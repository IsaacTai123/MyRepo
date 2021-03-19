using Dapper;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Dapper_practice
{
    class Program
    {
        public class People
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailAddress { get; set; }
            public string CellphoneNumber { get; set; }
        }

        public class Team
        {
            public int Id { get; set; }
            public string Teamname { get; set; }
            //public int personId { get; set; }
        }

        public class TeamMember
        {
            public int Id { get; set; }
            public int TeamId { get; set; }
            public int personId { get; set; }
            public List<People> people { get; set; } //= new List<People>();
            public Team TeamName { get; set; }
        }

        public class Test
        {
            public int Id { get; set; }
            public Team TeamName { get; set; }
        }


        static void Main(string[] args)
        {
            string connectionString = "Server=.\\SQLEXPRESS01;Database=Tournaments;Trusted_Connection=True";



            //using (SqlConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
            //{
            //    string str = "select * from dbo.TeamMembers t inner join dbo.People p on t.PersonId = p.id inner join dbo.Teams tm on t.TeamId = tm.id";

            //    //IEnumerable response = con.Query<TeamModel>(str);
            //    //output = con.Query<People>(str).ToList();

            //    output = con.Query<People, Team, TeamMember, TeamMember>(str, (p, t, tm) =>
            //    {
            //        tm.peoples.Add(p);
            //        tm.TeamName = t;
            //        return tm;
            //    }).ToList();

            //}


            //using (SqlConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
            //{
            //    string str = "select * from dbo.TeamMembers t inner join dbo.Teams tm on t.TeamId = tm.id";

            //    List<TeamMember> result = con.Query<TeamMember, Team, TeamMember>(str, (tm, t) =>
            //    {
            //        tm.TeamName = t;
            //        return tm;
            //    }, splitOn: "PersonId").ToList();

            //    //List<People> result = con.Query<People>(str).ToList();

            //    foreach (TeamMember teamMember in result)
            //    {
            //        Console.WriteLine($"{ teamMember.TeamId } => { teamMember.TeamName.personId }");
            //    }
            //}

            //using (SqlConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
            //{
            //    string str = "select * from dbo.TeamMembers t inner join dbo.People p on t.PersonId = p.id where t.id between 5 AND 6";
            //    var teamDictionary = new Dictionary<int, TeamMember>();
            //    int i = 0;

            //    List<TeamMember> result = con.Query<TeamMember, People, TeamMember>(str, (teamMember, people) =>
            //    {
            //        Console.WriteLine($"EXECUTE TIME { i += 1 }");
            //        Console.WriteLine($"teamMember => { JsonConvert.SerializeObject(teamMember, Formatting.Indented) }");
            //        Console.WriteLine($"people => { JsonConvert.SerializeObject(people, Formatting.Indented) }");

            //        TeamMember teamEntry;
            //        if (!teamDictionary.TryGetValue(teamMember.TeamId, out teamEntry))
            //        {
            //            Console.WriteLine("inner executed");
            //            teamEntry = teamMember;

            //            teamEntry.people = new List<People>();
            //            teamDictionary.Add(teamMember.TeamId, teamEntry);
            //        }

            //        foreach (var item in teamDictionary)
            //        {
            //            Console.WriteLine($"key {item.Key}, value { JsonConvert.SerializeObject(item.Value, Formatting.Indented)}");
            //        }

            //        teamEntry.people.Add(people);

            //        Console.WriteLine(" --------------------------------------------------------------------------- ");
            //        foreach (var item in teamDictionary)
            //        {
            //            Console.WriteLine($"key {item.Key}, value { JsonConvert.SerializeObject(item.Value, Formatting.Indented)}");
            //        }

            //        Console.WriteLine($"teamEntry => { JsonConvert.SerializeObject(teamEntry, Formatting.Indented) }");
            //        Console.WriteLine("End");
            //        Console.WriteLine();


            //        return teamEntry;

            //    }).Distinct().ToList();

            //    //List<People> result = con.Query<People>(str).ToList();


            //    foreach (TeamMember teamMember in result)
            //    {
            //        foreach (People people in teamMember.people)
            //        {
            //            Console.WriteLine($"{ teamMember.TeamId } => { people.FirstName } { people.LastName }");
            //        }
            //    }
            //}

            //// ****** 三個table join 在一起, 這邊spliton是寫兩個 id, but 如果分割的字是一樣的 像這個例子 都是ID的話 可以不用寫兩個 用預設的一個"ID" 就可以了
            //using (SqlConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
            //{
            //    string sql = "select * from dbo.TeamMembers t inner join dbo.Teams tm on t.TeamId = tm.id inner join dbo.People p on t.PersonId = p.id";
            //    var teamInfo = new Dictionary<int, TeamMember>();


            //    List<TeamMember> response = con.Query<TeamMember, Team, People, TeamMember>(sql,map: (teamMember, team, people) =>
            //    {
            //        Console.WriteLine($"teamMember => { JsonConvert.SerializeObject(teamMember, Formatting.Indented) }");
            //        Console.WriteLine($"Team => { JsonConvert.SerializeObject(team, Formatting.Indented) }");
            //        Console.WriteLine($"People => { JsonConvert.SerializeObject(people, Formatting.Indented) }");

            //        TeamMember output;
            //        if (!teamInfo.TryGetValue(teamMember.TeamId, out output))
            //        {
            //            output = teamMember;
            //            output.people = new List<People>();
            //            teamInfo.Add(teamMember.TeamId, output);
            //        }

            //        output.people.Add(people);
            //        output.TeamName = team;

            //        return output;
            //    }, splitOn: "id,id").Distinct().ToList();


            //    Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
            //}



            //// **** 使用Multi-Result 的Query方式
            //using (SqlConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
            //{
            //    string sql = @"select * from dbo.TeamMembers t inner join dbo.People p on t.PersonId = p.id 
            //                   select * from dbo.TeamMembers t inner join dbo.Teams tm on t.TeamId = tm.id";
            //    var data = new Dictionary<int, TeamMember>();

            //    List<TeamMember> response;
            //    List<TeamMember> secondResponse;
            //    List<Team> model;

            //    using (var lists = con.QueryMultiple(sql))
            //    {
            //        response = lists.Read<TeamMember, People, TeamMember>(
            //            (teamMember, people) =>
            //            {
            //                TeamMember output;
            //                if (!data.TryGetValue(teamMember.TeamId, out output))
            //                {
            //                    output = teamMember;
            //                    output.people = new List<People>();
            //                    data.Add(teamMember.TeamId, output);
            //                }
            //                output.people.Add(people);

            //                return output;
            //            }, splitOn: "Id").Distinct().ToList();

            //        //model = lists.Read<Team>().ToList();

            //        secondResponse = lists.Read<TeamMember, Team, TeamMember>(
            //            (teamMember, team) =>
            //            {
            //                teamMember.TeamName = team;

            //                return teamMember;
            //            }, splitOn: "Id").ToList();

            //        foreach (var item in response)
            //        {
            //            foreach (var team in secondResponse)
            //            {
            //                if (item.TeamName == null && item.TeamId == team.TeamId)
            //                {
            //                    item.TeamName = team.TeamName;
            //                    break;
            //                }
            //            }
            //        }


            //    }

            //    Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
            //}




            // ***** Slapper.Automapping
            using (SqlConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                string sql = @"select tm.*,
		                        p.id as people_Id,
		                        p.FirstName as people_FirstName,
		                        p.Lastname as people_LastName,
		                        p.EmailAddress as people_EmailAddress,
		                        p.CellphoneNumber as people_CellphoneNumber,
		                        t.id as TeamName_Id,
		                        t.TeamName as TeamName_TeamName
                            from dbo.TeamMembers tm
                            inner join dbo.People p on tm.PersonId = p.id 
                            inner join dbo.Teams t on t.id = tm.TeamId";

                var dynamicRespose = con.Query<dynamic>(sql);

                // 這個是為了設定identifier, 因為預設只有id 或是 TypeName + Id 或是 TypeName + Nbr, 而這裡的identifier 都不符合上述的設定 所以要自己設定
                Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(TeamMember), new List<string> { "TeamId" });
                

                var TeamList = Slapper.AutoMapper.MapDynamic<TeamMember>(dynamicRespose).ToList();
                Console.WriteLine("end");
            }



            //// ***** 測試Dictionary 先丟進dictionary之後 後面再把值更新, 那麼最後Dictionary裡面的value會不會更新
            //Team t = new Team() { Id = 1, Teamname = "one" };
            //Test ts = new Test() { Id = 2 };

            //var dic = new Dictionary<int, Test>();
            //dic.Add(1, ts);


            //Console.WriteLine(" hello ");
            //ts.TeamName = t;

            //foreach (var item in dic)
            //{
            //    Console.WriteLine("{0}, {1}", item.Key, item.Value);
            //}
        }
    }
}
