using System;
using System.Collections.Generic;
using System.Text;

namespace KATAs
{
    public class ComplementaryDNA
    {
        public string MakeComplement(string dna)
        {
            string result = "";

            foreach (char character in dna)
            {
                if (character == 'A')
                {
                    result += 'T';
                }
                else
                {
                    result += character;
                }
            }

            return result;
        }
    }
}
