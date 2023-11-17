using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokemon.Data;
using Pokemon.Models.Abilities;
using Pokemon.Data.Entities;

namespace Pokemon.Services.Abilities
{
    public class AbilitiesService : IAbilitiesService
    {
        private readonly ApplicationDbContext _dbContext;
        public AbilitiesService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<AbilitiesModel> CreateAbilityAsync(CreateAbility createModel)
        {
            var entity = new AbilityEntity
            {
                Name = createModel.Name
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

        public async Task<bool> DeleteAbilityAsync(int Id)
        {
            var Ability = await _dbContext.Abilities.FindAsync(Id);

            if (Ability != null)
            {
                _dbContext.Abilities.Remove(Ability);

                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}