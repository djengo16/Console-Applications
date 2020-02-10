using System;

namespace M_Pattern_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please choose the letter width: ");
            int letterWidth = int.Parse(Console.ReadLine());

            Field field = new Field(letterWidth);
            field.GenerateInitialField();
            field.Modify();
            field.Print();
        }
    }
}
