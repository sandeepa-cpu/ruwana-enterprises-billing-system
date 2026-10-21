using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;


namespace Billing_Inventory_Management_System
{
    public partial class frm_JobCreation : Form
    {
        public frm_JobCreation()
        {
            InitializeComponent();
        }

        decimal CALQTY;
        decimal CALVAL;
        decimal CALUNIT;
        decimal PURCHASE = 0;
        decimal DISC = 0;
        decimal TRANS = 0;
        decimal LOAD = 0;
        decimal OTHER = 0;
        decimal TOT = 0;
        decimal TOT_PURCHASE = 0;
        decimal TOTQTY = 0;
        decimal TOTPRICE = 0;
        decimal TOTAMOUNT = 0;

        string A = "";
        private SqlConnection _Conn;
        int CUS_ID, SEQ = 0;
        private string customerKey = "";
        private Label operatorLabel;
        string APRVD;
        int SEQNOD, SEQNO;
        decimal REMOVETOT = 0;
        private string strCriteria = "";
        private string strReportName = "";
        public String VVehicleNO;
        private bool loadingJob;
        private bool fillingCatalog;
        private bool blankAdvanceOnPrint;
        private Button btnPayFull;
        private Button btnPayHalf;
        private Button btnPayClear;
        private Button btnAddCustomer;
        private Label lblCustomerContact;
        private Label lblStockHint;
        private decimal availableStock;
        private bool stockKnown;

        private const string MaterialGroup = "Materials";
        private const string MaterialMake = "Catalog";
        private bool resolvingCustomer;
        private bool draftReady;
        private bool draftDirty;
        private bool draftSaved;
        private System.Windows.Forms.Timer draftTimer;
        Bitmap bitmA;
        String UserName;

        decimal SEQ_NO;
        string CATEGORY;
        string MAKE;
        string MODEL;
        decimal QTY;
        decimal BAL_QTY;
        string S_NO;

        int RSEQ;
        string INVNOD;
        decimal QTYD, AA = 0;
        //TOTAL = Convert.ToDecimal(dreader["TOT"].ToString().Trim());
        decimal TOT_ISSUE, ISSUE_P, TOTAL = 0;
        decimal ENDCAL = 0;
        decimal TOTCALQTY;

        public static string InvNo = "";
        public static string InvAmount = "";
        public static string SysDate = "";
        public static int LocID;

