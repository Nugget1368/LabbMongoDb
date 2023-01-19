/******************************************
 Här skrivs längre frågor till användaren
 ****************************************/

namespace LabbMongoDB
{
    internal class Script
    {
        public Fighter CreateFighterScript()
        {
            IIO io = new TextIO();

            int fighterWeight = 0;
            int fighterHeight = 0;
            string backstory = "";
            List<string> abilitiesList = new List<string>();
            List<string> typesList = new List<string>();

            
            io.HeaderOutput("\n---Figther id---\n");
            int fighterId = io.GetNumInput();

            if(!(fighterId == 0))
            {
                io.HeaderOutput("\n---Figther name---\n");
                string fighterName = io.GetInput();

                io.HeaderOutput("\n---Figther Abilities---\n");
                io.Output("How many abilities should this fighter have:");
                int numOfAbilities = io.GetNumInput();
               
                string[] abilities = new string[numOfAbilities];
                for (int x = 0; x < numOfAbilities; x++)
                {
                    io.Output($"Ability {x + 1} ");
                    abilities[x] = io.GetInput();
                }
                foreach (var ability in abilities)
                {
                    abilitiesList.Add(ability);
                }
       
                io.HeaderOutput("\n---Figther Types---\nAmount of types for this fighter is > ");
                int numOfTypes = io.GetNumInput();
               
                string[] types = new string[numOfTypes];
                for (int x = 0; x < numOfTypes; x++)
                {
                    io.Output($"Type {x + 1} > ");
                    types[x] = io.GetInput();
                }
                foreach (var type in types)
                {
                    typesList.Add(type);
                }
                
       
                io.HeaderOutput("\n---Fighter Weight---\n");
                fighterWeight = io.GetNumInput();
     
                io.HeaderOutput("\n---Fighter Height---\n");
                fighterHeight = io.GetNumInput();
   
                io.HeaderOutput("\n---Fighter Backstory---\n");
                backstory = io.GetInput();

                return new Fighter(fighterId, fighterName, abilitiesList, typesList, fighterHeight, fighterWeight, backstory);
            }
            return null;
       }
    }
}
