using System;
using System.Collections.Generic;

namespace Web
{
    public static class Permutation
    {
        public static void Permute(List<int> Input)
        {
            List<int> Answer = new List<int>();
            Permute(Input, Answer);
        }
        public static void Permute(List<int> Possibilities, List<int> Answer)
        {
            if (Possibilities.Count == 0)
            {
                Console.Write("[");
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
                Permute(NewPossibilities, NewAnswer);
            }
        }

        public static int Main(string[] args)
        {
            List<int> Array = new List<int>();
            string input;

            while(1)
            {
                input = Console.Read();
            }

            Permute(Array);
            return 0;
        }
    }
}