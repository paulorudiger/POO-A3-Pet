using Microsoft.AspNetCore.Mvc;

namespace POO_A4.Controllers
{
    public class AppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
