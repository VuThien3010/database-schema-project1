using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_1
{
    public class Columns
    {
        //A column belong to one table so there is a table object
        public Table table { get; set; }
        public object data_type { get; set; }
        public object column_name { get; set; }
        //A column can be primary key so there is isKey property
        public Boolean isKey { get; set; }

        public Columns(object data_type, object column_name, Table table)
        {
            this.isKey = false;
            this.data_type = data_type;
            this.column_name = column_name;
            this.table = table;
        }
    }
}
