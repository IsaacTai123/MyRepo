using SellingSystem.Models.DataModels;

namespace SellingSystem.Models.Services
{
    public interface IMemberServicers
    {
        bool CheckTheMember(string userName, int pwd);
        bool CheckTimeOut(int memberId);
        Selling_requestModel.MemberOnlineModel GetMemberFromDic(int memberId);
        long GetTimestamp();
        void StoreMemberToDic(Selling_requestModel.Member member);
        bool CheckLogin(int memberId);
    }
}