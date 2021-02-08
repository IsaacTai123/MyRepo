using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary
{
    public class SqlDataAccess : DataAccess
    {
        public override string LoadConnectionString(string name)
        {
            return base.LoadConnectionString(name);
        }

        public override void LoadData(string sql)
        {
            Console.WriteLine("Loading Microsoft SQL Data");
        }

        public override void SaveData(string sql)
        {
            Console.WriteLine("Saving data to Microsoft SQL Server");
        }
    }
}
