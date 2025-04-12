using System;

namespace RPGGame
{
    public class Explorer : IExplorer
    {
        private readonly ICombat _combat;

        public Explorer(ICombat combat)
        {
            _combat = combat;
        }

        public void Explore(Character player)
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
                        _combat.StartCombat(player);
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
    }
}
