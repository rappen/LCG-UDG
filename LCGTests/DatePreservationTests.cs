using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rappen.XTB.LCG;

namespace LateboundConstantGeneratorTests
{
    [TestClass]
    public class DatePreservationTests
    {
        private string _testFilePath;

        [TestInitialize]
        public void Setup()
        {
            _testFilePath = Path.GetTempFileName();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [TestMethod]
        public void WriteFile_WhenContentUnchanged_ShouldPreserveOriginalDate()
        {
            // Arrange
            var settings = new Settings();
            settings.NameSpace = "TestNamespace";
            var originalDate = "2023-01-15 10:30:45";
            var originalContent = TestContentHelper.GetExpectedTestContent(Path.GetFileName(_testFilePath), originalDate);

            // Write original file
            File.WriteAllText(_testFilePath, originalContent);

            // Act - Write the same content again
            var dataContent = TestContentHelper.GetTestDataContent();
            var result = dataContent.WriteFile(_testFilePath, "https://test.crm.dynamics.com", settings);

            // Assert
            Assert.IsTrue(result);
            var finalContent = File.ReadAllText(_testFilePath);
            Assert.IsTrue(finalContent.Contains(originalDate), "Original date should be preserved");
            Assert.IsFalse(finalContent.Contains(DateTime.Now.ToString("yyyy-MM-dd")), "Current date should not be used");
        }

        [TestMethod]
        public void WriteFile_WhenContentChanged_ShouldUpdateDate()
        {
            // Arrange
            var settings = new Settings();
            settings.NameSpace = "TestNamespace";
            var originalDate = "2023-01-15 10:30:45";
            var originalContent = TestContentHelper.GetExpectedTestContent(Path.GetFileName(_testFilePath), originalDate);

            // Write original file
            File.WriteAllText(_testFilePath, originalContent);

            // Act - Write different content
            var dataContent = TestContentHelper.GetModifiedTestDataContent();
            var result = dataContent.WriteFile(_testFilePath, "https://test.crm.dynamics.com", settings);

            // Assert
            Assert.IsTrue(result);
            var finalContent = File.ReadAllText(_testFilePath);
            Assert.IsFalse(finalContent.Contains(originalDate), "Original date should not be preserved when content changes");
            Assert.IsTrue(finalContent.Contains(DateTime.Now.ToString("yyyy-MM-dd")), "Current date should be used when content changes");
            Assert.IsTrue(finalContent.Contains("modified_entity"), "Modified content should be present");
        }

        [TestMethod]
        public void WriteFile_WhenOnlyFilenameChanged_ShouldPreserveOriginalFilename()
        {
            // Arrange
            var settings = new Settings();
            settings.NameSpace = "TestNamespace";
            var originalDate = "2023-01-15 10:30:45";
            var originalFilename = "OriginalFile.cs";
            var originalContent = TestContentHelper.GetExpectedTestContent(originalFilename, originalDate);

            // Write original file
            File.WriteAllText(_testFilePath, originalContent);

            // Act - Write content with different filename
            var dataContent = TestContentHelper.GetTestDataContent();
            var result = dataContent.WriteFile(_testFilePath, "https://test.crm.dynamics.com", settings);

            // Assert
            Assert.IsTrue(result);
            var finalContent = File.ReadAllText(_testFilePath);
            Assert.IsTrue(finalContent.Contains(originalFilename), "Original filename should be preserved");
            Assert.IsFalse(finalContent.Contains("ModifiedFile.cs"), "Modified filename should not be used");
            Assert.IsTrue(finalContent.Contains(originalDate), "Original date should also be preserved");
        }

        [TestMethod]
        public void WriteFile_WhenFileDoesNotExist_ShouldUseCurrentDate()
        {
            // Arrange
            var settings = new Settings();
            settings.NameSpace = "TestNamespace";
            var dataContent = TestContentHelper.GetNewTestDataContent();

            // Act - Write to new file
            var result = dataContent.WriteFile(_testFilePath, "https://test.crm.dynamics.com", settings);

            // Assert
            Assert.IsTrue(result);
            var finalContent = File.ReadAllText(_testFilePath);
            Assert.IsTrue(finalContent.Contains(DateTime.Now.ToString("yyyy-MM-dd")), "Current date should be used for new files");
            Assert.IsTrue(finalContent.Contains("new_entity"), "New content should be present");
        }
    }
}
