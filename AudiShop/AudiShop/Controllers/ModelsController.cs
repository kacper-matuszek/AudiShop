using AudiShop.DataAccess;
using AudiShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult Lista(string modelName, string searchQuery = null)
        {
            if (modelName.ToUpperInvariant().Length == 2)
            {
                if(searchQuery != null)
                {
                    List<Model> _searchMod;

                    if (User.IsInRole("Admin"))
                        _searchMod = _db.Models.Where(m => m.NameString.ToUpper().Contains(searchQuery.ToUpper())).ToList();
                    else
                        _searchMod = _db.Models.Where(m => m.NameString.ToUpper().Contains(searchQuery.ToUpper())).ToList();

                    if(Request.IsAjaxRequest())
                    {
                        return PartialView("_ModelList", _searchMod);
                    }

                    return View(_searchMod);
                }

                List<Model> _modList;

                if(User.IsInRole("Admin"))
                    _modList = _db.Models.Where(m => m.NameString.ToUpper() == modelName.ToUpper()).ToList();
                else
                    _modList = _db.Models.Where(m => m.NameString.ToUpper() == modelName.ToUpper() && m.Available).ToList();

                return View(_modList);
            }
            var _catList = _db.Categories.Where(c => c.Name.ToUpper() == modelName.ToUpper()).Single();
            var _models = _catList.Models.ToList();
            return View(_models);
        }

        public ActionResult Details(int id)
        {
            var _carModel = _db.Models.Find(id);

            return View(_carModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
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

        public ActionResult ModelsPrompt(string term)
        {
            var _models = _db.Models.Where(x => x.Available && x.NameString.ToLower().Contains(term.ToLower()))
                .Take(5)
                .Select(x => new { label = x.NameString });

            return Json(_models, JsonRequestBehavior.AllowGet);
        }
    }
}