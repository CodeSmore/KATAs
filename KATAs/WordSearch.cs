using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace KATAs
{
    public class WordSearch
    {
        public string GetInput(string fileName)
        {
            // C:\Users\codes\source\repos\KATAs\KATAs.Data

            string fileContentsAsString = "";

            string workingDirectory = Directory.GetCurrentDirectory();
            string solutionDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            string subfolderPath = @"KATAs.Data\WordSearch";

            string filePath = Path.Combine(solutionDirectory, subfolderPath, fileName);

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    // Read in the line
                    fileContentsAsString += sr.ReadLine();

                    if (!sr.EndOfStream)
                    {
                        fileContentsAsString += " ";
                    }
                }
            }

            return fileContentsAsString;
        }

        public string GetForwardHorizontalWords(string input)
        {
            string result = "";
            List<string> wordsInSearch = GetWordSearchKeywords(input);
            List<string> linesInSearch = GetLinesInWordSearch(input);


            // search each line
            for (int i = 0; i < linesInSearch.Count; ++i)
            {
                for (int j = 0; j < wordsInSearch.Count; ++j)
                {
                    if (linesInSearch[i].Contains(wordsInSearch[j]))
                    {
                        result += wordsInSearch[j] + ": ";

                        // find positions
                        for (int k = 0; k < linesInSearch[i].Length; ++k)
                        {
                            if (linesInSearch[i].Substring(k).Length >= wordsInSearch[j].Length)
                            {
                                if (linesInSearch[i].Substring(k, wordsInSearch[j].Length) == wordsInSearch[j])
                                {
                                    for (int l = k; l < wordsInSearch[j].Length + k; ++l)
                                    {
                                        if (l > k)
                                        {
                                            result += ",";
                                        }
                                        result += "(" + l + "," + i + ")";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        public string GetBackwardsHorizontalWords(string input)
        {
            string result = "";
            List<string> wordSearchKeywords = GetWordSearchKeywords(input);
            List<string> linesInWordSearch = GetLinesInWordSearch(input);


            // search each line
            for (int i = 0; i < linesInWordSearch.Count; ++i)
            {
                // using each word that we're looking for
                for (int j = 0; j < wordSearchKeywords.Count; ++j)
                {

                    if (linesInWordSearch[i].Contains(ReverseString(wordSearchKeywords[j])))
                    {
                        result += wordSearchKeywords[j] + ": ";

                        // find positions of letters
                        for (int k = 0; k < linesInWordSearch[i].Length; ++k)
                        {
                            if (linesInWordSearch[i].Substring(k).Length >= wordSearchKeywords[j].Length)
                            {
                                if (linesInWordSearch[i].Substring(k, wordSearchKeywords[j].Length) == ReverseString(wordSearchKeywords[j]))
                                {
                                    int xPositionOfFirstLetter = wordSearchKeywords[j].Length + k - 1;
                                    for (int l = xPositionOfFirstLetter; l > xPositionOfFirstLetter - wordSearchKeywords[j].Length;  --l)
                                    {
                                        if (l < wordSearchKeywords[j].Length + k - 1)
                                        {
                                            result += ",";
                                        }
                                        result += "(" + l + "," + i + ")";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        public string GetDownwardsVerticalWords(string input)
        {
            string result = "";
            List<string> wordSearchKeywords = GetWordSearchKeywords(input);
            List<string> linesInWordSearch = GetLinesInWordSearch(input);

            string[,] wordSearchArray = new string[linesInWordSearch[0].Length, linesInWordSearch.Count];

            wordSearchArray = FillWordSearchArray(linesInWordSearch);

            // search each line
            for (int i = 0; i < wordSearchArray.GetLength(0); ++i)
            {
                // using each word that we're looking for
                for (int j = 0; j < wordSearchKeywords.Count; ++j)
                {
                    string column = "";

                    for (int k = 0; k < wordSearchArray.GetLength(0); ++k)
                    {
                        column += wordSearchArray[k, i];
                    }

                    if (column.Contains(wordSearchKeywords[j]))
                    {
                        result += wordSearchKeywords[j] + ": ";

                        // find positions of letters
                        for (int k = 0; k < column.Length; ++k)
                        {
                            if (column.Substring(k).Length >= wordSearchKeywords[j].Length)
                            {
                                if (column.Substring(k, wordSearchKeywords[j].Length) == (wordSearchKeywords[j]))
                                {
                                    int xPositionOfFirstLetter = wordSearchKeywords[j].Length + k - 1;
                                    for (int l = k; l < wordSearchKeywords[j].Length + k; ++l)
                                    {
                                        if (l > k)
                                        {
                                            result += ",";
                                        }
                                        result += "(" + l + "," + i + ")";
                                    }
                                }
                            }
                        }
                    }
                    //if (linesInWordSearch[i].Contains(wordSearchKeywords[j]))
                    //{
                    //    result += wordSearchKeywords[j] + ": ";

                    //    // find positions of letters
                    //    for (int k = 0; k < linesInWordSearch[i].Length; ++k)
                    //    {
                    //        if (linesInWordSearch[i].Substring(k).Length >= wordSearchKeywords[j].Length)
                    //        {
                    //            if (linesInWordSearch[i].Substring(k, wordSearchKeywords[j].Length) == ReverseString(wordSearchKeywords[j]))
                    //            {
                    //                int xPositionOfFirstLetter = wordSearchKeywords[j].Length + k - 1;
                    //                for (int l = xPositionOfFirstLetter; l > xPositionOfFirstLetter - wordSearchKeywords[j].Length; --l)
                    //                {
                    //                    if (l < wordSearchKeywords[j].Length + k - 1)
                    //                    {
                    //                        result += ",";
                    //                    }
                    //                    result += "(" + l + "," + i + ")";
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }
            }

            return result;
        }

        public string[,] FillWordSearchArray(List<string> linesInWordSearch)
        {
            string[,] result = new string[linesInWordSearch[0].Length, linesInWordSearch.Count];

            for (int i = 0; i < linesInWordSearch[0].Length; ++i)
            {
                for (int j = 0; j < linesInWordSearch.Count; ++j)
                {
                    result[i, j] = linesInWordSearch[i].Substring(j, 1);
                }
            }

            return result;
        }

        public List<string> GetLinesInWordSearch(string input)
        {
            List<string> linesInSearch = new List<string>();

            string line = "";
            bool startAddingLines = false;
            foreach (char character in input)
            {
                if (!startAddingLines)
                {
                    if (character == ' ')
                    {
                        startAddingLines = true;
                    }
                }
                else
                {
                    if (character == ' ')
                    {
                        linesInSearch.Add(line);
                        line = "";
                    }
                    else if (character != ',')
                    {
                        line += character;
                    }
                }
            }

            if (line != "")
            {
                linesInSearch.Add(line);
            }

            return linesInSearch;
        }

        public List<string> GetWordSearchKeywords(string input)
        {
            List<string> result = new List<string>();
            string word = "";

            foreach (char character in input)
            {
                if (character == ' ')
                {
                    result.Add(word);
                    break;
                }

                if (character != ',' && character != ' ')
                {
                    word += character;
                }
                else
                {
                    result.Add(word);
                    word = "";
                }
            }

            return result;
        }

        // taken from
        // https://www.dotnetperls.com/reverse-string
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
