using SellingSystem.Models.DB;
using static SellingSystem.Models.DataModels.Selling_requestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SellingSystem.Models.Services
{
    public class MemberServicers : IMemberServicers
    {
        private static Dictionary<int, MemberOnlineModel> onlineMember = new Dictionary<int, MemberOnlineModel>(); //create a dictionary to store the login member

        public bool CheckTheMember(string userName, int pwd)
        {
            //var memberList = new MemberModel().MemberList();//_memberModel.MemberList(); // get the list of the member
            DataAccess getMemberList = new DataAccess();
            var memberList = getMemberList.GetAllMembers();

            // compare to the list see is the person a member
            foreach (var member in memberList)
            {
                if ((string)member.name == userName && (int)member.password == pwd)
                {
                    StoreMemberToDic(member);
                    return true;
                }
            }

            return false;
        }

        public void StoreMemberToDic(Member member)
        {
            if(onlineMember.ContainsKey(member.id))
            {
                onlineMember.Remove(member.id);
            }
            onlineMember.Add(member.id, new MemberOnlineModel
            {
                member = member,
                timestamp = GetTimestamp()
            });
        }

        public MemberOnlineModel GetMemberFromDic(int memberId)
        {
            MemberOnlineModel memberFromDic = onlineMember[memberId];
            return memberFromDic;
        }

        public long GetTimestamp()
        {
            long Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            return Timestamp;
        }

        public bool CheckLogin(int memberId)
        {
            MemberOnlineModel template = new MemberOnlineModel();
            onlineMember.TryGetValue(memberId, out template);

            if (template == null)
            {
                //havn't sign in
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckTimeOut(int memberId) // everytime user make a move we will check the timeout
        {
            MemberOnlineModel template = new MemberOnlineModel();
            onlineMember.TryGetValue(memberId, out template);

            long currentTime = GetTimestamp();

            // if the user havn't do anything in 3 minutes then we log him out
            if (template != null && (currentTime - template.timestamp) >= 180)
            {
                onlineMember.Remove(memberId);
                return false;
            }
            else
            {
                onlineMember.Remove(memberId);
                template.timestamp = currentTime;
                onlineMember.Add(memberId, template);
                return true;
            }
        }
    }
}
