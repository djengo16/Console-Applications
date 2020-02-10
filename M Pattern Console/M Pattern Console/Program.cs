using System;

namespace M_Pattern_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please choose the letter width: ");
            int letterWidth = int.Parse(Console.ReadLine());
            while (true) {
                if (!(letterWidth > 2 && letterWidth < 10 - 000))
                {
                    Console.WriteLine("Number is too small or too large!\nPrealse Try again!");
                    letterWidth = int.Parse(Console.ReadLine());
                }
                else if (letterWidth % 2 == 0)
                {
                    Console.WriteLine("Number should be odd!\nPlease Try again!");
                    letterWidth = int.Parse(Console.ReadLine());
                }
                else break;
                
            }
            Field field = new Field(letterWidth);
            field.GenerateInitialField();
            field.Modify();
            field.Print();
        }
    }
}
