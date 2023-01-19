using MongoDB.Driver;
using MongoDB.Bson;

namespace LabbMongoDB
{
    internal class InventoryController
    {
        IIO io;
        DAO dao;
        Menus menus;
        public InventoryController(IIO io, DAO dao)
        {
            this.io = io;
            this.dao = dao;
            menus = new Menus();
        }
        public void UserStart()
        {
            var script = new Script();
            bool TryAgain = true;
            while (true)
            {
                //MainMenu
                int choice = menus.UserMainMenu();
                //Choices
                switch (choice)
                {
                    case 1:
                        menus.CreateFighterMenu();
                        var fighter = script.CreateFighterScript();
                        if(fighter is not null)
                        {
                            dao.Create(fighter.Id, fighter.Name, fighter.Abilities.ToArray(), fighter.Types.ToArray(), fighter.Height, fighter.Weight, fighter.BackStory);
                            io.SuccessfulOutput("Fighter created!\n");
                        }
                        else
                        {
                            io.ReturnOutput();
                        }
                        io.ContinueOutput();
                        Console.ReadKey();
                        break;
                    case 2:
                        //Get Fighter -> 1 or All?
                        //All
                        menus.ChooseFighterMenu();
                        var fighters = dao.ReadAll();
                        dao.PrintAllFighters();

                        //Choose fighter index
                        TryAgain = true;
                        while (TryAgain)
                        {
                            choice = io.GetNumInput();
                            try
                            {
                                if(!(choice == 0))  //Go back
                                {
                                    var document = dao.ReadOne(choice);
                                    io.Output(document);
                                    TryAgain = false;
                                }
                                else
                                {
                                    io.ReturnOutput();
                                    TryAgain = false;
                                }
                            }
                            catch
                            {
                                io.ErrorOutput("\nTRY AGAIN\n");
                            }
                        }
                        io.ContinueOutput();
                        Console.ReadKey();
                        break;
                    case 0:   //Exit
                        io.Exit();
                        break;
                    default:
                        //Error
                        io.ErrorOutput("Error....\n");
                        break;
                }
                io.ClearWindow();
            }
        }
        public void AdminStart()
        {
            var script = new Script();
            bool TryAgain = true;
            while (true)
            {
                //MainMenu
                int choice = menus.AdminMainMenu();
                //Choices
                switch (choice)
                {
                    case 1:
                        menus.CreateFighterMenu();
                        var fighter = script.CreateFighterScript();
                        if (fighter is not null)
                        {
                            dao.Create(fighter.Id, fighter.Name, fighter.Abilities.ToArray(), fighter.Types.ToArray(), fighter.Height, fighter.Weight, fighter.BackStory);
                            io.SuccessfulOutput("Fighter created!\n");
                        }
                        else
                        {
                            io.ReturnOutput();
                        }
                        io.ContinueOutput();
                        Console.ReadKey();
                        break;
                    case 2:
                        //Get Fighter -> 1 or All?
                        //All
                        menus.ChooseFighterMenu();
                        var fighters = dao.ReadAll();
                        dao.PrintAllFighters();

                        //Choose fighter index
                        TryAgain = true;
                        while (TryAgain)
                        {
                            choice = io.GetNumInput();
                            try
                            {
                                if (!(choice == 0))  //Go back
                                {
                                    var document = dao.ReadOne(choice);
                                    io.Output(document);
                                    TryAgain = false;
                                }
                                else
                                {
                                    io.ReturnOutput();
                                    TryAgain = false;
                                }
                            }
                            catch
                            {
                                io.ErrorOutput("\nTRY AGAIN\n");
                            }
                        }
                        io.ContinueOutput();
                        Console.ReadKey();
                        break;
                    case 3:
                        //Update Fighter -> id?
                        menus.UpdateFighterMenu();
                        fighters = dao.ReadAll();
                        dao.PrintAllFighters();

                        TryAgain = true;
                        while (TryAgain)
                        {
                            choice = io.GetNumInput();
                            int id = choice;
                            try
                            {
                                if (!(choice == 0))  //Return
                                {
                                    //Hitta Fighter
                                    var document = dao.GetFighter(choice);
                                    while (TryAgain)
                                    {
                                        //Uppdatera Ability
                                        io.Output(document.ElementAtOrDefault(1).ToString().Substring(5) + $" is choosen, which ability will be updated? There is {document.ElementAtOrDefault(2).ToString().Split(',').ToArray().Length} abilities, {document.ElementAtOrDefault(2).ToString().Replace('=', ':').Replace('[', ' ').Replace(']', ' ')}\n");
                                        choice = io.GetNumInput();
                                        int ability = choice - 1;
                                        //Ifall Valet av Ability är inom ramen för arrayen
                                        if (ability < document.ElementAtOrDefault(2).ToString().Split(',').ToArray().Length) //Om index är mindre än alternativen
                                        {
                                            io.Output($"Update ability {ability + 1} to:\n");
                                            var newAbility = io.GetInput();
                                            //Update
                                            dao.UpdateAbility(id, ability, newAbility);
                                            io.SuccessfulOutput("Update succeded! :D\n");
                                            TryAgain = false;
                                        }
                                        else
                                        {
                                            io.ErrorOutput("Error....\n");    //Index out of bounds e
                                        }
                                    }
                                }
                                else  //Return to main window
                                {
                                    TryAgain = false;
                                    io.ReturnOutput();
                                }
                            }
                            catch
                            {
                                io.ErrorOutput("\nTRY AGAIN\n");
                            }
                        }
                        io.ContinueOutput();
                        Console.ReadKey();
                        break;
                    case 4:
                        //Delete Fighter -> id?
                        menus.DeleteFighterMenu();
                        dao.PrintAllFighters();
                        io.Output("Which fighter shall be deleted?");
                        choice = io.GetNumInput();
                        if (!(choice == 0))  //Return
                        {
                            bool succesfulDelete = dao.Delete(choice);
                            if (succesfulDelete)
                            {
                                io.SuccessfulOutput("Fighter has been deleted!\n");
                            }
                            else
                            {
                                io.ErrorOutput("Fighter not found.\n");
                            }
                        }
                        else
                        {
                            io.ReturnOutput();
                        }
                        io.ContinueOutput();
                        Console.ReadKey();
                        break;
                    case 0:   //Exit
                        io.Exit();
                        break;
                    default:
                        //Error
                        io.ErrorOutput("Error....\n");
                        break;
                }
                io.ClearWindow();
            }
        }


    }
}
