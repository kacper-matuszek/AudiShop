using AudiShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AudiShop.Controllers
{
    public class ModelsController : Controller
    {
        private AudiContext _db = new AudiContext();

        // GET: Models
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista(string modelName)
        {
            var catList = _db.Categories.Include("Models").Where(c => c.Name.ToUpper() == modelName.ToUpper()).Single();
            var models = catList.Models.ToList();
            return View(models);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ModelsMenu()
        {
            var _res = _db.Categories.ToList();

            return PartialView("_ModelsMenu",_res);
        }
    }
}