namespace Billing_Inventory_Management_System
{
    partial class frm_EmployeeFundRates
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ETF_ER = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_EPF_ER = new System.Windows.Forms.TextBox();
            this.txt_EPF_EE = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "%";
            // 
            // txt_ETF_ER
            // 
            this.txt_ETF_ER.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ETF_ER.ForeColor = System.Drawing.Color.Blue;
            this.txt_ETF_ER.Location = new System.Drawing.Point(167, 89);
            this.txt_ETF_ER.MaxLength = 4;
            this.txt_ETF_ER.Name = "txt_ETF_ER";
            this.txt_ETF_ER.Size = new System.Drawing.Size(49, 21);
            this.txt_ETF_ER.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(23, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(117, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "EPF Employee Rate";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(23, 92);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 13);
            this.label20.TabIndex = 36;
            this.label20.Text = "ETF Employee Rate";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_ETF_ER);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txt_EPF_ER);
            this.groupBox2.Controls.Add(this.txt_EPF_EE);
            this.groupBox2.Location = new System.Drawing.Point(5, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 129);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Company Settings";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(23, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(115, 13);
            this.label22.TabIndex = 34;
            this.label22.Text = "EPF Employer Rate";
            // 
            // txt_EPF_ER
            // 
            this.txt_EPF_ER.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EPF_ER.ForeColor = System.Drawing.Color.Blue;
            this.txt_EPF_ER.Location = new System.Drawing.Point(167, 26);
            this.txt_EPF_ER.MaxLength = 4;
            this.txt_EPF_ER.Name = "txt_EPF_ER";
            this.txt_EPF_ER.Size = new System.Drawing.Size(49, 21);
            this.txt_EPF_ER.TabIndex = 1;
            // 
            // txt_EPF_EE
            // 
            this.txt_EPF_EE.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EPF_EE.ForeColor = System.Drawing.Color.Blue;
            this.txt_EPF_EE.Location = new System.Drawing.Point(167, 57);
            this.txt_EPF_EE.MaxLength = 4;
            this.txt_EPF_EE.Name = "txt_EPF_EE";
            this.txt_EPF_EE.Size = new System.Drawing.Size(49, 21);
            this.txt_EPF_EE.TabIndex = 2;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(119, 142);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(98, 23);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(221, 142);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(63, 23);
            this.btn_Quit.TabIndex = 5;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // frm_EmployeeFundRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(289, 168);
            this.ControlBox = true;
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_EmployeeFundRates";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Employee Fund Rates";
            this.Load += new System.EventHandler(this.frm_EmployeeFundRates_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ETF_ER;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_EPF_ER;
        private System.Windows.Forms.TextBox txt_EPF_EE;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Quit;
    }
}