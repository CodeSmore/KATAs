using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace KATAs.Test
{
    [TestClass]
    public class WordSearchTests
    {
        [TestMethod]
        public void Test001_GivenWordSearch_GetInputReturnsTheStringOfTextFromInputTextFile()
        {
            WordSearch wordSearch = new WordSearch();

            Assert.AreEqual("SEEK,TEST,WORD B,V,L,T,W X,V,S,O,O S,E,E,K,R T,P,W,X,D K,T,E,S,D", wordSearch.GetInput("TestDocument001"));
        }
    }
}
