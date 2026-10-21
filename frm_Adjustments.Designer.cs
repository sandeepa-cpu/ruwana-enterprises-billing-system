namespace Billing_Inventory_Management_System
{
    partial class frm_Adjustments
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
            this.rb_Deduction = new System.Windows.Forms.RadioButton();
            this.rb_Earnings = new System.Windows.Forms.RadioButton();
            this.btn_Back = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.cmb_Category = new System.Windows.Forms.ComboBox();
            this.txt_EmpNo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Amount = new System.Windows.Forms.Label();
            this.txt_AMOUNT = new System.Windows.Forms.TextBox();
            this.txt_CAT_ID = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.cmb_Find_Emp = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_Deduction);
            this.groupBox2.Controls.Add(this.rb_Earnings);
            this.groupBox2.Location = new System.Drawing.Point(4, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(483, 75);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Adjustments";
            // 
            // rb_Deduction
            // 
            this.rb_Deduction.AutoSize = true;
            this.rb_Deduction.Location = new System.Drawing.Point(197, 32);
            this.rb_Deduction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rb_Deduction.Name = "rb_Deduction";
            this.rb_Deduction.Size = new System.Drawing.Size(162, 22);
            this.rb_Deduction.TabIndex = 2;
            this.rb_Deduction.TabStop = true;
            this.rb_Deduction.Text = "Deduction Adjustments";
            this.rb_Deduction.UseVisualStyleBackColor = true;
            this.rb_Deduction.CheckedChanged += new System.EventHandler(this.rb_Deduction_CheckedChanged);
            // 
            // rb_Earnings
            // 
            this.rb_Earnings.AutoSize = true;
            this.rb_Earnings.Location = new System.Drawing.Point(33, 32);
            this.rb_Earnings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rb_Earnings.Name = "rb_Earnings";
            this.rb_Earnings.Size = new System.Drawing.Size(148, 22);
            this.rb_Earnings.TabIndex = 1;
            this.rb_Earnings.TabStop = true;
            this.rb_Earnings.Text = "Earning Adjustments";
            this.rb_Earnings.UseVisualStyleBackColor = true;
            this.rb_Earnings.CheckedChanged += new System.EventHandler(this.rb_Earnings_CheckedChanged);
            // 
            // btn_Back
            // 
            this.btn_Back.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.Location = new System.Drawing.Point(344, 15);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(78, 32);
            this.btn_Back.TabIndex = 4;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 65;
            this.label2.Text = "Select Category";
            // 
            // btn_Add
            // 
            this.btn_Add.Enabled = false;
            this.btn_Add.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(69, 15);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(163, 30);
            this.btn_Add.TabIndex = 3;
            this.btn_Add.Text = "Save Adjustment";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // cmb_Category
            // 
            this.cmb_Category.BackColor = System.Drawing.Color.White;
            this.cmb_Category.FormattingEnabled = true;
            this.cmb_Category.Location = new System.Drawing.Point(134, 97);
            this.cmb_Category.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_Category.Name = "cmb_Category";
            this.cmb_Category.Size = new System.Drawing.Size(353, 26);
            this.cmb_Category.TabIndex = 5;
            this.cmb_Category.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Category_KeyPress);
            this.cmb_Category.SelectedValueChanged += new System.EventHandler(this.cmb_Category_SelectedValueChanged);
            // 
            // txt_EmpNo
            // 
            this.txt_EmpNo.BackColor = System.Drawing.Color.White;
            this.txt_EmpNo.Enabled = false;
            this.txt_EmpNo.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EmpNo.Location = new System.Drawing.Point(130, 68);
            this.txt_EmpNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_EmpNo.MaxLength = 15;
            this.txt_EmpNo.Name = "txt_EmpNo";
            this.txt_EmpNo.Size = new System.Drawing.Size(65, 23);
            this.txt_EmpNo.TabIndex = 1;
            this.txt_EmpNo.TextChanged += new System.EventHandler(this.txt_EmpNo_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_EmpNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbl_Amount);
            this.groupBox1.Controls.Add(this.txt_AMOUNT);
            this.groupBox1.Location = new System.Drawing.Point(4, 132);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(494, 156);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "EPF Number";
            // 
            // lbl_Amount
            // 
            this.lbl_Amount.AutoSize = true;
            this.lbl_Amount.Location = new System.Drawing.Point(13, 109);
            this.lbl_Amount.Name = "lbl_Amount";
            this.lbl_Amount.Size = new System.Drawing.Size(53, 18);
            this.lbl_Amount.TabIndex = 9;
            this.lbl_Amount.Text = "Amount";
            // 
            // txt_AMOUNT
            // 
            this.txt_AMOUNT.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AMOUNT.Location = new System.Drawing.Point(130, 105);
            this.txt_AMOUNT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_AMOUNT.Name = "txt_AMOUNT";
            this.txt_AMOUNT.Size = new System.Drawing.Size(102, 23);
            this.txt_AMOUNT.TabIndex = 2;
            // 
            // txt_CAT_ID
            // 
            this.txt_CAT_ID.BackColor = System.Drawing.Color.White;
            this.txt_CAT_ID.Enabled = false;
            this.txt_CAT_ID.Location = new System.Drawing.Point(134, 97);
            this.txt_CAT_ID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_CAT_ID.Name = "txt_CAT_ID";
            this.txt_CAT_ID.Size = new System.Drawing.Size(65, 23);
            this.txt_CAT_ID.TabIndex = 23;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Update);
            this.groupBox4.Controls.Add(this.btn_Add);
            this.groupBox4.Controls.Add(this.btn_Back);
            this.groupBox4.Location = new System.Drawing.Point(4, 800);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(426, 51);
            this.groupBox4.TabIndex = 64;
            this.groupBox4.TabStop = false;
            // 
            // btn_Update
            // 
            this.btn_Update.Enabled = false;
            this.btn_Update.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(238, 15);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(100, 30);
            this.btn_Update.TabIndex = 5;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // cmb_Find_Emp
            // 
            this.cmb_Find_Emp.BackColor = System.Drawing.Color.White;
            this.cmb_Find_Emp.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Find_Emp.FormattingEnabled = true;
            this.cmb_Find_Emp.Location = new System.Drawing.Point(205, 199);
            this.cmb_Find_Emp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_Find_Emp.Name = "cmb_Find_Emp";
            this.cmb_Find_Emp.Size = new System.Drawing.Size(276, 26);
            this.cmb_Find_Emp.TabIndex = 67;
            this.cmb_Find_Emp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Find_Emp_KeyPress);
            this.cmb_Find_Emp.SelectedValueChanged += new System.EventHandler(this.cmb_Find_Emp_SelectedValueChanged);
            // 
            // frm_Adjustments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(953, 868);
            this.ControlBox = true;
            this.Controls.Add(this.cmb_Find_Emp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_Category);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_CAT_ID);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Adjustments";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjustments for Earnings & Deductions";
            this.Load += new System.EventHandler(this.frm_Adjustments_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_Deduction;
        private System.Windows.Forms.RadioButton rb_Earnings;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ComboBox cmb_Category;
        private System.Windows.Forms.TextBox txt_EmpNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Amount;
        private System.Windows.Forms.TextBox txt_CAT_ID;
        private System.Windows.Forms.TextBox txt_AMOUNT;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmb_Find_Emp;
        private System.Windows.Forms.Button btn_Update;
    }
}