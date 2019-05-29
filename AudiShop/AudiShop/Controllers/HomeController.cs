using AudiShop.DataAccess;
using AudiShop.Models;
using AudiShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AudiShop.Controllers
{
    public class HomeController : Controller
    {
        private AudiContext _db = new AudiContext();

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