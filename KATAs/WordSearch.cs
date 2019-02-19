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

        public string GetHorizontalWords(string input)
        {
            string result = "";
            List<string> keywords = GetWordSearchKeywords(input);
            List<string> rowsInWordSearch = GetRowsInWordSearch(input);


            // search each row
            // i is an iteration for each row of the word search
            for (int i = 0; i < rowsInWordSearch.Count; ++i)
            {
                // j is an interation for each keyword that can be found in the word search
                for (int j = 0; j < keywords.Count; ++j)
                {
                    if (rowsInWordSearch[i].Contains(keywords[j]))
                    {
                        result += keywords[j] + ": " + GetKeywordForwardHorizontalLetterPositions(i, keywords[j], rowsInWordSearch[i]);

                        
                    }
                    else if (rowsInWordSearch[i].Contains(ReverseString(keywords[j])))
                    {
                        result += keywords[j] + ": " + GetKeywordBackwardsHorizontalLetterPositions(i, keywords[j], rowsInWordSearch[i]); 
                    }
                }
            }
            return result;
        }

        public string GetVerticalWords(string input)
        {
            string result = "";
            List<string> keywords = GetWordSearchKeywords(input);
            List<string> rowsInWordSearch = GetRowsInWordSearch(input);
            List<string> columnsInWordSearch = GetColumnsInWordSearch(rowsInWordSearch);

            // search each line
            // i is an iteration for each row of the word search
            for (int i = 0; i < columnsInWordSearch.Count; ++i)
            {
                // j is an interation for each keyword that can be found in the word search
                for (int j = 0; j < keywords.Count; ++j)
                {
                    string column = columnsInWordSearch[i];

                    if (column.Contains(keywords[j]))
                    {
                        result += newLineIfStringIsNotEmpty(result);
                        result += keywords[j] + ": " + GetKeywordDownwardsVerticalLetterPositions(i, keywords[j], columnsInWordSearch[i]);
                    }
                    else if (column.Contains(ReverseString(keywords[j])))
                    {
                        result += newLineIfStringIsNotEmpty(result);
                        result += keywords[j] + ": " + GetKeywordUpwardsVerticalLetterPositions(i, keywords[j], columnsInWordSearch[i]);
                    }
                }
            }
            return result;
        }

        public string GetKeywordDownwardsVerticalLetterPositions(int rowIndex, string keyword, string rowString)
        {
            string result = "";

            // find positions
            // k represents which column position we are looking at in the specified row
            for (int k = 0; k < rowString.Length; ++k)
            {
                if (rowString.Substring(k).Length >= keyword.Length)
                {
                    if (rowString.Substring(k, keyword.Length) == keyword)
                    {
                        for (int l = k; l < keyword.Length + k; ++l)
                        {
                            if (l > k)
                            {
                                result += ",";
                            }
                            result += "(" + l + "," + rowIndex + ")";
                        }
                    }
                }
            }
            return result;
        }

        string GetKeywordUpwardsVerticalLetterPositions(int rowIndex, string keyword, string rowString)
        {
            string result = "";

            // find positions of letters
            for (int k = 0; k < rowString.Length; ++k)
            {
                if (rowString.Substring(k).Length >= keyword.Length)
                {
                    if (rowString.Substring(k, keyword.Length) == ReverseString(keyword))
                    {
                        int xPositionOfFirstLetter = keyword.Length + k - 1;
                        for (int l = xPositionOfFirstLetter; l > xPositionOfFirstLetter - keyword.Length; --l)
                        {
                            if (l < keyword.Length + k - 1)
                            {
                                result += ",";
                            }
                            result += "(" + l + "," + rowIndex + ")";
                        }
                    }
                }
            }
            return result;
        }

        public List<string> GetColumnsInWordSearch (List<string> rowsInWordSearch)
        {
            List<string> result = new List<string>(rowsInWordSearch[0].Length);
            string column = "";

            for (int i = 0; i < rowsInWordSearch[0].Length; ++i)
            {
                for (int j = 0; j < rowsInWordSearch.Count; ++j)
                {
                    column += rowsInWordSearch[j].Substring(i, 1);
                }
                result.Add(column);
                column = "";
            }

            return result;
        }

        string GetKeywordForwardHorizontalLetterPositions(int rowIndex, string keyword, string rowString)
        {
            string result = "";

            // find positions
            // k represents which column position we are looking at in the specified row
            for (int k = 0; k < rowString.Length; ++k)
            {
                if (rowString.Substring(k).Length >= keyword.Length)
                {
                    if (rowString.Substring(k, keyword.Length) == keyword)
                    {
                        for (int l = k; l < keyword.Length + k; ++l)
                        {
                            if (l > k)
                            {
                                result += ",";
                            }
                            result += "(" + l + "," + rowIndex + ")";
                        }
                    }
                }
            }
            return result;
        }

        string GetKeywordBackwardsHorizontalLetterPositions(int rowIndex, string keyword, string rowString)
        {
            string result = "";

            // find positions of letters
            for (int k = 0; k < rowString.Length; ++k)
            {
                if (rowString.Substring(k).Length >= keyword.Length)
                {
                    if (rowString.Substring(k, keyword.Length) == ReverseString(keyword))
                    {
                        int xPositionOfFirstLetter = keyword.Length + k - 1;
                        for (int l = xPositionOfFirstLetter; l > xPositionOfFirstLetter - keyword.Length; --l)
                        {
                            if (l < keyword.Length + k - 1)
                            {
                                result += ",";
                            }
                            result += "(" + l + "," + rowIndex + ")";
                        }
                    }
                }
            }
            return result;
        }

        public List<string> GetRowsInWordSearch(string input)
        {
            List<string> rowsInSearch = new List<string>();

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
                        rowsInSearch.Add(line);
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
                rowsInSearch.Add(line);
            }

            return rowsInSearch;
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

        public string newLineIfStringIsNotEmpty(string str)
        {
            if (str != "")
            {
                return "\n";
            }

            return "";
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
