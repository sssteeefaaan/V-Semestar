using System;
using System.Collections.Generic;

namespace Web
{
    public static class WebProg
    {
        //public static List<int> Union(List<int> set1, List<int> set2)
        //{
        //    List<int> ret = new List<int>();

        //    ret.Add(set1[0]);
        //    for (int i = 1; i < set1.Count; i++)
        //    {
        //        if (ret[ret.Count - 1] != set1[i])
        //            ret.Add(set1[i]);

        //        for (int j = i; j < set1.Count; j++)
        //            if (set1[j] > ret[i])
        //                ret[i] = set1[j];
        //    }

        //    for (int i = 0; i < set2.Count; i++)
        //    {
        //        if (ret[ret.Count - 1] != set2[i])
        //            ret.Add(set2[i]);
        //        ret.Add(set2[i]);
        //        for (int j = i; j < set2.Count; j++)
        //            if (set2[j] > ret[size + i])
        //                ret[size + i] = set2[j];
        //    }

        //    return ret;
        //}
        public static void Permute(List<int> Input)
        {
            List<int> Answer = new List<int>();
            int red = 0;
            Permute(Input, Answer, ref red);
        }
        public static void Permute(List<int> Possibilities, List<int> Answer, ref int red)
        {
            if (Possibilities.Count == 0)
            {
                red++;
                Console.Write(red.ToString() + ". [");
                for (int j = 0; j < Answer.Count - 1; j++)
                    Console.Write(Answer[j].ToString() + ", ");
                Console.WriteLine(Answer[Answer.Count - 1].ToString() + "]");

                return;
            }

            for (int j = 0; j < Possibilities.Count; j++)
            {
                List<int> NewPossibilities = new List<int>();
                List<int> NewAnswer = new List<int>();
                for (int k = 0; k < Answer.Count; k++)
                    NewAnswer.Add(Answer[k]);
                for (int k = 0; k < Possibilities.Count; k++)
                {
                    if (k != j)
                        NewPossibilities.Add(Possibilities[k]);
                    else
                        NewAnswer.Add(Possibilities[k]);
                }
                Permute(NewPossibilities, NewAnswer, ref red);
            }
        }

        public static void Variate(List<int> Input)
        {
            List<int> Answer = new List<int>();
            int red = 0;
            Variate(Input, Answer, ref red);
        }
        public static void Variate(List<int> Possibilities, List<int> Answer, ref int red)
        {
            if (Possibilities.Count == 0)
            {
                red++;
                Console.Write(red.ToString() + ". [");
                for (int j = 0; j < Answer.Count - 1; j++)
                    Console.Write(Answer[j].ToString() + ", ");
                Console.WriteLine(Answer[Answer.Count - 1].ToString() + "]");

                return;
            }

            for (int j = 0; j < Possibilities.Count; j++)
            {
                List<int> NewPossibilities = new List<int>();
                List<int> NewAnswer = new List<int>();
                for (int k = 0; k < Answer.Count; k++)
                    NewAnswer.Add(Answer[k]);
                for (int k = 0; k < Possibilities.Count; k++)
                {
                    if (k != j)
                        NewPossibilities.Add(Possibilities[k]);
                    else
                        NewAnswer.Add(Possibilities[k]);
                }
                int count = 0;
                for (int p = j; p < Possibilities.Count; p++)
                    if (Possibilities[p] == Possibilities[j])
                        count++;
                if(count == 1)
                    Variate(NewPossibilities, NewAnswer, ref red);
            }
        }

        public static int Main(string[] args)
        {
            List<int> Array = new List<int>();
            string input1, input2;

            while (true)
            {
                Console.WriteLine("Unesite 'VARIJACIJE', 'PERMUTACIJE' ili 'KRAJ':");
                input1 = Console.ReadLine();
                if (input1 == "KRAJ")
                    break;

                Array.Clear();
                Console.WriteLine();
                Console.WriteLine("Unesite brojeve i 'KRAJ' za potvrdu:");
                while (true)
                {
                    input2 = Console.ReadLine();
                    if (input2 == "KRAJ")
                        break;
                    Array.Add(Int16.Parse(input2));
                }

                if(input1=="VARIJACIJE")
                    Variate(Array);
                else if (input1 == "PERMUTACIJE")
                    Permute(Array);

                Console.WriteLine();
            }
            return 0;
        }
    }
}