        private void PRO_DATE()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PRO_DATE FROM PRO_DATE";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblDate.Text = dreader["PRO_DATE"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void LoadParts()
        {
            cmbPartNO.Items.Clear();
            cmbPartNO.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO FROM MASTER ORDER BY PARTNO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPartNO.Items.Add(dreader["PARTNO"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void frm_JobCreation_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            this.Shown += FitJobCard;
            FormActions.Standardize(this);
            btnPay.Enabled = false;
            button31.Enabled = false;

            try
            {
                if (!string.IsNullOrEmpty(VVehicleNO))
                {
                    txtNo.Text = VVehicleNO;
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation", ex);
            }

            FindEmps();
            PRO_DATE();
            ApplyToday();
            //FindTypes();
            //InsuranceCompany();
            txtNo.Focus();
            timer1.Enabled = true;
            LoadParts();
            cmbPartNO.Focus();
            LoadCats();
            SeedMaterialCatalog();
            FillMaterialCategories();
            button43.Click += AddPrintCategory;
            button44.Click += AddPrintItem;
            LoadCustomers();
            AssignNextJobNo();
            txtQty.TextChanged += RefreshJobCost;
            txtSPAMNT.TextChanged += RefreshJobCost;
            txtAdvance.TextChanged += RefreshJobCost;
            StylePaymentArea();
            AddPaymentShortcuts();
            AddCustomerTools();
            AddStockHint();
            SetCashierTabOrder();
            RefreshBalance();
        }

        private void AddCustomerTools()
        {
            btnAddCustomer = new Button();
            btnAddCustomer.Text = "";
            btnAddCustomer.TabStop = false;
            btnAddCustomer.Size = new Size(42, 36);
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.FlatAppearance.BorderSize = 0;
            btnAddCustomer.BackColor = Color.White;
            btnAddCustomer.UseVisualStyleBackColor = false;
            btnAddCustomer.BackgroundImage = button43.BackgroundImage;
            btnAddCustomer.BackgroundImageLayout = ImageLayout.Zoom;
            btnAddCustomer.Click += AddCustomerQuick;
            lblCusName.Parent.Controls.Add(btnAddCustomer);

            lblCustomerContact = new Label();
            lblCustomerContact.AutoSize = false;
            lblCustomerContact.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblCustomerContact.ForeColor = UiTheme.Muted;
            lblCustomerContact.Text = "";
            lblCusName.Parent.Controls.Add(lblCustomerContact);
            PlaceCustomerTools();
        }

        private void PlaceCustomerTools()
        {
            if (btnAddCustomer == null)
            {
                return;
            }
            lblCusName.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            if (jobSideActions != null && jobSideActions.Parent == lblCusName.Parent)
            {
                int room = jobSideActions.Left - lblCusName.Left - 58;
                if (room > 280 && lblCusName.Width > room)
                {
                    lblCusName.Width = room;
                }
            }
            btnAddCustomer.Location = new Point(lblCusName.Right + 8, lblCusName.Top);
            btnAddCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnAddCustomer.BringToFront();
            lblCustomerContact.Visible = true;
            lblCustomerContact.ForeColor = Color.DarkSlateBlue;
            lblCustomerContact.Location = new Point(lblCusName.Left, lblCusName.Bottom + 4);
            lblCustomerContact.Size = new Size(Math.Max(280, lblCusName.Width), 24);
            lblCustomerContact.TextAlign = ContentAlignment.MiddleLeft;
            lblCustomerContact.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblCustomerContact.BringToFront();
        }

        private void AddCustomerQuick(object sender, EventArgs e)
        {
            Form dialog = new Form();
            dialog.Text = "New Customer";
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.ClientSize = new Size(440, 230);
            dialog.MaximizeBox = false;
            dialog.MinimizeBox = false;
            dialog.Font = UiTheme.Font;

            TextBox title = AddCustomerField(dialog, "Title", 16);
            TextBox name = AddCustomerField(dialog, "Customer Name", 52);
            TextBox address = AddCustomerField(dialog, "Address", 88);
            TextBox mobile = AddCustomerField(dialog, "Mobile No", 124);

            Button save = new Button();
            save.Text = "Save";
            save.Size = new Size(90, 32);
            save.Location = new Point(230, 180);
            save.DialogResult = DialogResult.OK;
            UiTheme.StylePrimary(save);
            Button cancel = new Button();
            cancel.Text = "Cancel";
            cancel.Size = new Size(90, 32);
            cancel.Location = new Point(330, 180);
            cancel.DialogResult = DialogResult.Cancel;
            UiTheme.StyleSecondary(cancel);
            dialog.Controls.Add(save);
            dialog.Controls.Add(cancel);
            dialog.AcceptButton = save;
            dialog.CancelButton = cancel;

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                dialog.Dispose();
                return;
            }
            string customerName = name.Text.Trim();
            string customerTitle = title.Text.Trim();
            string customerAddress = address.Text.Trim();
            string customerMobile = mobile.Text.Trim();
            dialog.Dispose();
            if (customerName.Length == 0)
            {
                MessageBox.Show("Enter the customer name.", "Customer");
                return;
            }
            SaveQuickCustomer(customerTitle, customerName, customerAddress, customerMobile);
        }

        private TextBox AddCustomerField(Form dialog, string caption, int top)
        {
            Label label = new Label();
            label.Text = caption;
            label.AutoSize = true;
            label.Location = new Point(16, top + 4);
            TextBox box = new TextBox();
            box.Location = new Point(140, top);
            box.Width = 280;
            dialog.Controls.Add(label);
            dialog.Controls.Add(box);
            return box;
        }

        private void SaveQuickCustomer(string title, string name, string address, string mobile)
        {
            string fileNo = "Q" + DateTime.Now.ToString("yyMMddHHmmss");
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                conn = obyConn.Connect();
                SqlCommand cmd = new SqlCommand("INSERT INTO CUSTOMER_INFO (TITLE, NAME, ADDRESS, RESIDENT_NO, MOBILE_NO, FILE_NO, USER_ACTION) VALUES (@title, @name, @address, @resident, @mobile, @file, @action)", conn);
                cmd.Parameters.Add("@title", SqlDbType.VarChar, 50).Value = title;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 200).Value = name;
                cmd.Parameters.Add("@address", SqlDbType.VarChar, 300).Value = address;
                cmd.Parameters.Add("@resident", SqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar, 50).Value = mobile;
                cmd.Parameters.Add("@file", SqlDbType.VarChar, 50).Value = fileNo;
                cmd.Parameters.Add("@action", SqlDbType.VarChar, 10).Value = "1";
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT SEQ_NO FROM CUSTOMER_INFO WHERE FILE_NO = @file";
                cmd.Parameters.Add("@file", SqlDbType.VarChar, 50).Value = fileNo;
                object seqValue = cmd.ExecuteScalar();
                string seq = seqValue == null ? "" : seqValue.ToString();
                LoadCustomers();
                lblCusName.Text = name;
                lblSEQ.Text = seq;
                customerKey = seq;
                if (seq.Length > 0)
                {
                    ShowUnpaidCredit(seq);
                    ShowCustomerContact(seq);
                }
                AuditLog.Write("EDIT", "frm_JobCreation", name);
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.SaveQuickCustomer", ex);
                MessageBox.Show(ex.Message, "Customer");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void ShowCustomerContact(string seq)
        {
            if (lblCustomerContact == null)
            {
                return;
            }
            lblCustomerContact.Text = "";
            if (seq == null || seq.Trim().Length == 0)
            {
                return;
            }
            SqlConnection conn = null;
            SqlDataReader reader = null;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                conn = obyConn.Connect();
                SqlCommand cmd = new SqlCommand("SELECT ADDRESS, MOBILE_NO, RESIDENT_NO FROM CUSTOMER_INFO WHERE SEQ_NO = @seq", conn);
                cmd.Parameters.Add("@seq", SqlDbType.VarChar, 50).Value = seq;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string address = reader["ADDRESS"].ToString().Trim();
                    string mobile = reader["MOBILE_NO"].ToString().Trim();
                    string resident = reader["RESIDENT_NO"].ToString().Trim();
                    string phone = mobile;
                    if (resident.Length > 0)
                    {
                        if (phone.Length > 0)
                        {
                            phone = phone + " / " + resident;
                        }
                        else
                        {
                            phone = resident;
                        }
                    }
                    if (address.Length > 0 && phone.Length > 0)
                    {
                        lblCustomerContact.Text = address + "    " + phone;
                    }
                    else
                    {
                        lblCustomerContact.Text = address + phone;
                    }
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.ShowCustomerContact", ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void AddStockHint()
        {
            lblStockHint = new Label();
            lblStockHint.AutoSize = false;
            lblStockHint.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblStockHint.TextAlign = ContentAlignment.MiddleLeft;
            lblStockHint.Text = "";
            txtQty.Parent.Controls.Add(lblStockHint);
            PlaceStockHint();
            lblStockHint.BringToFront();
        }

        private void StylePaymentArea()
        {
            Font amountFont = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblTOTCOST.AutoSize = false;
            lblTOTCOST.Font = amountFont;
            lblTOTCOST.TextAlign = ContentAlignment.MiddleRight;
            lblTOTCOST.Size = new Size(150, 42);
            lblBalanceDue.AutoSize = false;
            lblBalanceDue.Font = amountFont;
            lblBalanceDue.TextAlign = ContentAlignment.MiddleRight;
            lblBalanceDue.Size = new Size(150, 42);
            txtAdvance.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            txtAdvance.Width = 160;
            UiTheme.StylePrimary(button2);
            PlacePayButton();
        }

        private Panel jobSideActions;

        private void LayoutJobCard()
        {
            LayoutSideActions();
            LayoutLeftRows();
            PlaceCustomerTools();
            LayoutActionBar();
            PlaceStockHint();
            LayoutPaymentStrip();
        }

        private void LayoutLeftRows()
        {
            int y = 172;
            int step = 44;
            SetFieldRow(label5, dt_Start, null, y, 184);
            y += step;
            SetFieldRow(label1, dt_End, null, y, 184);
            y += step;
            SetFieldRow(label75, cmbMethod, button1, y, 420);
            y += step;
            SetFieldRow(label74, cmbMedia, null, y, 420);
            y += step;
            SetFieldRow(label77, cmbCat, button43, y, 420);
            y += step;
            SetFieldRow(label4, cmbPartNO, button44, y, 420);
            y += step;
            SetFieldRow(label73, txtQty, null, y, 120);
            label73.BringToFront();
            lblUOM.AutoSize = true;
            lblUOM.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblUOM.ForeColor = Color.DarkSlateBlue;
            lblUOM.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblUOM.Left = txtQty.Right + 8;
            lblUOM.Top = txtQty.Top + 6;
            txtSPAMNT.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtSPAMNT.Top = txtQty.Top;
            txtSPAMNT.Left = lblUOM.Right + 12;
            txtSPAMNT.Width = 140;
            txtSPAMNT.Height = 32;
            y += step;
            label8.AutoSize = true;
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label8.Left = 36;
            label8.Top = y + 6;
            label8.BringToFront();
            txtRemark.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtRemark.Left = 200;
            txtRemark.Top = y;
            txtRemark.Width = 460;
            txtRemark.Height = 64;
            button42.Visible = false;
            button1.Visible = false;
        }

        private void SetFieldRow(Control label, Control field, Control extra, int y, int fieldWidth)
        {
            label.AutoSize = true;
            label.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label.Left = 36;
            label.Top = y + 6;
            field.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            field.Left = 200;
            field.Top = y;
            field.Width = fieldWidth;
            field.Height = 32;
            if (extra != null)
            {
                extra.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                extra.Left = field.Right + 6;
                extra.Top = y - 2;
            }
        }

        private void LayoutSideActions()
        {
            Control host = btnPrint.Parent;
            if (jobSideActions == null)
            {
                jobSideActions = new Panel();
                jobSideActions.Name = "jobSideActions";
                jobSideActions.Size = new Size(228, 168);
                jobSideActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                host.Controls.Add(jobSideActions);
            }
            jobSideActions.Location = new Point(Math.Max(760, host.ClientSize.Width - jobSideActions.Width - 12), 168);
            Button[] actions = new Button[] { btnPrint, button20, button21 };
            int top = 8;
            for (int i = 0; i < actions.Length; i++)
            {
                Button action = actions[i];
                action.Parent = jobSideActions;
                action.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                action.AutoSize = false;
                action.AutoEllipsis = false;
                action.MinimumSize = new Size(208, 44);
                action.Size = new Size(208, 44);
                action.Location = new Point(10, top);
                action.TextAlign = ContentAlignment.MiddleCenter;
                top += 52;
            }
            jobSideActions.Height = top + 4;
            jobSideActions.BringToFront();
        }

        private void LayoutActionBar()
        {
            Panel bar = this.Controls["actionBar"] as Panel;
            if (bar == null)
            {
                bar = button2.Parent as Panel;
            }
            if (bar == null || bar.Name != "actionBar")
            {
                PlacePayButton();
                return;
            }
            bar.Height = 72;
            button2.MinimumSize = new Size(248, 44);
            button2.AutoSize = false;
            button2.AutoEllipsis = false;
            button2.Padding = new Padding(8, 2, 8, 2);
            button2.TextAlign = ContentAlignment.MiddleCenter;
            button2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Text = "PAY & PRINT INVOICE";
            button2.Size = new Size(248, 44);
            System.Collections.Generic.List<Button> row = new System.Collections.Generic.List<Button>();
            foreach (Control child in bar.Controls)
            {
                Button button = child as Button;
                if (button != null && button.Visible)
                {
                    row.Add(button);
                }
            }
            row.Sort(delegate(Button left, Button right) { return left.Left.CompareTo(right.Left); });
            int x = bar.ClientSize.Width - 12;
            int y = Math.Max(8, (bar.ClientSize.Height - 44) / 2);
            for (int i = row.Count - 1; i >= 0; i--)
            {
                Button button = row[i];
                int width = button == button2 ? 248 : Math.Max(110, button.Width);
                int height = 44;
                button.AutoSize = false;
                button.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                button.Size = new Size(width, height);
                if (button == button2)
                {
                    button.MinimumSize = new Size(248, 44);
                }
                x -= width;
                button.Location = new Point(Math.Max(8, x), y);
                button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                x -= 8;
            }
        }

        private void PlaceStockHint()
        {
            if (lblStockHint == null)
            {
                return;
            }
            lblStockHint.Location = new Point(txtSPAMNT.Right + 16, txtSPAMNT.Top);
            lblStockHint.Height = txtSPAMNT.Height;
            int limit = lblStockHint.Parent.ClientSize.Width - 16;
            if (jobSideActions != null && jobSideActions.Parent == lblStockHint.Parent)
            {
                limit = jobSideActions.Left - 8;
            }
            lblStockHint.Width = Math.Max(180, limit - lblStockHint.Left);
        }

        private void PlacePayButton()
        {
            button2.Text = "PAY & PRINT INVOICE";
            button2.AutoSize = false;
            button2.AutoEllipsis = false;
            button2.Padding = new Padding(8, 0, 8, 0);
            button2.TextAlign = ContentAlignment.MiddleCenter;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Width = 248;
            Panel bar = button2.Parent as Panel;
            if (bar != null && bar.Name == "actionBar")
            {
                button2.Height = Math.Max(28, bar.ClientSize.Height - 16);
                button2.Top = Math.Max(0, (bar.ClientSize.Height - button2.Height) / 2);
                button2.Left = Math.Max(8, bar.ClientSize.Width - button2.Width - 12);
            }
            else
            {
                button2.Height = 36;
            }
        }

        private decimal ReadAmount(string text)
        {
            if (text == null)
            {
                return 0;
            }
            string cleaned = text.Trim().Replace(" ", "").Replace(",", "");
            decimal value;
            if (decimal.TryParse(cleaned, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out value))
            {
                return value;
            }
            if (decimal.TryParse(text, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out value))
            {
                return value;
            }
            return 0;
        }

        private void AddPaymentShortcuts()
        {
            btnPayFull = AddPayButton("Full Paid", PayFull);
            btnPayHalf = AddPayButton("50% Advance", PayHalf);
            btnPayClear = AddPayButton("Clear", PayClear);
            PlacePaymentControls();
        }

        private Button AddPayButton(string text, EventHandler click)
        {
            Button button = new Button();
            button.Text = text;
            button.TabStop = false;
            button.Click += click;
            UiTheme.StyleSecondary(button);
            txtAdvance.Parent.Controls.Add(button);
            button.BringToFront();
            return button;
        }

        private void PlacePaymentControls()
        {
            LayoutPaymentStrip();
        }

        private void LayoutPaymentStrip()
        {
            int top = txtRemark.Bottom + 20;
            labelAdvance.AutoSize = true;
            labelAdvance.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            labelAdvance.Left = 36;
            labelAdvance.Top = top + 6;
            labelAdvance.BringToFront();
            txtAdvance.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtAdvance.Left = 200;
            txtAdvance.Top = top;
            txtAdvance.Width = 140;
            txtAdvance.Height = 34;
            if (btnPayFull != null)
            {
                btnPayFull.Size = new Size(86, 34);
                btnPayHalf.Size = new Size(108, 34);
                btnPayClear.Size = new Size(64, 34);
                btnPayFull.Location = new Point(txtAdvance.Right + 10, top);
                btnPayHalf.Location = new Point(btnPayFull.Right + 8, top);
                btnPayClear.Location = new Point(btnPayHalf.Right + 8, top);
                btnPayFull.BringToFront();
                btnPayHalf.BringToFront();
                btnPayClear.BringToFront();
            }
            label72.AutoSize = true;
            label72.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label72.Left = btnPayClear == null ? 520 : btnPayClear.Right + 20;
            label72.Top = top + 6;
            label72.BringToFront();
            lblTOTCOST.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblTOTCOST.AutoSize = false;
            lblTOTCOST.Size = new Size(140, 40);
            lblTOTCOST.Left = label72.Right + 8;
            lblTOTCOST.Top = top - 2;
            lblTOTCOST.BringToFront();
            labelBalanceDue.AutoSize = true;
            labelBalanceDue.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            labelBalanceDue.Left = 36;
            labelBalanceDue.Top = top + 50;
            labelBalanceDue.BringToFront();
            lblBalanceDue.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblBalanceDue.AutoSize = false;
            lblBalanceDue.Size = new Size(140, 40);
            lblBalanceDue.Left = 200;
            lblBalanceDue.Top = top + 42;
            lblBalanceDue.BringToFront();
            if (tabControl1.Top < top + 100)
            {
                tabControl1.Top = top + 100;
            }
        }

        private void PayFull(object sender, EventArgs e)
        {
            txtAdvance.Text = Money(lblTOTCOST.Text).ToString("0.00");
        }

        private void PayHalf(object sender, EventArgs e)
        {
            txtAdvance.Text = (Money(lblTOTCOST.Text) / 2m).ToString("0.00");
        }

        private void PayClear(object sender, EventArgs e)
        {
            txtAdvance.Text = "0.00";
        }

        private void SetCashierTabOrder()
        {
            txtNo.TabIndex = 1;
            lblCusName.TabIndex = 2;
            cmbPartNO.TabIndex = 3;
            txtQty.TabIndex = 4;
            txtSPAMNT.TabIndex = 5;
            txtAdvance.TabIndex = 6;
            button2.TabIndex = 7;
        }

        private void DefaultBlankAdvance()
        {
            if (txtAdvance.Text.Trim().Length == 0)
            {
                txtAdvance.Text = "0.00";
                blankAdvanceOnPrint = true;
            }
        }

        private void AssignNextJobNo()
        {
            if (!string.IsNullOrEmpty(txtNo.Text))
            {
                return;
            }
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                conn = obyConn.Connect();
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(CAST(JOB_NO AS int)), 0) + 1 FROM JOB_DETAILS WHERE JOB_NO NOT LIKE '%[^0-9]%' AND JOB_NO <> ''", conn);
                object value = cmd.ExecuteScalar();
                if (value != null && value != DBNull.Value)
                {
                    txtNo.Text = value.ToString();
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.AssignNextJobNo", ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void LoadCats()
        {
            cmbMethod.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT CATEGORY FROM CATEGORY";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbMethod.Items.Add(dreader["CATEGORY"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private static string[] MaterialRows()
        {
            return new string[] {
                "Flex|Flex Normal",
                "Flex|Flex Gloss",
                "Flex|Flex Matt",
                "Clear Media|Clear Gloss",
                "Clear Media|Clear Matt",
                "A4 Papers/Stickers|A4 Normal Paper",
                "A4 Papers/Stickers|A4 Sticker Gloss",
                "A4 Papers/Stickers|A4 Sticker Matt",
                "A4 Papers/Stickers|A4 Clear Gloss",
                "A4 Papers/Stickers|A4 Clear Matt",
                "Boards|Ice Gold Board",
                "Boards|Ice White Board",
                "Boards|Cloth Board",
                "Promotional Items|Mug 11 oz",
                "Promotional Items|Mug 15 oz",
                "Promotional Items|Tile 4x4",
                "Promotional Items|Tile 6x6",
                "Promotional Items|Tile 8x8",
                "Promotional Items|Granite 8x8",
                "Promotional Items|Granite 12x12",
                "Promotional Items|Glass 4x4",
                "Promotional Items|Glass 6x6",
                "Promotional Items|Glass 8x8"
            };
        }

        private void SeedMaterialCatalog()
        {
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                string[] rows = MaterialRows();
                for (int i = 0; i < rows.Length; i++)
                {
                    string[] parts = rows[i].Split('|');
                    EnsureMaterialCategory(conn, parts[0]);
                    EnsureMaterialItem(conn, parts[0], parts[1]);
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.SeedMaterialCatalog", ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void EnsureMaterialCategory(SqlConnection conn, string category)
        {
            SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT 1 FROM SUB_CATEGORY WHERE CATEGORY = @group AND MAKE = @make AND SUB_CAT = @sub) INSERT INTO SUB_CATEGORY (CATEGORY, MAKE, SUB_CAT) VALUES (@group, @make, @sub)", conn);
            cmd.Parameters.Add("@group", SqlDbType.VarChar, 100).Value = MaterialGroup;
            cmd.Parameters.Add("@make", SqlDbType.VarChar, 100).Value = MaterialMake;
            cmd.Parameters.Add("@sub", SqlDbType.VarChar, 100).Value = category;
            cmd.ExecuteNonQuery();
        }

        private void EnsureMaterialItem(SqlConnection conn, string category, string item)
        {
            SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT 1 FROM MASTER WHERE PARTNO = @part) INSERT INTO MASTER (CATEGORY, MAKE, SUB_CAT, DESCRIPTION, PARTNO, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO) VALUES (@group, @make, @sub, @part, @part, 'Nos', 0, 0, '', '', '', '', '')", conn);
            cmd.Parameters.Add("@part", SqlDbType.VarChar, 100).Value = item;
            cmd.Parameters.Add("@group", SqlDbType.VarChar, 100).Value = MaterialGroup;
            cmd.Parameters.Add("@make", SqlDbType.VarChar, 100).Value = MaterialMake;
            cmd.Parameters.Add("@sub", SqlDbType.VarChar, 100).Value = category;
            cmd.ExecuteNonQuery();
        }

        private void FillMaterialCategories()
        {
            string keep = cmbCat.Text;
            fillingCatalog = true;
            SqlConnection conn = null;
            try
            {
                cmbCat.Items.Clear();
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                SqlCommand cmd = new SqlCommand("SELECT SUB_CAT FROM SUB_CATEGORY WHERE CATEGORY = @group AND MAKE = @make ORDER BY SUB_CAT", conn);
                cmd.Parameters.Add("@group", SqlDbType.VarChar, 100).Value = MaterialGroup;
                cmd.Parameters.Add("@make", SqlDbType.VarChar, 100).Value = MaterialMake;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbCat.Items.Add(reader["SUB_CAT"].ToString());
                }
                reader.Close();
                if (keep.Length > 0)
                {
                    cmbCat.Text = keep;
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.FillMaterialCategories", ex);
            }
            finally
            {
                fillingCatalog = false;
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void FillMaterialItems(bool keepItem)
        {
            string keep = keepItem ? cmbPartNO.Text : "";
            fillingCatalog = true;
            SqlConnection conn = null;
            try
            {
                cmbPartNO.Items.Clear();
                if (!keepItem)
                {
                    cmbPartNO.Text = "";
                }
                if (cmbCat.Text.Trim().Length == 0)
                {
                    return;
                }
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                SqlCommand cmd = new SqlCommand("SELECT PARTNO FROM MASTER WHERE CATEGORY = @group AND MAKE = @make AND SUB_CAT = @sub ORDER BY PARTNO", conn);
                cmd.Parameters.Add("@group", SqlDbType.VarChar, 100).Value = MaterialGroup;
                cmd.Parameters.Add("@make", SqlDbType.VarChar, 100).Value = MaterialMake;
                cmd.Parameters.Add("@sub", SqlDbType.VarChar, 100).Value = cmbCat.Text.Trim();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbPartNO.Items.Add(reader["PARTNO"].ToString());
                }
                reader.Close();
                if (keep.Length > 0)
                {
                    cmbPartNO.Text = keep;
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.FillMaterialItems", ex);
            }
            finally
            {
                fillingCatalog = false;
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private string AskMaterialName(string title, string prompt)
        {
            Form dialog = new Form();
            dialog.Text = title;
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.MinimizeBox = false;
            dialog.MaximizeBox = false;
            dialog.ClientSize = new Size(380, 120);
            Label label = new Label();
            label.Text = prompt;
            label.AutoSize = true;
            label.Location = new Point(12, 12);
            TextBox box = new TextBox();
            box.Location = new Point(12, 40);
            box.Width = 350;
            Button ok = new Button();
            ok.Text = "Add";
            ok.DialogResult = DialogResult.OK;
            ok.Location = new Point(196, 76);
            Button cancel = new Button();
            cancel.Text = "Cancel";
            cancel.DialogResult = DialogResult.Cancel;
            cancel.Location = new Point(282, 76);
            dialog.Controls.Add(label);
            dialog.Controls.Add(box);
            dialog.Controls.Add(ok);
            dialog.Controls.Add(cancel);
            dialog.AcceptButton = ok;
            dialog.CancelButton = cancel;
            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return "";
            }
            return box.Text.Trim();
        }

        private void AddPrintCategory(object sender, EventArgs e)
        {
            string name = AskMaterialName("Print category", "New print category");
            if (name.Length == 0)
            {
                return;
            }
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                EnsureMaterialCategory(conn, name);
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.AddPrintCategory", ex);
                MessageBox.Show(ex.Message, "Print category");
                return;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
            FillMaterialCategories();
            cmbCat.Text = name;
            FillMaterialItems(false);
        }

        private void AddPrintItem(object sender, EventArgs e)
        {
            if (cmbCat.Text.Trim().Length == 0)
            {
                MessageBox.Show("Choose a print category first.", "Print items");
                return;
            }
            string name = AskMaterialName("Print item", "New print item");
            if (name.Length == 0)
            {
                return;
            }
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                SqlCommand existing = new SqlCommand("SELECT TOP 1 SUB_CAT FROM MASTER WHERE PARTNO = @part", conn);
                existing.Parameters.Add("@part", SqlDbType.VarChar, 100).Value = name;
                object found = existing.ExecuteScalar();
                if (found != null && found != DBNull.Value)
                {
                    if (found.ToString() != cmbCat.Text.Trim())
                    {
                        MessageBox.Show("That item is already in another category.", "Print items");
                        return;
                    }
                }
                else
                {
                    EnsureMaterialItem(conn, cmbCat.Text.Trim(), name);
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.AddPrintItem", ex);
                MessageBox.Show(ex.Message, "Print items");
                return;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
            FillMaterialItems(false);
            cmbPartNO.Text = name;
            Load_BALQTYS_PARTNO();
            UOM();
        }

        private void ShowDetails()
        {
            

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT JOB_TYPE, QTY, TOTAL, DEL, SEQ_NO, SEQNO  FROM JOB_DESCRIPTION WHERE SEQ_NO = '" + lblSEQ.Text + "' AND JOB_TYPE <> '-'", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "JOB_DESCRIPTION");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "JOB_DESCRIPTION";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 350;
            Grid_A.Columns[0].HeaderText = "JOB_TYPE";
            Grid_A.Columns[1].Width = 200;
            Grid_A.Columns[1].HeaderText = "QTY";
            Grid_A.Columns[2].Width = 200;
            Grid_A.Columns[2].HeaderText = "TOTAL";
            Grid_A.Columns[3].Width = 40;
            Grid_A.Columns[3].HeaderText = "SELECT";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;
            Grid_A.Columns[4].Visible = false;
            Grid_A.Columns[5].Visible = false;

            Grid_A.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            Grid_A.AutoGenerateColumns = false;
            Grid_A.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            Grid_A.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Grid_A.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
            Grid_A.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            Grid_A.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_A.MultiSelect = false;
            Grid_A.RowHeadersVisible = true;

            Grid_A.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void ShowDetailsB()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT EMPLOYEES.INITIALS + '  ' + EMPLOYEES.NAME AS NAME, EMPLOYEE_ALLOCATION.QTY,  EMPLOYEE_ALLOCATION.QTY, EMPLOYEE_ALLOCATION.TOTAL, DEL, SEQ_NO, SEQNO FROM EMPLOYEE_ALLOCATION INNER JOIN EMPLOYEES ON EMPLOYEE_ALLOCATION.EMP_NO = EMPLOYEES.EMP_NO WHERE SEQ_NO = '" + lblSEQ.Text + "'", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "EMPLOYEE_ALLOCATION");

            Grid_B.DataSource = dsLoan;
            Grid_B.DataMember = "EMPLOYEE_ALLOCATION";

            _Conn.Close();

            FillGridB();
        }

        private void FillGridB()
        {
            Grid_B.Columns[0].Width = 400;
            Grid_B.Columns[0].HeaderText = "EMPLOYEE";
            Grid_B.Columns[1].Width = 150;
            Grid_B.Columns[1].HeaderText = "NO.HOURS";
            Grid_B.Columns[3].Width = 300;
            Grid_B.Columns[3].HeaderText = "TOTAL AMOUNT";
            Grid_B.Columns[4].Width = 100;
            Grid_B.Columns[4].HeaderText = "SELECT";

            Grid_B.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_B.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_B.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_B.Columns[3].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_B.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_B.Columns[0].ReadOnly = true;
            Grid_B.Columns[1].ReadOnly = true;
            Grid_B.Columns[2].ReadOnly = true;
            Grid_B.Columns[3].ReadOnly = false;
            Grid_B.Columns[4].ReadOnly = false;
            Grid_B.Columns[2].Visible = false;
            Grid_B.Columns[5].Visible = false;
            Grid_B.Columns[6].Visible = false;

            Grid_B.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_B.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_B.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_B.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_B.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            Grid_B.AutoGenerateColumns = false;
            Grid_B.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            Grid_B.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Grid_B.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
            Grid_B.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            Grid_B.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_B.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            Grid_B.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_B.MultiSelect = false;
            Grid_B.RowHeadersVisible = true;

            Grid_B.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_B.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_B.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_B.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_B.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void InsuranceCompany()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT NAME FROM INSURANCE_COMPANY", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                cmbMethod.Items.Add(drReader["NAME"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }
            drReader.Close();
            _Conn.Close();
        }

        //private void Customers()
        //{

        //}


        private void button5_Click(object sender, EventArgs e)
        {
            frm_CustomerProfile frmGen = new frm_CustomerProfile();
            frmGen.CustomerNO = txtNo.Text;
            AppWorkspace.Open(frmGen, "Customer");
            //this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_InsuranceCompany frmGen = new frm_InsuranceCompany();
            frmGen.TopMost = true;
            frmGen.Show();
            this.Hide();
            InsuranceCompany();
        }

        private void UPSTOCKS()
        {
            QTY = decimal.Parse(txtQty.Text);
            BAL_QTY = decimal.Parse(lblBalQty.Text);

            if (QTY > BAL_QTY)
            {
                MessageBox.Show("Please Enter Less Issue Amount to Proceed", "Issue Goods Info");
                return;
            }

            if (txt_Price.Text == "" || txtQty.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Issue Goods Info");
                return;
            }

            decimal CALQTY = Convert.ToDecimal(txtQty.Text);
            decimal CALVAL = Convert.ToDecimal(txt_Price.Text);
            decimal CALUNIT = Convert.ToDecimal(txt_Price.Text);

            TOTCALQTY = CALQTY;

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQ_NO, PARTNO, QTY, BAL_QTY, S_NO, TOT, ISSUE_PRICE, STATUS FROM RECEIVED_ITEMS WHERE (PARTNO = '" + cmbPartNO.Text + "') AND (STATUS = 1)ORDER BY SEQ_NO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                {
                    SEQ_NO = Convert.ToInt16(dreader["SEQ_NO"].ToString().Trim());
                    QTY = Convert.ToDecimal(dreader["QTY"].ToString().Trim());
                    BAL_QTY = Convert.ToDecimal(dreader["BAL_QTY"].ToString().Trim());
                    //ISSUE_P = Convert.ToDecimal(dreader["ISSUE_PRICE"].ToString());
                    TOT_ISSUE = CALUNIT * TOTCALQTY;


                    if (TOTCALQTY != 0)
                    {
                        if (BAL_QTY > TOTCALQTY)
                        {
                            obyConn = new Connection.DatabaseConnection();
                            _Conn = obyConn.Connect();
                            SqlCommand cmdsql1 = new SqlCommand();
                            cmdsql1.Connection = _Conn;
                            CALVAL = CALUNIT * TOTCALQTY;
                            cmdsql1.CommandText = "INSERT INTO ISSUED_ITEMS (JOB_NO, SEQ, SYS_USER, PARTNO, ORGQTY, QTY, PRICE, REMARKS, PRO_DATE, TOT, STATUS, RECEIVE_SEQNO, PRO_TIME) VALUES ('" + txtNo.Text + "', '" + SEQ + "', '" + lblUser.Text + "', '" + cmbPartNO.Text + "','" + QTY + "', '" + TOTCALQTY + "','" + CALUNIT + "', '" + txtRemarks.Text + "',Convert(DateTime,'" + dt_Start.Text + "'),'" + TOT_ISSUE + "', '1', '" + SEQ_NO + "', '" + DateTime.Now + "')";
                            cmdsql1.ExecuteNonQuery();

                            SqlCommand cmdsql2 = new SqlCommand();
                            cmdsql2.Connection = _Conn;
                            cmdsql2.CommandText = "UPDATE RECEIVED_ITEMS SET BAL_QTY = '" + (BAL_QTY - TOTCALQTY) + "' WHERE SEQ_NO = '" + SEQ_NO + "'";
                            cmdsql2.ExecuteNonQuery();

                            TOTCALQTY = TOTCALQTY - TOTCALQTY;
                        }

                        if (BAL_QTY <= TOTCALQTY)
                        {
                            obyConn = new Connection.DatabaseConnection();
                            _Conn = obyConn.Connect();
                            SqlCommand cmdsql1 = new SqlCommand();
                            cmdsql1.Connection = _Conn;

                            ENDCAL = CALUNIT * BAL_QTY;

                            cmdsql1.CommandText = "INSERT INTO ISSUED_ITEMS (JOB_NO, SEQ, SYS_USER, PARTNO, ORGQTY, QTY, PRICE, REMARKS, PRO_DATE, TOT, STATUS, RECEIVE_SEQNO, PRO_TIME) VALUES ('" + txtNo.Text + "', '" + SEQ + "', '" + lblUser.Text + "', '" + cmbPartNO.Text + "','" + QTY + "', '" + BAL_QTY + "', '" + CALUNIT + "','" + txtRemarks.Text + "',Convert(DateTime,'" + dt_Start.Text + "'),'" + ENDCAL + "', '1', '" + SEQ_NO + "', '" + DateTime.Now + "')";
                            cmdsql1.ExecuteNonQuery();

                            SqlCommand cmdsql2 = new SqlCommand();
                            cmdsql2.Connection = _Conn;
                            cmdsql2.CommandText = "UPDATE RECEIVED_ITEMS SET BAL_QTY = '0', STATUS = '0' WHERE SEQ_NO = '" + SEQ_NO + "'";
                            cmdsql2.ExecuteNonQuery();
                            TOTCALQTY = TOTCALQTY - BAL_QTY;
                        }
                    }
                }
            }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Issue Goods Info");
            //    return;
            //}
            _Conn.Close();
            StockShowDetails();
            //ClearData();
            btn_Save.Enabled = false;


            Load_BALQTYS_PARTNO();

            lblShow.Text = "";
            txt_Price.Text = "";
            //txtQty.Text = "";
        }

        private void Load_BALQTYS()
        {
            lblBalQty.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT S_NO, SUM(BAL_QTY) AS QTY, STATUS FROM RECEIVED_ITEMS GROUP BY S_NO, STATUS, PARTNO HAVING (STATUS = 1) AND (PART_NO  = '" + cmbPartNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblBalQty.Text = dreader["QTY"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DefaultBlankAdvance();
            try
            {
            if (txtNo.Text.Trim().Length > 0 && HasPrintableJob())
            {
                if (SettleExistingJob(true))
                {
                    button20_Click_1(this, EventArgs.Empty);
                }
                return;
            }
            if (!StockAllowsSale())
            {
                return;
            }

            if (txtNo.Text == "" || lblCusName.Text == "" || lblSEQ .Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                return;
            }

            Connection.DatabaseConnection obyConn;
            bool saved = false;

            try
            {
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _Conn;
                cmdsql1.CommandText = "INSERT INTO JOB_DETAILS (JOB_DATE, JOB_TIME, JOB_NO, CUSTOMER_ID, JOB_START_DATE, JOB_END_DATE, P_SIZE, QTY, P_METHOD, P_MEDIA, P_CAT, REMARK) VALUES ('" + DateTime.Now + "', '" + DateTime.Now + "', '" + txtNo.Text + "', '" + lblSEQ.Text + "', '" + dt_Start.Value + "', '" + dt_End.Value + "', '" + cmbPartNO.Text + "', '" + txtQty.Text + "', '" + cmbMethod.Text + "', '" + cmbCat.Text + "', '" + cmbCat.Text + "', '" + txtRemark.Text + "')";
                cmdsql1.ExecuteNonQuery();
           

                FindSEQ();
                SaveJobAmounts();
                SaveJobLine();
                SaveInvoiceIdentity();
                //FindTypes();
                FindEmps();
                //ADD_MAIN();
                //ADD_SUB();
                ShowDetails();
                ShowDetailsB();
                StockShowDetails();


                //cmdsql1.CommandText = "INSERT INTO JOB_DESCRIPTION (SEQ_NO, JOB_TYPE, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '-', '0', '0', '" + dt_Start.Value + "')";
                //cmdsql1.ExecuteNonQuery();

                //cmdsql1.CommandText = "INSERT INTO JOB_ACCIDENT_REPAIR (SEQ_NO, MAIN_CAT, SUB_CAT, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '0', '0', '0', '0', '" + dt_Start.Value + "')";
                //cmdsql1.ExecuteNonQuery();

                //cmdsql1.CommandText = "INSERT INTO JOB_REPLACED_SPARES (SEQ_NO, JOB_TYPE, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '-', '0', '0', '" + dt_Start.Value + "')";
                //cmdsql1.ExecuteNonQuery();

                MessageBox.Show("Job Entry Successfully Added. Proceed to the Next step");
                saved = true;
                draftSaved = true;
                DeleteJobDraft();
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation", ex);
                MessageBox.Show(ex.Message, "Job Entry");
            }
            finally
            {
                if (_Conn != null)
                {
                    _Conn.Dispose();
                    _Conn = null;
                }
            }
            if (saved)
            {
                button20_Click_1(this, EventArgs.Empty);
            }
            tabControl1.Visible = true;
            tb1.Visible = true;
            tb2.Visible = true;
            FindSEQ();
            FindEmps();
            UPSTOCKS();
            lblBalQty.Text = "";
            txtINVNO.Focus();
            }
            finally
            {
                blankAdvanceOnPrint = false;
            }
        }

        private void PrintSavedJobCard()
        {
            frm_Reports report = new frm_Reports();
            try
            {
                try
                {
                    report.PrintJobCard(txtNo.Text);
                }
                catch (Exception ex)
                {
                    AppLog.Write("frm_JobCreation.PrintJobCard", ex);
                    btnPrint_Click(this, EventArgs.Empty);
                }
                report.PrintInvoice(txtNo.Text);
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.PrintInvoice", ex);
                button20_Click_1(this, EventArgs.Empty);
            }
            finally
            {
                report.Dispose();
            }
        }

        private void FindSEQ()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT SEQ_NO FROM JOB_DETAILS WHERE (JOB_NO = '" + txtNo.Text + "') AND (JOB_START_DATE = CONVERT(DATETIME, '" + dt_Start.Text + " 00:00:00', 102)) AND (STATUS = 1)", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                SEQ = int.Parse(drReader["SEQ_NO"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }
            drReader.Close();
            _Conn.Close();
        }

        private void FindEmps()
        {
            cmbEmp.Items.Clear();
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT EMP_NO, EMP_NO + '  -   ' + INITIALS + ' ' + NAME AS NAME, EMP_RATE  FROM  dbo.EMPLOYEES WHERE (STATUS = 2)", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                cmbEmp.Items.Add(drReader["NAME"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }
            drReader.Close();
            _Conn.Close();
        }

        private void StockShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT ISSUED_ITEMS.PARTNO, MASTER.DESCRIPTION, ISSUED_ITEMS.QTY, ISSUED_ITEMS.PRICE, ISSUED_ITEMS.TOT, ISSUED_ITEMS.S_NO, ISSUED_ITEMS.STATUS, ISSUED_ITEMS.DEL, ISSUED_ITEMS.SEQ_NO, ISSUED_ITEMS.SEQ FROM ISSUED_ITEMS INNER JOIN MASTER ON ISSUED_ITEMS.PARTNO = MASTER.PARTNO WHERE (ISSUED_ITEMS.STATUS = 1) AND (ISSUED_ITEMS.SEQ = '" + lblSEQ.Text + "')ORDER BY ISSUED_ITEMS.SEQ_NO DESC", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "ISSUED_ITEMS");

            dataGridView2.DataSource = dsLoan;
            dataGridView2.DataMember = "ISSUED_ITEMS";

            _Conn.Close();

            StockFillGrid();
        }

        private void StockFillGrid()
        {
            dataGridView2.Columns[0].Width = 120;
            dataGridView2.Columns[0].HeaderText = "PART NO";
            dataGridView2.Columns[1].Width = 140;
            dataGridView2.Columns[1].HeaderText = "DESCRIPTION";
            dataGridView2.Columns[2].Width = 100;
            dataGridView2.Columns[2].HeaderText = "QTY";
            dataGridView2.Columns[3].Width = 90;
            dataGridView2.Columns[3].HeaderText = "PRICE";
            dataGridView2.Columns[4].Width = 60;
            dataGridView2.Columns[4].HeaderText = "TOT";
            dataGridView2.Columns[5].Width = 120;
            dataGridView2.Columns[5].HeaderText = "S_NO";
            dataGridView2.Columns[6].Width = 120;
            dataGridView2.Columns[6].HeaderText = "STATUS";
            dataGridView2.Columns[7].Width = 20;
            dataGridView2.Columns[7].HeaderText = "DELETE";
            //Grid_A.Columns[10].Width = 20;
            //Grid_A.Columns[10].HeaderText = "SEQ_NO";

            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.Columns[5].DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.Columns[7].DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView2.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView2.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView2.Columns[3].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView2.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView2.Columns[5].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView2.Columns[6].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView2.Columns[7].DefaultCellStyle.ForeColor = Color.Blue;

            dataGridView2.Columns[0].ReadOnly = true;
            dataGridView2.Columns[1].ReadOnly = true;
            dataGridView2.Columns[2].ReadOnly = true;
            //dataGridView2.Columns[3].ReadOnly = true;
            dataGridView2.Columns[4].ReadOnly = true;
            dataGridView2.Columns[5].ReadOnly = true;
            dataGridView2.Columns[6].ReadOnly = true;
            dataGridView2.Columns[7].ReadOnly = true;

            dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.RowHeadersVisible = true;

            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void FINDMETHOD()
        {
            cmbMethod.Items.Clear();

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT CATEGORY FROM CATEGORY", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                cmbMethod.Items.Add(drReader["CATEGORY"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }

            drReader.Close();
            _Conn.Close();
        }

        private void FINDMEDIA()
        {
            cmbMedia.Items.Clear();

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT MAKE FROM MAKE WHERE CATEGORY = '"+ cmbMethod.Text +"'", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                cmbMedia.Items.Add(drReader["MAKE"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }

            drReader.Close();
            _Conn.Close();
        }

        private void FINDCAT()
        {
        }



        private decimal Money(string text)
        {
            decimal value;
            if (!decimal.TryParse(text, out value))
            {
                return 0;
            }
            return value;
        }

        private string Scalar(SqlConnection conn, string sql, string arg)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@q", SqlDbType.VarChar, 200).Value = arg;
            object value = cmd.ExecuteScalar();
            if (value == null || value == DBNull.Value)
            {
                return "";
            }
            return value.ToString();
        }

        private string ResolveJobNumber(string typed)
        {
            if (typed.Length == 0)
            {
                return "";
            }
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                string job = Scalar(conn, "SELECT TOP 1 JOB_NO FROM JOB_DETAILS WHERE JOB_NO = @q AND STATUS = 1", typed);
                if (job.Length > 0)
                {
                    return job;
                }
                job = Scalar(conn, "SELECT TOP 1 JOB_NO FROM JOB_DETAILS WHERE INV_NO = @q AND STATUS = 1", typed);
                if (job.Length > 0)
                {
                    return job;
                }
                string customer = Scalar(conn, "SELECT TOP 1 CAST(SEQ_NO AS varchar(20)) FROM CUSTOMER_INFO WHERE NAME = @q", typed);
                if (customer.Length == 0)
                {
                    return "";
                }
                customerKey = customer;
                SqlCommand countCmd = new SqlCommand("SELECT COUNT(*) FROM JOB_DETAILS WHERE CUSTOMER_ID = @q AND STATUS = 1", conn);
                countCmd.Parameters.Add("@q", SqlDbType.VarChar, 20).Value = customer;
                int count = Convert.ToInt32(countCmd.ExecuteScalar());
                if (count == 0)
                {
                    return "";
                }
                if (count == 1)
                {
                    return Scalar(conn, "SELECT TOP 1 JOB_NO FROM JOB_DETAILS WHERE CUSTOMER_ID = @q AND STATUS = 1 ORDER BY SEQ_NO DESC", customer);
                }
                conn.Dispose();
                conn = null;
                ShowPendingCredit(customer);
                return null;
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.ResolveJobNumber", ex);
                return "";
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private static string SqlMoney(string column)
        {
            return "CASE WHEN ISNUMERIC(" + column + ") = 1 THEN CAST(" + column + " AS decimal(18,2)) ELSE 0 END";
        }

        private void LoadFoundJob(string jobNo)
        {
            txtNo.Text = jobNo;
            FindEmps();
            CUS();
            SHOW();
            ShowDetails();
            ShowDetailsB();
            StockShowDetails();
        }

        private void ShowPendingCredit(string customerId)
        {
            Form dialog = new Form();
            dialog.Text = "Pending credit";
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.Size = new Size(760, 420);
            dialog.MinimizeBox = false;
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoGenerateColumns = true;
            Label empty = new Label();
            empty.Text = "No unpaid invoices for this customer.";
            empty.Dock = DockStyle.Top;
            empty.Height = 28;
            empty.Visible = false;
            dialog.Controls.Add(grid);
            dialog.Controls.Add(empty);
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                string paid = SqlMoney("j.ADVANCE_1") + " + " + SqlMoney("j.ADVANCE_2") + " + " + SqlMoney("j.ADVANCE_3");
                string total = SqlMoney("j.TOT_COST_AMOUNT");
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT j.JOB_NO, j.INV_NO, CONVERT(varchar(10), j.JOB_START_DATE, 23) AS JOB_DATE, " + total + " AS TOTAL, " + paid + " AS PAID, " + total + " - (" + paid + ") AS BALANCE FROM JOB_DETAILS j WHERE j.CUSTOMER_ID = @seq AND j.STATUS = 1 AND " + total + " - (" + paid + ") > 0 ORDER BY j.SEQ_NO DESC", conn);
                adapter.SelectCommand.Parameters.Add("@seq", SqlDbType.VarChar, 20).Value = customerId;
                DataTable table = new DataTable();
                adapter.Fill(table);
                grid.DataSource = table;
                if (grid.Columns.Count >= 6)
                {
                    grid.Columns[0].HeaderText = "Job No";
                    grid.Columns[1].HeaderText = "Invoice No";
                    grid.Columns[2].HeaderText = "Date";
                    grid.Columns[3].HeaderText = "Total";
                    grid.Columns[4].HeaderText = "Paid";
                    grid.Columns[5].HeaderText = "Balance";
                }
                empty.Visible = table.Rows.Count == 0;
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.ShowPendingCredit", ex);
                MessageBox.Show(ex.Message, "Pending credit");
                return;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
            grid.CellDoubleClick += delegate
            {
                if (grid.CurrentRow == null || grid.CurrentRow.Cells["JOB_NO"].Value == null)
                {
                    return;
                }
                string selected = grid.CurrentRow.Cells["JOB_NO"].Value.ToString();
                dialog.Close();
                LoadFoundJob(selected);
            };
            dialog.ShowDialog(this);
        }

        private void PlaceOperator()
        {
            if (operatorLabel == null)
            {
                operatorLabel = new Label();
                operatorLabel.Name = "lblOperator";
                operatorLabel.Text = "Assigned Employee / Operator";
                operatorLabel.AutoSize = true;
                operatorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                this.Controls.Add(operatorLabel);
            }
            operatorLabel.Location = new Point(lblBalanceDue.Left, Math.Max(8, lblBalanceDue.Top - 78));
            cmbEmp.Parent = this;
            cmbEmp.Location = new Point(lblBalanceDue.Left, operatorLabel.Bottom + 4);
            cmbEmp.Width = 280;
            cmbEmp.Visible = true;
            operatorLabel.Visible = true;
            operatorLabel.BringToFront();
            cmbEmp.BringToFront();
            FindEmps();
        }

        private bool SettleExistingJob(bool announce)
        {
            if (SEQ == 0)
            {
                FindSEQ();
            }
            if (SEQ == 0)
            {
                MessageBox.Show("The saved job could not be found.", "Job Card");
                return false;
            }
            decimal storedA = 0;
            decimal storedB = 0;
            decimal storedC = 0;
            string invoiceNo = txtINVNO.Text.Trim();
            SqlConnection read = null;
            try
            {
                Connection.DatabaseConnection readLink = new Connection.DatabaseConnection();
                read = readLink.Connect();
                SqlCommand readCmd = new SqlCommand("SELECT ADVANCE_1, ADVANCE_2, ADVANCE_3, INV_NO FROM JOB_DETAILS WHERE SEQ_NO = @seq AND STATUS = 1", read);
                readCmd.Parameters.Add("@seq", SqlDbType.Int).Value = SEQ;
                SqlDataReader reader = readCmd.ExecuteReader();
                if (reader.Read())
                {
                    storedA = Money(reader["ADVANCE_1"].ToString());
                    storedB = Money(reader["ADVANCE_2"].ToString());
                    storedC = Money(reader["ADVANCE_3"].ToString());
                    if (invoiceNo.Length == 0)
                    {
                        invoiceNo = reader["INV_NO"].ToString().Trim();
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.SettleExistingJob", ex);
                MessageBox.Show(ex.Message, "Job Card");
                return false;
            }
            finally
            {
                if (read != null)
                {
                    read.Dispose();
                }
            }
            txtA.Text = storedA.ToString("0.00");
            txtB.Text = storedB.ToString("0.00");
            txtC.Text = storedC.ToString("0.00");
            decimal stored = storedA + storedB + storedC;
            decimal screen = Money(txtAdvance.Text);
            decimal diff = screen - stored;
            if (diff < 0)
            {
                if (blankAdvanceOnPrint)
                {
                    txtAdvance.Text = stored.ToString("0.00");
                    diff = 0;
                }
                else
                {
                    MessageBox.Show("Enter the full paid amount, including earlier advances.", "Job Card");
                    return false;
                }
            }
            if (diff > 0)
            {
                string amountColumn = "";
                string dateColumn = "";
                if (Money(txtA.Text) == 0)
                {
                    amountColumn = "ADVANCE_1";
                    dateColumn = "PAID_DATE1";
                    txtA.Text = diff.ToString("0.00");
                }
                else if (Money(txtB.Text) == 0)
                {
                    amountColumn = "ADVANCE_2";
                    dateColumn = "PAID_DATE2";
                    txtB.Text = diff.ToString("0.00");
                }
                else if (Money(txtC.Text) == 0)
                {
                    amountColumn = "ADVANCE_3";
                    dateColumn = "PAID_DATE3";
                    txtC.Text = diff.ToString("0.00");
                }
                else
                {
                    MessageBox.Show("The three advance amounts are already filled.", "Job Card");
                    return false;
                }
                string amountText = diff.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                string totalText = Money(lblTOTCOST.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                string today = DateTime.Today.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                SqlConnection conn = null;
                try
                {
                    Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                    conn = link.Connect();
                    SqlCommand update = new SqlCommand("UPDATE JOB_DETAILS SET " + amountColumn + " = '" + amountText + "', " + dateColumn + " = '" + today + "', TOT_COST_AMOUNT = '" + totalText + "' WHERE SEQ_NO = '" + SEQ + "'", conn);
                    update.ExecuteNonQuery();
                    PostTodaySale(conn, diff, invoiceNo);
                }
                catch (Exception ex)
                {
                    AppLog.Write("frm_JobCreation.SettleExistingJob", ex);
                    MessageBox.Show(ex.Message, "Job Card");
                    return false;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Dispose();
                    }
                }
            }
            RefreshBalance();
            if (announce && diff > 0)
            {
                MessageBox.Show("Payment recorded. Balance is " + lblBalanceDue.Text + ".", "Job Card");
            }
            return true;
        }

        private void PostTodaySale(SqlConnection conn, decimal amount, string invoiceNo)
        {
            if (amount <= 0)
            {
                return;
            }
            string amountText = amount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            string today = DateTime.Today.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            string remarks = ("Job " + txtNo.Text.Trim() + " Inv " + invoiceNo).Replace("'", "''");
            SqlCommand insert = new SqlCommand("INSERT INTO DAY_EARNINGS (PRO_DATE, DESCRIPTION, AMOUNT, REMARKS) VALUES ('" + today + "', 'Today Sale', '" + amountText + "', '" + remarks + "')", conn);
            insert.ExecuteNonQuery();
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClearData();
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                string typed = txtNo.Text.Trim();
                string jobNo = ResolveJobNumber(typed);
                if (jobNo == null)
                {
                    return;
                }
                if (jobNo.Length == 0)
                {
                    MessageBox.Show("No job was found for that job number, invoice number, or customer.", "Job Card");
                    return;
                }
                txtNo.Text = jobNo;
                FindEmps();
                CUS();
                SHOW();
                //FindEmps();
                ShowDetails();
                ShowDetailsB();
                StockShowDetails();
               
                FillDGV("");
                if (txtNo.Text != "")
                {
                    btnPay.Enabled = true;
                    button31.Enabled = true;
                }
                FindEmps();
               
            }
        }

        private void CUS()
        {
            LoadCustomers();
            lblCusName.Focus();
        }

        private void LoadCustomers()
        {
            lblCusName.Items.Clear();
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            SqlConnection conn = null;
            SqlDataReader drReader = null;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                conn = obyConn.Connect();
                SqlCommand cmdReader = new SqlCommand("SELECT NAME, MOBILE_NO FROM CUSTOMER_INFO", conn);
                drReader = cmdReader.ExecuteReader();
                while (drReader.Read())
                {
                    string name = drReader["NAME"].ToString().Trim();
                    string mobile = drReader["MOBILE_NO"].ToString().Trim();
                    if (name != "")
                    {
                        lblCusName.Items.Add(name);
                        source.Add(name);
                    }
                    if (mobile != "")
                    {
                        source.Add(mobile);
                    }
                }
                lblCusName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                lblCusName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                lblCusName.AutoCompleteCustomSource = source;
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.LoadCustomers", ex);
            }
            finally
            {
                if (drReader != null)
                {
                    drReader.Close();
                }
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void ResolveCustomer()
        {
            if (resolvingCustomer)
            {
                return;
            }
            string typed = lblCusName.Text.Trim();
            if (typed == "")
            {
                if (lblCustomerContact != null)
                {
                    lblCustomerContact.Text = "";
                }
                return;
            }
            resolvingCustomer = true;
            SqlConnection conn = null;
            SqlDataReader drReader = null;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                conn = obyConn.Connect();
                SqlCommand cmdReader = new SqlCommand("SELECT SEQ_NO, NAME FROM CUSTOMER_INFO WHERE NAME = @q OR MOBILE_NO = @q", conn);
                cmdReader.Parameters.Add("@q", SqlDbType.VarChar, 200).Value = typed;
                drReader = cmdReader.ExecuteReader();
                if (drReader.Read())
                {
                    string seq = drReader["SEQ_NO"].ToString();
                    lblCusName.Text = drReader["NAME"].ToString();
                    lblSEQ.Text = seq;
                    customerKey = seq;
                    ShowCustomerContact(seq);
                    drReader.Close();
                    drReader = null;
                    conn.Dispose();
                    conn = null;
                    ShowUnpaidCredit(seq);
                    dt_Start.Focus();
                }
                else if (lblCustomerContact != null)
                {
                    lblCustomerContact.Text = "";
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.ResolveCustomer", ex);
            }
            finally
            {
                resolvingCustomer = false;
                if (drReader != null)
                {
                    drReader.Close();
                }
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void ShowUnpaidCredit(string seq)
        {
            lblBalQty.Text = "0.00";
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                conn = obyConn.Connect();
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(t.CREDIT), 0) FROM ISSUED_TOTALS t INNER JOIN (SELECT INV_NO, MIN(CUSTOMER_ID) AS CUSTOMER_ID FROM JOB_DETAILS GROUP BY INV_NO) j ON j.INV_NO = t.INV_NO WHERE j.CUSTOMER_ID = @seq AND (t.PAID = 0 OR t.PAID IS NULL)", conn);
                cmd.Parameters.Add("@seq", SqlDbType.VarChar, 50).Value = seq;
                object value = cmd.ExecuteScalar();
                decimal credit = 0;
                if (value != null && value != DBNull.Value)
                {
                    decimal.TryParse(value.ToString(), out credit);
                }
                lblBalQty.Text = credit.ToString("0.00");
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.ShowUnpaidCredit", ex);
                lblBalQty.Text = "0.00";
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void RefreshJobCost(object sender, EventArgs e)
        {
            if (loadingJob)
            {
                return;
            }
            decimal qty = ReadAmount(txtQty.Text);
            decimal price = ReadAmount(txtSPAMNT.Text);
            lblTOTCOST.Text = (qty * price).ToString("0.00");
            RefreshBalance();
            RefreshStockLabel();
        }

        private void RefreshBalance()
        {
            decimal total;
            decimal advance;
            if (!decimal.TryParse(lblTOTCOST.Text, out total))
            {
                total = 0;
            }
            if (!decimal.TryParse(txtAdvance.Text, out advance))
            {
                advance = 0;
            }
            decimal balance = total - advance;
            lblBalanceDue.Text = balance.ToString("0.00");
            if (balance <= 0)
            {
                lblBalanceDue.ForeColor = Color.ForestGreen;
            }
            else
            {
                lblBalanceDue.ForeColor = Color.OrangeRed;
            }
        }

        private void SaveInvoiceIdentity()
        {
            if (SEQ == 0)
            {
                throw new InvalidOperationException("The job was saved but its sequence number was not found.");
            }
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                SqlCommand read = new SqlCommand("SELECT INV_NO FROM JOB_DETAILS WHERE SEQ_NO = '" + SEQ + "'", conn);
                object current = read.ExecuteScalar();
                string existing = current == null || current == DBNull.Value ? "" : current.ToString().Trim();
                bool nonNumeric = false;
                for (int i = 0; i < existing.Length; i++)
                {
                    if (!char.IsDigit(existing[i]))
                    {
                        nonNumeric = true;
                        break;
                    }
                }
                string today = DateTime.Today.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                string clock = DateTime.Now.ToString("HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                string sql;
                if (nonNumeric)
                {
                    sql = "UPDATE JOB_DETAILS SET INV_DATE = '" + today + "', INV_TIME = '" + clock + "' WHERE SEQ_NO = '" + SEQ + "'";
                }
                else
                {
                    SqlCommand next = new SqlCommand("SELECT ISNULL(MAX(CASE WHEN INV_NO NOT LIKE '%[^0-9]%' AND INV_NO <> '' THEN CAST(INV_NO AS int) END), 0) + 1 FROM JOB_DETAILS", conn);
                    int number = Convert.ToInt32(next.ExecuteScalar());
                    sql = "UPDATE JOB_DETAILS SET INV_NO = '" + number.ToString(System.Globalization.CultureInfo.InvariantCulture) + "', INV_DATE = '" + today + "', INV_TIME = '" + clock + "' WHERE SEQ_NO = '" + SEQ + "'";
                    txtINVNO.Text = number.ToString(System.Globalization.CultureInfo.InvariantCulture);
                }
                SqlCommand update = new SqlCommand(sql, conn);
                update.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void SaveJobLine()
        {
            if (SEQ == 0)
            {
                throw new InvalidOperationException("The job was saved but its sequence number was not found.");
            }
            decimal qty;
            decimal price;
            if (!decimal.TryParse(txtQty.Text, out qty))
            {
                qty = 0;
            }
            if (!decimal.TryParse(txtSPAMNT.Text, out price))
            {
                price = 0;
            }
            string jobType = cmbPartNO.Text.Trim();
            if (jobType.Length == 0)
            {
                jobType = txtRemark.Text.Trim();
            }
            if (jobType.Length == 0)
            {
                jobType = "-";
            }
            jobType = jobType.Replace("'", "''");
            string qtyText = qty.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            string totalText = (qty * price).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                SqlCommand cmd = new SqlCommand("INSERT INTO JOB_DESCRIPTION (SEQ_NO, JOB_TYPE, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '" + jobType + "', '" + qtyText + "', '" + totalText + "', '" + dt_Start.Value + "')", conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void SaveJobAmounts()
        {
            decimal total;
            decimal advance;
            if (!decimal.TryParse(lblTOTCOST.Text, out total))
            {
                total = 0;
            }
            if (!decimal.TryParse(txtAdvance.Text, out advance))
            {
                advance = 0;
            }
            string totalText = total.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            string advanceText = advance.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            txtA.Text = advanceText;
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                SqlCommand cmd = new SqlCommand("UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = '" + totalText + "', ADVANCE_1 = '" + advanceText + "' WHERE SEQ_NO = '" + SEQ + "'", conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void TOTCOST()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT TOT_COST_AMOUNT FROM JOB_DETAILS WHERE SEQ_NO = '" + SEQ + "'", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                lblTOTCOST.Text = drReader["TOT_COST_AMOUNT"].ToString(); // + " - " + drTenMain["NAME"].ToString());
            }
            drReader.Close();
            _Conn.Close();
        }


        private void FindCus()
        {
            cmbEmp.Items.Clear();
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT NAME FROM CUSTOMER_INFO WHERE (SEQ_NO = '"+ CUS_ID +"')", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                lblCusName.Text =  drReader["NAME"].ToString(); // + " - " + drTenMain["NAME"].ToString());
                lblCusName.DroppedDown = false;
            }
            drReader.Close();
            _Conn.Close();
            ShowUnpaidCredit(CUS_ID.ToString());
        }

        private void SHOW()
        {
            loadingJob = true;
            try
            {
            lblCusName.Focus();
            button2.Enabled = true;

            //button25.Enabled = false;
            //button26.Enabled = false;

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT   CUSTOMER_ID, ADVANCE_1, ADVANCE_2, ADVANCE_3, ADVANCE_4,ADVANCE_5, ADVANCE_6, ADVANCE_7, ADVANCE_8, ADVANCE_9, ADVANCE_10, PAID_DATE1, PAID_DATE2, PAID_DATE3, PAID_DATE4, PAID_DATE5, PAID_DATE6, PAID_DATE7, PAID_DATE8, PAID_DATE9, PAID_DATE10, P_METHOD, QTY, P_MEDIA, P_CAT, PAID_DATE1, PAID_DATE2, PAID_DATE3, SEQ_NO, JOB_NO, JOB_START_DATE, JOB_END_DATE, P_SIZE, REMARK, TOT_COST_AMOUNT FROM JOB_DETAILS WHERE JOB_NO = '" + txtNo.Text + "' AND STATUS = 1", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                button2.Enabled = true;
                btnPay.Enabled = true;
                dt_Start.Focus();
                tabControl1.Visible = true;

                //button25.Enabled = true;
                //button26.Enabled = true;

                if (drReader.HasRows == true)
                {
                    CUS_ID = int.Parse(drReader["CUSTOMER_ID"].ToString());
                    FindCus();
                    SEQ = int.Parse(drReader["SEQ_NO"].ToString());
                    lblSEQ.Text = drReader["SEQ_NO"].ToString();
                    txtNo.Text = drReader["JOB_NO"].ToString();
                    dt_Start.Value = Convert.ToDateTime(drReader["JOB_START_DATE"].ToString());
                    dt_End.Value = Convert.ToDateTime(drReader["JOB_END_DATE"].ToString());
                    cmbMethod.Text = drReader["P_METHOD"].ToString();
                    txtQty.Text = drReader["QTY"].ToString();
                    cmbCat.Text = drReader["P_MEDIA"].ToString();
                    cmbCat.Text = drReader["P_CAT"].ToString();
                    cmbPartNO.Text = drReader["P_SIZE"].ToString();
                    txtRemark.Text = drReader["REMARK"].ToString();
                    lblTOTCOST.Text = drReader["TOT_COST_AMOUNT"].ToString();
                    txtA.Text = drReader["ADVANCE_1"].ToString();
                    txtB.Text = drReader["ADVANCE_2"].ToString();
                    txtC.Text = drReader["ADVANCE_3"].ToString();
                    txtAdvance.Text = (Money(txtA.Text) + Money(txtB.Text) + Money(txtC.Text)).ToString("0.00");
                    customerKey = CUS_ID.ToString();
                    txtD.Text = drReader["ADVANCE_4"].ToString();
                    txtE.Text = drReader["ADVANCE_5"].ToString();
                    txtF.Text = drReader["ADVANCE_6"].ToString();
                    txtG.Text = drReader["ADVANCE_7"].ToString();
                    txtH.Text = drReader["ADVANCE_8"].ToString();
                    txtI.Text = drReader["ADVANCE_9"].ToString();
                    txtJ.Text = drReader["ADVANCE_10"].ToString();

                    try
                    {
                        lblDA.Value = Convert.ToDateTime(drReader["PAID_DATE1"].ToString());
                        lblDB.Value = Convert.ToDateTime(drReader["PAID_DATE2"].ToString());
                        lblDC.Value = Convert.ToDateTime(drReader["PAID_DATE3"].ToString());
                        lblDD.Value = Convert.ToDateTime(drReader["PAID_DATE4"].ToString());
                        lblDE.Value = Convert.ToDateTime(drReader["PAID_DATE5"].ToString());
                        lblDF.Value = Convert.ToDateTime(drReader["PAID_DATE6"].ToString());
                        lblDG.Value = Convert.ToDateTime(drReader["PAID_DATE7"].ToString());
                        lblDH.Value = Convert.ToDateTime(drReader["PAID_DATE8"].ToString());
                        lblDI.Value = Convert.ToDateTime(drReader["PAID_DATE9"].ToString());
                        lblDJ.Value = Convert.ToDateTime(drReader["PAID_DATE10"].ToString());
                    }
                    catch (Exception)
                    {

                    }
                    txtINVNO.Focus();
                }
                if (drReader.HasRows == false)
                {
                    lblCusName.Focus();
                }
            }

            

            drReader.Close();
            _Conn.Close();
            FillMaterialItems(true);
            }
            finally
            {
                loadingJob = false;
                RefreshBalance();
                if (cmbPartNO.Text.Trim().Length > 0)
                {
                    Load_BALQTYS_PARTNO();
                    UOM();
                    ShowLiveStock();
                }
                if (lblSEQ.Text.Trim().Length > 0)
                {
                    ShowCustomerContact(lblSEQ.Text);
                }
                if (SEQ != 0)
                {
                    PlaceOperator();
                }
            }
        }

        private void CLEARDATA()
        {
            lblSEQ.Text = "";
            lblCusName.Text = "";

            SEQ = 0;
            txtNo.Text = "";
            txtQty.Text = "";
            cmbPartNO.Text = "";
            cmbCat.Text = "";
            cmbMethod.Text = "";
            cmbCat.Text = "";
            txtRemark.Text = "";
            cmbMethod.Text = "";
            lblTOTCOST.Text = "";
            ApplyToday();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (cmbType.Text == "" || txtNos.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                return;
            }

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;

            decimal Units = decimal.Parse(txtNos.Text);
            decimal UnitAmount = decimal.Parse(txtPrice.Text);
            decimal TOTAL = Units * UnitAmount;
            try
            {
                cmdsql1.CommandText = "INSERT INTO JOB_DESCRIPTION (SEQ_NO, JOB_TYPE, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '" + cmbType.Text + "', '" + txtNos.Text + "', '" + TOTAL + "', '" + dt_Start.Value + "')";
                cmdsql1.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Job already Entered, Select another Job");
                cmbType.Focus();
                return;
            }
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "UPDATE JOB_DETAILS SET INV_DATE = '" + DateTime.Now + "', INV_TIME = '" + DateTime.Now + "', INV_NO = '" + txtINVNO.Text + "', TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + TOTAL + "' WHERE (SEQ_NO = '" + SEQ + "')";
            cmdsql.ExecuteNonQuery();

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql2 = new SqlCommand();
            cmdsql2.Connection = _Conn;
            cmdsql2.CommandText = "UPDATE ISSUED_ITEMS SET INV_NO = '" + txtINVNO.Text + "' WHERE (SEQ_NO = '" + SEQ + "')";
            cmdsql2.ExecuteNonQuery();

            MessageBox.Show("Job Entry Successfully Added. Proceed to the Next Entry");
            _Conn.Close();

            cmbType.Focus();
            cmbType.Text = "";
            txtPrice.Text = "0.00";


           

            TOTCOST();
            ShowDetails();
            ShowDetailsB();
            StockShowDetails();

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            SHOW();

            btnComplete.Visible = false;
            decimal A = (decimal.Parse(lblTOTCOST.Text) / 100) * 50;
            lblA.Text = A.ToString();
            decimal B = (decimal.Parse(lblTOTCOST.Text) / 100) * 25;
            lblB.Text = B.ToString();
            decimal C = (decimal.Parse(lblTOTCOST.Text) / 100) * 25;
            lblC.Text = C.ToString();

            PAIDTOTS();

          


            //decimal A = (decimal.Parse(lblTOTCOST.Text)/100)*50;
            //decimal B = decimal.Parse(txtPrice.Text);
            //decimal C = A * B;



            TABA.Visible = true;
            decimal ABC = A + B + C;
            lblJobAmnt.Text = ABC.ToString();
            PAYTOT();

            if (txtA.Enabled == true)
            {
                txtA.Focus();
                txtA.SelectAll();
            }
            if (txtA.Enabled == false)
            {
                txtB.Focus();
                txtB.SelectAll();
            }
            if (txtB.Enabled == false)
            {
                txtC.Focus();
                txtC.SelectAll();
            }
        }

        private void PAYTOT()
        {
            try
            {
                decimal AA = decimal.Parse(txtA.Text);
                decimal BB = decimal.Parse(txtB.Text);
                decimal CC = decimal.Parse(txtC.Text);

                if (AA == 0)
                {
                    txtA.Enabled = true;
                    lblDA.Enabled = true;
                    txtB.Enabled = false;
                    lblDB.Enabled = false;
                    txtC.Enabled = false;
                    lblDC.Enabled = false;
                    return;
                }
                else if (AA != 0)
                {
                    txtA.Enabled = false;
                    lblDA.Enabled = false;
                    txtB.Enabled = true;
                    lblDB.Enabled = true;
                }

                if (BB == 0)
                {
                    txtA.Enabled = false;
                    lblDA.Enabled = false;
                    txtB.Enabled = true;
                    lblDB.Enabled = true;
                    txtC.Enabled = false;
                    lblDC.Enabled = false;
                    return;
                }
                else if (BB != 0)
                {
                    txtA.Enabled = false;
                    lblDA.Enabled = false;
                    txtB.Enabled = false;
                    lblDB.Enabled = false;
                    txtC.Enabled = true;
                    lblDC.Enabled = true;
                }

                if (CC == 0)
                {
                    txtA.Enabled = false;
                    lblDA.Enabled = false;
                    txtB.Enabled = false;
                    lblDB.Enabled = false;
                    txtC.Enabled = true;
                    lblDC.Enabled = true;
                    return;
                }
                else if (CC != 0)
                {
                    txtA.Enabled = false;
                    lblDA.Enabled = false;
                    txtB.Enabled = false;
                    lblDB.Enabled = false;
                    txtC.Enabled = false;
                    lblDC.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TABA.Visible = false;
        }

        private void PAIDTOTS()
        {
            try
            {
                decimal AAA = decimal.Parse(txtA.Text);
                decimal BBB = decimal.Parse(txtB.Text);
                decimal CCC = decimal.Parse(txtC.Text);

                TABA.Visible = true;
                decimal TOTS = AAA + BBB + CCC;
                lblD.Text = TOTS.ToString();
                txtABC.Text = TOTS.ToString();
                lblJobAmnt.Text = lblTOTCOST.Text;
                decimal BAL = decimal.Parse(lblJobAmnt.Text) - decimal.Parse(lblD.Text);
                lblBal.Text = BAL.ToString();
            }
            catch (Exception)
            {

            }

        }

        private void btnUPPAY_Click(object sender, EventArgs e)
        {
            if (txtA.Text == "" || txtA.Text == "0.00" || txtA.Text == "0")
            {

            }

            PAIDTOTS();

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;
            cmdsql1.CommandText = "UPDATE JOB_DETAILS SET ADVANCE_1 = '" + txtA.Text + "', ADVANCE_2 = '" + txtB.Text + "', ADVANCE_3 = '" + txtC.Text + "', PAID_DATE1 = '" + lblDA.Text + "', PAID_DATE2  = '" + lblDB.Text + "', PAID_DATE3  = '" + lblDC.Text + "' WHERE SEQ_NO = '" + SEQ + "'";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            dreader1.Close();


            ///////////////////// UPDATE DAY_EARNINGS ////////////////////////

            if (txtA.Text != "0.00")
            {
                try
                {
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();

                    SqlCommand cmdsqlA = new SqlCommand();
                    cmdsqlA.Connection = _Conn;
                    cmdsqlA.CommandText = "INSERT INTO DAY_EARNINGS(PRO_DATE, DESCRIPTION, AMOUNT, REMARKS)VALUES ('" + lblDA.Value + "', 'CASH', '" + txtA.Text + "', '-')";
                    SqlDataReader dreaderA = cmdsqlA.ExecuteReader();
                    dreaderA.Close();
                }
                catch (Exception)
                {
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();

                    SqlCommand cmdsqlB = new SqlCommand();
                    cmdsqlB.Connection = _Conn;
                    cmdsqlB.CommandText = "UPDATE DAY_EARNINGS SET AMOUNT = '" + txtA.Text + "' WHERE PRO_DATE = '" + lblDA.Value + "' AND DESCRIPTION = 'CASH'";
                    SqlDataReader dreaderB = cmdsqlB.ExecuteReader();
                    dreaderB.Close();

                }
            }

            if (txtB.Text != "0.00")
            {
                try
                {
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();

                    SqlCommand cmdsqlC = new SqlCommand();
                    cmdsqlC.Connection = _Conn;
                    cmdsqlC.CommandText = "INSERT INTO DAY_EARNINGS(PRO_DATE, DESCRIPTION, AMOUNT, REMARKS)VALUES ('" + lblDB.Value + "', 'CASH', '" + txtB.Text + "', '-')";
                    SqlDataReader dreaderC = cmdsqlC.ExecuteReader();
                    dreaderC.Close();
                }
                catch (Exception)
                {
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();

                    SqlCommand cmdsqlD = new SqlCommand();
                    cmdsqlD.Connection = _Conn;
                    cmdsqlD.CommandText = "UPDATE DAY_EARNINGS SET AMOUNT = '" + txtB.Text + "' WHERE PRO_DATE = '" + lblDB.Value + "' AND DESCRIPTION = 'CASH'";
                    SqlDataReader dreaderD = cmdsqlD.ExecuteReader();
                    dreaderD.Close();

                }
            }

            if (txtC.Text != "0.00")
            {
                try
                {
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();

                    SqlCommand cmdsqlE = new SqlCommand();
                    cmdsqlE.Connection = _Conn;
                    cmdsqlE.CommandText = "INSERT INTO DAY_EARNINGS(PRO_DATE, DESCRIPTION, AMOUNT, REMARKS)VALUES ('" + lblDC.Value + "', 'CASH', '" + txtC.Text + "', '-')";
                    SqlDataReader dreaderE = cmdsqlE.ExecuteReader();
                    dreaderE.Close();
                }
                catch (Exception)
                {
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();

                    SqlCommand cmdsqlF = new SqlCommand();
                    cmdsqlF.Connection = _Conn;
                    cmdsqlF.CommandText = "UPDATE DAY_EARNINGS SET AMOUNT = '" + txtC.Text + "' WHERE PRO_DATE = '" + lblDC.Value + "' AND DESCRIPTION = 'CASH'";
                    SqlDataReader dreaderF = cmdsqlF.ExecuteReader();
                    dreaderF.Close();

                }
            }

            ///////////////////// END DAY_EARNINGS ////////////////////////

            if (decimal.Parse(lblBal.Text) == 0)
            {
                btnComplete.Visible = true;
                btnComplete.Focus();
            }
            else
            {
                btnComplete.Visible = false;
            }
            MessageBox.Show("Payment Updated Successfully", "Payment Received Info");
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;
            cmdsql1.CommandText = "UPDATE JOB_DETAILS SET STATUS = 0 WHERE SEQ_NO = '" + SEQ + "'";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            dreader1.Close();

            SqlCommand cmdsql2 = new SqlCommand();
            cmdsql2.Connection = _Conn;
            cmdsql2.CommandText = "UPDATE ISSUED_ITEMS SET STATUS = 0 WHERE SEQ_NO = '" + SEQ + "'";
            SqlDataReader dreader2 = cmdsql2.ExecuteReader();
            dreader2.Close();

            SqlCommand cmdsql3 = new SqlCommand();
            cmdsql3.Connection = _Conn;
            cmdsql3.CommandText = "UPDATE EMPLOYEE_ALLOCATION SET STATUS = 0 WHERE SEQ_NO = '" + SEQ + "'";
            SqlDataReader dreader3 = cmdsql3.ExecuteReader();
            dreader3.Close();

            CLEARDATA();

            MessageBox.Show("Job Completed Successfully", "Job Info....");

            TABA.Visible = false;
        }

        private void Grid_A_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (cmbEmp.Text == "" || txtHours.Text == "" || txtRate.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                return;
            }

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;

            decimal EMPUnits = decimal.Parse(txtHours.Text);
            decimal EMPUnitAmount = decimal.Parse(txtRate.Text);
            decimal EMPTOTAL = EMPUnits * EMPUnitAmount;

            try
            {
                cmdsql1.CommandText = "INSERT INTO EMPLOYEE_ALLOCATION (SEQ_NO, EMP_NO, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '" + lblEMP.Text + "', '" + txtHours.Text + "', '" + EMPTOTAL + "', '" + dt_Start.Value + "')";
                cmdsql1.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Employee already Entered, Select another Employee");
                cmbEmp.Focus();
                return;
            }
            MessageBox.Show("Job Allocation is Successfull. Proceed to the Next Entry");
            _Conn.Close();

            cmbEmp.Focus();
            cmbEmp.Text = "";
            txtRate.Text = "0.00";
            txtHours.Text = "";
            ShowDetailsB();
        }

        private void cmbEmp_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT EMP_NO, EMP_RATE FROM dbo.EMPLOYEES WHERE (STATUS = 2) AND (EMP_NO + '  -   ' + INITIALS + ' ' + NAME = '" + cmbEmp.Text + "')", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                lblEMP.Text = drReader["EMP_NO"].ToString();
                txtRate.Text = drReader["EMP_RATE"].ToString();
            }
            drReader.Close();
            _Conn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT EMPLOYEES.INITIALS + '  ' + EMPLOYEES.NAME AS NAME,  EMPLOYEE_ALLOCATION.QTY, EMPLOYEE_ALLOCATION.QTY, EMPLOYEE_ALLOCATION.TOTAL, EMPLOYEE_ALLOCATION.DEL, EMPLOYEE_ALLOCATION.SEQ_NO, EMPLOYEE_ALLOCATION.SEQNO FROM EMPLOYEE_ALLOCATION INNER JOIN EMPLOYEES ON EMPLOYEE_ALLOCATION.EMP_NO = EMPLOYEES.EMP_NO WHERE SEQ_NO = '" + SEQ + "'", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "DELETE_ENTRY");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["DELETE_ENTRY"].Rows)
            {
                APRVD = Grid_B.Rows[count].Cells[4].Value.ToString();
                REMOVETOT = Convert.ToDecimal(Grid_B.Rows[count].Cells[3].Value.ToString());
                SEQNOD = Convert.ToInt32(Grid_B.Rows[count].Cells[5].Value.ToString());
                SEQNO = Convert.ToInt32(Grid_B.Rows[count].Cells[6].Value.ToString());

                if (APRVD == "True")
                {
                    try
                    {
                        SqlCommand cmdsql2 = new SqlCommand();
                        cmdsql2.Connection = _Conn;
                        cmdsql2.CommandText = "DELETE FROM EMPLOYEE_ALLOCATION WHERE (SEQNO = '" + SEQNO + "')";
                        SqlDataReader dreader2 = cmdsql2.ExecuteReader();
                        dreader2.Close();
                    }
                    catch (Exception)
                    {

                    }
                    _Conn.Dispose();
                }
                count++;
                _Conn = obyConn.Connect();
            }
            _Conn.Close();

            cmbType.Focus();

            ShowDetailsB();

            MessageBox.Show("Employee Allocation Records are Successfully Deleted", "Deleting Entries");
        }

        private void btn_Delete_Click_1(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT JOB_TYPE, QTY, TOTAL, DEL, SEQ_NO, SEQNO FROM JOB_DESCRIPTION WHERE SEQ_NO = '" + SEQ + "'", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "DELETE_ENTRY");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["DELETE_ENTRY"].Rows)
            {
                try
                {
                    APRVD = Grid_A.Rows[count].Cells[3].Value.ToString();
                    REMOVETOT = Convert.ToDecimal(Grid_A.Rows[count].Cells[2].Value.ToString());
                    SEQNOD = Convert.ToInt32(Grid_A.Rows[count].Cells[4].Value.ToString());
                    SEQNO = Convert.ToInt32(Grid_A.Rows[count].Cells[5].Value.ToString());
                    //INVNO = Grid_A.Rows[count].Cells[2].Value.ToString();
                }
                catch (Exception)
                {

                }

               

                if (APRVD == "True")
                {
                    try
                    {
                        SqlCommand cmdsql1 = new SqlCommand();
                        cmdsql1.Connection = _Conn;
                        cmdsql1.CommandText = "UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = TOT_COST_AMOUNT - '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
                        SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                        dreader1.Close();
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        SqlCommand cmdsql2 = new SqlCommand();
                        cmdsql2.Connection = _Conn;
                        cmdsql2.CommandText = "DELETE FROM JOB_DESCRIPTION WHERE (SEQNO = '" + SEQNO + "')";
                        SqlDataReader dreader2 = cmdsql2.ExecuteReader();
                        dreader2.Close();
                    }
                    catch (Exception)
                    {
                        //SqlCommand cmdsql1 = new SqlCommand();
                        //cmdsql1.Connection = _Conn;
                        //cmdsql1.CommandText = "UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
                        //SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                        //dreader1.Close();
                    }
                    //}
                    _Conn.Dispose();
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("Member Loan Can not be Deleted, Error.....", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                }
                count++;
                _Conn = obyConn.Connect();
            }
            _Conn.Close();

            cmbType.Focus();

            ShowDetails();

            TOTCOST();

            MessageBox.Show("Job Detail Records are Successfully Deleted", "Deleting Entries");
        }

        private void UP_STS()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT SUM(TOT) AS TOT FROM ISSUED_ITEMS GROUP BY SEQ HAVING (SEQ = '" + lblSEQ.Text + "')", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "ISSUED_ITEMS");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["ISSUED_ITEMS"].Rows)
            {
                try
                {
                    decimal TOT = decimal.Parse(dr["TOT"].ToString());
                    //INVNO = Grid_A.Rows[count].Cells[2].Value.ToString();

                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _Conn;
                    cmdsql1.CommandText = "UPDATE JOB_DETAILS SET STOCK_AMOUNT = '" + TOT + "' WHERE SEQ_NO = '" + lblSEQ.Text + "'";
                    SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                    dreader1.Close();
                }
                catch (Exception)
                {

                }
            }
            _Conn.Close();

        }

        private void UP_EMPS()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT SUM(TOTAL) AS TOT FROM EMPLOYEE_ALLOCATION GROUP BY SEQ_NO HAVING (SEQ_NO = '" + lblSEQ.Text + "')", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "EMPLOYEE_ALLOCATION");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["EMPLOYEE_ALLOCATION"].Rows)
            {
                try
                {
                    decimal TOT = decimal.Parse(dr["TOT"].ToString());
                    //INVNO = Grid_A.Rows[count].Cells[2].Value.ToString();

                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _Conn;
                    cmdsql1.CommandText = "UPDATE JOB_DETAILS SET EMP_AMOUNT = '" + TOT + "' WHERE SEQ_NO = '" + lblSEQ.Text + "'";
                    SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                    dreader1.Close();
                }
                catch (Exception)
                {

                }
            }
            _Conn.Close();

        }

        private bool HasPrintableJob()
        {
            string jobNo = txtNo.Text.Trim().Replace("'", "''");
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM JOB_DETAILS j INNER JOIN JOB_DESCRIPTION d ON d.SEQ_NO = j.SEQ_NO INNER JOIN CUSTOMER_INFO c ON CAST(c.SEQ_NO AS varchar(20)) = j.CUSTOMER_ID WHERE j.JOB_NO = '" + jobNo + "'", conn);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private bool PrepareJobForPrint()
        {
            if (txtNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("You have not assigned a Job. Assigne a Job & try again....", "Invalid Job", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            ResolveCustomer();
            if (HasPrintableJob())
            {
                return SettleExistingJob(false);
            }
            if (lblCusName.Text.Trim().Length == 0 || lblSEQ.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the customer, then print again.", "Invoice");
                return false;
            }
            decimal stockQty;
            decimal jobQty;
            bool hasStock = decimal.TryParse(lbl_BalQty.Text, out stockQty);
            bool hasQty = decimal.TryParse(txtQty.Text, out jobQty);
            if (hasStock && hasQty && stockQty < jobQty)
            {
                MessageBox.Show("Quantity not Enough for the Job", "Received Goods Info");
                return false;
            }
            bool saved = false;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _Conn;
                cmdsql1.CommandText = "INSERT INTO JOB_DETAILS (JOB_DATE, JOB_TIME, JOB_NO, CUSTOMER_ID, JOB_START_DATE, JOB_END_DATE, P_SIZE, QTY, P_METHOD, P_MEDIA, P_CAT, REMARK) VALUES ('" + DateTime.Now + "', '" + DateTime.Now + "', '" + txtNo.Text + "', '" + lblSEQ.Text + "', '" + dt_Start.Value + "', '" + dt_End.Value + "', '" + cmbPartNO.Text + "', '" + txtQty.Text + "', '" + cmbMethod.Text + "', '" + cmbCat.Text + "', '" + cmbCat.Text + "', '" + txtRemark.Text.Replace("'", "''") + "')";
                cmdsql1.ExecuteNonQuery();
                FindSEQ();
                SaveJobAmounts();
                SaveJobLine();
                SaveInvoiceIdentity();
                FindEmps();
                ShowDetails();
                ShowDetailsB();
                StockShowDetails();
                saved = true;
                draftSaved = true;
                DeleteJobDraft();
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.PrepareJobForPrint", ex);
                MessageBox.Show(ex.Message, "Invoice");
            }
            finally
            {
                if (_Conn != null)
                {
                    _Conn.Dispose();
                    _Conn = null;
                }
            }
            return saved;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            UP_STS();
            UP_EMPS();

            if (!PrepareJobForPrint())
            {
                return;
            }
            strCriteria = "Reports";

            this.Text = "Report Criteria for " + strCriteria;

            strReportName = "rpt_JobDetails";

            frm_Reports frm_Reports = new frm_Reports();
            CommonProfiles objComPro = new CommonProfiles();

            frm_Reports.GetReportCriteriaA(strReportName, strCriteria, txtNo.Text, SEQ);
            frm_Reports.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            txtNo.Focus();
            OfferJobDraft();
        }

        private static string JobDraftPath()
        {
            return Path.Combine(Application.StartupPath, "Drafts", "job-card.draft");
        }

        private void OfferJobDraft()
        {
            if (draftReady)
            {
                return;
            }
            if (string.IsNullOrEmpty(VVehicleNO) && File.Exists(JobDraftPath()))
            {
                DialogResult answer = MessageBox.Show("An unsaved job card draft was found. Would you like to restore it?", "Job card", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    RestoreJobDraft(JobDraftPath());
                }
            }
            BeginJobDraft();
        }

        private void BeginJobDraft()
        {
            draftReady = true;
            draftDirty = false;
            txtNo.TextChanged += MarkJobDraft;
            lblCusName.TextChanged += MarkJobDraft;
            lblSEQ.TextChanged += MarkJobDraft;
            dt_Start.ValueChanged += MarkJobDraft;
            dt_End.ValueChanged += MarkJobDraft;
            cmbMethod.TextChanged += MarkJobDraft;
            cmbCat.TextChanged += MarkJobDraft;
            cmbPartNO.TextChanged += MarkJobDraft;
            txtQty.TextChanged += MarkJobDraft;
            txtSPAMNT.TextChanged += MarkJobDraft;
            txtRemark.TextChanged += MarkJobDraft;
            txtAdvance.TextChanged += MarkJobDraft;
            this.Deactivate += JobDraftLeave;
            this.FormClosing += JobDraftClosing;
            draftTimer = new System.Windows.Forms.Timer();
            draftTimer.Interval = 3000;
            draftTimer.Tick += JobDraftTick;
            draftTimer.Start();
        }

        private void MarkJobDraft(object sender, EventArgs e)
        {
            if (draftReady && !draftSaved)
            {
                draftDirty = true;
            }
        }

        private void JobDraftTick(object sender, EventArgs e)
        {
            WriteJobDraft();
        }

        private void JobDraftLeave(object sender, EventArgs e)
        {
            WriteJobDraft();
        }

        private void JobDraftClosing(object sender, FormClosingEventArgs e)
        {
            WriteJobDraft();
        }

        private void WriteJobDraft()
        {
            if (!draftReady || !draftDirty || draftSaved)
            {
                return;
            }
            try
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Drafts"));
                string[] lines = new string[]
                {
                    "JobNo=" + EscapeDraft(txtNo.Text),
                    "Customer=" + EscapeDraft(lblCusName.Text),
                    "Seq=" + EscapeDraft(lblSEQ.Text),
                    "Start=" + dt_Start.Value.ToString("yyyy-MM-dd"),
                    "End=" + dt_End.Value.ToString("yyyy-MM-dd"),
                    "Method=" + EscapeDraft(cmbMethod.Text),
                    "Category=" + EscapeDraft(cmbCat.Text),
                    "Part=" + EscapeDraft(cmbPartNO.Text),
                    "Qty=" + EscapeDraft(txtQty.Text),
                    "UnitPrice=" + EscapeDraft(txtSPAMNT.Text),
                    "Advance=" + EscapeDraft(txtAdvance.Text),
                    "Remark=" + EscapeDraft(txtRemark.Text)
                };
                File.WriteAllLines(JobDraftPath(), lines);
                draftDirty = false;
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.Draft", ex);
            }
        }

        private void RestoreJobDraft(string path)
        {
            try
            {
                Dictionary<string, string> map = new Dictionary<string, string>();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    int split = line.IndexOf('=');
                    if (split <= 0)
                    {
                        continue;
                    }
                    map[line.Substring(0, split)] = UnescapeDraft(line.Substring(split + 1));
                }
                loadingJob = true;
                txtNo.Text = DraftValue(map, "JobNo");
                lblCusName.Text = DraftValue(map, "Customer");
                lblSEQ.Text = DraftValue(map, "Seq");
                cmbMethod.Text = DraftValue(map, "Method");
                cmbCat.Text = DraftValue(map, "Category");
                cmbPartNO.Text = DraftValue(map, "Part");
                txtQty.Text = DraftValue(map, "Qty");
                txtSPAMNT.Text = DraftValue(map, "UnitPrice");
                txtRemark.Text = DraftValue(map, "Remark");
                txtAdvance.Text = DraftValue(map, "Advance");
                DateTime start;
                if (DateTime.TryParse(DraftValue(map, "Start"), out start))
                {
                    dt_Start.Value = start;
                }
                DateTime end;
                if (DateTime.TryParse(DraftValue(map, "End"), out end))
                {
                    dt_End.Value = end;
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.Draft", ex);
            }
            finally
            {
                loadingJob = false;
                RefreshBalance();
            }
        }

        private static string DraftValue(Dictionary<string, string> map, string key)
        {
            string value;
            if (map.TryGetValue(key, out value))
            {
                return value;
            }
            return "";
        }

        private static string EscapeDraft(string value)
        {
            if (value == null)
            {
                return "";
            }
            return value.Replace("\\", "\\\\").Replace("\r", "").Replace("\n", "\\n");
        }

        private static string UnescapeDraft(string value)
        {
            if (value == null)
            {
                return "";
            }
            return value.Replace("\\n", "\n").Replace("\\\\", "\\");
        }

        private void DeleteJobDraft()
        {
            try
            {
                string path = JobDraftPath();
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.Draft", ex);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_IssueGoods frm_IGOODS = new frm_IssueGoods();
            frm_IGOODS.VehicleNO = txtNo.Text;
            frm_IGOODS.SEQ__NO = SEQ;
            frm_IGOODS.Show();
        }

        private void dt_End_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbMethod.Focus();

            }
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                button2.Focus();
            }
        }

        private void cmbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtNos.Focus();
            }
        }

        private void txtNos_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtPrice.Focus();
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                button6.Focus();
            }
        }

        private void cmbEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtHours.Focus();
            }
        }

        private void txtHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtRate.Focus();
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                button9.Focus();
            }
        }

        private void cmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();

            //SqlCommand cmdReader = new SqlCommand("SELECT AMOUNT FROM JOB_TYPE WHERE JOB_TYPE = '" + cmbType.Text + "'", _Conn);
            //SqlDataReader drReader = cmdReader.ExecuteReader();
            //while (drReader.Read())
            //{
            //    txtPrice.Text = drReader["AMOUNT"].ToString(); // + " - " + drTenMain["NAME"].ToString());
            //}
            //drReader.Close();
            //_Conn.Close();
        }


        private void cmbEmp_Enter(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (tabPage3.Text == "  ALLOCATE EMPLOYEE  -  ")
            {
                cmbEmp.Focus();
                //cmbEmp.DroppedDown = true;
                timer2.Enabled = false;
            }
            if (tabPage2.Text == "   JOB DESCRIPTION  -  ")
            {
                cmbType.Focus();
                //cmbType.DroppedDown = true;
                timer2.Enabled = false;

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();
            //SqlCommand cmdsql1 = new SqlCommand();
            //cmdsql1.Connection = _Conn;

            ////decimal Units = decimal.Parse(txtNoR.Text);
            ////decimal UnitAmount = decimal.Parse(txtCostR.Text);
            ////decimal TOTAL = Units * UnitAmount;

            //try
            //{
            //    cmdsql1.CommandText = "INSERT INTO JOB_ACCIDENT_REPAIR (SEQ_NO, MAIN_CAT, SUB_CAT, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '" + lblMain.Text + "', '" + lblSub.Text + "', '" + txtNoR.Text + "', '" + TOTAL + "', '" + dt_Start.Value + "')";
            //    cmdsql1.ExecuteNonQuery();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Accident Repair already Entered, Select another Job");
            //    cmbType.Focus();
            //    return;
            //}

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();
            //SqlCommand cmdsql = new SqlCommand();
            //cmdsql.Connection = _Conn;
            //cmdsql.CommandText = "UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + TOTAL + "' WHERE (SEQ_NO = '" + SEQ + "')";
            //cmdsql.ExecuteNonQuery();

            //MessageBox.Show("Job Entry Successfully Added. Proceed to the Next Entry");
            //_Conn.Close();

            //cmbMain.Focus();
            //cmbMain.Text = "";
            //cmbSub.Text = "";
            //txtCostR.Text = "0.00";

            //ShowDetailsC();

            //TOTCOST();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();

            //SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT MAIN_CAT, SUB_CAT, QTY, TOTAL, DEL, SEQ_NO, SEQNO FROM JOB_ACCIDENT_REPAIR WHERE SEQ_NO = '" + SEQ + "' AND SUB_CAT <> '-'", _Conn);
            //SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            //DataSet thisDataset = new DataSet();

            //thisAdapter.Fill(thisDataset, "DELETE_ENTRY");

            //int count = 0;

            //foreach (DataRow dr in thisDataset.Tables["DELETE_ENTRY"].Rows)
            //{
            //    APRVD = Grid_C.Rows[count].Cells[4].Value.ToString();
            //    REMOVETOT = Convert.ToDecimal(Grid_C.Rows[count].Cells[3].Value.ToString());
            //    SEQNOD = Convert.ToInt32(Grid_C.Rows[count].Cells[5].Value.ToString());
            //    SEQNO = Convert.ToInt32(Grid_C.Rows[count].Cells[6].Value.ToString());
            //    //INVNO = Grid_C.Rows[count].Cells[2].Value.ToString();

            //    if (APRVD == "True")
            //    {
            //        try
            //        {
            //            SqlCommand cmdsql1 = new SqlCommand();
            //            cmdsql1.Connection = _Conn;
            //            cmdsql1.CommandText = "UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = TOT_COST_AMOUNT - '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
            //            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            //            dreader1.Close();
            //        }
            //        catch (Exception)
            //        {

            //        }

            //        try
            //        {
            //            SqlCommand cmdsql2 = new SqlCommand();
            //            cmdsql2.Connection = _Conn;
            //            cmdsql2.CommandText = "DELETE FROM JOB_ACCIDENT_REPAIR WHERE (SEQNO = '" + SEQNO + "')";
            //            SqlDataReader dreader2 = cmdsql2.ExecuteReader();
            //            dreader2.Close();
            //        }
            //        catch (Exception)
            //        {
            //            SqlCommand cmdsql1 = new SqlCommand();
            //            cmdsql1.Connection = _Conn;
            //            cmdsql1.CommandText = "UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
            //            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            //            dreader1.Close();
            //        }
            //        //}
            //        _Conn.Dispose();
            //        //}
            //        //catch (Exception)
            //        //{
            //        //    MessageBox.Show("Member Loan Can not be Deleted, Error.....", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //    return;
            //        //}
            //    }
            //    count++;
            //    _Conn = obyConn.Connect();
            //}
            //_Conn.Close();

            //cmbType.Focus();

            //ShowDetailsC();

            //TOTCOST();

            //MessageBox.Show("Job Detail Records are Successfully Deleted", "Deleting Entries");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frm_JobType frmGenq = new frm_JobType();
            frmGenq.TopMost = true;
            frmGenq.Show();
            //this.Hide();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            frm_JobMainCat frmJM = new frm_JobMainCat();
            frmJM.TopMost = true;
            frmJM.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            frm_JobSubCat frmJS = new frm_JobSubCat();
            frmJS.TopMost = true;
            frmJS.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            frm_EmployeeDetails frmEmp = new frm_EmployeeDetails();
            frmEmp.TopMost = true;
            frmEmp.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            FillDGV("");
        }

        public void FillDGV(string valueToSearch)
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();

            //SqlCommand command = new SqlCommand("SELECT * FROM PHOTOS WHERE VEHICLE_NO = '"+ SEQ +"'", _Conn);

            //SqlDataAdapter adapter = new SqlDataAdapter(command);

            //DataTable table = new DataTable();

            //adapter.Fill(table);

            //dataGridView1.RowTemplate.Height = 100;

            //dataGridView1.AllowUserToAddRows = false;

            //dataGridView1.DataSource = table;

            //dataGridView1.Columns[0].Visible = false;
            ////dataGridView1.Columns[2].Visible = false;

            //Grid_B.Columns[2].Width = 40;
            //Grid_B.Columns[3].Width = 150;

            //DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            //imgCol = (DataGridViewImageColumn)dataGridView1.Columns[1];
            //imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button25_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(opf.FileName);
                    A = opf.FileName.ToString();
                    //txtPath.Text = A.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Size of the Picture is too large or Not a supported Format");
                }
            }

            //Byte[] img = (Byte[])dataGridView1.CurrentRow.Cells[3].Value;

            //MemoryStream ms = new MemoryStream(img);

            //pictureBox1.Image = Image.FromStream(ms);

            //textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //textBox22.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //textBox23.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            SqlCommand command = new SqlCommand("INSERT INTO PHOTOS(VEHICLE_NO, FILE_NAME, IMAGE) VALUES (@id,@name,@img)", _Conn);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = SEQ;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = A.ToString();
            command.Parameters.Add("@img", SqlDbType.Image).Value = img;

            ExecMyQuery(command, "Data Inserted");

        }

