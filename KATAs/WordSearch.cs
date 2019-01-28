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
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            string subfolderName = @"KATAs.Data\WordSearch";

            string filePath = Path.Combine(projectDirectory, subfolderName, fileName);

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
    }
}
