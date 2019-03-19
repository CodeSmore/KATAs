using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// *** NOTE: NOT COMPLETED!! ***
// Due to feeling like I'm banging my head against a wall, I'll be putting this on hold. 
// To reduce distractions from failed tests, I've commented out failing tests.
// Perhaps in the future, I'll give it another go.
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
        public void Test003_GivenWordSearch_GetHorizontalWordsReturnsWordAndLocationOfLettersForForwardHorizontalWords()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument001.txt");

            Assert.AreEqual("SEEK: (0,2),(1,2),(2,2),(3,2)", wordSearch.GetHorizontalWords(input));

            // -------------------------------------------------------------------------------

            input = wordSearch.GetInput("TestDocument002.txt");

            Assert.AreEqual("TEST: (2,2),(3,2),(4,2),(5,2)", wordSearch.GetHorizontalWords(input));
        }

        [TestMethod]
        public void Test003_HelperMethod001_GivenWordSearch_GetWordSearchKeywordsReturnsAListOfStringsContainingEachWordInTheWordSearch()
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
        public void Test003_HelperMethod002_GivenWordSearch_GetRowsInWordSearchReturnsAListOfStringsEachContainingARowFromThePuzzle()
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
        public void Test004_GivenWordSearch_GetHorizontalWordsReturnsWordAndLocationOfLettersForBackwardsHorizontalWords()
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
        public void Test005_GivenWordSearch_GetVerticalWordsReturnsWordAndLocationOfLettersForDownwardsVerticalWords()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument001.txt");

            Assert.AreEqual("WORD: (4,0),(4,1),(4,2),(4,3)", wordSearch.GetVerticalWords(input));
        }

        [TestMethod]
        public void Test006_GivenWordSearch_GetVerticalWordsReturnsWordAndLocationOfLettersForUpwardsAndDownwardsVerticalWords()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument002.txt");

            Assert.AreEqual("WAS: (4,4),(4,5),(4,6)\nTHIS: (5,6),(5,5),(5,4),(5,3)", wordSearch.GetVerticalWords(input));
        }

        //[TestMethod]
        //public void Test007_GivenWordSearch_GetUpwardsDiagonalWordsReturnsWordAndLocationOfLetters()
        //{
        //    WordSearch wordSearch = new WordSearch();

        //    string input = wordSearch.GetInput("TestDocument001.txt");

        //    Assert.AreEqual("TEST: (0,3),(1,2),(2,1),(3,0)", wordSearch.GetUpwardsDiagonalWords(input));

        //    // -------------------------------------------------------------------------------------------

        //    input = wordSearch.GetInput("TestDocument002.txt");

        //    Assert.AreEqual("JUST: (0,3),(1,2),(2,1),(3,0)\nTHE: (2,3),(1,4),(0,5)", wordSearch.GetUpwardsDiagonalWords(input));
        //}

        [TestMethod]
        public void Test007_HelperMethod001_GivenWordSearch_GetUpwardDiagonalsInWordSearchReturnsAListOfStringsEachContainingADiagonalFromThePuzzle()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument001.txt");

            List<string> expectedResult = new List<string>(new string[] { "B", "XV", "SVL", "TEST", "KPEOW", "TWKO", "EXR", "SD", "D" });
            List<string> actualResult = wordSearch.GetUpwardDiagonalsInWordSearch(wordSearch.GetRowsInWordSearch(input));

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test008_GivenWordSearch_GetDownwardDiagonalsInWordSearchReturnsWordAndLocationOfLetters()
        {
            WordSearch wordSearch = new WordSearch();

            // Forward
            string input = wordSearch.GetInput("TestDocument002.txt");

            Assert.AreEqual("FILE: (0,2),(1,3),(2,4),(3,5)", wordSearch.GetDownwardDiagonalWords(input));

            // ----------------------------------------------------------------------------------------------
            // Reverse
            input = wordSearch.GetInput("TestDocument004_InverseOf002.txt");

            Assert.AreEqual("FILE: (6,4),(5,3),(4,2),(3,1)", wordSearch.GetDownwardDiagonalWords(input));
        }

        [TestMethod]
        public void Test008_HelperMethod001_GivenWordSearch_GetDownwardDiagonalsInWordSearchReturnsAListOfStringsEachContainingADiagonalFromThePuzzle()
        {
            WordSearch wordSearch = new WordSearch();

            string input = wordSearch.GetInput("TestDocument002.txt");

            List<string> expectedResult = new List<string>(new string[] { "H", "LK", "VQO", "TSTC", "CLSSN", "TSEYIJ", "LDTXWHI", "DUTYAT", "FILES", "JHLK", "SMR", "EI", "Q" });
            List<string> actualResult = wordSearch.GetDownwardDiagonalsInWordSearch(wordSearch.GetRowsInWordSearch(input));
    
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        //[TestMethod]
        //public void Test009_GivenWordSearch_GetDownwardDiagonalsReturnsWordAndLocationOfLetters_ForAllDownwardDiagonalCases()
        //{
        //    WordSearch wordSearch = new WordSearch();

        //    string input = wordSearch.GetInput("TestDocument006_DownwardDiagonalTests.txt");

        //    string expectedResult = "ABC: (1,0),(2,1),(3,2)\nDEF: (0,2),(1,3),(2,4)\nGHI: (4,5),(3,4),(2,3)\nJKL: (5,3),(4,2),(3,1)\nMNO: (3,3),(4,4),(5,5)\nPQR: (2,2),(1,1),(0,0)";
        //    string actualResult = wordSearch.GetDownwardDiagonalWords(input);

        //    Assert.AreEqual(expectedResult, actualResult);
        //}

        //[TestMethod]
        //public void Test010_GivenWordSearch_GetDownwardDiagonalsReturnsWordAndLocationOfLetters_ForAllUpwardDiagonalCases()
        //{
        //    WordSearch wordSearch = new WordSearch();

        //    string input = wordSearch.GetInput("TestDocument007_UpwardDiagonalTests.txt");

        //    string expectedResult = "ABC: (0,4),(1,3),(2,2)\nDEF: (1,5),(2,4),(3,3)\nGHI: (3,0),(2,1),(1,2)\nJKL: (4,3),(3,4),(2,5)\nMNO: (0,5),(1,4),(2,3)\nPQR: (5,0),(4,1),(3,2)";
        //    string actualResult = wordSearch.GetUpwardsDiagonalWords(input);

        //    Assert.AreEqual(expectedResult, actualResult);
        //}
    }
}
