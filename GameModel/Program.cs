using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose name of your fighter and count of health");
            GameProcess game = new GameProcess(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
            game.Game();
        }
    }
}
