using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using MySql.Data.MySqlClient;

// https://www.youtube.com/watch?v=Et2khGnrIqc&t=1s

namespace FormUI
{
    public class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            //throw new NotFiniteNumberException(); // allow us to compile the application while we're working on it

            // this using statement is different than the outside, this allow me to call some code like with a connection and it said as soon you're done the using statement destory that connection
            // so the using statement is very helpful for making sure we don't leave connections open to our server
            //SQL
            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB"))) // we create a new connection to our SQL database
            //{
            //    //not safe way doing this (we need to prevent sql injection)
            //    //var output = connection.Query<Person>($"SELECT * FROM WHERE LastName = '{ lastName }'").ToList();
                
            //    // use Store Procedures
            //    var output = connection.Query<Person>("dbo.People_GetByLastName @LastName", new { Lastname = lastName }).ToList();

            //    // new { Lastname = lastName } this is a new class instance 

            //    return output;
            //}

            //MySQL
            using (MySqlConnection conn = new MySqlConnection(Helper.CnnVal("SampleMySQLDB"))) // we create a new connection to our SQL database
            {
                var output = conn.Query<Person>($"SELECT * FROM `person` WHERE LastName = '{ lastName }'").ToList(); //Query<Person> means i want to ask for person data back
                return output;
            }
        }

        public void InsertPerson(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            //throw new NotImplementedException();

            //using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB"))) // we create a new connection to our SQL database
            //{
            //    //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber };
            //    List<Person> people = new List<Person>();

            //    people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber });

            //    conn.Execute("dbo.People_Insert @FirstName, @LastName, @EmailAddress, @PhoneNumber", people);
            //}

            using (MySqlConnection conn = new MySqlConnection(Helper.CnnVal("SampleMySQLDB"))) // we create a new connection to our SQL database
            {
                List<Person> people = new List<Person>();
                people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber });

                conn.Execute($"INSERT INTO `person` VALUES (DEFAULT, '{firstName}', '{lastName}', '{emailAddress}', '{phoneNumber}')");
            }
        }
    }
}
