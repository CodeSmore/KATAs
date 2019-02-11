using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            List<string> wordsInSearch = GetWordsInSearch(input);
            List<string> linesInSearch = GetLinesInSearch(input);


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
            List<string> wordsInSearch = GetWordsInSearch(input);
            List<string> linesInSearch = GetLinesInSearch(input);


            // search each line
            for (int i = 0; i < linesInSearch.Count; ++i)
            {
                // using each word that we're looking for
                for (int j = 0; j < wordsInSearch.Count; ++j)
                {

                    if (linesInSearch[i].Contains(ReverseString(wordsInSearch[j])))
                    {
                        result += wordsInSearch[j] + ": ";

                        // find positions of letters
                        for (int k = 0; k < linesInSearch[i].Length; ++k)
                        {
                            if (linesInSearch[i].Substring(k).Length >= wordsInSearch[j].Length)
                            {
                                if (linesInSearch[i].Substring(k, wordsInSearch[j].Length) == ReverseString(wordsInSearch[j]))
                                {
                                    int xPositionOfFirstLetter = wordsInSearch[j].Length + k - 1;
                                    for (int l = xPositionOfFirstLetter; l > xPositionOfFirstLetter - wordsInSearch[j].Length;  --l)
                                    {
                                        if (l < wordsInSearch[j].Length + k - 1)
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

        public List<string> GetLinesInSearch(string input)
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

        public List<string> GetWordsInSearch(string input)
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
