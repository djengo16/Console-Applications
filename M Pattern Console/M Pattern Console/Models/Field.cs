using M_Pattern_Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace M_Pattern_Console
{
    public class Field : IModifiable
    {
        private int rows;
        private int cols;
        private char[,] field;
        private int letterWidth;

        public Field(int letterWidth)
        {
            this.rows = letterWidth + 1;
            this.cols = letterWidth * 10;
            this.letterWidth = letterWidth;
            this.field = new char[rows, cols];
            
        }


        public void GenerateInitialField()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = '-';
                }
            }
        }

        public void Print()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        //Adding four times /\ so we can get MM
        public void Modify()
        {

            AddPart(0, 0);
            AddPart( letterWidth * 2, letterWidth * 2);
            AddPart(letterWidth * 5, letterWidth * 5);
            AddPart(letterWidth * 7, letterWidth * 7);
        }

        // We are making the half of M like /\ 
        private  void AddPart(int startingColFirstPart, int startingColSecondPart)
        {
           

            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = startingColFirstPart;
                    j < letterWidth + startingColFirstPart;
                    j++)
                {
                    this.field[i, j] = '*';
                }
                startingColFirstPart += 1;
            }

          
            int moveCol = letterWidth;
            int moveCol2 = startingColSecondPart;
            for (int i = 0; i < rows; i++)
            {
                for (int j = letterWidth + startingColSecondPart;
                    j < moveCol + letterWidth + moveCol2;
                    j++)
                {
                    field[i, j] = '*';
                }
                startingColSecondPart++;
                moveCol++;
            }


        }

    }
}
