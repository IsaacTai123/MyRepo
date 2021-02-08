using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SellingSystem.Models.DataModels.Selling_requestModel;
using MySql.Data.MySqlClient;
using Dapper;

namespace SellingSystem.Models.DB
{
    public class DataAccess
    {
        public List<Member> GetAllMembers()
        {
            using (MySqlConnection conn = new MySqlConnection(Helper.CnnVal("localDB")))
            {
                var output = conn.Query<Member>($"SELECT * FROM `memberData`").ToList();
                return output;
            }
        }

        public List<Member> GetMember(int memberId)
        {
            using (MySqlConnection conn = new MySqlConnection(Helper.CnnVal("localDB")))
            {
                var output = conn.Query<Member>($"SELECT * FROM `memberData` WHERE id = '{memberId}'").ToList();
                return output;
            }
        }

        public List<KeyIV> GetKeyIV(string uniqueId)
        {
            using (MySqlConnection conn = new MySqlConnection(Helper.CnnVal("localDB")))
            {
                var output = conn.Query<KeyIV>($"SELECT * FROM `Keyiv` WHERE uniqueId = '{uniqueId}'").ToList();
                return output;
            }
        }

        public void UpdateWallet(int value, int id)
        {
            using (MySqlConnection conn = new MySqlConnection(Helper.CnnVal("localDB")))
            {
                conn.Execute($"UPDATE `memberData` SET wallet = '{value}' WHERE id = {id};");
            }
        }
    }
}
