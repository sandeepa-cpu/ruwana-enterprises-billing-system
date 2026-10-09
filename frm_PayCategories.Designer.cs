namespace Billing_Inventory_Management_System
{
    partial class frm_PayCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PayCategories));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_Find_Earn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Earn_ID = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_PAY_CAT_ID = new System.Windows.Forms.TextBox();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button32);
            this.groupBox2.Controls.Add(this.cmb_Find_Earn);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_Earn_ID);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.txt_PAY_CAT_ID);
            this.groupBox2.Controls.Add(this.txt_Desc);
            this.groupBox2.Location = new System.Drawing.Point(4, -4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 123);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            // 
            // cmb_Find_Earn
            // 
            this.cmb_Find_Earn.FormattingEnabled = true;
            this.cmb_Find_Earn.Location = new System.Drawing.Point(134, 97);
            this.cmb_Find_Earn.Name = "cmb_Find_Earn";
            this.cmb_Find_Earn.Size = new System.Drawing.Size(285, 21);
            this.cmb_Find_Earn.TabIndex = 39;
            this.cmb_Find_Earn.SelectedValueChanged += new System.EventHandler(this.cmb_Find_Deduct_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Earning Type";
            // 
            // txt_Earn_ID
            // 
            this.txt_Earn_ID.BackColor = System.Drawing.Color.White;
            this.txt_Earn_ID.Location = new System.Drawing.Point(134, 97);
            this.txt_Earn_ID.MaxLength = 10;
            this.txt_Earn_ID.Name = "txt_Earn_ID";
            this.txt_Earn_ID.ReadOnly = true;
            this.txt_Earn_ID.Size = new System.Drawing.Size(60, 21);
            this.txt_Earn_ID.TabIndex = 40;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(94, 13);
            this.label22.TabIndex = 34;
            this.label22.Text = "Category Code";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Description";
            // 
            // txt_PAY_CAT_ID
            // 
            this.txt_PAY_CAT_ID.Location = new System.Drawing.Point(134, 16);
            this.txt_PAY_CAT_ID.MaxLength = 10;
            this.txt_PAY_CAT_ID.Name = "txt_PAY_CAT_ID";
            this.txt_PAY_CAT_ID.Size = new System.Drawing.Size(100, 21);
            this.txt_PAY_CAT_ID.TabIndex = 17;
            // 
            // txt_Desc
            // 
            this.txt_Desc.Location = new System.Drawing.Point(134, 40);
            this.txt_Desc.MaxLength = 100;
            this.txt_Desc.Multiline = true;
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(285, 54);
            this.txt_Desc.TabIndex = 18;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Add);
            this.groupBox4.Controls.Add(this.btn_Back);
            this.groupBox4.Location = new System.Drawing.Point(4, 115);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(424, 39);
            this.groupBox4.TabIndex = 60;
            this.groupBox4.TabStop = false;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(222, 11);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(118, 23);
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
            this.Grid_A.Location = new System.Drawing.Point(4, 157);
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
            this.Grid_A.Size = new System.Drawing.Size(424, 173);
            this.Grid_A.TabIndex = 61;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(264, 333);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(164, 23);
            this.btnUpdate.TabIndex = 62;
            this.btnUpdate.Text = "Update Changes";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Brown;
            this.button32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button32.BackgroundImage")));
            this.button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(386, -2);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(38, 36);
            this.button32.TabIndex = 348;
            this.button32.TabStop = false;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // frm_PayCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(431, 358);
            this.ControlBox = false;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.Grid_A);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_PayCategories";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Pay Categories";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_PayCategories_Load);
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
        private System.Windows.Forms.TextBox txt_PAY_CAT_ID;
        private System.Windows.Forms.TextBox txt_Desc;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Earn_ID;
        private System.Windows.Forms.ComboBox cmb_Find_Earn;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button button32;
    }
}