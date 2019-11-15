namespace PROJECT_1
{
    partial class FK_Info
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
            this.lblRelationshipName = new System.Windows.Forms.Label();
            this.txtRelationshipName = new System.Windows.Forms.TextBox();
            this.lbl_PK_Table = new System.Windows.Forms.Label();
            this.lbl_FK_Table = new System.Windows.Forms.Label();
            this.txt_FK_TableName = new System.Windows.Forms.TextBox();
            this.txt_PK_TableName = new System.Windows.Forms.TextBox();
            this.lbl_PK = new System.Windows.Forms.Label();
            this.lbl_FK = new System.Windows.Forms.Label();
            this.txt_PK = new System.Windows.Forms.TextBox();
            this.txt_FK = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblRelationshipName
            // 
            this.lblRelationshipName.AutoSize = true;
            this.lblRelationshipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelationshipName.Location = new System.Drawing.Point(12, 9);
            this.lblRelationshipName.Name = "lblRelationshipName";
            this.lblRelationshipName.Size = new System.Drawing.Size(141, 20);
            this.lblRelationshipName.TabIndex = 1;
            this.lblRelationshipName.Text = "Relationship name";
            // 
            // txtRelationshipName
            // 
            this.txtRelationshipName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtRelationshipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelationshipName.Location = new System.Drawing.Point(16, 32);
            this.txtRelationshipName.Name = "txtRelationshipName";
            this.txtRelationshipName.ReadOnly = true;
            this.txtRelationshipName.Size = new System.Drawing.Size(462, 26);
            this.txtRelationshipName.TabIndex = 2;
            // 
            // lbl_PK_Table
            // 
            this.lbl_PK_Table.AutoSize = true;
            this.lbl_PK_Table.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PK_Table.Location = new System.Drawing.Point(12, 76);
            this.lbl_PK_Table.Name = "lbl_PK_Table";
            this.lbl_PK_Table.Size = new System.Drawing.Size(132, 20);
            this.lbl_PK_Table.TabIndex = 3;
            this.lbl_PK_Table.Text = "Referenced table";
            // 
            // lbl_FK_Table
            // 
            this.lbl_FK_Table.AutoSize = true;
            this.lbl_FK_Table.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FK_Table.Location = new System.Drawing.Point(301, 76);
            this.lbl_FK_Table.Name = "lbl_FK_Table";
            this.lbl_FK_Table.Size = new System.Drawing.Size(135, 20);
            this.lbl_FK_Table.TabIndex = 4;
            this.lbl_FK_Table.Text = "Referencing table";
            // 
            // txt_FK_TableName
            // 
            this.txt_FK_TableName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_FK_TableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FK_TableName.Location = new System.Drawing.Point(296, 109);
            this.txt_FK_TableName.Name = "txt_FK_TableName";
            this.txt_FK_TableName.ReadOnly = true;
            this.txt_FK_TableName.Size = new System.Drawing.Size(182, 22);
            this.txt_FK_TableName.TabIndex = 6;
            // 
            // txt_PK_TableName
            // 
            this.txt_PK_TableName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_PK_TableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PK_TableName.Location = new System.Drawing.Point(16, 109);
            this.txt_PK_TableName.Name = "txt_PK_TableName";
            this.txt_PK_TableName.ReadOnly = true;
            this.txt_PK_TableName.Size = new System.Drawing.Size(182, 22);
            this.txt_PK_TableName.TabIndex = 7;
            // 
            // lbl_PK
            // 
            this.lbl_PK.AutoSize = true;
            this.lbl_PK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PK.Location = new System.Drawing.Point(21, 152);
            this.lbl_PK.Name = "lbl_PK";
            this.lbl_PK.Size = new System.Drawing.Size(91, 20);
            this.lbl_PK.TabIndex = 8;
            this.lbl_PK.Text = "Primary Key";
            // 
            // lbl_FK
            // 
            this.lbl_FK.AutoSize = true;
            this.lbl_FK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FK.Location = new System.Drawing.Point(301, 152);
            this.lbl_FK.Name = "lbl_FK";
            this.lbl_FK.Size = new System.Drawing.Size(93, 20);
            this.lbl_FK.TabIndex = 9;
            this.lbl_FK.Text = "Foreign Key";
            // 
            // txt_PK
            // 
            this.txt_PK.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_PK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PK.Location = new System.Drawing.Point(16, 190);
            this.txt_PK.Name = "txt_PK";
            this.txt_PK.ReadOnly = true;
            this.txt_PK.Size = new System.Drawing.Size(182, 22);
            this.txt_PK.TabIndex = 10;
            // 
            // txt_FK
            // 
            this.txt_FK.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_FK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FK.Location = new System.Drawing.Point(296, 190);
            this.txt_FK.Name = "txt_FK";
            this.txt_FK.ReadOnly = true;
            this.txt_FK.Size = new System.Drawing.Size(182, 22);
            this.txt_FK.TabIndex = 11;
            // 
            // FK_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 231);
            this.Controls.Add(this.txt_FK);
            this.Controls.Add(this.txt_PK);
            this.Controls.Add(this.lbl_FK);
            this.Controls.Add(this.lbl_PK);
            this.Controls.Add(this.txt_PK_TableName);
            this.Controls.Add(this.txt_FK_TableName);
            this.Controls.Add(this.lbl_FK_Table);
            this.Controls.Add(this.lbl_PK_Table);
            this.Controls.Add(this.txtRelationshipName);
            this.Controls.Add(this.lblRelationshipName);
            this.Name = "FK_Info";
            this.Text = "FK_Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRelationshipName;
        private System.Windows.Forms.TextBox txtRelationshipName;
        private System.Windows.Forms.Label lbl_PK_Table;
        private System.Windows.Forms.Label lbl_FK_Table;
        private System.Windows.Forms.TextBox txt_FK_TableName;
        private System.Windows.Forms.TextBox txt_PK_TableName;
        private System.Windows.Forms.Label lbl_PK;
        private System.Windows.Forms.Label lbl_FK;
        private System.Windows.Forms.TextBox txt_PK;
        private System.Windows.Forms.TextBox txt_FK;
    }
}