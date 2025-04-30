using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.ATM.Cashier
{
  public  class ATMCashier
    {

        private int[] noteTypes;


        public ATMCashier( int[] denominations) { 
        
        noteTypes = denominations;

        }

        public void ShowCombination(int []ammounts)
        {

            foreach (int ammount in ammounts)
            {


                if (ammount <= 0)
                {
                    Console.WriteLine($" Oops! The amount: {ammount} can't be split using this combination");

                    continue;
                }

                Console.WriteLine($"{ammount} EUR can be paid in these ways:");

                GetCombinations(ammount, 0, new int[noteTypes.Length]);

            }


        }
        private void GetCombinations(int remaining, int idx, int[] used)
        {
            if (noteTypes.Length == 0)
            {
                Console.WriteLine("No denominations provided.");

                return;
            }

            if (idx == noteTypes.Length - 1)
            {
                if (remaining % noteTypes[idx] == 0)
                {
                    used[idx] = remaining/ noteTypes[idx];

                    ShowBreakdown(used);
                }

                return;
            }
            int maxCount = remaining / noteTypes[idx];
            for (int i = 0; i <= maxCount; i++)
            {
                used[idx] = i;
                // Try every possible number of bills for the current note type

                GetCombinations( remaining - i * noteTypes[idx], idx + 1, used);
            }

        }
        private void ShowBreakdown(int[] used)
        {
            var parts = new List<string>();

            for (int i = 0; i < noteTypes.Length; i++)
            { 

                if (used[i] > 0)
                    parts.Add($"{used[i]} x {noteTypes[i]}");
            }

            Console.WriteLine(string.Join(" + ", parts));
        }

               

    }
}
