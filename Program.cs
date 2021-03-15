using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main()
        {

            Team HeistTeam = new Team();
            int Diff = 0;

            Console.WriteLine("Choose your difficulty");
            Console.WriteLine("[1] Cake Walk, [2] A Little Sweat, [3] Shouldn't Try This, [4] Daniel Ocean Wouldn't Even Think About It");
            int playerInput = Int32.Parse(Console.ReadLine());
            if (playerInput == 1)
            {
                Diff = 50;
            }
            else if (playerInput == 2)
            {
                Diff = 100;
            }
            else if (playerInput == 3)
            {
                Diff = 150;
            }
            else if (playerInput == 4)
            {
                Diff = 500;
            }
            else
            {
                Main();
            }

            Console.WriteLine("Plan your heist!");
            Console.WriteLine();

            bool planning = true;

            while (planning)
            {
                if (HeistTeam.Members.Count >= 1)
                {
                    Console.WriteLine("Enter 'done' if your team is complete");
                }
                Console.Write("Enter a team member's name: ");
                string name = Console.ReadLine();
                if (name == "done")
                {
                    planning = false;
                }
                else
                {

                    Console.Write($"Enter {name}'s skill level (number): ");
                    string MemberSkill = Console.ReadLine();
                    int skill = Int32.Parse(MemberSkill);

                    decimal Courage()
                    {
                        Console.Write($"Enter {name}'s courage factor (0.0-2.0): ");
                        string courageFactor = Console.ReadLine();
                        decimal courage = Decimal.Parse(courageFactor);
                        if (courage > 2)
                        {
                            Console.WriteLine("You aren't that corageous!");
                            Courage();
                            return courage;
                        }
                        else
                        {
                            return courage;
                        }
                    }

                    decimal returnedCourage = Courage();


                    Member member = new Member(name, skill, returnedCourage);
                    HeistTeam.AddMember(member);


                }
            }
            Console.Clear();
            Console.WriteLine("How many banks you looking to rob today?");
            int trials = Int32.Parse(Console.ReadLine());
            int success = 0;

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
                    Console.WriteLine($"Your heist team's combined skill level is {teamSkill}");
                    Console.WriteLine($"The bank's difficulty level is {BankDiffLevel}.....");
                    Console.WriteLine("Sucess, you done did it!");
                    success = success + 1;
                }
                else
                {
                    Console.WriteLine($"Your heist team's combined skill level is {teamSkill}");
                    Console.WriteLine($"The bank's difficulty level is {BankDiffLevel}.....");
                    Console.WriteLine("You in jail");
                    success = success - 1;
                }
                trials = trials - 1;
            }
            Console.Clear();
            Console.WriteLine($"You have successfully robbed {success} banks!");
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



