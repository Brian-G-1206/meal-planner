using GroceryList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryListController : ControllerBase
    {
        private readonly ILogger<GroceryListController> _logger;
        private readonly IRecipeService _recipeService;

        public GroceryListController(ILogger<GroceryListController> logger, IRecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var meals = _recipeService.CreateMenu();
            var list = _recipeService.GetGroceryList(meals).Select(x => $"{x.Food.FoodName} - {x.Amount} {x.Measurement.MeasurementName}");

            var result = new List<string>();
            result.AddRange(meals.Select(x => $"{x.Recipe.Name} - {x.Recipe.Url}"));
            result.AddRange(list);

            return result;
        }
    }
}
