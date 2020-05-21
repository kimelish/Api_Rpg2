using Api_Rpg.Data;
using Api_Rpg.Dtos.Character;
using Api_Rpg.Dtos.Weapon;
using Api_Rpg.Models.User;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api_Rpg.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WeaponService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId
                && c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

                if (character == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Character not found.";
                    return response;
                }

                Weapon weapon = new Weapon
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    Character = character
                };

                await _context.Weapons.AddAsync(weapon);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}