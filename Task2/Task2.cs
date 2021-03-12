using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    //2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
    //а) Вывести только те слова сообщения, которые содержат не более n букв.
    //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    //в) Найти самое длинное слово сообщения.
    //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    //Продемонстрируйте работу программы на текстовом файле с вашей программой.

    public class Message
    {
        public string SourceString { get; set; }

        public Message(string sourceString)
        {
            SourceString = sourceString;
        }

        ////Вывод слов, которые короче N символов
        public List<string> ShorterThan(int length)
        {
            var returnList = new List<string>();
            foreach (string word in GetWords())
            {
                if (word.Length < length) returnList.Add(word);
            }
            return returnList;
        }

        ///Сообщение с удалением слов заканчивающимися на указанную букву
        public string RemoveEndsLetter(char letter)
        {
            var returnList = new List<string>();
            foreach (string word in GetWords())
            {
                if (!word.EndsWith(letter.ToString())) returnList.Add(word);
            }
            return string.Join(" ",returnList);
        }
        ////Самые длинные слова из введенной строки:
        public List<string> LongWords()
        {
            List<string> longWords = new List<string>();
            int maxWordLength = GetMaxWordLength();

            foreach (string word in GetWords())
            {
                if (word.Length == maxWordLength)
                {
                    longWords.Add(word);
                }
            }

            return longWords;
        }

        //// Сформировать строку с помощью StringBuilder из самых длинных слов сообщения. вставить сюда 
        public string GetLongWordsString()
        {
            var longWords = LongWords();
            StringBuilder longWordsBuilder = new StringBuilder();

            longWordsBuilder.AppendJoin(' ', longWords);

            return longWordsBuilder.ToString();
        }

        private string RemovePunctuation(string word)
        {
            StringBuilder wordBuilder = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (!char.IsPunctuation(word[i]))
                    wordBuilder.Append(word[i]);
            }

            return wordBuilder.ToString();
        }

        private string[] GetWords()
        {
            string[] words = SourceString.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = RemovePunctuation(words[i]);
            }

            return words;
        }

        private int GetMaxWordLength()
        {
            int maxWordLength = 0;
            foreach (string word in GetWords())
            {
                if (maxWordLength < word.Length)
                {
                    maxWordLength = word.Length;
                }
            }

            return maxWordLength;
        }
    }

    public class Task2
    {
        public static void Execute()
        {

            Message message = new Message("Let those who are in favour with their stars Of public honour and proud titles boast Whilst I whom fortune of such triumph bars Unlookd for joy in that I honour most.");

            Console.WriteLine("Text to be processed:");
            Console.WriteLine(message.SourceString);

            Console.WriteLine("\nOutputting words shorter than 4 letters:");
            foreach (string s in message.ShorterThan(4))
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nRemoving words that do not end with the letter [e]");
            Console.WriteLine(message.RemoveEndsLetter('e'));


            Console.WriteLine("\nLongest words:");
            // Получить финальную строку
            foreach (string word in message.LongWords())
            {
                Console.WriteLine(word);
            }

            Console.WriteLine($"\nString with longest words:\n{message.GetLongWordsString()}");

            Console.ReadLine();
        }

    }
}
