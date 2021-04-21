using Microsoft.EntityFrameworkCore;
using GroceryList.Models;

namespace GroceryList.Contexts
{
    public class RecipeContext : DbContext, IRecipeContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base (options)
        {
        }

        public DbSet<Food> Foods { get; set;}
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<PlannedMeal> PlannedMeals { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
    }
}