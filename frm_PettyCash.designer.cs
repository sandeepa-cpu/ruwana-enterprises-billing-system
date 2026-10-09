namespace Billing_Inventory_Management_System
{
    partial class frm_PettyCash
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PettyCash));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_Amnt = new System.Windows.Forms.TextBox();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.btn_Update = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb_Out = new System.Windows.Forms.RadioButton();
            this.rb_In = new System.Windows.Forms.RadioButton();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.DateTimePicker();
            this.label58 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_Code);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.txt_Amnt);
            this.groupBox2.Controls.Add(this.txt_Desc);
            this.groupBox2.Location = new System.Drawing.Point(7, 96);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox2.Size = new System.Drawing.Size(913, 124);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            // 
            // lbl_Code
            // 
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.Location = new System.Drawing.Point(13, 29);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(87, 20);
            this.lbl_Code.TabIndex = 34;
            this.lbl_Code.Text = "IN AMOUNT";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 20);
            this.label21.TabIndex = 35;
            this.label21.Text = "DESCRIPTION";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // txt_Amnt
            // 
            this.txt_Amnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Amnt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Amnt.Location = new System.Drawing.Point(137, 26);
            this.txt_Amnt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_Amnt.MaxLength = 10;
            this.txt_Amnt.Name = "txt_Amnt";
            this.txt_Amnt.Size = new System.Drawing.Size(120, 25);
            this.txt_Amnt.TabIndex = 3;
            // 
            // txt_Desc
            // 
            this.txt_Desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Desc.Location = new System.Drawing.Point(137, 58);
            this.txt_Desc.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_Desc.MaxLength = 100;
            this.txt_Desc.Multiline = true;
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(767, 57);
            this.txt_Desc.TabIndex = 4;
            this.txt_Desc.TextChanged += new System.EventHandler(this.txt_Desc_TextChanged);
            this.txt_Desc.Leave += new System.EventHandler(this.txt_Desc_Leave);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(701, 225);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(222, 35);
            this.btn_Add.TabIndex = 6;
            this.btn_Add.Text = "Save Entry";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // Grid_A
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_A.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(7, 265);
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
            this.Grid_A.Size = new System.Drawing.Size(916, 368);
            this.Grid_A.TabIndex = 74;
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(693, 636);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(230, 35);
            this.btn_Update.TabIndex = 8;
            this.btn_Update.Text = "Update Changes";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_Out);
            this.groupBox3.Controls.Add(this.rb_In);
            this.groupBox3.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(7, 38);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox3.Size = new System.Drawing.Size(913, 62);
            this.groupBox3.TabIndex = 75;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SELECT IN OR OUT";
            // 
            // rb_Out
            // 
            this.rb_Out.AutoSize = true;
            this.rb_Out.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Out.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Out.Location = new System.Drawing.Point(490, 28);
            this.rb_Out.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.rb_Out.Name = "rb_Out";
            this.rb_Out.Size = new System.Drawing.Size(208, 24);
            this.rb_Out.TabIndex = 2;
            this.rb_Out.Text = "PETTY CASH OUT AMOUNT";
            this.rb_Out.UseVisualStyleBackColor = true;
            this.rb_Out.CheckedChanged += new System.EventHandler(this.rb_Branch_CheckedChanged);
            // 
            // rb_In
            // 
            this.rb_In.AutoSize = true;
            this.rb_In.Checked = true;
            this.rb_In.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_In.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_In.Location = new System.Drawing.Point(198, 28);
            this.rb_In.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.rb_In.Name = "rb_In";
            this.rb_In.Size = new System.Drawing.Size(193, 24);
            this.rb_In.TabIndex = 1;
            this.rb_In.TabStop = true;
            this.rb_In.Text = "PETTY CASH IN AMOUNT";
            this.rb_In.UseVisualStyleBackColor = true;
            this.rb_In.CheckedChanged += new System.EventHandler(this.rb_Bank_CheckedChanged);
            // 
            // btn_Quit
            // 
            this.btn_Quit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Quit.BackgroundImage")));
            this.btn_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Quit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(891, 2);
            this.btn_Quit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(35, 33);
            this.btn_Quit.TabIndex = 268;
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(547, 225);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 35);
            this.button1.TabIndex = 76;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDate
            // 
            this.lblDate.Enabled = false;
            this.lblDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.lblDate.Location = new System.Drawing.Point(7, 643);
            this.lblDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblDate.MaxDate = new System.DateTime(2040, 12, 31, 0, 0, 0, 0);
            this.lblDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(181, 25);
            this.lblDate.TabIndex = 156;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.Maroon;
            this.label58.Location = new System.Drawing.Point(12, 4);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(251, 29);
            this.label58.TabIndex = 303;
            this.label58.Text = "PETTY CASH ENTRIES";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(457, 636);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 35);
            this.button2.TabIndex = 304;
            this.button2.Text = "View Report";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.BackColor = System.Drawing.Color.Maroon;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.SystemColors.Control;
            this.lblYear.Location = new System.Drawing.Point(20, 229);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(0, 24);
            this.lblYear.TabIndex = 305;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.BackColor = System.Drawing.Color.Maroon;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMonth.Location = new System.Drawing.Point(107, 229);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(0, 24);
            this.lblMonth.TabIndex = 306;
            // 
            // frm_PettyCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(929, 675);
            this.ControlBox = false;
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.Grid_A);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_PettyCash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_BankBranchDetails_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_Desc;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rb_Out;
        private System.Windows.Forms.RadioButton rb_In;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.TextBox txt_Amnt;
        private System.Windows.Forms.DateTimePicker lblDate;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
    }
}