using System;
using System.Collections.Generic;
using System.Text;

namespace LINQFromVanket
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }

        public static List<Student> GetAllStudents()
        {
            List<Student> listStudents = new List<Student>
            {
                new Student
                {
                    StudentID = 101,
                    Name = "Tome",
                    TotalMarks = 800
                },
                new Student
                {
                    StudentID = 102,
                    Name = "Mary",
                    TotalMarks = 900
                },
                new Student
                {
                    StudentID = 103,
                    Name = "Valarie",
                    TotalMarks = 800
                },
                new Student
                {
                    StudentID = 104,
                    Name = "John",
                    TotalMarks = 800
                },
                new Student
                {
                    StudentID = 105,
                    Name = "John",
                    TotalMarks = 800
                }
            };
            return listStudents;
        }
    }
}
