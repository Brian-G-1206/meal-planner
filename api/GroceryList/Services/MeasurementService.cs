using GroceryList.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity.Design.PluralizationServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Services
{
    public interface IMeasurementService
    {
        string FormatMeasurement(Measurement measurement);
        string FormatMeasurement(string measurementName);
    }

    public class MeasurementService: IMeasurementService
    {
        public static Dictionary<string, string> ConversionLookup = new Dictionary<string, string>()
        {
            {"tbsp", "Tablespoon" },
            {"tablespoon", "Tablespoon" },
            {"tsp", "Teaspoon"},
            {"teaspoon", "Teaspoon"},
            {"oz", "Ounce"},
            {"ounce", "Ounce" },
            {"cup", "Cup" },
            {"g", "Gram" },
            {"gram", "Gram" },
        };

        public string FormatMeasurement(Measurement measurement)
        {
            return FormatMeasurement(measurement.MeasurementName);
        }

        public string FormatMeasurement(string measurementName)
        {
            //var pService = PluralizationService.CreateService(new System.Globalization.CultureInfo("en-us"));
            var logger = NLog.LogManager.GetCurrentClassLogger();

            //measurementName = pService.Singularize(measurementName);

            string formattedName = measurementName;
            try
            {
                formattedName = ConversionLookup[measurementName];
            }
            catch
            {
                logger.Error($"Failed to find {measurementName} in ConversionLookup.");
            }
            return formattedName;
        }
    }
}
