using OMDB.BLL;
using OMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMDB.DAL.EntityFramework;
using System.IO;

namespace OMDB.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AccountService service = new AccountService();
                bool success = service.CheckLogin(model.Username, model.Password);

                if (success)
                {
                    User user = service.GetUserDetailByUsername(model.Username);
                    if (user.UserType == 1)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                }
            }

            return View(model);
        }

        public ActionResult SingUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SingUp(SingUpModel model, HttpPostedFileBase avatar)
        {
            if (ModelState.IsValid)
            {
                var fullFileName = "";

                if (avatar != null && avatar.ContentLength > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var ext = Path.GetExtension(avatar.FileName);
                    fullFileName = fileName + ext;
                    var fullPath = Path.Combine(Server.MapPath("~/documents/avatars"),fullFileName);
                    avatar.SaveAs(fullPath);
                }

                User user = new User();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Username = model.Username;
                user.Password = model.Password;
                user.Email = model.Email;
                user.ProfilePicture = fullFileName;
                user.UserType = 2;

                AccountService aservice = new AccountService();
                aservice.Create(user);
            }
            return View();
        }
    }
}