using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = false;
            switch (a)
            {
                case true:
                    Console.WriteLine(a);
                    break;
                case false:
                    Console.WriteLine(a);
                    break;
                default:
                    Console.WriteLine("Default");
                    break;

            }
        }
    }
}
