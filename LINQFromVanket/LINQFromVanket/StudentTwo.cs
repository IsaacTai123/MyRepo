using System;
using System.Collections.Generic;
using System.Text;

namespace LINQFromVanket
{
    public class StudentTwo
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public List<string> Subjects { get; set; }

        public static List<StudentTwo> GetAllStudetns()
        {
            List<StudentTwo> listStudents = new List<StudentTwo>
        {
            new StudentTwo
            {
                Name = "Tom",
                Gender = "Male",
                Subjects = new List<string> { "ASP.NET", "C#" }
            },
            new StudentTwo
            {
                Name = "Mike",
                Gender = "Male",
                Subjects = new List<string> { "ADO.NET", "C#", "AJAX" }
            },
            new StudentTwo
            {
                Name = "Pam",
                Gender = "Female",
                Subjects = new List<string> { "WCF", "SQL Server", "C#" }
            },
            new StudentTwo
            {
                Name = "Mary",
                Gender = "Female",
                Subjects = new List<string> { "WPF", "LINQ", "ASP.NET" }
            },
        };

            return listStudents;
        }
    }
}
