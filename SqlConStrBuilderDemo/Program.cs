using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlConStrBuilderDemo
{
    class Program
    {
        //const string connStr = @"Data Source=.;Initial Catalog=EFTestDb;User ID=sa;Password=sa1234=\/=/=\";
        const string connStrLowerCase = @"initial catalog=eftestdb;user id=secuser;password=sa;1234;=\/=/=\;data source=.;";
        const string connStr = @"Initial Catalog=EFTestDb;User ID=secuser;Password=sa;1234;=\/=/=\;Data Source=.;";
        const string connStrConverted = "Data Source=.;Initial Catalog=EFTestDb;User ID=secuser;Password=\"sa;1234;=\\/=/=\\\"";
        static void Main(string[] args)
        {
            //Console.WriteLine(Convert());
            //TestOpen();
            Console.WriteLine(GetDbName(connStrConverted));

            Console.WriteLine("Test done");
            Console.ReadKey();
        }

        static string Convert()
        {
            var sqlConStrBuilder = new SqlConnectionStringBuilder();
            sqlConStrBuilder.ConnectionString = connStr;

            return sqlConStrBuilder.Password;
        }

        static string CovertFromProperties()
        {
            var sqlConStrBuilder = new SqlConnectionStringBuilder();
            sqlConStrBuilder.DataSource = ".";
            sqlConStrBuilder.Password = @"sa;1234;=\/=/=\";
            sqlConStrBuilder.InitialCatalog = @"EF;=\/=/=\TestDb";
            sqlConStrBuilder.UserID = "secuser";

            return sqlConStrBuilder.ConnectionString;
        }

        public static string GetDbName(string connString)
        {
            return new SqlConnectionStringBuilder(connString).InitialCatalog;
        }

        static void TestOpen()
        {
            DataSet ds = new DataSet();
            var conn = new SqlConnection();
            //conn.ConnectionString = connStr;
            conn.ConnectionString = CovertFromProperties();
            //conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "select * from EXT_GAP_INITIATIVE_ATTACHMENT";
            //var sqlReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
    }
}
