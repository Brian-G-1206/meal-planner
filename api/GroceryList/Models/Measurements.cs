using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Design.PluralizationServices;

namespace GroceryList.Models
{
    public class Measurement
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string MeasurementName { get; set; }

        //public override bool Equals(object obj)
        //{
        //    var service = PluralizationService.CreateService(new System.Globalization.CultureInfo("en-US"));
        //    var measurement = obj as Measurement;
        //    if (measurement == null)
        //        return false;

        //    return measurement != null &&
        //           service.Singularize(MeasurementName) == service.Singularize(measurement.MeasurementName);
        //}

        //public override int GetHashCode()
        //{
        //    var hashCode = -675657432;
        //    hashCode = hashCode * -1521134295 + Id.GetHashCode();
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MeasurementName);
        //    return hashCode;
        //}
    }
}