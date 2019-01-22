using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pig_Latin_Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!\n");
            char response;

            do
            {   
                Console.Write("Please enter a line to be translated. ");
                string translateLine = Console.ReadLine();

                
                while ((translateLine == "") || (translateLine == " "))
                {
                    Console.WriteLine("That entry is invalid.");
                    Console.Write("Please enter a line to be translated. ");
                    translateLine = Console.ReadLine();
                }

                
                string[] arrayOfStrings = translateLine.Split(' ');
                string translatedLine = "";

               
                foreach (string word in arrayOfStrings)
                {
                    string pLatinWord = PigLatinGenerator(word);
                    translatedLine = translatedLine + " " + pLatinWord;
                }

                Console.WriteLine(translatedLine);
                Console.Write("\nWould you like to translate another line?(y or n) ");

                response = Console.ReadLine().ToLower()[0];
                while ((response != 'y') && (response != 'n'))
                {
                    Console.Write("Please enter y/n: ");
                    response = Console.ReadLine().ToLower()[0];
                }

            } while (response == 'y');
        }

        public static string PigLatinGenerator(string text)
        {
            
            text = text.Trim();

            
            if (Symbol(text))
            {
                return text;
            }

            string newWord = "";

            string vowels = "aeiouAEIOU";
            int firstVowelIndex = text.IndexOfAny(vowels.ToCharArray());


            if (firstVowelIndex == 0)
            {
                newWord = text + "way";
            }
            else
            {
                newWord += text.Substring(firstVowelIndex);
                newWord += text.Substring(0, firstVowelIndex);
                newWord += "ay";
            }

            return newWord;

            bool Symbol(string word)
            {
                foreach (char c in word)
                {
                    if (char.IsSymbol(c))
                    {
                        return true;
                    }

                    if (char.IsNumber(c))
                    {
                        return true;
                    }

                    char[] symbols = { '@', '#', '&', '%' };
                    if (word.IndexOfAny(symbols) != -1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
