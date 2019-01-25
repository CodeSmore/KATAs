/*
 A string is considered to be in title case if each word in the string is either (a) capitalised 
 (that is, only the first letter of the word is in upper case) or (b) considered to be an exception 
 and put entirely into lower case unless it is the first word, which is always capitalised.

Write a function that will convert a string into title case, given an optional list of 
exceptions (minor words). The list of minor words will be given as a string with each word 
separated by a space. Your function should ignore the case of the minor words string -
- it should behave in the same way even if the case of the minor word string is changed.
 */

using System;
using System.Collections.Generic;

namespace KATAs
{
    public class TitleCase
    {
        public string GetTitleCase(string title, string minorWords = "")
        {
            string result = "";
            bool skipTitleCasing = false;

            List<string> titleWords = GetWordsFromString(title);
            foreach (string word in titleWords)
            {
                List<string> minorWordsList = GetWordsFromString(minorWords);

                for (int i = 0; i < minorWordsList.Count; ++i)
                {
                    if (word == minorWordsList[i])
                    {
                        if (word != titleWords[0])
                        {
                            result += " ";
                        }

                        result += word;
                        skipTitleCasing = true;
                        break;
                    }
                }

                if (!skipTitleCasing)
                {
                    foreach (char character in word)
                    {
                        if (TitleAndMinorWordsAreTheSame(word, minorWords))
                        {
                            result = title;
                        }
                        else
                        {
                            if (character == word[0])
                            {
                                if (result != "")
                                {
                                    result += " ";
                                }
                                result += Char.ToUpper(character);
                            }
                            else
                            {
                                result += character;
                            }
                        }
                    }
                }

                skipTitleCasing = false;
            }

            return result;
        }

        public List<string> GetWordsFromString(string stringOfWords)
        {
            List<string> resultStrings = new List<string>();

            string word = "";
            foreach (char character in stringOfWords)
            {
                if (character != ' ')
                {
                    word += character;
                }
                else
                {
                    resultStrings.Add(word);
                    word = "";
                }
            }

            resultStrings.Add(word);

            return resultStrings;
        }

        bool TitleAndMinorWordsAreTheSame(string title, string minorWords)
        {
            return (title == minorWords);
        }
    }
}
