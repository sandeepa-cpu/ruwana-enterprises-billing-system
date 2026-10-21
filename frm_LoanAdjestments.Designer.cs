namespace Billing_Inventory_Management_System
{
    partial class frm_LoanAdjestments
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
            this.btn_Adjustments = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Find_Emp = new System.Windows.Forms.ComboBox();
            this.txt_Emp_No = new System.Windows.Forms.TextBox();
            this.cmb_LoanType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_BalAmount = new System.Windows.Forms.Label();
            this.txt_LoanAmount = new System.Windows.Forms.Label();
            this.txt_BalInst = new System.Windows.Forms.Label();
            this.txt_Inst = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Adjustments
            // 
            this.btn_Adjustments.Location = new System.Drawing.Point(179, 81);
            this.btn_Adjustments.Name = "btn_Adjustments";
            this.btn_Adjustments.Size = new System.Drawing.Size(169, 25);
            this.btn_Adjustments.TabIndex = 0;
            this.btn_Adjustments.Text = "Adjustments";
            this.btn_Adjustments.UseVisualStyleBackColor = true;
            this.btn_Adjustments.Click += new System.EventHandler(this.btn_Adjustments_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Employee";
            // 
            // cmb_Find_Emp
            // 
            this.cmb_Find_Emp.BackColor = System.Drawing.Color.White;
            this.cmb_Find_Emp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Find_Emp.FormattingEnabled = true;
            this.cmb_Find_Emp.Location = new System.Drawing.Point(121, 17);
            this.cmb_Find_Emp.Name = "cmb_Find_Emp";
            this.cmb_Find_Emp.Size = new System.Drawing.Size(298, 21);
            this.cmb_Find_Emp.TabIndex = 5;
            this.cmb_Find_Emp.SelectedValueChanged += new System.EventHandler(this.cmb_Find_Emp_SelectedValueChanged);
            // 
            // txt_Emp_No
            // 
            this.txt_Emp_No.BackColor = System.Drawing.Color.White;
            this.txt_Emp_No.Location = new System.Drawing.Point(121, 17);
            this.txt_Emp_No.MaxLength = 15;
            this.txt_Emp_No.Name = "txt_Emp_No";
            this.txt_Emp_No.ReadOnly = true;
            this.txt_Emp_No.Size = new System.Drawing.Size(70, 21);
            this.txt_Emp_No.TabIndex = 6;
            // 
            // cmb_LoanType
            // 
            this.cmb_LoanType.BackColor = System.Drawing.Color.White;
            this.cmb_LoanType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_LoanType.FormattingEnabled = true;
            this.cmb_LoanType.Location = new System.Drawing.Point(121, 47);
            this.cmb_LoanType.Name = "cmb_LoanType";
            this.cmb_LoanType.Size = new System.Drawing.Size(298, 21);
            this.cmb_LoanType.TabIndex = 7;
            this.cmb_LoanType.SelectedValueChanged += new System.EventHandler(this.cmb_LoanType_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Loan Type";
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(351, 81);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(68, 25);
            this.btn_Quit.TabIndex = 9;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Balance Amount   -";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Loan Amount        -";
            // 
            // txt_BalAmount
            // 
            this.txt_BalAmount.AutoSize = true;
            this.txt_BalAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BalAmount.ForeColor = System.Drawing.Color.Blue;
            this.txt_BalAmount.Location = new System.Drawing.Point(137, 42);
            this.txt_BalAmount.Name = "txt_BalAmount";
            this.txt_BalAmount.Size = new System.Drawing.Size(35, 13);
            this.txt_BalAmount.TabIndex = 13;
            this.txt_BalAmount.Text = "0.00";
            // 
            // txt_LoanAmount
            // 
            this.txt_LoanAmount.AutoSize = true;
            this.txt_LoanAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LoanAmount.ForeColor = System.Drawing.Color.Blue;
            this.txt_LoanAmount.Location = new System.Drawing.Point(137, 17);
            this.txt_LoanAmount.Name = "txt_LoanAmount";
            this.txt_LoanAmount.Size = new System.Drawing.Size(35, 13);
            this.txt_LoanAmount.TabIndex = 12;
            this.txt_LoanAmount.Text = "0.00";
            // 
            // txt_BalInst
            // 
            this.txt_BalInst.AutoSize = true;
            this.txt_BalInst.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BalInst.ForeColor = System.Drawing.Color.Blue;
            this.txt_BalInst.Location = new System.Drawing.Point(382, 42);
            this.txt_BalInst.Name = "txt_BalInst";
            this.txt_BalInst.Size = new System.Drawing.Size(15, 13);
            this.txt_BalInst.TabIndex = 17;
            this.txt_BalInst.Text = "0";
            // 
            // txt_Inst
            // 
            this.txt_Inst.AutoSize = true;
            this.txt_Inst.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Inst.ForeColor = System.Drawing.Color.Blue;
            this.txt_Inst.Location = new System.Drawing.Point(382, 17);
            this.txt_Inst.Name = "txt_Inst";
            this.txt_Inst.Size = new System.Drawing.Size(15, 13);
            this.txt_Inst.TabIndex = 16;
            this.txt_Inst.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Balance Installments   -";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(230, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "No. of Installments      -";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_BalInst);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_Inst);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_LoanAmount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_BalAmount);
            this.groupBox1.Location = new System.Drawing.Point(5, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 64);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // frm_LoanAdjestments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(423, 175);
            this.ControlBox = true;
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_LoanType);
            this.Controls.Add(this.cmb_Find_Emp);
            this.Controls.Add(this.txt_Emp_No);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Adjustments);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_LoanAdjestments";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjestments of Loan Installments";
            this.Load += new System.EventHandler(this.frm_LoanAdjestments_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Adjustments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Find_Emp;
        private System.Windows.Forms.TextBox txt_Emp_No;
        private System.Windows.Forms.ComboBox cmb_LoanType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txt_BalAmount;
        private System.Windows.Forms.Label txt_LoanAmount;
        private System.Windows.Forms.Label txt_BalInst;
        private System.Windows.Forms.Label txt_Inst;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}