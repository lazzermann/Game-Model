using System;
using System.Threading;

namespace GameModel
{
    class GameProcess
    {
        Player player;
        Player computer;

       public GameProcess(String name, int hpCount) {
            this.player = new Player(name, hpCount);
            this.computer = new Player("Computer", hpCount);
        }

        public GameProcess() {
            player = new Player("Player", 100);
            computer = new Player("Computer", 100);
        }

       public void Game() {
            Random turnRandomizer = new Random();

            do
            {
                switch (turnRandomizer.Next(1,3)) {

                    case 1:
                        switch (player.chooseAction()) {
                            case 1:
                                computer.getDamage(player.Punch());
                                showResultOfTurn(player.getName()+" kick the "+computer.getName()+" with punch");
                                break;
                            case 2:
                                computer.getDamage(player.forcePunch());
                                showResultOfTurn(player.getName() + " kick the " + computer.getName() + " with force punch");
                                break;
                            case 3:
                                player.Heal();
                                showResultOfTurn(player.getName() + " heal himself");
                                break;
                        };
                        break;

                    case 2:
                        switch (computer.chooseAction())
                        {
                            case 1:
                                player.getDamage(computer.Punch());
                                showResultOfTurn(computer.getName() + " kick the " + player.getName() + " with punch");
                                break;
                            case 2:
                                player.getDamage(computer.forcePunch());
                                showResultOfTurn(computer.getName() + " kick the " + player.getName() + " with force punch");
                                break;
                            case 3:
                                computer.Heal();
                                showResultOfTurn(computer.getName() + " heal himself");
                                break;
                        };
                        break;   

                };

                Console.Beep();
                Thread.Sleep(500);

            } while (player.getHealth() > 0 && computer.getHealth() > 0);
            
            if(player.getHealth() < 0)
            showGameResult(computer);

            if (computer.getHealth() < 0)
                showGameResult(player);
        }

        void showResultOfTurn(String message) {
            Console.WriteLine(message);
            Console.WriteLine(player.getName()+" HP"+" : " + player.getHealth());
            Console.WriteLine(computer.getName() + " HP" + " : " + computer.getHealth());
            Console.WriteLine();
        }

        void showGameResult(Player winner) {      
                Console.WriteLine(winner.getName() + " Win !!!");
                Console.WriteLine("Remaining Hp : " + winner.getHealth());
        }

    }
}
