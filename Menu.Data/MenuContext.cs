using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Menu.Entities.Entity;

namespace Menu.Data
{
    public class MenuContext : IdentityDbContext
    {
        public DbSet<Meal> Meals { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public MenuContext(DbContextOptions<MenuContext> ctx) : base(ctx)
        {  

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .HasMany(m => m.Ingredients)
                .WithMany(r => r.Meals)
                .HasForeignKeys(r => r.Id)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
