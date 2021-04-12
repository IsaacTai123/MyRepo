using BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using Dapper;

namespace DataAccess
{
    public class UserDAL
    {

        public CustomBO AddUser(UserBO user)
        {
            CustomBO newUser = new CustomBO();
            

            // TODO - finish connect to database
            using (IDbConnection con = new System.Data.SqlClient.SqlConnection(CnnString("UserDB")))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@name", user.UserName);
                p.Add("@Address", user.UserAddress);
                p.Add("@Email", user.UserEmail);
                p.Add("@phone", user.UserPhone);

                // TODO - push data to database
                try
                {
                    con.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);
                    newUser.CustomMessage = "Data successfully added!!";
                    newUser.CustomMessageNumber = 1;
                }
                catch (Exception e)
                {
                    newUser.CustomMessage = "There is some problem to add user!!";
                    newUser.CustomMessageNumber = 0;
                }
            }

            return newUser;
        }

        public string CnnString(string name)
        {
            var output = ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;
            return output;
        }
    }
}
