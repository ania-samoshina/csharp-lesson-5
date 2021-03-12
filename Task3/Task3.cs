using System;
using System.Linq;

namespace Task3
{
    //3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
    //а) с использованием методов C#;
    //б) * разработав собственный алгоритм.
    // Например:
    //badc являются перестановкой abcd.
    public class Task3
    {
        private static void PrintExampleTitle(string string1, string string2)
        {
            Console.WriteLine($"Is [{string1}] permutation of [{string2}]?");
        }

        private static bool CheckIsPermutation(string string1, string string2)
        {
            if(string1.Length != string2.Length)
            {
                return false;
            }

            foreach(char letter in string1)
            {
                if(string2.IndexOf(letter) == -1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckIsPermutationViaCSharp(string string1, string string2)
        {
            if (string1.Length != string2.Length)
            {
                return false;
            }


            char[] string1Letters = string1.ToCharArray();
            char[] string2Letters = string2.ToCharArray();

            Array.Sort(string1Letters);
            Array.Sort(string2Letters);

            return Enumerable.SequenceEqual(string1Letters, string2Letters);     
        }

        public static void Execute()
        {   
            string string1 = "abcd";
            string string2 = "badc";

            
            PrintExampleTitle(string1, string2);

            if(CheckIsPermutation(string1, string2))
            {
                Console.WriteLine("Yes!");
            } else
            {
                Console.WriteLine("No!");
            }

            if (CheckIsPermutationViaCSharp(string1, string2))
            {
                Console.WriteLine("Yes!");
            }
            else
            {
                Console.WriteLine("No!");
            }

            string string3 = "edfc";
            string string4 = "emfc";

            PrintExampleTitle(string3, string4);

            if (CheckIsPermutation(string3, string4))
            {
                Console.WriteLine("Yes!");
            }
            else
            {
                Console.WriteLine("No!");
            }

            if (CheckIsPermutationViaCSharp(string3, string4))
            {
                Console.WriteLine("Yes!");
            }
            else
            {
                Console.WriteLine("No!");
            }
        }
    }
}
