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

            Assert.AreEqual("apple", titleCase.GetTitleCase("apple", ""));
        }
    }
}
