
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryList.Models
{
    public class Food
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [StringLength(450)]
        public string FoodName { get; set; }

        public Food(string foodName)
        {
            FoodName = foodName;
        }

        public Food()
        {

        }
    }
}