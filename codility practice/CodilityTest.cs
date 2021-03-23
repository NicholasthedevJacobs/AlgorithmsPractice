using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codility_practice
{
    class CodilityTest
    {
        public string[] solution(string[] A, int[] B, int[] C)
        {
            string[] typeAndModel = { "L01", "L02", "D01"};
            int[] price = { 900, 900, 850 };
            int[] typeScreen = { 13, 15, 1 };

            Dictionary<int, string> modelAndKey = new Dictionary<int, string>();
            for (int i = 0; i < price.Length; i++)
            {
                modelAndKey.Add(i, typeAndModel[i]);
            }
          
            Dictionary<int, int> priceAndKey = new Dictionary<int, int>();
            for(int i = 0; i < price.Length; i++)
            {
                priceAndKey.Add(i, price[i]);
            }

            //This orders by price while keeping track of typeAndModel
            var ordered = priceAndKey.OrderBy(p => p.Value);

            //This is converting from type Key/Value to dictionary
            Dictionary<int, int> orderedPriceDictionary = new Dictionary<int, int>();
            foreach (var item in ordered)
            {
                orderedPriceDictionary.Add(item.Key, item.Value);
            }

            Dictionary<int, int> typeAndKey = new Dictionary<int, int>();
            for (int i = 0; i < price.Length; i++)
            {
                typeAndKey.Add(i, typeScreen[i]);
            }
            var orderTypeandKey = typeAndKey.OrderBy(p => p.Value);
            Dictionary<int, int> orderedTypeDictionary = new Dictionary<int, int>();
            foreach (var item in orderTypeandKey)
            {
                orderedTypeDictionary.Add(item.Key, item.Value);
            }

            var counter3 = 0;
            Dictionary<int, Dictionary<int, int>> pairTypePrice = new Dictionary<int, Dictionary<int, int>>();
            foreach (var key in orderedTypeDictionary)
            {
                if (orderedTypeDictionary.ContainsKey(counter3))
                {
                    pairTypePrice.Add(counter3, new Dictionary<int, int>());

                    if (pairTypePrice.ContainsKey(counter3))
                    {
                        pairTypePrice[counter3].Add(key.Key, orderedPriceDictionary[key.Key]);
                    }
                }
                counter3++;

            }
            




            //This piece is pairing model name with screentype/desktop type and price in the correct order highest to lowest.
            var counter = 0;
            Dictionary<string, Dictionary<int, int>> pairModelPriceTypeScreen = new Dictionary<string, Dictionary<int, int>>();
            foreach(var order in pairTypePrice)
            {
                if (orderedPriceDictionary.ContainsKey(counter))
                {

                    pairModelPriceTypeScreen.Add(typeAndModel[order.Key], new Dictionary<int, int>());

                    if (pairModelPriceTypeScreen.ContainsKey(typeAndModel[order.Key]))
                    {
                        
                        pairModelPriceTypeScreen[typeAndModel[order.Key]].Add(order.Key, order.Key);
                    }
                }
                counter++;
            }

            //this is comparing duplicate prices
            //var duplicates = orderedDictionary.SelectMany(d => d.Value).GroupBy(k => k).Where(x => x.Count() > 1);

            string[] solution = new string[typeAndModel.Length];
            //int[] priceArray = new int[typeAndModel.Length];
            //int[] typeArray = new int[typeAndModel.Length];
            var counter2 = 0;
            foreach (var pairModelPrice in pairModelPriceTypeScreen)
            {
                solution[counter2] = pairModelPrice.Key;
                //priceArray[counter2] = pairModelPriceTypeScreen[pairModelPrice.Key];
                //typeArray[counter2] = pairModelPrice.Value[2];
                counter2++;
            }
            
           
            

            return solution;
        }
    }
}
