namespace Billing_Inventory_Management_System
{
    partial class frm_Daily_Expences
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Daily_Expences));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cmb_Exp = new System.Windows.Forms.ComboBox();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmnt = new System.Windows.Forms.TextBox();
            this.Grid_B = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnew = new System.Windows.Forms.TextBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.dt_Start = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button32 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_B)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.Pink;
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemark.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(118, 125);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(572, 30);
            this.txtRemark.TabIndex = 294;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 24);
            this.label8.TabIndex = 293;
            this.label8.Text = "Remarks";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RosyBrown;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(118, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(234, 31);
            this.button2.TabIndex = 292;
            this.button2.Text = "SAVE CHANGES";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmb_Exp
            // 
            this.cmb_Exp.BackColor = System.Drawing.Color.Pink;
            this.cmb_Exp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Exp.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Exp.ForeColor = System.Drawing.Color.Maroon;
            this.cmb_Exp.FormattingEnabled = true;
            this.cmb_Exp.Location = new System.Drawing.Point(118, 51);
            this.cmb_Exp.Name = "cmb_Exp";
            this.cmb_Exp.Size = new System.Drawing.Size(572, 32);
            this.cmb_Exp.TabIndex = 291;
            this.cmb_Exp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Exp_KeyPress);
            this.cmb_Exp.SelectedValueChanged += new System.EventHandler(this.cmb_Exp_SelectedValueChanged);
            // 
            // Grid_A
            // 
            this.Grid_A.AllowDrop = true;
            this.Grid_A.AllowUserToAddRows = false;
            this.Grid_A.AllowUserToDeleteRows = false;
            this.Grid_A.AllowUserToResizeColumns = false;
            this.Grid_A.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_A.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.Grid_A.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_A.ColumnHeadersHeight = 25;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(3, 201);
            this.Grid_A.Name = "Grid_A";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Grid_A.RowHeadersWidth = 50;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_A.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.Grid_A.Size = new System.Drawing.Size(799, 595);
            this.Grid_A.TabIndex = 289;
            this.Grid_A.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_A_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 24);
            this.label4.TabIndex = 290;
            this.label4.Text = "Expence";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 24);
            this.label5.TabIndex = 287;
            this.label5.Text = "Date";
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.RosyBrown;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.Color.Black;
            this.btn_Delete.Location = new System.Drawing.Point(486, 800);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(187, 31);
            this.btn_Delete.TabIndex = 318;
            this.btn_Delete.Text = "REMOVE ENTRY";
            this.btn_Delete.UseVisualStyleBackColor = false;
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.RosyBrown;
            this.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Back.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.ForeColor = System.Drawing.Color.Black;
            this.btn_Back.Location = new System.Drawing.Point(679, 800);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(123, 31);
            this.btn_Back.TabIndex = 317;
            this.btn_Back.Text = "QUIT";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.Pink;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(118, 89);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmount.Size = new System.Drawing.Size(190, 30);
            this.txtAmount.TabIndex = 319;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 320;
            this.label1.Text = "Amount";
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(696, 50);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 35);
            this.button5.TabIndex = 321;
            this.button5.TabStop = false;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Coral;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAmnt);
            this.panel1.Controls.Add(this.Grid_B);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtnew);
            this.panel1.Location = new System.Drawing.Point(806, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 780);
            this.panel1.TabIndex = 322;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.RosyBrown;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(252, 744);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 31);
            this.button3.TabIndex = 327;
            this.button3.Text = "UPDATE CHANGES";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 326;
            this.label3.Text = "Amount";
            // 
            // txtAmnt
            // 
            this.txtAmnt.BackColor = System.Drawing.Color.Pink;
            this.txtAmnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmnt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmnt.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmnt.Location = new System.Drawing.Point(128, 60);
            this.txtAmnt.Name = "txtAmnt";
            this.txtAmnt.Size = new System.Drawing.Size(153, 30);
            this.txtAmnt.TabIndex = 325;
            this.txtAmnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Grid_B
            // 
            this.Grid_B.AllowDrop = true;
            this.Grid_B.AllowUserToAddRows = false;
            this.Grid_B.AllowUserToDeleteRows = false;
            this.Grid_B.AllowUserToResizeColumns = false;
            this.Grid_B.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_B.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.Grid_B.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.Grid_B.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_B.ColumnHeadersHeight = 25;
            this.Grid_B.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_B.Location = new System.Drawing.Point(6, 150);
            this.Grid_B.Name = "Grid_B";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_B.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.Grid_B.RowHeadersWidth = 50;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_B.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.Grid_B.Size = new System.Drawing.Size(446, 590);
            this.Grid_B.TabIndex = 324;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(128, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 31);
            this.button1.TabIndex = 323;
            this.button1.Text = "SAVE ENTRY";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 324;
            this.label2.Text = "Expence";
            // 
            // txtnew
            // 
            this.txtnew.BackColor = System.Drawing.Color.Pink;
            this.txtnew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnew.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnew.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnew.Location = new System.Drawing.Point(128, 20);
            this.txtnew.Name = "txtnew";
            this.txtnew.Size = new System.Drawing.Size(318, 30);
            this.txtnew.TabIndex = 323;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(320, 18);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(17, 24);
            this.lblMonth.TabIndex = 323;
            this.lblMonth.Text = "-";
            // 
            // dt_Start
            // 
            this.dt_Start.Enabled = false;
            this.dt_Start.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_Start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_Start.Location = new System.Drawing.Point(118, 18);
            this.dt_Start.MaxDate = new System.DateTime(2040, 12, 31, 0, 0, 0, 0);
            this.dt_Start.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dt_Start.Name = "dt_Start";
            this.dt_Start.Size = new System.Drawing.Size(184, 30);
            this.dt_Start.TabIndex = 324;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Brown;
            this.button32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button32.BackgroundImage")));
            this.button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(1230, 0);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(38, 36);
            this.button32.TabIndex = 348;
            this.button32.TabStop = false;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(250, 797);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(230, 35);
            this.button4.TabIndex = 349;
            this.button4.Text = "View Report";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.BackColor = System.Drawing.Color.Maroon;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.SystemColors.Control;
            this.lblYear.Location = new System.Drawing.Point(591, 18);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(0, 24);
            this.lblYear.TabIndex = 350;
            // 
            // frm_Daily_Expences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1268, 835);
            this.ControlBox = false;
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button32);
            this.Controls.Add(this.dt_Start);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmb_Exp);
            this.Controls.Add(this.Grid_A);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Daily_Expences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_Daily_Expences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_B)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmb_Exp;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnew;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.DataGridView Grid_B;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmnt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dt_Start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblYear;
    }
}