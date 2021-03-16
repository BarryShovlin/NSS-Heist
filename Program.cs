using System;
using System.Collections.Generic;
using System.Threading;

namespace Heist
{
    class Program
    {
        static void Main()
        {

            Team HeistTeam = new Team();
            int Diff = 0;
            Difficulty();
            void Difficulty()
            {
                Console.WriteLine("Choose your difficulty");
                Console.WriteLine("[1] Cake Walk, [2] A Little Sweat, [3] Shouldn't Try This, [4] Daniel Ocean Wouldn't Even Think About It");
                string playerInput = Console.ReadLine();
                try
                {
                    int input = Int32.Parse(playerInput);
                    if (input == 1)
                    {
                        Diff = 50;
                    }
                    else if (input == 2)
                    {
                        Diff = 100;
                    }
                    else if (input == 3)
                    {
                        Diff = 150;
                    }
                    else if (input == 4)
                    {
                        Diff = 500;
                    }
                    else
                    {
                        Difficulty();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Please enter a valid choice");
                    Main();
                }
            }

            Console.WriteLine("Plan your heist!");
            Console.WriteLine();

            bool planning = true;

            while (planning)
            {
                Console.Write("Enter a team member's name: ");
                string name = Console.ReadLine();

                int Skillset()
                {
                    Console.Write($"Enter {name}'s skill level (number): ");
                    string MemberSkill = Console.ReadLine();
                    try
                    {
                        int skill = Int32.Parse(MemberSkill);
                        return skill;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Please enter a number");
                        Skillset();
                        return 0;
                    }
                }
                int skill = Skillset();


                decimal Courage()
                {
                    Console.Write($"Enter {name}'s courage factor (0.0-2.0): ");
                    string courageFactor = Console.ReadLine();

                    try
                    {
                        decimal courage = Decimal.Parse(courageFactor);
                        if (courage > 2)
                        {
                            Console.WriteLine($"{name} isn't that corageous!");
                            Courage();
                            return courage;
                        }
                        else
                        {
                            return courage;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Enter any number between 0.0 and 2.0.  {ex.Message}");
                        Courage();
                        return 0;
                    }
                }

                decimal returnedCourage = Courage();


                Member member = new Member(name, skill, returnedCourage);
                HeistTeam.AddMember(member);

                Console.WriteLine("Add another member? [y/n]");
                string addOn = Console.ReadLine();
                if (addOn == "y")
                {
                    planning = true;

                }
                else
                {
                    planning = false;
                }

            }
            Console.Clear();
            Console.WriteLine("How many banks you looking to rob today?");
            int trials = Int32.Parse(Console.ReadLine());
            int success = 0;
            int fail = 0;
            int HeistNumber = 1;

            while (trials > 0)
            {
                int BankDiffLevel = Diff;
                Random Luck = new Random();
                int teamLuck = Luck.Next(-10, 10);
                BankDiffLevel = 100 + teamLuck;


                int teamSkill = 0;

                foreach (Member m in HeistTeam.Members)
                {
                    teamSkill = teamSkill + m.Skill;
                }


                if (teamSkill >= BankDiffLevel)
                {
                    Console.WriteLine($"Heist number {HeistNumber}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Your heist team's combined skill level is {teamSkill}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"The bank's difficulty level is.....");
                    Thread.Sleep(2000);
                    Console.WriteLine($"{BankDiffLevel}");
                    Thread.Sleep(500);
                    Console.WriteLine("Sucess, you done did it!");
                    success = success + 1;
                    Thread.Sleep(3000);

                }
                else
                {
                    Console.WriteLine($"Heist number {HeistNumber}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Your heist team's combined skill level is {teamSkill}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"The bank's difficulty level is.....");
                    Thread.Sleep(2000);
                    Console.WriteLine($"{BankDiffLevel}");
                    Thread.Sleep(500);
                    Console.WriteLine("This is not good...");
                    fail = fail + 1;
                    Thread.Sleep(3000);
                }
                trials = trials - 1;
                HeistNumber = HeistNumber + 1;

            }
            Thread.Sleep(3000);
            Console.Clear();
            if (success == 0)
            {
                Console.WriteLine("You've manage to blow it on every heist attempt.  Get a good attorney and a better team next time...");
            }
            else
            {
                Console.WriteLine($"You have successfully robbed {success} banks!");
                if (fail == 0)
                {
                    Console.WriteLine("And you managed to outsmart the po-po.  Nice work, playboy.");
                }
                else if (fail == 1)
                {
                    Console.WriteLine("But you got caught robbing one of them....  See you in 6-8 months...");
                }
                else
                {
                    Console.WriteLine($"But you got caught robbing {fail} banks.  Better call ma and tell her you won't make it home for supper");
                }
            }
            Console.WriteLine("Care to try again?  [y/n]");
            Console.Write(">");
            string again = Console.ReadLine();
            if (again == "y")
            {
                Main();
            }

        }
    }
}




