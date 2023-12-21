using AspProjesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspProjesi.Controllers
{
	public class LoggedController : Controller
	{

		private readonly ContextApp appContext;
		public LoggedController(ContextApp appContext)
		{


			this.appContext = appContext;
		}
		public IActionResult Squad()
		{
			return View(appContext.Doctors.ToList());
		}
	}
}
