using Microsoft.AspNetCore.Mvc;
using Pokemon.Models.Pokemon;
using Pokemon.Models.TypesModels;
using Pokemon.Services;
using System.Threading.Tasks;


namespace Pokemon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly IPokemonTypeService _pokemonTypeService;

        public TypesController(IPokemonTypeService pokemonTypeService)
        {
            _pokemonTypeService = pokemonTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateType([FromBody] PokemonTypesModels type)
        {
            var createdType = await _pokemonTypeService.CreateTypeAsync(type);
            if (createdType == null)
            {
                return BadRequest("Unable to create type");
            }

            return CreatedAtAction(nameof(GetTypeById), new { id = createdType.Id }, createdType);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var type = await _pokemonTypeService.GetTypeByIdAsync(id);
            if (type == null)
            {
                return NotFound();
            }

            return Ok(type);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var success = await _pokemonTypeService.DeleteTypeAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}