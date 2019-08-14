using AudiShop.DataAccess;
using AudiShop.Models;
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
            if (modelName.ToUpperInvariant().Length == 2)
            {
                var _modList = _db.Models.Where(m => m.NameString.ToUpper() == modelName.ToUpper()).ToList();
                return View(_modList);
            }
            var _catList = _db.Categories.Where(c => c.Name.ToUpper() == modelName.ToUpper()).Single();
            var _models = _catList.Models.ToList();
            return View(_models);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ModelsMenu()
        {
            var _categories = _db.Categories.Select(x => x.Name).ToArray();
            var _models = Enum.GetValues(typeof(ModelType)).Cast<ModelType>().Select(x => x.ToString()).ToArray();

            string[][] _result = new string[][]
            {
                _categories,
                _models
            };
            
            return PartialView("_ModelsMenu",_result);
        }
    }
}