using AudiShop.App_Start;
using AudiShop.DataAccess;
using AudiShop.Helpers;
using AudiShop.Models;
using AudiShop.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Hangfire;
using System.Net;

namespace AudiShop.Controllers
{
    public class TrolleyController : Controller
    {
        private ISessionManager _sessionManager;
        private IMailService _mailService;
        private TrolleyManager _trolleyManager;
        private AudiContext _db;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public TrolleyController(AudiContext context, IMailService mailService, ISessionManager sessionManager)
        {
            _db = context;
            _mailService = mailService;
            _sessionManager = sessionManager;
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

        public async Task<ActionResult> Pay()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                //if user data exists in database, it automatically puts in textboxes
                var order = new Order()
                {
                    Name = user.UserData.Name,
                    LastName = user.UserData.LastName,
                    Address = user.UserData.Address,
                    City = user.UserData.City,
                    PostalCode = user.UserData.PostalCode,
                    Email = user.UserData.Email,
                    PhoneNumber = user.UserData.PhoneNumber
                };

                return View(order);
            }

            return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Pay", "Trolley") });
        }

        [HttpPost]
        public async Task<ActionResult> Pay(Order orderDetails)
        {
            if (ModelState.IsValid)
            {
                //Gets user id from current logged user
                var userID = User.Identity.GetUserId();

                //it creates order based on what we have in basket
                var newOrder = _trolleyManager.CreateOrder(orderDetails, userID);

                //user details - it updates user data
                var user = await UserManager.FindByIdAsync(userID);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);

                //clear basket
                _trolleyManager.EmptyTrolley();
                _mailService.SendMailOfOrderConfirmation(newOrder);

                return RedirectToAction("ConfirmationOrder");
            }

            return View(orderDetails);
        }
       
        public ActionResult ConfirmationOrder()
        {
            return View();
        }
    } 
}