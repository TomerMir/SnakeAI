using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAi
{
    public class Population
    {
        Board _board = new Board();
        Food food = new Food();
        static int BestScore = 0;
        public List<NeuralNet> SortKillReproduce(List<NeuralNet> netList)
        {
            List<NeuralNet> halfNet = new List<NeuralNet>();         
            List<NeuralNet> finelList = new List<NeuralNet>();
            NeuralNet tmpNet = new NeuralNet(Program.layers);           

            halfNet = netList.OrderByDescending(x => x.Score).Take(netList.Count / 3).ToList(); //sort 
            if (halfNet.First().Score > BestScore)
            {
                BestScore = halfNet.First().Score;
                Console.WriteLine("Best Score: " + BestScore);
                halfNet.First().SaveWeights();
                if (Program.seeGame)
                {
                    Game game = new Game(halfNet);
                    _board.ClearAndCreate();
                    game.PlayBest(halfNet.First());
                    Console.WriteLine(halfNet.First().Score);
                }
            }  
            
            for (int i = 0; i < halfNet.Count; i+=2)
            {
                tmpNet.weights = halfNet[i].CrossWith(halfNet[i + 1]).weights;
                finelList.Add(tmpNet);
                finelList.Add(halfNet[i]);
                finelList.Add(halfNet[i + 1]);
            }
            for (int i = 0; i < (netList.Count/2); i++)
            {
                NeuralNet anotherNet = new NeuralNet(Program.layers);
                finelList.Add(anotherNet);
            }
            return finelList;
        }


    }
}
