using System;
using System.Collections.Generic;

namespace RPGGame
{
    class RPGGame
    {
        static void Main(string[] args)
        {
            ICharacterCreator characterCreator = new CharacterCreator();
            Character player = characterCreator.CreateCharacter();
            Console.WriteLine($"Welcome, {player.Name} the {player.Class}!");

            ICombat combat = new Combat();
            IExplorer explorer = new Explorer(combat);
            explorer.Explore(player);
        }
    }
}