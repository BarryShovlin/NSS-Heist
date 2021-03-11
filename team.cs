using System.Collections.Generic;

namespace Heist
{
    public class Team
    {
        public List<Member> Members = new List<Member>();

        public void AddMember(Member member)
        {
            Members.Add(member);
        }
    }
}