using static SellingSystem.Models.DataModels.Selling_requestModel;
using System.Collections.Generic;

namespace SellingSystem.Models.DB
{
    public interface IMemberModel
    {
        List<Member> MemberList();
    }
}