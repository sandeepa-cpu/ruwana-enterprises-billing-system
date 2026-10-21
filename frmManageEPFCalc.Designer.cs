namespace Billing_Inventory_Management_System
{
    partial class frmManageEPFCalc
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lbl_Ten_No = new System.Windows.Forms.Label();
            this.cmbTenNo = new System.Windows.Forms.ComboBox();
            this.lsbEmpNo = new System.Windows.Forms.ListBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeselect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddBacktoReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(7, 444);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(202, 26);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Pause Print in EPF Report";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lbl_Ten_No
            // 
            this.lbl_Ten_No.AutoSize = true;
            this.lbl_Ten_No.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ten_No.Location = new System.Drawing.Point(4, 12);
            this.lbl_Ten_No.Name = "lbl_Ten_No";
            this.lbl_Ten_No.Size = new System.Drawing.Size(105, 13);
            this.lbl_Ten_No.TabIndex = 74;
            this.lbl_Ten_No.Text = "Select Tender No";
            // 
            // cmbTenNo
            // 
            this.cmbTenNo.FormattingEnabled = true;
            this.cmbTenNo.Items.AddRange(new object[] {
            "OFFICE"});
            this.cmbTenNo.Location = new System.Drawing.Point(6, 28);
            this.cmbTenNo.Name = "cmbTenNo";
            this.cmbTenNo.Size = new System.Drawing.Size(424, 21);
            this.cmbTenNo.TabIndex = 75;
            this.cmbTenNo.SelectedValueChanged += new System.EventHandler(this.cmbTenNo_SelectedValueChanged);
            // 
            // lsbEmpNo
            // 
            this.lsbEmpNo.FormattingEnabled = true;
            this.lsbEmpNo.Location = new System.Drawing.Point(6, 83);
            this.lsbEmpNo.Name = "lsbEmpNo";
            this.lsbEmpNo.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbEmpNo.Size = new System.Drawing.Size(424, 355);
            this.lsbEmpNo.TabIndex = 76;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(242, 58);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(91, 21);
            this.btnSelectAll.TabIndex = 77;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselect
            // 
            this.btnDeselect.Location = new System.Drawing.Point(339, 58);
            this.btnDeselect.Name = "btnDeselect";
            this.btnDeselect.Size = new System.Drawing.Size(91, 21);
            this.btnDeselect.TabIndex = 78;
            this.btnDeselect.Text = "Deselect All";
            this.btnDeselect.UseVisualStyleBackColor = true;
            this.btnDeselect.Click += new System.EventHandler(this.btnDeselect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Select Eployees";
            // 
            // btnAddBacktoReport
            // 
            this.btnAddBacktoReport.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBacktoReport.Location = new System.Drawing.Point(228, 444);
            this.btnAddBacktoReport.Name = "btnAddBacktoReport";
            this.btnAddBacktoReport.Size = new System.Drawing.Size(202, 26);
            this.btnAddBacktoReport.TabIndex = 79;
            this.btnAddBacktoReport.Text = "Update Print in EPF Report";
            this.btnAddBacktoReport.UseVisualStyleBackColor = true;
            this.btnAddBacktoReport.Click += new System.EventHandler(this.btnAddBacktoReport_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(310, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 24);
            this.button1.TabIndex = 80;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmManageEPFCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(435, 502);
            this.ControlBox = true;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddBacktoReport);
            this.Controls.Add(this.btnDeselect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.lsbEmpNo);
            this.Controls.Add(this.cmbTenNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Ten_No);
            this.Controls.Add(this.btnUpdate);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(450, 165);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageEPFCalc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " Manage EPF Report Settings";
            this.Load += new System.EventHandler(this.frmManageEPFCalc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lbl_Ten_No;
        private System.Windows.Forms.ComboBox cmbTenNo;
        private System.Windows.Forms.ListBox lsbEmpNo;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnDeselect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddBacktoReport;
        private System.Windows.Forms.Button button1;
    }
}