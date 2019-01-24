using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Assert.AreEqual("Knife", titleCase.GetTitleCase("knife", ""));
        }

        [TestMethod]
        public void Test003_GivenTitleCase_GetTitleCaseReturnsInputWithFirstLetterLowerCaseDueToMinorWordsParameter()
        {
            TitleCase titleCase = new TitleCase();

            Assert.AreEqual("apple", titleCase.GetTitleCase("apple", "apple"));
        }

        //[TestMethod]
        //public void Test004_GivenTitleCase_GetTitleCaseReturnsLowerCaseFirstWordUpperCaseSecondWord()
        //{
        //    TitleCase titleCase = new TitleCase();

        //    Assert.AreEqual("apple Pie", titleCase.GetTitleCase("apple pie", "apple"));
        //}
    }
}
