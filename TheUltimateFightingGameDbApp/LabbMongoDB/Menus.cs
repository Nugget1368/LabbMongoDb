using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbMongoDB
{
    internal class Menus
    {
        TextIO io = new TextIO();
        
        public bool IsAdmin()
        {
            bool TryAgain = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@$"---User Select---
1. Admin.
2. User.
0. Exit.
----------------");
            Console.ForegroundColor = ConsoleColor.White;
            while (TryAgain)
            {
                int choice = io.GetNumInput();
                switch(choice)
                {
                    case 1: //Admin
                        io.ClearWindow();
                        TryAgain = false;
                        return true;
                        break;
                    case 2: //User
                        io.ClearWindow();
                        TryAgain = false;
                        return false;
                        break;
                    case 0: //Exit
                        io.Exit();
                        return false;
                    default:    //Fel - Gör om
                        io.ErrorOutput("Error.... TryAgain....");
                        break;
                }
            }
            return false;            
        }
        public int AdminMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@$"------Menu------
1. Create Fighter.
2. Choose Fighter.
3. Update Fighter.
4. Delete Fighter.
0. Exit.
----------------");
            Console.ForegroundColor = ConsoleColor.White;

            int answer;
            bool success = false;
            while (!(success))
            {
                Console.Write("admin > ");
                success = int.TryParse(Console.ReadLine(), out answer);
                if (success && answer >= 0 && answer < 5)
                {
                    return answer;  ///Välj id från resp. Fighter.
                }
            }
            return -1;
        }
    
        public int UserMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@$"------Menu------
1. Create Fighter.
2. Choose Fighter.
0. Exit.
----------------");
            Console.ForegroundColor = ConsoleColor.White;

            int answer;
            bool success = false;
            while (!(success))
            {
                Console.Write("user > ");
                success = int.TryParse(Console.ReadLine(), out answer);
                if (success && answer >= 0 && answer < 5)
                {
                    return answer;  ///Välj id från resp. Fighter.
                }
            }
            return -1;
        }
        public void CreateFighterMenu()
        {
            string menu = @"
---------------------------
* CREATE YOUR FIGHTER *
---------------------------
0. Return";
            io.ClearWindow();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(menu + "\n");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void ChooseFighterMenu()
        {
            string menu = @"
---------------------------
* CHOOSE YOUR FIGHTER *
---------------------------
0. Return";
            io.ClearWindow();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(menu + "\n");
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void UpdateFighterMenu()
        {
            string menu = @"
---------------------------
* UPDATE FIGHTER *
---------------------------
0. Return";
            io.ClearWindow();
            Console.Write(menu + "\n");

        }

        public void DeleteFighterMenu()
        {
            string menu = @"
---------------------------
* DELETE FIGHTER *
---------------------------
0. Return";
            io.ClearWindow();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(menu + "\n");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
