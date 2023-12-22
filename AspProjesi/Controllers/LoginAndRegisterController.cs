using AspProjesi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing.Printing;
using System.Security.Claims;

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
                appDbContext.Userinfo.Add(info);
                appDbContext.SaveChanges();

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
                        new Claim(ClaimTypes.Name,info.name),
                        new Claim(ClaimTypes.Role, "User")

                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var AuthProperties = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), AuthProperties);
                    return RedirectToAction("Index", "Home");

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

    }
}
