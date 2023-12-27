using AspProjesi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing.Printing;
using System.Security.Claims;
using Microsoft.Win32;
using System.Data.Entity;
using Microsoft.AspNetCore.Antiforgery;

namespace AspProjesi.Controllers
{

    public class LoginAndRegisterController : Controller
    {
        private readonly ContextApp appDbContext;

        public IActionResult Login()
        {
            return View();
        }

        public LoginAndRegisterController(ContextApp appDbContext)
        {
            this.appDbContext = appDbContext;

        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegister(userinfo info)

        {
            if (ModelState.IsValid)

            {
                userinfo userinfo = new userinfo();
                userinfo.name = info.name;
                userinfo.surname = info.surname;
                userinfo.email = info.email;
                userinfo.password =info.password;
                userinfo.Role = Role.User;

  
                appDbContext.Userinfo.Add(info);
                appDbContext.SaveChanges();
                ViewBag.Message = "Kayıt işlemi başarılı.Lütfen giriş yapınız.";
                return View("Login");

            }
            return View("Register");

        }
        [HttpPost]

        public async Task<IActionResult> UserLogin(userinfo info)

        {

            if (!ModelState.IsValid)
            {
                userinfo kullanici = appDbContext.Userinfo.Where(usertest => usertest.username == info.username && usertest.password == info.password).FirstOrDefault();



                if (kullanici == null)
                {
                    ViewBag.ErrorMessage = "Kullanici adi veya sifre hatalidir";

                    return View("Login");

                }
                else
                {

                    var claims = new List<Claim>
{
                     new Claim(ClaimTypes.Name, info.username),
                     new Claim(ClaimTypes.Role, info.Role.ToString())
};
                    var appIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var AuthProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(appIdentity), AuthProperties);

                    if (info.email == "a@gmail.com" && info.Role == Role.Admin)
                    {
                        return RedirectToAction("LoginAndRegister", "AdminPanel", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("LoginAndRegister", "UserLogin", new { area = "User" });
                    }
                }


            }

            else
            {

                return View("Login");
            }
                

        }
        [Authorize]
        public IActionResult LoggedHome(userinfo info)
        {

            return View(info);

        }
        public IActionResult AdminPanel() 
        {

            return View();
        
        }

    }
}
