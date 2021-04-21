using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryList.Models
{
    public class Ingredient
    {
        [Key]
        [JsonIgnore]
        public int IngredientId { get; set;  }
        [JsonIgnore]
        public int? FK_id_Food { get; set; }
        [ForeignKey("FK_id_Food")]
        public Food Food { get; set; }
        [JsonIgnore]
        public int? FK_id_Measurement { get; set; }
        [ForeignKey("FK_id_Measurement")]
        public Measurement Measurement { get; set; }
        public decimal Amount { get; set; }
        [JsonIgnore]
        public int? FK_id_Recipe { get; set; }
        [JsonIgnore]
        [ForeignKey("FK_id_Recipe")]
        public Recipe Recipe { get; set; }
    }
}