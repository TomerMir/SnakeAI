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
        public List<NeuralNet> SortKillReproduce(List<NeuralNet> netList)
        {
            List<NeuralNet> halfNet = new List<NeuralNet>();         
            List<NeuralNet> finelList = new List<NeuralNet>();
            int[] tmp = new int[3] { 6,16,3};
            NeuralNet tmpNet = new NeuralNet(tmp);

            halfNet = netList.OrderByDescending(x => x.Score).Take(netList.Count / 4).ToList(); //sort           
            Game game = new Game(halfNet);
            _board.ClearAndCreate();
            game.PlayBest(halfNet.First());
            Console.WriteLine("Score: " + halfNet.First().Score + "\n\n\n");

            foreach (NeuralNet net in halfNet) //reproduce
            {
                for (int i = 0; i < 3; i++)
                {
                    tmpNet.weights = net.weights;
                    tmpNet.ChangeWeight();
                    finelList.Add(tmpNet);
                }
                finelList.Add(net);                                   
            }
            return finelList;
        }


    }
}
