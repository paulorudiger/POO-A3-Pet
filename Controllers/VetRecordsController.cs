using Microsoft.AspNetCore.Mvc;
using POO_A4.Services.Interfaces;
using POO_A4.Services.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using POO_A3_Pet.Domain;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Services.Interfaces;
using POO_A4.Database;
using POO_A4.Services;

namespace POO_A4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetRecordsController : ControllerBase
    {
        private readonly IVetRecordService _service;

        public VetRecordsController(PetDbContext context)
        {
            _service = new VetRecordService(context);
        }

        [HttpPost]
        public ActionResult<VetRecord> Insert([FromBody] VetRecordDTO body)
        {
            try
            {
                var entity = _service.Add(body);
                return Ok(entity);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<VetRecord> GetById(int id)
        {
            try
            {
                var vetRecord = _service.GetById(id);
                if (vetRecord == null)
                    return NotFound("Vet record not found");

                return Ok(vetRecord);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("/getAllVetRecords")]
        public ActionResult<IEnumerable<VetRecord>> GetAll()
        {
            try
            {
                var vetRecords = _service.GetAll();
                return Ok(vetRecords);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<VetRecord> Update(int id, [FromBody] VetRecordDTO body)
        {
            try
            {
                var updatedVetRecord = _service.Update(body);
                if (updatedVetRecord == null)
                    return NotFound("Vet record not found");

                return Ok(updatedVetRecord);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}