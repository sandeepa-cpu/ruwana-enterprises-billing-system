namespace Billing_Inventory_Management_System
{
    partial class frm_ReturnSuppliers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ReturnSuppliers));
            this.txt_Qty = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbINVNO = new System.Windows.Forms.ComboBox();
            this.lbl_TotCost = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblUnitPriceA = new System.Windows.Forms.Label();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_Save1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSEQNO = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSup = new System.Windows.Forms.Label();
            this.lblBal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbPartNo = new System.Windows.Forms.ComboBox();
            this.lbl_ProDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDesc = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbSup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUnitPriceD = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblReTOTPrice = new System.Windows.Forms.Label();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Qty
            // 
            this.txt_Qty.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Qty.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Qty.Location = new System.Drawing.Point(147, 6);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.Size = new System.Drawing.Size(96, 23);
            this.txt_Qty.TabIndex = 4;
            this.txt_Qty.Leave += new System.EventHandler(this.txt_Qty_Leave);
            this.txt_Qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Qty_KeyPress);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(25, 48);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(109, 18);
            this.label31.TabIndex = 103;
            this.label31.Text = "Ordered Quantity";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(25, 149);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 18);
            this.label19.TabIndex = 104;
            this.label19.Text = "Purchased Price";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(25, 39);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 18);
            this.label24.TabIndex = 105;
            this.label24.Text = "Invoice No";
            // 
            // cmbINVNO
            // 
            this.cmbINVNO.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmbINVNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbINVNO.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbINVNO.FormattingEnabled = true;
            this.cmbINVNO.Location = new System.Drawing.Point(144, 36);
            this.cmbINVNO.Name = "cmbINVNO";
            this.cmbINVNO.Size = new System.Drawing.Size(191, 26);
            this.cmbINVNO.TabIndex = 1;
            this.cmbINVNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbINVNO_KeyPress);
            this.cmbINVNO.SelectedValueChanged += new System.EventHandler(this.cmbINVNO_SelectedValueChanged);
            // 
            // lbl_TotCost
            // 
            this.lbl_TotCost.AutoSize = true;
            this.lbl_TotCost.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotCost.ForeColor = System.Drawing.Color.Red;
            this.lbl_TotCost.Location = new System.Drawing.Point(171, 146);
            this.lbl_TotCost.MinimumSize = new System.Drawing.Size(100, 0);
            this.lbl_TotCost.Name = "lbl_TotCost";
            this.lbl_TotCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_TotCost.Size = new System.Drawing.Size(100, 22);
            this.lbl_TotCost.TabIndex = 101;
            this.lbl_TotCost.Text = "0.00";
            this.lbl_TotCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.ForeColor = System.Drawing.Color.Red;
            this.lblQty.Location = new System.Drawing.Point(170, 45);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(19, 22);
            this.lblQty.TabIndex = 113;
            this.lblQty.Text = "0";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblUnitPriceA
            // 
            this.lblUnitPriceA.AutoSize = true;
            this.lblUnitPriceA.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPriceA.ForeColor = System.Drawing.Color.Red;
            this.lblUnitPriceA.Location = new System.Drawing.Point(170, 78);
            this.lblUnitPriceA.Name = "lblUnitPriceA";
            this.lblUnitPriceA.Size = new System.Drawing.Size(19, 22);
            this.lblUnitPriceA.TabIndex = 112;
            this.lblUnitPriceA.Text = "0";
            // 
            // btn_Quit
            // 
            this.btn_Quit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(480, 617);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(128, 38);
            this.btn_Quit.TabIndex = 8;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_Save1
            // 
            this.btn_Save1.Enabled = false;
            this.btn_Save1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save1.Location = new System.Drawing.Point(278, 617);
            this.btn_Save1.Name = "btn_Save1";
            this.btn_Save1.Size = new System.Drawing.Size(201, 38);
            this.btn_Save1.TabIndex = 7;
            this.btn_Save1.Text = "Return to Supplier";
            this.btn_Save1.UseVisualStyleBackColor = true;
            this.btn_Save1.Click += new System.EventHandler(this.btn_Save1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 18);
            this.label4.TabIndex = 119;
            this.label4.Text = "Returned Quantity";
            // 
            // lblSEQNO
            // 
            this.lblSEQNO.AutoSize = true;
            this.lblSEQNO.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEQNO.Location = new System.Drawing.Point(119, 179);
            this.lblSEQNO.Name = "lblSEQNO";
            this.lblSEQNO.Size = new System.Drawing.Size(15, 13);
            this.lblSEQNO.TabIndex = 120;
            this.lblSEQNO.Text = "0";
            this.lblSEQNO.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 18);
            this.label5.TabIndex = 121;
            this.label5.Text = "Supplier Name";
            this.label5.Visible = false;
            // 
            // lblSup
            // 
            this.lblSup.AutoSize = true;
            this.lblSup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSup.Location = new System.Drawing.Point(169, 179);
            this.lblSup.Name = "lblSup";
            this.lblSup.Size = new System.Drawing.Size(15, 13);
            this.lblSup.TabIndex = 122;
            this.lblSup.Text = "0";
            this.lblSup.Visible = false;
            // 
            // lblBal
            // 
            this.lblBal.AutoSize = true;
            this.lblBal.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBal.ForeColor = System.Drawing.Color.Red;
            this.lblBal.Location = new System.Drawing.Point(171, 38);
            this.lblBal.Name = "lblBal";
            this.lblBal.Size = new System.Drawing.Size(19, 22);
            this.lblBal.TabIndex = 123;
            this.lblBal.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(27, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 18);
            this.label7.TabIndex = 125;
            this.label7.Text = "Balance Qty";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 126;
            this.label8.Text = "Seq No";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 18);
            this.label9.TabIndex = 127;
            this.label9.Text = "Purchased Unit Price";
            // 
            // txtSN
            // 
            this.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSN.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSN.Location = new System.Drawing.Point(147, 34);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(255, 23);
            this.txtSN.TabIndex = 5;
            this.txtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSN_KeyPress);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(147, 63);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(444, 53);
            this.txtRemarks.TabIndex = 6;
            this.txtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarks_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 18);
            this.label10.TabIndex = 135;
            this.label10.Text = "Serial No";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(25, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 18);
            this.label12.TabIndex = 136;
            this.label12.Text = "Remarks";
            // 
            // cmbPartNo
            // 
            this.cmbPartNo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmbPartNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPartNo.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPartNo.FormattingEnabled = true;
            this.cmbPartNo.Location = new System.Drawing.Point(144, 6);
            this.cmbPartNo.Name = "cmbPartNo";
            this.cmbPartNo.Size = new System.Drawing.Size(260, 26);
            this.cmbPartNo.TabIndex = 2;
            this.cmbPartNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPartNo_KeyPress);
            this.cmbPartNo.SelectedValueChanged += new System.EventHandler(this.cmbPartNo_SelectedValueChanged);
            // 
            // lbl_ProDate
            // 
            this.lbl_ProDate.AutoSize = true;
            this.lbl_ProDate.BackColor = System.Drawing.Color.White;
            this.lbl_ProDate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProDate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_ProDate.Location = new System.Drawing.Point(479, 49);
            this.lbl_ProDate.MaximumSize = new System.Drawing.Size(120, 20);
            this.lbl_ProDate.Name = "lbl_ProDate";
            this.lbl_ProDate.Size = new System.Drawing.Size(13, 18);
            this.lbl_ProDate.TabIndex = 139;
            this.lbl_ProDate.Text = "-";
            this.lbl_ProDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_ProDate.Click += new System.EventHandler(this.lbl_ProDate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(330, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 18);
            this.label3.TabIndex = 138;
            this.label3.Text = "Current Proccesing Date";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(2, 145);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(605, 99);
            this.tabControl2.TabIndex = 140;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.cmbDesc);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.cmbPartNo);
            this.tabPage3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(597, 68);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Sort Part No / Description                                                       " +
                "                                                                          ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 130;
            this.label2.Text = "Description";
            // 
            // cmbDesc
            // 
            this.cmbDesc.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmbDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDesc.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDesc.ForeColor = System.Drawing.Color.Blue;
            this.cmbDesc.FormattingEnabled = true;
            this.cmbDesc.Location = new System.Drawing.Point(144, 36);
            this.cmbDesc.Name = "cmbDesc";
            this.cmbDesc.Size = new System.Drawing.Size(447, 26);
            this.cmbDesc.TabIndex = 3;
            this.cmbDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDesc_KeyPress);
            this.cmbDesc.SelectedValueChanged += new System.EventHandler(this.cmbDesc_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 18);
            this.label6.TabIndex = 128;
            this.label6.Text = "Part No";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(2, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(605, 100);
            this.tabControl1.TabIndex = 141;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.cmbSup);
            this.tabPage1.Controls.Add(this.cmbINVNO);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 69);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sort Invoice No                                                                  " +
                "                                                                            ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(25, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 18);
            this.label11.TabIndex = 107;
            this.label11.Text = "Supplier";
            // 
            // cmbSup
            // 
            this.cmbSup.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmbSup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSup.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSup.FormattingEnabled = true;
            this.cmbSup.Location = new System.Drawing.Point(144, 6);
            this.cmbSup.Name = "cmbSup";
            this.cmbSup.Size = new System.Drawing.Size(447, 26);
            this.cmbSup.TabIndex = 106;
            this.cmbSup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSup_KeyPress);
            this.cmbSup.SelectedValueChanged += new System.EventHandler(this.cmbSup_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 143;
            this.label1.Text = "Actual Unit Price";
            // 
            // lblUnitPriceD
            // 
            this.lblUnitPriceD.AutoSize = true;
            this.lblUnitPriceD.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPriceD.ForeColor = System.Drawing.Color.Red;
            this.lblUnitPriceD.Location = new System.Drawing.Point(170, 112);
            this.lblUnitPriceD.Name = "lblUnitPriceD";
            this.lblUnitPriceD.Size = new System.Drawing.Size(19, 22);
            this.lblUnitPriceD.TabIndex = 142;
            this.lblUnitPriceD.Text = "0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Blue;
            this.label32.Location = new System.Drawing.Point(27, 99);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(68, 18);
            this.label32.TabIndex = 138;
            this.label32.Text = "Total Cost";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage2);
            this.tabControl3.Location = new System.Drawing.Point(347, 246);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(260, 214);
            this.tabControl3.TabIndex = 139;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblBal);
            this.tabPage2.Controls.Add(this.label32);
            this.tabPage2.Controls.Add(this.lblReTOTPrice);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(252, 183);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "                                                                                 " +
                "         ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblReTOTPrice
            // 
            this.lblReTOTPrice.AutoSize = true;
            this.lblReTOTPrice.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReTOTPrice.ForeColor = System.Drawing.Color.Blue;
            this.lblReTOTPrice.Location = new System.Drawing.Point(131, 96);
            this.lblReTOTPrice.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblReTOTPrice.Name = "lblReTOTPrice";
            this.lblReTOTPrice.Size = new System.Drawing.Size(100, 22);
            this.lblReTOTPrice.TabIndex = 1;
            this.lblReTOTPrice.Text = "0.00";
            this.lblReTOTPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReTOTPrice.TextChanged += new System.EventHandler(this.lblReTOTPrice_TextChanged);
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage4);
            this.tabControl4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl4.Location = new System.Drawing.Point(2, 463);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(605, 152);
            this.tabControl4.TabIndex = 144;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.txt_Qty);
            this.tabPage4.Controls.Add(this.txtSN);
            this.tabPage4.Controls.Add(this.txtRemarks);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(597, 121);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Return Quantity Info                                                             " +
                "                                                                    ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(170, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(19, 22);
            this.lblName.TabIndex = 106;
            this.lblName.Text = "0";
            this.lblName.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = false;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.FloralWhite;
            this.label58.Location = new System.Drawing.Point(3, 5);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(267, 29);
            this.label58.TabIndex = 265;
            this.label58.Text = "RETURN TO SUPPLIERS";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(226, 62);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "                                                      ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(123, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 18);
            this.label13.TabIndex = 123;
            this.label13.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(6, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 18);
            this.label14.TabIndex = 138;
            this.label14.Text = "Total Cost";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(105, 29);
            this.label15.MinimumSize = new System.Drawing.Size(100, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 18);
            this.label15.TabIndex = 1;
            this.label15.Text = "0.00";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 18);
            this.label16.TabIndex = 125;
            this.label16.Text = "Balance Qty";
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage6);
            this.tabControl5.Location = new System.Drawing.Point(2, 246);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(342, 214);
            this.tabControl5.TabIndex = 266;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label5);
            this.tabPage6.Controls.Add(this.lbl_TotCost);
            this.tabPage6.Controls.Add(this.label19);
            this.tabPage6.Controls.Add(this.label31);
            this.tabPage6.Controls.Add(this.label1);
            this.tabPage6.Controls.Add(this.lblName);
            this.tabPage6.Controls.Add(this.lblUnitPriceD);
            this.tabPage6.Controls.Add(this.lblUnitPriceA);
            this.tabPage6.Controls.Add(this.lblQty);
            this.tabPage6.Controls.Add(this.lblSEQNO);
            this.tabPage6.Controls.Add(this.lblSup);
            this.tabPage6.Controls.Add(this.label8);
            this.tabPage6.Controls.Add(this.label9);
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(334, 183);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "                                                                                 " +
                "                                                                              ";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(581, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 28);
            this.button1.TabIndex = 268;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_ReturnSuppliers
            // 
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(610, 656);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_ProDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl5);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.tabControl4);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Save1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ReturnSuppliers";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_ReturnSuppliers_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SS);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl4.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabControl5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Qty;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbINVNO;
        private System.Windows.Forms.Label lbl_TotCost;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblUnitPriceA;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_Save1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSEQNO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSup;
        private System.Windows.Forms.Label lblBal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbPartNo;
        private System.Windows.Forms.Label lbl_ProDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUnitPriceD;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblReTOTPrice;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cmbSup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button button1;
    }
}