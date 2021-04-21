
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryList.Models
{
    public class PlannedMeal
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public int? FK_id_Recipe { get; set; }
        [JsonIgnore]
        [ForeignKey("FK_id_Recipe")]
        public virtual Recipe Recipe { get; set; }

        public decimal NumberOfServings { get; set; }
    }
}