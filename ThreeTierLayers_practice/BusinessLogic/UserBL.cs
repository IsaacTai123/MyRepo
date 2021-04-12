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
            // TODO - Validate the input codition before calling a method from the DataAccess Layer,
            // this ensures the data input is correct before proceedings and can often ensure that the ouputs are correct as well.

            return new UserDAL().AddUser(userBO);
        }
    }
}
