namespace Billing_Inventory_Management_System
{
    partial class frm_EmployeeUnits
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
            this.txt_TenNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Month = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_SubLocation = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_TenNo = new System.Windows.Forms.ComboBox();
            this.btn_Find = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Year = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubLoc = new System.Windows.Forms.TextBox();
            this.btn_ReAllow = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.lblEarDed = new System.Windows.Forms.LinkLabel();
            this.lblOT = new System.Windows.Forms.LinkLabel();
            this.lblOffEmpPay = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_TenNo
            // 
            this.txt_TenNo.AllowDrop = true;
            this.txt_TenNo.Location = new System.Drawing.Point(95, 51);
            this.txt_TenNo.Name = "txt_TenNo";
            this.txt_TenNo.Size = new System.Drawing.Size(59, 21);
            this.txt_TenNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tender No";
            // 
            // txt_Month
            // 
            this.txt_Month.Location = new System.Drawing.Point(515, 24);
            this.txt_Month.Name = "txt_Month";
            this.txt_Month.Size = new System.Drawing.Size(63, 21);
            this.txt_Month.TabIndex = 3;
            this.txt_Month.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Month_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_SubLocation);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmb_TenNo);
            this.groupBox1.Controls.Add(this.txt_TenNo);
            this.groupBox1.Controls.Add(this.btn_Find);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_Month);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_Year);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSubLoc);
            this.groupBox1.Location = new System.Drawing.Point(1, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 79);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select the Tender Range";
            // 
            // cmb_SubLocation
            // 
            this.cmb_SubLocation.FormattingEnabled = true;
            this.cmb_SubLocation.Location = new System.Drawing.Point(95, 24);
            this.cmb_SubLocation.Name = "cmb_SubLocation";
            this.cmb_SubLocation.Size = new System.Drawing.Size(220, 21);
            this.cmb_SubLocation.TabIndex = 9;
            this.cmb_SubLocation.SelectedValueChanged += new System.EventHandler(this.cmb_SubLocation_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Sub Location";
            // 
            // cmb_TenNo
            // 
            this.cmb_TenNo.FormattingEnabled = true;
            this.cmb_TenNo.Location = new System.Drawing.Point(95, 51);
            this.cmb_TenNo.Name = "cmb_TenNo";
            this.cmb_TenNo.Size = new System.Drawing.Size(483, 21);
            this.cmb_TenNo.TabIndex = 7;
            this.cmb_TenNo.SelectedValueChanged += new System.EventHandler(this.cmb_TenNo_SelectedValueChanged);
            // 
            // btn_Find
            // 
            this.btn_Find.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Find.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Find.ForeColor = System.Drawing.Color.Blue;
            this.btn_Find.Location = new System.Drawing.Point(588, 49);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(95, 24);
            this.btn_Find.TabIndex = 4;
            this.btn_Find.Text = "Find";
            this.btn_Find.UseVisualStyleBackColor = false;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(471, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Month";
            // 
            // txt_Year
            // 
            this.txt_Year.Location = new System.Drawing.Point(383, 24);
            this.txt_Year.Name = "txt_Year";
            this.txt_Year.Size = new System.Drawing.Size(69, 21);
            this.txt_Year.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Year";
            // 
            // txtSubLoc
            // 
            this.txtSubLoc.AllowDrop = true;
            this.txtSubLoc.Location = new System.Drawing.Point(95, 24);
            this.txtSubLoc.Name = "txtSubLoc";
            this.txtSubLoc.Size = new System.Drawing.Size(59, 21);
            this.txtSubLoc.TabIndex = 10;
            // 
            // btn_ReAllow
            // 
            this.btn_ReAllow.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ReAllow.Enabled = false;
            this.btn_ReAllow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReAllow.ForeColor = System.Drawing.Color.Blue;
            this.btn_ReAllow.Location = new System.Drawing.Point(1, 555);
            this.btn_ReAllow.Name = "btn_ReAllow";
            this.btn_ReAllow.Size = new System.Drawing.Size(274, 24);
            this.btn_ReAllow.TabIndex = 11;
            this.btn_ReAllow.Text = "Allocate Changed Tender Employees";
            this.btn_ReAllow.UseVisualStyleBackColor = false;
            this.btn_ReAllow.Click += new System.EventHandler(this.btn_ReAllow_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Save.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.Blue;
            this.btn_Save.Location = new System.Drawing.Point(425, 15);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(184, 23);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Update No. of Units";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Quit
            // 
            this.btn_Quit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Quit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.ForeColor = System.Drawing.Color.Blue;
            this.btn_Quit.Location = new System.Drawing.Point(615, 14);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(67, 24);
            this.btn_Quit.TabIndex = 6;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = false;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Quit);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btn_Save);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(1, 485);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(689, 47);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(132, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(348, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "No. of Employees  -";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Total Units for the Tender  -";
            // 
            // Grid_A
            // 
            this.Grid_A.AllowUserToAddRows = false;
            this.Grid_A.AllowUserToDeleteRows = false;
            this.Grid_A.AllowUserToResizeRows = false;
            this.Grid_A.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Grid_A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_A.Location = new System.Drawing.Point(1, 92);
            this.Grid_A.Name = "Grid_A";
            this.Grid_A.Size = new System.Drawing.Size(689, 396);
            this.Grid_A.StandardTab = true;
            this.Grid_A.TabIndex = 13;
            // 
            // lblEarDed
            // 
            this.lblEarDed.AutoSize = true;
            this.lblEarDed.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEarDed.Location = new System.Drawing.Point(452, 537);
            this.lblEarDed.Name = "lblEarDed";
            this.lblEarDed.Size = new System.Drawing.Size(148, 13);
            this.lblEarDed.TabIndex = 21;
            this.lblEarDed.TabStop = true;
            this.lblEarDed.Text = "Earnings and Deductions";
            this.lblEarDed.VisitedLinkColor = System.Drawing.Color.Fuchsia;
            this.lblEarDed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEarDed_LinkClicked);
            // 
            // lblOT
            // 
            this.lblOT.AutoSize = true;
            this.lblOT.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOT.Location = new System.Drawing.Point(619, 537);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(67, 13);
            this.lblOT.TabIndex = 22;
            this.lblOT.TabStop = true;
            this.lblOT.Text = "Over Time";
            this.lblOT.VisitedLinkColor = System.Drawing.Color.Fuchsia;
            this.lblOT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblOT_LinkClicked);
            // 
            // lblOffEmpPay
            // 
            this.lblOffEmpPay.AutoSize = true;
            this.lblOffEmpPay.Enabled = false;
            this.lblOffEmpPay.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOffEmpPay.Location = new System.Drawing.Point(5, 537);
            this.lblOffEmpPay.Name = "lblOffEmpPay";
            this.lblOffEmpPay.Size = new System.Drawing.Size(208, 13);
            this.lblOffEmpPay.TabIndex = 23;
            this.lblOffEmpPay.TabStop = true;
            this.lblOffEmpPay.Text = "Manage Office Employee Payments";
            this.lblOffEmpPay.VisitedLinkColor = System.Drawing.Color.Fuchsia;
            this.lblOffEmpPay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblOffEmpPay_LinkClicked);
            // 
            // frm_EmployeeUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(691, 580);
            this.Controls.Add(this.btn_ReAllow);
            this.Controls.Add(this.lblOffEmpPay);
            this.Controls.Add(this.lblOT);
            this.Controls.Add(this.lblEarDed);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Grid_A);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_EmployeeUnits";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Employee Monthly Attendance";
            this.Load += new System.EventHandler(this.frm_EmployeeUnits_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_TenNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Month;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Year;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_TenNo;
        private System.Windows.Forms.ComboBox cmb_SubLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.TextBox txtSubLoc;
        private System.Windows.Forms.LinkLabel lblEarDed;
        private System.Windows.Forms.LinkLabel lblOT;
        private System.Windows.Forms.LinkLabel lblOffEmpPay;
        private System.Windows.Forms.Button btn_ReAllow;
    }
}