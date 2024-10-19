using Microsoft.AspNetCore.Mvc;

namespace POO_A4.Controllers
{
    public class PetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
