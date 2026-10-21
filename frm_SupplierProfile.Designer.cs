namespace Billing_Inventory_Management_System
{
    partial class frm_SupplierProfile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SupplierProfile));
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.cmb_Branch = new System.Windows.Forms.ComboBox();
            this.cmb_Bank = new System.Windows.Forms.ComboBox();
            this.txt_BankCode = new System.Windows.Forms.TextBox();
            this.txt_BranchCode = new System.Windows.Forms.TextBox();
            this.txt_AccNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_FileNo = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txt_Mobile = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_ReActivate = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_Deactivate = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_Resident = new System.Windows.Forms.TextBox();
            this.txt_Initials = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.txt_Title = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid_A
            // 
            this.Grid_A.AllowDrop = true;
            this.Grid_A.AllowUserToAddRows = false;
            this.Grid_A.AllowUserToResizeColumns = false;
            this.Grid_A.AllowUserToResizeRows = false;
            this.Grid_A.BackgroundColor = System.Drawing.Color.White;
            this.Grid_A.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_A.ColumnHeadersHeight = 30;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(4, 355);
            this.Grid_A.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Grid_A.Name = "Grid_A";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_A.RowHeadersWidth = 50;
            this.Grid_A.Size = new System.Drawing.Size(608, 393);
            this.Grid_A.TabIndex = 127;
            // 
            // cmb_Branch
            // 
            this.cmb_Branch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmb_Branch.Enabled = false;
            this.cmb_Branch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Branch.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Branch.FormattingEnabled = true;
            this.cmb_Branch.Location = new System.Drawing.Point(173, 282);
            this.cmb_Branch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_Branch.Name = "cmb_Branch";
            this.cmb_Branch.Size = new System.Drawing.Size(418, 30);
            this.cmb_Branch.TabIndex = 123;
            this.cmb_Branch.Visible = false;
            // 
            // cmb_Bank
            // 
            this.cmb_Bank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmb_Bank.Enabled = false;
            this.cmb_Bank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Bank.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Bank.FormattingEnabled = true;
            this.cmb_Bank.Location = new System.Drawing.Point(173, 245);
            this.cmb_Bank.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_Bank.Name = "cmb_Bank";
            this.cmb_Bank.Size = new System.Drawing.Size(418, 30);
            this.cmb_Bank.TabIndex = 121;
            this.cmb_Bank.Visible = false;
            // 
            // txt_BankCode
            // 
            this.txt_BankCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_BankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BankCode.Enabled = false;
            this.txt_BankCode.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BankCode.Location = new System.Drawing.Point(173, 245);
            this.txt_BankCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_BankCode.MaxLength = 50;
            this.txt_BankCode.Name = "txt_BankCode";
            this.txt_BankCode.ReadOnly = true;
            this.txt_BankCode.Size = new System.Drawing.Size(46, 26);
            this.txt_BankCode.TabIndex = 122;
            this.txt_BankCode.Visible = false;
            // 
            // txt_BranchCode
            // 
            this.txt_BranchCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_BranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BranchCode.Enabled = false;
            this.txt_BranchCode.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BranchCode.Location = new System.Drawing.Point(173, 282);
            this.txt_BranchCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_BranchCode.MaxLength = 50;
            this.txt_BranchCode.Name = "txt_BranchCode";
            this.txt_BranchCode.ReadOnly = true;
            this.txt_BranchCode.Size = new System.Drawing.Size(61, 26);
            this.txt_BranchCode.TabIndex = 124;
            this.txt_BranchCode.Visible = false;
            // 
            // txt_AccNo
            // 
            this.txt_AccNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_AccNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_AccNo.Enabled = false;
            this.txt_AccNo.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AccNo.Location = new System.Drawing.Point(173, 318);
            this.txt_AccNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_AccNo.MaxLength = 25;
            this.txt_AccNo.Name = "txt_AccNo";
            this.txt_AccNo.Size = new System.Drawing.Size(323, 26);
            this.txt_AccNo.TabIndex = 125;
            this.txt_AccNo.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(23, 323);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 18);
            this.label17.TabIndex = 126;
            this.label17.Text = "Account No";
            this.label17.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 251);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 18);
            this.label11.TabIndex = 119;
            this.label11.Text = "Bank";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 288);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 18);
            this.label12.TabIndex = 120;
            this.label12.Text = "Branch";
            this.label12.Visible = false;
            // 
            // txt_FileNo
            // 
            this.txt_FileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_FileNo.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FileNo.Location = new System.Drawing.Point(173, 182);
            this.txt_FileNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_FileNo.Name = "txt_FileNo";
            this.txt_FileNo.Size = new System.Drawing.Size(155, 26);
            this.txt_FileNo.TabIndex = 6;
            this.txt_FileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_FileNo_KeyPress);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(23, 187);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(104, 18);
            this.label26.TabIndex = 118;
            this.label26.Text = "Supplier File No.";
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(253, 742);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(137, 39);
            this.btn_Add.TabIndex = 8;
            this.btn_Add.Text = "&Save";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(170, 157);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(33, 18);
            this.label25.TabIndex = 115;
            this.label25.Text = "Tel :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(398, 157);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(38, 18);
            this.label24.TabIndex = 113;
            this.label24.Text = "Fax :";
            // 
            // txt_Mobile
            // 
            this.txt_Mobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Mobile.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Mobile.Location = new System.Drawing.Point(435, 152);
            this.txt_Mobile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Mobile.MaxLength = 12;
            this.txt_Mobile.Name = "txt_Mobile";
            this.txt_Mobile.Size = new System.Drawing.Size(156, 26);
            this.txt_Mobile.TabIndex = 5;
            this.txt_Mobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Mobile_KeyPress);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(336, 750);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(137, 39);
            this.btn_Save.TabIndex = 11;
            this.btn_Save.Text = "&Update Changes";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_ReActivate
            // 
            this.btn_ReActivate.Enabled = false;
            this.btn_ReActivate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReActivate.Location = new System.Drawing.Point(335, 313);
            this.btn_ReActivate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ReActivate.Name = "btn_ReActivate";
            this.btn_ReActivate.Size = new System.Drawing.Size(137, 39);
            this.btn_ReActivate.TabIndex = 9;
            this.btn_ReActivate.Text = "R&e-Activate";
            this.btn_ReActivate.UseVisualStyleBackColor = true;
            // 
            // btn_Quit
            // 
            this.btn_Quit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(489, 742);
            this.btn_Quit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(137, 39);
            this.btn_Quit.TabIndex = 12;
            this.btn_Quit.Text = "&Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_Deactivate
            // 
            this.btn_Deactivate.Enabled = false;
            this.btn_Deactivate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Deactivate.Location = new System.Drawing.Point(476, 313);
            this.btn_Deactivate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Deactivate.Name = "btn_Deactivate";
            this.btn_Deactivate.Size = new System.Drawing.Size(137, 39);
            this.btn_Deactivate.TabIndex = 10;
            this.btn_Deactivate.Text = "Dea&ctivate";
            this.btn_Deactivate.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(23, 157);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(108, 18);
            this.label23.TabIndex = 111;
            this.label23.Text = "Contact Numbers";
            // 
            // txt_Resident
            // 
            this.txt_Resident.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Resident.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Resident.Location = new System.Drawing.Point(204, 152);
            this.txt_Resident.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Resident.MaxLength = 12;
            this.txt_Resident.Name = "txt_Resident";
            this.txt_Resident.Size = new System.Drawing.Size(158, 26);
            this.txt_Resident.TabIndex = 4;
            this.txt_Resident.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Resident_KeyPress);
            // 
            // txt_Initials
            // 
            this.txt_Initials.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txt_Initials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Initials.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Initials.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Initials.Location = new System.Drawing.Point(173, 44);
            this.txt_Initials.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Initials.MaxLength = 50;
            this.txt_Initials.Name = "txt_Initials";
            this.txt_Initials.Size = new System.Drawing.Size(418, 26);
            this.txt_Initials.TabIndex = 2;
            this.txt_Initials.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Initials_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 18);
            this.label9.TabIndex = 108;
            this.label9.Text = "Address";
            // 
            // txt_Address
            // 
            this.txt_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Address.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(173, 75);
            this.txt_Address.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Address.MaxLength = 100;
            this.txt_Address.Multiline = true;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(418, 72);
            this.txt_Address.TabIndex = 3;
            this.txt_Address.TextChanged += new System.EventHandler(this.txt_Address_TextChanged);
            this.txt_Address.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Address_KeyPress);
            // 
            // txt_Title
            // 
            this.txt_Title.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txt_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_Title.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Title.FormattingEnabled = true;
            this.txt_Title.Items.AddRange(new object[] {
            "COM.",
            "MR.",
            "MRS."});
            this.txt_Title.Location = new System.Drawing.Point(173, 8);
            this.txt_Title.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Size = new System.Drawing.Size(66, 30);
            this.txt_Title.TabIndex = 1;
            this.txt_Title.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Title_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 105;
            this.label3.Text = "Supplier Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.TabIndex = 103;
            this.label2.Text = "Title";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(173, 213);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(323, 26);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 129;
            this.label1.Text = "E - Mail";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.FloralWhite;
            this.label58.Location = new System.Drawing.Point(3, 2);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(219, 29);
            this.label58.TabIndex = 265;
            this.label58.Text = "SUPPLIER PROFILE";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 276);
            this.tabControl1.TabIndex = 266;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.txt_Title);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txt_Address);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txt_Initials);
            this.tabPage1.Controls.Add(this.txt_Resident);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.cmb_Branch);
            this.tabPage1.Controls.Add(this.txt_Mobile);
            this.tabPage1.Controls.Add(this.cmb_Bank);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.txt_BankCode);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.txt_BranchCode);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.txt_AccNo);
            this.tabPage1.Controls.Add(this.txt_FileNo);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(600, 245);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = resources.GetString("tabPage1.Text");
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(576, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 28);
            this.button1.TabIndex = 268;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // frm_SupplierProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(615, 790);
            this.ControlBox = true;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_ReActivate);
            this.Controls.Add(this.btn_Deactivate);
            this.Controls.Add(this.Grid_A);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Quit);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_SupplierProfile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_SupplierProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.ComboBox cmb_Branch;
        private System.Windows.Forms.ComboBox cmb_Bank;
        private System.Windows.Forms.TextBox txt_BankCode;
        private System.Windows.Forms.TextBox txt_BranchCode;
        private System.Windows.Forms.TextBox txt_AccNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_FileNo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txt_Mobile;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_ReActivate;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_Deactivate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_Resident;
        private System.Windows.Forms.TextBox txt_Initials;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.ComboBox txt_Title;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}