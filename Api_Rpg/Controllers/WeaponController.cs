using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Rpg.Dtos.Weapon;
using Api_Rpg.Services.WeaponService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Rpg.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpPost]
        public async Task<IActionResult> AddWeapon(AddWeaponDto newWeapon)
        {
            return Ok(await _weaponService.AddWeapon(newWeapon));
        }
    }
}