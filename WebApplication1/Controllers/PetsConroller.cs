using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IDBService _dbService;
        public PetsController(IDBService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet("{year:DateTime}")]
        public IActionResult GetPets(DateTime year)
        {
            try
            {
                var result = _dbService.GetPets(year);
                return Ok(result);
            }
            catch (PetDoesNotExist exc)
            {
                return NotFound(exc.Message);
            }
        }

        [HttpPost("{id:int}")]
        public IActionResult AddPet(int id, int idBreedType, string Name, bool IsMale, DateTime DateDeath, DateTime DateAdopted)
        {
            try
            {
                var response = _dbService.AddPet(id, idBreedType, Name, IsMale, DateDeath, DateAdopted);
                return Created("Pet added", response);
            }
            catch (NoSuchBreed ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}