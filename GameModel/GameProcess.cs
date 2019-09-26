using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    class GameProcess
    {
        Player player;
        Player computer;

        GameProcess(String name, int health) {
            player = new Player(name, health);
            computer = new Player("Computer", health);
        }

        void GameLoop() {

        }

        void showMessageOfTurn() {
            Console.WriteLine();
        }
    }
}
