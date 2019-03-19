using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace KATAs.Test
{
    [TestClass]
    public class HelpTheBooksellerTests
    {
        [TestMethod]
        public void Test001_GivenHelpTheBookseller_WhenTheStockQuantitiesAreZero_ThenTheSummaryReturnsAllCategoriesAsEmpty()
        {
            string[] stockList = new string[] { "ABART 0", "CDXEF 0", "BKWRK 0"};
            string[] categoryList = new string[] { "A", "B", "C" };

            string expectedResult = "(A : 0) - (B : 0) - (C : 0)";
            string actualResult = HelpTheBookseller.GetStockSummary(stockList, categoryList);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test002_GivenHelpTheBookseller_WhenTheStockIsFilled_ThenTheSummaryReturnsAllCategoriesWithCorrectAmounts()
        {
            string[] stockList = new string[] { "ABART 10", "CDXEF 5", "BKWRK 10", "BCTK 2" };
            string[] categoryList = new string[] { "A", "B", "C" };

            string expectedResult = "(A : 10) - (B : 12) - (C : 5)";
            string actualResult = HelpTheBookseller.GetStockSummary(stockList, categoryList);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test003_GivenHelpTheBookseller_WhenStockListIsAnEmptyArray_ThenTheSummaryReturnsEmptyString()
        {
            string[] stockList = new string[] { };
            string[] categoryList = new string[] { "A", "B", "C" };

            string expectedResult = "";
            string actualResult = HelpTheBookseller.GetStockSummary(stockList, categoryList);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test004_GivenHelpTheBookseller_WhenCategoryListIsAnEmptyArray_ThenTheSummaryReturnsEmptyString()
        {
            string[] stockList = new string[] { "ABART 10", "CDXEF 5", "BKWRK 10", "BCTK 2" };
            string[] categoryList = new string[] { };

            string expectedResult = "";
            string actualResult = HelpTheBookseller.GetStockSummary(stockList, categoryList);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestHelperMethod001_GivenHelpTheBookseller_WhenAddCategoriesToStockSummaryDictionaryIsCalled_ReturnDicionaryCategoriesAsKeysAndZeroForEachValue()
        {
            string[] categoryList = new string[] { "A", "B", "W" };

            Dictionary<char, int> expectedResult = new Dictionary<char, int> { { 'A', 0 }, { 'B', 0 }, { 'W', 0 } };
            Dictionary<char, int> actualResult = HelpTheBookseller.AddCategoriesToStockSummaryDictionary(categoryList);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestHelperMethod002_GivenHelpTheBookseller_WhenAddStockValuesToStockSummaryDictionaryIsCalled_ReturnDicionaryCategoriesAsKeysAndIntsForEachValue()
        {
            Dictionary<char, int> stockSummaryDict = new Dictionary<char, int> { { 'A', 0 }, { 'B', 0 }, { 'W', 0 } };
            string[] stockList = { "ABART 10", "BKWRK 30", "WDXEF 20"};

            Dictionary<char, int> actualResult = HelpTheBookseller.AddStockValuesToStockSummaryDictionary(stockSummaryDict, stockList);
            Dictionary<char, int> expectedResult = new Dictionary<char, int>() { { 'A', 10 }, { 'B', 30 }, { 'W', 20 } };

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
