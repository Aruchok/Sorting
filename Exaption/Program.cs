using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatthiWare.CommandLine.Core.Attributes;
using System.IO;
using System.Text.RegularExpressions;
using MatthiWare.CommandLine;

namespace Sort
{
    /// <summary>
    /// Класс параметров командной строки
    /// </summary>
    public class Options
    {
        ///Путь до файла загрузки
        [Name("pi", "pathIn"), Description("Путь до файла загрузки"), DefaultValue("0")]
        public string PathIn { get; set; }

        ///Путь до файла выгрузки
        [Name("po", "pathOut"), Description("Путь до файла сохранения"), DefaultValue("0")]
        public string PathOut { get; set; }

        ///Тип строки
        [Name("t", "type"), Description("Тип строки"), DefaultValue("int")]
        public string Type { get; set; }

        ///Выбор алгоритма сортировки
        [Name("a", "algo"), Description("Алгоритмы сортировки")]
        public int Algo { get; set; }

        ///Частичная сортировка
        [Name("p", "top"), Description("Коэф. частичной сортировки")]
        public int Top { get; set; }

        ///Переменная для вывода справки
        [Name("h", "help"), Description("Помощь")]
        public string Help { get; set; }
    }


    /// <summary>
    /// Класс методов сортировки
    /// </summary>
    public class Sorting
    {
        /// <summary>
        /// Сортировка методов выбора
        /// </summary>
        /// <param name="mas"> Массив чисел </param>
        /// <returns> Отсортированный массив </returns>
        /// <b>Example:</b>
        /// <code>
        /// Входные данные:
        /// int[] arr = { 234, 443, 582, 484, 326, 746, 245, 126, 453, 615 };
        /// 
        /// Применение:
        /// MainResult = Sorting.ViborSort(arr, Ops);
        /// 
        /// Результат:
        /// string MainResult = "126 234 245 326 443 453 484 582 615 746";
        /// </code>
        public static string ViborSort(int[] mas, Options Ops)
        {

            if (Ops.Top == 0 || Ops.Top >= mas.Length)
            {
                Ops.Top = mas.Length;
            } 

            for (int i = 0; i < Ops.Top; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                //обмен элементов
                int temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
            }
            return string.Join(" ", mas);       
        }

