using System;

namespace Move_To_Front
{
    class Program
    {
        static void Main()
        {
            Algorithm MTF = new Algorithm();

            string task = "baccaaabaaacccbbbbb";
            MTF.PrintTransformation(task);
            Console.ReadKey();
        }
    }
}

