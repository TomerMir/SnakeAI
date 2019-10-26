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
            int[] tmp = new int[4] { 6,8,8,3};
            NeuralNet tmpNet = new NeuralNet(tmp);           

            halfNet = netList.OrderByDescending(x => x.Score).Take(netList.Count / 3).ToList(); //sort 

            if (halfNet.First().Score > BestScore)
            {
                BestScore = halfNet.First().Score;
                Console.WriteLine("Best Score: " + BestScore);
                halfNet.First().SaveWeights();
            }
            if (halfNet.First().Score >= 50)
            {
                Console.WriteLine(Program.Generation);
                Console.ReadKey();
                Game game = new Game(halfNet);
                _board.ClearAndCreate();
                game.PlayBest(halfNet.First());

            }

            /*Game game = new Game(halfNet);
            _board.ClearAndCreate();
            game.PlayBest(halfNet.First());*/


            //Console.WriteLine("Score: " + halfNet.First().Score + "\n\n\n");


            //Console.WriteLine("Weight: " + halfNet[0].weights["1,0.0"]);

            /*foreach (NeuralNet net in halfNet) //reproduce
            {
                for (int i = 0; i < 4; i++)
                {
                    tmpNet.weights = net.weights;
                    tmpNet.ChangeWeight();
                    finelList.Add(tmpNet);
                }
                finelList.Add(net);                                   
            }*/

            for (int i = 0; i < halfNet.Count; i+=2)
            {
                tmpNet.weights = halfNet[i].CrossWith(halfNet[i + 1]).weights;
                finelList.Add(tmpNet);
                finelList.Add(halfNet[i]);
                finelList.Add(halfNet[i + 1]);
            }
            for (int i = 0; i < (netList.Count/2); i++)
            {
                NeuralNet anotherNet = new NeuralNet(tmp);
                finelList.Add(anotherNet);
            }
            return finelList;
        }


    }
}
