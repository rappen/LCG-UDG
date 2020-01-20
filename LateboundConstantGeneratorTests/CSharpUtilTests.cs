using System.Collections.Generic;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk.Metadata;
using Rappen.XTB.LCG;

namespace LateboundConstantGeneratorTests
{
    [TestClass]
    public class CSharpUtilTests
    {
        [TestMethod]
        public void GenerateClasses_ForEmptyMetadata_Should_GenerateLogicalName()
        {
            // Arrange
            var metadata = new EntityMetadataProxy(new EntityMetadata
            {
                LogicalName = "uber_entity"
            });
            metadata.SetSelected(true);
            var values = new List<EntityMetadataProxy> { metadata };
            var settings = new Settings();
            settings.InitalizeCommonSettings(false);
            var fakeWriter = A.Fake<IConstantFileWriter>();
            string entity = null;
            var config = A.CallTo(() => fakeWriter.WriteBlock(null, null, null))
                .WithAnyArguments()
                .Invokes((Settings s, string e, string f) => { entity = e; });
            
            // Act
            CSharpUtils.GenerateClasses(values, settings, fakeWriter);

            // Assert
            config.MustHaveHappened();
            Assert.IsTrue(entity.Contains("public const string EntityName = \"uber_entity\";"));
            
        }

        [TestMethod]
        public void CamelCaseTest1()
        {
            var settings = new Settings();
            settings.InitalizeCommonSettings(false);
            var identifier = "theaccountnamecountid";
            var camelcased = identifier.CamelCaseIt(settings);
            Assert.AreEqual("TheAccountNameCountId", camelcased);

            identifier = "Accounting";
            camelcased = identifier.CamelCaseIt(settings);
            Assert.AreEqual("AccountIng", camelcased);
        }
    }
}
