//using System;

//namespace blackBoard
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//        }
//    }
//}



// C# program to divide the employees 
// in the groups according to their 
// language 

using System; 
using System.Linq; 
using System.Collections.Generic;
using Newtonsoft.Json;
using NLog;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Net;

namespace blackBoard
{
    // Employee details 
    public class Employee
    {

        public int emp_id
        {
            get;
            set;
        }

        public string emp_name
        {
            get;
            set;
        }

        public string emp_gender
        {
            get;
            set;
        }

        public string emp_hire_date
        {
            get;
            set;
        }

        public int emp_salary
        {
            get;
            set;
        }
        public string emp_lang
        {
            get;
            set;
        }
    }

    class GFG
    {

        // Main method 
        static public void Main()
        {
            //// Extension practice
            //List<int> Number = new List<int> { 1, 2, 3 };
            //IEnumerable<int> EventNumber = Enumerable.Where(Number, n => n % 2 == 0);

            //string strName = "programe";
            //string result = strName.ChangeFirstLetterCase();


            //// -------------------------------------------------------------------------------------


            //List < Employee > emp = new List<Employee>() {

            //new Employee() {emp_id = 209, emp_name = "Anjita", emp_gender = "Female",
            //    emp_hire_date = "12/3/2017", emp_salary = 20000, emp_lang = "Ruby"},

            //new Employee() {emp_id = 210, emp_name = "Soniya", emp_gender = "Female",
            //    emp_hire_date = "22/4/2018", emp_salary = 30000, emp_lang = "Java"},

            //new Employee() {emp_id = 211, emp_name = "Rohit", emp_gender = "Male",
            //emp_hire_date = "3/5/2016", emp_salary = 40000, emp_lang = "Perl"},

            //new Employee() {emp_id = 212, emp_name = "Supriya", emp_gender = "Female",
            //        emp_hire_date = "4/8/2017", emp_salary = 40000, emp_lang = "Java"},

            //new Employee() {emp_id = 213, emp_name = "Anil", emp_gender = "Male",
            //emp_hire_date = "12/1/2016", emp_salary = 40000, emp_lang = "C#"},

            //new Employee() {emp_id = 214, emp_name = "Anju", emp_gender = "Female",
            //    emp_hire_date = "17/6/2015", emp_salary = 50000, emp_lang = "C#"},
            //};

            //// Query to divide the employees in 
            //// the groups according to their 
            //// language using GroupBy method in 
            //// the method syntax 
            //var res = emp.GroupBy(e => e.emp_lang);

            //foreach (var val in res)
            //{

            //    // Here language is the key value 
            //    Console.WriteLine("Group By Language: {0}", val.Key);

            //    // Display name of the employees 
            //    // Inner collection according to 
            //    // the key value 
            //    foreach (Employee e in val)
            //    {
            //        Console.WriteLine("Employee Name: {0}", e.emp_name);
            //    }
            //}


            // test JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            //modelTest model = new modelTest { number = 3, name = "jason" };
            //string modeljson = JsonConvert.SerializeObject(model);

            //Dictionary<string, string> dir = JsonConvert.DeserializeObject<Dictionary<string, string>>(modeljson);
            //string output = "";
            //dir.TryGetValue("name", out output);
            //Console.WriteLine(output);

            //foreach (var item in dir)
            //{
            //    if (item.Value == "jason")
            //    {
            //        Console.WriteLine("this is name field");
            //    }
            //    if (item.Value == "3")
            //    {
            //        Console.WriteLine("this is number field");
            //    }
            //}

            //Console.WriteLine(dir.ContainsKey("number") == true ? "it is exists" : "it is not exists");

            //modelTest model = new modelTest { number = 3, name = "jason" };
            //string modeljson = JsonConvert.SerializeObject(model);

            //string transUrl = "";

            //NLogHelper.Info(JsonConvert.SerializeObject(model, Formatting.Indented));
            //Redirect(transUrl);

            //// Using Statement (using 陳述式)
            //string manyLines = @"This is line one
            //                    This is line two
            //                    Here is line three
            //                    The penultimate line is line four
            //                    This is the final, fifth line.";

            //using var reader = new StringReader(manyLines);

            //    string? item;
            //    do
            //    {
            //        item = reader.ReadLine();
            //        Console.WriteLine(item);
            //    } while (item != null);

            //int num = 4;
            //if (num > 89) Console.WriteLine("{0}", num);
            //Console.WriteLine("This still work");

            //HttpAsync();
            //Console.WriteLine("Hello World!");
            //Console.Read();

            //to see way we need get and set property
            //Myclass test = new Myclass();
            //Console.WriteLine(test.output());

            //test.MyProperty = "string";
            //Console.WriteLine(test.output(), "\r\n");


            //Mylist test = new Mylist();
            //test.modellist = new List<modelTest>() {
            //    new modelTest()
            //    {
            //        name = "john",
            //        number = 222
            //    },
            //    new modelTest()
            //    {
            //        name = "Tom",
            //        number = 333
            //    },
            //    new modelTest()
            //    {
            //        name = "cora",
            //        number = 444
            //    },
            //};

            //test.modellist.Add(new modelTest() { name = "john", number = 222 });



            //foreach (modelTest list in test.modellist)
            //{
            //    Console.WriteLine($"{list.name}, {list.number}");
            //}

            //Myclass.TestStatic();
            //TestStatic.GetDataBack();


            //試著獲取client ip

            //var remoteIp = HttpContextAccessor.HttpContext.Connection.RemoteIpAddress;
            //Console.WriteLine(remoteIp);


            //// using Regex to get the specific thing you want
            //StringBuilder input = new StringBuilder();
            //input.AppendLine("A bbbb A");
            //input.AppendLine("C bbbb C");

            //string pattern = @"^\w"; //pattern will be any one word character 
            //Console.WriteLine(input.ToString());
            //MatchCollection matchCol = Regex.Matches(input.ToString(), pattern, RegexOptions.Multiline);
            //foreach (Match item in matchCol)
            //{
            //    Console.WriteLine("結果：{0}", item.Value);
            //}



            //// testing calling static method and nonestatic
            //NoneStatic non = new NoneStatic();
            //non.test();


            //staticmethod.test();

            //// calculate test
            //int rounds = 4;
            //List<int> sample = new List<int>();

            //if (rounds > 1)
            //{
            //    for (int i = rounds; i > 1; i--)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}


            //// 試著用用 is operator => E is T v
            //int i = 23;
            //object iBoxed = i;
            //int? jnullable = 7;

            //if (iBoxed is int a && jnullable is int b)
            //{
            //    Console.WriteLine(a + b); // output 30
            //}

            //int? number = iBoxed as int?;
            //if (number != null)
            //{
            //    Console.WriteLine(number.GetType());
            //}


            //int? ii = iBoxed is int ? (int)iBoxed : (int?)null;
            //if (ii != null)
            //{
            //    Console.WriteLine(ii.GetType());
            //}


            //// typeof Operator
            //void PrintType<T>() => Console.WriteLine(typeof(T));

            //Console.WriteLine(typeof(List<string>));
            //PrintType<int>();
            //PrintType<System.Int32>();
            //PrintType<Dictionary<int, char>>();
            //// Output:
            //// System.Collections.Generic.List`1[System.String]
            //// System.Int32
            //// System.Int32
            //// System.Collections.Generic.Dictionary`2[System.Int32,System.Char]
            ///

            
        }

