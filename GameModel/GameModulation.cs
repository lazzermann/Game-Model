using System;
using System.Threading;

namespace GameModel
{
    class GameModulation
    {
        //Action constants to avoid the appearance of magic numbers
        const int punchAction = 1;
        const int forcePunchAction = 2;
        const int healAction = 3;


        Player player;
        Player computer;

       public GameModulation(String name, int hpCount) {
            this.player = new Player(name, hpCount);
            this.computer = new Player("Computer", hpCount);
        }

        public GameModulation(Player player, Player computer) {
            this.player = player;
            this.computer = computer;
        }

        //Default constructor
        public GameModulation() {
            player = new Player("Player", 100);
            computer = new Player("Computer", 100);
        }

        //Game loop
       public void startGame() {
            Random turnRandomizer = new Random(); //Random of computer and player turns

            do
            {
                switch (turnRandomizer.Next(1,3)) {

                    case 1:
                        switch (player.chooseAction()) { //Turn of the player
                           
                            case punchAction:
                                computer.getDamage(player.Punch());
                                showResultOfTurn(player.getName()+" kick the "+computer.getName()+" with punch");
                                break;

                            case forcePunchAction:
                                computer.getDamage(player.forcePunch());
                                showResultOfTurn(player.getName() + " kick the " + computer.getName() + " with force punch");
                                break;

                            case healAction:
                                player.Heal();
                                showResultOfTurn(player.getName() + " heal himself");
                                break;
                        };
                        break;

                    case 2:
                        switch (computer.chooseAction()) //Turn of the computer
                        {

                            case punchAction:
                                player.getDamage(computer.Punch());
                                showResultOfTurn(computer.getName() + " kick the " + player.getName() + " with punch");
                                break;

                            case forcePunchAction:
                                player.getDamage(computer.forcePunch());
                                showResultOfTurn(computer.getName() + " kick the " + player.getName() + " with force punch");
                                break;

                            case healAction:
                                computer.Heal();
                                showResultOfTurn(computer.getName() + " heal himself");
                                break;
                        };
                        break;   

                };

                Console.Beep(); //Sound signal
                Thread.Sleep(500); //Delay between result outputs on half of second

            } while (player.getHealth() > 0 && computer.getHealth() > 0);
            
            if(player.getHealth() < 0)
            showGameResult(computer);

            if (computer.getHealth() < 0)
                showGameResult(player);
        }

        //Show what happens at each turn
        void showResultOfTurn(String message) {
            Console.WriteLine(message);
            Console.WriteLine(player.getName()+" HP"+" : " + player.getHealth());
            Console.WriteLine(computer.getName() + " HP" + " : " + computer.getHealth());
            Console.WriteLine();
        }

        //Show winner
        void showGameResult(Player winner) {      
                Console.WriteLine(winner.getName() + " Win !!!");
                Console.WriteLine("Remaining Hp : " + winner.getHealth());
        }

    }
}
