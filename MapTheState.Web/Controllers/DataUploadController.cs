using System.Net;
using System.Web.Mvc;
using MapTheState.Web.DataImport;
using MapTheState.Web.Models;
using Neo4jClient;
using Newtonsoft.Json.Serialization;
using OfficeOpenXml;

namespace MapTheState.Web.Controllers
{
    public class DataUploadController : Controller
    {
        private readonly IExcelImporter _excelImporter;

        public DataUploadController(IExcelImporter excelImporter)
        {
            _excelImporter = excelImporter;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadData(UploadDataViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dataStream = new ExcelPackage(model.File.InputStream);
                _excelImporter.ImportFile(dataStream);
            }

            return new HttpStatusCodeResult(HttpStatusCode.Accepted);
        }
    }
}