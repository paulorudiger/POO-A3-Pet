using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POO_A4.Services;

namespace POO_A4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {

        private readonly AppointmentService _service;
        private readonly ILogger _logger;


    }
}
