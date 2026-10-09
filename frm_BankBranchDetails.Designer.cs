namespace Billing_Inventory_Management_System
{
    partial class frm_BankBranchDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BankBranchDetails));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.cmb_SelectBank = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_Code = new System.Windows.Forms.TextBox();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.txt_SelectBank = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.btn_Update = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.rb_Branch = new System.Windows.Forms.RadioButton();
            this.rb_Bank = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lbl_Code);
            this.groupBox2.Controls.Add(this.cmb_SelectBank);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.txt_Code);
            this.groupBox2.Controls.Add(this.txt_Desc);
            this.groupBox2.Controls.Add(this.txt_SelectBank);
            this.groupBox2.Location = new System.Drawing.Point(18, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 123);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "Select Bank";
            // 
            // lbl_Code
            // 
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.Location = new System.Drawing.Point(11, 19);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(70, 13);
            this.lbl_Code.TabIndex = 34;
            this.lbl_Code.Text = "Bank Code";
            // 
            // cmb_SelectBank
            // 
            this.cmb_SelectBank.BackColor = System.Drawing.Color.White;
            this.cmb_SelectBank.Enabled = false;
            this.cmb_SelectBank.FormattingEnabled = true;
            this.cmb_SelectBank.Location = new System.Drawing.Point(120, 96);
            this.cmb_SelectBank.Name = "cmb_SelectBank";
            this.cmb_SelectBank.Size = new System.Drawing.Size(379, 21);
            this.cmb_SelectBank.TabIndex = 5;
            this.cmb_SelectBank.SelectedValueChanged += new System.EventHandler(this.cmb_Bank_SelectedValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 58);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Description";
            // 
            // txt_Code
            // 
            this.txt_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Code.Location = new System.Drawing.Point(120, 16);
            this.txt_Code.MaxLength = 10;
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.Size = new System.Drawing.Size(105, 21);
            this.txt_Code.TabIndex = 3;
            // 
            // txt_Desc
            // 
            this.txt_Desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Desc.Location = new System.Drawing.Point(120, 39);
            this.txt_Desc.MaxLength = 100;
            this.txt_Desc.Multiline = true;
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(379, 55);
            this.txt_Desc.TabIndex = 4;
            this.txt_Desc.Leave += new System.EventHandler(this.txt_Desc_Leave);
            // 
            // txt_SelectBank
            // 
            this.txt_SelectBank.Location = new System.Drawing.Point(120, 96);
            this.txt_SelectBank.MaxLength = 10;
            this.txt_SelectBank.Name = "txt_SelectBank";
            this.txt_SelectBank.ReadOnly = true;
            this.txt_SelectBank.Size = new System.Drawing.Size(67, 21);
            this.txt_SelectBank.TabIndex = 78;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(322, 266);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(129, 23);
            this.btn_Add.TabIndex = 6;
            this.btn_Add.Text = "Save Entry";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // Grid_A
            // 
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(18, 295);
            this.Grid_A.Name = "Grid_A";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_A.RowHeadersWidth = 50;
            this.Grid_A.Size = new System.Drawing.Size(505, 174);
            this.Grid_A.TabIndex = 74;
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(359, 472);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(164, 23);
            this.btn_Update.TabIndex = 8;
            this.btn_Update.Text = "Update Changes";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_Branch);
            this.groupBox3.Controls.Add(this.rb_Bank);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(18, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(505, 78);
            this.groupBox3.TabIndex = 75;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Entry Type";
            // 
            // btn_Quit
            // 
            this.btn_Quit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Quit.BackgroundImage")));
            this.btn_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Quit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(481, 26);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(27, 28);
            this.btn_Quit.TabIndex = 268;
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // rb_Branch
            // 
            this.rb_Branch.AutoSize = true;
            this.rb_Branch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Branch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Branch.Location = new System.Drawing.Point(32, 47);
            this.rb_Branch.Name = "rb_Branch";
            this.rb_Branch.Size = new System.Drawing.Size(127, 17);
            this.rb_Branch.TabIndex = 2;
            this.rb_Branch.Text = "New Branch Entry";
            this.rb_Branch.UseVisualStyleBackColor = true;
            this.rb_Branch.CheckedChanged += new System.EventHandler(this.rb_Branch_CheckedChanged);
            // 
            // rb_Bank
            // 
            this.rb_Bank.AutoSize = true;
            this.rb_Bank.Checked = true;
            this.rb_Bank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Bank.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Bank.Location = new System.Drawing.Point(32, 24);
            this.rb_Bank.Name = "rb_Bank";
            this.rb_Bank.Size = new System.Drawing.Size(116, 17);
            this.rb_Bank.TabIndex = 1;
            this.rb_Bank.TabStop = true;
            this.rb_Bank.Text = "New Bank Entry";
            this.rb_Bank.UseVisualStyleBackColor = true;
            this.rb_Bank.CheckedChanged += new System.EventHandler(this.rb_Bank_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(191, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 76;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 23);
            this.label1.TabIndex = 79;
            this.label1.Text = "Bank & Branch Details";
            // 
            // frm_BankBranchDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 631);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.Grid_A);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_BankBranchDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_BankBranchDetails_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_Code;
        private System.Windows.Forms.TextBox txt_Desc;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rb_Branch;
        private System.Windows.Forms.RadioButton rb_Bank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_SelectBank;
        private System.Windows.Forms.TextBox txt_SelectBank;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Label label1;
    }
}