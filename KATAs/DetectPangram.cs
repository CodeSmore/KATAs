using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
