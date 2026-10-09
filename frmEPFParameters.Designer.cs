namespace Billing_Inventory_Management_System
{
    partial class frmEPFParameters
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbCheque = new System.Windows.Forms.RadioButton();
            this.rdbCash = new System.Windows.Forms.RadioButton();
            this.rdbMoneyOrder = new System.Windows.Forms.RadioButton();
            this.rdbDirectDebit = new System.Windows.Forms.RadioButton();
            this.txtPayRef = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbEvemp = new System.Windows.Forms.GroupBox();
            this.btnGenerateExel = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbEvemp.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.cmbMonth);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Year and Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Date Generated";
            // 
            // dtpDate
            // 
            this.dtpDate.Checked = false;
            this.dtpDate.Location = new System.Drawing.Point(9, 95);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(222, 21);
            this.dtpDate.TabIndex = 10;
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(98, 19);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(133, 21);
            this.cmbMonth.TabIndex = 4;
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbYear.Location = new System.Drawing.Point(9, 19);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(83, 21);
            this.cmbYear.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbCheque);
            this.groupBox2.Controls.Add(this.rdbCash);
            this.groupBox2.Controls.Add(this.rdbMoneyOrder);
            this.groupBox2.Controls.Add(this.rdbDirectDebit);
            this.groupBox2.Location = new System.Drawing.Point(6, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode of Payment";
            // 
            // rdbCheque
            // 
            this.rdbCheque.AutoSize = true;
            this.rdbCheque.Location = new System.Drawing.Point(31, 25);
            this.rdbCheque.Name = "rdbCheque";
            this.rdbCheque.Size = new System.Drawing.Size(69, 17);
            this.rdbCheque.TabIndex = 2;
            this.rdbCheque.TabStop = true;
            this.rdbCheque.Text = "Cheque";
            this.rdbCheque.UseVisualStyleBackColor = true;
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.Location = new System.Drawing.Point(31, 50);
            this.rdbCash.Name = "rdbCash";
            this.rdbCash.Size = new System.Drawing.Size(54, 17);
            this.rdbCash.TabIndex = 3;
            this.rdbCash.TabStop = true;
            this.rdbCash.Text = "Cash";
            this.rdbCash.UseVisualStyleBackColor = true;
            // 
            // rdbMoneyOrder
            // 
            this.rdbMoneyOrder.AutoSize = true;
            this.rdbMoneyOrder.Location = new System.Drawing.Point(173, 25);
            this.rdbMoneyOrder.Name = "rdbMoneyOrder";
            this.rdbMoneyOrder.Size = new System.Drawing.Size(99, 17);
            this.rdbMoneyOrder.TabIndex = 4;
            this.rdbMoneyOrder.TabStop = true;
            this.rdbMoneyOrder.Text = "Money Order";
            this.rdbMoneyOrder.UseVisualStyleBackColor = true;
            // 
            // rdbDirectDebit
            // 
            this.rdbDirectDebit.AutoSize = true;
            this.rdbDirectDebit.Location = new System.Drawing.Point(173, 49);
            this.rdbDirectDebit.Name = "rdbDirectDebit";
            this.rdbDirectDebit.Size = new System.Drawing.Size(93, 17);
            this.rdbDirectDebit.TabIndex = 5;
            this.rdbDirectDebit.TabStop = true;
            this.rdbDirectDebit.Text = "Direct Debit";
            this.rdbDirectDebit.UseVisualStyleBackColor = true;
            // 
            // txtPayRef
            // 
            this.txtPayRef.Location = new System.Drawing.Point(6, 139);
            this.txtPayRef.MaxLength = 20;
            this.txtPayRef.Name = "txtPayRef";
            this.txtPayRef.Size = new System.Drawing.Size(160, 21);
            this.txtPayRef.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(6, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Payment References";
            // 
            // grbEvemp
            // 
            this.grbEvemp.Controls.Add(this.groupBox2);
            this.grbEvemp.Controls.Add(this.txtPayRef);
            this.grbEvemp.Controls.Add(this.label1);
            this.grbEvemp.Location = new System.Drawing.Point(265, 12);
            this.grbEvemp.Name = "grbEvemp";
            this.grbEvemp.Size = new System.Drawing.Size(309, 168);
            this.grbEvemp.TabIndex = 5;
            this.grbEvemp.TabStop = false;
            this.grbEvemp.Text = "Payment Detail File (EVEMP)";
            // 
            // btnGenerateExel
            // 
            this.btnGenerateExel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateExel.Location = new System.Drawing.Point(8, 156);
            this.btnGenerateExel.Name = "btnGenerateExel";
            this.btnGenerateExel.Size = new System.Drawing.Size(140, 24);
            this.btnGenerateExel.TabIndex = 7;
            this.btnGenerateExel.Text = "&Generate Excel";
            this.btnGenerateExel.UseVisualStyleBackColor = true;
            this.btnGenerateExel.Click += new System.EventHandler(this.btnGenerateExel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(156, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmEPFParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(581, 187);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGenerateExel);
            this.Controls.Add(this.grbEvemp);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(400, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEPFParameters";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " EPF Contribution Reports";
            this.Load += new System.EventHandler(this.frmEPFParameters_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbEvemp.ResumeLayout(false);
            this.grbEvemp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbCheque;
        private System.Windows.Forms.RadioButton rdbCash;
        private System.Windows.Forms.RadioButton rdbMoneyOrder;
        private System.Windows.Forms.RadioButton rdbDirectDebit;
        private System.Windows.Forms.TextBox txtPayRef;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbEvemp;
        private System.Windows.Forms.Button btnGenerateExel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}