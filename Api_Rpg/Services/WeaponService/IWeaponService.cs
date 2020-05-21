using Api_Rpg.Dtos.Character;
using Api_Rpg.Dtos.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Rpg.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}