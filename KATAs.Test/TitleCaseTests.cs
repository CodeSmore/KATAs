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

            Assert.AreEqual("Apple", titleCase.GetTitleCase("Apple"));
        }

        [TestMethod]
        public void Test002_GivenTitleCase_GetTitleCaseReturnsInputWithFirstLetterCapitalized()
        {
            TitleCase titleCase = new TitleCase();

            Assert.AreEqual("Apple", titleCase.GetTitleCase("apple"));

            // The issue wasn't that I needed to add this second assert, but that I skipped the 'refactor' step of 'Red, Green, Refactor' 
            // to eliminate the magic character
            Assert.AreEqual("Knife", titleCase.GetTitleCase("knife"));
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

            List<string> expectedResultList = new List<string>();
            expectedResultList.Add("this");
            expectedResultList.Add("is");
            expectedResultList.Add("easy");

            CollectionAssert.AreEqual(expectedResultList, titleCase.GetWordsFromString("this is easy"));
        }

        [TestMethod]
        public void Test005_GivenTitleCase_GetTitleCaseReturnsInputWithFirstLettersOfTwoWordsCapitalized()
        {
            TitleCase titleCase = new TitleCase();

            Assert.AreEqual("Apple Pie", titleCase.GetTitleCase("apple pie"));
        }

        [TestMethod]
        public void Test006_GivenTitleCase_GetTitleCaseReturnsInputWithFirstAndFourthWordsTitleCasedSecondAndThirdWordsLowerCase()
        {
            TitleCase titleCase = new TitleCase();

            Assert.AreEqual("Gone with the Wind", titleCase.GetTitleCase("gone with the wind", "the with"));
        }

        [TestMethod]
        public void Test007_GivenTitleCase_GetTitleCaseReturnsWithFirstWordCapitalizedEvenThoughItIsPresentInMinorWords()
        {
            TitleCase titleCase = new TitleCase();

            Assert.AreEqual("A Clash of Jesters", titleCase.GetTitleCase("a clash of jesters", "of a"));
        }

        [TestMethod]
        public void Test008_GivenTitleCase_GetTitleCaseMakesLowerCaseAllLettersAfterTheFirstInEachWord()
        {
            TitleCase titleCase = new TitleCase();

            Assert.AreEqual("Wind in the Hills", titleCase.GetTitleCase("WIND IN THE HILLS", "The In"));
        }

        
        [TestMethod]
        public void Test009_GivenTitleCase_GetTitleCaseWorksEvenIfFirstLetterOfWordIsUsedLaterInWord()
        {
            TitleCase titleCase = new TitleCase();

            Assert.AreEqual("Wind in the Willows", titleCase.GetTitleCase("wind in the willows", "the in"));
        }

        /*
        [TestMethod]
        public void Test010_GivenTitleCase_GetTitleCaseWorksEvenIfALaterWordIsTheSameAsTheFirstWord()
        {
            TitleCase titleCase = new TitleCase();

            Assert.AreEqual("The Wind in the Willows", titleCase.GetTitleCase("the wind in the willows", "the in"));
        }
         */
    }
}
