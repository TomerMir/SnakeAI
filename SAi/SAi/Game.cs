using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SAi
{
    public class Game
    {
        Board _board = new Board();
        Food food = new Food();
        List<NeuralNet> netList;

        public Game(List<NeuralNet> netListInput)
        {
            netList = netListInput;
        }       
        
        public void Play(NeuralNet net)
        {
            int tmpFood = 1;
            Snake snake = new Snake();
            int genNum1 = food.Generate(0);
            if (genNum1 == 0)
            {
                tmpFood++;
            }
            else
            {
                tmpFood += genNum1 + 1;
            }
            while (snake.IsLoose() == false)
            {
                snake.addFirst();
                snake.removeLast();

                float[] inputArr = new float[6] { snake.IsFoodForward(), snake.IsFoodRight(), snake.IsFoodLeft(), snake.IsClearForward(), snake.IsClearRight(), snake.IsClearLeft() };
                string Direction = net.GetDirection(inputArr).ToString();
                
                if (Direction == "Left")
                {
                    snake.MoveLeft();
                }
                else if (Direction == "Right")
                {
                    snake.MoveRight();
                }
                else
                {
                    snake.KeepForward();
                }
                snake.hunger--;
                if(Board.board[snake.nextPlace.X, snake.nextPlace.Y].whatsIn == Place.WhatsInEnum.Food)
                {
                    Place tmpPlace = new Place();
                    tmpPlace.X = snake.snake.Last.Value.X;
                    tmpPlace.Y = snake.snake.Last.Value.Y;
                    tmpPlace.whatsIn = Place.WhatsInEnum.Snake;
                    snake.snake.AddLast(tmpPlace);
                    snake.score++;
                    snake.hunger += 50;
                    int genNum = food.Generate(tmpFood);
                    if(genNum == 0)
                    {
                        tmpFood++;
                    }
                    else
                    {
                        tmpFood += genNum + 1;
                    }
                }             
            }            
            net.Score = snake.score;            
        }

        public List<NeuralNet> GenerationRun()
        {
            _board.ClearAndCreate();
            food.FirstGenerate();
            foreach (NeuralNet net in netList)
            {
                Play(net);
                _board.ClearAndCreate();
            }
            return netList;
        }

        public void PlayBest(NeuralNet net)
        {
            int tmpFood = 1;
            Snake snake = new Snake();
            int genNum1 = food.Generate(0);
            if (genNum1 == 0)
            {
                tmpFood++;
            }
            else
            {
                tmpFood += genNum1 + 1;
            }
            while (snake.IsLoose() == false)
            {
                snake.addFirst();
                snake.removeLast();

                float[] inputArr = new float[6] { snake.IsFoodForward(), snake.IsFoodRight(), snake.IsFoodLeft(), snake.IsClearForward(), snake.IsClearRight(), snake.IsClearLeft() };
                string Direction = net.GetDirection(inputArr).ToString();

                if (Direction == "Left")
                {
                    snake.MoveLeft();
                }
                else if (Direction == "Right")
                {
                    snake.MoveRight();
                }
                else
                {
                    snake.KeepForward();
                }
                snake.hunger--;
                if (Board.board[snake.nextPlace.X, snake.nextPlace.Y].whatsIn == Place.WhatsInEnum.Food)
                {
                    Place tmpPlace = new Place();
                    tmpPlace.X = snake.snake.Last.Value.X;
                    tmpPlace.Y = snake.snake.Last.Value.Y;
                    tmpPlace.whatsIn = Place.WhatsInEnum.Snake;
                    snake.snake.AddLast(tmpPlace);
                    snake.score++;
                    snake.hunger += 50;
                    int genNum = food.Generate(tmpFood);
                    if (genNum == 0)
                    {
                        tmpFood++;
                    }
                    else
                    {
                        tmpFood += genNum + 1;
                    }
                }
                Console.Clear();
                _board.Print();
                Thread.Sleep(10);
            }          
        }
    }
}
