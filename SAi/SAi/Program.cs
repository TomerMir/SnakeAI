using System;
using System.Collections.Generic;

namespace SAi
{
    class Program
    {
        static List<NeuralNet> netList = new List<NeuralNet>();
        static Population population = new Population();
        public static int Generation = 1;
        static void Main(string[] args)
        {
            BuildNewNetList();
            while (true)
            {
                Console.WriteLine("Loading Generation " + Generation + "...");
                Game game = new Game(netList);
                netList = game.GenerationRun();
                netList = population.SortKillReproduce(netList);
                Food.listOfAll.Clear();
                Generation++;
            }
        }
        public static void BuildNewNetList()
        {
            int[] layers = new int[3] { 6, 16, 3 };
            for (int i = 0; i < 10000; i++)
            {
                NeuralNet net = new NeuralNet(layers);
                netList.Add(net);
            }
        }
    }
}
