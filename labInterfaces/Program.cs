using System;

namespace labInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramConverter[] check = new ProgramConverter[2]; // создали массив элементов ProgramConverter 
            check[0] = new ProgramConverter(); // тип ProgramConverter
            check[1] = new ProgramHelper(); // тип ProgramHelper
            for (int i = 0; i < check.Length; i++) // проверка реализации метода ICodeChecker
            {
                if (check[i] is ICodeChecker) // если метод реализуется, вызываем метод проверки кода и соответствующий метод преобразования
                {
                    ICodeChecker codeCheck = check[i] as ProgramHelper; 
                    if (codeCheck.CheckCodeSyntax("coding", "programmer")) Console.WriteLine(check[i].ConvertToCSharp("coding"));
                    else Console.WriteLine(check[i].ConvertToVB("coding"));
                }
                else // если метод не реализуется, вызываем два метода преоброзвания кода
                {
                    IConvertible convert = check[i] as ProgramConverter;
                    Console.WriteLine(convert.ConvertToCSharp("coding"));
                    Console.WriteLine(convert.ConvertToVB("coding"));
                }
            }
        }
    }

    interface IConvertible // реализуем интерфейс IConvertible
    {
        string ConvertToCSharp(string toSharp); // реализуем метод ConvertToSharp, который возвращает строку
        string ConvertToVB(string toVB); // реализуем метод ConvertToVB, который возвращает строку
    }

    interface ICodeChecker // 3 ий пункт ( создание нового интерфейса, опредилив метод CheckCodeSyntax )
    {
        bool CheckCodeSyntax(string str1, string str2); // метод принимает 2 строки (строка для проверки и используемый язык) тип данных bool
    }
    class ProgramHelper : ProgramConverter, ICodeChecker // создаем класс ProgramHelper, который реализует IConvertible + добавили наследование от IcodeChecker
    {
        public string ConvertToCSharp(string toSharp)
        {
            return "ProgramHelper_toCSharp"; // простые строковые сообщения для имитации преоброзования
        }

        public string ConvertToVB(string toVB)
        {
            return "ProgramHelper_toVB"; // простые строковые сообщения для имитации преоброзования
        }

        public bool CheckCodeSyntax(string str, string lang)
        {
            return true;
        }
    }

    public class ProgramConverter : IConvertible // класс ProgramConverter реализует интерфейс IConvertible
    {
        public string ConvertToCSharp(string toSharp) // опредилили первый  метод конвертации
        {
            return "ProgramConverter_toCSharp";
        }

        public string ConvertToVB(string toVB) // опредилили второй метод конвертации
        {
            return "ProgramConverter_toVB";
        }
    }
}