using System;
using System.Collections.Generic;

namespace RPGGame
{
    class RPGGame
    {
        static void Main(string[] args)
        {
            Character player = CreateCharacter();
            Console.WriteLine($"Welcome, {player.Name} the {player.Class}!");
            Explore(player);
        }

        static Character CreateCharacter()
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

        static void Explore(Character player)
        {
            Console.WriteLine("You are exploring the world...");
            Random random = new Random();
            while (true)
            {
                int encounter = random.Next(1, 4);
                switch (encounter)
                {
                    case 1:
                        Console.WriteLine("You found a treasure chest!");
                        player.Inventory.Add("Gold");
                        break;
                    case 2:
                        Console.WriteLine("You encountered a monster!");
                        Combat(player);
                        break;
                    case 3:
                        Console.WriteLine("You found a healing potion!");
                        player.Inventory.Add("Healing Potion");
                        break;
                }

                Console.WriteLine("Do you want to continue exploring? (yes/no)");
                string response = Console.ReadLine().ToLower();
                if (response != "yes")
                {
                    Console.WriteLine("Thanks for playing! Goodbye.");
                    break;
                }
            }
        }

        static void Combat(Character player)
        {
            Console.WriteLine("Combat initiated!");
            Random random = new Random();
            int monsterHealth = random.Next(20, 51);
            while (monsterHealth > 0 && player.Health > 0)
            {
                Console.WriteLine($"Monster Health: {monsterHealth}");
                Console.WriteLine($"Your Health: {player.Health}");
                Console.WriteLine("Choose your action:");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Healing Potion");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        int damage = random.Next(5, 16);
                        monsterHealth -= damage;
                        Console.WriteLine($"You dealt {damage} damage to the monster.");
                        break;
                    case "2":
                        if (player.Inventory.Contains("Healing Potion"))
                        {
                            player.Health += 20;
                            player.Inventory.Remove("Healing Potion");
                            Console.WriteLine("You used a healing potion and restored 20 health.");
                        }
                        else
                        {
                            Console.WriteLine("You don't have any healing potions!");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid action, you missed your turn.");
                        break;
                }

                if (monsterHealth > 0)
                {
                    int monsterDamage = random.Next(5, 16);
                    player.Health -= monsterDamage;
                    Console.WriteLine($"The monster dealt {monsterDamage} damage to you.");
                }
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("You have been defeated by the monster.");
            }
            else
            {
                Console.WriteLine("You defeated the monster!");
            }
        }
    }
}