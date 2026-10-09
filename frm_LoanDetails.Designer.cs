namespace Billing_Inventory_Management_System
{
    partial class frm_LoanDetails
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmb_Loan_ID = new System.Windows.Forms.ComboBox();
            this.txt_Loan_ID = new System.Windows.Forms.TextBox();
            this.lbl_Ten_No = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.txt_Loan_Amount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Emp_No = new System.Windows.Forms.TextBox();
            this.cmb_Find_Emp = new System.Windows.Forms.ComboBox();
            this.txt_Interest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_No_Installments = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_LoanDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmb_Loan_ID);
            this.groupBox3.Controls.Add(this.txt_Loan_ID);
            this.groupBox3.Controls.Add(this.lbl_Ten_No);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(5, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(427, 47);
            this.groupBox3.TabIndex = 79;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Tender";
            // 
            // cmb_Loan_ID
            // 
            this.cmb_Loan_ID.BackColor = System.Drawing.Color.White;
            this.cmb_Loan_ID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Loan_ID.FormattingEnabled = true;
            this.cmb_Loan_ID.Location = new System.Drawing.Point(133, 19);
            this.cmb_Loan_ID.MaxDropDownItems = 5;
            this.cmb_Loan_ID.Name = "cmb_Loan_ID";
            this.cmb_Loan_ID.Size = new System.Drawing.Size(289, 21);
            this.cmb_Loan_ID.TabIndex = 1;
            this.cmb_Loan_ID.SelectedValueChanged += new System.EventHandler(this.cmb_Loan_ID_SelectedValueChanged);
            // 
            // txt_Loan_ID
            // 
            this.txt_Loan_ID.BackColor = System.Drawing.Color.White;
            this.txt_Loan_ID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Loan_ID.Location = new System.Drawing.Point(133, 19);
            this.txt_Loan_ID.MaxLength = 10;
            this.txt_Loan_ID.Name = "txt_Loan_ID";
            this.txt_Loan_ID.ReadOnly = true;
            this.txt_Loan_ID.Size = new System.Drawing.Size(71, 21);
            this.txt_Loan_ID.TabIndex = 75;
            // 
            // lbl_Ten_No
            // 
            this.lbl_Ten_No.AutoSize = true;
            this.lbl_Ten_No.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ten_No.Location = new System.Drawing.Point(14, 22);
            this.lbl_Ten_No.Name = "lbl_Ten_No";
            this.lbl_Ten_No.Size = new System.Drawing.Size(107, 13);
            this.lbl_Ten_No.TabIndex = 70;
            this.lbl_Ten_No.Text = "Select Loan Code";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Add);
            this.groupBox4.Controls.Add(this.btn_Back);
            this.groupBox4.Location = new System.Drawing.Point(5, 197);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(427, 40);
            this.groupBox4.TabIndex = 78;
            this.groupBox4.TabStop = false;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(133, 13);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(208, 22);
            this.btn_Add.TabIndex = 6;
            this.btn_Add.Text = "Update Loan Entry";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.Location = new System.Drawing.Point(344, 13);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(78, 22);
            this.btn_Back.TabIndex = 7;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // txt_Loan_Amount
            // 
            this.txt_Loan_Amount.Location = new System.Drawing.Point(133, 43);
            this.txt_Loan_Amount.MaxLength = 20;
            this.txt_Loan_Amount.Name = "txt_Loan_Amount";
            this.txt_Loan_Amount.Size = new System.Drawing.Size(111, 21);
            this.txt_Loan_Amount.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Loan Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "EPF Number";
            // 
            // txt_Emp_No
            // 
            this.txt_Emp_No.BackColor = System.Drawing.Color.White;
            this.txt_Emp_No.Location = new System.Drawing.Point(133, 16);
            this.txt_Emp_No.MaxLength = 15;
            this.txt_Emp_No.Name = "txt_Emp_No";
            this.txt_Emp_No.ReadOnly = true;
            this.txt_Emp_No.Size = new System.Drawing.Size(70, 21);
            this.txt_Emp_No.TabIndex = 4;
            // 
            // cmb_Find_Emp
            // 
            this.cmb_Find_Emp.BackColor = System.Drawing.Color.White;
            this.cmb_Find_Emp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Find_Emp.FormattingEnabled = true;
            this.cmb_Find_Emp.ItemHeight = 13;
            this.cmb_Find_Emp.Location = new System.Drawing.Point(133, 16);
            this.cmb_Find_Emp.MaxDropDownItems = 5;
            this.cmb_Find_Emp.Name = "cmb_Find_Emp";
            this.cmb_Find_Emp.Size = new System.Drawing.Size(288, 21);
            this.cmb_Find_Emp.TabIndex = 2;
            this.cmb_Find_Emp.SelectedValueChanged += new System.EventHandler(this.cmb_Find_Emp_SelectedValueChanged);
            // 
            // txt_Interest
            // 
            this.txt_Interest.Location = new System.Drawing.Point(133, 70);
            this.txt_Interest.MaxLength = 4;
            this.txt_Interest.Name = "txt_Interest";
            this.txt_Interest.Size = new System.Drawing.Size(34, 21);
            this.txt_Interest.TabIndex = 4;
            this.txt_Interest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Interest.TextChanged += new System.EventHandler(this.txt_Interest_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Interest";
            // 
            // txt_No_Installments
            // 
            this.txt_No_Installments.Location = new System.Drawing.Point(133, 97);
            this.txt_No_Installments.MaxLength = 4;
            this.txt_No_Installments.Name = "txt_No_Installments";
            this.txt_No_Installments.Size = new System.Drawing.Size(49, 21);
            this.txt_No_Installments.TabIndex = 5;
            this.txt_No_Installments.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "No. of Installments";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_LoanDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_Find_Emp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_No_Installments);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Interest);
            this.groupBox1.Controls.Add(this.txt_Emp_No);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_Loan_Amount);
            this.groupBox1.Location = new System.Drawing.Point(5, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 152);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            // 
            // dtp_LoanDate
            // 
            this.dtp_LoanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_LoanDate.Location = new System.Drawing.Point(133, 124);
            this.dtp_LoanDate.MaxDate = new System.DateTime(2040, 12, 31, 0, 0, 0, 0);
            this.dtp_LoanDate.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dtp_LoanDate.Name = "dtp_LoanDate";
            this.dtp_LoanDate.Size = new System.Drawing.Size(103, 21);
            this.dtp_LoanDate.TabIndex = 73;
            this.dtp_LoanDate.Value = new System.DateTime(2022, 11, 17, 13, 36, 39, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Payment Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "%";
            // 
            // frm_LoanDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(436, 246);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_LoanDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Loan Details";
            this.Load += new System.EventHandler(this.frm_LoanDetails_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_Loan_ID;
        private System.Windows.Forms.ComboBox cmb_Loan_ID;
        private System.Windows.Forms.Label lbl_Ten_No;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.TextBox txt_Loan_Amount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Emp_No;
        private System.Windows.Forms.ComboBox cmb_Find_Emp;
        private System.Windows.Forms.TextBox txt_Interest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_No_Installments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_LoanDate;
    }
}