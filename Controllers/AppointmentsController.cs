using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Services;
using POO_A3_Pet.Services.Interfaces;
using POO_A4.Database;
using POO_A4.Interfaces;
using POO_A4.Services;
using System;

namespace POO_A4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        //private readonly ILogger _logger;

        public AppointmentsController(PetDbContext context)
        {
            // _service = service;
            _service = new AppointmentService(context);
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
                //  _service.Add(new Appointment());

                // Logg

                //  var entity = _service.Insert(productDTO);
                return Ok(null);
            }
            catch (Exception E)
            {
                //log
                return BadRequest(E.Message);
            }
        }
    }
}