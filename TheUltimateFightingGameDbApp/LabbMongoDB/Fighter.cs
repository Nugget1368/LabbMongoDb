using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbMongoDB
{
    internal class Fighter
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public List<string> Abilities { get; set; }
        public List<string> Types { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string BackStory { get; set; }

        public Fighter(int id, string name, List<string> abilities, List<string> types, double height, double weight, string backStory)
        {
            Id = id;
            Name = name;
            Abilities = abilities;
            Types = types;
            Height = height;
            Weight = weight;
            BackStory = backStory;
        }
    }
}
