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
using Slapper;
using System.Dynamic;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Specialized;

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


            //// 把class 轉換成json 在把 json 轉成dicionary的 key, value
            //model parm = new model() { name = "jason", address = "street 6", currency = "YSL", money = "1000" };

            //string json = JsonConvert.SerializeObject(parm);
            //Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            //foreach (var item in dic)
            //{
            //    Console.WriteLine("{0},  {1}", item.Key, item.Value);
            //}


            // ****** LINQ  --> IEnumerable "Select" practice  *****
            //int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //int result = array.Where(x => x == 2).FirstOrDefault();
            //Console.WriteLine(result) ;

            //var select = array.Select(x => new
            //{
            //    number = x + "new string"
            //});
            //foreach (var item in select)
            //{
            //    Console.WriteLine(item.number);
            //}
            ////Console.WriteLine(response);


            //int[] numbers = { 2, 55, 67, 82, 99, 13 };
            //int[] result = numbers.Select((numbers, i) => numbers * i).ToArray();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            //string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            //var query = fruits.Select((fruit, index) => new { index, str = fruit.Substring(0, index) });

            //foreach (var obj in query)
            //{
            //    Console.WriteLine("{0}", obj);
            //}


            /*
             This code produces the following output:

             {index=0, str=}
             {index=1, str=b}
             {index=2, str=ma}
             {index=3, str=ora}
             {index=4, str=pass}
             {index=5, str=grape}
            */

            List<Trainer> trainers = new List<Trainer>()
            {
                new Trainer(Teams.Valor, "Candela"),
                new Trainer(Teams.Valor, "Bob"),
                new Trainer(Teams.Mystic, "Blanche"),
                new Trainer(Teams.Valor, "Alice"),
                new Trainer(Teams.Instinct, "Spark"),
                new Trainer(Teams.Mystic, "Tom"),
                new Trainer(Teams.Dark, "Jeffrey")
            };

            ////目標：以Team分類，將同隊的訓練師集合成List<Trainer>，
            ////最終產出Dictionary<Teams, List<Trainer>>

            ////以前的寫法，跑迴圈加邏輯比對
            //var res1 = new Dictionary<Teams, List<Trainer>>();
            //foreach (var t in trainers)
            //{
            //    if (!res1.ContainsKey(t.Team))
            //        res1.Add(t.Team, new List<Trainer>());
            //    res1[t.Team].Add(t);
            //}

            ////新寫法，使用LINQ GroupBy
            //var res2 = trainers.GroupBy(x => x.Team).ToDictionary(o => o.Key, o => o.ToList());


            // ****** Using Slapper Automapper
            //var dic = new Dictionary<string, Object>()
            //                            {
            //                                { "Id", 1 },
            //                                { "FirstName", "Clark" },
            //                                { "LastName", "Kent" }
            //                            };

            //var person = AutoMapper.Map<Person>(dic);
            //var personJson = JsonConvert.SerializeObject(person, Formatting.Indented);
            //Console.WriteLine(personJson);

            //// ***** Dynamic type
            //dynamic test = new ExpandoObject();

            //test.Name = "john";
            //test.Age = 3;

            //Console.WriteLine(test.Name);
            //Console.WriteLine(test.Age);


            //test testing = new test();
            //testing.secondMethod();

            //Console.WriteLine(Days.Mon.GetDescription());
            NameValueCollection list = new NameValueCollection()
            {
                { "name", "isaac" },
                { "age", "23" }
            };

            Dictionary<string, int> sample = new Dictionary<string, int>()
            {
                { "age", 3 },
                { "number", 223333 }
            };

            sample.TryGetValue("age", out int result);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine(list[0]);


        }

       public class test
        {
            public int id;
            public string name;

            public void printresult(string Name)
            {
                name = Name;
                Console.WriteLine(name);
            }

            public void secondMethod()
            {
                printresult("people");
            }
        }
        

        public enum Days
        {
            [Description("Today is Monday")]
            Mon,

            [Description("Today is Tuesday")]
            Tue,

            [Description("Today is thirthday")]
            Thirth
        }


        public class Person
        {
            public int Id;
            public string FirstName;
            public string LastName;
        }

        public enum Teams
        {
            Valor, 
            Mystic,
            Instinct,
            Dark
        }

        public class Trainer
        {
            public Teams Team;
            public string Name;
            public Trainer(Teams team, string name)
            {
                Team = team; 
                Name = name;
            }
        }



        public class model
        {
            public string name { get; set; }
            public string address { get; set; }
            public string money { get; set; }
            public string currency { get; set; }
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
    public static class EnumExtension
    {
        public static string GetDescription(this Enum source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}




