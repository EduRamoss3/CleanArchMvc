using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
