using System.IO;
using MapTheState.Web.DataImport;
using MapTheState.Web.Repositories;
using NUnit.Framework;
using OfficeOpenXml;

namespace MapTheState.Tests
{
    [TestFixture]
    public class GivenExcelImporter
    {
        private ExcelPackage _package;

        [SetUp]
        public void Setup()
        {
            _package = new ExcelPackage(new FileInfo("TestDb.xlsx"));
        }

        [Test]
        public void WhenImportFileThenFileIsImported()
        {
        }
    }
}
