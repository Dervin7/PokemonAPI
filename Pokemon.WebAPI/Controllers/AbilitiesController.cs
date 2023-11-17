using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokemon.Data;
using Pokemon.Services.Abilities;
using Pokemon.Models.Abilities;

namespace Pokemon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        private readonly IAbilitiesService _aService;
        public AbilitiesController(IAbilitiesService aService)
        {
            _aService = aService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbility([FromBody] CreateAbility request)
        {
            var newAbility = await _aService.CreateAbilityAsync(request);
            if (newAbility == null)
            {
                return BadRequest();
            }

            return Ok(newAbility);
        }

        [HttpDelete("{AbilityId:int}")]
        public async Task<IActionResult> DeleteAbility([FromRoute] int AbilityId)
        {
            return await _aService.DeleteAbilityAsync(AbilityId);
            if (AbilityId == null)
            {
                return BadRequest();
            }

            return Ok(AbilityId);
        }
    }
}