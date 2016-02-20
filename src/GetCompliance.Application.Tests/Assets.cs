using System.IO;
using NUnit.Framework;

namespace GetCompliance.Application.Tests
{
    public static class Assets
    {
        public static string EmlTestFilePath => Path.Combine(TestContext.CurrentContext.TestDirectory, "Assets", "test.eml");
    }
}