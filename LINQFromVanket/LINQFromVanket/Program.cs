using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQFromVanket
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int? result = null;

            //// find the min even number in array without LINQ
            //foreach (int i in Numbers)
            //{
            //    if (i % 2 == 0)
            //    {
            //        if (!result.HasValue || i < result)
            //        {
            //            result = i;
            //        }
            //    }

            //}

            //// using LINQ "Aggregate Functions"
            //int resultLINQ = Numbers.Where(x => x % 2 == 0).Min(); //

            //Console.WriteLine(resultLINQ);

            //-------------------------------------------------------------------------------------------------------------------

            //string[] countries = { "India", "USA", "UK" };
            //int mincount = countries.Min(x => x.Length);

            //Console.WriteLine("The shortest country name has {0} characters in its name", mincount);


            //-------------------------------------------------------------------------------------------------------------------

            ////Aggregate function
            ////without LINQ
            //string[] countries = { "India", "USA", "UK", "Canada", "Australia" };
            //string result = string.Empty;

            //foreach (string str in countries)
            //{
            //    result = result + str + ", ";
            //}

            //int lastIndex = result.LastIndexOf(",");
            //result = result.Remove(lastIndex);
            //Console.WriteLine(result);

            ////With LINQ
            ////這個Aggregate裡面的 a代表India, b代表USA, 所以把這兩個合起來 然後依序下去
            //string results = countries.Aggregate((a, b) => a + ", " + b);
            //Console.WriteLine(results);


            //int[] Numbers = { 2, 3, 4, 5 };
            //int resultInt = Numbers.Aggregate((a, b) => a * b);
            //Console.WriteLine(resultInt);

            //-------------------------------------------------------------------------------------------------------------------

            ////Orderby one item
            //Console.WriteLine("Student names before sorting");

            //List<Student> students = Student.GetAllStudents();
            //foreach (Student s in students)
            //{
            //    Console.WriteLine(s.Name);
            //}
            //Console.WriteLine();

            //IEnumerable<Student> result = Student.GetAllStudents().OrderBy(s => s.Name);
            ////IEnumerable<Student> result = from student in Student.GetAllStudents()
            ////                              orderby student.Name
            ////                              descending
            ////                              select student;

            //Console.WriteLine("Student names after sorting");
            //foreach (Student s1 in result)
            //{
            //    Console.WriteLine(s1.Name);
            //}

            //-------------------------------------------------------------------------------------------------------------------

            //// Orderby multiple item
            ////IOrderedEnumerable<Student> result = Student.GetAllStudents().OrderBy(s => s.TotalMarks).ThenBy(s => s.Name).ThenByDescending(s => s.StudentID);
            //IOrderedEnumerable<Student> result = from s in Student.GetAllStudents()
            //                                     orderby s.TotalMarks, s.Name descending, s.StudentID descending
            //                                     select s;


            //foreach (Student s in result)
            //{
            //    Console.WriteLine(s.TotalMarks + "\t" + s.Name + "\t" + s.StudentID);
            //}


            //-------------------------------------------------------------------------------------------------------------------

            IEnumerable<Student> students = Student.GetAllStudents();
            Console.WriteLine("Before calling Reverse method");
            foreach (Student s in students)
            {
                Console.WriteLine(s.StudentID + "\t" + s.Name + "\t" + s.TotalMarks);
            }
            
            Console.WriteLine();
            IEnumerable<Student> result = students.Reverse();
            Console.WriteLine("Before calling Reverse method");
            foreach (Student s in result)
            {
                Console.WriteLine(s.StudentID + "\t" + s.Name + "\t" + s.TotalMarks);
            }
        }
    }
}
