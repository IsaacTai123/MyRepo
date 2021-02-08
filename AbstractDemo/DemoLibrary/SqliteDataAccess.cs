using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary
{
    public class SqliteDataAccess : DataAccess
    {
        public override string LoadConnectionString(string name)
        {
            string output = base.LoadConnectionString(name); //you don't have to do "base" you can just do your own code instead, in this case i'm going add the extra stuff to the existed code.

            output += " (from SQLite)";

            return output;
        }

        public override void LoadData(string sql)
        {
            Console.WriteLine("Loading SQLite Data");
        }

        public override void SaveData(string sql)
        {
            Console.WriteLine("Saving data to SQLite");
        }
    }
}
