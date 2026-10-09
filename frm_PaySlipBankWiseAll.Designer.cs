namespace Billing_Inventory_Management_System
{
    partial class frm_PaySlipBankWiseAll
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
            this.trvTenders = new System.Windows.Forms.TreeView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelection = new System.Windows.Forms.Button();
            this.chbExcel = new System.Windows.Forms.CheckBox();
            this.cmbBatchNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trvTenders
            // 
            this.trvTenders.CheckBoxes = true;
            this.trvTenders.Location = new System.Drawing.Point(12, 28);
            this.trvTenders.Name = "trvTenders";
            this.trvTenders.Size = new System.Drawing.Size(255, 612);
            this.trvTenders.TabIndex = 0;
            this.trvTenders.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvTenders_AfterCheck);
            this.trvTenders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTenders_AfterSelect);
            this.trvTenders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvTenders_NodeMouseClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(152, 646);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(115, 25);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(273, 28);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(722, 612);
            this.crystalReportViewer1.TabIndex = 4;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Tender Number and Employee";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(888, 647);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 25);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.cmbMonth.Location = new System.Drawing.Point(452, 6);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(91, 21);
            this.cmbMonth.TabIndex = 8;
            this.cmbMonth.SelectedValueChanged += new System.EventHandler(this.cmbMonth_SelectedValueChanged);
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
            this.cmbYear.Location = new System.Drawing.Point(303, 6);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(91, 21);
            this.cmbYear.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(411, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Month";
            // 
            // btnSelection
            // 
            this.btnSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelection.Location = new System.Drawing.Point(15, 647);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(131, 24);
            this.btnSelection.TabIndex = 11;
            this.btnSelection.Text = "SELECT ALL";
            this.btnSelection.UseVisualStyleBackColor = true;
            this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
            // 
            // chbExcel
            // 
            this.chbExcel.AutoSize = true;
            this.chbExcel.Location = new System.Drawing.Point(741, 6);
            this.chbExcel.Name = "chbExcel";
            this.chbExcel.Size = new System.Drawing.Size(101, 17);
            this.chbExcel.TabIndex = 12;
            this.chbExcel.Text = "Upload to Excel";
            this.chbExcel.UseVisualStyleBackColor = true;
            this.chbExcel.CheckedChanged += new System.EventHandler(this.chbExcel_CheckedChanged);
            // 
            // cmbBatchNo
            // 
            this.cmbBatchNo.FormattingEnabled = true;
            this.cmbBatchNo.Location = new System.Drawing.Point(618, 6);
            this.cmbBatchNo.Name = "cmbBatchNo";
            this.cmbBatchNo.Size = new System.Drawing.Size(99, 21);
            this.cmbBatchNo.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Batch No";
            // 
            // frm_PaySlipBankWiseAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1001, 676);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbBatchNo);
            this.Controls.Add(this.chbExcel);
            this.Controls.Add(this.btnSelection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.trvTenders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_PaySlipBankWiseAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tender Wise Selection for All Banks";
            this.Load += new System.EventHandler(this.frmPaySlipBankWise_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvTenders;
        private System.Windows.Forms.Button btnPrint;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelection;
        private System.Windows.Forms.CheckBox chbExcel;
        private System.Windows.Forms.ComboBox cmbBatchNo;
        private System.Windows.Forms.Label label4;
    }
}

