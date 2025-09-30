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

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                 .HasMany(r => r.ingredients)
                 .WithMany(m => m.meals)
                 .UsingEntity<IngredientQuantity>(x => x.HasOne(x => x.ingredient).WithMany().HasForeignKey(x => x.IngredientID).OnDelete(DeleteBehavior.Cascade),
                 x => x.HasOne(x => x.recipe).WithMany().HasForeignKey(x => x.RecipeID).OnDelete(DeleteBehavior.Cascade));

            base.OnModelCreating(modelBuilder);
        }
    }
}
