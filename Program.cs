using System;

namespace Rio.Coding.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] denominations = { 10, 50, 100 }; // You can change this

            int[] amounts = { 30, 50, 60, 80, 140, 230, 370, 610, 980 };

            var machine = new ATMCashier(denominations);

            machine.ShowCombination(amounts);
        }
    }
}
