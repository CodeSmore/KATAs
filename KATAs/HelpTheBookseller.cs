using System;
using System.Collections.Generic;
using System.Text;

namespace KATAs
{
    public class HelpTheBookseller
    {
        public static string GetStockSummary(string[] stockList, string[] categoryList)
        {
            Dictionary<char, int> stockSummaryDict = AddCategoriesToStockSummaryDictionary(categoryList);
            stockSummaryDict = AddStockValuesToStockSummaryDictionary(stockSummaryDict, stockList);

            string result = FormatStockSummary(stockSummaryDict);

            return result;
        }

        public static string FormatStockSummary(Dictionary<char, int> stockSummaryDict)
        {
            string resultString = "";

            foreach (KeyValuePair<char, int> kvp in stockSummaryDict)
            {
                if (resultString != "")
                {
                    resultString += " - ";
                }

                resultString += "(" + kvp.Key + " : " + kvp.Value + ")";
            }

            return resultString;
        }

        public static Dictionary<char, int> AddStockValuesToStockSummaryDictionary
            (Dictionary<char, int> stockSummaryDict, string[] stockList)
        {
            foreach (string stockItem in stockList)
            {
                char category = GetCategory(stockItem);
                int quantity = ParseStockQuantity(stockItem);

                if (stockSummaryDict.ContainsKey(category))
                {
                    stockSummaryDict[category] += quantity;
                }
            }

            return stockSummaryDict;
        }

        static char GetCategory(string stockItem)
        {
            return stockItem[0];
        }

        static int ParseStockQuantity(string stockItem)
        {
            int quantity = 0;

            for (int i = 0; i < stockItem.Length; ++i)
            {
                if (stockItem[i] == ' ')
                {
                    Int32.TryParse(stockItem.Substring(i + 1), out quantity);
                }
            }

            return quantity;
        }

        public static Dictionary<char, int> AddCategoriesToStockSummaryDictionary(string[] categoryList)
        {
            Dictionary<char, int> resultDict = new Dictionary<char, int>();

            foreach (string category in categoryList)
            {
                resultDict.Add(category.ToCharArray()[0], 0);
            }

            return resultDict;
        }
    }
}
