using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace PROJECT_1
{
    public class MyConnection
    {
        public string database_name { get; set; }
        public static string data_source { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }

        public MyConnection()
        {
        }
        public MyConnection(string database_name)
        {
            this.database_name = database_name;
        }

        public SqlConnection getConnection()
        {
            string str = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
                data_source,this.database_name, username,password);
            SqlConnection cn = new SqlConnection(str);
            return cn;
        }
    

    }
}
