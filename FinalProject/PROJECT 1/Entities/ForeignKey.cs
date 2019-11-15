using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_1
{
    public class ForeignKey
    {
        /**A foreign key must contain information of referenced table 
         * and referencing table so there are two Table objects for 
         * those two tables
         **/
        public Table referencedTable { get; set; }
        public Table referencingTable { get; set; }
        public object constraint_name { get; set; }
        /**A foreign key must contain information of referenced column name
         * and referencing column name so there are two objects for 
         * those two column names
         **/
        public object referencedCol { get; set; }
        public object referencingCol { get; set; }

        public ForeignKey()
        {
        }
        public ForeignKey(object constraint_name, object referencedCol, object referencingCol, Table referencedTable, Table referencingTable)
        {
            this.constraint_name = constraint_name;
            this.referencedCol = referencedCol;
            this.referencingCol = referencingCol;
            this.referencedTable = referencedTable;
            this.referencingTable = referencingTable;
        }
    }
}
