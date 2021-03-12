using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {

            Team HeistTeam = new Team();

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

                    Console.Write($"Enter {name}'s courage factor (0.0-2.0): ");
                    string courageFactor = Console.ReadLine();
                    decimal courage = Decimal.Parse(courageFactor);


                    Member member = new Member(name, skill, courage);
                    HeistTeam.AddMember(member);

                    // Console.WriteLine(name);
                    // Console.WriteLine(MemberSkill);
                    // Console.WriteLine(courageFactor);


                    // Console.WriteLine("----------------------------");
                    // Console.WriteLine("");
                    // Console.WriteLine("Your Team Roster");

                    // Console.WriteLine($"Total team members: {HeistTeam.Members.Count}");

                    // foreach (Member m in HeistTeam.Members)
                    // {
                    //     Console.WriteLine("----------------------------");
                    //     Console.WriteLine($"{m.Name}   ");
                    //     Console.WriteLine($"Skill level: {m.Skill}");
                    //     Console.WriteLine($"Courage level: {m.Courage}");
                    //     Console.WriteLine("");
                    // }
                }
            }
            int BankDiffLevel = 100;

            int teamSkill = 0;

            foreach (Member m in HeistTeam.Members)
            {
                teamSkill = teamSkill + m.Skill;
            }

            if (teamSkill >= BankDiffLevel)
            {
                Console.WriteLine("Sucess, you done did it!");
            }
            else
            {
                Console.WriteLine("You in jail");
            }


        }
    }
}



