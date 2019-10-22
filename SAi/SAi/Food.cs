using System;
using System.Collections.Generic;
using System.Text;

namespace SAi
{
    public class Food
    {
        Random random = new Random();
        public static List<Place> listOfAll = new List<Place>();
        public static int X;
        public static int Y;

        public int Generate(int num)
        {
            if (Board.board[listOfAll[num].X, listOfAll[num].Y].whatsIn == Place.WhatsInEnum.Nothing)
            {
                Board.board[listOfAll[num].X, listOfAll[num].Y].whatsIn = Place.WhatsInEnum.Food;
                X = listOfAll[num].X;
                Y = listOfAll[num].Y;
                return 0;
            }
            else
            {
                int retNum = 0;
                while(Board.board[listOfAll[num].X, listOfAll[num].Y].whatsIn != Place.WhatsInEnum.Nothing)
                {
                    retNum++;
                    num++;
                    if(Board.board[listOfAll[num].X, listOfAll[num].Y].whatsIn == Place.WhatsInEnum.Nothing)
                    {
                        Board.board[listOfAll[num].X, listOfAll[num].Y].whatsIn = Place.WhatsInEnum.Food;
                        X = listOfAll[num].X;
                        Y = listOfAll[num].Y;
                        return retNum;
                    }
                }
            }
            return 0;
        }

        public void FirstGenerate()
        {
            List<Place> list = new List<Place>();
            foreach (Place place in Board.board)
            {
                if (place.whatsIn == Place.WhatsInEnum.Nothing)
                {
                    list.Add(place);
                }
            }
            
            while(listOfAll.Count < 100)
            {
                int rand = random.Next(0, list.Count);
                if (!listOfAll.Contains(list[rand]))
                {
                    listOfAll.Add(list[rand]);
                }
            }
        }
    }
}
