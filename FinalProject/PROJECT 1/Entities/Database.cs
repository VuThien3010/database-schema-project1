using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PROJECT_1
{
    public class Database
    {
        public object database_name { get; set; }
        public object create_date { get; set; }
        public object dbid { get; set; }
        //A database can have many table so there is List<Table> 
        private List<Table> Tables;

        public List<Table> GetSetTable
        {
            get
            {
                return Tables;
            }
            set
            {
                Tables = value;
            }
        }

        public Database(DataTable dt, string database_name)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dr[dc].Equals(database_name))
                    {
                        this.database_name = dr[0];
                        this.dbid = dr[1];
                        this.create_date = dr[2];
                        break;
                    }
                }
            }

        }

        public Table getTableByName(object table_name)
        {
            foreach (Table t in this.Tables)
            {
                if (t.table_name.Equals(table_name))
                {
                    return t;
                }
            }
            return null;
        }
    }
}
