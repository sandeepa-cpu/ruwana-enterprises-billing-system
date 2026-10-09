namespace Billing_Inventory_Management_System
{
    partial class frm_CustomerProfile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CustomerProfile));
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
            this.txt_FileNo = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmb_Branch = new System.Windows.Forms.ComboBox();
            this.cmb_Bank = new System.Windows.Forms.ComboBox();
            this.txt_BankCode = new System.Windows.Forms.TextBox();
            this.txt_BranchCode = new System.Windows.Forms.TextBox();
            this.txt_AccNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.button32 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(614, 177);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(133, 55);
            this.btn_Add.TabIndex = 52;
            this.btn_Add.Text = "&Save";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(150, 148);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 18);
            this.label25.TabIndex = 59;
            this.label25.Text = "Resident";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(328, 148);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 18);
            this.label24.TabIndex = 57;
            this.label24.Text = "Mobile";
            // 
            // txt_Mobile
            // 
            this.txt_Mobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Mobile.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Mobile.Location = new System.Drawing.Point(374, 143);
            this.txt_Mobile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Mobile.MaxLength = 12;
            this.txt_Mobile.Name = "txt_Mobile";
            this.txt_Mobile.Size = new System.Drawing.Size(102, 26);
            this.txt_Mobile.TabIndex = 50;
            this.txt_Mobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Mobile_KeyPress);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(614, 684);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(133, 38);
            this.btn_Save.TabIndex = 53;
            this.btn_Save.Text = "&Update Changes";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_ReActivate
            // 
            this.btn_ReActivate.Enabled = false;
            this.btn_ReActivate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReActivate.Location = new System.Drawing.Point(614, 234);
            this.btn_ReActivate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ReActivate.Name = "btn_ReActivate";
            this.btn_ReActivate.Size = new System.Drawing.Size(133, 38);
            this.btn_ReActivate.TabIndex = 56;
            this.btn_ReActivate.Text = "R&e-Activate";
            this.btn_ReActivate.UseVisualStyleBackColor = true;
            // 
            // btn_Quit
            // 
            this.btn_Quit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(614, 723);
            this.btn_Quit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(133, 38);
            this.btn_Quit.TabIndex = 58;
            this.btn_Quit.Text = "&Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_Deactivate
            // 
            this.btn_Deactivate.Enabled = false;
            this.btn_Deactivate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Deactivate.Location = new System.Drawing.Point(614, 273);
            this.btn_Deactivate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Deactivate.Name = "btn_Deactivate";
            this.btn_Deactivate.Size = new System.Drawing.Size(133, 38);
            this.btn_Deactivate.TabIndex = 60;
            this.btn_Deactivate.Text = "Dea&ctivate";
            this.btn_Deactivate.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(23, 148);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(108, 18);
            this.label23.TabIndex = 55;
            this.label23.Text = "Contact Numbers";
            // 
            // txt_Resident
            // 
            this.txt_Resident.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Resident.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Resident.Location = new System.Drawing.Point(212, 143);
            this.txt_Resident.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Resident.MaxLength = 12;
            this.txt_Resident.Name = "txt_Resident";
            this.txt_Resident.Size = new System.Drawing.Size(102, 26);
            this.txt_Resident.TabIndex = 48;
            this.txt_Resident.TextChanged += new System.EventHandler(this.txt_Resident_TextChanged);
            this.txt_Resident.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Resident_KeyPress);
            // 
            // txt_Initials
            // 
            this.txt_Initials.BackColor = System.Drawing.Color.MistyRose;
            this.txt_Initials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Initials.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Initials.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Initials.Location = new System.Drawing.Point(153, 39);
            this.txt_Initials.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Initials.MaxLength = 50;
            this.txt_Initials.Name = "txt_Initials";
            this.txt_Initials.Size = new System.Drawing.Size(441, 26);
            this.txt_Initials.TabIndex = 42;
            this.txt_Initials.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Initials_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 18);
            this.label9.TabIndex = 51;
            this.label9.Text = "Address";
            // 
            // txt_Address
            // 
            this.txt_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Address.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(153, 68);
            this.txt_Address.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Address.MaxLength = 100;
            this.txt_Address.Multiline = true;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(441, 72);
            this.txt_Address.TabIndex = 46;
            this.txt_Address.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Address_KeyPress);
            // 
            // txt_Title
            // 
            this.txt_Title.BackColor = System.Drawing.Color.MistyRose;
            this.txt_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_Title.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Title.FormattingEnabled = true;
            this.txt_Title.Items.AddRange(new object[] {
            "MR.",
            "MRS.",
            "MS.",
            "REV.",
            "COM."});
            this.txt_Title.Location = new System.Drawing.Point(154, 5);
            this.txt_Title.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Size = new System.Drawing.Size(66, 30);
            this.txt_Title.TabIndex = 41;
            this.txt_Title.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Title_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 18);
            this.label3.TabIndex = 47;
            this.label3.Text = "Customer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.TabIndex = 45;
            this.label2.Text = "Title";
            // 
            // txt_FileNo
            // 
            this.txt_FileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_FileNo.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FileNo.Location = new System.Drawing.Point(153, 172);
            this.txt_FileNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_FileNo.Name = "txt_FileNo";
            this.txt_FileNo.Size = new System.Drawing.Size(147, 26);
            this.txt_FileNo.TabIndex = 62;
            this.txt_FileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_FileNo_KeyPress);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(23, 177);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(113, 18);
            this.label26.TabIndex = 63;
            this.label26.Text = "Customer File No.";
            // 
            // cmb_Branch
            // 
            this.cmb_Branch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmb_Branch.Enabled = false;
            this.cmb_Branch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Branch.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Branch.FormattingEnabled = true;
            this.cmb_Branch.Location = new System.Drawing.Point(154, 270);
            this.cmb_Branch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_Branch.Name = "cmb_Branch";
            this.cmb_Branch.Size = new System.Drawing.Size(323, 30);
            this.cmb_Branch.TabIndex = 68;
            this.cmb_Branch.Visible = false;
            // 
            // cmb_Bank
            // 
            this.cmb_Bank.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmb_Bank.Enabled = false;
            this.cmb_Bank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Bank.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Bank.FormattingEnabled = true;
            this.cmb_Bank.Location = new System.Drawing.Point(154, 237);
            this.cmb_Bank.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_Bank.Name = "cmb_Bank";
            this.cmb_Bank.Size = new System.Drawing.Size(323, 30);
            this.cmb_Bank.TabIndex = 66;
            this.cmb_Bank.Visible = false;
            // 
            // txt_BankCode
            // 
            this.txt_BankCode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_BankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BankCode.Enabled = false;
            this.txt_BankCode.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BankCode.Location = new System.Drawing.Point(154, 237);
            this.txt_BankCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_BankCode.MaxLength = 50;
            this.txt_BankCode.Name = "txt_BankCode";
            this.txt_BankCode.ReadOnly = true;
            this.txt_BankCode.Size = new System.Drawing.Size(46, 26);
            this.txt_BankCode.TabIndex = 67;
            this.txt_BankCode.Visible = false;
            // 
            // txt_BranchCode
            // 
            this.txt_BranchCode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_BranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BranchCode.Enabled = false;
            this.txt_BranchCode.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BranchCode.Location = new System.Drawing.Point(154, 270);
            this.txt_BranchCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_BranchCode.MaxLength = 50;
            this.txt_BranchCode.Name = "txt_BranchCode";
            this.txt_BranchCode.ReadOnly = true;
            this.txt_BranchCode.Size = new System.Drawing.Size(61, 26);
            this.txt_BranchCode.TabIndex = 69;
            this.txt_BranchCode.Visible = false;
            // 
            // txt_AccNo
            // 
            this.txt_AccNo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_AccNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_AccNo.Enabled = false;
            this.txt_AccNo.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AccNo.Location = new System.Drawing.Point(154, 275);
            this.txt_AccNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_AccNo.MaxLength = 25;
            this.txt_AccNo.Name = "txt_AccNo";
            this.txt_AccNo.Size = new System.Drawing.Size(208, 26);
            this.txt_AccNo.TabIndex = 70;
            this.txt_AccNo.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 279);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 18);
            this.label17.TabIndex = 71;
            this.label17.Text = "Account No";
            this.label17.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 241);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 18);
            this.label11.TabIndex = 64;
            this.label11.Text = "Bank";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 274);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 18);
            this.label12.TabIndex = 65;
            this.label12.Text = "Branch";
            this.label12.Visible = false;
            // 
            // Grid_A
            // 
            this.Grid_A.AllowDrop = true;
            this.Grid_A.AllowUserToAddRows = false;
            this.Grid_A.AllowUserToResizeColumns = false;
            this.Grid_A.AllowUserToResizeRows = false;
            this.Grid_A.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.Grid_A.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_A.ColumnHeadersHeight = 30;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(3, 313);
            this.Grid_A.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Grid_A.Name = "Grid_A";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_A.RowHeadersWidth = 50;
            this.Grid_A.Size = new System.Drawing.Size(608, 448);
            this.Grid_A.TabIndex = 100;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(2, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 276);
            this.tabControl1.TabIndex = 267;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Thistle;
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.comboBox3);
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Controls.Add(this.textBox6);
            this.tabPage1.Controls.Add(this.textBox7);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.txt_Title);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txt_FileNo);
            this.tabPage1.Controls.Add(this.txt_Address);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txt_Initials);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.txt_Resident);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.txt_Mobile);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(600, 245);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = resources.GetString("tabPage1.Text");
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBox2.Enabled = false;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(173, 282);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(418, 30);
            this.comboBox2.TabIndex = 123;
            this.comboBox2.Visible = false;
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBox3.Enabled = false;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(173, 245);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(418, 30);
            this.comboBox3.TabIndex = 121;
            this.comboBox3.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(173, 245);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox5.MaxLength = 50;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(46, 26);
            this.textBox5.TabIndex = 122;
            this.textBox5.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(173, 282);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox6.MaxLength = 50;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(61, 26);
            this.textBox6.TabIndex = 124;
            this.textBox6.Visible = false;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(173, 318);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox7.MaxLength = 25;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(323, 26);
            this.textBox7.TabIndex = 125;
            this.textBox7.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(23, 323);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 18);
            this.label14.TabIndex = 126;
            this.label14.Text = "Account No";
            this.label14.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 288);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 18);
            this.label15.TabIndex = 120;
            this.label15.Text = "Branch";
            this.label15.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(23, 251);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 18);
            this.label16.TabIndex = 119;
            this.label16.Text = "Bank";
            this.label16.Visible = false;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.Maroon;
            this.label58.Location = new System.Drawing.Point(3, 3);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(235, 29);
            this.label58.TabIndex = 268;
            this.label58.Text = "CUSTOMER PROFILE";
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Brown;
            this.button32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button32.BackgroundImage")));
            this.button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(710, 1);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(38, 36);
            this.button32.TabIndex = 348;
            this.button32.TabStop = false;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // frm_CustomerProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(750, 764);
            this.ControlBox = false;
            this.Controls.Add(this.button32);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Grid_A);
            this.Controls.Add(this.cmb_Branch);
            this.Controls.Add(this.cmb_Bank);
            this.Controls.Add(this.txt_BankCode);
            this.Controls.Add(this.txt_BranchCode);
            this.Controls.Add(this.txt_AccNo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_ReActivate);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Deactivate);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_CustomerProfile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_CustomerProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.TextBox txt_FileNo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmb_Branch;
        private System.Windows.Forms.ComboBox cmb_Bank;
        private System.Windows.Forms.TextBox txt_BankCode;
        private System.Windows.Forms.TextBox txt_BranchCode;
        private System.Windows.Forms.TextBox txt_AccNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Timer timer1;
    }
}