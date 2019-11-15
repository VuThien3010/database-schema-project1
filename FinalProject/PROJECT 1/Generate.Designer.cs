namespace PROJECT_1
{
    partial class Generate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generate));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cmbListDatabase = new System.Windows.Forms.ComboBox();
            this.lblDB_Name = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.lblDBId = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.txtDBId = new System.Windows.Forms.TextBox();
            this.txtCreatedDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(3, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 517);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerate.BackgroundImage")));
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(237, 2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(183, 68);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cmbListDatabase
            // 
            this.cmbListDatabase.FormattingEnabled = true;
            this.cmbListDatabase.Location = new System.Drawing.Point(16, 49);
            this.cmbListDatabase.Name = "cmbListDatabase";
            this.cmbListDatabase.Size = new System.Drawing.Size(183, 21);
            this.cmbListDatabase.TabIndex = 10;
            this.cmbListDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbListDatabase_SelectedIndexChanged);
            // 
            // lblDB_Name
            // 
            this.lblDB_Name.AutoSize = true;
            this.lblDB_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDB_Name.Location = new System.Drawing.Point(12, 9);
            this.lblDB_Name.Name = "lblDB_Name";
            this.lblDB_Name.Size = new System.Drawing.Size(182, 20);
            this.lblDB_Name.TabIndex = 11;
            this.lblDB_Name.Text = "Choose Other Database";
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBName.Location = new System.Drawing.Point(610, 9);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(64, 16);
            this.lblDBName.TabIndex = 12;
            this.lblDBName.Text = "DBName";
            // 
            // lblDBId
            // 
            this.lblDBId.AutoSize = true;
            this.lblDBId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBId.Location = new System.Drawing.Point(610, 34);
            this.lblDBId.Name = "lblDBId";
            this.lblDBId.Size = new System.Drawing.Size(38, 16);
            this.lblDBId.TabIndex = 13;
            this.lblDBId.Text = "DBId";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedDate.Location = new System.Drawing.Point(610, 60);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(88, 16);
            this.lblCreatedDate.TabIndex = 14;
            this.lblCreatedDate.Text = "Created Date";
            // 
            // txtDBName
            // 
            this.txtDBName.BackColor = System.Drawing.Color.White;
            this.txtDBName.Location = new System.Drawing.Point(722, 5);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.ReadOnly = true;
            this.txtDBName.Size = new System.Drawing.Size(155, 20);
            this.txtDBName.TabIndex = 15;
            // 
            // txtDBId
            // 
            this.txtDBId.BackColor = System.Drawing.Color.White;
            this.txtDBId.Location = new System.Drawing.Point(722, 31);
            this.txtDBId.Name = "txtDBId";
            this.txtDBId.ReadOnly = true;
            this.txtDBId.Size = new System.Drawing.Size(155, 20);
            this.txtDBId.TabIndex = 16;
            // 
            // txtCreatedDate
            // 
            this.txtCreatedDate.BackColor = System.Drawing.Color.White;
            this.txtCreatedDate.Location = new System.Drawing.Point(722, 59);
            this.txtCreatedDate.Name = "txtCreatedDate";
            this.txtCreatedDate.ReadOnly = true;
            this.txtCreatedDate.Size = new System.Drawing.Size(155, 20);
            this.txtCreatedDate.TabIndex = 17;
            // 
            // Generate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 619);
            this.Controls.Add(this.txtCreatedDate);
            this.Controls.Add(this.txtDBId);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.lblCreatedDate);
            this.Controls.Add(this.lblDBId);
            this.Controls.Add(this.lblDBName);
            this.Controls.Add(this.lblDB_Name);
            this.Controls.Add(this.cmbListDatabase);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.panel1);
            this.Name = "Generate";
            this.Text = "Generate";
            this.Load += new System.EventHandler(this.Generate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cmbListDatabase;
        private System.Windows.Forms.Label lblDB_Name;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.Label lblDBId;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.TextBox txtDBId;
        private System.Windows.Forms.TextBox txtCreatedDate;
    }
}