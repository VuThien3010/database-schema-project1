using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT_1
{
    public partial class FK_Info : Form
    {
        public FK_Info(ForeignKey fk)
        {
            InitializeComponent();
            this.txtRelationshipName.Text = fk.constraint_name.ToString();
            this.txt_PK_TableName.Text = fk.referencedTable.table_name.ToString();
            this.txt_PK.Text = fk.referencedCol.ToString();
            this.txt_FK_TableName.Text = fk.referencingTable.table_name.ToString();
            this.txt_FK.Text = fk.referencingCol.ToString();
        }
    }
}
