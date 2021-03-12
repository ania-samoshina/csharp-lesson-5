using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Task1
{
    //1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, 
    //содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    //а) без использования регулярных выражений;
    //б) * с использованием регулярных выражений.
    public class Task1
    {
        public static bool CheckLogin(string login)
        {
            if (login.Length > 10 || login.Length < 2)
            {
                return false;
            }

            for (int i = 0; i < login.Length-1; i++)
            {
                UnicodeCategory letter = char.GetUnicodeCategory(login[i]);

                switch (letter)
                {
                    case UnicodeCategory.DecimalDigitNumber:
                        {
                            if (i == 0)
                            {
                                return false;
                            }
                        }
                        break;
                    case UnicodeCategory.UppercaseLetter:
                    case UnicodeCategory.LowercaseLetter:
                        break;
                    default:
                        return false;
                }
            }

            return true;
        }

        public static bool CheckLoginViaRegExp(string login)
        {
            Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9]{1,9}$");
            return regex.IsMatch(login);
        }
         
        public static void Execute()
        {
            Console.WriteLine("Login: ");
            string login = Console.ReadLine();

            //Basic check
            if (CheckLogin(login))
                Console.WriteLine("Basic check: login entered correctly - {0}", login);
            else
                Console.WriteLine("Basic check: login is not correct");

            //Regular check
            if (CheckLoginViaRegExp(login))
                Console.WriteLine("Regular check: login entered correctly - {0}", login);
            else
                Console.WriteLine("Regular check: login is not correct");

        }

    }
}
