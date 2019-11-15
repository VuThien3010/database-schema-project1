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
using System.Collections;
namespace PROJECT_1
{
    public partial class Generate : Form
    {
        //SqlConnection object is used for generate getSchema()
        private SqlConnection cn;

        //MyConnection
        private MyConnection myConnection;

        //Database object handles and organize information 
        //generated from getSchema("Database")
        private Database db;

        //List<DataGridView> object contains all DataGridViews 
        //that showed on panel
        private List<DataGridView> listDgv = new List<DataGridView>();

        //Hashtable object is used for illustrating relationship
        //between ForeignKey object and drawing arrows (Key: List<Point>, Value: ForeignKey)
        private Hashtable hashtable = new Hashtable();

        #region function List<Point> isInsideArror(Point mousePoint) description
        /**
         * Function take on parameter which mouse cursor location
         * Inside the function:
         * Step 1: 
         *  Loop through all drawing arrows which are List<Point> object inhashtable.Keys
         * Step 2: 
         *  Loop through each section of an arrow which is created by a point and 
         *  its following one in List<Point>
         * Step 3:
         *  Calculate the length from mouse cursor location to each end of the section 
         *  (length0 and length1) and calculate the total length of the section (totalLength)
         *  by fomula d = sqrt((x1-x2)^2+(y1-y2)^2)
         * Step 4: check if the sum of length0 and legnth1 is equal to totalLength or not
         *  If yes: return that List<Point> object
         *  If no: continue looping, when finish looping but can not find any 
         *  List<Point> object, return null.
         **/
        #endregion
        public List<Point> isInsideArror(Point mousePoint)
        {
            double length0;
            double length1;
            double totalLength;
            foreach (List<Point> points in hashtable.Keys)
            {
                for (int i = 0; i < points.Count - 1; i++)
                {
                    length0 = Math.Round(Math.Sqrt(Math.Pow(mousePoint.X - points[i].X, 2) +
                       Math.Pow(mousePoint.Y - points[i].Y, 2)));
                    length1 = Math.Round(Math.Sqrt(Math.Pow(mousePoint.X - points[i + 1].X, 2) +
                        Math.Pow(mousePoint.Y - points[i + 1].Y, 2)));
                    totalLength = Math.Round(Math.Sqrt(Math.Pow(points[i].X - points[i + 1].X, 2) +
                       Math.Pow(points[i].Y - points[i + 1].Y, 2)));
                    if (length0 + length1 == totalLength)
                    {
                        return points;
                    }
                }
            }
            return null;
        }

        #region function postioning(List<DataGridView> list) description
        /**
         * Main goal: placing Datagridview Object on panel which use as much space as possible
         * Step 1: 
         *  Placing the first DataGridView Object on the top left of the panel as
         *  an pivot position
         * Step 2:
         *  Placing the next DataGridView Object next to an pivot position horizontally
         * Step 3:
         *  Placing the next DataGridView Object next to an pivot position vertically
         * Step 4:
         *  Fill the gap between horizontal and vertical axis
         * Step 5:
         *  Show DataGridView Object on panel and return to Step 2 if there is still
         *  DataGridView in List<DataGridView>
         * 
         **/
        #endregion
        public void postioning(List<DataGridView> list)
        {
            this.btnGenerate.Enabled = false;

            /**
             * These variables are used when filling the gap between 
             * horizontal and vertical axis
             **/
            int i = 0;
            int count = 0;
            Queue q = new Queue();

            /**
             * longestHeight and longestWidth are used for ensuring that DataGridView Objects
             * are placed horizontally or vertically to the pivot position serially
             **/
            int longestHeight = 0;
            int longestWidth = 0;



            /**
             * 0: first position
             * 1: horizontal location
             * 2: vertical position
             * 3: sub location
            **/
            int status = 0;
            foreach (DataGridView dgv in list)
            {
                //placing pivot position
                if (status == 0)
                {
                    dgv.Location = new Point(50, 50);
                    longestHeight = dgv.Height;
                    longestWidth = dgv.Width;
                    status = 1;
                }
                //placing horizontally
                else if (status == 1)
                {
                    dgv.Location = new Point(longestWidth + 100, 50);
                    longestWidth = (dgv.Location.X + dgv.Width);
                    q.Enqueue(new Point(dgv.Location.X, dgv.Height + 100));
                    /**
                     * Collect Number of item in Queue to make sure that status will not
                     * equal to 3 permanently
                    **/
                    count = q.Count;
                    status = 2;
                }
                //placing vertically
                else if (status == 2)
                {
                    dgv.Location = new Point(50, longestHeight + 100);
                    longestHeight = (dgv.Location.Y + dgv.Height);
                    status = 3;
                    i = 0;
                }
                //Fill the gap between horizontal and vertical axis
                else if (status == 3)
                {
                    if (i < count)
                    {
                        dgv.Location = (Point)q.Dequeue();
                        q.Enqueue(new Point(dgv.Location.X, dgv.Location.Y + dgv.Height + 100));
                        i++;
                        if (i >= count)
                        {
                            status = 1;
                        }
                    }
                }
                this.panel1.Controls.Add(dgv);
            }
        }

