namespace Billing_Inventory_Management_System
{
    partial class frm_PaymentMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PaymentMode));
            this.tbCash = new System.Windows.Forms.TabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.lblAmountA = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBal = new System.Windows.Forms.Label();
            this.lblInv = new System.Windows.Forms.Label();
            this.lblSEQ = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.btnCredit = new System.Windows.Forms.Button();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.rbcash = new System.Windows.Forms.RadioButton();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.button32 = new System.Windows.Forms.Button();
            this.tbCash.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbCash
            // 
            this.tbCash.Controls.Add(this.tabPage9);
            this.tbCash.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCash.Location = new System.Drawing.Point(2, 39);
            this.tbCash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCash.Name = "tbCash";
            this.tbCash.SelectedIndex = 0;
            this.tbCash.Size = new System.Drawing.Size(420, 341);
            this.tbCash.TabIndex = 195;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.lblAmountA);
            this.tabPage9.Controls.Add(this.label2);
            this.tabPage9.Controls.Add(this.label1);
            this.tabPage9.Controls.Add(this.lblBal);
            this.tabPage9.Controls.Add(this.lblInv);
            this.tabPage9.Controls.Add(this.lblSEQ);
            this.tabPage9.Controls.Add(this.lblAmount);
            this.tabPage9.Controls.Add(this.txtCash);
            this.tabPage9.Controls.Add(this.btnCredit);
            this.tabPage9.Controls.Add(this.txtCredit);
            this.tabPage9.Controls.Add(this.rbcash);
            this.tabPage9.Controls.Add(this.rbCredit);
            this.tabPage9.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage9.Size = new System.Drawing.Size(412, 315);
            this.tabPage9.TabIndex = 0;
            this.tabPage9.Text = "                                                                                 " +
                "                                                                          ";
            this.tabPage9.UseVisualStyleBackColor = true;
            this.tabPage9.Click += new System.EventHandler(this.tabPage9_Click);
            // 
            // lblAmountA
            // 
            this.lblAmountA.AutoSize = true;
            this.lblAmountA.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountA.ForeColor = System.Drawing.Color.Blue;
            this.lblAmountA.Location = new System.Drawing.Point(379, 75);
            this.lblAmountA.Name = "lblAmountA";
            this.lblAmountA.Size = new System.Drawing.Size(16, 22);
            this.lblAmountA.TabIndex = 205;
            this.lblAmountA.Text = "-";
            this.lblAmountA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 204;
            this.label2.Text = "Invoice Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 203;
            this.label1.Text = "Invoice No";
            // 
            // lblBal
            // 
            this.lblBal.AutoSize = true;
            this.lblBal.Enabled = false;
            this.lblBal.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBal.Location = new System.Drawing.Point(491, 55);
            this.lblBal.Name = "lblBal";
            this.lblBal.Size = new System.Drawing.Size(16, 22);
            this.lblBal.TabIndex = 201;
            this.lblBal.Text = "-";
            this.lblBal.Visible = false;
            // 
            // lblInv
            // 
            this.lblInv.AutoSize = true;
            this.lblInv.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInv.ForeColor = System.Drawing.Color.Blue;
            this.lblInv.Location = new System.Drawing.Point(232, 27);
            this.lblInv.Name = "lblInv";
            this.lblInv.Size = new System.Drawing.Size(16, 22);
            this.lblInv.TabIndex = 200;
            this.lblInv.Text = "-";
            this.lblInv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSEQ
            // 
            this.lblSEQ.AutoSize = true;
            this.lblSEQ.Enabled = false;
            this.lblSEQ.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEQ.Location = new System.Drawing.Point(491, 30);
            this.lblSEQ.Name = "lblSEQ";
            this.lblSEQ.Size = new System.Drawing.Size(16, 22);
            this.lblSEQ.TabIndex = 199;
            this.lblSEQ.Text = "-";
            this.lblSEQ.Visible = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblAmount.Location = new System.Drawing.Point(232, 75);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(16, 22);
            this.lblAmount.TabIndex = 198;
            this.lblAmount.Text = "-";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCash
            // 
            this.txtCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCash.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.Location = new System.Drawing.Point(236, 140);
            this.txtCash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCash.Name = "txtCash";
            this.txtCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCash.Size = new System.Drawing.Size(159, 26);
            this.txtCash.TabIndex = 1;
            this.txtCash.Text = "0.00";
            this.txtCash.Leave += new System.EventHandler(this.txtCash_Leave);
            this.txtCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCash_KeyPress);
            // 
            // btnCredit
            // 
            this.btnCredit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCredit.Location = new System.Drawing.Point(236, 254);
            this.btnCredit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(159, 46);
            this.btnCredit.TabIndex = 5;
            this.btnCredit.Text = "Save";
            this.btnCredit.UseVisualStyleBackColor = true;
            this.btnCredit.Click += new System.EventHandler(this.btnCredit_Click);
            // 
            // txtCredit
            // 
            this.txtCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCredit.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredit.Location = new System.Drawing.Point(236, 195);
            this.txtCredit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCredit.Size = new System.Drawing.Size(159, 26);
            this.txtCredit.TabIndex = 2;
            this.txtCredit.Text = "0.00";
            this.txtCredit.Leave += new System.EventHandler(this.txtCredit_Leave);
            this.txtCredit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCredit_KeyPress);
            // 
            // rbcash
            // 
            this.rbcash.AutoSize = true;
            this.rbcash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbcash.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbcash.Location = new System.Drawing.Point(72, 143);
            this.rbcash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcash.Name = "rbcash";
            this.rbcash.Size = new System.Drawing.Size(54, 22);
            this.rbcash.TabIndex = 3;
            this.rbcash.TabStop = true;
            this.rbcash.Text = "Cash";
            this.rbcash.UseVisualStyleBackColor = true;
            this.rbcash.CheckedChanged += new System.EventHandler(this.rbcash_CheckedChanged);
            // 
            // rbCredit
            // 
            this.rbCredit.AutoSize = true;
            this.rbCredit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbCredit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCredit.Location = new System.Drawing.Point(72, 198);
            this.rbCredit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbCredit.Name = "rbCredit";
            this.rbCredit.Size = new System.Drawing.Size(62, 22);
            this.rbCredit.TabIndex = 4;
            this.rbCredit.TabStop = true;
            this.rbCredit.Text = "Credit";
            this.rbCredit.UseVisualStyleBackColor = true;
            this.rbCredit.CheckedChanged += new System.EventHandler(this.rbCredit_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.FloralWhite;
            this.label58.Location = new System.Drawing.Point(4, 3);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(191, 29);
            this.label58.TabIndex = 265;
            this.label58.Text = "PAYMENT MODE";
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Brown;
            this.button32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button32.BackgroundImage")));
            this.button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(385, 1);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(38, 36);
            this.button32.TabIndex = 348;
            this.button32.TabStop = false;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // frm_PaymentMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(425, 382);
            this.ControlBox = false;
            this.Controls.Add(this.button32);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.tbCash);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_PaymentMode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_PaymentMode_Load);
            this.tbCash.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbCash;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button btnCredit;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.RadioButton rbcash;
        private System.Windows.Forms.RadioButton rbCredit;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblSEQ;
        private System.Windows.Forms.Label lblInv;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblBal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAmountA;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button button32;
    }
}