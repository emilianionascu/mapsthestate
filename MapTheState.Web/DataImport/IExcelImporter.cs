using OfficeOpenXml;

namespace MapTheState.Web.DataImport
{
    public interface IExcelImporter
    {
        void ImportFile(ExcelPackage package);
    }
}