using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokemon.Models.Abilities;

namespace Pokemon.Services.Abilities
{
    public interface IAbilitiesService
    {
        Task<AbilitiesModel> CreateAbilityAsync(CreateAbility createModel);
        Task<bool> DeleteAbilityAsync(int Id);
    }
}