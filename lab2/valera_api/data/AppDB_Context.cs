using Microsoft.EntityFrameworkCore;
using ValeraAPI.models;

namespace ValeraAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Valera> ValeraS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Valera>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Health).IsRequired();
                entity.Property(v => v.Mana).IsRequired();
                entity.Property(v => v.Cheerfulness).IsRequired();
                entity.Property(v => v.Fatigue).IsRequired();
                entity.Property(v => v.Money).IsRequired();
            });
        }
    }
}