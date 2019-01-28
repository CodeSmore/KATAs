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


        [TestMethod]
        public void Test002_GivenWordSearch_GetInputReturnsTheStringOfTextFromInputTextFileTestDocument002()
        {
            WordSearch wordSearch = new WordSearch();

            Assert.AreEqual("THIS,WAS,JUST,THE,TEST,FILE L,T,C,T,V,L,H D,D,S,L,S,Q,K F,U,T,E,S,T,O J,I,T,X,Y,S,C S,H,L,Y,W,I,N E,M,L,E,A,H,J Q,I,R,K,S,T,I"
                , wordSearch.GetInput("TestDocument002"));
        }
    }
}
