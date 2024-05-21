using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
