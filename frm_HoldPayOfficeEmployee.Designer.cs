namespace Billing_Inventory_Management_System
{
    partial class frm_HoldPayOfficeEmployee
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
            this.btn_Hold = new System.Windows.Forms.Button();
            this.btn_Resume = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEmpNo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_FindEmp = new System.Windows.Forms.ComboBox();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.Grid_B = new System.Windows.Forms.DataGridView();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Hold
            // 
            this.btn_Hold.Enabled = false;
            this.btn_Hold.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Hold.ForeColor = System.Drawing.Color.Maroon;
            this.btn_Hold.Location = new System.Drawing.Point(544, 16);
            this.btn_Hold.Name = "btn_Hold";
            this.btn_Hold.Size = new System.Drawing.Size(167, 33);
            this.btn_Hold.TabIndex = 0;
            this.btn_Hold.Text = "Hold Payment";
            this.btn_Hold.UseVisualStyleBackColor = true;
            this.btn_Hold.Click += new System.EventHandler(this.btn_Hold_Click);
            // 
            // btn_Resume
            // 
            this.btn_Resume.Enabled = false;
            this.btn_Resume.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Resume.ForeColor = System.Drawing.Color.Blue;
            this.btn_Resume.Location = new System.Drawing.Point(544, 49);
            this.btn_Resume.Name = "btn_Resume";
            this.btn_Resume.Size = new System.Drawing.Size(168, 33);
            this.btn_Resume.TabIndex = 1;
            this.btn_Resume.Text = "Resume Payment";
            this.btn_Resume.UseVisualStyleBackColor = true;
            this.btn_Resume.Click += new System.EventHandler(this.btn_Resume_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(7, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Active Office Employees";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(550, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Inactive Office Employees";
            // 
            // lblEmpNo
            // 
            this.lblEmpNo.AutoSize = true;
            this.lblEmpNo.Location = new System.Drawing.Point(134, 32);
            this.lblEmpNo.Name = "lblEmpNo";
            this.lblEmpNo.Size = new System.Drawing.Size(0, 13);
            this.lblEmpNo.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_FindEmp);
            this.groupBox1.Controls.Add(this.lblEmpNo);
            this.groupBox1.Controls.Add(this.btn_Hold);
            this.groupBox1.Controls.Add(this.btn_Resume);
            this.groupBox1.Location = new System.Drawing.Point(5, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 89);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Employee Number";
            // 
            // cmb_FindEmp
            // 
            this.cmb_FindEmp.BackColor = System.Drawing.Color.White;
            this.cmb_FindEmp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_FindEmp.FormattingEnabled = true;
            this.cmb_FindEmp.ItemHeight = 13;
            this.cmb_FindEmp.Location = new System.Drawing.Point(140, 35);
            this.cmb_FindEmp.MaxDropDownItems = 5;
            this.cmb_FindEmp.Name = "cmb_FindEmp";
            this.cmb_FindEmp.Size = new System.Drawing.Size(381, 21);
            this.cmb_FindEmp.TabIndex = 9;
            this.cmb_FindEmp.Leave += new System.EventHandler(this.cmb_FindEmp_Leave);
            this.cmb_FindEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_FindEmp_KeyPress);
            this.cmb_FindEmp.SelectedValueChanged += new System.EventHandler(this.cmb_FindEmp_SelectedValueChanged);
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(632, 566);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(94, 23);
            this.btn_Quit.TabIndex = 93;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // Grid_B
            // 
            this.Grid_B.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Grid_B.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_B.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_B.DefaultCellStyle = dataGridViewCellStyle4;
            this.Grid_B.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_B.Location = new System.Drawing.Point(370, 113);
            this.Grid_B.Name = "Grid_B";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_B.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Grid_B.RowHeadersWidth = 50;
            this.Grid_B.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Grid_B.Size = new System.Drawing.Size(355, 450);
            this.Grid_B.TabIndex = 92;
            // 
            // Grid_A
            // 
            this.Grid_A.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(4, 113);
            this.Grid_A.Name = "Grid_A";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Grid_A.RowHeadersWidth = 50;
            this.Grid_A.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Grid_A.Size = new System.Drawing.Size(355, 450);
            this.Grid_A.TabIndex = 91;
            // 
            // frm_HoldPayOfficeEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(729, 592);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.Grid_B);
            this.Controls.Add(this.Grid_A);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_HoldPayOfficeEmployee";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Hold Payment for Office Employees";
            this.Load += new System.EventHandler(this.frm_HoldPayOfficeEmployee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Hold;
        private System.Windows.Forms.Button btn_Resume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEmpNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_FindEmp;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.DataGridView Grid_B;
        private System.Windows.Forms.DataGridView Grid_A;
    }
}