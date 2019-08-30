using AudiShop.App_Start;
using AudiShop.DataAccess;
using AudiShop.Helpers;
using AudiShop.Models;
using AudiShop.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AudiShop.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private AudiContext _db = new AudiContext();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: Manage
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            if (User.IsInRole("Admin"))
                ViewBag.UserIsAdmin = true;
            else
                ViewBag.UserIsAdmin = false;

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return View("Error");
            }

            var model = new ManageCredentialsViewModel
            {
                Message = message,
                UserData = user.UserData
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeProfile([Bind(Prefix = "UserData")]UserData userData)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UserData = userData;

                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword([Bind(Prefix = "ChangePasswordViewModel")]ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return View("Index");
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
           
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var message = ManageMessageId.ChangePasswordSuccess;
            return RedirectToAction("Index", new { Message = message });
        }
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        public ActionResult OrdersList()
        {
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = isAdmin;

            IEnumerable<Order> userOrders;

            if (isAdmin)
            {
                userOrders = _db.Orders.Include(d => d.OrderDetails).OrderByDescending(d => d.CreatedDate).ToArray();
            } else
            {
                var userID = User.Identity.GetUserId();
                userOrders = _db.Orders.Where(d => d.UserID == userID).Include(d => d.OrderDetails).OrderByDescending(d => d.CreatedDate).ToArray(); 
            }

            return View(userOrders);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public OrderStatus ChangeOfOrderStatus(Order order)
        {
            Order orderToModify = _db.Orders.Find(order.OrderID);

            orderToModify.Status = order.Status;
            _db.SaveChanges();

            return order.Status;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddModel(int? modelID, bool? confirmation)
        {
            Model model;

            if (modelID.HasValue)
            {
                ViewBag.EditMode = true;
                model = _db.Models.Find(modelID);
            } else
            {
                ViewBag.EditMode = false;
                model = new Model();
            }

            var result = new EditModelViewModel
            {
                Categories = _db.Categories.ToList(),
                Engines = _db.Engines.ToList(),
                Model = model,
                Confirmation = confirmation
            };

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddModel(EditModelViewModel model, HttpPostedFileBase file)
        {
            if (model.Model.ModelID > 0)
            {
                _db.Entry(model.Model).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("AddModel", new { confirmation = true });
            }

            //It check whether user choose the file
            if (file != null && file.ContentLength > 0)
            {

                if (ModelState.IsValid)
                {
                    var fileExt = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid() + fileExt;

                    var path = Path.Combine(Server.MapPath(AppConfig.ModelIcons), fileName);
                    file.SaveAs(path);

                    model.Model.PictureName = fileName;
                    model.Model.CreatedDate = DateTime.Now;

                    _db.Entry(model.Model).State = EntityState.Added;
                    _db.SaveChanges();

                    return RedirectToAction("AddModel", new { confirmation = true });
                }

                model.Categories = _db.Categories.ToList(); ;

                return View(model);
            }

            ModelState.AddModelError("", "Nie wskazano pliku");

            var category = _db.Categories.ToList();
            model.Categories = category;

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult HideModel(int modelID)
        {
            var model = _db.Models.Find(modelID);
            model.Available = false;
            _db.SaveChanges();

            return RedirectToAction("AddModel", new { confirmation = true });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ShowModel(int modelID)
        {
            var model = _db.Models.Find(modelID);
            model.Available = true;
            _db.SaveChanges();

            return RedirectToAction("AddModel", new { confirmation = true });
        }

        [AllowAnonymous]
        public ActionResult SendMailOfOrderConfirmation (int orderID, string lastName)
        {
            var order = _db.Orders.Include(o => o.OrderDetails).Include(o => o.OrderDetails.Select(od => od.Model)).SingleOrDefault(o => o.OrderID == orderID && o.LastName == lastName);

            if (order == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }


            OrderConfirmationEmail email = new OrderConfirmationEmail()
            {
                To = order.Email,
                From = "AudiShop@gmail.com",
                OrderValue = order.Value,
                OrderNumber = order.OrderID,
                OrderDetails = order.OrderDetails
            };

            email.Send();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}