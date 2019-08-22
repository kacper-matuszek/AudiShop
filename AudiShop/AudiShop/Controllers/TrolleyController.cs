using AudiShop.DataAccess;
using AudiShop.Helpers;
using AudiShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AudiShop.Controllers
{
    public class TrolleyController : Controller
    {
        private TrolleyManager _trolleyManager;
        private ISessionManager _sessionManager;
        private AudiContext _db;

        public TrolleyController()
        {
            _db = new AudiContext();
            _sessionManager = new SessionManager();
            _trolleyManager = new TrolleyManager(_sessionManager, _db);
        }
        // GET: Trolley
        public ActionResult Index()
        {
            var positionsOfTrolley = _trolleyManager.GetTrolley();
            var totalPrice = _trolleyManager.GetValueOfTrolley();

            TrolleyViewModel trolleyVM = new TrolleyViewModel()
            {
                PositionsTrolley = positionsOfTrolley,
                TotalPrice = totalPrice
            };


            return View(trolleyVM);
        }

        public ActionResult AddToTrolley(int id)
        {
            _trolleyManager.AddToTrolley(id);

            return RedirectToAction("Index");
        }

        public int GetCountItems()
        {
            return _trolleyManager.GetCountOfTrolley();
        }

        public ActionResult RemoveFromTrolley(int modelID)
        {
            int countPosition = _trolleyManager.RemoveFromTrolley(modelID);
            int countPositionOfTrolley = _trolleyManager.GetCountOfTrolley();
            decimal valueOfTrolley = _trolleyManager.GetValueOfTrolley();

            var result = new TrolleyRemovingViewModel()
            {
                IdPositionRemoving = modelID,
                CountToRemove = countPosition,
                TrolleyTotalPrice = valueOfTrolley,
                TrolleyTotalPriceString = String.Format("{0: ### ###} zł", valueOfTrolley),
                CountPositionsOfTrolley = countPositionOfTrolley
            };

            return Json(result);
        }
    }
}