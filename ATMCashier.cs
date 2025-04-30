using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rio.Coding.Exercise
{
  public  class ATMCashier
    {

        private int[] notes;


        public ATMCashier( int[] denominations) { 
        
        notes = denominations;

        }

        public void ShowCombination(int []ammounts)
        {

            foreach (int ammount in ammounts)
            {

                if (ammount <= 0)
                {
                    Console.WriteLine($" This {ammount} can not have combination");

                }
                Console.WriteLine($"\nWays to make {ammount} in EUR:");

                GenerateCombinations(ammount, 0, new int[notes.Length]);

            }


        }
        private void GenerateCombinations(int remaining, int idx, int[] used)
        {
            if (idx == notes.Length - 1)
            {
                if (remaining % notes[idx] == 0)
                {
                    used[idx] = remaining/ notes[idx];

                    Print(used);
                }

                return;
            }
            int maxCount = remaining / notes[idx];
            for (int i = 0; i <= maxCount; i++)
            {
                used[idx] = i;
                GenerateCombinations( remaining - i * notes[idx], idx + 1, used);
            }

        }
        private void Print(int[] used)
        {
            var parts = new List<string>();

            for (int i = 0; i < notes.Length; i++)
            { 

                if (used[i] > 0)
                    parts.Add($"{used[i]} x {notes[i]}");
            }

            Console.WriteLine(string.Join(" + ", parts));
        }

               

    }
}
