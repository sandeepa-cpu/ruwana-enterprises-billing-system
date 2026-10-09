namespace Billing_Inventory_Management_System
{
    partial class frm_PayProcess
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
            this.btn_Quit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Year = new System.Windows.Forms.Label();
            this.lbl_Month = new System.Windows.Forms.Label();
            this.cmd_ProEPF = new System.Windows.Forms.Button();
            this.btnPay_Tax = new System.Windows.Forms.Button();
            this.btn_PeriodChange = new System.Windows.Forms.Button();
            this.btn_Process_OT = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_Loan_Process = new System.Windows.Forms.Button();
            this.btnFESADVANCE = new System.Windows.Forms.Button();
            this.btnOfficeBasic = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdWelfair = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.prbEPF_ETF = new System.Windows.Forms.ProgressBar();
            this.btnBatchSumReport = new System.Windows.Forms.Button();
            this.btnBatchBankSumReport = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cmdProSec = new System.Windows.Forms.Button();
            this.cmdPaySlip = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(338, 603);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(114, 31);
            this.btn_Quit.TabIndex = 2;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Processing Month";
            // 
            // lbl_Year
            // 
            this.lbl_Year.AutoSize = true;
            this.lbl_Year.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Year.Location = new System.Drawing.Point(321, 19);
            this.lbl_Year.Name = "lbl_Year";
            this.lbl_Year.Size = new System.Drawing.Size(0, 13);
            this.lbl_Year.TabIndex = 4;
            // 
            // lbl_Month
            // 
            this.lbl_Month.AutoSize = true;
            this.lbl_Month.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Month.Location = new System.Drawing.Point(200, 19);
            this.lbl_Month.Name = "lbl_Month";
            this.lbl_Month.Size = new System.Drawing.Size(0, 13);
            this.lbl_Month.TabIndex = 5;
            // 
            // cmd_ProEPF
            // 
            this.cmd_ProEPF.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_ProEPF.ForeColor = System.Drawing.Color.Red;
            this.cmd_ProEPF.Location = new System.Drawing.Point(29, 561);
            this.cmd_ProEPF.Name = "cmd_ProEPF";
            this.cmd_ProEPF.Size = new System.Drawing.Size(423, 32);
            this.cmd_ProEPF.TabIndex = 7;
            this.cmd_ProEPF.Text = "Process EPF ";
            this.cmd_ProEPF.UseVisualStyleBackColor = true;
            this.cmd_ProEPF.Click += new System.EventHandler(this.cmd_ProEPF_Click);
            // 
            // btnPay_Tax
            // 
            this.btnPay_Tax.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay_Tax.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnPay_Tax.Location = new System.Drawing.Point(29, 415);
            this.btnPay_Tax.Name = "btnPay_Tax";
            this.btnPay_Tax.Size = new System.Drawing.Size(175, 71);
            this.btnPay_Tax.TabIndex = 8;
            this.btnPay_Tax.Text = "Payee TAX";
            this.btnPay_Tax.UseVisualStyleBackColor = true;
            this.btnPay_Tax.Click += new System.EventHandler(this.btnPay_Tax_Click);
            // 
            // btn_PeriodChange
            // 
            this.btn_PeriodChange.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PeriodChange.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btn_PeriodChange.Location = new System.Drawing.Point(226, 471);
            this.btn_PeriodChange.Name = "btn_PeriodChange";
            this.btn_PeriodChange.Size = new System.Drawing.Size(206, 36);
            this.btn_PeriodChange.TabIndex = 10;
            this.btn_PeriodChange.Text = "Set Next Salary Period";
            this.btn_PeriodChange.UseVisualStyleBackColor = true;
            this.btn_PeriodChange.Visible = false;
            this.btn_PeriodChange.Click += new System.EventHandler(this.btn_PeriodChange_Click);
            // 
            // btn_Process_OT
            // 
            this.btn_Process_OT.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Process_OT.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btn_Process_OT.Location = new System.Drawing.Point(249, 134);
            this.btn_Process_OT.Name = "btn_Process_OT";
            this.btn_Process_OT.Size = new System.Drawing.Size(175, 66);
            this.btn_Process_OT.TabIndex = 11;
            this.btn_Process_OT.Text = "Over Time ";
            this.btn_Process_OT.UseVisualStyleBackColor = true;
            this.btn_Process_OT.Click += new System.EventHandler(this.btn_Process_OT_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(223, 748);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(264, 19);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // btn_Loan_Process
            // 
            this.btn_Loan_Process.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Loan_Process.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btn_Loan_Process.Location = new System.Drawing.Point(29, 342);
            this.btn_Loan_Process.Name = "btn_Loan_Process";
            this.btn_Loan_Process.Size = new System.Drawing.Size(174, 69);
            this.btn_Loan_Process.TabIndex = 12;
            this.btn_Loan_Process.Text = "Loan Process";
            this.btn_Loan_Process.UseVisualStyleBackColor = true;
            this.btn_Loan_Process.Click += new System.EventHandler(this.btn_Loan_Process_Click_1);
            // 
            // btnFESADVANCE
            // 
            this.btnFESADVANCE.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFESADVANCE.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnFESADVANCE.Location = new System.Drawing.Point(29, 202);
            this.btnFESADVANCE.Name = "btnFESADVANCE";
            this.btnFESADVANCE.Size = new System.Drawing.Size(175, 67);
            this.btnFESADVANCE.TabIndex = 14;
            this.btnFESADVANCE.Text = "Festival Advance";
            this.btnFESADVANCE.UseVisualStyleBackColor = true;
            this.btnFESADVANCE.Click += new System.EventHandler(this.btnFESADVANCE_Click_1);
            // 
            // btnOfficeBasic
            // 
            this.btnOfficeBasic.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOfficeBasic.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnOfficeBasic.Location = new System.Drawing.Point(249, 61);
            this.btnOfficeBasic.Name = "btnOfficeBasic";
            this.btnOfficeBasic.Size = new System.Drawing.Size(176, 67);
            this.btnOfficeBasic.TabIndex = 17;
            this.btnOfficeBasic.Text = "Process Office Basic";
            this.btnOfficeBasic.UseVisualStyleBackColor = true;
            this.btnOfficeBasic.Click += new System.EventHandler(this.btnOfficeBasic_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(710, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 327);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Relevant to Office Employee";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkMagenta;
            this.button2.Location = new System.Drawing.Point(249, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 66);
            this.button2.TabIndex = 19;
            this.button2.Text = "Other Earnings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkMagenta;
            this.button1.Location = new System.Drawing.Point(249, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "Allowance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cmdWelfair
            // 
            this.cmdWelfair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdWelfair.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdWelfair.ForeColor = System.Drawing.Color.DarkMagenta;
            this.cmdWelfair.Location = new System.Drawing.Point(29, 61);
            this.cmdWelfair.Name = "cmdWelfair";
            this.cmdWelfair.Size = new System.Drawing.Size(176, 67);
            this.cmdWelfair.TabIndex = 17;
            this.cmdWelfair.Text = "Welfare Deduction";
            this.cmdWelfair.UseVisualStyleBackColor = true;
            this.cmdWelfair.Click += new System.EventHandler(this.cmdWelfair_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(18, 765);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 107);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Common Functions";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_Year);
            this.groupBox4.Controls.Add(this.lbl_Month);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(15, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(424, 48);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            // 
            // prbEPF_ETF
            // 
            this.prbEPF_ETF.Location = new System.Drawing.Point(33, 529);
            this.prbEPF_ETF.Name = "prbEPF_ETF";
            this.prbEPF_ETF.Size = new System.Drawing.Size(419, 12);
            this.prbEPF_ETF.TabIndex = 22;
            this.prbEPF_ETF.Visible = false;
            // 
            // btnBatchSumReport
            // 
            this.btnBatchSumReport.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnBatchSumReport.Location = new System.Drawing.Point(260, 368);
            this.btnBatchSumReport.Name = "btnBatchSumReport";
            this.btnBatchSumReport.Size = new System.Drawing.Size(151, 28);
            this.btnBatchSumReport.TabIndex = 23;
            this.btnBatchSumReport.Text = "Batch Report";
            this.btnBatchSumReport.UseVisualStyleBackColor = true;
            // 
            // btnBatchBankSumReport
            // 
            this.btnBatchBankSumReport.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnBatchBankSumReport.Location = new System.Drawing.Point(260, 415);
            this.btnBatchBankSumReport.Name = "btnBatchBankSumReport";
            this.btnBatchBankSumReport.Size = new System.Drawing.Size(151, 34);
            this.btnBatchBankSumReport.TabIndex = 24;
            this.btnBatchBankSumReport.Text = "Batch Summary Report (Bank)";
            this.btnBatchBankSumReport.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkMagenta;
            this.button3.Location = new System.Drawing.Point(29, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(176, 67);
            this.button3.TabIndex = 25;
            this.button3.Text = "Salary Advance";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DarkMagenta;
            this.button4.Location = new System.Drawing.Point(29, 272);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(175, 67);
            this.button4.TabIndex = 26;
            this.button4.Text = "Other Deductions";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmdProSec
            // 
            this.cmdProSec.Enabled = false;
            this.cmdProSec.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProSec.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cmdProSec.Location = new System.Drawing.Point(15, 54);
            this.cmdProSec.Name = "cmdProSec";
            this.cmdProSec.Size = new System.Drawing.Size(176, 23);
            this.cmdProSec.TabIndex = 6;
            this.cmdProSec.Text = "Process Security Deposit";
            this.cmdProSec.UseVisualStyleBackColor = true;
            this.cmdProSec.Click += new System.EventHandler(this.cmdProSec_Click);
            // 
            // cmdPaySlip
            // 
            this.cmdPaySlip.Enabled = false;
            this.cmdPaySlip.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPaySlip.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cmdPaySlip.Location = new System.Drawing.Point(15, 25);
            this.cmdPaySlip.Name = "cmdPaySlip";
            this.cmdPaySlip.Size = new System.Drawing.Size(176, 23);
            this.cmdPaySlip.TabIndex = 0;
            this.cmdPaySlip.Text = "Process Invoices";
            this.cmdPaySlip.UseVisualStyleBackColor = true;
            this.cmdPaySlip.Click += new System.EventHandler(this.cmdPaySlip_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdPaySlip);
            this.groupBox2.Controls.Add(this.cmdProSec);
            this.groupBox2.Location = new System.Drawing.Point(18, 667);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 232);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Relevant to Tender Employee";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.DarkMagenta;
            this.button5.Location = new System.Drawing.Point(249, 202);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(257, 35);
            this.button5.TabIndex = 27;
            this.button5.Text = "Fixed Allowances / Deductions";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // frm_PayProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumVioletRed;
            this.ClientSize = new System.Drawing.Size(518, 656);
            this.ControlBox = false;
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnOfficeBasic);
            this.Controls.Add(this.btn_Process_OT);
            this.Controls.Add(this.btnFESADVANCE);
            this.Controls.Add(this.btn_Loan_Process);
            this.Controls.Add(this.btnBatchBankSumReport);
            this.Controls.Add(this.btnPay_Tax);
            this.Controls.Add(this.cmdWelfair);
            this.Controls.Add(this.btnBatchSumReport);
            this.Controls.Add(this.prbEPF_ETF);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_PeriodChange);
            this.Controls.Add(this.cmd_ProEPF);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_PayProcess";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Process Salary";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_PayProcess_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Year;
        private System.Windows.Forms.Label lbl_Month;
        private System.Windows.Forms.Button cmd_ProEPF;
        private System.Windows.Forms.Button btnPay_Tax;
        private System.Windows.Forms.Button btn_PeriodChange;
        private System.Windows.Forms.Button btn_Process_OT;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_Loan_Process;
        private System.Windows.Forms.Button btnFESADVANCE;
        private System.Windows.Forms.Button btnOfficeBasic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdWelfair;
        private System.Windows.Forms.ProgressBar prbEPF_ETF;
        private System.Windows.Forms.Button btnBatchSumReport;
        private System.Windows.Forms.Button btnBatchBankSumReport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button cmdProSec;
        private System.Windows.Forms.Button cmdPaySlip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
    }
}