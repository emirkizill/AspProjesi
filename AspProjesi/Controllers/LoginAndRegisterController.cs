using AspProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing.Printing;

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

		public IActionResult UserLogin(userinfo info)

		{
			if (!ModelState.IsValid) 
            {
				userinfo kullanici=appDbContext.Userinfo.Where(usertest => usertest.username == info.username && usertest.password == info.password).FirstOrDefault();



            if(kullanici==null)
                {
                    ViewBag.ErrorMessage = "Kullanici adi veya sifre hatalidir";

                    return View("Login");

                }
            else
                {

                    return View(info);

                }
            
            
            }

            else
            {
                return View("Login");
            }

            
		}

	}
}
