using Microsoft.AspNetCore.Mvc;

namespace AspProjesi.Controllers
{
	public class LoggedController : Controller
	{
		public IActionResult Squad()
		{
			return View();
		}
	}
}
