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



            return result;
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
    }
}
