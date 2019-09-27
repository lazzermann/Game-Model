using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    class Program
    {
        static void Intro() {       
            
            int chooser;

            Console.WriteLine("Welcome to game model simulation");
            Console.WriteLine("Input  1 - to choose your player name and count of HP");
            Console.WriteLine("2 - to choose default player name and 100 HP");
            Console.WriteLine("0 - to exit");

            chooser = Convert.ToInt32(Console.ReadLine());
            switch(chooser){
                case 1:
                    setGameThisIsPrototypeOfNameOfThisFunction(1);
                    break;
                case 2:
                    setGameThisIsPrototypeOfNameOfThisFunction(2);
                    break;
                case 0:
                    Environment.Exit(0); //Exit from programm
                    break;
                default:
                    break;
            }
        }
        //Need change name of function
        static void setGameThisIsPrototypeOfNameOfThisFunction(/*GameModulation game,*/ int chooseIndex) {
            GameModulation game;

            int count;
            String name;

            switch(chooseIndex){
                case 1:
                    Console.Write("Name: ");
                    name = Console.ReadLine();

                    Console.Write("HP count: ");
                    count = Convert.ToInt32(Console.ReadLine());

                    game = new GameModulation(name, count);
                    break;
     
                case 2:
                    game = new GameModulation();
                    break;

                default:
                    game = new GameModulation();
                    break;
            }
            game.startGame();
        }

        static void Main(string[] args)
        {
            Intro();
        }
    }
}
