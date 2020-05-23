using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Rpg.Dtos.Fight;
using Api_Rpg.Services.FightService;
using Microsoft.AspNetCore.Mvc;

namespace Api_Rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }

        [HttpPost("Weapon")]
        public async Task<IActionResult> WeaponAttack(WeaponAttackDto request)
        {
            return Ok(await _fightService.WeaponAttack(request));
        }

        [HttpPost("Skill")]
        public async Task<IActionResult> SkillAttack(SkillAttackDto request)
        {
            return Ok(await _fightService.SkillAttack(request));
        }

        [HttpPost]
        public async Task<IActionResult> Fight(FightRequestDto request)
        {
            return Ok(await _fightService.Fight(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetHighscore()
        {
            return Ok(await _fightService.GetHighScore());
        }
    }
}