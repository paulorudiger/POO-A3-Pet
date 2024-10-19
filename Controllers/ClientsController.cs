using Microsoft.AspNetCore.Mvc;

namespace POO_A4.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
