using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SAi
{
    class Program
    {
        static List<NeuralNet> netList = new List<NeuralNet>();
        static Population population = new Population();
        public static int Generation = 1;
        public static int numOfSnakesInGeneration = 12;
        public const string root = "c:\\Users\\Public\\SnakeAI\\";
        public static bool seeGame = false;
        static void Main(string[] args)
        {
            BuildNewNetList();
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            Console.WriteLine("What do you want to do? \n 1.Run The AI \n 2.Run the AI from the last record \n\n");
            while (true)
            {               
                string input = Console.ReadLine();
                if (input == "1" || input == "2")
                {
                    while (true)
                    {
                        Console.WriteLine("Do you want to see the snake's game? \n 1.Yes \n 2.No");
                        string see = Console.ReadLine();

                        if (see == "1" || see == "2")
                        {
                            if (see == "1")
                            {
                                seeGame = true;
                            }
                            if (input == "1")
                            {
                                Console.Clear();
                                RunAll();
                            }
                            if (input == "2")
                            {
                                int numberOfFiles = Directory.GetFiles(root, "SnakeId_*.txt").Length;
                                if (numberOfFiles < numOfSnakesInGeneration)
                                {
                                    Console.WriteLine("You need to have at least " + numOfSnakesInGeneration + " snakes in your list to run this, Try running the AI more. Press 1 to run the AI.");
                                    continue;
                                }
                                else
                                {
                                    AppendToNet();
                                    RunAll();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Your answer shoud be only 1 or 2, try again");
                            continue;
                        }
                    }                                        
                }
                else
                {
                    Console.WriteLine("Your answer shoud be only 1 or 2, try again");
                    continue;
                }
            }                       
        }
        public static void RunAll()
        {
            while (true)
            {
                //Console.WriteLine("Loading Generation " + Generation + "...");
                Game game = new Game(netList);
                netList = game.GenerationRun();
                netList = population.SortKillReproduce(netList);
                Food.listOfAll.Clear();
                Generation++;
            }
        }
        public static NeuralNet ReadFromFile(string path, NeuralNet net)
        {
            string[] allWeightss = File.ReadAllLines(path);
            List<string> keyList = new List<string>(net.weights.Keys);
            int i = 0;
            foreach (var key in keyList)
            {
                net.weights[key] = float.Parse(allWeightss[i]);
                i++;
            }
            return net;
        }

        public static void AppendToNet()
        {
            List<FileName> listOfNames = new List<FileName>();
            List<FileName> listAfterSort = new List<FileName>();
            Regex fileName = new Regex("SnakeID_(.*)_Score_(.*).txt");
            string[] nameOfFiles = Directory.GetFiles(root, "SnakeId_*.txt");
            foreach (var name in nameOfFiles)
            {
                if(fileName.IsMatch(name))
                {
                    FileName tmpName = new FileName();
                    tmpName.SnakeId = fileName.Match(name).Groups[1].Value;
                    tmpName.Score = int.Parse(fileName.Match(name).Groups[2].Value);
                    listOfNames.Add(tmpName);
                }
            }
            listAfterSort = listOfNames.OrderByDescending(x => x.Score).Take(numOfSnakesInGeneration).ToList();
            string path;
            for (int i = 0; i < numOfSnakesInGeneration; i++)
            {
                path = root + "SnakeID_" + listAfterSort[i].SnakeId + "_Score_" + listAfterSort[i].Score + ".txt";
                netList[i] = ReadFromFile(path, netList[i]);
            }
        }

        public static void BuildNewNetList()
        {
            int[] layers = new int[4] { 6,8,8,3 };
            for (int i = 0; i < numOfSnakesInGeneration; i++)
            {
                NeuralNet net = new NeuralNet(layers);
                netList.Add(net);
            }
        }
    }
}
