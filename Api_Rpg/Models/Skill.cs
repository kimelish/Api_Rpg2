using System.Collections.Generic;

namespace Api_Rpg.Models.User
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public IList<CharacterSkill> CharacterSkills { get; set; }
    }
}