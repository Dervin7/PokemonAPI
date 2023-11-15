using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokemon.Models.Pokemon;

namespace Pokemon.Services.Pokemon
{
    public interface IPokemonService
    {
        Task<PokemonModel> CreatePokemonAsync(CreatePokemon createModel);
        Task<PokemonModel> GetPokemonByIdAsync(int Id);
    }
}