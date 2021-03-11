using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {

            Team HeistTeam = new Team();

            bool planning = true;

            while (planning)
            {
                Console.WriteLine("Plan your heist!");
                Console.WriteLine();

                Console.Write("Enter a team member's name: ");
                string name = Console.ReadLine();
                if (name == "")
                {
                    break;
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

                    Console.WriteLine(name);
                    Console.WriteLine(MemberSkill);
                    Console.WriteLine(courageFactor);

                    Console.WriteLine(HeistTeam.Members.Count);

                    foreach (Member m in HeistTeam.Members)
                    {
                        Console.WriteLine($"{m.Name} Skill level: {m.Skill}  courage level: {m.Courage}");
                    }
                }
            }


        }
    }
}
