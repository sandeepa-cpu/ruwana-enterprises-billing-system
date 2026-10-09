namespace Billing_Inventory_Management_System
{
    partial class frm_OT_Rates
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_Hired = new System.Windows.Forms.RadioButton();
            this.rb_Office = new System.Windows.Forms.RadioButton();
            this.lbl_Ten_No = new System.Windows.Forms.Label();
            this.cmb_Ten_No = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblHalfDay = new System.Windows.Forms.Label();
            this.cmb_Find_Emp = new System.Windows.Forms.ComboBox();
            this.txt_Emp_No = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_OT_VALUE = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlOTMethod = new System.Windows.Forms.Panel();
            this.rbtHalfday = new System.Windows.Forms.RadioButton();
            this.rbtDuration = new System.Windows.Forms.RadioButton();
            this.rbtNormalOT = new System.Windows.Forms.RadioButton();
            this.rbtSubLoc = new System.Windows.Forms.RadioButton();
            this.pnlTender = new System.Windows.Forms.Panel();
            this.cmbSubLocation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Ten_No = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pnlDuration = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlOTMethod.SuspendLayout();
            this.pnlTender.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.pnlDuration.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_Hired);
            this.groupBox2.Controls.Add(this.rb_Office);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 52);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Over Time Method";
            // 
            // rb_Hired
            // 
            this.rb_Hired.AutoSize = true;
            this.rb_Hired.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Hired.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Hired.Location = new System.Drawing.Point(285, 24);
            this.rb_Hired.Name = "rb_Hired";
            this.rb_Hired.Size = new System.Drawing.Size(131, 17);
            this.rb_Hired.TabIndex = 2;
            this.rb_Hired.TabStop = true;
            this.rb_Hired.Text = "Tender Employees";
            this.rb_Hired.UseVisualStyleBackColor = true;
            this.rb_Hired.CheckedChanged += new System.EventHandler(this.rb_Hired_CheckedChanged);
            // 
            // rb_Office
            // 
            this.rb_Office.AutoSize = true;
            this.rb_Office.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Office.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Office.Location = new System.Drawing.Point(88, 24);
            this.rb_Office.Name = "rb_Office";
            this.rb_Office.Size = new System.Drawing.Size(124, 17);
            this.rb_Office.TabIndex = 1;
            this.rb_Office.TabStop = true;
            this.rb_Office.Text = "Office Employees";
            this.rb_Office.UseVisualStyleBackColor = true;
            this.rb_Office.CheckedChanged += new System.EventHandler(this.rb_Office_CheckedChanged);
            // 
            // lbl_Ten_No
            // 
            this.lbl_Ten_No.AutoSize = true;
            this.lbl_Ten_No.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ten_No.Location = new System.Drawing.Point(14, 34);
            this.lbl_Ten_No.Name = "lbl_Ten_No";
            this.lbl_Ten_No.Size = new System.Drawing.Size(105, 13);
            this.lbl_Ten_No.TabIndex = 70;
            this.lbl_Ten_No.Text = "Select Tender No";
            // 
            // cmb_Ten_No
            // 
            this.cmb_Ten_No.BackColor = System.Drawing.Color.White;
            this.cmb_Ten_No.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Ten_No.FormattingEnabled = true;
            this.cmb_Ten_No.Location = new System.Drawing.Point(124, 34);
            this.cmb_Ten_No.Name = "cmb_Ten_No";
            this.cmb_Ten_No.Size = new System.Drawing.Size(348, 21);
            this.cmb_Ten_No.TabIndex = 1;
            this.cmb_Ten_No.SelectedValueChanged += new System.EventHandler(this.cmb_Ten_No_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblHalfDay);
            this.groupBox1.Controls.Add(this.cmb_Find_Emp);
            this.groupBox1.Controls.Add(this.txt_Emp_No);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_OT_VALUE);
            this.groupBox1.Location = new System.Drawing.Point(5, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 84);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            // 
            // lblHalfDay
            // 
            this.lblHalfDay.AutoSize = true;
            this.lblHalfDay.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalfDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHalfDay.Location = new System.Drawing.Point(199, 55);
            this.lblHalfDay.Name = "lblHalfDay";
            this.lblHalfDay.Size = new System.Drawing.Size(145, 13);
            this.lblHalfDay.TabIndex = 10;
            this.lblHalfDay.Text = "Enter No. of Halfdays";
            this.lblHalfDay.Visible = false;
            // 
            // cmb_Find_Emp
            // 
            this.cmb_Find_Emp.BackColor = System.Drawing.Color.White;
            this.cmb_Find_Emp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Find_Emp.FormattingEnabled = true;
            this.cmb_Find_Emp.Location = new System.Drawing.Point(123, 19);
            this.cmb_Find_Emp.Name = "cmb_Find_Emp";
            this.cmb_Find_Emp.Size = new System.Drawing.Size(350, 21);
            this.cmb_Find_Emp.TabIndex = 2;
            this.cmb_Find_Emp.Enter += new System.EventHandler(this.cmb_Find_Emp_Enter);
            this.cmb_Find_Emp.SelectedValueChanged += new System.EventHandler(this.cmb_Find_Emp_SelectedValueChanged);
            // 
            // txt_Emp_No
            // 
            this.txt_Emp_No.BackColor = System.Drawing.Color.White;
            this.txt_Emp_No.Location = new System.Drawing.Point(123, 19);
            this.txt_Emp_No.MaxLength = 15;
            this.txt_Emp_No.Name = "txt_Emp_No";
            this.txt_Emp_No.ReadOnly = true;
            this.txt_Emp_No.Size = new System.Drawing.Size(70, 21);
            this.txt_Emp_No.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "EPF Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "No. of  Units";
            // 
            // txt_OT_VALUE
            // 
            this.txt_OT_VALUE.Location = new System.Drawing.Point(123, 52);
            this.txt_OT_VALUE.MaxLength = 10;
            this.txt_OT_VALUE.Name = "txt_OT_VALUE";
            this.txt_OT_VALUE.Size = new System.Drawing.Size(70, 21);
            this.txt_OT_VALUE.TabIndex = 3;
            this.txt_OT_VALUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Update);
            this.groupBox4.Controls.Add(this.btn_Add);
            this.groupBox4.Controls.Add(this.btn_Back);
            this.groupBox4.Location = new System.Drawing.Point(5, 367);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(479, 40);
            this.groupBox4.TabIndex = 69;
            this.groupBox4.TabStop = false;
            // 
            // btn_Update
            // 
            this.btn_Update.Enabled = false;
            this.btn_Update.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(290, 13);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(100, 22);
            this.btn_Update.TabIndex = 6;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Enabled = false;
            this.btn_Add.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(89, 13);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(195, 22);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "Save Over Time";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.Location = new System.Drawing.Point(396, 13);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(78, 22);
            this.btn_Back.TabIndex = 5;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlOTMethod);
            this.groupBox3.Controls.Add(this.pnlTender);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(5, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(479, 136);
            this.groupBox3.TabIndex = 76;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Tender";
            // 
            // pnlOTMethod
            // 
            this.pnlOTMethod.Controls.Add(this.rbtHalfday);
            this.pnlOTMethod.Controls.Add(this.rbtDuration);
            this.pnlOTMethod.Controls.Add(this.rbtNormalOT);
            this.pnlOTMethod.Controls.Add(this.rbtSubLoc);
            this.pnlOTMethod.Location = new System.Drawing.Point(1, 17);
            this.pnlOTMethod.Name = "pnlOTMethod";
            this.pnlOTMethod.Size = new System.Drawing.Size(473, 33);
            this.pnlOTMethod.TabIndex = 79;
            // 
            // rbtHalfday
            // 
            this.rbtHalfday.AutoSize = true;
            this.rbtHalfday.Location = new System.Drawing.Point(382, 9);
            this.rbtHalfday.Name = "rbtHalfday";
            this.rbtHalfday.Size = new System.Drawing.Size(75, 17);
            this.rbtHalfday.TabIndex = 82;
            this.rbtHalfday.TabStop = true;
            this.rbtHalfday.Text = "Halfday";
            this.rbtHalfday.UseVisualStyleBackColor = true;
            this.rbtHalfday.CheckedChanged += new System.EventHandler(this.rbtHalfday_CheckedChanged);
            // 
            // rbtDuration
            // 
            this.rbtDuration.AutoSize = true;
            this.rbtDuration.Location = new System.Drawing.Point(261, 9);
            this.rbtDuration.Name = "rbtDuration";
            this.rbtDuration.Size = new System.Drawing.Size(81, 17);
            this.rbtDuration.TabIndex = 81;
            this.rbtDuration.TabStop = true;
            this.rbtDuration.Text = "Duration";
            this.rbtDuration.UseVisualStyleBackColor = true;
            this.rbtDuration.CheckedChanged += new System.EventHandler(this.rbtDuration_CheckedChanged);
            // 
            // rbtNormalOT
            // 
            this.rbtNormalOT.AutoSize = true;
            this.rbtNormalOT.Location = new System.Drawing.Point(13, 9);
            this.rbtNormalOT.Name = "rbtNormalOT";
            this.rbtNormalOT.Size = new System.Drawing.Size(72, 17);
            this.rbtNormalOT.TabIndex = 79;
            this.rbtNormalOT.TabStop = true;
            this.rbtNormalOT.Text = "Normal";
            this.rbtNormalOT.UseVisualStyleBackColor = true;
            this.rbtNormalOT.CheckedChanged += new System.EventHandler(this.rbtNormalOT_CheckedChanged);
            // 
            // rbtSubLoc
            // 
            this.rbtSubLoc.AutoSize = true;
            this.rbtSubLoc.Location = new System.Drawing.Point(119, 9);
            this.rbtSubLoc.Name = "rbtSubLoc";
            this.rbtSubLoc.Size = new System.Drawing.Size(108, 17);
            this.rbtSubLoc.TabIndex = 80;
            this.rbtSubLoc.TabStop = true;
            this.rbtSubLoc.Text = "Sub Location";
            this.rbtSubLoc.UseVisualStyleBackColor = true;
            this.rbtSubLoc.CheckedChanged += new System.EventHandler(this.rbtSubLoc_CheckedChanged);
            // 
            // pnlTender
            // 
            this.pnlTender.Controls.Add(this.cmb_Ten_No);
            this.pnlTender.Controls.Add(this.cmbSubLocation);
            this.pnlTender.Controls.Add(this.lbl_Ten_No);
            this.pnlTender.Controls.Add(this.label2);
            this.pnlTender.Controls.Add(this.txt_Ten_No);
            this.pnlTender.Location = new System.Drawing.Point(1, 62);
            this.pnlTender.Name = "pnlTender";
            this.pnlTender.Size = new System.Drawing.Size(475, 64);
            this.pnlTender.TabIndex = 78;
            // 
            // cmbSubLocation
            // 
            this.cmbSubLocation.BackColor = System.Drawing.Color.White;
            this.cmbSubLocation.Enabled = false;
            this.cmbSubLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubLocation.FormattingEnabled = true;
            this.cmbSubLocation.Location = new System.Drawing.Point(124, 3);
            this.cmbSubLocation.Name = "cmbSubLocation";
            this.cmbSubLocation.Size = new System.Drawing.Size(213, 21);
            this.cmbSubLocation.TabIndex = 77;
            this.cmbSubLocation.SelectedValueChanged += new System.EventHandler(this.cmbSubLocation_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Sub Location";
            // 
            // txt_Ten_No
            // 
            this.txt_Ten_No.BackColor = System.Drawing.Color.White;
            this.txt_Ten_No.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ten_No.Location = new System.Drawing.Point(125, 34);
            this.txt_Ten_No.MaxLength = 50;
            this.txt_Ten_No.Name = "txt_Ten_No";
            this.txt_Ten_No.ReadOnly = true;
            this.txt_Ten_No.Size = new System.Drawing.Size(70, 21);
            this.txt_Ten_No.TabIndex = 78;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pnlDuration);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(7, 213);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(477, 58);
            this.groupBox5.TabIndex = 77;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Selecte Duration Type";
            // 
            // pnlDuration
            // 
            this.pnlDuration.Controls.Add(this.label3);
            this.pnlDuration.Controls.Add(this.cmbPeriod);
            this.pnlDuration.Enabled = false;
            this.pnlDuration.Location = new System.Drawing.Point(6, 18);
            this.pnlDuration.Name = "pnlDuration";
            this.pnlDuration.Size = new System.Drawing.Size(464, 32);
            this.pnlDuration.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Duration";
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Items.AddRange(new object[] {
            "9 - 12",
            "12 - 18",
            "18 - 24"});
            this.cmbPeriod.Location = new System.Drawing.Point(118, 6);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(102, 21);
            this.cmbPeriod.TabIndex = 11;
            this.cmbPeriod.SelectedValueChanged += new System.EventHandler(this.cmbPeriod_SelectedValueChanged);
            // 
            // frm_OT_Rates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(489, 415);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_OT_Rates";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Over Time Rates";
            this.Load += new System.EventHandler(this.frm_OT_Rates_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.pnlOTMethod.ResumeLayout(false);
            this.pnlOTMethod.PerformLayout();
            this.pnlTender.ResumeLayout(false);
            this.pnlTender.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.pnlDuration.ResumeLayout(false);
            this.pnlDuration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_Hired;
        private System.Windows.Forms.RadioButton rb_Office;
        private System.Windows.Forms.Label lbl_Ten_No;
        private System.Windows.Forms.ComboBox cmb_Ten_No;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Emp_No;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_OT_VALUE;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmb_Find_Emp;
        private System.Windows.Forms.ComboBox cmbSubLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlTender;
        private System.Windows.Forms.TextBox txt_Ten_No;
        private System.Windows.Forms.RadioButton rbtNormalOT;
        private System.Windows.Forms.RadioButton rbtSubLoc;
        private System.Windows.Forms.RadioButton rbtDuration;
        private System.Windows.Forms.Panel pnlOTMethod;
        private System.Windows.Forms.RadioButton rbtHalfday;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel pnlDuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.Label lblHalfDay;
        private System.Windows.Forms.Button btn_Update;

    }
}