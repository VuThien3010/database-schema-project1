using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PROJECT_1
{
    public partial class table_Info : Form
    {
        public table_Info(string table_name,MyConnection myConnection)
        {
            InitializeComponent();
            SqlConnection cn = myConnection.getConnection();
            string student = table_name;
            string sql = "select * from " + student;
            SqlCommand cmd;
            try
            {
                cn.Open();
                cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.KeyInfo);
                DataTable dt = dr.GetSchemaTable();

                foreach (DataRow dt_row in dt.Rows)
                {

                    foreach (DataColumn dt_col in dt.Columns)
                    {
                        this.rtbView.Text += string.Format("{0}={1}", dt_col.ColumnName, dt_row[dt_col]).ToString();
                        this.rtbView.Text += "\n";
                    }
                    this.rtbView.Text += "=======================\n";
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }
    }
}
