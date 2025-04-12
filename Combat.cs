using System;

namespace RPGGame
{
    public class Combat : ICombat
    {
        public void StartCombat(Character player)
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