        #region function InitEvent(List<DataGridView> list) description
        /**
         * Initialize Three Event for each DataGridView:
         * MouseDown, MouseMove, DoubleClick
         * The first two Events are used for holding and dragging DataGridView object 
         **/
        #endregion
        public void InitEvent(List<DataGridView> list)
        {
            foreach (DataGridView dgv in list)
            {
                Point firstPoint = new Point();
                dgv.MouseDown += (ss, ee) =>
                {
                    if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        firstPoint = Control.MousePosition;
                    }
                    //Redraw panel
                    this.panel1.Refresh();
                };
                dgv.MouseMove += (ss, ee) =>
                {
                    if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        Point temp = Control.MousePosition;
                        Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                        dgv.Location = new Point(dgv.Location.X - res.X, dgv.Location.Y - res.Y);

                        firstPoint = temp;
                    }
                    //Redraw panel
                    this.panel1.Refresh();
                };
                dgv.DoubleClick += new EventHandler(delegate (Object o, EventArgs a)
                {
                    table_Info table_info = new table_Info(dgv.Columns[0].HeaderText,this.myConnection);
                    table_info.ShowDialog();
                });

            }
        }

        #region function filterUnnessaryRow(DataTable dt) description
        /**
         * Remove DataBase Schema of the system
        **/
        #endregion
        public void filterUnnessaryRow(DataTable dt)
        {
            List<DataRow> index = new List<DataRow>();
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dr[dc].Equals("sysdiagrams"))
                    {
                        index.Add(dr);
                    }
                }
            }
            foreach (DataRow i in index)
            {
                dt.Rows.Remove(i);
            }
        }

        public bool IsConnection(SqlConnection cn)
        {
            cn.Open();
            return true;
        }

        #region function Generate(MyConnection myConnection) description
        /**
         * Generate Database from database name given by user
         * Collect all database names and put to combo box for users to switch database
        **/ 
        #endregion
        public Generate(MyConnection myConnection)
        {
            InitializeComponent();
            this.myConnection = myConnection;
            this.cn = this.myConnection.getConnection();
            this.panel1.AutoScroll = true;
            this.btnGenerate.Enabled = false;
            
            cn.Open();

            DataTable databasesSchemaTable = cn.GetSchema("Databases");

            foreach (DataRow dr in databasesSchemaTable.Rows)
            {
                if (!dr[0].Equals("master") && !dr[0].Equals("tempdb") &&
                   !dr[0].Equals("model") && !dr[0].Equals("msdb") &&
                   !dr[0].Equals("ReportServer") && !dr[0].Equals("ReportServerTempDB"))
                {
                    this.cmbListDatabase.Items.Add(dr[0].ToString());
                }
            }
            
            #region Load information to Database class
            db = new Database(databasesSchemaTable, myConnection.database_name);
            #endregion

            #region Load information to Table class
            DataTable allTablesSchemaTable = cn.GetSchema("Tables", new string[] { null, null, null, "BASE TABLE" });
            filterUnnessaryRow(allTablesSchemaTable);
            List<Table> listTables = new List<Table>();
            foreach (DataRow dr in allTablesSchemaTable.Rows)
            {
                Table t = new Table(dr[2], db);
                listTables.Add(t);
            }
            db.GetSetTable = listTables;
            #endregion

            #region Load information to Columns class
            DataTable allColumnsSchemaTable = cn.GetSchema("Columns");
            filterUnnessaryRow(allColumnsSchemaTable);
            var selectedRows = from info in allColumnsSchemaTable.AsEnumerable()
                               select new
                               {
                                   TableCatalog = info["TABLE_CATALOG"],
                                   TableSchema = info["TABLE_SCHEMA"],
                                   TableName = info["TABLE_NAME"],
                                   ColumnName = info["COLUMN_NAME"],
                                   DataType = info["DATA_TYPE"]
                               };
            foreach (Table t in db.GetSetTable)
            {
                List<Columns> listColumns = new List<Columns>();
                foreach (var row in selectedRows)
                {
                    if (t.table_name.Equals(row.TableName))
                    {
                        Columns col = new Columns(row.DataType, row.ColumnName, t);
                        listColumns.Add(col);
                    }
                }
                t.GetSetColumns = listColumns;
            }
            #endregion

            #region Set primary key for Columns class
            DataTable allIndexColumnsSchemaTable = cn.GetSchema("IndexColumns");
            filterUnnessaryRow(allIndexColumnsSchemaTable);
            var selectedIndexRows = from info in allIndexColumnsSchemaTable.AsEnumerable()
                                    select new
                                    {
                                        TableSchema = info["table_schema"],
                                        TableName = info["table_name"],
                                        ColumnName = info["column_name"],
                                        ConstraintSchema = info["constraint_schema"],
                                        ConstraintName = info["constraint_name"],
                                        KeyType = info["KeyType"]
                                    };
            foreach (Table t in db.GetSetTable)
            {
                foreach (var row in selectedIndexRows)
                {
                    if (t.table_name.Equals(row.TableName))
                    {
                        foreach (Columns col in t.GetSetColumns)
                        {
                            if (col.column_name.Equals(row.ColumnName))
                            {
                                col.isKey = true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Set foreign key for Foreign class
            string selectQuery = "select ";
            selectQuery += "rc.CONSTRAINT_NAME,";
            selectQuery += "rcu.TABLE_NAME 'Referencing Table',";
            selectQuery += "rcu.COLUMN_NAME 'Referencing Column',";
            selectQuery += "rcu1.TABLE_NAME 'Referenced Table',";
            selectQuery += "rcu1.COLUMN_NAME 'Referenced Column'\n";
            selectQuery += "from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc\n";
            selectQuery += "inner join\n";
            selectQuery += "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE rcu\n";
            selectQuery += "on rc.CONSTRAINT_CATALOG = rcu.CONSTRAINT_CATALOG\n";
            selectQuery += "and rc.CONSTRAINT_NAME = rcu.CONSTRAINT_NAME\n";
            selectQuery += "inner join\n";
            selectQuery += "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE rcu1\n";
            selectQuery += "on rc.UNIQUE_CONSTRAINT_CATALOG = rcu1.CONSTRAINT_CATALOG\n";
            selectQuery += "and rc.UNIQUE_CONSTRAINT_NAME = rcu1.CONSTRAINT_NAME";
            SqlCommand cmd = new SqlCommand(selectQuery, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (Table t in db.GetSetTable)
            {
                List<ForeignKey> listForeignKeys = new List<ForeignKey>();
                foreach (DataRow row in dt.Rows)
                {
                    ForeignKey fk = new ForeignKey();
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName.Equals("CONSTRAINT_NAME"))
                        {
                            fk.constraint_name = row[col];
                        }
                        else if (col.ColumnName.Equals("Referencing Table"))
                        {
                            fk.referencingTable = db.getTableByName(row[col]);
                        }
                        else if (col.ColumnName.Equals("Referencing Column"))
                        {
                            fk.referencingCol = row[col];
                        }
                        else if (col.ColumnName.Equals("Referenced Table"))
                        {
                            fk.referencedTable = db.getTableByName(row[col]);
                        }
                        else
                        {
                            fk.referencedCol = row[col];
                        }
                    }
                    if (t.table_name.Equals(fk.referencingTable.table_name))
                    {
                        listForeignKeys.Add(fk);
                    }
                }
                t.GetSetForeignKeys = listForeignKeys;
            }
            #endregion

            #region add table info to datagridview
            for (int i = 0; i < db.GetSetTable.Count; i++)
            {
                DataGridView dgv = new DataGridView();
                dgv.Height = dgv.RowTemplate.Height;
                DataGridViewTextBoxColumn IdCol = new DataGridViewTextBoxColumn();
                IdCol.HeaderText = db.GetSetTable[i].table_name.ToString();
                dgv.Columns.Add(IdCol);
                DataGridViewTextBoxColumn dataTypeColumn = new DataGridViewTextBoxColumn();
                dataTypeColumn.Name = "Datatype";

                dataTypeColumn.HeaderText = "Data Type";
                dgv.Columns.Add(dataTypeColumn);
                int indexRow = 0;
                foreach (Columns col in db.GetSetTable[i].GetSetColumns)
                {

                    dgv.Rows.Add(string.Format("{0}", col.column_name),
                        string.Format("{0}", col.data_type));
                    if (col.isKey)
                    {
                        dgv.Rows[indexRow].Cells[0].Value += " (PK)";
                    }
                    dgv.Height += dgv.RowTemplate.Height;
                    indexRow++;
                }
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(184, 239, 252);
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Bold);
                dgv.EnableHeadersVisualStyles = false;
                dgv.DefaultCellStyle.Font = new Font("Verdana", 10);
                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.BorderStyle = BorderStyle.Fixed3D;
                dgv.MultiSelect = false;
                dgv.GridColor = Color.MediumTurquoise;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                dgv.RowHeadersVisible = false;
                dgv.AllowUserToAddRows = false;
                listDgv.Add(dgv);
            }
            #endregion

            this.cn.Close();
            this.txtDBName.Text = db.database_name.ToString();
            this.txtDBId.Text = db.dbid.ToString();
            this.txtCreatedDate.Text = db.create_date.ToString();
            postioning(listDgv);
            InitEvent(listDgv);
        }
        
        public static void OpenLoginForm()
        {
            
            Application.Run(new Form1());          
        }
        
        private void Generate_Load(object sender, EventArgs e)
        {

        }

        public Generate(IContainer components, Panel panel1)
        {
            this.components = components;
            this.panel1 = panel1;
        }

        #region function Generate(MyConnection myConnection) description
        /**
         * Clear current database object and list of DataGridView
         * Generate new Database
        **/ 
        #endregion
        private void btnGenerate_Click(object sender, EventArgs e)
        {
           
            try
            {
                #region Create sql connection
                myConnection = new MyConnection(this.cmbListDatabase.SelectedItem.ToString());
                this.cn = myConnection.getConnection();
                if (IsConnection(this.cn))
                {
                    
                    if (listDgv.Count > 0)
                    {
                        foreach (DataGridView dgv in listDgv)
                        {
                            dgv.Dispose();
                        }
                    }
                    listDgv.Clear();
                    this.panel1.Controls.Clear();

                    #endregion

                    #region Load information to Database class
                    DataTable databasesSchemaTable = cn.GetSchema("Databases");
                    db = new Database(databasesSchemaTable, myConnection.database_name);
                    #endregion

                    #region Load information to Table class
                    DataTable allTablesSchemaTable = cn.GetSchema("Tables", new string[] { null, null, null, "BASE TABLE" });
                    filterUnnessaryRow(allTablesSchemaTable);
                    List<Table> listTables = new List<Table>();
                    foreach (DataRow dr in allTablesSchemaTable.Rows)
                    {
                        Table t = new Table(dr[2], db);
                        listTables.Add(t);
                    }
                    db.GetSetTable = listTables;
                    #endregion

                    #region Load information to Columns class
                    DataTable allColumnsSchemaTable = cn.GetSchema("Columns");
                    filterUnnessaryRow(allColumnsSchemaTable);
                    var selectedRows = from info in allColumnsSchemaTable.AsEnumerable()
                                       select new
                                       {
                                           TableCatalog = info["TABLE_CATALOG"],
                                           TableSchema = info["TABLE_SCHEMA"],
                                           TableName = info["TABLE_NAME"],
                                           ColumnName = info["COLUMN_NAME"],
                                           DataType = info["DATA_TYPE"]
                                       };
                    foreach (Table t in db.GetSetTable)
                    {
                        List<Columns> listColumns = new List<Columns>();
                        foreach (var row in selectedRows)
                        {
                            if (t.table_name.Equals(row.TableName))
                            {
                                Columns col = new Columns(row.DataType, row.ColumnName, t);
                                listColumns.Add(col);
                            }
                        }
                        t.GetSetColumns = listColumns;
                    }
                    #endregion

                    #region Set primary key for Columns class
                    DataTable allIndexColumnsSchemaTable = cn.GetSchema("IndexColumns");
                    filterUnnessaryRow(allIndexColumnsSchemaTable);
                    var selectedIndexRows = from info in allIndexColumnsSchemaTable.AsEnumerable()
                                            select new
                                            {
                                                TableSchema = info["table_schema"],
                                                TableName = info["table_name"],
                                                ColumnName = info["column_name"],
                                                ConstraintSchema = info["constraint_schema"],
                                                ConstraintName = info["constraint_name"],
                                                KeyType = info["KeyType"]
                                            };
                    foreach (Table t in db.GetSetTable)
                    {
                        foreach (var row in selectedIndexRows)
                        {
                            if (t.table_name.Equals(row.TableName))
                            {
                                foreach (Columns col in t.GetSetColumns)
                                {
                                    if (col.column_name.Equals(row.ColumnName))
                                    {
                                        col.isKey = true;
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region Set foreign key for Foreign class
                    string selectQuery = "select ";
                    selectQuery += "rc.CONSTRAINT_NAME,";
                    selectQuery += "rcu.TABLE_NAME 'Referencing Table',";
                    selectQuery += "rcu.COLUMN_NAME 'Referencing Column',";
                    selectQuery += "rcu1.TABLE_NAME 'Referenced Table',";
                    selectQuery += "rcu1.COLUMN_NAME 'Referenced Column'\n";
                    selectQuery += "from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc\n";
                    selectQuery += "inner join\n";
                    selectQuery += "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE rcu\n";
                    selectQuery += "on rc.CONSTRAINT_CATALOG = rcu.CONSTRAINT_CATALOG\n";
                    selectQuery += "and rc.CONSTRAINT_NAME = rcu.CONSTRAINT_NAME\n";
                    selectQuery += "inner join\n";
                    selectQuery += "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE rcu1\n";
                    selectQuery += "on rc.UNIQUE_CONSTRAINT_CATALOG = rcu1.CONSTRAINT_CATALOG\n";
                    selectQuery += "and rc.UNIQUE_CONSTRAINT_NAME = rcu1.CONSTRAINT_NAME";
                    SqlCommand cmd = new SqlCommand(selectQuery, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (Table t in db.GetSetTable)
                    {
                        List<ForeignKey> listForeignKeys = new List<ForeignKey>();
                        foreach (DataRow row in dt.Rows)
                        {
                            ForeignKey fk = new ForeignKey();
                            foreach (DataColumn col in dt.Columns)
                            {
                                if (col.ColumnName.Equals("CONSTRAINT_NAME"))
                                {
                                    fk.constraint_name = row[col];
                                }
                                else if (col.ColumnName.Equals("Referencing Table"))
                                {
                                    fk.referencingTable = db.getTableByName(row[col]);
                                }
                                else if (col.ColumnName.Equals("Referencing Column"))
                                {
                                    fk.referencingCol = row[col];
                                }
                                else if (col.ColumnName.Equals("Referenced Table"))
                                {
                                    fk.referencedTable = db.getTableByName(row[col]);
                                }
                                else
                                {
                                    fk.referencedCol = row[col];
                                }
                            }
                            if (t.table_name.Equals(fk.referencingTable.table_name))
                            {
                                listForeignKeys.Add(fk);
                            }
                        }
                        t.GetSetForeignKeys = listForeignKeys;
                    }
                    #endregion

                    #region add table info to datagridview
                    for (int i = 0; i < db.GetSetTable.Count; i++)
                    {
                        DataGridView dgv = new DataGridView();
                        dgv.Height = dgv.RowTemplate.Height;
                        DataGridViewTextBoxColumn IdCol = new DataGridViewTextBoxColumn();
                        IdCol.HeaderText = db.GetSetTable[i].table_name.ToString();
                        dgv.Columns.Add(IdCol);
                        DataGridViewTextBoxColumn dataTypeColumn = new DataGridViewTextBoxColumn();
                        dataTypeColumn.Name = "Datatype";

                        dataTypeColumn.HeaderText = "Data Type";
                        dgv.Columns.Add(dataTypeColumn);
                        int indexRow = 0;
                        foreach (Columns col in db.GetSetTable[i].GetSetColumns)
                        {

                            dgv.Rows.Add(string.Format("{0}", col.column_name),
                                string.Format("{0}", col.data_type));
                            if (col.isKey)
                            {
                                dgv.Rows[indexRow].Cells[0].Value += " (PK)";
                            }
                            dgv.Height += dgv.RowTemplate.Height;
                            indexRow++;
                        }
                        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(184, 239, 252);
                        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Bold);
                        dgv.EnableHeadersVisualStyles = false;
                        dgv.DefaultCellStyle.Font = new Font("Verdana", 10);
                        dgv.DefaultCellStyle.BackColor = Color.White;
                        dgv.BorderStyle = BorderStyle.Fixed3D;
                        dgv.MultiSelect = false;
                        dgv.GridColor = Color.MediumTurquoise;
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                        dgv.RowHeadersVisible = false;
                        dgv.AllowUserToAddRows = false;
                        listDgv.Add(dgv);
                    }
                    #endregion


                    this.cn.Close();
                    this.txtDBName.Text = db.database_name.ToString();
                    this.txtDBId.Text = db.dbid.ToString();
                    this.txtCreatedDate.Text = db.create_date.ToString();
                    postioning(listDgv);
                    InitEvent(listDgv);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Your Account Has No Permission To Access This Database!");
                cn.Close();
            }
            this.cmbListDatabase.SelectedIndex = -1;

        }

        #region function panel1_Paint(object sender, PaintEventArgs e) description
        /**
         * Drawing arrows according to cases
        **/
        #endregion
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            Pen myPen = new Pen(Brushes.GreenYellow, 5);
            myPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            hashtable.Clear();
            if (db != null)
            {
                foreach (Table t in db.GetSetTable)
                {
                    if (t.GetSetForeignKeys.Count > 0)
                    {
                        int i = db.GetSetTable.IndexOf(t);
                        foreach (ForeignKey fk in t.GetSetForeignKeys)
                        {
                            int j = db.GetSetTable.IndexOf(fk.referencedTable);
                            //the table references to itself
                            if (listDgv[i].Location.X == listDgv[j].Location.X &&
                   listDgv[i].Location.Y == listDgv[j].Location.Y)
                            {
                                List<Point> points = new List<Point>();
                                points.Add(listDgv[i].Location);
                                points.Add(new Point(listDgv[i].Location.X, listDgv[i].Location.Y - 20));
                                points.Add(new Point(listDgv[i].Location.X - 20, listDgv[i].Location.Y - 20));
                                points.Add(new Point(listDgv[i].Location.X - 20, listDgv[i].Location.Y));
                                points.Add(listDgv[i].Location);
                                gp.DrawLines(myPen, points.ToArray());
                                hashtable.Add(points, fk);
                            }
                            // referenced table is on the right of referencing table
                            else if (listDgv[i].Location.X + listDgv[i].Width < listDgv[j].Location.X)
                            {
                                List<Point> points = new List<Point>();
                                points.Add(new Point(listDgv[i].Location.X + listDgv[i].Width,
                                    listDgv[i].Location.Y));
                                points.Add(new Point((listDgv[i].Location.X + listDgv[i].Width + listDgv[j].Location.X) / 2,
                                    listDgv[i].Location.Y));
                                points.Add(new Point((listDgv[i].Location.X + listDgv[i].Width + listDgv[j].Location.X) / 2,
                                    listDgv[j].Location.Y));
                                points.Add(listDgv[j].Location);
                                gp.DrawLines(myPen, points.ToArray());
                                hashtable.Add(points, fk);
                            }
                            //referenced table is on the left of referencing table
                            else if (listDgv[j].Location.X + listDgv[j].Width < listDgv[i].Location.X)
                            {
                                List<Point> points = new List<Point>();
                                points.Add(listDgv[i].Location);
                                points.Add(new Point((listDgv[j].Location.X + listDgv[j].Width + listDgv[i].Location.X) / 2,
                                    listDgv[i].Location.Y));
                                points.Add(new Point((listDgv[j].Location.X + listDgv[j].Width + listDgv[i].Location.X) / 2,
                                    listDgv[j].Location.Y));
                                points.Add(new Point(listDgv[j].Location.X + listDgv[j].Width,
                                   listDgv[j].Location.Y));
                                gp.DrawLines(myPen, points.ToArray());
                                hashtable.Add(points, fk);
                            }
                            else if ((listDgv[i].Location.X + listDgv[i].Width >= listDgv[j].Location.X) ||
                                (listDgv[j].Location.X + listDgv[j].Width >= listDgv[i].Location.X))
                            {
                                //referenced table is above referencing table
                                if (listDgv[i].Location.Y > listDgv[j].Location.Y + listDgv[j].Height)
                                {
                                    List<Point> points = new List<Point>();
                                    points.Add(listDgv[i].Location);
                                    points.Add(new Point(listDgv[j].Location.X, listDgv[i].Location.Y));
                                    points.Add(new Point(listDgv[j].Location.X, listDgv[j].Location.Y + listDgv[j].Height));
                                    gp.DrawLines(myPen, points.ToArray());
                                    hashtable.Add(points, fk);
                                }
                                //referenced table is below referencing table
                                else
                                {
                                    List<Point> points = new List<Point>();
                                    points.Add(new Point(listDgv[i].Location.X, listDgv[i].Location.Y + listDgv[i].Height));
                                    points.Add(new Point(listDgv[j].Location.X, listDgv[i].Location.Y + listDgv[i].Height));
                                    points.Add(listDgv[j].Location);
                                    gp.DrawLines(myPen, points.ToArray());
                                    hashtable.Add(points, fk);
                                }
                            }
                        }
                    }
                }
            }

        }

        private void cmbListDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnGenerate.Enabled = true;
        }

        #region function panel1_MouseDoubleClick(object sender, MouseEventArgs e) description
        /**
         * Showing ForeignKey detail information
        **/
        #endregion
        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<Point> isInSide = isInsideArror(e.Location);
            if (isInSide != null)
            {
                ForeignKey khoa = (ForeignKey)hashtable[isInSide];
                FK_Info fK_Info = new FK_Info(khoa);
                fK_Info.ShowDialog();
            }
        }


    }
}
