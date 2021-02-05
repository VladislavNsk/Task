using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using DocumentsStorage.Models;
using DocumentsStorage.Repositories;
using DocumentsStorage.Services;

namespace DocumentsStorage.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController()
        {
            _userService = new UserService(new UserRepository());
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Documents", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (_userService.HasUser(user.Login))
            {
                ModelState.AddModelError("", "Пользователь с таким именем уже существует");
                return View();
            }

            _userService.Add(user);
            SetCookie(user);

            return RedirectToAction("Documents", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Documents", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!_userService.HasUser(user))
            {
                ModelState.AddModelError("", "Введен не правильный логин/пароль");
                return View();
            }

            SetCookie(user);
            return RedirectToAction("Documents", "Home");
        }

        private void SetCookie(User user)
        {
            var ticket = new FormsAuthenticationTicket(user.Login, true, 3000);
            var encrypt = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypt)
            {
                Expires = DateTime.Now.AddHours(3000),
                HttpOnly = true
            };

            Response.Cookies.Add(cookie);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
