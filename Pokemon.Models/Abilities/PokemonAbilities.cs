using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Models.AbilitiesModels
{
    public class PokemonAbilities
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public int AbilitiesId { get; set; }
    }
}