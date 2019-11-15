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
using System.Diagnostics;

namespace PROJECT_1
{
    public partial class Form1 : Form
    {
        /**
         * Check whether the connection was successfully established or not
         **/
        public bool IsConnection(SqlConnection cn)
        {
            cn.Open();
            return true;
        }
        public Form1()
        {
            InitializeComponent();
            this.txtServerName.Select();
        }


        /**
         * Validate user input
         * If connection is opened successfully, open Generate form
         * If not show "Login Fail !" message
         **/
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Check if empty
            if (txtUName.Text == "" && txtPass.Text == "")
            {
                MessageBox.Show("Please fill in the blank");
            }
            else
            {
                //collect user input
                string uname = txtUName.Text;
                string pass = txtPass.Text;
                string ServerName = txtServerName.Text;
                string DbName = txtDBName.Text;
                /**
                 * data_source, username, password are static
                 * because when users login successfully but they want switch to another database,
                 * they do not have to login again
                 **/
                MyConnection.data_source = ServerName;
                MyConnection.username = uname;
                MyConnection.password = pass;
                MyConnection myConnection = new MyConnection(DbName);
                
                SqlConnection cn = myConnection.getConnection();
                try
                {
                    if (IsConnection(cn))
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                            cn.Close();
                        this.txtDBName.Text = "";
                        this.txtServerName.Text = "";
                        this.txtUName.Text = "";
                        this.txtPass.Text = "";
                        Generate obj = new Generate(myConnection);
                           obj.Show();
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Login Fail !");
                    cn.Close();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
