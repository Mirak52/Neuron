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
        const int Dendrit = 5;
        public static List<int> dendrit = new List<int>();
        public  static List<int> response = new List<int>();
        public static bool start = true;
        static void Main(string[] args)
        {
            if (start)
            {
                for (int i = 0; i < Dendrit; i++)
                {
                        dendrit.Add(i);
                        response.Add(i);
                        dendrit[i]=1;
                }
                start = false;
            }
            for (int i=0; i < Dendrit; i++)
            {
                GetUserInput(i);
            }
            GetIncreasedWeight(response);
            Console.ForegroundColor = ConsoleColor.Cyan;
            CreatedSynapseLine(dendrit);
            Console.WriteLine("Threshold: "+GetThreshold(dendrit));
            Console.WriteLine("sum: "+GetSum(dendrit,response));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            CompareWeightThreshold(GetThreshold(dendrit), GetSum(dendrit,response));
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
            for (int i = 0; i < Dendrit; i++)
            {
                if (response[i] == 1)
                {
                    dendrit[i] = dendrit[i]+ 1;
                }
            }
            return dendrit;
        }

        public static void CreatedSynapseLine(List<int> dendrit)
        {
            for (int i = 0; i < Dendrit; i++)
            {
                Console.Write(dendrit[i]+ " ");
            }
            Console.WriteLine("");
        }
        public static object GetUserInput(int i)
        {
            Console.WriteLine("fire dendrit? y/n");
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
        public static int GetThreshold(List<int> dendrit)
        {
            int thrash = 0;
            for (int i = 0; i < Dendrit; i++)
            {
                   thrash = thrash + dendrit[i];
            }
            return thrash /2;
        }
        public static int GetSum(List<int> dendrit, List<int> response)
        {
            int sum = 0;
            for (int i = 0; i < Dendrit; i++)
            {
                if (response[i] == 1)
                {
                    sum = sum + dendrit[i];
                }
            }
            return sum;
        }
    }
}
