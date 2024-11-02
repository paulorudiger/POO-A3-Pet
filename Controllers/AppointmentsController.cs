using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Domain;
using POO_A3_Pet.Services;
using POO_A3_Pet.Services.Interfaces;
using POO_A4.Database;
using POO_A4.Interfaces;
using POO_A4.Services;
using POO_A4.Services.DTOs;
using System;
using System.Collections.Generic;

namespace POO_A4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(PetDbContext context)
        {
            // _service = service;
            _service = new AppointmentService(context);
        }

        [HttpPost]
        public ActionResult<Appointment> Insert([FromBody] AppointmentDTO body)
        {
            try
            {
                var entity = _service.Add(body);
                return Ok(null);
            }

            // TODO: tratar tipos de erro com os status code corretos
            catch (Exception E)
            {
                Logger.Warn("asdasd");
                return BadRequest(E.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Appointment> GetById(int id)
        {
            try
            {
                var appointment = _service.GetById(id);
                if (appointment == null)
                    return NotFound("Appointment not found");

                return Ok(appointment);
            }
            // TODO: tratar tipos de erro com os status code corretos
            catch (Exception e)
            {
                // log
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/getAll")]
        public ActionResult<IEnumerable<Appointment>> GetAll()
        {
            try
            {
                var appointments = _service.GetAll();
                return Ok(appointments);
            }
            // TODO: tratar tipos de erro com os status code corretos
            catch (Exception e)
            {
                // log
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Appointment> Update(int id, [FromBody] AppointmentDTO body)
        {
            try
            {
                var updatedAppointment = _service.Update(body);
                if (updatedAppointment == null)
                    return NotFound("Appointment not found");

                return Ok(updatedAppointment);
            }
            // TODO: tratar tipos de erro com os status code corretos
            catch (Exception e)
            {
                // log
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: delete nao apaga do banco
                _service.Delete(id);

                return NoContent();
            }
            // TODO: tratar tipos de erro com os status code corretos
            catch (Exception e)
            {
                // log
                return BadRequest(e.Message);
            }
        }
    }
}