using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Menu.Entities.Entity;

namespace Menu.Data
{
    public class MenuContext : IdentityDbContext
    {
        public DbSet<Meal> meals { get; set; }
        public DbSet<Ingredient> ingredients { get; set; }

        public MenuContext(DbContextOptions<MenuContext> ctx) : base(ctx)
        {  
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
               .HasMany(r => r.Ingredients)
               .WithMany(m => m.Meals)
               .UsingEntity<IngredientsAmount>(x => x.HasOne(x => x.ingredient).WithMany().HasForeignKey(x => x.IngredientID).OnDelete(DeleteBehavior.Cascade),
               x => x.HasOne(x => x.meal).WithMany().HasForeignKey(x => x.MealID).OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<IngredientsAmount>()
               .HasOne(x => x.meal)
               .WithMany(x => x.IngredientsAmounts)
               .HasForeignKey(x => x.MealID)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IngredientsAmount>()
               .HasOne(x => x.ingredient)
               .WithMany(x => x.IngredientsAmounts)
               .HasForeignKey(x => x.IngredientID)
               .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
