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

            //IEnumerable<Student> students = Student.GetAllStudents();
            //Console.WriteLine("Before calling Reverse method");
            //foreach (Student s in students)
            //{
            //    Console.WriteLine(s.StudentID + "\t" + s.Name + "\t" + s.TotalMarks);
            //}

            //Console.WriteLine();
            //IEnumerable<Student> result = students.Reverse();
            //Console.WriteLine("Before calling Reverse method");
            //foreach (Student s in result)
            //{
            //    Console.WriteLine(s.StudentID + "\t" + s.Name + "\t" + s.TotalMarks);
            //}


            //-------------------------------------------------------------------------------------------------------------------
            //// **** Select & Selectmany
            //IEnumerable<List<String>> result = StudentTwo.GetAllStudetns().Select( x => x.Subjects );
            //foreach (List<string> stringList in result)
            //{
            //    foreach (string str in stringList)
            //    {
            //        Console.WriteLine(str);
            //    }
            //}

            //IEnumerable<String> resultTwo = StudentTwo.GetAllStudetns().SelectMany(x => x.Subjects);
            //foreach (string str in resultTwo)
            //{
            //    Console.WriteLine(str);
            //}

            //-------------------------------------------------------------------------------------------------------------------
            //// ***** Groupby
            //var employeeGroups = Employee.GetAllEmployees().GroupBy(x => x.Department);

            //foreach (var group in employeeGroups)
            //{
            //    Console.WriteLine("{0}, {1} ", group.Key, group.Count());
            //    Console.WriteLine("-------------------");

            //    foreach (var employee in group)
            //    {
            //        Console.WriteLine(employee.Name + "\t" + employee.Department);
            //    }
            //    Console.WriteLine();
            //}

            //var employeeGroups = Employee.GetAllEmployees()
            //                                      .GroupBy(x => x.Department)
            //                                      .OrderBy(g => g.Key)
            //                                      .Select(g => new
            //                                      {
            //                                          Key = g.Key,
            //                                          Employee = g.OrderBy(x => x.Name)
            //                                      });

            //foreach (var group in employeeGroups)
            //{
            //    Console.WriteLine("{0}, {1} ", group.Key, group.Employee.Count());
            //    Console.WriteLine("-------------------");

            //    foreach (var employee in group.Employee)
            //    {
            //        Console.WriteLine(employee.Name + "\t" + employee.Department);
            //    }
            //    Console.WriteLine();
            //}

            //-------------------------------------------------------------------------------------------------------------------
            //// **** Groupby Multiple keys
            var employeeGroups = from p in Employee.GetAllEmployees()
                                                     group p by new { p.Department, p.Gender } into eGroup
                                                     orderby eGroup.Key.Department, eGroup.Key.Gender
                                                     select new
                                                     {
                                                         Department = eGroup.Key.Department,
                                                         Gender = eGroup.Key.Gender,
                                                         Employee = eGroup.OrderBy(x => x.Name)
                                                     };

            // or you can use the object you created
            var employeeGroupss = from p in Employee.GetAllEmployees()
                                                     group p by new { p.Department, p.Gender } into eGroup
                                                     orderby eGroup.Key.Department, eGroup.Key.Gender
                                                     select new model
                                                     {
                                                         Name = eGroup.Key.Department,
                                                         Gender = eGroup.Key.Gender,
                                                         emp = eGroup.OrderBy(x => x.Name)
                                                     };


            //var employeeGroups = Employee.GetAllEmployees()
            //                                            .GroupBy(x => new { x.Department, x.Gender })
            //                                            .OrderBy(g => g.Key.Department).ThenBy(g => g.Key.Gender)
            //                                            .Select(t => new
            //                                            {
            //                                                Department = t.Key.Department,
            //                                                Gender = t.Key.Gender,
            //                                                Employee = t.OrderBy(e => e.Name)
            //                                            });

            foreach (var group in employeeGroups)
            {
                Console.WriteLine("{0} department  {1}  employees Count = {2}", group.Department, group.Gender, group.Employee.Count());
                Console.WriteLine("------------------------------------------------------");
                foreach (var employee in group.Employee)
                {
                    Console.WriteLine(employee.Name + "\t" + employee.Gender + "\t" + employee.Department);
                }
                Console.WriteLine();
            }


            //-------------------------------------------------------------------------------------------------------------------
            // ***** Anonymous methods in c#
            List<EmployeeTwo> listEmployees = new List<EmployeeTwo>()
            {
                new EmployeeTwo{ ID = 101, Name = "Mark"},
                new EmployeeTwo{ ID = 102, Name = "John"},
                new EmployeeTwo{ ID = 103, Name = "Mary"},
            };

            // * Standard way ~~
            // Step2
            //Predicate<EmployeeTwo> employeePredicate = new Predicate<EmployeeTwo>(FindEmployee);

            ////EmployeeTwo employee = listEmployees.Find(employeePredicate); // first way
            //EmployeeTwo employee = listEmployees.Find(emp => FindEmployee(emp)); // second way

            //Console.WriteLine("Id = {0} , Name = {1}", employee.ID, employee.Name);

            // * using anonymouse method
            //Predicate<EmployeeTwo> employeePredicate = delegate (EmployeeTwo emp) { return emp.ID == 102; };
            
            //EmployeeTwo employee = listEmployees.Find(employeePredicate);
            //Console.WriteLine("Id = {0} , Name = {1}", employee.ID, employee.Name);

            // * using anonymouse method and Lamdba expressions
            //Predicate<EmployeeTwo> employeePredicate = (EmployeeTwo emp) => { return emp.ID == 102; };
            //EmployeeTwo employee = listEmployees.Find(employeePredicate);
            //Console.WriteLine("Id = {0} , Name = {1}", employee.ID, employee.Name);
        }

        // Setp1
        public static bool FindEmployee(EmployeeTwo emp)
        {
            return emp.ID == 102;
        }

        public class model
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public IEnumerable<Employee> emp { get; set; }
        }
    }
}
