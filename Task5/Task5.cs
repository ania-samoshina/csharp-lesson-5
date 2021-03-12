using System;
using System.Collections.Generic;
using System.IO;

namespace Task5
{
    //5. ** Написать игру «Верю.Не верю». В файле хранятся вопрос и ответ, правда это или нет.
    //Например: «Шариковую ручку изобрели в древнем Египте», «Да». Компьютер загружает эти 
    //данные, случайным образом выбирает 5 вопросов и задаёт их игроку.Игрок отвечает Да или 
    //Нет на каждый вопрос и набирает баллы за каждый правильный ответ.Список вопросов ищите 
    //во вложении или воспользуйтесь интернетом.
    public class Question
    {
        public string Text { get; set; }
        public string Answer { get; set; }
    }

    public class TrueFalseGame
    {
        public List<Question> Questions { get; set; }

        public void PlayRound()
        {          
            int roundCount = 0;
            int playerScore = 0;

            Console.WriteLine("Привет! Добропожаловать в игру Верю.Не верю!");

            while (roundCount < 5)
            {
                Console.WriteLine($"\nВопрос №: {roundCount+1}");
                Question selectedQuestion = GetRandomQuestion();

                Console.WriteLine(selectedQuestion.Text);
                Console.WriteLine("\nВвведите ответ: [Да\\Нет]");

                string playerAnswer = Console.ReadLine();

                if (playerAnswer == selectedQuestion.Answer)
                {
                    Console.WriteLine("Ура! Вы ответили правильно!");
                    playerScore++;
                }
                else
                {
                    Console.WriteLine("Вы ответили непарвильно");
                }

                roundCount++;
            }

            Console.WriteLine($"\nИгра окончена. Ваши баллы: {playerScore}");
        }

        private Question GetRandomQuestion()
        {
            Random random = new Random();
            return Questions[random.Next(0, Questions.Count - 1)];
        }
    }

    public class Task5
    {
        public static void Execute()
        {
            List<Question> questions = new List<Question>();

            try
            {
                using (StreamReader sr = new StreamReader("questions.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string questionString = sr.ReadLine();
                        string[] questionData = questionString.Split("---");

                        Question question = new Question();
                        question.Text = questionData[0];
                        question.Answer = questionData[1];

                        questions.Add(question);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error reading questions file {ex.Message}");
            }

            TrueFalseGame trueFalseGame = new TrueFalseGame();
            trueFalseGame.Questions = questions;
            trueFalseGame.PlayRound();

            Console.ReadLine();
        }
    }
}
