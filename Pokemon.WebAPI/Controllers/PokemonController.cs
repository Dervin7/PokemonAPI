using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Services.Pokemon;
using Pokemon.Data;
using Pokemon.Models.Pokemon;

namespace Pokemon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pService;
        public PokemonController(IPokemonService pService)
        {
            _pService = pService;
        }

        [HttpGet("{pokemonId:int}")]
        public async Task<IActionResult> GetPokemonById(int pokemonId)
        {
            var pokemon = await _pService.GetPokemonByIdAsync(pokemonId);
            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePokemon([FromBody] CreatePokemon request)
        {
            var newPokemon = await _pService.CreatePokemonAsync(request);
            if (newPokemon == null)
            {
                return NotFound();
            }

            return Ok(newPokemon);
        }
    }
}