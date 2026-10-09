namespace Billing_Inventory_Management_System
{
    partial class frm_Attendance
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Attendance));
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.lblYM = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button32 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbEmp = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid_A
            // 
            this.Grid_A.AllowUserToAddRows = false;
            this.Grid_A.AllowUserToDeleteRows = false;
            this.Grid_A.AllowUserToResizeColumns = false;
            this.Grid_A.AllowUserToResizeRows = false;
            this.Grid_A.BackgroundColor = System.Drawing.Color.White;
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(7, 105);
            this.Grid_A.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Grid_A.Name = "Grid_A";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_A.RowHeadersWidth = 50;
            this.Grid_A.Size = new System.Drawing.Size(1216, 666);
            this.Grid_A.TabIndex = 82;
            // 
            // lblYM
            // 
            this.lblYM.AutoSize = true;
            this.lblYM.BackColor = System.Drawing.Color.Maroon;
            this.lblYM.Font = new System.Drawing.Font("ARADHANA", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYM.ForeColor = System.Drawing.SystemColors.Control;
            this.lblYM.Location = new System.Drawing.Point(142, 49);
            this.lblYM.Name = "lblYM";
            this.lblYM.Size = new System.Drawing.Size(0, 23);
            this.lblYM.TabIndex = 84;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 6000;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(917, 779);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(169, 32);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.ForeColor = System.Drawing.Color.Black;
            this.btn_Back.Location = new System.Drawing.Point(1090, 779);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(134, 32);
            this.btn_Back.TabIndex = 3;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button32);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbEmp);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.Grid_A);
            this.groupBox1.Controls.Add(this.btn_Back);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1230, 819);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Brown;
            this.button32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button32.BackgroundImage")));
            this.button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(1193, -2);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(38, 36);
            this.button32.TabIndex = 348;
            this.button32.TabStop = false;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 309;
            this.label1.Text = "Employee Name";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(952, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 31);
            this.button1.TabIndex = 308;
            this.button1.Text = "TODAY EMPLOYEE ATTENDANCE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbEmp
            // 
            this.cmbEmp.BackColor = System.Drawing.Color.Pink;
            this.cmbEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEmp.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmp.ForeColor = System.Drawing.Color.Maroon;
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.Location = new System.Drawing.Point(179, 45);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.Size = new System.Drawing.Size(504, 32);
            this.cmbEmp.TabIndex = 307;
            this.cmbEmp.SelectedIndexChanged += new System.EventHandler(this.cmbEmp_SelectedIndexChanged);
            this.cmbEmp.SelectedValueChanged += new System.EventHandler(this.cmbEmp_SelectedValueChanged);
            // 
            // lblDate
            // 
            this.lblDate.Enabled = false;
            this.lblDate.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.lblDate.Location = new System.Drawing.Point(99, 777);
            this.lblDate.MaxDate = new System.DateTime(2040, 12, 31, 0, 0, 0, 0);
            this.lblDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(159, 30);
            this.lblDate.TabIndex = 155;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RosyBrown;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(692, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(251, 31);
            this.button2.TabIndex = 279;
            this.button2.Text = "ATTENDANCE FOR THE MONTH";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblUser
            // 
            this.lblUser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Gray;
            this.lblUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUser.Location = new System.Drawing.Point(563, 22);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(165, 20);
            this.lblUser.TabIndex = 152;
            this.lblUser.Text = "-";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.BackColor = System.Drawing.Color.Maroon;
            this.lblYear.Font = new System.Drawing.Font("ARADHANA", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.SystemColors.Control;
            this.lblYear.Location = new System.Drawing.Point(187, 20);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(0, 23);
            this.lblYear.TabIndex = 105;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.BackColor = System.Drawing.Color.Maroon;
            this.lblMonth.Font = new System.Drawing.Font("ARADHANA", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMonth.Location = new System.Drawing.Point(262, 19);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(0, 23);
            this.lblMonth.TabIndex = 106;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 349;
            this.label2.Text = "Curent Month";
            // 
            // frm_Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1236, 823);
            this.ControlBox = false;
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblYM);
            this.Controls.Add(this.lblUser);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Attendance";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_Attendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.Label lblYM;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.DateTimePicker lblDate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbEmp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Label label2;
    }
}