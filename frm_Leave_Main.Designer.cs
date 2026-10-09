namespace Billing_Inventory_Management_System
{
    partial class frm_Leave_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Leave_Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.button32 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(175, 97);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(213, 30);
            this.txtAmount.TabIndex = 300;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtType
            // 
            this.txtType.BackColor = System.Drawing.Color.White;
            this.txtType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtType.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtType.Location = new System.Drawing.Point(175, 59);
            this.txtType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(611, 30);
            this.txtType.TabIndex = 298;
            this.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 297;
            this.label4.Text = "NO OF DAYS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 295;
            this.label2.Text = "LEAVE TYPE";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.Maroon;
            this.label58.Location = new System.Drawing.Point(26, 9);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(166, 29);
            this.label58.TabIndex = 302;
            this.label58.Text = "LEAVE ENTRY";
            // 
            // btn_Quit
            // 
            this.btn_Quit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Quit.BackgroundImage")));
            this.btn_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Quit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(930, -158);
            this.btn_Quit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(31, 31);
            this.btn_Quit.TabIndex = 308;
            this.btn_Quit.UseVisualStyleBackColor = true;
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.RosyBrown;
            this.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Back.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.ForeColor = System.Drawing.Color.Black;
            this.btn_Back.Location = new System.Drawing.Point(726, 630);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(143, 43);
            this.btn_Back.TabIndex = 305;
            this.btn_Back.Text = "QUIT";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.RosyBrown;
            this.btn_Delete.Enabled = false;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.Color.Black;
            this.btn_Delete.Location = new System.Drawing.Point(285, 630);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(218, 43);
            this.btn_Delete.TabIndex = 307;
            this.btn_Delete.Text = "REMOVE ENTRY";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.RosyBrown;
            this.btn_Update.Enabled = false;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.ForeColor = System.Drawing.Color.Black;
            this.btn_Update.Location = new System.Drawing.Point(6, 630);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(273, 43);
            this.btn_Update.TabIndex = 306;
            this.btn_Update.Text = "SAVE CHANGES";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Visible = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RosyBrown;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(175, 149);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(273, 43);
            this.button2.TabIndex = 304;
            this.button2.Text = "SAVE CHANGES";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Grid_A
            // 
            this.Grid_A.AllowDrop = true;
            this.Grid_A.AllowUserToAddRows = false;
            this.Grid_A.AllowUserToDeleteRows = false;
            this.Grid_A.AllowUserToResizeColumns = false;
            this.Grid_A.AllowUserToResizeRows = false;
            this.Grid_A.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.Grid_A.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grid_A.ColumnHeadersHeight = 25;
            this.Grid_A.GridColor = System.Drawing.Color.CornflowerBlue;
            this.Grid_A.Location = new System.Drawing.Point(6, 200);
            this.Grid_A.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Grid_A.Name = "Grid_A";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_A.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_A.RowHeadersWidth = 50;
            this.Grid_A.Size = new System.Drawing.Size(863, 425);
            this.Grid_A.TabIndex = 303;
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Brown;
            this.button32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button32.BackgroundImage")));
            this.button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(836, 0);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(38, 36);
            this.button32.TabIndex = 349;
            this.button32.TabStop = false;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // frm_Leave_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(875, 678);
            this.ControlBox = false;
            this.Controls.Add(this.button32);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Grid_A);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_Leave_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_JobType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.Button button32;
    }
}