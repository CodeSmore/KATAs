using System;
using System.Collections.Generic;
using System.IO;

// *** NOTE: NOT COMPLETED!! ***
// Due to feeling like I'm banging my head against a wall, I'll be putting this on hold. 
// To reduce distractions from failed tests, I've commented out failing tests.
// Perhaps in the future, I'll give it another go.

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

        public string GetUpwardsDiagonalWords(string input)
        {
            string result = "";
            List<string> keywords = GetWordSearchKeywords(input);
            List<string> rowsInWordSearch = GetRowsInWordSearch(input);
            List<string> upwardDiagonalsInWordSearch = GetUpwardDiagonalsInWordSearch(rowsInWordSearch);

            // search each line
            // i is an iteration for each row of the word search
            for (int i = 0; i < upwardDiagonalsInWordSearch.Count; ++i)
            {
                // j is an interation for each keyword that can be found in the word search
                for (int j = 0; j < keywords.Count; ++j)
                {
                    string diagonal = upwardDiagonalsInWordSearch[i];

                    if (diagonal.Contains(keywords[j]))
                    {
                        result += newLineIfStringIsNotEmpty(result);
                        result += keywords[j] + ": " + GetKeywordUpwardDiagonalLetterPositions(i, keywords[j], upwardDiagonalsInWordSearch[i]);
                    }
                    else if (diagonal.Contains(ReverseString(keywords[j])))
                    {
                        result += newLineIfStringIsNotEmpty(result);
                        result += keywords[j] + ": " + GetKeywordBackwardsUpwardDiagonalLetterPositions(i, keywords[j], upwardDiagonalsInWordSearch[i], upwardDiagonalsInWordSearch.Count);
                        
                    }
                }
            }
            return result;
        }

        public string GetDownwardDiagonalWords(string input)
        {
            string result = "";
            List<string> keywords = GetWordSearchKeywords(input);
            List<string> rowsInWordSearch = GetRowsInWordSearch(input);
            List<string> downwardDiagonalsInWordSearch = GetDownwardDiagonalsInWordSearch(rowsInWordSearch);

            for (int i = 0; i < downwardDiagonalsInWordSearch.Count; ++i)
            {
                // j is an interation for each keyword that can be found in the word search
                for (int j = 0; j < keywords.Count; ++j)
                {
                    string diagonal = downwardDiagonalsInWordSearch[i];
                    int diagonalIndex = i;

                    if (diagonal.Contains(keywords[j]))
                    {
                        result += newLineIfStringIsNotEmpty(result);
                        result += keywords[j] + ": " + GetKeywordDownwardDiagonalLetterPositions(diagonalIndex, keywords[j], downwardDiagonalsInWordSearch[i], downwardDiagonalsInWordSearch.Count);
                    }
                    else if (diagonal.Contains(ReverseString(keywords[j])))
                    {
                        result += newLineIfStringIsNotEmpty(result);
                        result += keywords[j] + ": " + GetKeywordBackwardsDownwardDiagonalLetterPositions(diagonalIndex, keywords[j], downwardDiagonalsInWordSearch[i], downwardDiagonalsInWordSearch.Count);
                    }
                }
            }
            return result;
        }

        string GetKeywordDownwardsVerticalLetterPositions(int columnIndex, string keyword, string columnString)
        {
            string result = "";

            // find positions
            // k represents which column position we are looking at in the specified row
            for (int k = 0; k < columnString.Length; ++k)
            {
                if (columnString.Substring(k).Length >= keyword.Length)
                {
                    if (columnString.Substring(k, keyword.Length) == keyword)
                    {
                        for (int l = k; l < keyword.Length + k; ++l)
                        {
                            if (l > k)
                            {
                                result += ",";
                            }
                            result += "(" + columnIndex + "," + l + ")";
                        }
                    }
                }
            }
            return result;
        }

        string GetKeywordUpwardsVerticalLetterPositions(int columnIndex, string keyword, string columnString)
        {
            string result = "";

            // find positions of letters
            for (int k = 0; k < columnString.Length; ++k)
            {
                if (columnString.Substring(k).Length >= keyword.Length)
                {
                    if (columnString.Substring(k, keyword.Length) == ReverseString(keyword))
                    {
                        int xPositionOfFirstLetter = keyword.Length + k - 1;
                        for (int l = xPositionOfFirstLetter; l > xPositionOfFirstLetter - keyword.Length; --l)
                        {
                            if (l < keyword.Length + k - 1)
                            {
                                result += ",";
                            }
                            result += "(" + columnIndex + "," + l + ")";
                        }
                    }
                }
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

        string GetKeywordUpwardDiagonalLetterPositions(int diagonalIndex, string keyword, string diagonalString)
        {
            string result = "";

            // find positions of letters
            for (int k = 0; k < diagonalString.Length; ++k)
            {
                if (diagonalString.Substring(k).Length >= keyword.Length)
                {
                    if (diagonalString.Substring(k, keyword.Length) == keyword)
                    {
                        for (int l = k; l < keyword.Length; ++l)
                        {
                            if (l > k)
                            {
                                result += ",";
                            }
                            result += "(" + l + "," + diagonalIndex-- + ")";
                        }
                    }
                }
            }
            return result;
        }

        string GetKeywordBackwardsUpwardDiagonalLetterPositions(int diagonalIndex, string keyword, string diagonalString, int numberOfDiagonals)
        {
            string result = "";

            // find positions of letters
            for (int k = 0; k < diagonalString.Length; ++k)
            {
                if (diagonalString.Substring(k).Length >= keyword.Length)
                {
                    if (diagonalString.Substring(k, keyword.Length) == ReverseString(keyword))
                    {
                        // find x and y positions of first letter in the keyword
                        int xPositionOfFirstLetter = k + keyword.Length - 1;
                        int yPositionOfFirstLetter = k + keyword.Length - 1;

                        int indexOfDiagonalAtOrigin = numberOfDiagonals / 2 + 1;

                        if (diagonalIndex > indexOfDiagonalAtOrigin)
                        {
                            xPositionOfFirstLetter += indexOfDiagonalAtOrigin - diagonalIndex;
                        }
                        //else if (diagonalIndex < indexOfDiagonalAtOrigin)
                        //{
                        //    yPositionOfFirstLetter += diagonalIndex - indexOfDiagonalAtOrigin;
                        //}

                        for (int l = xPositionOfFirstLetter; l > xPositionOfFirstLetter - keyword.Length; --l)
                        {
                            if (l < keyword.Length + k - 1)
                            {
                                result += ",";
                            }
                            result += "(" + l + "," + yPositionOfFirstLetter++ + ")";
                        }
                    }
                }
            }
            return result;
        }

        string GetKeywordDownwardDiagonalLetterPositions(int diagonalIndex, string keyword, string diagonalString, int numberOfDiagonals)
        {
            string result = "";

            // find positions of letters
            for (int k = 0; k < diagonalString.Length; ++k)
            {
                if (diagonalString.Substring(k).Length >= keyword.Length)
                {
                    if (diagonalString.Substring(k, keyword.Length) == keyword)
                    {                        
                        // find x and y positions of first letter in the keyword
                        int xPositionOfFirstLetter = k;
                        int yPositionOfFirstLetter = k;

                        int indexOfDiagonalAtOrigin = numberOfDiagonals / 2;

                        if (diagonalIndex < indexOfDiagonalAtOrigin)
                        {
                            xPositionOfFirstLetter += indexOfDiagonalAtOrigin - diagonalIndex;
                        }
                        else if (diagonalIndex > indexOfDiagonalAtOrigin)
                        {
                            yPositionOfFirstLetter += diagonalIndex - indexOfDiagonalAtOrigin;
                        }

                        // find the positions for each letter in the keyword
                        for (int l = xPositionOfFirstLetter; l < keyword.Length + xPositionOfFirstLetter; ++l)
                        {
                            if (l > xPositionOfFirstLetter)
                            {
                                result += ",";
                            }
                            result += "(" + l + "," + yPositionOfFirstLetter++ + ")";
                        }
                    }
                }
            }
            return result;
        }

        string GetKeywordBackwardsDownwardDiagonalLetterPositions(int diagonalIndex, string keyword, string diagonalString, int numberOfDiagonals)
        {
            string result = "";

            // find positions of letters
            for (int k = 0; k < diagonalString.Length; ++k)
            {
                if (diagonalString.Substring(k).Length >= keyword.Length)
                {
                    if (diagonalString.Substring(k, keyword.Length) == ReverseString(keyword))
                    {
                        // find x and y positions of first letter in the keyword
                        int xPositionOfFirstLetter = k + keyword.Length - 1;
                        int yPositionOfFirstLetter = k + keyword.Length - 1;

                        int indexOfDiagonalAtOrigin = numberOfDiagonals / 2;
                     
                        if (diagonalIndex < indexOfDiagonalAtOrigin)
                        {
                            xPositionOfFirstLetter += indexOfDiagonalAtOrigin - diagonalIndex;
                        }
                        else if (diagonalIndex > indexOfDiagonalAtOrigin)
                        {
                            yPositionOfFirstLetter += diagonalIndex - indexOfDiagonalAtOrigin;
                        }
                        
                        // find the positions for each letter in the keyword
                        for (int l = xPositionOfFirstLetter; l > xPositionOfFirstLetter - keyword.Length; --l)
                        {
                            if (l < xPositionOfFirstLetter)
                            {
                                result += ",";
                            }
                            result += "(" + l + "," + yPositionOfFirstLetter-- + ")";
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

        public List<string> GetColumnsInWordSearch(List<string> rowsInWordSearch)
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

        public List<string> GetUpwardDiagonalsInWordSearch(List<string> rowsInWordSearch)
        {
            List<string> result = new List<string>();
            string[,] wordSearchArray = new string[rowsInWordSearch[0].Length, rowsInWordSearch.Count];

            for (int i = 0; i < rowsInWordSearch[0].Length; ++i)
            {
                for (int j = 0; j < rowsInWordSearch.Count; ++j)
                {
                    wordSearchArray[i, j] = rowsInWordSearch[j].Substring(i, 1);
                }
            }

            string newDiagonal = "";
            // fill w/ x = 0 starting points
            for (int i = 0; i < wordSearchArray.GetLength(1); ++i)
            {
                int xStep = 0, yStep = i;

                while (xStep <= i && yStep >= 0)
                {
                    newDiagonal += wordSearchArray[xStep, yStep];

                    xStep++;
                    yStep--;
                }

                result.Add(newDiagonal);
                newDiagonal = "";
            }

            // fill w/ y = wordSearchArray.GetLength(1) - 1 starting points
            for (int i = 1; i < wordSearchArray.GetLength(1); ++i)
            {
                int xStep = i, yStep = wordSearchArray.GetLength(1) - 1;

                while (xStep < wordSearchArray.GetLength(1) && yStep >= 0)
                {
                    newDiagonal += wordSearchArray[xStep, yStep];

                    xStep++;
                    yStep--;
                }

                result.Add(newDiagonal);
                newDiagonal = "";
            }

            return result;
        }

        public List<string> GetDownwardDiagonalsInWordSearch(List<string> rowsInWordSearch)
        {
            List<string> result = new List<string>();
            string[,] wordSearchArray = new string[rowsInWordSearch[0].Length, rowsInWordSearch.Count];

            for (int i = 0; i < rowsInWordSearch[0].Length; ++i)
            {
                for (int j = 0; j < rowsInWordSearch.Count; ++j)
                {
                    wordSearchArray[i, j] = rowsInWordSearch[j].Substring(i, 1);
                }
            }

            string newDiagonal = "";
            // fill w/ x = row.length-1 starting points
            for (int i = wordSearchArray.GetLength(0) - 1; i >= 0; --i)
            {
                int xStep = i, yStep = 0;

                while (xStep < wordSearchArray.GetLength(0) && yStep < wordSearchArray.GetLength(1))
                {
                    newDiagonal += wordSearchArray[xStep, yStep];

                    xStep++;
                    yStep++;
                }

                result.Add(newDiagonal);
                newDiagonal = "";
            }

            // fill w/ y = i starting points
            for (int i = 1; i < wordSearchArray.GetLength(1); ++i)
            {
                int xStep = 0, yStep = i;

                while (xStep < wordSearchArray.GetLength(0) && yStep < wordSearchArray.GetLength(1))
                {
                    newDiagonal += wordSearchArray[xStep, yStep];

                    xStep++;
                    yStep++;
                }

                result.Add(newDiagonal);
                newDiagonal = "";
            }

            return result;
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
