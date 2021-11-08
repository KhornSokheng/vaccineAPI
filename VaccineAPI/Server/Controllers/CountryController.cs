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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        public CountriesController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Getcountries()
        {
            try
            {
                return Ok(await countryRepository.GetCountries());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data From The Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            try
            {
                var result = await countryRepository.GetCountry(id);
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
        public async Task<ActionResult<IEnumerable<Country>>> Search(string countryName)
        {
            try
            {
                var result = await countryRepository.Search(countryName);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountry(Country country)
        {
            try
            {
                if (country == null)
                    return BadRequest();
                var createdCountry = await countryRepository.AddCountry(country);
                return CreatedAtAction(nameof(GetCountry),
                new { id = createdCountry.CountryID }, createdCountry);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new Country record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Country>> UpdateCountry(int id, Country country)
        {
            try
            {

                var CountryToUpdate = await countryRepository.GetCountry(id);
                if (CountryToUpdate == null)
                {
                    return NotFound($"Country with Id = {id} not found");
                }
                return await countryRepository.UpdateCountry(country);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating employee record");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            try
            {
                var countryToDelete = await countryRepository.GetCountry(id);
                if (countryToDelete == null)
                {
                    return NotFound($"Country with Id = {id} not found");
                }
                await countryRepository.DeleteCountry(id);
                return Ok($"Country with Id = {id} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleting country record");
            }
        }


    }
}
