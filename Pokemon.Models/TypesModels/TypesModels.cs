using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Models.TypesModels
{
    public class TypesModels
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        

    }

}