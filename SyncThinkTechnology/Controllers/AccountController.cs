using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SyncThinkTechnology.Models;
using BCrypt.Net;
using System.Web.Helpers;

namespace SyncThinkTechnology.Controllers
{
    public class AccountController : Controller
    {
        SyncThinkDatabaseEntities syncThink = new SyncThinkDatabaseEntities();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = syncThink.UserInfoes.Any(x => x.Username == credentials.Email && x.Password == credentials.Password);
            UserInfo u = syncThink.UserInfoes.FirstOrDefault(x => x.Username == credentials.Email && x.Password == credentials.Password);

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or password is incorrect.");

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserInfo userInfor)
        {
            syncThink.UserInfoes.Add(userInfor);
            syncThink.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult SignOut()
        {
            return View();
        }
    }
}