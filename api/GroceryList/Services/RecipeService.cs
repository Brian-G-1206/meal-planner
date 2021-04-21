using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using GroceryList.Contexts;
using GroceryList.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Services
{
    public interface IRecipeService
    {
        List<PlannedMeal> CreateMenu();
        List<Ingredient> GetGroceryList(List<PlannedMeal> meals);
        void ParseRecipesTemp();
        void CreateRecipe(Recipe recipe);

        
    }
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeContext db;

        public RecipeService(IRecipeContext recipeContext)
        {
            db = recipeContext;
        }

        public List<PlannedMeal> CreateMenu()
        {
            var meals = new List<PlannedMeal>();
            var recipes = db.Recipes.ToList();

            var rdm = new Random();

            while(meals.Count() < 7)
            {
                var recipe = recipes[rdm.Next(recipes.Count())];


                var meal = new PlannedMeal()
                {
                    Recipe = recipe,
                    FK_id_Recipe = recipe.Id,
                    NumberOfServings = 5
                };
                meals.Add(meal);
            }
            return meals;
        }

        public List<Ingredient> GetGroceryList(List<PlannedMeal> meals)
        {
            var groceryList = new List<Ingredient>();
            foreach (var meal in meals)
            {
                var ingredients = db
                    .Ingredients
                    .Where(x => x.FK_id_Recipe == meal.FK_id_Recipe)
                    .Include(x => x.Food)
                    .Include(x => x.Measurement)
                    ;
                foreach (var ingredient in ingredients)
                {
                    var existingIngredient = groceryList
                        .SingleOrDefault(x => x.Food.FoodName == ingredient.Food.FoodName &&
                                x.Measurement.MeasurementName.Equals(ingredient.Measurement.MeasurementName));

                    var amountToAdd = ingredient.Amount / meal.Recipe.NumberOfServings * meal.NumberOfServings;

                    if(existingIngredient != null)
                    {
                        existingIngredient.Amount += decimal.Round(amountToAdd, 2, System.MidpointRounding.AwayFromZero);
                    } 
                    else
                    {
                        ingredient.Amount = decimal.Round(amountToAdd, 2, System.MidpointRounding.AwayFromZero);
                        groceryList.Add(ingredient);
                    }
                }
            }

            return groceryList;
        }

        public void ParseRecipesTemp()
        {
            var filepath = "C:\\workspace\\recipesJson\\web\\recipeUrls.dat";

            StreamReader rdr = new StreamReader(filepath);
            var urls = new List<string>();
            using (rdr)
            {
                string line;
                while ((line = rdr.ReadLine()) != null)
                {
                    urls.Add(line);
                }
            }

            for (int i = 0; i < urls.Count; i++)
            {
                var client = new HttpClient();
                var url = urls[i];


                // Get the response.
                HttpResponseMessage response = client.GetAsync(url).Result;

                // Get the response content.
                HttpContent responseContent = response.Content;

                // Get the stream of the content.
                using (var reader = new StreamReader(responseContent.ReadAsStreamAsync().Result))
                {
                    // Write the output.
                    var html = reader.ReadToEnd();
                    var recipe = new BlueApronParserService().ParseHtmlRecipe(html, url);
                    CreateRecipe(recipe);
                }
            }
        }

        public void CreateRecipe(Recipe recipe)
        {
            //var pService = PluralizationService.CreateService(new System.Globalization.CultureInfo("en-us"));

            var exists = db.Recipes.Where(x => x.Name == recipe.Name).FirstOrDefault();

            Recipe recipeToUse;

            if(exists != null)
            {
                exists.Name = recipe.Name;
                exists.Url = recipe.Url;
                exists.NumberOfServings = recipe.NumberOfServings;
                recipeToUse = exists;
            }
            else
            {
                recipeToUse = db.Recipes.Add(new Recipe() { Name = recipe.Name, NumberOfServings = recipe.NumberOfServings, Url = recipe.Url }).Entity;
            }
            
            db.SaveChanges();

            foreach (Ingredient ing in recipe.Ingredients)
            {
                var food = db.Foods.SingleOrDefault(x => x.FoodName == ing.Food.FoodName);
                if (food != null)
                {
                    ing.Food = food;
                }

                //ingredient.Measurement.MeasurementName = pService.Singularize(ingredient.Measurement.MeasurementName);
                var measurement = db.Measurements
                    .SingleOrDefault(x => x.MeasurementName == ing.Measurement.MeasurementName);
                if (measurement != null)
                {
                    ing.Measurement = measurement;
                }
                ing.FK_id_Recipe = recipeToUse.Id;

                var ingExists = db.Ingredients.FirstOrDefault(x => x.Food.FoodName == ing.Food.FoodName && x.FK_id_Recipe == ing.FK_id_Recipe);

                if (ingExists != null && ing.Measurement != ingExists.Measurement)
                {
                    ingExists.Measurement = ing.Measurement;
                }
                else if (ingExists == null)
                {
                    db.Ingredients.Add(ing);
                }

                db.SaveChanges();
            }
        }
    }
}
