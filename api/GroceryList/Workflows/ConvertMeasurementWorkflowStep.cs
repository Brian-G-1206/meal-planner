using GroceryList.Models;
using GroceryList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Workflows
{
    public class ConvertMeasurementService
    {
        private Dictionary<Tuple<string, string>, decimal> ConversionFactorDictionary = new Dictionary<Tuple<string, string>, decimal>()
        {
            { new Tuple<string, string>("Tablespoon", "Cup"), 1m/16m },
            { new Tuple<string, string>("Tablespoon", "Teaspoon"), 3 },
            { new Tuple<string, string>("Teaspoon", "Tablespoon"), 1m/3m },
            { new Tuple<string, string>("Cup", "Tablespoon"), 16m },
           
        };
    
        public decimal Convert(string input, string output, decimal amount)
        {
            var standardInput = MeasurementService.ConversionLookup[input.ToLower()];
            var standardOutput = MeasurementService.ConversionLookup[output.ToLower()];
            var conversionFactor = ConversionFactorDictionary[new Tuple<string, string>(standardInput, standardOutput)];
            decimal result = amount * conversionFactor;
            return decimal.Round(result,2,System.MidpointRounding.AwayFromZero);
        }

        public decimal ConvertWithIntermediarySearch(string input, string output, decimal amount)
        {
            var standardInput = MeasurementService.ConversionLookup[input.ToLower()];
            var standardOutput = MeasurementService.ConversionLookup[output.ToLower()];
            decimal conversionFactor = 0m;

            try
            {
                conversionFactor = ConversionFactorDictionary[new Tuple<string, string>(standardInput, standardOutput)];
            }
            catch(KeyNotFoundException)
            {
                var startingConversions = ConversionFactorDictionary.Where(x => x.Key.Item1 == standardInput);
                var endingConversions = ConversionFactorDictionary.Where(x => x.Key.Item2 == standardOutput);
                foreach (var start in startingConversions)
                {
                    foreach (var end in endingConversions)
                    {
                        if(start.Key.Item2 == end.Key.Item1)
                        {
                            conversionFactor = start.Value * end.Value;
                        }
                    }
                }
            }
            if(conversionFactor == 0)
            {
                throw new ConversionFailedException();
            }
            decimal result = amount * conversionFactor;
            return decimal.Round(result, 2, System.MidpointRounding.AwayFromZero);
        }
        public List<int> MergeSort(List<int> unsortedList)
        {
            if (unsortedList.Count() > 1)
            {
                var mid = unsortedList.Count() / 2;
                var front = unsortedList.Take(mid).ToList();
                var back = unsortedList.Skip(mid).ToList();

                MergeSort(front);
                MergeSort(back);

                var frontIndex = 0;
                var backIndex = 0;
                var unsortedIndex = 0;

                while(frontIndex < front.Count() && backIndex < back.Count())
                {
                    if (front[frontIndex] > back[backIndex])
                    {
                        unsortedList[unsortedIndex] = back[backIndex];
                        backIndex++;
                    }
                    else
                    {
                        unsortedList[unsortedIndex] = front[frontIndex];
                        frontIndex++;
                    }

                    unsortedIndex++;
                }

                while(frontIndex < front.Count())
                {
                    unsortedList[unsortedIndex] = front[frontIndex];
                    unsortedIndex++;
                    frontIndex++;
                }

                while (backIndex < back.Count())
                {
                    unsortedList[unsortedIndex] = back[backIndex];
                    unsortedIndex++;
                    backIndex++;
                }
            }
            return unsortedList;
        }
    }

    public class ConversionFactor
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public decimal Amount { get; set; }

        public ConversionFactor(string input, string output, decimal amount)
        {
            Input = input;
            Output = output;
            Amount = amount;
        }

        public ConversionFactor(string input, string output)
        {
            Input = input;
            Output = output;
        }

        public override bool Equals(object obj)
        {
            var factor = obj as ConversionFactor;
            return factor != null &&
                   Input == factor.Input &&
                   Output == factor.Output;
        }

        public override int GetHashCode()
        {
            var hashCode = -1143322761;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Input);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Output);
            return hashCode;
        }
    }
}
