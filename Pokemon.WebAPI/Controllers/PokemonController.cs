using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Services.Pokemon;

namespace Pokemon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);
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
            if (newPokemon is null)
            {
                return NotFound();
            }

            return Ok(newPokemon);
        }
    }
}