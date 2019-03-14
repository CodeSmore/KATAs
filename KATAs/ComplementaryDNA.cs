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
                else if (character == 'T')
                {
                    result += 'A';
                }
                else if (character == 'C')
                {
                    result += 'G';
                }
                else if (character == 'G')
                {
                    result += 'C';
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
