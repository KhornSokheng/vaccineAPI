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
    public class VaccinationController : ControllerBase
    {
        private readonly IVaccinationRepository vaccinationRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IVaccineRepository vaccineRepository;


        public VaccinationController(IVaccinationRepository vaccinationRepository, ICountryRepository countryRepository, IVaccineRepository vaccineRepository)
        {
            this.vaccinationRepository = vaccinationRepository;
            this.countryRepository = countryRepository;
            this.vaccineRepository = vaccineRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetVaccinations()
        {
            try
            {
                return Ok(await vaccinationRepository.GetVaccinations());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data From The Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Vaccination>> GetVaccination(int id)
        {
            try
            {
                var result = await vaccinationRepository.GetVaccination(id);
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
        public async Task<ActionResult<IEnumerable<Vaccination>>> Search(string countryName, string vaccineName)
        {
            try
            {
                var country_id = 0;
                var vaccine_id = 0;
                if (!string.IsNullOrEmpty(countryName))
                {
                    var country = await countryRepository.GetCountryByName(countryName);
                    if (country == null)
                        return NotFound($"Country Name = {countryName} not found");
                    country_id = country.CountryID;
                }

                if (!string.IsNullOrEmpty(vaccineName))
                {
                    var vaccine = await vaccineRepository.GetVaccineByName(vaccineName);
                    if (vaccine == null)
                        return NotFound($"Vaccine Name = {vaccineName} not found");
                    vaccine_id = vaccine.VaccineID;
                }

                var result = await vaccinationRepository.Search(country_id, vaccine_id);
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
        public async Task<ActionResult<Vaccination>> AddVaccination(Vaccination vaccination)
        {
            try
            {
                if (vaccination == null)
                    return BadRequest();

                var newVaccination = await vaccinationRepository.AddVaccination(vaccination);

                return CreatedAtAction(nameof(GetVaccination), new { id = newVaccination.VaccinationID }, newVaccination);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating new vaccination record");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteVaccination(int id)
        {
            try
            {
                var vaccinationToDelete = await vaccinationRepository.GetVaccination(id);
                if (vaccinationToDelete == null)
                {
                    return NotFound($"vaccination with ID = {id} not found");

                }
                await vaccinationRepository.DeleteVaccination(id);

                return Ok($"vaccination With ID = {id} has deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Deleting vaccination Record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Vaccination>> UpdateVaccination(int id, Vaccination vaccination)
        {
            try
            {
                if (id != vaccination.VaccinationID)
                    return BadRequest("vaccination ID mismatch");
                var vaccinationToUpdate = await vaccinationRepository.GetVaccination(id);

                if (vaccinationToUpdate == null)
                {
                    return NotFound($"vaccination with ID = {id} not Found");
                }

                return await vaccinationRepository.UpdateVaccination(vaccination);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Updating vaccination Record");
            }
        }

    }
}
