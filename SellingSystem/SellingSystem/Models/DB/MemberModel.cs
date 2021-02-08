using static SellingSystem.Models.DataModels.Selling_requestModel;
using System.Collections.Generic;

namespace SellingSystem.Models.DB
{
    public class MemberModel : IMemberModel
    {
        public List<Member> MemberList() // create a list of the member
        {
            List<Member> member = new List<Member>();
            member.Add(new Member { id = 1, name = "john", password = 123456, email = "email@gmail.com", wallet = 0 });
            member.Add(new Member { id = 2, name = "jason", password = 234567, email = "email@gmail.com", wallet = 0 });
            member.Add(new Member { id = 3, name = "Anny", password = 345678, email = "email@gmail.com", wallet = 0 });
            member.Add(new Member { id = 4, name = "jimmy", password = 456789, email = "email@gmail.com", wallet = 0 });

            return member;
        }

        public static List<Member> memberlist2 = new List<Member>()
        {
            new Member() { id = 1, name = "john", password = 123456, email = "email@gmail.com", wallet = 0},
            new Member() { id = 2, name = "jason", password = 234567, email = "email@gmail.com", wallet = 0},
            new Member() { id = 3, name = "Anny", password = 345678, email = "email@gmail.com", wallet = 0 },
            new Member() { id = 4, name = "jimmy", password = 456789, email = "email@gmail.com", wallet = 0}
        };
    }
}
