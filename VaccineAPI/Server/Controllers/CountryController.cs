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
       

    }
}
