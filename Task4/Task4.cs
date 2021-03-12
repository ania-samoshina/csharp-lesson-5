using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task4
{
    //4. Задача ЕГЭ.
    //*На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
    //В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая 
    //из следующих N строк имеет следующий формат:
    //<Фамилия> <Имя> <оценки>,
    //где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем 
    //из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
    //<Фамилия> и<Имя>, а также <Имя> и<оценки> разделены одним пробелом.
    //Пример входной строки:
    //Иванов Петр 4 5 3
    //Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и 
    //имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, 
    //что и один из трёх худших, следует вывести и их фамилии и имена.
    //Достаточно решить 2 задачи.Старайтесь разбивать программы на подпрограммы.Переписывайте в начало программы 
    //условие и свою фамилию. Все программы сделать в одном решении. Для решения задач используйте неизменяемые строки (string).
    public class StudentResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int[] Marks { get; set; }

        public float GetAvgMark()
        {
            int totalMarks = 0;

            foreach (int mark in Marks)
            {
                totalMarks += mark;
            }

            return (float)totalMarks / (float)Marks.Length;
        }
    }

    public class ExamResults
    {
        public int StudentCount { get; set; }
        public StudentResult[] StudentResults { get; set; }
    }

    public class Task4
    {
        public static void Execute()
        {
            Console.WriteLine("Loading student data");

            ExamResults examResults = new ExamResults();

            try
            {
                using (StreamReader sr = new StreamReader(@"studentResults.txt"))
                {
                    int studentCount = Convert.ToInt32(sr.ReadLine());
                    examResults.StudentCount = studentCount;
                    examResults.StudentResults = new StudentResult[studentCount];

                    int studentIndex = 0;

                    while (!sr.EndOfStream)
                    {
                        string studentString = sr.ReadLine();
                        string[] dataParts = studentString.Split(' ');

                        StudentResult studentResult = new StudentResult();
                        studentResult.FirstName = dataParts[0];
                        studentResult.LastName = dataParts[1];

                        studentResult.Marks = new int[dataParts.Length - 2];

                        for (int i = 2; i < dataParts.Length; i++)
                        {
                            studentResult.Marks[i-2] = Convert.ToInt32(dataParts[i]);
                        }

                        examResults.StudentResults[studentIndex] = studentResult;
                        studentIndex++;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error reading student results: {ex.Message}");
            }

            Console.WriteLine("Top 3 students with worst average marks");

            float[] averageResults = new float[examResults.StudentCount];

            for (int i=0; i<examResults.StudentCount;i++)
            {
                averageResults[i] = examResults.StudentResults[i].GetAvgMark();
            }

            Array.Sort(averageResults);

            List<float> threeWorstAvegate = averageResults.Take(3).ToList();

            foreach (StudentResult result in examResults.StudentResults)
            {
                if (threeWorstAvegate.Contains(result.GetAvgMark()))
                {
                    Console.WriteLine($"{result.LastName} {result.FirstName}");
                }
            }

            Console.ReadKey();
        }
    }
}
