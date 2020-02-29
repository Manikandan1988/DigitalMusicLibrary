using DigitalMusicLibrary.Models.DataModels;
using DigitalMusicLibrary.Models.ViewModels;
using DigitalMusicLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalMusicLibrary.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ILoginRepository _repository = null;

        public HomeController()
        {
            this._repository = new LoginRepository();
        }
        public HomeController(ILoginRepository repository)
        {
            this._repository = repository;
        }


        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
                return RedirectToAction("Login");
            else
            {

            }
            return View();
        }

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userDetails = _repository.Login(new UserRole { UserName = viewModel.UserName, Password = viewModel.Password });
                if (string.IsNullOrEmpty(userDetails?.UserName))
                    ModelState.AddModelError("", "Login Failed");
                else
                {
                    Session["RoleID"] = userDetails.RoleID;
                    Session["UserName"] = userDetails.UserName;

                    if (userDetails.RoleID == 2)
                    {
                        return RedirectToAction("ViewMusicDetails", "ViewMusicDetail");
                    }
                    else if (userDetails.RoleID == 1)
                    {
                        return RedirectToAction("UploadMusicDetais", "AddMusicDetail");
                    }
                }
                return View(viewModel);
            }
            else
            {
                ModelState.AddModelError("", "Please Enter Valid Data");
                return View(viewModel);
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            Session.Abandon();

            return RedirectToAction("Login");
        }
    }
}