namespace Billing_Inventory_Management_System
{
    partial class frm_HoldLoanDeductions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmb_FindEmp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_Hold = new System.Windows.Forms.CheckBox();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_Resume = new System.Windows.Forms.CheckBox();
            this.lblEmpNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Grid_B = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_B)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_FindEmp
            // 
            this.cmb_FindEmp.BackColor = System.Drawing.Color.White;
            this.cmb_FindEmp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_FindEmp.FormattingEnabled = true;
            this.cmb_FindEmp.ItemHeight = 13;
            this.cmb_FindEmp.Location = new System.Drawing.Point(138, 31);
            this.cmb_FindEmp.MaxDropDownItems = 5;
            this.cmb_FindEmp.Name = "cmb_FindEmp";
            this.cmb_FindEmp.Size = new System.Drawing.Size(331, 21);
            this.cmb_FindEmp.TabIndex = 9;
            this.cmb_FindEmp.Leave += new System.EventHandler(this.cmb_FindEmp_Leave_1);
            this.cmb_FindEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_FindEmp_KeyPress_1);
            this.cmb_FindEmp.SelectedValueChanged += new System.EventHandler(this.cmb_FindEmp_SelectedValueChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Employee Number";
            // 
            // chk_Hold
            // 
            this.chk_Hold.AutoSize = true;
            this.chk_Hold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_Hold.Enabled = false;
            this.chk_Hold.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Hold.ForeColor = System.Drawing.Color.Maroon;
            this.chk_Hold.Location = new System.Drawing.Point(507, 21);
            this.chk_Hold.Name = "chk_Hold";
            this.chk_Hold.Size = new System.Drawing.Size(90, 17);
            this.chk_Hold.TabIndex = 10;
            this.chk_Hold.Text = "Hold Loan";
            this.chk_Hold.UseVisualStyleBackColor = true;
            this.chk_Hold.CheckedChanged += new System.EventHandler(this.chk_Hold_CheckedChanged);
            // 
            // Grid_A
            // 
            this.Grid_A.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(4, 102);
            this.Grid_A.Name = "Grid_A";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Grid_A.RowHeadersWidth = 50;
            this.Grid_A.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Grid_A.Size = new System.Drawing.Size(636, 218);
            this.Grid_A.TabIndex = 85;
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(533, 551);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(107, 23);
            this.btn_Quit.TabIndex = 87;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_Resume);
            this.groupBox1.Controls.Add(this.chk_Hold);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_FindEmp);
            this.groupBox1.Controls.Add(this.lblEmpNo);
            this.groupBox1.Location = new System.Drawing.Point(4, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 79);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // chk_Resume
            // 
            this.chk_Resume.AutoSize = true;
            this.chk_Resume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_Resume.Enabled = false;
            this.chk_Resume.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Resume.ForeColor = System.Drawing.Color.Blue;
            this.chk_Resume.Location = new System.Drawing.Point(507, 49);
            this.chk_Resume.Name = "chk_Resume";
            this.chk_Resume.Size = new System.Drawing.Size(112, 17);
            this.chk_Resume.TabIndex = 11;
            this.chk_Resume.Text = "Resume Loan";
            this.chk_Resume.UseVisualStyleBackColor = true;
            this.chk_Resume.CheckedChanged += new System.EventHandler(this.chk_Resume_CheckedChanged);
            // 
            // lblEmpNo
            // 
            this.lblEmpNo.AutoSize = true;
            this.lblEmpNo.Location = new System.Drawing.Point(134, 20);
            this.lblEmpNo.Name = "lblEmpNo";
            this.lblEmpNo.Size = new System.Drawing.Size(0, 13);
            this.lblEmpNo.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(7, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 89;
            this.label2.Text = "Active Loans";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(6, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "Inactive Loans";
            // 
            // Grid_B
            // 
            this.Grid_B.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Grid_B.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_B.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_B.DefaultCellStyle = dataGridViewCellStyle5;
            this.Grid_B.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_B.Location = new System.Drawing.Point(4, 342);
            this.Grid_B.Name = "Grid_B";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_B.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Grid_B.RowHeadersWidth = 50;
            this.Grid_B.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Grid_B.Size = new System.Drawing.Size(636, 206);
            this.Grid_B.TabIndex = 86;
            // 
            // frm_HoldLoanDeductions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(644, 577);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.Grid_B);
            this.Controls.Add(this.Grid_A);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_HoldLoanDeductions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Hold Loan Deductions";
            this.Load += new System.EventHandler(this.frm_HoldLoanDeductions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_B)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_FindEmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_Hold;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_Resume;
        private System.Windows.Forms.DataGridView Grid_B;
        private System.Windows.Forms.Label lblEmpNo;
    }
}