        private void button27_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            SqlCommand command = new SqlCommand("UPDATE PHOTOS SET VEHICLE_NO=@id, FILE_NAME=@name, IMAGE=@img WHERE ID = @id", _Conn);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = SEQ;
            //command.Parameters.Add("@name", SqlDbType.VarChar).Value = A.ToString;
            //command.Parameters.Add("@img", SqlDbType.Blob).Value = img;

            ExecMyQuery(command, "Data Updated");
        }

        public void ExecMyQuery(SqlCommand mcomd, string myMsg)
        {
            try
            {
                _Conn.Open();
            }
            catch (Exception)
            {

            }
                
            
            if (mcomd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(myMsg);
            }
            else
            {
                MessageBox.Show("Query Not Executed");
            }

            FillDGV("");
            _Conn.Close();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM PHOTOS WHERE VEHICLE_NO = @id", _Conn);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = SEQ;

            ExecMyQuery(command, "Data Deleted");

            ClearFields();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            FillDGV(txtPath.Text);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM PHOTOS WHERE IMAGE1 = @id", _Conn);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = SEQ;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("No Data Found");
                ClearFields();
            }
            else
            {

                txtNo.Text = table.Rows[0][0].ToString();
                txtPath.Text = table.Rows[0][1].ToString();
                //pictureBox1.Image = table.Rows[0][2].ToString();

                byte[] img = (byte[])table.Rows[0][3];
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);

            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            tb3.Visible = false;
            ClearFields();
        }

        public void ClearFields()
        {
            pictureBox1.Image = null;

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            Byte[] img = (Byte[])dataGridView1.CurrentRow.Cells[1].Value;

            MemoryStream ms = new MemoryStream(img);

            pictureBox1.Image = Image.FromStream(ms);

            //SEQ = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPath.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //pictureBox1.Image = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (tb3.Visible == false)
            {
                tb3.Visible = true;
            }
            else if (tb3.Visible == true)
            {
                tb3.Visible = false;
            }
        }


        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btnUPPAY.Focus();
            }
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btnUPPAY.Focus();
            }
        }

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btnUPPAY.Focus();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbType_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtPrice.Focus();
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //if (txtSpare.Text == "" || txtSPAMNT.Text == "")
            //{
            //    MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
            //    return;
            //}

            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();
            //SqlCommand cmdsql1 = new SqlCommand();
            //cmdsql1.Connection = _Conn;

            //decimal Units = 1;
            //decimal UnitAmount = decimal.Parse(txtSPAMNT.Text);
            //decimal TOTAL = Units * UnitAmount;
            //try
            //{
            //    cmdsql1.CommandText = "INSERT INTO JOB_REPLACED_SPARES (SEQ_NO, JOB_TYPE, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '" + txtSpare.Text + "', '1', '" + TOTAL + "', '" + dt_Start.Value + "')";
            //    cmdsql1.ExecuteNonQuery();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Job already Entered, Select another Job");
            //    cmbType.Focus();
            //    return;
            //}
            ////obyConn = new Connection.DatabaseConnection();
            ////_Conn = obyConn.Connect();
            ////SqlCommand cmdsql = new SqlCommand();
            ////cmdsql.Connection = _Conn;
            ////cmdsql.CommandText = "UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + TOTAL + "' WHERE (SEQ_NO = '" + SEQ + "')";
            ////cmdsql.ExecuteNonQuery();

            //MessageBox.Show("Job Spare Part Replacement Successfully Added. Proceed to the Next Entry");
            //_Conn.Close();

            //txtSpare.Focus();
            //txtSpare.Text = "";
            //txtSPAMNT.Text = "0.00";

            //ShowDetailsD();

            //TOTCOST();

        }

        private void button41_Click(object sender, EventArgs e)
        {
            FindEmps();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void button38_Click_1(object sender, EventArgs e)
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();

            //SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT JOB_TYPE, QTY, TOTAL, DEL, SEQ_NO, SEQNO  FROM JOB_REPLACED_SPARES WHERE SEQ_NO = '" + SEQ + "' AND JOB_TYPE <> '-'", _Conn);
            //SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            //DataSet thisDataset = new DataSet();

            //thisAdapter.Fill(thisDataset, "DELETE_ENTRY");

            //int count = 0;

            //foreach (DataRow dr in thisDataset.Tables["DELETE_ENTRY"].Rows)
            //{
            //    APRVD = Grid_D.Rows[count].Cells[3].Value.ToString();
            //    REMOVETOT = Convert.ToDecimal(Grid_D.Rows[count].Cells[2].Value.ToString());
            //    SEQNOD = Convert.ToInt32(Grid_D.Rows[count].Cells[4].Value.ToString());
            //    SEQNO = Convert.ToInt32(Grid_D.Rows[count].Cells[5].Value.ToString());
            //    //INVNO = Grid_D.Rows[count].Cells[2].Value.ToString();

            //    if (APRVD == "True")
            //    {
            //        try
            //        {
            //            ////SqlCommand cmdsql1 = new SqlCommand();
            //            ////cmdsql1.Connection = _Conn;
            //            ////cmdsql1.CommandText = "UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = TOT_COST_AMOUNT - '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
            //            ////SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            //            ////dreader1.Close();
            //        }
            //        catch (Exception)
            //        {

            //        }

            //        try
            //        {
            //            SqlCommand cmdsql2 = new SqlCommand();
            //            cmdsql2.Connection = _Conn;
            //            cmdsql2.CommandText = "DELETE FROM JOB_REPLACED_SPARES WHERE (SEQNO = '" + SEQNO + "')";
            //            SqlDataReader dreader2 = cmdsql2.ExecuteReader();
            //            dreader2.Close();
            //        }
            //        catch (Exception)
            //        {
            //            SqlCommand cmdsql1 = new SqlCommand();
            //            cmdsql1.Connection = _Conn;
            //            cmdsql1.CommandText = "UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
            //            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            //            dreader1.Close();
            //        }
            //        //}
            //        _Conn.Dispose();
            //        //}
            //        //catch (Exception)
            //        //{
            //        //    MessageBox.Show("Member Loan Can not be Deleted, Error.....", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //    return;
            //        //}
            //    }
            //    count++;
            //    _Conn = obyConn.Connect();
            //}
            //_Conn.Close();

            //cmbType.Focus();

            //ShowDetailsD();

            //TOTCOST();

            //MessageBox.Show("Spare Parts are Successfully Deleted", "Deleting Entries");
        }

        private void Grid_B_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dt_Start_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                dt_End.Focus();
            }
        }

        private void txtMile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                button2.Focus();
            }
        }

        private void lblCusName_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbMethod_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbMedia.Focus();
            }
        }

        private void cmbMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbCat.Focus();
            }
        }

        private void cmbCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbPartNO.Focus();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cmbSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtQty.Focus();
            }
        }

        private void ADD()
        {
            if (txtSpare.Text == "" || txtSPAMNT.Text == "")
            {
                //MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                return;
            }

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;

            decimal Units = decimal.Parse(txt_Qty.Text); ;
            decimal UnitAmount = decimal.Parse(txtSPAMNT.Text);
            decimal TOTAL = Units * UnitAmount;
            try
            {
                cmdsql1.CommandText = "INSERT INTO JOB_REPLACED_SPARES (SEQ_NO, JOB_TYPE, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '" + txtSpare.Text + "', '" + Units + "', '" + TOTAL + "', '" + dt_Start.Value + "')";
                cmdsql1.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //MessageBox.Show("Job already Entered, Select another Job");
                cmbType.Focus();
                return;
            }

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + TOTAL + "' WHERE (SEQ_NO = '" + SEQ + "')";
            cmdsql.ExecuteNonQuery();

            //MessageBox.Show("Job Spare Part Replacement Successfully Added. Proceed to the Next Entry");
            _Conn.Close();

            TOTCOST();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                try
                {

                //    {
                //    decimal V = Math.Round(decimal.Parse(txtSPAMNT.Text) / 5, 0) * 5;
                //    decimal Q = decimal.Parse(txt_Qty.Text);
                //    decimal T = Math.Round(V * Q / 5, 0) * 5;
                //    txtSPAMNT.Text = Convert.ToDecimal(V).ToString("###,###,###");
                //}
                //catch (Exception)
                //{

                //}
                    //decimal V = Math.Round(decimal.Parse(lblLastPrice.Text) / 5, 0) * 5;
                    //decimal Q = decimal.Parse(txt_Qty.Text);
                    //decimal T = Math.Round(V * Q / 5, 0) * 5;
                    //txt_Price.Text = Convert.ToDecimal(V).ToString("###,###,###");
                    //lblShow.Text = Convert.ToDecimal(T).ToString("###,###,###");

                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "SELECT BAL_QTY, ISSUE_PRICE / QTY AS ISSUE, PRICE FROM RECEIVED_ITEMS WHERE (PARTNO = '" + cmbPartNO.Text + "') AND STATUS = 1";
                    SqlDataReader dreader = cmdsql.ExecuteReader();
                    while (dreader.Read())
                    {
                        decimal V = decimal.Parse(dreader["ISSUE"].ToString());
                        txt_Price.Text = Convert.ToDecimal(V).ToString("#########.00");
                    }
                    cmdsql.Dispose();
                    dreader.Dispose();
                    _Conn.Close();
                }
                catch (Exception)
                {
                }

                txtRemark.Focus();
            }




            if (cmbPartNO.Text == "" || txtQty.Text == "" || txtSPAMNT.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                txtSpare.Focus();
                return;
            }

            try
            {
             QTY = decimal.Parse(txt_Qty.Text);
            if (lbl_BalQty.Text == "-")
            {
                lbl_BalQty.Text = "0";
            }
            BAL_QTY = decimal.Parse(lbl_BalQty.Text);

            if (BAL_QTY > 0)
            {
                if (QTY > BAL_QTY)
                {
                    MessageBox.Show("Please Enter Less Issue Amount to Proceed", "Issue Goods Info");
                    return;
                }
            }

            if (txtSPAMNT.Text == "" || txt_Qty.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Issue Goods Info");
                return;
            }

            CALQTY = Convert.ToDecimal(txt_Qty.Text);
            CALUNIT = Convert.ToDecimal(txtSPAMNT.Text);

            TOTCALQTY = CALQTY;

            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;
            cmdsql1.CommandText = "SELECT SEQ_NO, PARTNO, QTY, BAL_QTY, S_NO, TOT, ISSUE_PRICE, STATUS FROM RECEIVED_ITEMS WHERE (PARTNO = '" + txtSpare.Text + "') AND (STATUS = 1)ORDER BY SEQ_NO";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                {
                    SEQ_NO = Convert.ToInt16(dreader1["SEQ_NO"].ToString().Trim());
                    QTY = Convert.ToDecimal(dreader1["QTY"].ToString().Trim());
                    BAL_QTY = Convert.ToDecimal(dreader1["BAL_QTY"].ToString().Trim());
                    //ISSUE_P = Convert.ToDecimal(dreader["ISSUE_PRICE"].ToString());
                    TOT_ISSUE = CALUNIT * TOTCALQTY;


                    if (TOTCALQTY != 0)
                    {
                        if (BAL_QTY > TOTCALQTY)
                        {
                            SqlCommand cmdsql5 = new SqlCommand();
                            cmdsql5.Connection = _Conn;
                            CALVAL = CALUNIT * TOTCALQTY;
                            cmdsql5.CommandText = "INSERT INTO ISSUED_ITEMS (SEQ, SYS_USER, PARTNO, ORGQTY, QTY, PRICE, REMARKS, PRO_DATE, TOT, STATUS, RECEIVE_SEQNO, PRO_TIME) VALUES ('" + SEQ + "', '" + lblUser.Text + "', '" + txtSpare.Text + "','" + QTY + "', '" + TOTCALQTY + "','" + CALUNIT + "', '" + txtRemarks.Text + "',Convert(DateTime,'" + lblDate.Text + "'),'" + TOT_ISSUE + "', '1', '" + SEQ_NO + "', '" + DateTime.Now + "')";
                            cmdsql5.ExecuteNonQuery();

                            SqlCommand cmdsql2 = new SqlCommand();
                            cmdsql2.Connection = _Conn;
                            cmdsql2.CommandText = "UPDATE RECEIVED_ITEMS SET BAL_QTY = '" + (BAL_QTY - TOTCALQTY) + "' WHERE SEQ_NO = '" + SEQ_NO + "'";
                            cmdsql2.ExecuteNonQuery();

                            TOTCALQTY = TOTCALQTY - TOTCALQTY;

                            ADD();
                        }

                        if (BAL_QTY <= TOTCALQTY)
                        {
                            SqlCommand cmdsql9 = new SqlCommand();
                            cmdsql9.Connection = _Conn;

                            ENDCAL = CALUNIT * BAL_QTY;

                            cmdsql9.CommandText = "INSERT INTO ISSUED_ITEMS (SEQ, SYS_USER, PARTNO, ORGQTY, QTY, PRICE, REMARKS, PRO_DATE, TOT, STATUS, RECEIVE_SEQNO, PRO_TIME) VALUES ('" + SEQ + "', '" + lblUser.Text + "', '" + txtSpare.Text + "','" + QTY + "', '" + BAL_QTY + "', '" + CALUNIT + "','" + txtRemarks.Text + "',Convert(DateTime,'" + lblDate.Text + "'),'" + ENDCAL + "', '1', '" + SEQ_NO + "', '" + DateTime.Now + "')";
                            cmdsql9.ExecuteNonQuery();

                            SqlCommand cmdsql2 = new SqlCommand();
                            cmdsql2.Connection = _Conn;
                            cmdsql2.CommandText = "UPDATE RECEIVED_ITEMS SET BAL_QTY = '0', STATUS = '0' WHERE SEQ_NO = '" + SEQ_NO + "'";
                            cmdsql2.ExecuteNonQuery();
                            TOTCALQTY = TOTCALQTY - BAL_QTY;

                            ADD();
                        }
                    }
                }
            }


            MessageBox.Show("Items Issue Entry Successfully Added");
        }
        catch (Exception)
        {
            MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Issue Goods Info");
            return;
        }
            _Conn.Close();
            ShowDetails();
            //ClearData();
            btn_Save.Enabled = false;


            Load_BALQTYS();

            txtSPAMNT.Text = "0.00";
            txt_Qty.Text = "";
            txtSPAMNT.ResetText();
            txtSpare.Focus();
        }

        private void lblCusName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                ResolveCustomer();
            }
        }

        private void lblCusName_Leave(object sender, EventArgs e)
        {
            ResolveCustomer();
        }

        private void cmbPartNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtQty.Focus();
            }
        }

        private void Load_BALQTYS_PARTNO()
        {
            lblBalQty.Text = "0.00";
            if (cmbPartNO.Text.Trim().Length == 0)
            {
                return;
            }
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand("SELECT ISNULL(SUM(CASE WHEN ISNUMERIC(r.BAL_QTY) = 1 THEN CAST(r.BAL_QTY AS decimal(18,2)) ELSE 0 END), 0) FROM RECEIVED_ITEMS r WHERE r.STATUS = 1 AND (r.PARTNO = @item OR EXISTS (SELECT 1 FROM MASTER m WHERE m.PARTNO = r.PARTNO AND m.DESCRIPTION = @item))", conn);
                cmdsql.Parameters.Add("@item", SqlDbType.VarChar, 100).Value = cmbPartNO.Text.Trim();
                object value = cmdsql.ExecuteScalar();
                decimal qty = 0;
                if (value != null && value != DBNull.Value)
                {
                    decimal.TryParse(value.ToString(), out qty);
                }
                lblBalQty.Text = qty.ToString("0.00");
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.Load_BALQTYS_PARTNO", ex);
                lblBalQty.Text = "0.00";
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void UOM()
        {
            lblUOM.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT TOP 1 UOM FROM MASTER WHERE PARTNO = @item OR DESCRIPTION = @item";
            cmdsql.Parameters.Add("@item", SqlDbType.VarChar, 100).Value = cmbPartNO.Text.Trim();
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblUOM.Text = dreader["UOM"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void cmbPartNO_SelectedValueChanged(object sender, EventArgs e)
        {
            if (loadingJob || fillingCatalog)
            {
                return;
            }
            Load_BALQTYS_PARTNO();
            UOM();
            ShowLiveStock();
        }

        private void ShowLiveStock()
        {
            availableStock = 0;
            stockKnown = false;
            if (cmbPartNO.Text.Trim().Length == 0)
            {
                RefreshStockLabel();
                return;
            }
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand("SELECT ISNULL(SUM(CASE WHEN ISNUMERIC(r.BAL_QTY) = 1 THEN CAST(r.BAL_QTY AS decimal(18,2)) ELSE 0 END), 0) FROM RECEIVED_ITEMS r WHERE r.STATUS = 1 AND (r.PARTNO = @item OR EXISTS (SELECT 1 FROM MASTER m WHERE m.PARTNO = r.PARTNO AND m.DESCRIPTION = @item))", conn);
                cmdsql.Parameters.Add("@item", SqlDbType.VarChar, 100).Value = cmbPartNO.Text.Trim();
                object value = cmdsql.ExecuteScalar();
                if (value != null && value != DBNull.Value)
                {
                    decimal.TryParse(value.ToString(), out availableStock);
                }
                stockKnown = true;
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.ShowLiveStock", ex);
                stockKnown = false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
            RefreshStockLabel();
        }

        private void RefreshStockLabel()
        {
            if (lblStockHint == null)
            {
                return;
            }
            if (!stockKnown)
            {
                lblStockHint.Text = "";
                return;
            }
            decimal jobQty;
            if (!decimal.TryParse(txtQty.Text, out jobQty))
            {
                jobQty = 0;
            }
            string count = decimal.Truncate(availableStock).ToString("0");
            if (jobQty > availableStock)
            {
                lblStockHint.ForeColor = Color.Red;
                lblStockHint.Text = "Insufficient Stock! Available: " + count + " Nos";
            }
            else
            {
                lblStockHint.ForeColor = Color.ForestGreen;
                lblStockHint.Text = "In Stock: " + count + " Nos";
            }
        }

        private bool StockAllowsSale()
        {
            decimal jobQty;
            if (!decimal.TryParse(txtQty.Text, out jobQty))
            {
                return true;
            }
            if (!stockKnown)
            {
                ShowLiveStock();
            }
            if (stockKnown && jobQty > availableStock)
            {
                MessageBox.Show("There is not enough stock for this quantity. Available: " + decimal.Truncate(availableStock).ToString("0") + " Nos.", "Job Card");
                return false;
            }
            return true;
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            lblShow.Text = "";

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT ISSUED_ITEMS.PARTNO, MASTER.DESCRIPTION, ISSUED_ITEMS.QTY, ISSUED_ITEMS.PRICE, ISSUED_ITEMS.TOT, ISSUED_ITEMS.S_NO, ISSUED_ITEMS.STATUS, ISSUED_ITEMS.DEL, ISSUED_ITEMS.SEQ_NO, ISSUED_ITEMS.SEQ FROM ISSUED_ITEMS INNER JOIN MASTER ON ISSUED_ITEMS.PARTNO = MASTER.PARTNO WHERE (ISSUED_ITEMS.STATUS = 1) AND (ISSUED_ITEMS.SEQ = '" + SEQ + "')ORDER BY ISSUED_ITEMS.SEQ_NO DESC", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "DELETE_ENTRY");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["DELETE_ENTRY"].Rows)
            {
                APRVD = Grid_A.Rows[count].Cells[8].Value.ToString();
                //SEQNO = Convert.ToInt32(Grid_A.Rows[count].Cells[8].Value.ToString());
                SEQNOD = Convert.ToInt32(Grid_A.Rows[count].Cells[9].Value.ToString());
                //INVNO = Grid_A.Rows[count].Cells[2].Value.ToString();

                if (APRVD == "True")
                {
                    //try

                    //Connection.DatabaseConnection obyConn;
                    //obyConn = new Connection.DatabaseConnection();
                    //_Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "SELECT RECEIVE_SEQNO, QTY, PRICE, TOT FROM ISSUED_ITEMS WHERE SEQ_NO = '" + SEQNOD + "'";
                    SqlDataReader dreader = cmdsql.ExecuteReader();
                    while (dreader.Read())
                    {
                        RSEQ = int.Parse(dreader["RECEIVE_SEQNO"].ToString());
                        QTYD = decimal.Parse(dreader["QTY"].ToString());

                    }
                    cmdsql.Dispose();
                    dreader.Dispose();

                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _Conn;
                    cmdsql1.CommandText = "UPDATE RECEIVED_ITEMS SET BAL_QTY = BAL_QTY + '" + QTYD + "', STATUS = 1 WHERE SEQ_NO = '" + RSEQ + "'";
                    SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                    dreader1.Close();

                    SqlCommand cmdsql2 = new SqlCommand();
                    cmdsql2.Connection = _Conn;
                    cmdsql2.CommandText = "DELETE FROM ISSUED_ITEMS WHERE SEQ_NO = '" + SEQNOD + "'";
                    SqlDataReader dreader2 = cmdsql2.ExecuteReader();
                    dreader2.Close();

                    //}
                    _Conn.Dispose();
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("Member Loan Can not be Deleted, Error.....", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                }
                count++;
                _Conn = obyConn.Connect();
            }
            _Conn.Close();
            StockShowDetails();
            Load_BALQTYS_PARTNO();
            MessageBox.Show("Records are Successfully Deleted", "Deleting Entries");
            //TOTAMOUNTS();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            DefaultBlankAdvance();
            if (!PrepareJobForPrint())
            {
                blankAdvanceOnPrint = false;
                return;
            }
            blankAdvanceOnPrint = false;
            strCriteria = "Reports";

            this.Text = "Report Criteria for " + strCriteria;

            strReportName = "rpt_Invoice";

            frm_Reports frm_Reports = new frm_Reports();
            CommonProfiles objComPro = new CommonProfiles();

            try
            {
                frm_Reports.GetReportCriteriaA(strReportName, strCriteria, txtNo.Text, SEQ);
                frm_Reports.Show();
                frm_Reports.Activate();
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation.PrintInvoice", ex);
                MessageBox.Show(ex.Message, "Invoice");
            }
        }

        private void txtNo_Enter(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            lblCusName.ResetText();
            lblSEQ.Text = "";
            if (lblCustomerContact != null)
            {
                lblCustomerContact.Text = "";
            }
            cmbMethod.ResetText();
            cmbCat.ResetText();
            cmbCat.ResetText();
            cmbPartNO.ResetText();
            txtQty.Text = "";
            txtRemark.Text = "";
            tabControl1.Visible = false;
            ApplyToday();
        }

        private void ApplyToday()
        {
            dt_Start.Value = DateTime.Today;
            dt_End.Value = DateTime.Today.AddDays(3);
        }

        private void FitJobCard(object sender, EventArgs e)
        {
            this.Shown -= FitJobCard;
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            Grid_A.Dock = DockStyle.Fill;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView2.Dock = DockStyle.Fill;
            btn_Delete.BringToFront();
            tb1.BringToFront();
            LayoutJobCard();
            PlacePaymentControls();
            this.MinimumSize = new Size(1180, 760);
            AnchorRightEdge(this);
            if (jobSideActions != null)
            {
                jobSideActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                jobSideActions.BringToFront();
            }
        }

        private void FitWidth(Control control)
        {
            int room = control.Parent.ClientSize.Width - control.Left - 16;
            if (room > 180 && room < control.Width)
            {
                control.Width = room;
            }
        }

        private void AnchorRightEdge(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control.Name == "actionBar")
                {
                    continue;
                }
                if (control == lblCusName || control == txtRemark || control == tabControl1)
                {
                    continue;
                }
                if (control.Left >= 900 && control.Dock == DockStyle.None && control.Right <= control.Parent.ClientSize.Width)
                {
                    control.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                }
                if (control.HasChildren && !(control is DataGridView))
                {
                    AnchorRightEdge(control);
                }
            }
        }

        private void txtINVNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbType.Focus();
            }
        }

        private void txtNo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            if (customerKey.Length == 0)
            {
                ResolveCustomer();
            }
            if (customerKey.Length == 0 && CUS_ID > 0)
            {
                customerKey = CUS_ID.ToString();
            }
            if (customerKey.Length == 0)
            {
                MessageBox.Show("Please enter the customer, then try again.", "Pending credit");
                return;
            }
            ShowPendingCredit(customerKey);
        }

        private void cmbMethod_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbMedia.Items.Clear();

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT MAKE FROM MAKE WHERE CATEGORY = '" + cmbMethod.Text + "'", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                cmbMedia.Items.Add(drReader["MAKE"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }

            drReader.Close();
            _Conn.Close();
            //SHOW = "SELECT SEQNO, CATEGORY, MAKE, PARTNO, PART, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO, DEL, BARNO FROM MASTER WHERE (CATEGORY = '" + cmbMethod.Text + "')ORDER BY SEQNO";
            //ShowDetails();
        }

        private void txtSpare_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT EMP_NO, EMP_RATE FROM dbo.EMPLOYEES WHERE (STATUS = 2) AND (EMP_NO + '  -   ' + INITIALS + ' ' + NAME = '" + cmbEmp.Text + "')", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                lblEMP.Text = drReader["EMP_NO"].ToString();
                txtRate.Text = drReader["EMP_RATE"].ToString();
            }
            drReader.Close();
            _Conn.Close();
        }

        private void txt_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtSPAMNT.Focus();
                try
                {
                    decimal V = Math.Round(decimal.Parse(txtSPAMNT.Text) / 5, 0) * 5;
                    decimal Q = decimal.Parse(txt_Qty.Text);
                    decimal T = Math.Round(V * Q / 5, 0) * 5;
                    txtSPAMNT.Text = Convert.ToDecimal(V).ToString("###,###,###");
                }
                catch (Exception)
                {

                }
            }
        }

        private void cmbMethod_Leave(object sender, EventArgs e)
        {
            FINDMEDIA();
            cmbMedia.Enabled = true;
        }

        private void txtNo_Leave(object sender, EventArgs e)
        {
            FINDMETHOD();
            cmbMethod.Enabled = true;
        }

        private void cmbMedia_Leave(object sender, EventArgs e)
        {
            
        }

        private void cmbMedia_Leave_1(object sender, EventArgs e)
        {
            FINDCAT();
        }

        private void cmbMedia_SelectedValueChanged_1(object sender, EventArgs e)
        {
            FINDCAT();
        }

        private void cmbMedia_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbCat.Focus();
            }
        }

        private void cmbCat_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbPartNO.Focus();
            }
        }

        private void cmbCat_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (fillingCatalog)
            {
                return;
            }
            FillMaterialItems(loadingJob);
        }

        private void FINDParts()
        {
            cmbPartNO.Items.Clear();

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdReader = new SqlCommand("SELECT SEQNO, CATEGORY, MAKE, PARTNO, PART, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO, DEL, BARNO FROM MASTER WHERE MAKE = '" + cmbMedia.Text + "' AND CATEGORY = '" + cmbMethod.Text + "' AND SUB_CAT = '" + cmbCat.Text + "'", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                cmbPartNO.Items.Add(drReader["PARTNO"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }

            drReader.Close();
            _Conn.Close();
        }
    }
}