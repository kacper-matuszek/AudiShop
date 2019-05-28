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
            var models = Enum.GetValues(typeof(ModelType)).Cast<ModelType>();

            var vm = new HomeViewModel()
            {
                Models = models
            };
            return View(vm);
        }
    }
}