using System;
using System.Linq;

/*
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * На основе полученных чисел получить новое по формуле: 5 + a[0] - a[1] + a[2] - a[3] + ...
 * Это необходимо сделать двумя способами:
 * 1) с помощью встроенного LINQ метода Aggregate
 * 2) с помощью своего метода MyAggregate, сигнатура которого дана в классе MyClass
 * Вывести полученные результаты на экран (естественно, они должны быть одинаковыми)
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 8
 * 8
 * 
 * Пояснение:
 * 5 + 1 - 2 + 3 - 4 + 5 = 8
 * 
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 */

namespace Task04
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RunTesk04();
        }

        public static void RunTesk04()
        {
            int[] arr;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x)).ToArray();
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
                return;
            }

            // использовать синтаксис методов! SQL-подобные запросы не писать!

            int arrAggregate = 5 + arr.Aggregate((x, y) => x + (y % 2 == 0 ? -y : y)); // wtf
            // int arrAggregate = 5 + arr.Aggregate((x, y) => x + y - (2 * (1 - y % 2) * y)); // wtf^2

            int arrMyAggregate = MyClass.MyAggregate(arr);

            Console.WriteLine(arrAggregate);
            Console.WriteLine(arrMyAggregate);
        }
    }

    internal static class MyClass
    {
        public static int MyAggregate(int[] arr)
        {
            int res = 5;

            for (int i = 0; i < arr.Length; i++)
            {
                res += i % 2 == 0 ? arr[i] : -arr[i];
            }

            return res;
        }
    }
}
