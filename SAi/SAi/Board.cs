using System;
using System.Collections.Generic;
using System.Text;

namespace SAi
{
    public class Board
    {
        public static Place[,] board = new Place[21, 21]; 
        
        public Board()
        {
            for (int i = 0; i < 21; i++)
            {
                for (int k = 0; k < 21; k++)
                {
                    board[i, k] = new Place();
                }
            }
        }
            

        public void ClearAndCreate()
        {
            for(int i = 0; i < 21; i++)
            {
                for (int k = 0; k < 21; k++)
                {
                    board[i, k].whatsIn = Place.WhatsInEnum.Nothing;
                    board[i, k].X = i;
                    board[i, k].Y = k;

                }
            }

            for(int i = 0; i < 21; i++)
            {
                board[i, 20].whatsIn = Place.WhatsInEnum.Boarder;
                board[20, i].whatsIn = Place.WhatsInEnum.Boarder;
                board[0, i].whatsIn = Place.WhatsInEnum.Boarder;
                board[i, 0].whatsIn = Place.WhatsInEnum.Boarder;
            }
        }
        public void Print()
        {
            for(int i = 20; i >= 0; i--)
            {
                for(int k = 20; k >= 0; k--)
                {
                    if(board[k,i].whatsIn == Place.WhatsInEnum.Nothing)
                    {
                        Console.Write("  ");
                    }
                    if (board[k, i].whatsIn == Place.WhatsInEnum.Snake)
                    {
                        Console.Write(" *");
                    }
                    if (board[k, i].whatsIn == Place.WhatsInEnum.Boarder)
                    {
                        Console.Write(" #");
                    }
                    if (board[k, i].whatsIn == Place.WhatsInEnum.Food)
                    {
                        Console.Write(" @");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
