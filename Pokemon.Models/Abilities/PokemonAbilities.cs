using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pokemon.Models.AbilitiesModel
{
    public class PokemonAbilities
    {
        public int Id { get; set; }

        [ForeignKey]
        public int PokemonId { get; set; }

        [ForeignKey]
        public int AbilitiesId { get; set; }
    }
}