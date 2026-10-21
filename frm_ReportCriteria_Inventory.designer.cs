namespace Billing_Inventory_Management_System
{
    partial class frm_ReportCriteria_Inventory
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Master Info.");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Supplier wise Details");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Supplier Info.", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("GRN Range");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Received Info.", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Issued Info.");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Stock Balance - In Detail");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Stock Balance - Summary");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Return to Supplier");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Return to Customer");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Sales Info. (Profit / Loss)");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Print Invoice");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Supplier Credit Info.");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Customer Credit Info.");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Parts Re-Order");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Reports", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ReportCriteria_Inventory));
            this.grbDates = new System.Windows.Forms.GroupBox();
            this.lbl_SysDate = new System.Windows.Forms.DateTimePicker();
            this.pnlDt = new System.Windows.Forms.Panel();
            this.lbl_SysLast = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label58 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trvReports = new System.Windows.Forms.TreeView();
            this.lblSEQ = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCUSSUP = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPwdOK = new System.Windows.Forms.Label();
            this.gbPSW = new System.Windows.Forms.GroupBox();
            this.lblwait = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblINVNO = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grbCriteria = new System.Windows.Forms.GroupBox();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.lblPW = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cmbNICNo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLoanNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNICNo = new System.Windows.Forms.TextBox();
            this.txtBankBranch = new System.Windows.Forms.TextBox();
            this.txtCheNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnComBank = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dt_Date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.grbDates.SuspendLayout();
            this.pnlDt.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbPSW.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDates
            // 
            this.grbDates.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grbDates.Controls.Add(this.lbl_SysDate);
            this.grbDates.Controls.Add(this.pnlDt);
            this.grbDates.Controls.Add(this.label2);
            this.grbDates.Location = new System.Drawing.Point(5, 4);
            this.grbDates.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbDates.Name = "grbDates";
            this.grbDates.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbDates.Size = new System.Drawing.Size(479, 240);
            this.grbDates.TabIndex = 0;
            this.grbDates.TabStop = false;
            this.grbDates.Text = "Select Date";
            // 
            // lbl_SysDate
            // 
            this.lbl_SysDate.CustomFormat = "yyyy-MM-dd";
            this.lbl_SysDate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SysDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lbl_SysDate.Location = new System.Drawing.Point(63, 36);
            this.lbl_SysDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_SysDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.lbl_SysDate.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.lbl_SysDate.Name = "lbl_SysDate";
            this.lbl_SysDate.Size = new System.Drawing.Size(108, 23);
            this.lbl_SysDate.TabIndex = 90;
            this.lbl_SysDate.Value = new System.DateTime(2017, 5, 14, 0, 0, 0, 0);
            // 
            // pnlDt
            // 
            this.pnlDt.Controls.Add(this.lbl_SysLast);
            this.pnlDt.Controls.Add(this.label7);
            this.pnlDt.Enabled = false;
            this.pnlDt.Location = new System.Drawing.Point(209, 29);
            this.pnlDt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDt.Name = "pnlDt";
            this.pnlDt.Size = new System.Drawing.Size(198, 36);
            this.pnlDt.TabIndex = 89;
            // 
            // lbl_SysLast
            // 
            this.lbl_SysLast.CustomFormat = "yyyy-MM-dd";
            this.lbl_SysLast.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SysLast.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lbl_SysLast.Location = new System.Drawing.Point(87, 4);
            this.lbl_SysLast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_SysLast.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.lbl_SysLast.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.lbl_SysLast.Name = "lbl_SysLast";
            this.lbl_SysLast.Size = new System.Drawing.Size(108, 23);
            this.lbl_SysLast.TabIndex = 79;
            this.lbl_SysLast.Value = new System.DateTime(2017, 5, 14, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 18);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ending Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(108, 656);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 18);
            this.label9.TabIndex = 89;
            this.label9.Text = "Selected Month";
            this.label9.Visible = false;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // cmbMonths
            // 
            this.cmbMonths.Enabled = false;
            this.cmbMonths.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Items.AddRange(new object[] {
            "JAN - FEB",
            "MAR - APR",
            "MAY - JUN",
            "JUL - AUG",
            "SEP - OCT",
            "NOV - DEC"});
            this.cmbMonths.Location = new System.Drawing.Point(206, 651);
            this.cmbMonths.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(122, 26);
            this.cmbMonths.TabIndex = 88;
            this.cmbMonths.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(75, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 79;
            this.label1.Text = "Select Member";
            this.label1.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label58);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitContainer1.Panel2.Controls.Add(this.lblSEQ);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.lblPwdOK);
            this.splitContainer1.Panel2.Controls.Add(this.gbPSW);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.grbCriteria);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.cmbMonths);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1001, 840);
            this.splitContainer1.SplitterDistance = 507;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label58.Location = new System.Drawing.Point(5, 3);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(206, 29);
            this.label58.TabIndex = 265;
            this.label58.Text = "REPORT CRITIRIA";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trvReports);
            this.groupBox2.Location = new System.Drawing.Point(0, 26);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(506, 815);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            // 
            // trvReports
            // 
            this.trvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvReports.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvReports.Location = new System.Drawing.Point(3, 20);
            this.trvReports.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trvReports.Name = "trvReports";
            treeNode1.Name = "chnMain";
            treeNode1.Text = "Master Info.";
            treeNode2.Name = "chnSupSum";
            treeNode2.Text = "Supplier wise Details";
            treeNode3.Name = "chnSup";
            treeNode3.Text = "Supplier Info.";
            treeNode4.Name = "chnGRNR";
            treeNode4.Text = "GRN Range";
            treeNode5.Name = "chnGRN";
            treeNode5.Text = "Received Info.";
            treeNode6.Name = "chnMIR";
            treeNode6.Text = "Issued Info.";
            treeNode7.ForeColor = System.Drawing.Color.Black;
            treeNode7.Name = "chnSBD";
            treeNode7.Text = "Stock Balance - In Detail";
            treeNode8.Name = "chnSBS";
            treeNode8.Text = "Stock Balance - Summary";
            treeNode9.Name = "chnRSup";
            treeNode9.Text = "Return to Supplier";
            treeNode10.Name = "chnRCus";
            treeNode10.Text = "Return to Customer";
            treeNode11.Name = "chnPro";
            treeNode11.Text = "Sales Info. (Profit / Loss)";
            treeNode12.Name = "chnInv";
            treeNode12.Text = "Print Invoice";
            treeNode13.Name = "chnSC";
            treeNode13.Text = "Supplier Credit Info.";
            treeNode14.Name = "chnCC";
            treeNode14.Text = "Customer Credit Info.";
            treeNode15.Name = "chnRe";
            treeNode15.Text = "Parts Re-Order";
            treeNode16.Name = "Node0";
            treeNode16.Text = "Reports";
            this.trvReports.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16});
            this.trvReports.Size = new System.Drawing.Size(500, 791);
            this.trvReports.TabIndex = 0;
            this.trvReports.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvReports_AfterSelect);
            // 
            // lblSEQ
            // 
            this.lblSEQ.AutoSize = true;
            this.lblSEQ.BackColor = System.Drawing.Color.Transparent;
            this.lblSEQ.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEQ.Location = new System.Drawing.Point(214, 101);
            this.lblSEQ.Name = "lblSEQ";
            this.lblSEQ.Size = new System.Drawing.Size(15, 16);
            this.lblSEQ.TabIndex = 94;
            this.lblSEQ.Text = "-";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblCUSSUP);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Location = new System.Drawing.Point(12, 179);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(457, 37);
            this.panel4.TabIndex = 94;
            this.panel4.Visible = false;
            // 
            // lblCUSSUP
            // 
            this.lblCUSSUP.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCUSSUP.FormattingEnabled = true;
            this.lblCUSSUP.Location = new System.Drawing.Point(205, 4);
            this.lblCUSSUP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCUSSUP.Name = "lblCUSSUP";
            this.lblCUSSUP.Size = new System.Drawing.Size(249, 26);
            this.lblCUSSUP.TabIndex = 92;
            this.lblCUSSUP.SelectedValueChanged += new System.EventHandler(this.lblSup_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(35, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 16);
            this.label11.TabIndex = 93;
            this.label11.Text = "Select Supplier";
            // 
            // lblPwdOK
            // 
            this.lblPwdOK.AutoSize = true;
            this.lblPwdOK.Enabled = false;
            this.lblPwdOK.Location = new System.Drawing.Point(9, 388);
            this.lblPwdOK.Name = "lblPwdOK";
            this.lblPwdOK.Size = new System.Drawing.Size(13, 18);
            this.lblPwdOK.TabIndex = 92;
            this.lblPwdOK.Text = "-";
            this.lblPwdOK.Visible = false;
            // 
            // gbPSW
            // 
            this.gbPSW.Controls.Add(this.lblwait);
            this.gbPSW.Controls.Add(this.lblPwd);
            this.gbPSW.Controls.Add(this.txtPwd);
            this.gbPSW.Location = new System.Drawing.Point(83, 388);
            this.gbPSW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPSW.Name = "gbPSW";
            this.gbPSW.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPSW.Size = new System.Drawing.Size(301, 123);
            this.gbPSW.TabIndex = 91;
            this.gbPSW.TabStop = false;
            this.gbPSW.Visible = false;
            this.gbPSW.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblwait
            // 
            this.lblwait.AutoSize = true;
            this.lblwait.Enabled = false;
            this.lblwait.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwait.Location = new System.Drawing.Point(98, 37);
            this.lblwait.Name = "lblwait";
            this.lblwait.Size = new System.Drawing.Size(112, 18);
            this.lblwait.TabIndex = 93;
            this.lblwait.Text = "PLEASE WAIT.....";
            this.lblwait.Visible = false;
            this.lblwait.Click += new System.EventHandler(this.label10_Click);
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Enabled = false;
            this.lblPwd.Location = new System.Drawing.Point(97, 94);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(13, 18);
            this.lblPwd.TabIndex = 92;
            this.lblPwd.Text = "-";
            this.lblPwd.Visible = false;
            this.lblPwd.Click += new System.EventHandler(this.lblPwd_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPwd.Location = new System.Drawing.Point(27, 63);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '•';
            this.txtPwd.Size = new System.Drawing.Size(246, 23);
            this.txtPwd.TabIndex = 0;
            this.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPwd.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPwd_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblINVNO);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(12, 147);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 37);
            this.panel2.TabIndex = 90;
            this.panel2.Visible = false;
            // 
            // lblINVNO
            // 
            this.lblINVNO.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblINVNO.FormattingEnabled = true;
            this.lblINVNO.Location = new System.Drawing.Point(205, 4);
            this.lblINVNO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblINVNO.Name = "lblINVNO";
            this.lblINVNO.Size = new System.Drawing.Size(249, 26);
            this.lblINVNO.TabIndex = 92;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 16);
            this.label8.TabIndex = 93;
            this.label8.Text = "Select Invoice No.";
            // 
            // grbCriteria
            // 
            this.grbCriteria.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grbCriteria.Controls.Add(this.txtPW);
            this.grbCriteria.Controls.Add(this.Grid_A);
            this.grbCriteria.Controls.Add(this.lblPW);
            this.grbCriteria.Controls.Add(this.lblName);
            this.grbCriteria.Controls.Add(this.cmbNICNo);
            this.grbCriteria.Controls.Add(this.label3);
            this.grbCriteria.Controls.Add(this.cmbLoanNo);
            this.grbCriteria.Controls.Add(this.label1);
            this.grbCriteria.Controls.Add(this.label6);
            this.grbCriteria.Controls.Add(this.txtNICNo);
            this.grbCriteria.Controls.Add(this.txtBankBranch);
            this.grbCriteria.Controls.Add(this.txtCheNo);
            this.grbCriteria.Controls.Add(this.label5);
            this.grbCriteria.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbCriteria.Enabled = false;
            this.grbCriteria.Location = new System.Drawing.Point(0, 826);
            this.grbCriteria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbCriteria.Name = "grbCriteria";
            this.grbCriteria.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbCriteria.Size = new System.Drawing.Size(489, 14);
            this.grbCriteria.TabIndex = 2;
            this.grbCriteria.TabStop = false;
            this.grbCriteria.Text = "Select Criteria";
            this.grbCriteria.Visible = false;
            // 
            // txtPW
            // 
            this.txtPW.BackColor = System.Drawing.SystemColors.Control;
            this.txtPW.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPW.Location = new System.Drawing.Point(24, -307);
            this.txtPW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '•';
            this.txtPW.Size = new System.Drawing.Size(124, 23);
            this.txtPW.TabIndex = 1;
            // 
            // Grid_A
            // 
            this.Grid_A.AllowUserToAddRows = false;
            this.Grid_A.AllowUserToDeleteRows = false;
            this.Grid_A.AllowUserToResizeColumns = false;
            this.Grid_A.AllowUserToResizeRows = false;
            this.Grid_A.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(4, 330);
            this.Grid_A.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Grid_A.Name = "Grid_A";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_A.RowHeadersVisible = false;
            this.Grid_A.RowHeadersWidth = 50;
            this.Grid_A.Size = new System.Drawing.Size(461, 55);
            this.Grid_A.TabIndex = 86;
            this.Grid_A.Visible = false;
            // 
            // lblPW
            // 
            this.lblPW.AutoSize = true;
            this.lblPW.BackColor = System.Drawing.SystemColors.Control;
            this.lblPW.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPW.Location = new System.Drawing.Point(78, 159);
            this.lblPW.Name = "lblPW";
            this.lblPW.Size = new System.Drawing.Size(130, 16);
            this.lblPW.TabIndex = 90;
            this.lblPW.Text = "Security Password";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Blue;
            this.lblName.Location = new System.Drawing.Point(3, 94);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 87;
            // 
            // cmbNICNo
            // 
            this.cmbNICNo.Enabled = false;
            this.cmbNICNo.FormattingEnabled = true;
            this.cmbNICNo.Location = new System.Drawing.Point(173, 220);
            this.cmbNICNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbNICNo.Name = "cmbNICNo";
            this.cmbNICNo.Size = new System.Drawing.Size(283, 26);
            this.cmbNICNo.TabIndex = 83;
            this.cmbNICNo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(75, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 81;
            this.label3.Text = "Loan No";
            this.label3.Visible = false;
            // 
            // cmbLoanNo
            // 
            this.cmbLoanNo.Enabled = false;
            this.cmbLoanNo.FormattingEnabled = true;
            this.cmbLoanNo.Location = new System.Drawing.Point(173, 258);
            this.cmbLoanNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbLoanNo.Name = "cmbLoanNo";
            this.cmbLoanNo.Size = new System.Drawing.Size(283, 26);
            this.cmbLoanNo.TabIndex = 80;
            this.cmbLoanNo.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Bank && Branch";
            this.label6.Visible = false;
            // 
            // txtNICNo
            // 
            this.txtNICNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtNICNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNICNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNICNo.ForeColor = System.Drawing.Color.Blue;
            this.txtNICNo.Location = new System.Drawing.Point(78, 155);
            this.txtNICNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNICNo.MaxLength = 10;
            this.txtNICNo.Name = "txtNICNo";
            this.txtNICNo.ReadOnly = true;
            this.txtNICNo.Size = new System.Drawing.Size(97, 14);
            this.txtNICNo.TabIndex = 1;
            this.txtNICNo.Visible = false;
            // 
            // txtBankBranch
            // 
            this.txtBankBranch.Location = new System.Drawing.Point(214, 346);
            this.txtBankBranch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBankBranch.Name = "txtBankBranch";
            this.txtBankBranch.Size = new System.Drawing.Size(244, 23);
            this.txtBankBranch.TabIndex = 8;
            this.txtBankBranch.Visible = false;
            // 
            // txtCheNo
            // 
            this.txtCheNo.Location = new System.Drawing.Point(79, 346);
            this.txtCheNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCheNo.Name = "txtCheNo";
            this.txtCheNo.Size = new System.Drawing.Size(128, 23);
            this.txtCheNo.TabIndex = 7;
            this.txtCheNo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cheque No:";
            this.label5.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbDates);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 252);
            this.panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Quit);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnSubmit);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnComBank);
            this.groupBox3.Location = new System.Drawing.Point(5, 752);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(479, 66);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // btn_Quit
            // 
            this.btn_Quit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Quit.BackgroundImage")));
            this.btn_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Quit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(342, 24);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(29, 29);
            this.btn_Quit.TabIndex = 268;
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(186, 20);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(146, 36);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(7, 21);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(174, 35);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(338, 20);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 36);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnComBank
            // 
            this.btnComBank.Location = new System.Drawing.Point(23, 21);
            this.btnComBank.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnComBank.Name = "btnComBank";
            this.btnComBank.Size = new System.Drawing.Size(125, 35);
            this.btnComBank.TabIndex = 6;
            this.btnComBank.Text = "Convert to Excel";
            this.btnComBank.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox4.Controls.Add(this.dt_Date);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(49, 679);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(385, 65);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Visible = false;
            // 
            // dt_Date
            // 
            this.dt_Date.CustomFormat = "yy-MM-dd";
            this.dt_Date.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_Date.Location = new System.Drawing.Point(161, 24);
            this.dt_Date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dt_Date.Name = "dt_Date";
            this.dt_Date.Size = new System.Drawing.Size(101, 23);
            this.dt_Date.TabIndex = 10;
            this.dt_Date.Value = new System.DateTime(2013, 12, 20, 0, 0, 0, 0);
            this.dt_Date.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Select Processing Date";
            this.label4.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frm_ReportCriteria_Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 840);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Location = new System.Drawing.Point(200, 150);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ReportCriteria_Inventory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_ReportCriteria_Load);
            this.grbDates.ResumeLayout(false);
            this.grbDates.PerformLayout();
            this.pnlDt.ResumeLayout(false);
            this.pnlDt.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gbPSW.ResumeLayout(false);
            this.gbPSW.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbCriteria.ResumeLayout(false);
            this.grbCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox grbCriteria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnComBank;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dt_Date;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCheNo;
        private System.Windows.Forms.TextBox txtBankBranch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLoanNo;
        private System.Windows.Forms.ComboBox cmbNICNo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMonths;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.TextBox txtNICNo;
        private System.Windows.Forms.Panel pnlDt;
        private System.Windows.Forms.DateTimePicker lbl_SysLast;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker lbl_SysDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Label lblPW;
        private System.Windows.Forms.TreeView trvReports;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox lblINVNO;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbPSW;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblwait;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPwdOK;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox lblCUSSUP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblSEQ;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button btn_Quit;
    }
}