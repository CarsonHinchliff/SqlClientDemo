using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlConStrBuilderDemo
{
    class Program
    {
        //const string connStr = @"Data Source=.;Initial Catalog=EFTestDb;User ID=sa;Password=sa1234=\/=/=\";
        const string connStr = @"Data Source=.;Initial Catalog=EFTestDb;User ID=secuser;Password=sa1234=\/=/=\";
        static void Main(string[] args)
        {
            //Console.WriteLine(Convert());
            TestOpen();

            Console.WriteLine("Test done");
            Console.ReadKey();
        }

        static string Convert()
        {
            var sqlConStrBuilder = new SqlConnectionStringBuilder();
            sqlConStrBuilder.ConnectionString = connStr;

            return sqlConStrBuilder.Password;
        }

        static void TestOpen()
        {
            DataSet ds = new DataSet();
            var conn = new SqlConnection();
            conn.ConnectionString = connStr;
            //conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "select * from EXT_GAP_INITIATIVE_ATTACHMENT";
            //var sqlReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
    }
}
