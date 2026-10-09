namespace Billing_Inventory_Management_System
{
    partial class frm_General
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCat = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmb_MAKE = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.Grid_B = new System.Windows.Forms.DataGridView();
            this.Grid_C = new System.Windows.Forms.DataGridView();
            this.btn_Save1 = new System.Windows.Forms.Button();
            this.btn_Up1 = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbCat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCat1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_C)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 13);
            this.label16.TabIndex = 92;
            this.label16.Text = "New Category Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCat);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 55);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Category Info.";
            // 
            // txtCat
            // 
            this.txtCat.Location = new System.Drawing.Point(193, 27);
            this.txtCat.Name = "txtCat";
            this.txtCat.Size = new System.Drawing.Size(329, 21);
            this.txtCat.TabIndex = 2;
            this.txtCat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCat_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbCat);
            this.groupBox2.Controls.Add(this.txtMake);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(4, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 55);
            this.groupBox2.TabIndex = 96;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Brand / Make Info.";
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(193, 31);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(329, 21);
            this.txtMake.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "New Brand / Make Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cmb_MAKE);
            this.groupBox3.Controls.Add(this.cmbCat1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtModel);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(4, 220);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 86);
            this.groupBox3.TabIndex = 97;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model Info.";
            // 
            // cmb_MAKE
            // 
            this.cmb_MAKE.BackColor = System.Drawing.Color.White;
            this.cmb_MAKE.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_MAKE.FormattingEnabled = true;
            this.cmb_MAKE.Location = new System.Drawing.Point(193, 30);
            this.cmb_MAKE.Name = "cmb_MAKE";
            this.cmb_MAKE.Size = new System.Drawing.Size(329, 21);
            this.cmb_MAKE.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 100;
            this.label3.Text = "Select Brand / Make Name";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(193, 58);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(329, 21);
            this.txtModel.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "New Model Name";
            // 
            // Grid_A
            // 
            this.Grid_A.AllowDrop = true;
            this.Grid_A.AllowUserToAddRows = false;
            this.Grid_A.AllowUserToResizeColumns = false;
            this.Grid_A.AllowUserToResizeRows = false;
            this.Grid_A.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.Grid_A.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_A.ColumnHeadersHeight = 20;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(536, 18);
            this.Grid_A.Name = "Grid_A";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_A.RowHeadersWidth = 50;
            this.Grid_A.Size = new System.Drawing.Size(319, 101);
            this.Grid_A.TabIndex = 99;
            // 
            // Grid_B
            // 
            this.Grid_B.AllowDrop = true;
            this.Grid_B.AllowUserToAddRows = false;
            this.Grid_B.AllowUserToResizeColumns = false;
            this.Grid_B.AllowUserToResizeRows = false;
            this.Grid_B.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.Grid_B.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grid_B.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_B.ColumnHeadersHeight = 20;
            this.Grid_B.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_B.Location = new System.Drawing.Point(536, 122);
            this.Grid_B.Name = "Grid_B";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_B.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_B.RowHeadersWidth = 50;
            this.Grid_B.Size = new System.Drawing.Size(319, 101);
            this.Grid_B.TabIndex = 100;
            // 
            // Grid_C
            // 
            this.Grid_C.AllowDrop = true;
            this.Grid_C.AllowUserToAddRows = false;
            this.Grid_C.AllowUserToResizeColumns = false;
            this.Grid_C.AllowUserToResizeRows = false;
            this.Grid_C.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.Grid_C.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grid_C.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_C.ColumnHeadersHeight = 20;
            this.Grid_C.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_C.Location = new System.Drawing.Point(536, 226);
            this.Grid_C.Name = "Grid_C";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_C.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_C.RowHeadersWidth = 50;
            this.Grid_C.Size = new System.Drawing.Size(319, 101);
            this.Grid_C.TabIndex = 101;
            // 
            // btn_Save1
            // 
            this.btn_Save1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save1.Location = new System.Drawing.Point(394, 344);
            this.btn_Save1.Name = "btn_Save1";
            this.btn_Save1.Size = new System.Drawing.Size(141, 23);
            this.btn_Save1.TabIndex = 15;
            this.btn_Save1.Text = "Save ";
            this.btn_Save1.UseVisualStyleBackColor = true;
            this.btn_Save1.Click += new System.EventHandler(this.btn_Save1_Click);
            // 
            // btn_Up1
            // 
            this.btn_Up1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Up1.Location = new System.Drawing.Point(706, 329);
            this.btn_Up1.Name = "btn_Up1";
            this.btn_Up1.Size = new System.Drawing.Size(150, 23);
            this.btn_Up1.TabIndex = 16;
            this.btn_Up1.Text = "Update Changes";
            this.btn_Up1.UseVisualStyleBackColor = true;
            this.btn_Up1.Click += new System.EventHandler(this.btn_Up1_Click);
            // 
            // btn_Quit
            // 
            this.btn_Quit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(536, 329);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(79, 23);
            this.btn_Quit.TabIndex = 0;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(202, 80);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Unit of Measure";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(26, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Add Unit of Measure";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 21);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbCat
            // 
            this.cmbCat.BackColor = System.Drawing.Color.White;
            this.cmbCat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCat.FormattingEnabled = true;
            this.cmbCat.Location = new System.Drawing.Point(193, 9);
            this.cmbCat.Name = "cmbCat";
            this.cmbCat.Size = new System.Drawing.Size(329, 21);
            this.cmbCat.TabIndex = 101;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 102;
            this.label4.Text = "New Category Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 104;
            this.label5.Text = "New Category Name";
            // 
            // cmbCat1
            // 
            this.cmbCat1.BackColor = System.Drawing.Color.White;
            this.cmbCat1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCat1.FormattingEnabled = true;
            this.cmbCat1.Location = new System.Drawing.Point(193, 6);
            this.cmbCat1.Name = "cmbCat1";
            this.cmbCat1.Size = new System.Drawing.Size(329, 21);
            this.cmbCat1.TabIndex = 103;
            // 
            // frm_General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 509);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Up1);
            this.Controls.Add(this.btn_Save1);
            this.Controls.Add(this.Grid_C);
            this.Controls.Add(this.Grid_B);
            this.Controls.Add(this.Grid_A);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_General";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " General Info.";
            this.Load += new System.EventHandler(this.frm_General_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_C)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCat;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.DataGridView Grid_B;
        private System.Windows.Forms.DataGridView Grid_C;
        private System.Windows.Forms.Button btn_Save1;
        private System.Windows.Forms.Button btn_Up1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_MAKE;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbCat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCat1;
    }
}