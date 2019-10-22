using System;
using System.Collections.Generic;
using System.Text;

namespace SAi
{
    public class Snake
    {
        public int score = 0;
        public Place nextPlace = new Place();
        public LinkedList<Place> snake = new LinkedList<Place>();
        public int hunger;
        public enum DirectionEnum { Up, Down, Left, Right };
        public DirectionEnum Direction;
        public Snake()
        {
            Place firstCoor = new Place { whatsIn = Place.WhatsInEnum.Snake, X = 10, Y = 18 };
            snake.AddFirst(firstCoor);
            Board.board[10, 18].whatsIn = Place.WhatsInEnum.Snake;
            Place secondCoor = new Place { whatsIn = Place.WhatsInEnum.Snake, X = 10, Y = 19 };
            snake.AddLast(secondCoor);
            Board.board[10, 19].whatsIn = Place.WhatsInEnum.Snake;
            Direction = DirectionEnum.Down;
            hunger = 100;
            nextPlace.whatsIn = Place.WhatsInEnum.Nothing;
            nextPlace.X = 10;
            nextPlace.Y = 17;
        }
        public bool IsLoose()
        {
            if (Board.board[nextPlace.X,nextPlace.Y].whatsIn == Place.WhatsInEnum.Boarder || Board.board[nextPlace.X, nextPlace.Y].whatsIn == Place.WhatsInEnum.Snake || hunger == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int IsFoodRight()
        {
            if (Direction == DirectionEnum.Down)
            {
                for(int x = 0; x < snake.First.Value.X; x++)
                {
                    if(Board.board[x, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else if (Direction == DirectionEnum.Up)
            {
                for (int x = snake.First.Value.X; x < 21 ; x++)
                {
                    if (Board.board[x, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else if (Direction == DirectionEnum.Left)
            {
                for (int y = snake.First.Value.Y; y < 21; y++)
                {
                    if (Board.board[snake.First.Value.X, y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else
            {
                for (int y = 0; y < snake.First.Value.Y; y++)
                {
                    if (Board.board[snake.First.Value.X, y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
        }

        public int IsFoodLeft()
        {
            if (Direction == DirectionEnum.Down)
            {
                for (int x = snake.First.Value.X; x < 21; x++)
                {
                    if (Board.board[x, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else if (Direction == DirectionEnum.Up)
            {
                for (int x = 0; x < snake.First.Value.X; x++)
                {
                    if (Board.board[x, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else if (Direction == DirectionEnum.Left)
            {
                for (int y = 0; y < snake.First.Value.Y; y++)
                {
                    if (Board.board[snake.First.Value.X, y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else
            {
                for (int y = snake.First.Value.Y; y < 21; y++)
                {
                    if (Board.board[snake.First.Value.X, y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
        }

        public int IsFoodForward()
        {
            if (Direction == DirectionEnum.Down)
            {
                for (int y = 0; y < snake.First.Value.Y; y++)
                {
                    if (Board.board[snake.First.Value.X, y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else if (Direction == DirectionEnum.Up)
            {
                for (int y = snake.First.Value.Y; y < 21; y++)
                {
                    if (Board.board[snake.First.Value.X, y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else if (Direction == DirectionEnum.Left)
            {
                for (int x = 0; x < snake.First.Value.X; x++)
                {
                    if (Board.board[x, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else
            {
                for (int x = snake.First.Value.X; x < 21; x++)
                {
                    if (Board.board[x, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Food)
                    {
                        return 1;
                    }
                }
                return 0;
            }
        }

        public int IsClearForward()
        {
            if (Direction == DirectionEnum.Down)
            {
                if(Board.board[snake.First.Value.X, snake.First.Value.Y-1].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X, snake.First.Value.Y-1].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (Direction == DirectionEnum.Up)
            {
                if (Board.board[snake.First.Value.X, snake.First.Value.Y + 1].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X, snake.First.Value.Y + 1].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (Direction == DirectionEnum.Left)
            {
                if (Board.board[snake.First.Value.X - 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X - 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (Board.board[snake.First.Value.X - 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X - 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public int IsClearLeft()
        {
            if (Direction == DirectionEnum.Down)
            {
                if (Board.board[snake.First.Value.X + 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X + 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (Direction == DirectionEnum.Up)
            {
                if (Board.board[snake.First.Value.X - 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X - 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (Direction == DirectionEnum.Left)
            {
                if (Board.board[snake.First.Value.X, snake.First.Value.Y-1].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X, snake.First.Value.Y - 1].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (Board.board[snake.First.Value.X, snake.First.Value.Y + 1].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X, snake.First.Value.Y + 1].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public int IsClearRight()
        {
            if (Direction == DirectionEnum.Down)
            {
                if (Board.board[snake.First.Value.X - 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X - 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (Direction == DirectionEnum.Up)
            {
                if (Board.board[snake.First.Value.X + 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X + 1, snake.First.Value.Y].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (Direction == DirectionEnum.Left)
            {
                if (Board.board[snake.First.Value.X, snake.First.Value.Y + 1].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X, snake.First.Value.Y + 1].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (Board.board[snake.First.Value.X, snake.First.Value.Y - 1].whatsIn == Place.WhatsInEnum.Boarder || Board.board[snake.First.Value.X, snake.First.Value.Y - 1].whatsIn == Place.WhatsInEnum.Snake)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
                     
        public void removeLast()
        {
            Board.board[snake.Last.Value.X, snake.Last.Value.Y].whatsIn = Place.WhatsInEnum.Nothing;
            snake.RemoveLast();
        }
        public void addFirst()
        {
            Board.board[nextPlace.X, nextPlace.Y].whatsIn = Place.WhatsInEnum.Snake;
            Place tmpPlace = new Place();
            tmpPlace.X = nextPlace.X;
            tmpPlace.Y = nextPlace.Y;
            tmpPlace.whatsIn = Place.WhatsInEnum.Snake;
            snake.AddFirst(tmpPlace);
        }
        public void MoveRight()
        {
            if(Direction == DirectionEnum.Down)
            {
                nextPlace.X--;
                Direction = DirectionEnum.Left;
            }
            else if (Direction == DirectionEnum.Up)
            {
                nextPlace.X++;
                Direction = DirectionEnum.Right;
            }
            else if (Direction == DirectionEnum.Left)
            {
                nextPlace.Y++;
                Direction = DirectionEnum.Up;
            }
            else if (Direction == DirectionEnum.Right)
            {
                nextPlace.Y--;
                Direction = DirectionEnum.Down;
            }
        }
        public void MoveLeft()
        {
            if(Direction == DirectionEnum.Down)
            {
                nextPlace.X++;
                Direction = DirectionEnum.Right;
            }
            else if(Direction == DirectionEnum.Up)
            {
                nextPlace.X--;
                Direction = DirectionEnum.Left;
            }
            else if(Direction == DirectionEnum.Left)
            {
                nextPlace.Y--;
                Direction = DirectionEnum.Down;
            }
            else if(Direction == DirectionEnum.Right)
            {
                nextPlace.Y++;
                Direction = DirectionEnum.Up;
            }
        }
        public void KeepForward()
        {
            if (Direction == DirectionEnum.Down)
            {
                nextPlace.Y--;
            }
            else if(Direction == DirectionEnum.Up)
            {
                nextPlace.Y++;
            }
            else if(Direction == DirectionEnum.Left)
            {
                nextPlace.X--;
            }
            else if(Direction == DirectionEnum.Right)
            {
                nextPlace.X++;
            }
        }        
    }
}
