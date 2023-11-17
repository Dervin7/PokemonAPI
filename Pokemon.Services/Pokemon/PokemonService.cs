using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokemon.Models.Pokemon;
using Pokemon.Data;
using Pokemon.Data.Entities;

namespace Pokemon.Services.Pokemon
{
    public class PokemonService : IPokemonService
    {
        private readonly ApplicationDbContext _dbContext;
        public PokemonService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<PokemonModel> GetPokemonByIdAsync(int Id)
        {
            var entity = await _dbContext.Pokemon.FindAsync(Id);
            if (entity == null)
            {
                return null;
            }

            var model = new PokemonModel
            {
                Id = entity.Id,
                Name = entity.Name
            };

            return model;
        }
        public async Task<PokemonModel> CreatePokemonAsync(CreatePokemon createModel)
        {
            var entity = new PokemonEntity
            {
                Name = createModel.Name
            };

            _dbContext.Pokemon.Add(entity);

            await _dbContext.SaveChangesAsync();

            var model = new PokemonModel
            {
                Id = entity.Id,
                Name = entity.Name
            };

            return model;
        }
    }
}