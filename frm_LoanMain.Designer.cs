namespace Billing_Inventory_Management_System
{
    partial class frm_LoanMain
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_Find_Deduct = new System.Windows.Forms.ComboBox();
            this.txt_DED_ID = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_LoanID = new System.Windows.Forms.TextBox();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmb_Find_Deduct);
            this.groupBox2.Controls.Add(this.txt_DED_ID);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txt_LoanID);
            this.groupBox2.Controls.Add(this.txt_Desc);
            this.groupBox2.Location = new System.Drawing.Point(3, -3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 140);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            // 
            // cmb_Find_Deduct
            // 
            this.cmb_Find_Deduct.FormattingEnabled = true;
            this.cmb_Find_Deduct.Location = new System.Drawing.Point(134, 109);
            this.cmb_Find_Deduct.Name = "cmb_Find_Deduct";
            this.cmb_Find_Deduct.Size = new System.Drawing.Size(285, 21);
            this.cmb_Find_Deduct.TabIndex = 37;
            this.cmb_Find_Deduct.SelectedValueChanged += new System.EventHandler(this.cmb_Find_Deduct_SelectedValueChanged);
            // 
            // txt_DED_ID
            // 
            this.txt_DED_ID.BackColor = System.Drawing.Color.White;
            this.txt_DED_ID.Location = new System.Drawing.Point(134, 109);
            this.txt_DED_ID.MaxLength = 10;
            this.txt_DED_ID.Name = "txt_DED_ID";
            this.txt_DED_ID.ReadOnly = true;
            this.txt_DED_ID.Size = new System.Drawing.Size(60, 21);
            this.txt_DED_ID.TabIndex = 38;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(68, 13);
            this.label22.TabIndex = 34;
            this.label22.Text = "Loan Code";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 65);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Description";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(121, 13);
            this.label20.TabIndex = 36;
            this.label20.Text = "Deduction Category";
            // 
            // txt_LoanID
            // 
            this.txt_LoanID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_LoanID.Location = new System.Drawing.Point(134, 16);
            this.txt_LoanID.MaxLength = 10;
            this.txt_LoanID.Name = "txt_LoanID";
            this.txt_LoanID.Size = new System.Drawing.Size(100, 21);
            this.txt_LoanID.TabIndex = 17;
            // 
            // txt_Desc
            // 
            this.txt_Desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Desc.Location = new System.Drawing.Point(134, 39);
            this.txt_Desc.MaxLength = 100;
            this.txt_Desc.Multiline = true;
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(285, 68);
            this.txt_Desc.TabIndex = 18;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Add);
            this.groupBox4.Controls.Add(this.btn_Back);
            this.groupBox4.Location = new System.Drawing.Point(3, 133);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(426, 39);
            this.groupBox4.TabIndex = 58;
            this.groupBox4.TabStop = false;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(235, 11);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(105, 23);
            this.btn_Add.TabIndex = 22;
            this.btn_Add.Text = "Save";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.Location = new System.Drawing.Point(344, 11);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(76, 23);
            this.btn_Back.TabIndex = 27;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // Grid_A
            // 
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(3, 175);
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
            this.Grid_A.Size = new System.Drawing.Size(426, 173);
            this.Grid_A.TabIndex = 64;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(265, 351);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(164, 23);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Update Changes";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frm_LoanMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(432, 376);
            this.ControlBox = false;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.Grid_A);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_LoanMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Loan Information";
            this.Load += new System.EventHandler(this.frm_LoanDetails_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_LoanID;
        private System.Windows.Forms.TextBox txt_Desc;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.ComboBox cmb_Find_Deduct;
        private System.Windows.Forms.TextBox txt_DED_ID;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.Button btnUpdate;
    }
}