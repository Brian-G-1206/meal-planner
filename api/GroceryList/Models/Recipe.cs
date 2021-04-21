using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GroceryList.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set;}
        public List<Ingredient> Ingredients { get; set; }

        public decimal NumberOfServings { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return
$@"{Name}
{this.Ingredients.Select(x => $"{x.Food.FoodName} - {x.Amount} {x.Measurement.MeasurementName}\n")}
";
        }

    }

    public static class RecipeExtensions
    {
        public static void AddIngredient(this Recipe recipe, string ingredientName, decimal amount, string measurement)
        {
            var ingredient = new Ingredient()
            {
                Food = new Food() { FoodName = ingredientName },
                Amount = amount,
                Measurement = new Measurement() { MeasurementName = measurement }
            };

            if (recipe.Ingredients == null)
            {
                recipe.Ingredients = new List<Ingredient>();
            }

            recipe.Ingredients.Add(ingredient);
        }
    }


}