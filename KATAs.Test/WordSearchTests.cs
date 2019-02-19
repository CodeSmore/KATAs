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

            Assert.AreEqual("SEEK: (0,2),(1,2),(2,2),(3,2)", wordSearch.GetHorizontalWords(input));

            // -------------------------------------------------------------------------------

            input = wordSearch.GetInput("TestDocument002.txt");

            Assert.AreEqual("TEST: (2,2),(3,2),(4,2),(5,2)", wordSearch.GetHorizontalWords(input));
        }

        [TestMethod]
        public void Test003_HelperMethod001_GivenWordSearch_GetWordsInSearchReturnsAListOfStringsContainingEachWordInTheWordSearch()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument001.txt");

            List<string> expectedResult = new List<string>(new string[] { "SEEK", "TEST", "WORD" });
            List<string> actualResult = wordSearch.GetWordSearchKeywords(input);

            CollectionAssert.AreEqual(expectedResult, actualResult);

// ---------------------------------------------------------------------------------------------------------------

            input = wordSearch.GetInput("TestDocument002.txt");

            expectedResult = new List<string>(new string[] { "THIS", "WAS", "JUST", "THE", "TEST", "FILE" });
            actualResult = wordSearch.GetWordSearchKeywords(input);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test003_HelperMethod002_GivenWordSearch_GetLinesInSearchReturnsAListOfStringsEachContainingALineFromThePuzzle()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument001.txt");

            List<string> expectedResult = new List<string>(new string[] { "BVLTW", "XVSOO", "SEEKR", "TPWXD", "KTESD" });
            List<string> actualResult = wordSearch.GetRowsInWordSearch(input);

            CollectionAssert.AreEqual(expectedResult, actualResult);

            // ---------------------------------------------------------------------------------------------------------------

            input = wordSearch.GetInput("TestDocument002.txt");

            expectedResult = new List<string>(new string[] { "LTCTVLH", "DDSLSQK", "FUTESTO", "JITXYSC", "SHLYWIN", "EMLEAHJ", "QIRKSTI" });
            actualResult = wordSearch.GetRowsInWordSearch(input);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test004_GivenWordSearch_GetBackwardsHorizontalWordsReturnsWordAndLocationOfLetters()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument003_InverseOf001.txt");

            Assert.AreEqual("SEEK: (4,2),(3,2),(2,2),(1,2)", wordSearch.GetHorizontalWords(input));

            //----------------------------------------------------------------------------------------------

            input = wordSearch.GetInput("TestDocument004_InverseOf002.txt");

            Assert.AreEqual("TEST: (4,4),(3,4),(2,4),(1,4)", wordSearch.GetHorizontalWords(input));

            input = wordSearch.GetInput("TestDocument005.txt");

            Assert.AreEqual("TEST: (5,4),(4,4),(3,4),(2,4)", wordSearch.GetHorizontalWords(input));
        }

        [TestMethod]
        public void Test005_GivenWordSearch_GetDownwardsVerticalWordsReturnsWordAndLocationOfLetters()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument001.txt");

            Assert.AreEqual("WORD: (0,4),(1,4),(2,4),(3,4)", wordSearch.GetVerticalWords(input));
        }

        //[TestMethod]
        //public void Test005_HelperMethod001_GivenWordSearch_FillWordSearchArrayContainsTheCorrectValues()
        //{
        //    WordSearch wordSearch = new WordSearch();

        //    string input = wordSearch.GetInput("TestDocument001.txt");
        //    List<string> linesInSearch = wordSearch.GetRowsInWordSearch(input);

        //    string[,] expectedResult = new string[,] { { "B", "V", "L", "T", "W" }, { "X", "V", "S", "O", "O"}, { "S", "E", "E", "K", "R"}, { "T", "P", "W", "X", "D"}, { "K", "T", "E", "S", "D"} };
        //    string[,] actualResult = wordSearch.FillWordSearchArray(linesInSearch);

        //    CollectionAssert.AreEqual(expectedResult, actualResult);
        //}

        [TestMethod]
        public void Test006_GivenWordSearch_GetUpwardsVerticalWordsReturnsWordAndLocationOfLetters()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument002.txt");

            Assert.AreEqual("WAS: (4,4),(5,4),(6,4)\nTHIS: (6,5),(5,5),(4,5),(3,5)", wordSearch.GetVerticalWords(input));
        }
    }
}
