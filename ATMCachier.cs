using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rio.Coding.Exercise
{
  public  class Cashier
    {
        private readonly int[] Denominations = { 10, 50, 100 };

        // this method will calcualate possible withdra
        public void GetPossibleWithdrawals(int[] withdrawalList)
        {
            foreach (var item in withdrawalList)
            { 

                GenrateCombination(item);
            }
        }

        private void GenrateCombination(int amountLeft, int billIndex = 0, int[] usedBills = null)
        {
            
            if (usedBills == null) usedBills = new int[Denominations.Length];

           
        }

       

    }
}
