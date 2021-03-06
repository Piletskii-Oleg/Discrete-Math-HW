using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Move_To_Front
{
    class Algorithm
    {
        private string CreateAlphabet(string str)
        {
            StringBuilder alphabet = new StringBuilder("");
            alphabet.Append(str[0]);
            bool flag;
            for (int i = 1; i < str.Length; i++)
            {
                flag = true;
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (str[i] == alphabet[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    alphabet.Append(str[i]);
                }
            }
            return alphabet.ToString();
        }

        private int[] DirectConversion(string str)
        {
            int[] resultArray = new int[str.Length];
            StringBuilder helper = new StringBuilder("");
            int position;

            for (int i = 0; i < str.Length; i++)
            {
                position = 0;

                for (int j = 0; j < helper.Length; j++)
                {
                    if (str[i] == helper[j])
                    {
                        position = j + 1;
                        resultArray[i] = position;

                        helper.Remove(j, 1);
                        helper.Insert(0, str[i]);

                        break;
                    }
                }

                if (position == 0)
                {
                    helper.Insert(0, str[i]);
                    resultArray[i] = 0;
                }
            }
            return resultArray;
        }

        private string ReverseConvertion(int[] array, string str)
        {
            StringBuilder resultString = new StringBuilder();
            StringBuilder helper = new StringBuilder();
            int position = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    helper.Insert(0, str[position]);
                    resultString.Append(str[position]);
                    position++;
                }
                else
                {
                    resultString.Append(helper[array[i] - 1]);
                    helper.Insert(0, helper[array[i] - 1]);
                    helper.Remove(array[i], 1);
                }

            }

            return resultString.ToString();
        }

        public void PrintTransformation(string toConvert)
        {
            int[] array = new int[toConvert.Length];
            array = DirectConversion(toConvert);

            Console.Write("Численный результат: ");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");

            string alphabet = CreateAlphabet(toConvert);
            Console.WriteLine("\nСловарь: " + alphabet);

            string reverse = ReverseConvertion(array, alphabet);
            Console.WriteLine("Обратно: " + reverse);
            Console.WriteLine("Совпадение строк: " + (reverse == toConvert));
        }
    }
}
