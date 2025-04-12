using System;

namespace RPGGame
{
    public class CharacterCreator : ICharacterCreator
    {
        public Character CreateCharacter()
        {
            Console.WriteLine("Create your character:");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Choose your class:");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Rogue");
            string classChoice = Console.ReadLine();

            CharacterClass characterClass = CharacterClass.Warrior;
            switch (classChoice)
            {
                case "1":
                    characterClass = CharacterClass.Warrior;
                    break;
                case "2":
                    characterClass = CharacterClass.Mage;
                    break;
                case "3":
                    characterClass = CharacterClass.Rogue;
                    break;
                default:
                    Console.WriteLine("Invalid choice, defaulting to Warrior.");
                    break;
            }

            return new Character(name, characterClass);
        }
    }
}

