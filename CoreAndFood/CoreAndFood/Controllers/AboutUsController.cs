using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class AboutUsController : Controller
    {
		[AllowAnonymous]
		public IActionResult Index()
        {
            return View();
        }
    }
}
