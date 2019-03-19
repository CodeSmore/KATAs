using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KATAs
{
    public class DetectPangram
    {
        public static bool IsPangram(string str)
        {
            string alphabetString = "abcdefghijklmnopqrstuvwxyz";
            int lettersRemaining = 26;
            str = str.ToLower();

            foreach (char letter in alphabetString)
            {
                if (str.Contains(letter))
                {
                    lettersRemaining--;
                }
            }

            return (lettersRemaining == 0);
        }

        // Best Practice on CodeWars.com uses a Linq statement
        public static bool IsPangramBestPractice(string str)
        {
            return str.Where(ch => Char.IsLetter(ch)).Select(ch => Char.ToLower(ch)).Distinct().Count() == 26;
        }
    }
}
