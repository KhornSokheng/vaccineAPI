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
    public class ContinentController: ControllerBase
    {
        private readonly IContinentRepository continentRepository;
        public ContinentController(IContinentRepository continentRepository)
        {
            this.continentRepository = continentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetContinents()
        {
            try
            {
                return Ok(await continentRepository.GetContinents());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data From The Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Continent>> GetContinent(int id)
        {
            try
            {
                var result = await continentRepository.GetContinent(id);
                if((result == null))
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