        class Demo { };


        private static IHttpContextAccessor HttpContextAccessor;
        public static void configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        private static readonly HttpClient _client = new HttpClient();

        public static async void HttpAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                //using (var client = new HttpClient())
                //{
                    var result = await _client.GetAsync("http://www.baidu.com");
                    Console.WriteLine($"{i}:{result.StatusCode}");
                //}
            }
        }

        public class modelTest
        {
            public int number { get; set; }
            public string name { get; set; }
        }

        public class NLogHelper
        {
            private static Logger nLogger = LogManager.GetCurrentClassLogger();
            public static void Info(string msg)
            {
                nLogger.Info(msg);
            }
        }

        public class Mylist
        {
            public List<modelTest> modellist { get; set; } = new List<modelTest>();
        }

        public class Myclass
        {
            
            private string myfield = "default";

            public string MyProperty
            {
                get
                {
                    return myfield;
                }
                set
                {
                    myfield = value;
                }
            }

            public string output()
            {
                return myfield;
            }

            public static void TestStatic()
            {
                Console.WriteLine("this is stsatic method");
            }
        }

        public class TestStatic
        {
            public static string GetDataBack()
            {
                var str = "databack";
                Console.WriteLine("This is a string");
                return str;
            }
        }


        public class NoneStatic
        {
            public void test()
            {
                Console.WriteLine("nonestatic");
            }
        }

        public class staticmethod
        {
            public static void test()
            {
                Console.WriteLine("static");
            }
        }
    }
}




