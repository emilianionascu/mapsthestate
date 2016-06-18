using System.Linq;
using MapTheState.Web.Domain;
using MapTheState.Web.Repositories;
using OfficeOpenXml;

namespace MapTheState.Web.DataImport
{
    public class ExcelImporter : IExcelImporter
    {
        private readonly IInstitutionsRepository _institutionsRepository;

        public ExcelImporter(IInstitutionsRepository institutionsRepository)
        {
            _institutionsRepository = institutionsRepository;
        }

        public void ImportFile(ExcelPackage package)
        {
            var worksheet = package.Workbook.Worksheets["Sheet1"];
            var institutions = worksheet.Cells.GroupBy(cell => cell.Start.Row).Skip(1).Select(rowGrouping =>
            {
                var rowCells = rowGrouping.ToDictionary(rowCell => rowCell.Address.Substring(0, 1), rowCell => rowCell.Text);

                var result = Institution.FromListOfCells(rowCells);
                

                return result;
            }).ToList();

            foreach (var institution in institutions)
            {
                _institutionsRepository.SaveInstitution(institution);
            }
        }
    }
}