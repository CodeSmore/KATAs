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
                switch (character)
                {
                    case 'A':
                        result += 'T';
                        break;
                    case 'T':
                        result += 'A';
                        break;
                    case 'C':
                        result += 'G';
                        break;
                    case 'G':
                        result += 'C';
                        break;
                    default:
                        result += character;
                        break;
                }
            }

            return result;
        }
    }
}
