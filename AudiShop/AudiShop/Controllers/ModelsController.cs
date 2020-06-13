using System;
using System.Linq;
using System.Web.Mvc;
using AudiShop.Data;
using AudiShop.Data.Models;

namespace AudiShop.Controllers
{
    public class ModelsController : Controller
    {
        private AudiContext _db;

        public ModelsController(AudiContext db)
        {
            _db = db;
        }

        // GET: Models
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista(string modelName, string searchQuery = null)
        {
            if (modelName.ToString().ToUpperInvariant().Length == 2)
            {
                if(searchQuery != null)
                {
                    var searchMod = User.IsInRole("Admin") 
                        ? _db.Models.Where(m => m.Name.ToString().ToUpper().Contains(searchQuery.ToUpper())).ToList() 
                        : _db.Models.Where(m => m.Name.ToString().ToUpper().Contains(searchQuery.ToUpper())).ToList();

                    if(Request.IsAjaxRequest())
                    {
                        return PartialView("_ModelList", searchMod);
                    }

                    return View(searchMod);
                }

                var modList = User.IsInRole("Admin")
                    ? _db.Models.Where(m => m.Name.ToString().ToUpper() == modelName.ToUpper()).ToList()
                    : _db.Models.Where(m => m.Name.ToString().ToUpper() == modelName.ToUpper() && m.Available).ToList();

                return View(modList);
            }
            var catList = _db.Categories.Single(c => c.Name.ToString().ToUpper() == modelName.ToString().ToUpper());
            var models = catList.Models.ToList();
            return View(models);
        }

        public ActionResult Details(int id)
        {
            var carModel = _db.Models.Find(id);

            return View(carModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult ModelsMenu()
        {

            var categories = _db.Categories.Select(x => x.Name.ToString()).ToArray();
            var models = Enum.GetValues(typeof(ModelType)).Cast<ModelType>().Select(x => x.ToString()).ToArray();

            string[][] result = new string[][]
            {
                categories,
                models
            };
            
            return PartialView("_ModelsMenu",result);
        }

        public ActionResult ModelsPrompt(string term)
        {
            var models = _db.Models.Where(x => x.Available && x.Name.ToString().ToLower().Contains(term.ToLower()))
                .Take(5)
                .Select(x => new { label = x.Name.ToString() });

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}