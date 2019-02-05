﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Assert.AreEqual("SEEK,TEST,WORD B,V,L,T,W X,V,S,O,O S,E,E,K,R T,P,W,X,D K,T,E,S,D", wordSearch.GetInput("TestDocument001.txt"));
        }


        [TestMethod]
        public void Test002_GivenWordSearch_GetInputReturnsTheStringOfTextFromInputTextFileTestDocument002()
        {
            WordSearch wordSearch = new WordSearch();

            Assert.AreEqual("THIS,WAS,JUST,THE,TEST,FILE L,T,C,T,V,L,H D,D,S,L,S,Q,K F,U,T,E,S,T,O J,I,T,X,Y,S,C S,H,L,Y,W,I,N E,M,L,E,A,H,J Q,I,R,K,S,T,I"
                , wordSearch.GetInput("TestDocument002.txt"));
        }

        [TestMethod]
        public void Test003_GivenWordSearch_GetForwardHorizontalWordsReturnsWordAndLocationOfLetters()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument001.txt");

            Assert.AreEqual("SEEK: (0,2),(1,2),(2,2),(3,2)", wordSearch.GetForwardHorizontalWords(input));
        }

        [TestMethod]
        public void Test004_GivenWordSearch_GetWordsInSearchReturnsAListOfStringsContainingEachWordInTheWordSearch()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument001.txt");

            List<string> expectedResult = new List<string>(new string[] { "SEEK", "TEST", "WORD" });
            List<string> actualResult = wordSearch.GetWordsInSearch(input);

            CollectionAssert.AreEqual(expectedResult, actualResult);

// ---------------------------------------------------------------------------------------------------------------

            input = wordSearch.GetInput("TestDocument002.txt");

            expectedResult = new List<string>(new string[] { "THIS", "WAS", "JUST", "THE", "TEST", "FILE" });
            actualResult = wordSearch.GetWordsInSearch(input);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
