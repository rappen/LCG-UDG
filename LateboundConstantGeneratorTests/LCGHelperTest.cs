using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rappen.XTB.LCG.Cmd;

namespace LateboundConstantGeneratorTests
{
    [TestClass]
    public class LCGHelperTest
    {
        [TestMethod]
        [DeploymentItem(@"testdata\LateboundConstantsGeneratorConfiguration.xml")]
        public void LoadSettingsFromFile_Should_LoadTestFileSettings()
        {
            // Arrange
            var lcgHelper = new LCGHelper();

            // Act
            lcgHelper.LoadSettingsFromFile("LateboundConstantsGeneratorConfiguration.xml");

            // Assert
            Assert.IsNotNull(lcgHelper.Settings);
            Assert.AreEqual("LateboundConstantGeneratorTests", lcgHelper.Settings.NameSpace);
            Assert.AreEqual(3, lcgHelper.Settings.Selection.Count);
            Assert.AreEqual("contact:", lcgHelper.Settings.Selection[0]);
        }

        [TestMethod, TestCategory("Integration")]
        [DeploymentItem(@"testdata\LateboundConstantsGeneratorConfiguration.xml")]
        public void GenerateConstants_Should_GenerateConstantsFileClass()
        {
            // Arrange
            var lcgHelper = new LCGHelper();
            lcgHelper.LoadSettingsFromFile("LateboundConstantsGeneratorConfiguration.xml");
            var filename = $"constants_{Guid.NewGuid()}.cs";
            var credentials = new CrmCredentials
            {
                Domain = "MyDomain",
                OrgUnit = "MyOrganizationUnit",
                ServerName = "MyServerName",
                Password = "MyPassword",
                Protocol = CrmCredentials.protocol.https,
                User = "MyUsername"
            };
            lcgHelper.ConnectCrm(credentials);

            // Act
            lcgHelper.GenerateConstants();

            // Assert
            Assert.IsTrue(File.Exists(Path.Combine(lcgHelper.Settings.OutputFolder, lcgHelper.Settings.CommonFile + ".cs")));
        }
    }
}
