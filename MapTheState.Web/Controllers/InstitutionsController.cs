using System.Web.Mvc;
using MapTheState.Web.Models;

namespace MapTheState.Web.Controllers
{
    public class InstitutionsController : Controller
    {
        public InstitutionsController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddInstitution(AddInstitutionViewModel model)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }
    }
}