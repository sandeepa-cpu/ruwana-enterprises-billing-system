namespace Billing_Inventory_Management_System
{
    partial class frm_CreateUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CreateUsers));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_AccLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ConfimPWD = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_UserID = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.label58 = new System.Windows.Forms.Label();
            this.button32 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.cmb_AccLevel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_ConfimPWD);
            this.groupBox2.Controls.Add(this.txt_Password);
            this.groupBox2.Controls.Add(this.txt_UserID);
            this.groupBox2.Controls.Add(this.txt_UserName);
            this.groupBox2.Controls.Add(this.btn_Quit);
            this.groupBox2.Controls.Add(this.btn_AddUser);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.listBox3);
            this.groupBox2.Controls.Add(this.listBox4);
            this.groupBox2.Location = new System.Drawing.Point(10, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 245);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // cmb_AccLevel
            // 
            this.cmb_AccLevel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmb_AccLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_AccLevel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_AccLevel.FormattingEnabled = true;
            this.cmb_AccLevel.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.cmb_AccLevel.Location = new System.Drawing.Point(370, 141);
            this.cmb_AccLevel.Name = "cmb_AccLevel";
            this.cmb_AccLevel.Size = new System.Drawing.Size(48, 26);
            this.cmb_AccLevel.TabIndex = 40;
            this.cmb_AccLevel.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "Access Level";
            // 
            // txt_ConfimPWD
            // 
            this.txt_ConfimPWD.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txt_ConfimPWD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ConfimPWD.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConfimPWD.Location = new System.Drawing.Point(176, 111);
            this.txt_ConfimPWD.Name = "txt_ConfimPWD";
            this.txt_ConfimPWD.PasswordChar = '•';
            this.txt_ConfimPWD.Size = new System.Drawing.Size(188, 23);
            this.txt_ConfimPWD.TabIndex = 38;
            this.txt_ConfimPWD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ConfimPWD_KeyPress);
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Password.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(176, 81);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '•';
            this.txt_Password.Size = new System.Drawing.Size(188, 23);
            this.txt_Password.TabIndex = 37;
            this.txt_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Password_KeyPress);
            // 
            // txt_UserID
            // 
            this.txt_UserID.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txt_UserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_UserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_UserID.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserID.Location = new System.Drawing.Point(176, 51);
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.Size = new System.Drawing.Size(188, 23);
            this.txt_UserID.TabIndex = 36;
            this.txt_UserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_UserID_KeyPress);
            // 
            // txt_UserName
            // 
            this.txt_UserName.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txt_UserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_UserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_UserName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserName.Location = new System.Drawing.Point(176, 22);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(289, 23);
            this.txt_UserName.TabIndex = 35;
            this.txt_UserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_UserName_KeyPress);
            // 
            // btn_Quit
            // 
            this.btn_Quit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(356, 198);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(107, 38);
            this.btn_Quit.TabIndex = 28;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUser.Location = new System.Drawing.Point(176, 198);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(169, 38);
            this.btn_AddUser.TabIndex = 27;
            this.btn_AddUser.Text = "Create User";
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Log In User ID";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Log In User Name";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "New Password";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Confirm Password";
            // 
            // listBox3
            // 
            this.listBox3.Location = new System.Drawing.Point(9, 272);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(111, 17);
            this.listBox3.TabIndex = 9;
            this.listBox3.Visible = false;
            // 
            // listBox4
            // 
            this.listBox4.Location = new System.Drawing.Point(56, 288);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(139, 17);
            this.listBox4.TabIndex = 11;
            this.listBox4.Visible = false;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label58.Location = new System.Drawing.Point(12, 9);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(222, 29);
            this.label58.TabIndex = 265;
            this.label58.Text = "CREATE NEW USER";
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Brown;
            this.button32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button32.BackgroundImage")));
            this.button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(452, 1);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(38, 36);
            this.button32.TabIndex = 348;
            this.button32.TabStop = false;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.DropDownHeight = 120;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.ItemHeight = 32;
            this.comboBox1.Items.AddRange(new object[] {
            "ADMIN",
            "USER",
            "REPORTS ONLY"});
            this.comboBox1.Location = new System.Drawing.Point(176, 141);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(260, 38);
            this.comboBox1.TabIndex = 41;
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frm_CreateUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(492, 303);
            this.ControlBox = true;
            this.Controls.Add(this.button32);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_CreateUsers";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ListBox listBox3;
        internal System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.TextBox txt_ConfimPWD;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_UserID;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.ComboBox cmb_AccLevel;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}