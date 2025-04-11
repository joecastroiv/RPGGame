using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    enum CharacterClass
    {
        Warrior,
        Mage,
        Rogue
    }

    internal class Character
    {
        public string Name { get; set; }
        public CharacterClass Class { get; set; }
        public int Health { get; set; }
        public List<string> Inventory { get; set; }

        public Character(string name, CharacterClass characterClass)
        {
            Name = name;
            Class = characterClass;
            Health = 100;
            Inventory = new List<string>();
        }
    }




}
