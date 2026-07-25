using System;
using System.IO;

namespace LateboundConstantGeneratorTests
{
    public static class TestContentHelper
    {
        private static readonly string TestDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "testdata");
        
        public static string GetExpectedTestContent(string filename, string date)
        {
            var templatePath = Path.Combine(TestDataPath, "ExpectedTestContent.cs");
            var template = File.ReadAllText(templatePath);
            return string.Format(template, filename, date);
        }
        
        public static string GetTestDataContent()
        {
            return @"public class TestClass
{
    public const string EntityName = ""test_entity"";
}";
        }
        
        public static string GetModifiedTestDataContent()
        {
            return @"public class TestClass
{
    public const string EntityName = ""modified_entity"";
    public const string NewProperty = ""new_value"";
}";
        }
        
        public static string GetNewTestDataContent()
        {
            return @"public class TestClass
{
    public const string EntityName = ""new_entity"";
}";
        }
    }
}
