using System;
using System.Runtime.InteropServices;

namespace Rio.Coding.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] noteTypes = { 10, 50, 100 }; // You can change this

            int[] amounts = { 0, 50, 60, 80, 140, 230, 370, 610, 980 }; // you can change to different values

            var machine = new ATMCashier(noteTypes);

            machine.ShowCombination(amounts);
        }
    }
}
