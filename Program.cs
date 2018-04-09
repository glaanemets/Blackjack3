using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many ppl?");
            int playerCount = int.Parse(Console.ReadLine());
            Game game = new Game(playerCount);
            Console.ReadKey();
        }
    }
}
