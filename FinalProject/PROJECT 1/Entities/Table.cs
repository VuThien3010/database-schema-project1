using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_1
{
    public class Table
    {
        //A table belong to one database so there is a database object
        public Database database { get; set; }
        public object table_name { get; set; }
        //A table can have many column so there is List<Columns> 
        private List<Columns> Columns;
        //A table can have many foreignKey so there is List<ForeignKey>
        private List<ForeignKey> foreignKeys;

        public List<Columns> GetSetColumns
        {
            get
            {
                return Columns;
            }
            set
            {
                Columns = value;
            }
        }

        public List<ForeignKey> GetSetForeignKeys
        {
            get
            {
                return foreignKeys;
            }
            set
            {
                foreignKeys = value;
            }
        }

        public Table(object table_name, Database db)
        {
            this.database = db;
            this.table_name = table_name;
        }
    }
}