        /// <summary>
        /// Cортировка вставками 
        /// </summary>
        /// <param name="array"> Массив чисел </param>
        /// <returns> Отсортированный массив </returns>
        /// <b>Example:</b>
        /// <code>
        /// Входные данные:
        /// int[] arr = { 214, 443, 582, 484, 326, 746, 245, 126, 453, 615 };
        /// 
        /// Применение:
        ///  MainResult = Sorting.InsertionSort(arr);
        /// 
        /// Результат:
        /// string MainResult = "126 214 245 326 443 453 484 582 615 746";
        /// </code>
        public static string InsertionSort(int[] array)
        {

            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && result[j - 1] > array[i])
                {
                    result[j] = result[j - 1];
                    j--;
                }
                result[j] = array[i];
            }
            return string.Join(" ", result);
        }

        /// <summary>
        /// Cортировка по убыванию
        /// </summary>
        /// <param name="ara"> Массив чисел </param>
        /// <returns> Отсортированный массив </returns>
        /// <b>Example:</b>
        /// <code>
        /// Входные данные:
        /// int[] arr = { 234, 443, 582, 484, 326, 746, 245, 126, 453, 615 };
        /// 
        /// Применение:
        ///   MainResult = Sorting.SortDecreaseInt(arr);
        /// 
        /// Результат:
        /// string MainResult = "746 615 582 484 453 443 326 245 234 126";
        /// </code>
        public static string SortDecreaseInt(int[] ara)
        {
            string res = "";
            /*сортировка по убыванию, в начале нужно отсортировать по возрастанию, если этого
            не зделать метод Reverse отобразит значения массива с конца*/
            Array.Sort(ara);
            Array.Reverse(ara);
            //массив после сортировки
            foreach (var i in ara)
            {
                res += i + " ";
            }
            return string.Join(" ", ara);
        }

        /// <summary>
        /// Cортировка по возрастанию
        /// </summary>
        /// <param name="words"> Массив слов </param>
        /// <returns> Упорядоченная строка </returns>
        /// <b>Example:</b>
        /// <code>
        /// Входные данные:
        ///  string[] array = { "fhdy", "dhvdsd", "q", "rw", "qwe", "qwasda", "sdasdww" };
        /// 
        /// Применение:
        ///  MainResult = Sorting.SortAscending(arr);
        /// 
        /// Результат:
        /// string MainResult = "q rw qwe fhdy dhvdsd qwasda sdasdww ";
        /// </code>
        public static string SortAscending(string[] words)
        {
            string res = "";
            IEnumerable<string> query = words.OrderBy(num => num.Length);

            foreach (string str in query)
                res += str + " ";
            return res;
        }

        /// <summary>
        /// Cортировка по убыванию
        /// </summary>
        /// <param name="words"> Массив слов </param>
        /// <returns> Упорядоченная строка </returns>
        /// <b>Example:</b>
        /// <code>
        /// Входные данные:
        ///  string[] array = { "fhdy", "dhvdsd", "q", "rw", "qwe", "qwasda", "sdasdww" };
        /// 
        /// Применение:
        /// MainResult = Sorting.SortDecrease(arr);
        /// 
        /// Результат:
        ///  string res = "sdasdww dhvdsd qwasda fhdy qwe rw q ";
        /// </code>
        public static string SortDecrease(string[] words)
        {
            string res = "";
            //IEnumerable<string> query = from word in words
            //                            orderby word.Substring(0, 1) descending
            //                            select word;

            IEnumerable<string> query = words.OrderByDescending(num => num.Length);
            foreach (string str in query)
                res += str + " ";
            //Console.WriteLine(str);
            return res;
        }

        /// <summary>
        /// Дополнительная сортировка по возрастанию
        /// </summary>
        /// <param name="words"> Массив слов </param>
        /// <returns> Упорядоченная строка </returns>
        /// <b>Example:</b>
        /// <code>
        /// Входные данные:
        ///  string[] array = { "fhdy", "dhvdsd", "q", "rw", "qwe", "qwasda", "sdasdww" };
        /// 
        /// Применение:
        ///  MainResult = Sorting.SortDecreaseYet(arr);
        /// 
        /// Результат:
        ///  string MainResult = "q rw qwe fhdy dhvdsd qwasda sdasdww ";
        /// </code>
        public static string SortDecreaseYet(string[] words)
        {
            string res = "";
            IEnumerable<string> query = from word in words
                                        orderby word.Length, word.Substring(0, 1)
                                        select word;

            foreach (string str in query)
                res += str + " ";
            // Console.WriteLine(str);
            return res;
        }

        /// <summary>
        /// Естественная сортировка 
        /// </summary>
        /// <param name="list"> Лист строк</param>
        /// <returns> Упорядоченная строка </returns>
        /// <b>Example:</b>
        /// <code>
        /// Входные данные:
        ///  string[] array = { "a10b", "a11b", "a3b", "a30b", "a20b", "a21b", "a2b", "a1b", "a12b" };
        /// 
        /// Применение:
        ///   MainResult = Sorting.SortNatural(arr);
        /// 
        /// Результат:
        ///  string MainResult = "a1b a2b a3b a10b a11b a12b a20b a21b a30b ";
        /// </code>
        public static string SortNatural(List<String> list)
        {
            string res = "";
            //естественная сортировка
            //List<String> list = new List<String>();
         

            var ordered = list.OrderBy(x => PadNumbers(x));
            foreach (var items in ordered)
            {
                res += items + " ";
                //Console.WriteLine(items);
            }
            return res;
        }

        /// <summary>
        /// Вспомогательная функция для естественной сортировки
        /// </summary>
        /// <param name="input"> Строка </param>
        /// <returns>
        /// Возвращает строку, заполненную 4-мя нулями
        /// </returns>
        /// <b>Example:</b>
        /// <code>
        /// Входные данные:
        ///  string[] array = { "a10b", "a11b", "a3b", "a30b", "a20b", "a21b", "a2b", "a1b", "a12b" };
        /// 
        /// Применение:
        ///  return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(4, '0'));
        /// 
        /// Результат:
        ///  string MainResult = "a10000b a20000b a30000b a100000b a110000b a120000b a200000b a210000b a300000b ";
        /// </code>
        public static string PadNumbers(string input)
        {
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(4, '0'));
        }
    }


    /// <summary>
    /// Главный класс программы
    /// </summary>
    class Program
    {
        /// <summary>
        /// Главная функция
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string MainResult = "";

            ///Настройка командной строки
            var options = new CommandLineParserOptions
            {
                AppName = "Sort",
                EnableHelpOption = true,
                //PostfixOption = "h"
            };

            ///Парсинг переменных класса Options()
            var parser = new CommandLineParser<Options>(options);

            ///Команда вывода справки на экран
            parser.AddCommand<Options>()
            .Name("-h")
            .Required(false)
            .Description("Help")
            .OnExecuting((p) =>
            {
                Console.WriteLine("Usage: Lab_1 [options]\n" +
                                    "Options: \n" +
                                    "- pi | —pathIn Путь к начальному файлу\n" +
                                    "- po | —pathOut Путь к конечному файлу\n" +
                                    "- t | —type Тип строк\n" +
                                    "- a | —algo Алгоритмы: int: 0 - сортировка методов выбора, 1 - сортировка вставками, def - сортировка по убыванию. str: 0 - сортировка по возрастанию, 1 - сортировка по убыванию, def - дополнительная сортировка по возрастанию\n" +
                                    "- p | —top Коэф частичной сортировки\n" +
                                    "- h | —help Помощь\n");
                return;
            });

            var result = parser.Parse(args);

            ///Завершение программы в случае ошибки парсинга
            if (result.HasErrors)
            {
                Console.Error.WriteLine("Error parsing");
                return;
            }

            ///Создание переменной для использования распарсенных переменных
            var Ops = result.Result;

            ///Проверка пути для Считывания и сохранения
            var dirInfoIn = new DirectoryInfo(Ops.PathIn);
            var dirInfoOut = new DirectoryInfo(Ops.PathOut);


            ///В случае отсутствия директории, выводится ошибка
            if (!dirInfoIn.Exists && Ops.PathIn != "0" || Ops.PathIn == "0")
            {
                Console.WriteLine("Путь к файлу Input введен неверно");
                return;
            }

            ///В случае отсутствия директории, выводится ошибка
            if (!dirInfoOut.Exists && Ops.PathOut != "0")
            {
                Console.WriteLine("Путь к файлу Output введен неверно");
                return;
            }


            ///Объявление переменных пути входа и выхода
            StreamReader sr = new StreamReader($"{Ops.PathIn}\\input.txt");
            
            ///Выполнение программы для строки int
            if (Ops.Type == "int")
            {
                string lineInt;
                int[] arr;

                ///Отчистка файла
                if (Ops.PathOut != "0")
                {
                    File.WriteAllText($"{Ops.PathOut}\\none.txt", string.Empty);
                }
                while ((lineInt = sr.ReadLine()) != null)
                {
                    if (lineInt == "")
                    {
                        goto Skip;
                    }
                    arr = lineInt.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                    switch (Ops.Algo)
                    {
                        ///Алгоритмы сортировки
                        case (0): // сортировка методов выбора
                            MainResult = Sorting.ViborSort(arr, Ops);
                            break;
                        case (1): // сортировка вставками 
                            MainResult = Sorting.InsertionSort(arr);
                            break;

                        default: // сортировка по убыванию
                            MainResult = Sorting.SortDecreaseInt(arr);
                            break;
                    }
                    if (Ops.PathOut == "0")
                    {
                        Console.WriteLine(MainResult);
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter($"{Ops.PathOut}\\none.txt", true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(MainResult);
                        }
                    }
                Skip:;
                }
            }

            /// Выполнение программы для строки string
            else if (Ops.Type == "str")
            {
                string lineStr;
                string[] arr;

                ///Отчистка файла
                if (Ops.PathOut != "0")
                {
                    File.WriteAllText($"{Ops.PathOut}\\none.txt", string.Empty);
                }

                while ((lineStr = sr.ReadLine()) != null)
                {
                    if (lineStr == "")
                    {
                        goto Skip;
                    }
                    arr = lineStr.Split(' ').ToArray();
                    switch (Ops.Algo)
                    {
                        ///Алгоритмы сортировки
                        case (0):// сортировка по возрастанию
                            MainResult = Sorting.SortAscending(arr);
                            break;
                        case (1):// сортировка по убыванию
                            MainResult = Sorting.SortDecrease(arr);
                            break;
                        default:// дополнительная сортировка по возрастанию
                            MainResult = Sorting.SortDecreaseYet(arr);
                            break;
                    }
                    if (Ops.PathOut == "0")
                    {
                        Console.WriteLine(MainResult);
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter($"{Ops.PathOut}\\none.txt", true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(MainResult);
                        }
                    }
                Skip:;
                }
            }

            /// Выполнение программы для строки natural
            else if (Ops.Type == "nat")
            {
                string lineNat;
                List<string> arr;

                ///Отчистка файла
                if (Ops.PathOut != "0")
                {
                    File.WriteAllText($"{Ops.PathOut}\\none.txt", string.Empty);
                }
                while ((lineNat = sr.ReadLine()) != null)
                {
                    if (lineNat == "")
                    {
                        goto Skip;
                    }

                    arr = lineNat.Split(' ').ToList();
                    MainResult = Sorting.SortNatural(arr);

                    if (Ops.PathOut == "0")
                    {
                        Console.WriteLine(MainResult);
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter($"{Ops.PathOut}\\none.txt", true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(MainResult);
                        }
                    }
                Skip:;
                }
            }
            else
            {
                Console.WriteLine("Выбран неверный тип");
                return;
            }
        }
    }
}


