using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    class startGameInterface
    {
        //Action constants to avoid the appearance of magic numbers
        const int customSetPlayerOptionsAction = 1;
        const int defaultSetPlayerOptionsAction = 2;
        const int exitAction = 0;

        GameModulation game;

        public startGameInterface() { }

        
        public void startGame()
        {
            int chooser = 0;

            //Menu
            Console.WriteLine("Welcome to game model simulation");
            Console.WriteLine("Input  1 - to choose your player name and count of HP");
            Console.WriteLine("2 - to choose default player name and 100 HP");
            Console.WriteLine("0 - to exit from programm");

            try
            {
                chooser = Convert.ToInt32(Console.ReadLine());
            }

            catch (System.FormatException) {
                Console.WriteLine("You input not a number - default game options selected");
                chooser = defaultSetPlayerOptionsAction;

                Thread.Sleep(1000); //Delay between the exception message and game result outputs
            }

            switch (chooser)
            {
                case customSetPlayerOptionsAction:

                    setPlayers(customSetPlayerOptionsAction);
                    break;

                case defaultSetPlayerOptionsAction:

                    setPlayers(defaultSetPlayerOptionsAction);
                    break;

                case exitAction:

                    Environment.Exit(0); //Exit from programm
                    break;

                default:
                    setPlayers(defaultSetPlayerOptionsAction);
                    break;
            }
            //Start game loop
            game.startGame();
        }
       

        private void setPlayers(int chooseIndex)
        {
            int count;
            String name;

            switch (chooseIndex)
            {
                case customSetPlayerOptionsAction:
                    Console.Write("Name: ");
                    name = Console.ReadLine();

                    Console.Write("HP count: ");
                    count = Convert.ToInt32(Console.ReadLine());

                    game = new GameModulation(name, count);
                    break;

                case defaultSetPlayerOptionsAction:
                    game = new GameModulation();
                    break;

                default:
                    game = new GameModulation();
                    break;
            }
        }
    }
}
