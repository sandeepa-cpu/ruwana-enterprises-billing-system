namespace Billing_Inventory_Management_System
{
    partial class frm_ChangeProcessPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChangeProcessPeriod));
            this.btn_PeriodChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNextlabel = new System.Windows.Forms.Label();
            this.lbl_CurrentDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_NextDate = new System.Windows.Forms.DateTimePicker();
            this.label58 = new System.Windows.Forms.Label();
            this.button32 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_PeriodChange
            // 
            this.btn_PeriodChange.BackColor = System.Drawing.Color.White;
            this.btn_PeriodChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PeriodChange.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PeriodChange.ForeColor = System.Drawing.Color.Maroon;
            this.btn_PeriodChange.Location = new System.Drawing.Point(104, 321);
            this.btn_PeriodChange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_PeriodChange.Name = "btn_PeriodChange";
            this.btn_PeriodChange.Size = new System.Drawing.Size(265, 60);
            this.btn_PeriodChange.TabIndex = 11;
            this.btn_PeriodChange.Text = "Set Next Proccess Date";
            this.btn_PeriodChange.UseVisualStyleBackColor = false;
            this.btn_PeriodChange.Click += new System.EventHandler(this.btn_PeriodChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Current Processing Date";
            // 
            // lblNextlabel
            // 
            this.lblNextlabel.AutoSize = true;
            this.lblNextlabel.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextlabel.Location = new System.Drawing.Point(146, 221);
            this.lblNextlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNextlabel.Name = "lblNextlabel";
            this.lblNextlabel.Size = new System.Drawing.Size(190, 24);
            this.lblNextlabel.TabIndex = 18;
            this.lblNextlabel.Text = "Next Processing Date";
            this.lblNextlabel.Visible = false;
            // 
            // lbl_CurrentDate
            // 
            this.lbl_CurrentDate.CustomFormat = "yyyy-MM-dd";
            this.lbl_CurrentDate.Enabled = false;
            this.lbl_CurrentDate.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CurrentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.lbl_CurrentDate.Location = new System.Drawing.Point(161, 126);
            this.lbl_CurrentDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbl_CurrentDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.lbl_CurrentDate.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.lbl_CurrentDate.Name = "lbl_CurrentDate";
            this.lbl_CurrentDate.Size = new System.Drawing.Size(163, 30);
            this.lbl_CurrentDate.TabIndex = 19;
            this.lbl_CurrentDate.Value = new System.DateTime(2019, 1, 15, 0, 0, 0, 0);
            // 
            // lbl_NextDate
            // 
            this.lbl_NextDate.CustomFormat = "yyyy-MM-dd";
            this.lbl_NextDate.Enabled = false;
            this.lbl_NextDate.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NextDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.lbl_NextDate.Location = new System.Drawing.Point(161, 253);
            this.lbl_NextDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbl_NextDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.lbl_NextDate.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.lbl_NextDate.Name = "lbl_NextDate";
            this.lbl_NextDate.Size = new System.Drawing.Size(163, 30);
            this.lbl_NextDate.TabIndex = 20;
            this.lbl_NextDate.Value = new System.DateTime(2019, 1, 15, 0, 0, 0, 0);
            this.lbl_NextDate.Visible = false;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.Maroon;
            this.label58.Location = new System.Drawing.Point(7, 9);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(339, 29);
            this.label58.TabIndex = 265;
            this.label58.Text = "CHANGE PROCESSING PERIOD";
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Brown;
            this.button32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button32.BackgroundImage")));
            this.button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(439, 0);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(38, 36);
            this.button32.TabIndex = 348;
            this.button32.TabStop = false;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // frm_ChangeProcessPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(478, 422);
            this.ControlBox = false;
            this.Controls.Add(this.button32);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.lbl_NextDate);
            this.Controls.Add(this.lbl_CurrentDate);
            this.Controls.Add(this.lblNextlabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_PeriodChange);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChangeProcessPeriod";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_ChangeProcessPeriod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PeriodChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNextlabel;
        private System.Windows.Forms.DateTimePicker lbl_CurrentDate;
        private System.Windows.Forms.DateTimePicker lbl_NextDate;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button button32;
    }
}