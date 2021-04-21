
using Microsoft.EntityFrameworkCore;
using GroceryList.Models;

namespace GroceryList.Contexts
{
    public interface IRecipeContext
    {
        DbSet<Food> Foods { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Recipe> Recipes { get; set; }
        DbSet<Measurement> Measurements { get; set; }
        DbSet<PlannedMeal> PlannedMeals { get; set; }
        int SaveChanges();
    }
}