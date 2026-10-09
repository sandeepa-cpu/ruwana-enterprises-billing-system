namespace Billing_Inventory_Management_System
{
    partial class frm_ReceiveMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ReceiveMode));
            this.btnHide = new System.Windows.Forms.Button();
            this.lblBal = new System.Windows.Forms.Label();
            this.lblInv = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblSEQ = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.lblLocID = new System.Windows.Forms.Label();
            this.lblCUSSUP = new System.Windows.Forms.ComboBox();
            this.lbl_SysLast = new System.Windows.Forms.DateTimePicker();
            this.lbl_SysDate = new System.Windows.Forms.DateTimePicker();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.btnCredit = new System.Windows.Forms.Button();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.rbcash = new System.Windows.Forms.RadioButton();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.tbCash = new System.Windows.Forms.TabControl();
            this.label58 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tabPage9.SuspendLayout();
            this.tbCash.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHide
            // 
            this.btnHide.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHide.BackgroundImage")));
            this.btnHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHide.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.Location = new System.Drawing.Point(435, 1);
            this.btnHide.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(32, 31);
            this.btnHide.TabIndex = 202;
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // lblBal
            // 
            this.lblBal.AutoSize = true;
            this.lblBal.Enabled = false;
            this.lblBal.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBal.Location = new System.Drawing.Point(382, 73);
            this.lblBal.Name = "lblBal";
            this.lblBal.Size = new System.Drawing.Size(13, 18);
            this.lblBal.TabIndex = 201;
            this.lblBal.Text = "-";
            this.lblBal.Visible = false;
            // 
            // lblInv
            // 
            this.lblInv.AutoSize = true;
            this.lblInv.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInv.ForeColor = System.Drawing.Color.Black;
            this.lblInv.Location = new System.Drawing.Point(197, 17);
            this.lblInv.Name = "lblInv";
            this.lblInv.Size = new System.Drawing.Size(22, 29);
            this.lblInv.TabIndex = 200;
            this.lblInv.Text = "-";
            this.lblInv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 22);
            this.label1.TabIndex = 203;
            this.label1.Text = "Invoice No";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crystalReportViewer1.Location = new System.Drawing.Point(4, 336);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(462, 422);
            this.crystalReportViewer1.TabIndex = 198;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 22);
            this.label2.TabIndex = 204;
            this.label2.Text = "Invoice Amount";
            // 
            // lblSEQ
            // 
            this.lblSEQ.AutoSize = true;
            this.lblSEQ.Enabled = false;
            this.lblSEQ.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEQ.Location = new System.Drawing.Point(382, 48);
            this.lblSEQ.Name = "lblSEQ";
            this.lblSEQ.Size = new System.Drawing.Size(13, 18);
            this.lblSEQ.TabIndex = 199;
            this.lblSEQ.Text = "-";
            this.lblSEQ.Visible = false;
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.White;
            this.tabPage9.Controls.Add(this.lblLocID);
            this.tabPage9.Controls.Add(this.lblCUSSUP);
            this.tabPage9.Controls.Add(this.lbl_SysLast);
            this.tabPage9.Controls.Add(this.lbl_SysDate);
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
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage9.Size = new System.Drawing.Size(454, 274);
            this.tabPage9.TabIndex = 0;
            this.tabPage9.Text = "                                                                                 " +
                "                                                                    ";
            // 
            // lblLocID
            // 
            this.lblLocID.AutoSize = true;
            this.lblLocID.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocID.ForeColor = System.Drawing.Color.Black;
            this.lblLocID.Location = new System.Drawing.Point(346, 17);
            this.lblLocID.Name = "lblLocID";
            this.lblLocID.Size = new System.Drawing.Size(22, 29);
            this.lblLocID.TabIndex = 263;
            this.lblLocID.Text = "-";
            this.lblLocID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCUSSUP
            // 
            this.lblCUSSUP.Enabled = false;
            this.lblCUSSUP.FormattingEnabled = true;
            this.lblCUSSUP.Location = new System.Drawing.Point(385, 8);
            this.lblCUSSUP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCUSSUP.Name = "lblCUSSUP";
            this.lblCUSSUP.Size = new System.Drawing.Size(46, 21);
            this.lblCUSSUP.TabIndex = 262;
            this.lblCUSSUP.TabStop = false;
            this.lblCUSSUP.Visible = false;
            // 
            // lbl_SysLast
            // 
            this.lbl_SysLast.CustomFormat = "yyyy-MM-dd";
            this.lbl_SysLast.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SysLast.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lbl_SysLast.Location = new System.Drawing.Point(464, 108);
            this.lbl_SysLast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_SysLast.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.lbl_SysLast.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.lbl_SysLast.Name = "lbl_SysLast";
            this.lbl_SysLast.Size = new System.Drawing.Size(108, 26);
            this.lbl_SysLast.TabIndex = 205;
            this.lbl_SysLast.Value = new System.DateTime(2023, 9, 15, 0, 0, 0, 0);
            // 
            // lbl_SysDate
            // 
            this.lbl_SysDate.CustomFormat = "yyyy-MM-dd";
            this.lbl_SysDate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SysDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lbl_SysDate.Location = new System.Drawing.Point(464, 163);
            this.lbl_SysDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_SysDate.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.lbl_SysDate.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.lbl_SysDate.Name = "lbl_SysDate";
            this.lbl_SysDate.Size = new System.Drawing.Size(108, 26);
            this.lbl_SysDate.TabIndex = 206;
            this.lbl_SysDate.Value = new System.DateTime(2023, 9, 15, 0, 0, 0, 0);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Black;
            this.lblAmount.Location = new System.Drawing.Point(197, 65);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(22, 29);
            this.lblAmount.TabIndex = 198;
            this.lblAmount.Text = "-";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCash
            // 
            this.txtCash.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.Location = new System.Drawing.Point(201, 113);
            this.txtCash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCash.Name = "txtCash";
            this.txtCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCash.Size = new System.Drawing.Size(202, 35);
            this.txtCash.TabIndex = 1;
            this.txtCash.Text = "0.00";
            this.txtCash.TextChanged += new System.EventHandler(this.txtCash_TextChanged);
            this.txtCash.Leave += new System.EventHandler(this.txtCash_Leave);
            this.txtCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCash_KeyPress);
            // 
            // btnCredit
            // 
            this.btnCredit.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCredit.Location = new System.Drawing.Point(201, 219);
            this.btnCredit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(202, 38);
            this.btnCredit.TabIndex = 5;
            this.btnCredit.Text = "OK >  Print Receipt";
            this.btnCredit.UseVisualStyleBackColor = true;
            this.btnCredit.Click += new System.EventHandler(this.btnCredit_Click);
            // 
            // txtCredit
            // 
            this.txtCredit.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredit.Location = new System.Drawing.Point(201, 163);
            this.txtCredit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCredit.Size = new System.Drawing.Size(202, 35);
            this.txtCredit.TabIndex = 2;
            this.txtCredit.Text = "0.00";
            this.txtCredit.Leave += new System.EventHandler(this.txtCredit_Leave);
            this.txtCredit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCredit_KeyPress);
            // 
            // rbcash
            // 
            this.rbcash.AutoSize = true;
            this.rbcash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbcash.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbcash.Location = new System.Drawing.Point(39, 120);
            this.rbcash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcash.Name = "rbcash";
            this.rbcash.Size = new System.Drawing.Size(61, 26);
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
            this.rbCredit.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCredit.Location = new System.Drawing.Point(39, 170);
            this.rbCredit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbCredit.Name = "rbCredit";
            this.rbCredit.Size = new System.Drawing.Size(73, 26);
            this.rbCredit.TabIndex = 4;
            this.rbCredit.TabStop = true;
            this.rbCredit.Text = "Credit";
            this.rbCredit.UseVisualStyleBackColor = true;
            this.rbCredit.CheckedChanged += new System.EventHandler(this.rbCredit_CheckedChanged);
            // 
            // tbCash
            // 
            this.tbCash.Controls.Add(this.tabPage9);
            this.tbCash.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCash.Location = new System.Drawing.Point(4, 33);
            this.tbCash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCash.Name = "tbCash";
            this.tbCash.SelectedIndex = 0;
            this.tbCash.Size = new System.Drawing.Size(462, 300);
            this.tbCash.TabIndex = 197;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Firebrick;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label58.Location = new System.Drawing.Point(7, 2);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(193, 29);
            this.label58.TabIndex = 265;
            this.label58.Text = "RECEIVED MODE";
            // 
            // frm_ReceiveMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(470, 368);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.tbCash);
            this.Controls.Add(this.btnHide);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ReceiveMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_ReceiveMode_Load);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tbCash.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Label lblBal;
        private System.Windows.Forms.Label lblInv;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSEQ;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Button btnCredit;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.RadioButton rbcash;
        private System.Windows.Forms.RadioButton rbCredit;
        private System.Windows.Forms.TabControl tbCash;
        private System.Windows.Forms.DateTimePicker lbl_SysLast;
        private System.Windows.Forms.DateTimePicker lbl_SysDate;
        private System.Windows.Forms.ComboBox lblCUSSUP;
        private System.Windows.Forms.Label label58;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label lblLocID;
    }
}