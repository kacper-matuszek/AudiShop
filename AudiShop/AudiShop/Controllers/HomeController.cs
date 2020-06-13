using System;
using System.Linq;
using System.Web.Mvc;
using AudiShop.Data;
using AudiShop.Data.Models;

namespace AudiShop.Controllers
{
    public class HomeController : Controller
    {
        private AudiContext _db;

        public HomeController(AudiContext db)
        {
            _db = db;
        }

        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

       public PartialViewResult Models()
        {
            var _res = Enum.GetValues(typeof(ModelType)).Cast<ModelType>().Select(x => x.ToString());

            return PartialView("_Menu", _res);
        }

        public PartialViewResult BodyWorks()
        {
            var _res = _db.Categories.Select(x => x.Name);

            return PartialView("_Menu", _res);
        }
    }
}