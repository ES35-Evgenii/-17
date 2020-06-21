using System;
using System.Collections.Generic;

namespace Задание_17
{
    class Program
    {
        static List<decimal> list = new List<decimal>();

        static void Main(string[] args)
        {
            //тестовая строка
            string str = "Создать 0 метод, принимающий 1,00  2,01  3.03  4.04 5,05 6,06 7.0009 8.08 9,09 10.1" +
                " 11.11 12,12 13,13 14,14 15.15 16,16 17.17 18.18 19.19 20.20 21.21 22,22 23.23 24,24 25,25 26.26" +
                " 27.27 28,28 29.29 30.30 101.99 102.2 103.03 104.04 105.5 106.6 107.7 108.8 109.9 110.10 111.11 " +
                "112.12 113.13 114.14 115.15 116 117 118 119 120 121 122 123 124 125 1001.1 1002.02 1003 1004 1005 " +
                "1006 1007 1008 1009 1010 1011 1012 1013 1014 1015 1016 1017 1018 1019 1020 10011 1113 11115 " +
                "строку 10.23 возвращает это 111 число с 00.00  101 корректным 03.45 падежом 3,03  учитывать 11 " +
                "). Метод 25 слова рубль";
            Extract(str);               //запись в list сочетаний возможных для денежных единиц
            ShowCorrectPrice(list);     //корректный вывод сумм из List в консоль
            
            Console.ReadLine();
        }

        private static void ShowCorrectPrice(List<decimal> list)
        {
            int rub;        //числовая переменная рубли
            int kop;        //числовая переменная копейки

            foreach (decimal n in list)
            {
                if (n != Convert.ToInt32(n) ) //если дробное
                {
                    rub = Convert.ToInt32(Math.Truncate(n));
                    kop = Convert.ToInt32((n * 100) % 100);
                }
                else
                {
                    rub = Convert.ToInt32(n);
                    kop = 00;
                }
                Console.WriteLine(Ruble(rub) + ", " + Kopeck(kop) + ".");
            }
        }

        private static string Kopeck(int kop)   //берет int копеек и возвращает корректную строку
        {
            string str;
            if ((kop == 1 || kop % 10 == 1) && kop != 11)
            {
                str = "копейка";
            }
            else if ((kop % 10 == 2 || kop % 10 == 3 || kop % 10 == 4) &&
                kop != 12 && kop != 13 && kop != 14)
            {
                str = "копейки";
            }
            else
            {
                str = "копеек";
            }
            return kop + " " + str;
        }

        private static string Ruble(int rub)    //берет int рублей и возвращает корректную строку
        {
            string str;
            if ((rub == 1 || rub % 10 == 1) && rub != 11 && rub % 100 != 11)
            {
                str = "рубль";
            }
            else if ((rub % 10 == 2 || rub % 10 == 3 || rub % 10 == 4) &&
                rub != 12 && rub % 100 != 12 &&
                rub != 13 && rub % 100 != 13 &&
                rub != 14 && rub % 100 != 14)
            {
                str = "рубля";
            }
            else
            {
                str = "рублей";
            }
            return rub + " " + str;
        }

        private static List<decimal> Extract(string str) //берет строку, возвращает List с числами
        {
            string[] s = str.Split();
            foreach (string n in s)
            {
                if (decimal.TryParse(n.Replace(".", ","), out _)) //достаем числа из строки и кидаем в list
                {
                    list.Add(Convert.ToDecimal(n.Replace(".", ",")));
                }
            }
            return list;
        }
    }
}
