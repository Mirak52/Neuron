using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neuron
{
    class Program
    {
        const int Synapse = 5;
        public static List<int> synapse = new List<int>();
        public  static List<int> response = new List<int>();
        public static bool start = true;
        static void Main(string[] args)
        {
            if (start)
            {
                for (int i = 0; i < Synapse; i++)
                {
                        synapse.Add(i);
                        response.Add(i);
                        synapse[i]=1;
                }
                start = false;
            }
            for (int i=0; i < Synapse; i++)
            {
                GetUserInput(i);
            }
            GetIncreasedWeight(response);
            Console.ForegroundColor = ConsoleColor.Cyan;
            CreatedSynapseLine(synapse);
            Console.WriteLine("Threshold: "+GetThreshold(synapse));
            Console.WriteLine("sum: "+GetSum(synapse,response));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            CompareWeightThreshold(GetThreshold(synapse), GetSum(synapse,response));
            Console.ResetColor();
            Main(new string[] { });
            Console.ReadLine();
            
        }

        private static void CompareWeightThreshold(int thrash, int sum)
        {
            if (sum > thrash)
            {
                Console.WriteLine("Neuron fired");
            }
        }
        public static object GetIncreasedWeight(List<int> response)
        {
            for (int i = 0; i < Synapse; i++)
            {
                if (response[i] == 1)
                {
                    synapse[i] = synapse[i]+ 1;
                }
            }
            return synapse;
        }

        public static void CreatedSynapseLine(List<int> synapse)
        {
            for (int i = 0; i < Synapse; i++)
            {
                Console.Write(synapse[i]+ " ");
            }
            Console.WriteLine("");
        }
        public static object GetUserInput(int i)
        {
            Console.WriteLine("fire synapse? y/n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "n":
                    input = "0";
                    break;
                case "y":
                    input = "1";
                    break;
            }
            int c;
            Int32.TryParse(input, out c);
            response[i] = c;
            return response;
        }
        public static int GetThreshold(List<int> synapse)
        {
            int thrash = 0;
            for (int i = 0; i < Synapse; i++)
            {
                   thrash = thrash + synapse[i];
            }
            return thrash /2;
        }
        public static int GetSum(List<int> synapse, List<int> response)
        {
            int sum = 0;
            for (int i = 0; i < Synapse; i++)
            {
                if (response[i] == 1)
                {
                    sum = sum + synapse[i];
                }
            }
            return sum;
        }
        public static int Response(int o)
        {
            
            return o;
        }
        
        
    }
    
    
}
