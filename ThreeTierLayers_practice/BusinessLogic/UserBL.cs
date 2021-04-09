using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class UserBL
    {
        public CustomBO AddUser(UserBO userBO)
        {
            return new UserDAL().AddUser(userBO);
        }
    }
}
