using System;
using System.Runtime.InteropServices;

namespace Ria.ATM.Cashier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] noteTypes = { 10, 50, 100 }; // You can change this

            int[] amounts = { 30, 50, 60, 80, 140, 230, 370, 610, 980 }; // you can change to different values

            var machine = new ATMCashier(noteTypes);

            machine.ShowCombination(amounts);
        }
    }
}
