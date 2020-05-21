using Api_Rpg.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Api_Rpg.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkill>().HasKey(cs => new { cs.CharacterId, cs.SkillId });
        }
    }
}