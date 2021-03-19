using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ADO.Net_ConnectPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //ADO.NET由五大類庫組成,分別是:
            //1 Connection(用於建立與 資料庫的連線)
            //2 Command(用於執行SQL語句)
            //3 DataReader(用於讀取資料)
            //4 DataAdapter(用於填充把資料填充到DataSet)
            //5 DataSet(資料集, 用於程式中)


            //通常,從程式中訪問資料庫的方法是:
            //1 建立一個到資料庫的連線
            //2 開啟資料庫連線
            //3 建立ADO記錄集
            //4 從記錄集中提取需要的資料
            //5 關閉記錄集
            //6 關閉連線

            //建立連線 -- 收先需要媒介 (連線字串)
            string connectionString = "Server = .\\SQLEXPRESS01; Database = SQL Tutorial; Trusted_Connection=True";


            //有了連線字串就可以建立物件
            //using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            //{
            //    // 開啟連線
            //    sqlconnection.Open();

            //    // 執行命令 - 開啟連線之後就可以操作資料庫了,在這裡需要用到SqlCommand命令物件
            //    SqlCommand command = new SqlCommand();
            //    command.CommandText = "Select TeamName from dbo.Teams where id = 4";
            //    command.CommandType = CommandType.Text;

            //    // 設定連線
            //    command.Connection = sqlconnection;

            //    //object firstData = command.ExecuteScalar();

            //    string result = command.ExecuteScalar().ToString();
            //    Console.WriteLine(result);
            //}



            // **** 若想要傳遞引數給資料庫 可以用sqlParameter 該類有幾個重要的屬性: ****
            //ParameterName: 設定引數名
            //Value:給引數設定值
            //Size:設定引數位元組最大長度
            //SqlDbType:引數在SQL中的類別

            //和幾個重要的方法:
            //1 AddWithVlue
            //2 Add
            //3 AddRange
            //using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            //{
            //    sqlconnection.Open();

            //    SqlCommand cmd = sqlconnection.CreateCommand(); //如果是這樣用sqlconnection create 就不需要像上面一樣 把sqlconnection 丟進 Cmd.Connection了

            //    cmd.CommandText = "dbo.spTeams_select";
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@id", "4");

            //    string result = cmd.ExecuteScalar().ToString();
            //    Console.WriteLine($"{result} => using sqlParameters");
            //}



            // **** 資料讀取 使用DataReader --> 利用查詢語句得到的資料資訊需要通過資料讀取器進行操作 ****
            //using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            //{
            //    sqlconnection.Open();

            //    SqlCommand cmd = sqlconnection.CreateCommand(); //如果是這樣用sqlconnection create 就不需要像上面一樣 把sqlconnection 丟進 Cmd.Connection了

            //    cmd.CommandText = "select * from dbo.Teams";

            //    SqlDataReader reader = cmd.ExecuteReader();

            //    if (reader.HasRows) //查看使否有資料
            //    {
            //        while (reader.Read()) //讀取資料
            //        {
            //            Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("No rows founds");
            //    }
            //    reader.Close();
            //}


            // ***** 使用NextResult 來取出多個結果集 ******
            //using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            //{
            //    sqlconnection.Open();

            //    SqlCommand cmd = sqlconnection.CreateCommand();

            //    cmd.CommandText = "select * from dbo.Teams; select * from dbo.People";


            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read()) //查看使否有資料
            //        {
            //            Console.WriteLine("\t{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
            //        }

            //        //reader.NextResult();
            //        if (reader.NextResult())
            //        {
            //            Console.WriteLine("\ttrue");
            //        }

            //        while (reader.Read()) //讀取資料
            //        {
            //            Console.WriteLine("\t{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
            //        }
            //    }
            //}


            // 當DataReader 開啟時, 可以使用 GetSchemaTable 方法來取得目前結果集的架構資訊
            // GetSchemaTable 會傳回一個 DataTable 物件，此物件會填入包含目前結果集之架構資訊的資料列和資料行
            // 其中 ColumnName 是屬性的名稱，而資料行的值是屬性的值
            //using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            //{
            //    sqlconnection.Open();

            //    SqlCommand cmd = sqlconnection.CreateCommand();

            //    cmd.CommandText = "select * from dbo.People";

            //    SqlDataReader reader = cmd.ExecuteReader();
            //    DataTable schemaTable = reader.GetSchemaTable();

            //    //foreach (DataRow row in schemaTable.Rows) // 所以row的值是屬性的值
            //    //{
            //    //    foreach (DataColumn column in schemaTable.Columns) // 而column是屬性的名稱
            //    //    {
            //    //        Console.WriteLine(String.Format("{0} = {1}", column.ColumnName, row[column]));
            //    //    }
            //    //}


            //    // 如果想要指定的data 可以用下面這個方法
            //    foreach (DataRow row in schemaTable.Rows)
            //    {
            //        string column = row.Field<string>("ColumnName");
            //        string type = row.Field<string>("DataTypeName");
            //        short precision = row.Field<short>("NumericPrecision");
            //        short scale = row.Field<short>("NumericScale");
            //        Console.WriteLine("Column: {0} Type: {1} Precision: {2} Scale: {3}", column, type, precision, scale);
            //    }
            //}



            // **** Sql Transaction 使用transaction savepoint 以及Rollback ******
            //using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            //{
            //    sqlconnection.Open();

            //    //begin Transaction 開始交易
            //    SqlTransaction transaction = sqlconnection.BeginTransaction();

            //    SqlCommand cmd = sqlconnection.CreateCommand();
            //    cmd.CommandText = "Insert into dbo.MemberData (EmployeeID, FirstName, LastName, Age, Gender) values (55, 'petter', 'parker', 6, 'who know');";
            //    cmd.CommandType = CommandType.Text;

            //    cmd.Transaction = transaction;

            //    // ExecuteNonQuery return 0 if it failed ....
            //    int result = cmd.ExecuteNonQuery(); 

            //    //儲存交易點
            //    transaction.Save("Transaction first point");

            //    if (result == 0) // means it failed
            //        //滾回儲存點
            //        transaction.Rollback("Transaction point");
            //    else
            //        //執行交易
            //        transaction.Commit();
            //}


            // 使用Try catch 來測試 transaction
            //using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            //{
            //    sqlconnection.Open();

            //    //begin Transaction 開始交易
            //    SqlTransaction transaction = sqlconnection.BeginTransaction("First Transaction");

            //    SqlCommand cmd = sqlconnection.CreateCommand();
            //    cmd.Transaction = transaction;

            //    try
            //    {
            //        cmd.CommandText = "Insert into dbo.MemberData (EmployeeID, FirstName, LastName, Age, Gender) values (1, 'audin', 'thore', 1, 'GOD');";
            //        cmd.CommandType = CommandType.Text;
            //        cmd.ExecuteNonQuery();


            //        transaction.Commit();
            //        Console.WriteLine("The first line is insert successfully");

            //        try
            //        {
            //            SqlTransaction tran2 = sqlconnection.BeginTransaction("Second Transaction");
            //            cmd.Transaction = tran2;

            //            cmd.CommandText = "Insert into dbo.MemberData (EmployeeID, FirstName, LastName, Age, Gender) values (6, 'Miley', 'cyrus', 30, 'girl');Insert into dbo.MemberData (EmployeeID, FirstName, LastName, Age) values (1, 'audin', 'thore', 1);";
            //            cmd.CommandType = CommandType.Text;
            //            cmd.ExecuteNonQuery();

            //            tran2.Commit();
            //            Console.WriteLine("The Second line is insert successfully");
            //        }
            //        catch (Exception e)
            //        {
            //            Console.WriteLine("Second Commit Failed => Commit Exception Type {0}", e.GetType());
            //            Console.WriteLine("Message {0}", e.Message);

            //            try
            //            {
            //                transaction.Rollback("Second Transaction");
            //            }
            //            catch (Exception ex)
            //            {
            //                // This catch block will handle any errors that may have occurred
            //                // on the server that would cause the rollback to fail, such as
            //                // a closed connection.
            //                Console.WriteLine("RollBack failed => Rollback Exception Type: {0}", ex.GetType());
            //                Console.WriteLine("Message: {0}", ex.Message);
            //            }
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Commit Failed => Commit Exception Type {0}", e.GetType());
            //        Console.WriteLine("Message {0}", e.Message);

            //        try
            //        {
            //            transaction.Rollback("First Transaction");
            //        }
            //        catch (Exception ex)
            //        {
            //            // This catch block will handle any errors that may have occurred
            //            // on the server that would cause the rollback to fail, such as
            //            // a closed connection.
            //            Console.WriteLine("RollBack failed => Rollback Exception Type: {0}", ex.GetType());
            //            Console.WriteLine("Message: {0}", ex.Message);
            //        }
            //    }
            //}


            // ***** 使用 DataAdapter ******
            // ***** DataAdpater 物件填充 Dataset, DataTable物件 *****
            //using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            //{
            //    string sql = "Select * from dbo.Testperson where id = [id]";
            //    SqlParameter p = new SqlParameter("@id", 2);

            //    using (SqlCommand com = new SqlCommand(sql, sqlconnection))
            //    {
            //        DataSet ds = new DataSet();
            //        try
            //        {
            //            com.Parameters.Add(p);
            //            sqlconnection.Open();
            //            SqlDataAdapter adapter = new SqlDataAdapter(com);
            //            adapter.Fill(ds);

            //            foreach (DataRow s in ds.Tables[0].Rows)
            //            {
            //                Console.WriteLine("ID:" + s["id"].ToString());
            //                Console.WriteLine("Name:" + s["FirstName"].ToString());
            //            }
            //        }
            //        catch (Exception e)
            //        {

            //            throw new Exception(e.Message);
            //        }
            //    }
            //}

            //DataAdapter物件實現批量修改
            //using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            //{
            //    string sql = "Select * from dbo.Testperson";
            //    DataSet ds = new DataSet(); //創一個dataset的記憶體資料集

            //    try
            //    {
            //        sqlconnection.Open();

            //        //DataAdapter首先將構造一個SelectCommand例項（本質就一個Command物件），然後檢查是否開啟連線，
            //        //如果沒有開啟連線則開啟連線，緊接著呼叫DataReader介面檢索資料，最後根據維護的對映關係
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlconnection);

            //        // 把adapter 檢索到得資料庫填充到 本地的 DataSet 或著 DataTable 裡面
            //        adapter.Fill(ds);

            //        // ds.Tables[ 選擇資料表名稱 ], 這邊沒有給table 命名 所以用數字 0表示第一個
            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        {
            //            Console.WriteLine(ds.Tables[0].Rows[i].RowState);//RowState：Unchanged 
            //            Console.WriteLine(ds.Tables[0].Rows[i][2]);
            //            ds.Tables[0].Rows[i][2] = "abc"; // 每一行的第三列都修改為abc
            //            Console.WriteLine(ds.Tables[0].Rows[i][2]);
            //            Console.WriteLine(ds.Tables[0].Rows[i].RowState);//RowState：Modified
            //            Console.WriteLine();
            //        }

            //        SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter); //這行不能缺少，除非自定義Command賦值給adapter.UpdateCommand
            //        Console.WriteLine("生成的Update語句：{0}", cmdBuilder.GetUpdateCommand().CommandText);

            //        adapter.Update(ds);//更新到資料來源中
            //        ds.AcceptChanges();//提交到DataTable中  提交後DataRow.RowState會修改為Unchanged
            //    }
            //    catch (Exception e)
            //    {

            //        throw new Exception(e.Message);
            //    }
            //}


            // 自己練習一次
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = "Select * from dbo.Testperson";
                DataSet ds = new DataSet();

                sqlConnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlConnection);
                adapter.Fill(ds);

                ds.Tables[0].TableName = "TableOne";

                foreach (DataRow dataRow in ds.Tables["TableOne"].Rows)
                {
                    Console.WriteLine($"ID => {dataRow["id"]}, {dataRow["FirstName"]}, {dataRow["LastName"]}");
                }

                //新增一筆資料
                DataRow newRow = ds.Tables["TableOne"].NewRow();
                newRow["FirstName"] = "Harry";
                newRow["LastName"] = "Potter";
                newRow["EmailAddress"] = "ddd@gmail.com";
                ds.Tables["TableOne"].Rows.Add(newRow);

                //移除一筆資料
                //ds.Tables["TableOne"].Rows.Remove(ds.Tables["TableOne"].Rows[1]);
                ds.Tables["TableOne"].Rows[1].Delete(); // 要移除後端Database裏面的資料 必須用Delete, 使用Remove 只會移除DataTable 裡面的資料而已


                //for (int i = ds.Tables["TableOne"].Rows.Count - 1; i >= 0; i--)
                //{
                //    DataRow dr = ds.Tables["TableOne"].Rows[i];
                //    if (dr["FirstName"].ToString() == "firstname")
                //    {
                //        dr.Delete();
                //    }
                //}
                

                //修改一筆資料
                DataRow[] rows = ds.Tables["TableOne"].Select("id=5");
                if (rows.Length > 0)
                {
                    rows[0]["FirstName"] = "johon";
                }



                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                Console.WriteLine("生成的Update語句：{0}", cmdBuilder.GetUpdateCommand().CommandText);

                adapter.Update(ds, "TableOne"); // if you set the tablename then you will have to put it right behind.
                ds.AcceptChanges();

            }
        }
    }
}
