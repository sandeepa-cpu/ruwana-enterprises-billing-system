namespace Billing_Inventory_Management_System
{
    partial class frm_ReturnCustomers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ReturnCustomers));
            this.btn_Back = new System.Windows.Forms.Button();
            this.Grid_A = new System.Windows.Forms.DataGridView();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.cmbINVNO = new System.Windows.Forms.ComboBox();
            this.lbl_ProDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDesc = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPartNo = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblBal = new System.Windows.Forms.Label();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.lblReTOTPrice = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Qty = new System.Windows.Forms.TextBox();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbCus = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCus = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lblQty = new System.Windows.Forms.Label();
            this.lbl_TotCost = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblUnitPriceA = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSEQNO = new System.Windows.Forms.Label();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_Save1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblRSEQNO = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Back
            // 
            this.btn_Back.Enabled = false;
            this.btn_Back.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.Location = new System.Drawing.Point(18, 899);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(86, 32);
            this.btn_Back.TabIndex = 160;
            this.btn_Back.Text = "Quit";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Visible = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
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
            this.Grid_A.Location = new System.Drawing.Point(-2, 842);
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
            this.Grid_A.Size = new System.Drawing.Size(533, 39);
            this.Grid_A.TabIndex = 163;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Enabled = false;
            this.btn_Delete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(143, 899);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(45, 32);
            this.btn_Delete.TabIndex = 162;
            this.btn_Delete.Text = "Remove Entry";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Visible = false;
            // 
            // btn_Update
            // 
            this.btn_Update.Enabled = false;
            this.btn_Update.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(100, 899);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(44, 32);
            this.btn_Update.TabIndex = 161;
            this.btn_Update.Text = "Save Changes";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Visible = false;
            // 
            // cmbINVNO
            // 
            this.cmbINVNO.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmbINVNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbINVNO.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbINVNO.ForeColor = System.Drawing.Color.Blue;
            this.cmbINVNO.FormattingEnabled = true;
            this.cmbINVNO.Location = new System.Drawing.Point(144, 40);
            this.cmbINVNO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbINVNO.Name = "cmbINVNO";
            this.cmbINVNO.Size = new System.Drawing.Size(147, 26);
            this.cmbINVNO.TabIndex = 164;
            this.cmbINVNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbINVNO_KeyPress);
            this.cmbINVNO.SelectedValueChanged += new System.EventHandler(this.cmbInvNo_SelectedValueChanged);
            // 
            // lbl_ProDate
            // 
            this.lbl_ProDate.AutoSize = true;
            this.lbl_ProDate.BackColor = System.Drawing.Color.White;
            this.lbl_ProDate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProDate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_ProDate.Location = new System.Drawing.Point(511, 50);
            this.lbl_ProDate.MaximumSize = new System.Drawing.Size(120, 28);
            this.lbl_ProDate.Name = "lbl_ProDate";
            this.lbl_ProDate.Size = new System.Drawing.Size(13, 18);
            this.lbl_ProDate.TabIndex = 180;
            this.lbl_ProDate.Text = "-";
            this.lbl_ProDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(354, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 18);
            this.label3.TabIndex = 179;
            this.label3.Text = "Current Proccesing Date";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(3, 155);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(636, 107);
            this.tabControl2.TabIndex = 182;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.cmbDesc);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.cmbPartNo);
            this.tabPage3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(628, 76);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Sort Part No / Description                                                       " +
                "                                                                 ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 44);
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
            this.cmbDesc.Location = new System.Drawing.Point(144, 41);
            this.cmbDesc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDesc.Name = "cmbDesc";
            this.cmbDesc.Size = new System.Drawing.Size(371, 26);
            this.cmbDesc.TabIndex = 3;
            this.cmbDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDesc_KeyPress);
            this.cmbDesc.SelectedValueChanged += new System.EventHandler(this.cmbDesc_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 18);
            this.label6.TabIndex = 128;
            this.label6.Text = "Part No";
            // 
            // cmbPartNo
            // 
            this.cmbPartNo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmbPartNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPartNo.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPartNo.ForeColor = System.Drawing.Color.Blue;
            this.cmbPartNo.FormattingEnabled = true;
            this.cmbPartNo.Location = new System.Drawing.Point(144, 8);
            this.cmbPartNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPartNo.Name = "cmbPartNo";
            this.cmbPartNo.Size = new System.Drawing.Size(191, 26);
            this.cmbPartNo.TabIndex = 2;
            this.cmbPartNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPartNo_KeyPress);
            this.cmbPartNo.SelectedValueChanged += new System.EventHandler(this.cmbPartNo_SelectedValueChanged);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(147, 70);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(473, 72);
            this.txtRemarks.TabIndex = 6;
            this.txtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarks_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 18);
            this.label10.TabIndex = 135;
            this.label10.Text = "Serial No";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 18);
            this.label12.TabIndex = 136;
            this.label12.Text = "Remarks";
            // 
            // lblBal
            // 
            this.lblBal.AutoSize = true;
            this.lblBal.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBal.ForeColor = System.Drawing.Color.Red;
            this.lblBal.Location = new System.Drawing.Point(189, 11);
            this.lblBal.Name = "lblBal";
            this.lblBal.Size = new System.Drawing.Size(19, 22);
            this.lblBal.TabIndex = 123;
            this.lblBal.Text = "0";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage2);
            this.tabControl3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl3.Location = new System.Drawing.Point(357, 265);
            this.tabControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(282, 120);
            this.tabControl3.TabIndex = 181;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblBal);
            this.tabPage2.Controls.Add(this.label32);
            this.tabPage2.Controls.Add(this.lblReTOTPrice);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(274, 89);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "                                                                   ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Blue;
            this.label32.Location = new System.Drawing.Point(19, 52);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(68, 18);
            this.label32.TabIndex = 138;
            this.label32.Text = "Total Cost";
            // 
            // lblReTOTPrice
            // 
            this.lblReTOTPrice.AutoSize = true;
            this.lblReTOTPrice.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReTOTPrice.ForeColor = System.Drawing.Color.Blue;
            this.lblReTOTPrice.Location = new System.Drawing.Point(151, 48);
            this.lblReTOTPrice.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblReTOTPrice.Name = "lblReTOTPrice";
            this.lblReTOTPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReTOTPrice.Size = new System.Drawing.Size(100, 22);
            this.lblReTOTPrice.TabIndex = 1;
            this.lblReTOTPrice.Text = "0.00";
            this.lblReTOTPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReTOTPrice.TextChanged += new System.EventHandler(this.lblReTOTPrice_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(19, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 18);
            this.label7.TabIndex = 125;
            this.label7.Text = "Balance Qty";
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
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Size = new System.Drawing.Size(628, 149);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Return Quantity Info                                                             " +
                "                                                                               ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 18);
            this.label4.TabIndex = 119;
            this.label4.Text = "Returned Quantity";
            // 
            // txt_Qty
            // 
            this.txt_Qty.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Qty.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Qty.Location = new System.Drawing.Point(147, 7);
            this.txt_Qty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.Size = new System.Drawing.Size(96, 23);
            this.txt_Qty.TabIndex = 4;
            this.txt_Qty.Leave += new System.EventHandler(this.txt_Qty_Leave);
            this.txt_Qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Qty_KeyPress);
            // 
            // txtSN
            // 
            this.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSN.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSN.Location = new System.Drawing.Point(147, 38);
            this.txtSN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(255, 23);
            this.txtSN.TabIndex = 5;
            this.txtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSN_KeyPress);
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage4);
            this.tabControl4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl4.Location = new System.Drawing.Point(3, 444);
            this.tabControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(636, 180);
            this.tabControl4.TabIndex = 186;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbCus);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblCus);
            this.tabPage1.Controls.Add(this.cmbINVNO);
            this.tabPage1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(628, 75);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sort Customer / Invoice No                                                       " +
                "                                                                    ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbCus
            // 
            this.cmbCus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmbCus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCus.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCus.ForeColor = System.Drawing.Color.Blue;
            this.cmbCus.FormattingEnabled = true;
            this.cmbCus.Location = new System.Drawing.Point(144, 7);
            this.cmbCus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCus.Name = "cmbCus";
            this.cmbCus.Size = new System.Drawing.Size(476, 26);
            this.cmbCus.TabIndex = 187;
            this.cmbCus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCus_KeyPress);
            this.cmbCus.SelectedValueChanged += new System.EventHandler(this.lblName_SelectedValueChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(25, 43);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 18);
            this.label24.TabIndex = 105;
            this.label24.Text = "Invoice No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 18);
            this.label5.TabIndex = 175;
            this.label5.Text = "Customer Name";
            // 
            // lblCus
            // 
            this.lblCus.AutoSize = true;
            this.lblCus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCus.Location = new System.Drawing.Point(368, 50);
            this.lblCus.Name = "lblCus";
            this.lblCus.Size = new System.Drawing.Size(15, 13);
            this.lblCus.TabIndex = 176;
            this.lblCus.Text = "0";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 46);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(636, 106);
            this.tabControl1.TabIndex = 183;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.ForeColor = System.Drawing.Color.Red;
            this.lblQty.Location = new System.Drawing.Point(165, 14);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(19, 22);
            this.lblQty.TabIndex = 173;
            this.lblQty.Text = "0";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbl_TotCost
            // 
            this.lbl_TotCost.AutoSize = true;
            this.lbl_TotCost.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotCost.ForeColor = System.Drawing.Color.Red;
            this.lbl_TotCost.Location = new System.Drawing.Point(165, 103);
            this.lbl_TotCost.MinimumSize = new System.Drawing.Size(100, 0);
            this.lbl_TotCost.Name = "lbl_TotCost";
            this.lbl_TotCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_TotCost.Size = new System.Drawing.Size(100, 22);
            this.lbl_TotCost.TabIndex = 168;
            this.lbl_TotCost.Text = "0.00";
            this.lbl_TotCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(19, 17);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(93, 18);
            this.label31.TabIndex = 169;
            this.label31.Text = "Soled Quantity";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(19, 106);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 18);
            this.label19.TabIndex = 170;
            this.label19.Text = "Soled Price";
            // 
            // lblUnitPriceA
            // 
            this.lblUnitPriceA.AutoSize = true;
            this.lblUnitPriceA.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPriceA.ForeColor = System.Drawing.Color.Red;
            this.lblUnitPriceA.Location = new System.Drawing.Point(165, 59);
            this.lblUnitPriceA.Name = "lblUnitPriceA";
            this.lblUnitPriceA.Size = new System.Drawing.Size(19, 22);
            this.lblUnitPriceA.TabIndex = 172;
            this.lblUnitPriceA.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(454, 412);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 18);
            this.label8.TabIndex = 177;
            this.label8.Text = "Seq No";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 18);
            this.label9.TabIndex = 178;
            this.label9.Text = "Sold Unit Price";
            // 
            // lblSEQNO
            // 
            this.lblSEQNO.AutoSize = true;
            this.lblSEQNO.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEQNO.Location = new System.Drawing.Point(536, 412);
            this.lblSEQNO.Name = "lblSEQNO";
            this.lblSEQNO.Size = new System.Drawing.Size(15, 18);
            this.lblSEQNO.TabIndex = 174;
            this.lblSEQNO.Text = "0";
            // 
            // btn_Quit
            // 
            this.btn_Quit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(537, 627);
            this.btn_Quit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(104, 46);
            this.btn_Quit.TabIndex = 167;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_Save1
            // 
            this.btn_Save1.Enabled = false;
            this.btn_Save1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save1.Location = new System.Drawing.Point(313, 627);
            this.btn_Save1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Save1.Name = "btn_Save1";
            this.btn_Save1.Size = new System.Drawing.Size(222, 46);
            this.btn_Save1.TabIndex = 166;
            this.btn_Save1.Text = "Returned by Customer";
            this.btn_Save1.UseVisualStyleBackColor = true;
            this.btn_Save1.Click += new System.EventHandler(this.btn_Save1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblRSEQNO
            // 
            this.lblRSEQNO.AutoSize = true;
            this.lblRSEQNO.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRSEQNO.Location = new System.Drawing.Point(593, 412);
            this.lblRSEQNO.Name = "lblRSEQNO";
            this.lblRSEQNO.Size = new System.Drawing.Size(15, 18);
            this.lblRSEQNO.TabIndex = 187;
            this.lblRSEQNO.Text = "0";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.FloralWhite;
            this.label58.Location = new System.Drawing.Point(3, 9);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(445, 29);
            this.label58.TabIndex = 265;
            this.label58.Text = "RETURN TO INVENTORY BY CUSTOMER";
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage5);
            this.tabControl5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl5.Location = new System.Drawing.Point(3, 265);
            this.tabControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(350, 176);
            this.tabControl5.TabIndex = 266;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label31);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.lblUnitPriceA);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.lbl_TotCost);
            this.tabPage5.Controls.Add(this.lblQty);
            this.tabPage5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage5.Size = new System.Drawing.Size(342, 145);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "                                                                                 " +
                "                             ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(614, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 28);
            this.button1.TabIndex = 268;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_ReturnCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(643, 675);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl5);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.lblRSEQNO);
            this.Controls.Add(this.lbl_ProDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.tabControl4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSEQNO);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Save1);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.Grid_A);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Update);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ReturnCustomers";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_ReturnCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_A)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabControl4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.DataGridView Grid_A;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.ComboBox cmbINVNO;
        private System.Windows.Forms.Label lbl_ProDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPartNo;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblBal;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblReTOTPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Qty;
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lbl_TotCost;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblUnitPriceA;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSEQNO;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_Save1;
        private System.Windows.Forms.ComboBox cmbCus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblRSEQNO;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button1;
    }
}