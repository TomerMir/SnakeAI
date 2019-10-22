using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SAi
{
    public class NeuralNet
    {
        public int Score = 0;
        int[] layers;
        float[][] NeuralNetwork = new float[3][];
        Random random = new Random();
        public enum _Direction {Right, Left, Forward};
        public Dictionary<string, float> weights = new Dictionary<string, float>();
         public NeuralNet(int[] _Layers) //מקבל מערך של מספרים שאומר לו כמה נוירונים יהיו בכל שכבה
        {
            layers = _Layers;
            for (int i = 0; i < layers.Length; i++)
            {
                float[] tmpArr = new float[layers[i]];                 
                NeuralNetwork[i] = tmpArr;
            }
            buildWeights();
        }
        
        public void feedNet(float[] vlaue)//מזין לרשת נוירונים את השכבה הראשונה של הקלט
        {
            for(int i = 0; i < NeuralNetwork[0].Length; i++)
            {
                NeuralNetwork[0][i] = vlaue[i];
            }
        }

        public void Clear()
        {
            Score = 0;
        }

        public void addWeights(int layer)//מוסיף משקל לכל חיבור בין שני נוירונים לפי שכבה שהפונקציה מקבלת
        {           
            for(int i = 0; i < NeuralNetwork[layer].Length; i++)
            {
                for (int k = 0; k < NeuralNetwork[layer - 1].Length; k++)
                {
                    float value = (float)((random.NextDouble() * 2) - 1);
                    string key = layer.ToString() + "," + i.ToString() +"." + k.ToString();
                    weights.Add(key, value);
                }
            }
        }

        public void calculateValueForLayer(int layer)//מחשב את הערך לכל נוירון לפי שכבה שהפונקציה מקבלת
        {            
            for(int i = 0; i < NeuralNetwork[layer].Length; i++)
            {
                float value = 0;
                for (int k = 0; k < NeuralNetwork[layer - 1].Length; k++)
                {
                    string key = layer.ToString() + "," + i.ToString() + "." + k.ToString();
                    float weightFromDictionery = weights[key];
                    value += NeuralNetwork[layer - 1][k] * weightFromDictionery;
                }
                NeuralNetwork[layer][i] = (float)(1.0 / (1.0 + Math.Pow(Math.E, -value))); ;
            }
        }

        public void buildWeights()//בונה את הרשת נוירונים
        {
            for (int i = 1; i < NeuralNetwork.Length; i++)
            {
                addWeights(i);
            }
        }
        public void ChangeWeight()
        {
            List<string> keyList = new List<string>(weights.Keys);
            for (int i = 0; i < keyList.Count; i++)
            {
                string tmp = keyList[i];
                int randomIndex = random.Next(i, keyList.Count);
                keyList[i] = keyList[randomIndex];
                keyList[randomIndex] = tmp;
            }
            List<string> randomKeys = keyList.Take(keyList.Count / 50).ToList();
           
            List<float> randomNums = new List<float>();
            foreach(string key in randomKeys)
            {
                randomNums.Add(weights[key]);
            }
            for(int i = 0; i < randomNums.Count; i++)
            {
                int rand = random.Next(1, 2);
                if(rand == 1)
                {
                    //randomNums[i] = randomNums[i] + (randomNums[i] / (Program.Generation * 3));
                    //randomNums[i] = randomNums[i] + (randomNums[i] / (float)(Math.Pow(2, (0.5 * Program.Generation))));
                    //randomNums[i] = randomNums[i] + (randomNums[i] / (float)(1.5 * Program.Generation));
                    randomNums[i] = randomNums[i] + (randomNums[i] / 3);
                }
                else
                {
                    //randomNums[i] = randomNums[i] - (randomNums[i] / (Program.Generation * 3));
                    //randomNums[i] = randomNums[i] - (randomNums[i] / (float)(Math.Pow(2, (0.5 * Program.Generation))));
                    //randomNums[i] = randomNums[i] - (randomNums[i] / (float)(1.5 * Program.Generation));
                    randomNums[i] = randomNums[i] - (randomNums[i] / 3);
                }
              
            }
            int index = 0;
            foreach (string key in randomKeys)
            {
                weights[key] = randomNums[index];
                index++;
            }
        }
        public _Direction GetDirection(float[] input)//בוחר לאיזה כיוון צריך הנחש לפנות
        {
            feedNet(input);
            for (int i = 1; i < NeuralNetwork.Length; i++)
            {
                calculateValueForLayer(i);
            }
            int maxIndex = 0;
            float maxValue = 0;
            int k = 0;
            foreach (float num in NeuralNetwork[NeuralNetwork.Length-1])
            {
               if(num > maxValue)
                {
                    maxIndex = k;
                    maxValue = num;
                }
                k++;
            }
            return (_Direction)maxIndex;            
        }
        
    }
}
