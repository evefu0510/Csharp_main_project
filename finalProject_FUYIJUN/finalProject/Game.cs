using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProject
{
    internal class Game
    {
        private int playerHP;
        private int dragonHP;

        public void Start()
        {
            int playerHP = 30; // Player's initial HP value
            int dragonHP = 20; // Dragon's initial HP value
            int roadChoice;


            //User input name
            Console.WriteLine("Welcome, adventurer! Legends tell of a hidden castle treasure fiercely guarded by a dragon's flame. Can your mettle withstand the blaze to claim the prize? Please tell me your name! ");
            string playerName = Console.ReadLine();
            Console.WriteLine("Greetings, " + playerName + ". Your journey begins now. ");

            //******************** Chapter 1: a simple choice  (using 'do while loop' & 'Switch' ) ********************            
            do
            {
                Console.WriteLine("******************** Chapter 1: You find yourself at the castle gates. Choose your path: ********************");
                Console.WriteLine("1. Go straight ahead");
                Console.WriteLine("2. Climb through the window");
                Console.WriteLine("3. Approach the backdoor");
                Console.WriteLine("4. Exit the game");
                Console.Write("Enter your choice: (input number only)");
                roadChoice = int.Parse(Console.ReadLine());

                switch (roadChoice)
                {
                    case 1:
                        Console.WriteLine("As you approach, a soldier steps forward, blocking your way. Try another way. ");
                        break;
                    case 2:
                        Console.WriteLine("It's too high to reach with ease. Climbing might be a challenge. Reconsider your path");
                        break;
                    case 3: // Only choose path 3 can Implement further scenarios
                        Console.WriteLine("You approach the backdoor, and to your surprise, it's unlocked.");
                        Console.WriteLine("A sense of anticipation fills the air as you push it open.");
                        break;
                    case 4:
                        Console.WriteLine("Exiting the game.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (roadChoice != 3);


            //******************** Chapter 2: Choose your weapon (using single array, for and if, also use exception handling) ********************       
            string[] weaponNames = { "Sword", "Armor", "Nothing", "Exit" };
            int[] weaponBonuses = { 10, 5, 0, 0 };
            string[] weaponDescriptions = {
            "Gain a significant advantage with this mighty weapon.",
            "Equip yourself with protective armor for added defense.",
            "Opt to go without a weapon for now.",
            "Exit the game"
        };

            Console.WriteLine("******************** Chapter 2: Choose your weapon ********************");
            for (int i = 0; i < weaponNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {weaponNames[i]}");
            }
            Console.Write("Enter your choice: ");
            try
            {
                int weaponChoice = int.Parse(Console.ReadLine());

                if (weaponChoice >= 1 && weaponChoice <= weaponNames.Length)
                {
                    Console.WriteLine($"You chose {weaponNames[weaponChoice - 1]}");
                    Console.WriteLine(weaponDescriptions[weaponChoice - 1]);
                    int weaponBonus = weaponBonuses[weaponChoice - 1];
                    // Calculate the effective player health by adding weapon bonus
                    playerHP += weaponBonus;
                }
                else
                {
                    Console.WriteLine("Invalid input. You lost your chance!");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid input. You lost your chance!");
            }

            //******************* show the result of the game: *******************

            DragonBattle(ref playerHP, ref dragonHP);
            if (playerHP > 0)
            {
                Console.WriteLine("Congrats, You have won!");
                Console.WriteLine("...Press any key to explore a hidden story path...");
                Console.ReadKey();
                ShowHiddenStoryPath();
            }
            else
            {
                Console.WriteLine("You lose!");
            }
        }



        //Simulates a battle between the player and the dragon.
        //******************** Chapter 4: Combat Game (Using while & if statement & static method) ********************
        static void DragonBattle(ref int playerHP, ref int dragonHP)
        {
            int playerAttack = 5;
            int dragonAttack = 7;
            int playerHeal = 5;
            int dragonHeal = 5;

            Random random = new Random();

            Console.WriteLine("******************** Chapter 3: The Dragon's Lair ********************");
            Console.WriteLine("You are now facing the dragon! Choose your action: ");

            while (playerHP > 0 && dragonHP > 0)
            {
                Console.WriteLine(" -- Player turn --");// Attacks the dragon based on the player's choice.
                Console.WriteLine("Player HP - " + playerHP + ". Dragon HP - " + dragonHP);
                Console.WriteLine("1.Attack the dragon  2.heal yourself ");
                Console.Write("Enter your choice: "); //The player's battle choice (1 for attack, 2 for heal).
                int battleChoice = int.Parse(Console.ReadLine());

                if (battleChoice == 1)
                {
                    dragonHP -= playerAttack;
                    Console.WriteLine("You attack the dragon and deal " + playerAttack + " damage!");
                }
                else if (battleChoice == 2)
                {
                    playerHP += playerHeal;
                    Console.WriteLine("You heal yourself and restore" + playerHeal + "HP.");
                }
                else
                {
                    Console.WriteLine("Invalid input! You waste your turn.");
                }

                //Dragon turn
                if (dragonHP > 0)
                {
                    Console.WriteLine(" -- Dragon turn -- ");
                    Console.WriteLine("Player HP - " + playerHP + ". Dragon HP - " + dragonHP);
                    int dragonChoice = random.Next(0, 2);


                    if (dragonChoice == 0)
                    {
                        playerHP -= dragonAttack;
                        Console.WriteLine("Dragon attacks and deals " + dragonAttack + "HP!");
                    }
                    else
                    {
                        dragonHP += dragonHeal;
                        Console.WriteLine("Dragon restores " + dragonHeal + "HP!");
                    }

                }

            }
        }

        //******************** Hidden Chapter: Only shown when the player win the game, using multidimensional array ********************
        static void ShowHiddenStoryPath()
        {
            string[,] hiddenStory = {
        {"********************Hidden Chapter: The Mysterious Door********************", "You find a hidden door in the castle's depths."},
        {"As you open it, a gust of wind sweeps through.", "You're now faced with a dark corridor."},
        {"Your steps echo as you venture deeper into the unknown.", "Tales of ancient treasures and forgotten curses fill your thoughts."},
        {"With each step, the tension grows, but so does your excitement.", "What awaits you at the end of this uncharted path?"}
    };

            for (int row = 0; row < hiddenStory.GetLength(0); row++)
            {
                Console.WriteLine(hiddenStory[row, 0]);
                Console.WriteLine(hiddenStory[row, 1]);
                Console.WriteLine();
            }
        }

    }
}
        
    

