using System;

namespace Course3
{
    class Program
    {
        static void Main(string[] args)
        {
            Print.Print.PrintName("Ann Samoshina");
            Console.WriteLine("Enter your task: ");
            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            switch (caseSwitch)
            {
                case 1:
                    Task1.Task1.Execute();
                    break;
                case 2:
                    Task2.Task2.Execute();
                    break;
                case 3:
                    Task3.Task3.Execute();
                    break;
                case 4:
                    Task4.Task4.Execute();
                    break;
                case 5:
                    Task5.Task5.Execute();
                    break;
            }
            Console.ReadKey();

        }
    }
}
