using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokemon.Data;
using Pokemon.Models.Abilities;

namespace Pokemon.Services.Abilities
{
    public class AbilitiesService : IAbilitiesService
    {
        private readonly ApplicationDbContext _dbContext;
        public AbilitiesService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<AbilitiesModel> CreateAbilityAsync(CreateAbility abilityModel)
        {
            var entity = new AbilityEntity
            {
                Name = abilityModel.Name
            };

            _dbContext.Abilities.Add(entity);

            await _dbContext.SaveChangesAsync();

            var model = new AbilityModel
            {
                Id = entity.Id,
                Name = entity.Name
            };

            return model;
        }
    }
}