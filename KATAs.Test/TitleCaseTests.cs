using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KATAs.Test
{
    [TestClass]
    public class TitleCaseTests
    {
        [TestMethod]
        public void Test001_GivenTitleCase_GetTitleCaseReturnsInputString()
        {
            TitleCase titleCase = new TitleCase();

            Assert.AreEqual("Apple", titleCase.GetTitleCase("Apple", ""));
        }

        [TestMethod]
        public void Test002_GivenTitleCase_GetTitleCaseReturnsInputWithFirstLetterCapitalized()
        {
            TitleCase titleCase = new TitleCase();

            Assert.AreEqual("Apple", titleCase.GetTitleCase("apple", ""));

            // The issue wasn't that I needed to add this second assert, but that I skipped the 'refactor' step of 'Red, Green, Refactor' 
            // to eliminate the magic character
            Assert.AreEqual("Knife", titleCase.GetTitleCase("knife", ""));
        }

        [TestMethod]
        public void Test003_GivenTitleCase_GetTitleCaseReturnsInputWithFirstLetterLowerCaseDueToMinorWordsParameter()
        {
            TitleCase titleCase = new TitleCase();

            Assert.AreEqual("apple", titleCase.GetTitleCase("apple", "apple"));
        }

        [TestMethod]
        public void Test004_GivenTitleCase_GetWordsFromStringMethodReturnsListOfCorrectStrings()
        {
            TitleCase titleCase = new TitleCase();

            List<string> resultList = new List<string>();
            resultList.Add("this");
            resultList.Add("is");
            resultList.Add("easy");

            Assert.AreEqual(resultList, titleCase.GetWordsFromString("this is easy"));
        }
    }
}
