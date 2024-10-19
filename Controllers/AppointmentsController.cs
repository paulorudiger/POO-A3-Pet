using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POO_A4.Models;
using POO_A4.Services;
using System;

namespace POO_A4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _service;
        private readonly ILogger _logger;

        public AppointmentsController(AppointmentService service, ILogger<AppointmentsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Rota para inserção de novos produtos
        /// </summary>
        /// <param name="productDTO">JSON dos dados que serão inseridos.
        ///     Obrigatórios: Description, Barcode, Barcodetype, Stock, Price, Costprice
        /// </param>
        /// <returns>Retorna o produto inserido</returns>
        /// <response code="200">Retorna o JSON com o produto cadastrado</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="422">Campos obrigatórios não enviados para a inserção do produto</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpPost]
        public ActionResult<Appointment> Insert()
        {
            try
            {
                //  var entity = _service.Insert(productDTO);
                return Ok(null);
            }
            catch (Exception E)
            {
                return BadRequest(E.Message);
            }
        }
    }
}