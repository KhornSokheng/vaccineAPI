using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineAPI.Server.Models;
using VaccineAPI.Shared;

namespace VaccineAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineRepository vaccineRepository;
        public VaccineController(IVaccineRepository vaccineRepository)
        {
            this.vaccineRepository = vaccineRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetVaccines()
        {
            try
            {
                return Ok(await vaccineRepository.GetVaccines());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data From The Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Vaccine>> GetVaccine(int id)
        {
            try
            {
                var result = await vaccineRepository.GetVaccine(id);
                if ((result == null))
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data From The Database");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Vaccine>>> Search(string vaccineName)
        {
            try
            {
                var result = await vaccineRepository.Search(vaccineName);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Vaccine>> AddVaccine(Vaccine vaccine)
        {
            try
            {
                if (vaccine == null)
                    return BadRequest();

                var newVaccine = await vaccineRepository.AddVaccine(vaccine);

                return CreatedAtAction(nameof(GetVaccine), new { id = newVaccine.VaccineID }, newVaccine);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating new vaccine record");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteVaccine(int id)
        {
            try
            {
                var vaccineToDelete = await vaccineRepository.GetVaccine(id);
                if (vaccineToDelete == null)
                {
                    return NotFound($"Vaccine with ID = {id} not found");

                }
                await vaccineRepository.DeleteVaccine(id);

                return Ok($"Vaccine With ID = {id} has deleted");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Deleting Vaccine Record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Vaccine>> UpdateVaccine(int id, Vaccine vaccine)
        {
            try
            {
                if (id != vaccine.VaccineID)
                    return BadRequest("Vaccine ID mismatch");
                var vaccineToUpdate = await vaccineRepository.GetVaccine(id);

                if (vaccineToUpdate == null)
                {
                    return NotFound($"Vaccine with ID = {id} not Found");
                }

                return await vaccineRepository.UpdateVaccine(vaccine);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Updating vaccine Record");
            }
        }

    }
}
