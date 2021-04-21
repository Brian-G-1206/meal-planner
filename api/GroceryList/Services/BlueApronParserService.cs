using GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GroceryList.Services
{
    public class BlueApronParserService
    {
        public Recipe ParseHtmlRecipe(string html, string url)
        {
            
           var titleRegex = new Regex("<title>Recipe: (.+?) - Blue Apron</title>");
            var title = titleRegex.Match(html);

            try
            {
                var ingredientRegex = new Regex("<li .+?itemprop=.recipeIngredient.>\r?\n<.+\r?\n<span>\r?\n(.+?)\r?\n(.+?)?\n</span>\r?\n(.+)\r?\n</.+?>\r?\n</li>");
                var servingRegex = new Regex("<span itemprop='recipeYield'>(\\d+)</span>");
                var servings = servingRegex.Match(html);

                var ingredientMatches = ingredientRegex.Matches(html);

                var ingredients = new List<Ingredient>();

                foreach (Match match in ingredientMatches)
                {
                    var amountValue = ParseMeasurement(match.Groups[1].Value);
                    var ing = new Ingredient()
                    {
                        Food = new Food()
                        {
                            FoodName = match.Groups[3].Value.Trim()
                        },
                        Amount = amountValue,
                        Measurement = new Measurement()
                        {
                            MeasurementName = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? "Each" : match.Groups[2].Value.Trim(),
                        }
                    };
                    
                     ingredients.Add(ing);                    
                }
                int servingsValue = -1;
                try
                {
                    servingsValue = int.Parse(servings.Groups[1].Value);
                }
                catch (Exception)
                {
                    
                }

                var recipe = new Recipe()
                {
                    Name = title.Groups[1].Value,
                    NumberOfServings = servingsValue,
                    Ingredients = ingredients,
                    Url = url,
                };

                return recipe;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error parsing recipe: {title}", ex);
            }
        }

        private decimal ParseMeasurement(string amountString)
        {
            var amountValue = 0m;

            if (amountString.Contains("to"))
            {
                var amounts = amountString.Split("to");
                amountValue = amounts.Select(x => x.Trim()).Select(x => ParseMeasurement(x)).OrderByDescending(x => x).First();
            }
            else if (!decimal.TryParse(amountString, out amountValue))
            {
                var amountRegex = new Regex("(\\d+?)([^\\d])");
                var fullAmountMatch = amountRegex.Match(amountString);
                var fullAmount = 0;
                var fractionalAmount = amountString;

                if (fullAmountMatch.Success)
                {
                    fullAmount = int.Parse(fullAmountMatch.Groups[1].Value);
                    fractionalAmount = fullAmountMatch.Groups[2].Value;
                }

                switch (fractionalAmount)
                {
                    case "¾":
                        amountValue = .75m;
                        break;
                    case "⅔":
                        amountValue = .6m;
                        break;
                    case "½":
                        amountValue = .5m;
                        break;
                    case "⅓":
                        amountValue = .3m;
                        break;
                    case "¼":
                        amountValue = .25m;
                        break;
                    case "⅛":
                        amountValue = .125m;
                        break;
                    default:

                        throw new Exception($"Unhandled Ingredient Amount: {amountString}");
                }

                amountValue += amountValue;
            }

            return amountValue;
        }
    }
}
