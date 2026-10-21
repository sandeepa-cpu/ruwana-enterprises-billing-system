using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace Billing_Inventory_Management_System
{  
    public partial class frm_MainMenu : Form
    {
        private SqlConnection _conn;
        String UserName;
        int A, B, C, D = 0;

        public frm_MainMenu()
        {
            InitializeComponent();
            BuildNavigation();
        }

        private void toWondowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            frm_UserLogIn frmUsers = new frm_UserLogIn();
            frmUsers.Close();
            this.Close();
            Application.Exit();
            Environment.Exit(0);
        }

        private void ProfitPWD()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT PASSWORD FROM USER_LOGIN WHERE USER_ID = 'Profit'";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                lblPwd.Text = dreader["PASSWORD"].ToString();
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void SystemDate()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT PRO_DATE FROM PRO_DATE";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                lblSD.Text = dreader["PRO_DATE"].ToString();
                //DateTime dt = new DateTime(DateTime.Parse(drEmp["LOAN_DATE"].ToString()));
                //String DT = String.Format("{0:MM/dd/yyyy}", DTM);
                //lblSD.Text = String.Format("{0:yyyy-MM-dd}", DTM); 
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void LOAD_MSI()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT COUNT(INV_NO) AS NOS FROM ISSUED_ITEMS GROUP BY PRO_DATE HAVING (PRO_DATE = CONVERT(DATETIME, '" + lblSD.Text + "', 102))";
            //cmdsql.CommandText = "SELECT COUNT(INV_NO) AS NOS FROM VW_MSI WHERE (ORDER_STATUS = 0)  AND (PRO_DATE = CONVERT(DATETIME, '" + lblSD.Text + "', 102)) ORDER BY COUNT(INV_NO)";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                linkLabel1.Text = dreader["NOS"].ToString();
                break;
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void TABS()
        {
            if (lblUserLevel.Text == "0")
            {
                button5.Enabled = true;
                button11.Enabled = true;
                //button7.Enabled = true;
                //button6.Enabled = true;
                button12.Enabled = true;
                //button28.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = false;
                button10.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                //button25.Enabled = true;
                //button26.Enabled = true;
                button29.Enabled = true;
               // button30.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button17.Enabled = true;
                //button13.Enabled = true;
                button20.Enabled = true;
                button19.Enabled = true;
                //button22.Enabled = true;
                //button21.Enabled = true;
                //button8.Enabled = true;
            }
            if (lblUserLevel.Text == "1")
            {
                button5.Enabled = true;
                button11.Enabled = true;
                //button7.Enabled = true;
                //button6.Enabled = true;
                button12.Enabled = false;
                //button28.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = false;
                button10.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
                //button25.Enabled = false;
                //button26.Enabled = false;
                button29.Enabled = false;
                //button30.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = true;
                button17.Enabled = true;
                //button13.Enabled = true;
                button20.Enabled = true;
                button19.Enabled = true;
                //button22.Enabled = true;
                //button21.Enabled = true;
                //button8.Enabled = false;
            }
            if (lblUserLevel.Text == "2")
            {
                button5.Enabled = true;
                button11.Enabled = true;
                //button7.Enabled = true;
                //button6.Enabled = true;
                button12.Enabled = true;
                //button28.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button10.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
                //button25.Enabled = false;
                //button26.Enabled = false;
                button29.Enabled = false;
                //button30.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = true;
                button17.Enabled = false;
                //button13.Enabled = true;
                button20.Enabled = false;
                button19.Enabled = true;
                //button22.Enabled = true;
                //button21.Enabled = true;
                //button8.Enabled = true;
            }
        }

        private void LOAD_SSR()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT COUNT(INV_NO) AS NOS FROM VW_SSR WHERE (ORDER_STATUS = 0) ORDER BY COUNT(INV_NO)";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                linkLabel5.Text = dreader["NOS"].ToString();
                break;
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void LOAD_SSI()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT COUNT(INV_NO) AS NOS FROM VW_SSI WHERE (ORDER_STATUS = 0) ORDER BY COUNT(INV_NO)";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                linkLabel6.Text = dreader["NOS"].ToString();
                break;
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void LOAD_COMPANYNAME()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT NAME FROM COMPANY_INFO";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                label15.Text = dreader["NAME"].ToString();
                break;
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void LOAD_COMPANYADDRESS()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT ADDRESS FROM COMPANY_INFO";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                label11.Text = dreader["ADDRESS"].ToString();
                break;
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void LOAD_COMPANYCITY()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT CITY FROM COMPANY_INFO";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                label6.Text = dreader["CITY"].ToString();
                break;
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void LOAD_System()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT SYSTEM1 FROM COMPANY_INFO";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                label9.Text = dreader["SYSTEM1"].ToString();
                break;
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void ArrangeLegacyMenus()
        {
            ToolStripMenuItem legacy = new ToolStripMenuItem("Legacy payroll");
            legacy.Name = "legacyPayrollToolStripMenuItem";
            legacy.DropDownItems.Add(toolStripMenuItem11);
            legacy.DropDownItems.Add(employeeAdjestmentsToolStripMenuItem);
            legacy.DropDownItems.Add(toolStripMenuItem13);
            legacy.DropDownItems.Add(toolStripMenuItem12);
            legacy.DropDownItems.Add(paySlipToolStripMenuItem);
            legacy.DropDownItems.Add(loanInstallmentAdjestmentsToolStripMenuItem);
            paySlipToolStripMenuItem.Enabled = true;
            loanInstallmentAdjestmentsToolStripMenuItem.Enabled = true;
            int processIndex = menuStrip1.Items.IndexOf(processToolStripMenuItem);
            if (processIndex < 0)
            {
                processIndex = menuStrip1.Items.Count;
            }
            menuStrip1.Items.Insert(processIndex, legacy);
            toolStripMenuItem9.Text = "Day Book";
        }

        private void LoadDashboard()
        {
            Panel row = new Panel();
            row.Name = "kpiRow";
            row.Size = new Size(1060, 110);
            row.BackColor = Color.Transparent;
            Label jobs = AddKpiCard(row, 0, "\uE787", "Jobs today");
            Label stock = AddKpiCard(row, 270, "\uE7BF", "Stock value");
            Label credit = AddKpiCard(row, 540, "\uE8C7", "Unpaid credit");
            AddKpiCard(row, 810, "\uE7BA", "Low stock");
            BindCardClick(row.Controls["kpiUnpaidcredit"] as Panel, creditOverview_Click);
            BindCardClick(row.Controls["kpiLowstock"] as Panel, lowStock_Click);
            this.Controls.Add(row);
            LayoutChrome();

            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                conn = obyConn.Connect();
                jobs.Text = DashboardCount(conn, "SELECT COUNT(*) FROM JOB_DETAILS WHERE JOB_DATE >= CONVERT(date, GETDATE()) AND JOB_DATE < DATEADD(day, 1, CONVERT(date, GETDATE()))");
                stock.Text = DashboardCount(conn, "SELECT ISNULL(SUM(BAL_QTY * ISSUE_PRICE), 0) FROM RECEIVED_ITEMS WHERE DEL = 0 OR DEL IS NULL");
                credit.Text = DashboardCount(conn, "SELECT ISNULL(SUM(CREDIT), 0) FROM ISSUED_TOTALS WHERE PAID = 0 OR PAID IS NULL");
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_MainMenu.Dashboard", ex);
                jobs.Text = "Dashboard unavailable: " + ex.Message;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
            RefreshLowStock();
        }

        private const int CreditOverdueDays = 30;

        private const string LowStockSql =
            "SELECT m.PARTNO, m.DESCRIPTION, m.ROL, ISNULL(SUM(r.BAL_QTY), 0) AS ON_HAND " +
            "FROM MASTER m " +
            "LEFT JOIN RECEIVED_ITEMS r ON r.PARTNO = m.PARTNO AND (r.DEL = 0 OR r.DEL IS NULL) " +
            "WHERE (m.DEL = 0 OR m.DEL IS NULL) " +
            "GROUP BY m.PARTNO, m.DESCRIPTION, m.ROL " +
            "HAVING ISNULL(SUM(r.BAL_QTY), 0) <= m.ROL AND m.ROL > 0";

        private void RefreshLowStock()
        {
            Label value = FindKpiValue("kpiLowstockValue");
            if (value == null)
            {
                return;
            }
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                conn = obyConn.Connect();
                value.Text = DashboardCount(conn, "SELECT COUNT(*) FROM (" + LowStockSql + ") AS low_stock");
                value.ForeColor = value.Text == "0" ? UiTheme.Ink : Color.FromArgb(180, 83, 9);
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_MainMenu.LowStock", ex);
                value.Text = "-";
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private Label FindKpiValue(string name)
        {
            Control[] found = this.Controls.Find(name, true);
            if (found.Length == 0)
            {
                return null;
            }
            return found[0] as Label;
        }

        private static void BindCardClick(Panel card, EventHandler handler)
        {
            if (card == null || handler == null)
            {
                return;
            }
            card.Cursor = Cursors.Hand;
            card.Click += handler;
            foreach (Control child in card.Controls)
            {
                child.Cursor = Cursors.Hand;
                child.Click += handler;
            }
        }

        private void lowStock_Click(object sender, EventArgs e)
        {
            frm_InsightList list = new frm_InsightList("Low stock", LowStockSql);
            list.Show(this);
        }

        private void creditOverview_Click(object sender, EventArgs e)
        {
            string sql =
                "SELECT CASE WHEN c.NAME IS NULL THEN 'Unassigned' ELSE c.NAME END AS CUSTOMER, " +
                "COUNT(*) AS INVOICES, SUM(t.CREDIT) AS UNPAID, MIN(j.OLDEST) AS OLDEST, " +
                "CASE WHEN MIN(j.OLDEST) < DATEADD(day, -" + CreditOverdueDays.ToString() + ", CAST(GETDATE() AS date)) THEN 'Yes' ELSE 'No' END AS OVERDUE " +
                "FROM ISSUED_TOTALS t " +
                "LEFT JOIN (SELECT INV_NO, MIN(CUSTOMER_ID) AS CUSTOMER_ID, MIN(COALESCE(INV_DATE, JOB_DATE)) AS OLDEST FROM JOB_DETAILS GROUP BY INV_NO) j ON j.INV_NO = t.INV_NO " +
                "LEFT JOIN CUSTOMER_INFO c ON c.SEQ_NO = j.CUSTOMER_ID " +
                "WHERE (t.PAID = 0 OR t.PAID IS NULL) AND ISNULL(t.CREDIT, 0) > 0 " +
                "GROUP BY CASE WHEN c.NAME IS NULL THEN 'Unassigned' ELSE c.NAME END " +
                "ORDER BY SUM(t.CREDIT) DESC";
            frm_InsightList list = new frm_InsightList("Unpaid credit", sql);
            list.Show(this);
        }

        private static Label AddKpiCard(Panel row, int left, string icon, string caption)
        {
            Panel shadow = new Panel();
            shadow.Name = "kpiShadow" + caption.Replace(" ", "");
            shadow.Location = new Point(left + 2, 2);
            shadow.Size = new Size(250, 100);
            shadow.BackColor = Color.FromArgb(208, 213, 221);
            row.Controls.Add(shadow);
            UiTheme.RoundPanel(shadow, 8);

            Panel card = new Panel();
            card.Name = "kpi" + caption.Replace(" ", "");
            card.Location = new Point(left, 0);
            card.Size = new Size(250, 100);
            card.BackColor = Color.White;
            Label glyph = new Label();
            glyph.Name = "navKpiIcon";
            glyph.Text = icon;
            glyph.Font = new Font("Segoe MDL2 Assets", 20F);
            glyph.ForeColor = UiTheme.Primary;
            glyph.Location = new Point(16, 16);
            glyph.AutoSize = true;
            Label title = new Label();
            title.Text = caption;
            title.Font = new Font("Segoe UI", 9F);
            title.ForeColor = UiTheme.Muted;
            title.Location = new Point(56, 18);
            title.AutoSize = true;
            Label value = new Label();
            value.Name = card.Name + "Value";
            value.Text = "...";
            value.Font = UiTheme.ValueFont;
            value.ForeColor = UiTheme.Ink;
            value.Location = new Point(16, 52);
            value.AutoSize = true;
            card.Controls.Add(glyph);
            card.Controls.Add(title);
            card.Controls.Add(value);
            row.Controls.Add(card);
            card.BringToFront();
            UiTheme.RoundPanel(card, 8);
            return value;
        }

        private static string DashboardCount(SqlConnection conn, string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            object value = cmd.ExecuteScalar();
            return value == null ? "0" : value.ToString();
        }

        private void frm_MainMenu_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            LOAD_COMPANYNAME();
            LOAD_COMPANYCITY();
            LOAD_COMPANYADDRESS();
            SystemDate();
            LOAD_System();
            ArrangeLegacyMenus();
            LoadDashboard();
            //LOAD_MSI();
            //LOAD_MSR();
            //LOAD_SSI();
            //LOAD_SSR();

            int TOT_INV = int.Parse(linkLabel2.Text) + int.Parse(linkLabel4.Text) + int.Parse(linkLabel5.Text) + int.Parse(linkLabel6.Text);
            linkLabel1.Text = TOT_INV.ToString();
            checkBox1.Checked = true;


            //----------------------------------------------------------------------------------------

            //lblDate.Text = DateTime.Now.ToShortDateString();

            DateTime DTNOW = DateTime.Now;
            //DateTime dt = new DateTime(DateTime.Parse(drEmp["LOAN_DATE"].ToString()));
            //String DT = String.Format("{0:MM/dd/yyyy}", DTM);
            lblDate.Text = String.Format("{0:yyyy-MM-dd}", DTNOW); 
            
            frm_UserLogIn frm_User = new frm_UserLogIn();
            UserName = frm_User.txt_User.Text;
            //LoadUserMenu();
            frm_User.Close();
            //SystemDate();
            if (lblUserLevel.Text == "0")
            {
                //////PA.Visible = true;
                ////rtbPendingActions.Visible = true;
                ////rtbPendingLoans.Visible = true;
                //////PopulatePendingActions();
                //////PopulatePendingLoans();
            }
            //PopulatePendingActionsA();
            //PopulatePendingActionsB();
            TABS();
        }

        //private void LOAD_MSR()
        //{
        //    Connection.DatabaseConnection obyConn;
        //    obyConn = new Connection.DatabaseConnection();
        //    _conn = obyConn.Connect();
        //    SqlCommand cmdsql = new SqlCommand();
        //    cmdsql.Connection = _conn;
        //    cmdsql.CommandText = "SELECT COUNT(INV_NO) AS NOS FROM VW_MSR WHERE (ORDER_STATUS = 0) ORDER BY COUNT(INV_NO)";
        //    SqlDataReader dreader = cmdsql.ExecuteReader();

        //    while (dreader.Read())
        //    {
        //        linkLabel2.Text = dreader["NOS"].ToString();
        //        return;
        //    }

        //    dreader.Close();
        //    _conn.Dispose();
        //}

        //private void LOAD_ALL()
        //{
        //    Connection.DatabaseConnection obyConn;
        //    obyConn = new Connection.DatabaseConnection();
        //    _conn = obyConn.Connect();
        //    SqlCommand cmdsql = new SqlCommand();
        //    cmdsql.Connection = _conn;
        //    cmdsql.CommandText = "SELECT COUNT(INV_NO) AS NOS FROM VW_SSI WHERE (PRO_DATE = CONVERT(DATETIME, '" + lblSD.Text + " 00:00:00', 102)) ORDER BY COUNT(INV_NO)";
        //    SqlDataReader dreader = cmdsql.ExecuteReader();

        //    while (dreader.Read())
        //    {
        //        A = int.Parse(dreader["NOS"].ToString());
        //        return;
        //    }

        //    obyConn = new Connection.DatabaseConnection();
        //    _conn = obyConn.Connect();
        //    SqlCommand cmdsql1 = new SqlCommand();
        //    cmdsql.Connection = _conn;
        //    cmdsql.CommandText = "SELECT COUNT(INV_NO) AS NOS FROM VW_MSI WHERE (PRO_DATE = CONVERT(DATETIME, '" + lblSD.Text + " 00:00:00', 102)) ORDER BY COUNT(INV_NO)";
        //    //cmdsql.CommandText = "SELECT COUNT(INV_NO) AS NOS FROM VW_MSI WHERE (ORDER_STATUS = 0)  AND (PRO_DATE = CONVERT(DATETIME, '" + lblSD.Text + "', 102)) ORDER BY COUNT(INV_NO)";
        //    SqlDataReader dreader1 = cmdsql.ExecuteReader();

        //    while (dreader.Read())
        //    {
        //        B = int.Parse(dreader1["NOS"].ToString());
        //        return;
        //    }

        //    dreader.Close();
        //    _conn.Dispose();

        //    obyConn = new Connection.DatabaseConnection();
        //    _conn = obyConn.Connect();
        //    SqlCommand cmdsql2 = new SqlCommand();
        //    cmdsql.Connection = _conn;
        //    cmdsql.CommandText = "SELECT COUNT(INV_NO) AS NOS FROM VW_MSR WHERE (PRO_DATE = CONVERT(DATETIME, '" + lblSD.Text + " 00:00:00', 102)) ORDER BY COUNT(INV_NO)";
        //    SqlDataReader dreader2 = cmdsql.ExecuteReader();

        //    while (dreader.Read())
        //    {
        //        C = int.Parse(dreader2["NOS"].ToString());
        //        return;
        //    }

        //    dreader.Close();
        //    _conn.Dispose();

        //    obyConn = new Connection.DatabaseConnection();
        //    _conn = obyConn.Connect();
        //    SqlCommand cmdsql3 = new SqlCommand();
        //    cmdsql.Connection = _conn;
        //    cmdsql.CommandText = "SELECT COUNT(INV_NO) AS NOS FROM VW_SSR WHERE (PRO_DATE = CONVERT(DATETIME, '" + lblSD.Text + " 00:00:00', 102)) ORDER BY COUNT(INV_NO)";
        //    SqlDataReader dreader3 = cmdsql.ExecuteReader();

        //    while (dreader.Read())
        //    {
        //        D = int.Parse(dreader3["NOS"].ToString());
        //        return;
        //    }

        //    dreader.Close();
        //    _conn.Dispose();

        //    linkLabel1.Text = A.ToString() + B.ToString() + C.ToString() + D.ToString();
        //}

        private void LOAD_COM()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT COUNT(INV_NO) AS NOS FROM VW_MSI WHERE (ORDER_STATUS = 1) AND (PRO_DATE = CONVERT(DATETIME, '" + lblSD.Text + "', 102)) ORDER BY COUNT(INV_NO)";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                linkLabel3.Text = dreader["NOS"].ToString();
                break;
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void LoadUserMenu()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdUser = new SqlCommand("SELECT USER_NAME, USER_ID, USER_ROLE_ID FROM VW_USER_ROLE WHERE USER_NAME = '" + lblUser.Text + "'", _conn);
            SqlDataReader drUser = cmdUser.ExecuteReader();

            while (drUser.Read())
            {
                //cmb_User.Items.Add(new KeyValuePair(drUser["ACC_LEVEL"], drUser["USER_NAME"].ToString()));

                //************** Admin ***************

                if (drUser["USER_ROLE_ID"].ToString() == "1")
                {
                    employeeDetailsToolStripMenuItem.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "2")
                {
                    toolStripMenuItem3.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "3")
                {
                    toolStripMenuItem3.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "4")
                {
                    toolStripMenuItem3.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "5")
                {
                    MainToolStripMenuItem.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "6")
                {
                    MainToolStripMenuItem.Visible = true;
                    loanDetailsToolStripMenuItem.Visible = true;
                }

                //************** Edit Mode ***************

                if (drUser["USER_ROLE_ID"].ToString() == "11")
                {

                }

                //************** Process ***************

                if (drUser["USER_ROLE_ID"].ToString() == "21")
                {
                    paySlipToolStripMenuItem.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "22")
                {
                    changeProcessPeriodToolStripMenuItem.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "23")
                {
                    loanInstallmentAdjestmentsToolStripMenuItem.Visible = true;
                }

                //************** Tools ***************

                if (drUser["USER_ROLE_ID"].ToString() == "31")
                {
                    userManagementToolStripMenuItem.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "32")
                {
                    createNewUserToolStripMenuItem.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "33")
                {
                    changePasswordToolStripMenuItem.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "34")
                {
                    createUserRolesToolStripMenuItem.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "35")
                {
                    backupDatabaseToolStripMenuItem.Visible = true;
                }

                //************** Reports ***************

                if (drUser["USER_ROLE_ID"].ToString() == "41")
                {
                    reportViewerToolStripMenuItem.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "42")
                {
                    verifyEmployeeAttendanceToolStripMenuItem.Visible = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "43")
                {
                    checkMemberInformationToolStripMenuItem.Visible = true;
                }
                
            }
            drUser.Close();
            _conn.Close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();

        }

        private void createNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button14_Click_1(sender, e);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button15_Click_1(sender, e);
        }

        private void changeProcessPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button11_Click_1(sender, e);
        }

        private void loanInstallmentAdjestmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_LoanAdjestments frm_LoanAdj = new frm_LoanAdjestments();
            frm_LoanAdj.Show();
        }

        private void createUserRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CreateUserRoles frm_Roles = new frm_CreateUserRoles();
            frm_Roles.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button20_Click_1(sender, e);
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button17_Click_1(sender, e);
        }

        //private void PopulatePendingActionsA()
        //{
        //    Connection.DatabaseConnection obyConn;

        //    obyConn = new Connection.DatabaseConnection();
        //    _conn = obyConn.Connect();

        //    SqlDataAdapter drLoan = new SqlDataAdapter("SELECT EMP_NO, FULL_NAME, MODIFIED_BY, MODIFIED_DATE FROM EMPLOYEES WHERE (STATUS = '2') ORDER BY CONVERT(INT,EMP_NO)", _conn);
        //    SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
        //    DataSet dsLoan = new DataSet();

        //    drLoan.Fill(dsLoan, "VW_LOAN_PROCESS");

        //    Grid_A.DataSource = dsLoan;
        //    Grid_A.DataMember = "VW_LOAN_PROCESS";

        //    _conn.Close();

        //    FillGridA();
        //}

        private void PopulatePendingActionsB()
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_conn = obyConn.Connect();

            //SqlDataAdapter drLoan = new SqlDataAdapter("SELECT EMP_NO, FULL_NAME, LOAN_AMOUNT, NO_INST, INTEREST, LOAN_DATE, SEL_STS, SEQ_NO FROM VW_LOAN_APPROVAL WHERE (STATUS = '2') ORDER BY NIC_NO", _conn);
            //SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            //DataSet dsLoan = new DataSet();

            //drLoan.Fill(dsLoan, "VW_LOAN_PROCESS");

            //Grid_B.DataSource = dsLoan;
            //Grid_B.DataMember = "VW_LOAN_PROCESS";

            //_conn.Close();

            //FillGridB();
        }

        private void FillGridB()
        {
            //Grid_B.Columns[0].Width = 80;
            //Grid_B.Columns[0].HeaderText = "NIC NO.";
            //Grid_B.Columns[1].Width = 220;
            //Grid_B.Columns[1].HeaderText = "NAME";
            //Grid_B.Columns[2].Width = 120;
            //Grid_B.Columns[2].HeaderText = "LOAN AMOUNT";
            //Grid_B.Columns[3].Width = 85;
            //Grid_B.Columns[3].HeaderText = "NO INST";
            //Grid_B.Columns[4].Width = 75;
            //Grid_B.Columns[4].HeaderText = "INTEREST";
            //Grid_B.Columns[5].Width = 90;
            //Grid_B.Columns[5].HeaderText = "LOAN DATE";
            //Grid_B.Columns[6].Width = 80;
            //Grid_B.Columns[6].HeaderText = "APPROVED";

            //Grid_B.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            //Grid_B.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            //Grid_B.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            //Grid_B.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            //Grid_B.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            //Grid_B.Columns[5].DefaultCellStyle.BackColor = Color.AliceBlue;
            //Grid_B.Columns[6].DefaultCellStyle.BackColor = Color.AliceBlue;
            //Grid_B.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            //Grid_B.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            //Grid_B.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
            //Grid_B.Columns[3].DefaultCellStyle.ForeColor = Color.Blue;
            //Grid_B.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;
            //Grid_B.Columns[5].DefaultCellStyle.ForeColor = Color.Blue;
            //Grid_B.Columns[6].DefaultCellStyle.ForeColor = Color.Blue;

            //Grid_B.Columns[0].ReadOnly = true;
            //Grid_B.Columns[1].ReadOnly = true;
            //Grid_B.Columns[2].ReadOnly = true;
            //Grid_B.Columns[3].ReadOnly = true;
            //Grid_B.Columns[4].ReadOnly = true;
            //Grid_B.Columns[5].ReadOnly = true;
            //Grid_B.Columns[7].Visible  = false;

            //Grid_B.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            //Grid_B.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            //Grid_B.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            //Grid_B.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            //Grid_B.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            //Grid_B.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            //Grid_B.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            ////Grid_A.Columns[6].DefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);

            //Grid_B.AutoGenerateColumns = false;
            //Grid_B.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            //Grid_B.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //Grid_B.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
            //Grid_B.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            //Grid_B.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            //Grid_B.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            //Grid_B.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Grid_B.MultiSelect = false;
            //Grid_B.RowHeadersVisible = true;

            //Grid_B.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //Grid_B.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //Grid_B.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //Grid_B.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Grid_B.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Grid_B.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Grid_B.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            ////Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            //Grid_B.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            //Grid_B.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void PopulatePendingActions()
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_conn = obyConn.Connect();

            //string strDelAllocated = ("SELECT NIC_NO, FULL_NAME, MODIFIED_BY, MODIFIED_DATE FROM MEMBERS WHERE (STATUS = '2') ORDER BY NIC_NO");
            //SqlCommand cmdEmp = new SqlCommand(strDelAllocated, _conn);
            //SqlDataReader drEmp = cmdEmp.ExecuteReader();

            //int intActionsCount = 0;
            //rtbPendingActions.Font.Underline = true;
            //rtbPendingActions.SelectedText = "                           PENDING APPROVALS" + "\n" + "\n";
            //rtbPendingActions.Font.Underline = false;
            //if(drEmp.HasRows == true)
            //    rtbPendingActions.SelectedText = "    NIC NO.               MEMBER NAME              MODIFIED BY" + "\n" + "\n";

            //while (drEmp.Read())
            //{
            //    rtbPendingActions.SelectedText = drEmp["NIC_NO"] + " | " + drEmp["FULL_NAME"].ToString() + " | " + drEmp["MODIFIED_BY"].ToString() + "\n";// +" - " + DateTime.Parse(drEmp["MODIFIED_DATE"].ToString()).ToShortDateString() + "\n";
            //    intActionsCount += 1;
            //}
            //drEmp.Close();
            // =====================================

            //if (intActionsCount == 0)
            //{
            //    rtbPendingActions.Height = 45;
            //    rtbPendingActions.Clear();
            //    rtbPendingActions.SelectedText = "          ==== NO PENDING MEMBER APPROVALS ====";
            //}
        }

        private void PopulatePendingLoans()
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_conn = obyConn.Connect();

            //string strDelAllocated = ("SELECT NIC_NO, FULL_NAME, LOAN_AMOUNT, NO_INST, INTEREST, LOAN_DATE FROM VW_LOAN_APPROVAL WHERE (STATUS = '2') ORDER BY NIC_NO");
            //SqlCommand cmdEmp = new SqlCommand(strDelAllocated, _conn);
            //SqlDataReader drEmp = cmdEmp.ExecuteReader();

            //int intActionsCount = 0;
            //rtbPendingLoans.SelectedText = "                           PENDING LOAN APPROVALS" + "\n" + "\n";
            //if (drEmp.HasRows == true)
            //    rtbPendingLoans.SelectedText = "LOAN DATE |     NIC NO.   |      MEMBER NAME              |   AMOUNT  | INTEREST" + "\n" + "\n";

            //while (drEmp.Read())
            //{
            //    //dt_Birth.Text = Convert.ToString(dreader["DATE_OF_BIRTH"]).ToString().Trim();
                
            //    DateTime DTM =  DateTime.Parse(drEmp["LOAN_DATE"].ToString());
            //    //DateTime dt = new DateTime(DateTime.Parse(drEmp["LOAN_DATE"].ToString()));
            //    String DT = String.Format("{0:MM/dd/yyyy}", DTM);

            //    rtbPendingLoans.SelectedText = DT.ToString() + " | " + drEmp["NIC_NO"] + " | " + drEmp["FULL_NAME"].ToString() + " | " + drEmp["LOAN_AMOUNT"].ToString() + " | " + drEmp["INTEREST"].ToString() + "\n";
            //    intActionsCount += 1;
            //}
            //drEmp.Close();
            //// =====================================

            //if (intActionsCount == 0)
            //{
            //    //rtbPendingLoans.Height = 45;
            //    rtbPendingLoans.Clear();
            //    rtbPendingLoans.SelectedText = "          ==== NO PENDING LOAN APPROVALS ====";
            //}
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //if (lblUserLevel.Text == "0")
            //{
                //rtbPendingActions.Clear();
                //rtbPendingLoans.Clear();

                //PopulatePendingActions();
                //PopulatePendingLoans();

             
            //}
            SystemDate();
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_conn = obyConn.Connect();

            //string strDelAllocated = ("SELECT NIC_NO, FULL_NAME, MODIFIED_BY, MODIFIED_DATE FROM MEMBERS WHERE (STATUS = '2') ORDER BY NIC_NO");
            //SqlCommand cmdEmp = new SqlCommand(strDelAllocated, _conn);
            //SqlDataReader drEmp = cmdEmp.ExecuteReader();

            //int intActionsCount = 0;
            ////rtbPendingActions.Font.Underline = true;
            //rtbPendingActions.SelectedText = "                           PENDING APPROVALS" + "\n" + "\n";
            ////rtbPendingActions.Font.Underline = false;
            //if (drEmp.HasRows == true)
            //    rtbPendingActions.SelectedText = "    NIC NO.               MEMBER NAME              MODIFIED BY" + "\n" + "\n";

            //while (drEmp.Read())
            //{
            //    rtbPendingActions.SelectedText = drEmp["NIC_NO"] + " | " + drEmp["FULL_NAME"].ToString() + " | " + drEmp["MODIFIED_BY"].ToString() + "\n";// +" - " + DateTime.Parse(drEmp["MODIFIED_DATE"].ToString()).ToShortDateString() + "\n";
            //    intActionsCount += 1;
            //}
            //drEmp.Close();
            //// =====================================

            //if (intActionsCount == 0)
            //{
            //    rtbPendingActions.Height = 45;
            //    rtbPendingActions.Clear();
            //    rtbPendingActions.SelectedText = "     ==== NO PENDING APPROVALS ====";
            //}


            //obyConn = new Connection.DatabaseConnection();
            //_conn = obyConn.Connect();

            //string LoanstrDelAllocated = ("SELECT NIC_NO, FULL_NAME, LOAN_AMOUNT, NO_INST, INTEREST, LOAN_DATE FROM VW_LOAN_APPROVAL WHERE (STATUS = '2') ORDER BY NIC_NO");
            //SqlCommand LoancmdEmp = new SqlCommand(LoanstrDelAllocated, _conn);
            //SqlDataReader LoandrEmp = LoancmdEmp.ExecuteReader();

            //int LoanintActionsCount = 0;
            //rtbPendingLoans.SelectedText = "                           PENDING LOAN APPROVALS" + "\n" + "\n";
            //if (LoandrEmp.HasRows == true)
            //    rtbPendingLoans.SelectedText = "    NIC NO.               MEMBER NAME              MODIFIED BY" + "\n" + "\n";

            //while (LoandrEmp.Read())
            //{
            //    rtbPendingLoans.SelectedText = LoandrEmp["NIC_NO"] + " | " + LoandrEmp["FULL_NAME"].ToString() + " | " + LoandrEmp["LOAN_AMOUNT"].ToString() + " | " + LoandrEmp["NO_INST"].ToString() + " | " + LoandrEmp["INTEREST"].ToString() + " | " + LoandrEmp["LOAN_DATE"].ToString() + "\n";
            //    LoanintActionsCount += 1;
            //}
            //LoandrEmp.Close();
            //// =====================================

            //if (intActionsCount == 0)
            //{
            //    rtbPendingLoans.Height = 45;
            //    rtbPendingLoans.Clear();
            //    rtbPendingLoans.SelectedText = "     ==== NO PENDING APPROVALS ====";
            //}
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

        }

    

        private void reportViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ReportCriteria_Inventory frm_Rpts = new frm_ReportCriteria_Inventory();
            frm_Rpts.Show();
        }

       

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_AboutUs frm_ABT = new frm_AboutUs();
            frm_ABT.Show();
        }

      

        private void pendingApprovalsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lblUserLevel.Text == "0")
            {

            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            GridA();
            GridB();
            btnShow.Focus();
        }

        private void GridA()
        {
            string APRVD;
            string NICNO;

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT NIC_NO, FULL_NAME, MODIFIED_BY, MODIFIED_DATE, SEL_STS FROM MEMBERS WHERE (STATUS = '2') ORDER BY NIC_NO", _conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "MEMBERS");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["MEMBERS"].Rows)
            {
                ////APRVD = Grid_A.Rows[count].Cells[4].Value.ToString();
                ////NICNO = Grid_A.Rows[count].Cells[0].Value.ToString();
                ////NICNO = Convert.ToInt16(Grid_A.Rows[count].Cells[0].Value.ToString());

                //if (APRVD == "True")
                //{
                //    string str_AdjINS = "UPDATE MEMBERS SET STATUS = '1' WHERE NIC_NO = '" + NICNO + "'";
                //    SqlCommand cmd_AdjINS = new SqlCommand(str_AdjINS, _conn);
                //    cmd_AdjINS.ExecuteNonQuery();
                //    cmd_AdjINS.Dispose();
                //}
                //count++;
            }
            _conn.Close();
            
        }

        private void GridB()
        {
            string APRVD;
            //string CAT;
            int SEQNO;

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT NIC_NO, FULL_NAME, LOAN_AMOUNT, NO_INST, INTEREST, LOAN_DATE, SEL_STS FROM VW_LOAN_APPROVAL WHERE (STATUS = '2') ORDER BY NIC_NO", _conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "VW_LOAN_APPROVAL");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["VW_LOAN_APPROVAL"].Rows)
            {
                //APRVD = Grid_B.Rows[count].Cells[6].Value.ToString();
                ////NICNO = Convert.ToInt16(Grid_B.Rows[count].Cells[0].Value.ToString());
                //SEQNO = Convert.ToInt16(Grid_B.Rows[count].Cells[7].Value.ToString());
                ////CAT = Grid_B.Rows[count].Cells[1].Value.ToString();

                //if (APRVD == "True")
                //{
                //    string str_AdjINS = "UPDATE LOAN_DETAILS SET STATUS = '1' WHERE SEQ_NO = '" + SEQNO + "'";
                //    SqlCommand cmd_AdjINS = new SqlCommand(str_AdjINS, _conn);
                //    cmd_AdjINS.ExecuteNonQuery();
                //    cmd_AdjINS.Dispose();
                //}
                //count++;
            }
            _conn.Close();
            PopulatePendingActionsB();
        }

        

        private void bankDepositsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_BankDeposits frm_Bank = new frm_BankDeposits();
            frm_Bank.Show();
        }

        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button7_Click_1(sender, e);
        }

        private void employeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button6_Click_1(sender, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frm_General frm_Gen = new frm_General();
            frm_Gen.Show();
        }

        private void loanDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button16_Click_1(sender, e);
        }

        private void loanReceivedDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_IssueGoods frm_IGOODS = new frm_IssueGoods();
            frm_IGOODS.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frm_ReturnSuppliers frm_RSup = new frm_ReturnSuppliers();
            frm_RSup.Show();
        }

        private void fromCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ReturnCustomers frm_RCus = new frm_ReturnCustomers();
            frm_RCus.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_ReceiveGoods frm_Rece = new frm_ReceiveGoods();
            frm_Rece.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_ReturnSuppliers frm_RSup = new frm_ReturnSuppliers();
            frm_RSup.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_IssueGoods frm_Issuue = new frm_IssueGoods();
            frm_Issuue.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_ReturnCustomers frm_RCup = new frm_ReturnCustomers();
            frm_RCup.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_InventoryMaster frm_Mast = new frm_InventoryMaster();
            frm_Mast.Show();
        }

      

        private void button7_Click(object sender, EventArgs e)
        {
            frm_SupplierProfile frm_Sup = new frm_SupplierProfile();
            frm_Sup.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm_CustomerProfile frm_Cus = new frm_CustomerProfile();
            frm_Cus.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process Proc = new System.Diagnostics.Process();
            Proc.StartInfo.FileName = Application.StartupPath + "\\Backup DB.exe";
            Proc.Start();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frm_ProcessLogIn frm_PWD = new frm_ProcessLogIn();
            frm_PWD.txt_User.Text = lblUser.Text;
            frm_PWD.txt_User.Enabled = false;
            frm_PWD.Text = "Change Process Period";
            frm_PWD.txt_Password.Focus();
            frm_PWD.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            frm_CreateUsers frm_CreateUser = new frm_CreateUsers();
            frm_CreateUser.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            frm_ChangePassword frm_ChangePwd = new frm_ChangePassword();
            frm_ChangePwd.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            frm_CreateUserRoles frm_Roles = new frm_CreateUserRoles();
            frm_Roles.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            frm_ReportCriteria_Inventory frm_Rpts = new frm_ReportCriteria_Inventory();
            frm_Rpts.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_UserLogIn frm_User = new frm_UserLogIn();
            frm_User.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Dispose();
            frm_UserLogIn frmUsers = new frm_UserLogIn();
            frmUsers.Close();
            this.Close();
            Application.Exit();
            Environment.Exit(0);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            frm_AboutUs frm_ABT = new frm_AboutUs();
            frm_ABT.Show();
        }


        private void updateCreditPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CreditInvoice frm_CP = new Frm_CreditInvoice();
            frm_CP.Show();
        }

        private void updateCreditPaymentsCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CreditInvoice frm_CPCUS = new Frm_CreditInvoice();
            frm_CPCUS.Show();
        }

        private void updateStockBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfitPWD();
            gbSB.Visible = true;
            gbSP.Visible = false;
            txtSBPwd.Focus();
        }

        private void changeIssuePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfitPWD();
            gbSP.Visible = true;
            gbSB.Visible = false;
            txtSPPwd.Focus();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void employeeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5_Click_1(sender, e);
        }

        private void banksBranchesInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_BankBranchDetails frm_Bank = new frm_BankBranchDetails();
            frm_Bank.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frm_JobCreation frm_JOB = new frm_JobCreation();
            AppWorkspace.Open(frm_JOB, "Job Card");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void earningsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Earnings frm_Ear = new frm_Earnings();
            frm_Ear.Show();
        }

        private void deductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Deductions frm_Ded = new frm_Deductions();
            frm_Ded.Show();
        }

        private void employeeAdjestmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Adjustments frm_Adj = new frm_Adjustments();
            frm_Adj.Show();
        }

        private void frmEmployeeFundRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_EmployeeFundRates frm_fund = new frm_EmployeeFundRates();
            frm_fund.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            frm_PayProcess frm_PRO = new frm_PayProcess();
            frm_PRO.Show();
        }

        private void dailyExpencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dailyExpencesToolStripMenuItem1_Click(sender, e);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            button12_Click(sender, e);
        }

        private void dailyExpencesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_Daily_Expences frm_Daily = new frm_Daily_Expences();
            frm_Daily.Show();
        }

        private void dailyEarningsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Daily_Earnings frm_DailyE = new frm_Daily_Earnings();
            frm_DailyE.Show();
        }

        private void employeeAttendanceRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Attendance frm_Attn = new frm_Attendance();
            frm_Attn.Show();
        }

        private void leaveInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Leave_Main frm_LM = new frm_Leave_Main();
            frm_LM.Show();
        }

        private void employeeLeaveUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem7_Click(sender, e);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frm_Employee_Leave frm_EL = new frm_Employee_Leave();
            frm_EL.Show();
        }

        private void employeeLeaveRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Employee_Leave_Taken frm_ELT = new frm_Employee_Leave_Taken();
            frm_ELT.Show();
        }

        private void pettyCashInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_PettyCash frm_Petty = new frm_PettyCash();
            frm_Petty.Show();
        }

        private void employeeLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_LoanMain frm_Loans = new frm_LoanMain();
            frm_Loans.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            frm_LoanDetails frm_LoanDetails = new frm_LoanDetails();
            frm_LoanDetails.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            frm_ReportCriteria_Payroll frm_RptsPay = new frm_ReportCriteria_Payroll();
            frm_RptsPay.Show();
        }

        private void mainCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_JobMainCat frm_JobMain = new frm_JobMainCat();
            frm_JobMain.Show();
        }

        private void subCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_JobSubCat frm_JobSub = new frm_JobSubCat();
            frm_JobSub.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frm_InventoryMaster frm_INV = new frm_InventoryMaster();
            AppWorkspace.Open(frm_INV, "Inventory");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            frm_EmployeeDetails frm_EMP = new frm_EmployeeDetails();
            frm_EMP.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            frm_ProcessLogIn frm_PWD = new frm_ProcessLogIn();
            frm_PWD.txt_User.Text = lblUser.Text;
            frm_PWD.txt_User.Enabled = false;
            frm_PWD.Text = "Change Process Period";
            frm_PWD.txt_Password.Focus();
            frm_PWD.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            frm_SupplierProfile frm_Sup = new frm_SupplierProfile();
            AppWorkspace.Open(frm_Sup, "Suppliers");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            frm_CustomerProfile frm_Cus = new frm_CustomerProfile();
            AppWorkspace.Open(frm_Cus, "Customers");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frm_JobCreation_Quotation frm_Quote = new frm_JobCreation_Quotation();
            frm_Quote.Show();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            frm_ReceiveGoods frm_RGOODS = new frm_ReceiveGoods();
            AppWorkspace.Open(frm_RGOODS, "Receive stock");
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            frm_ReportCriteria frm_Rpts = new frm_ReportCriteria();
            frm_Rpts.Show();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            frm_CreateUsers frm_CreateUser = new frm_CreateUsers();
            frm_CreateUser.Show();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            frm_ChangePassword frm_ChangePwd = new frm_ChangePassword();
            frm_ChangePwd.Show();
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process Proc = new System.Diagnostics.Process();
            Proc.StartInfo.FileName = Application.StartupPath + "\\Backup DB.exe";
            Proc.Start();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            List<Form> open = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                open.Add(form);
            }
            frm_UserLogIn login = null;
            foreach (Form form in open)
            {
                if (form is frm_UserLogIn)
                {
                    login = (frm_UserLogIn)form;
                    break;
                }
            }
            if (login == null || login.IsDisposed)
            {
                login = new frm_UserLogIn();
            }
            login.txt_User.Text = "";
            login.txt_Password.Text = "";
            login.Show();
            login.Activate();
            foreach (Form form in open)
            {
                if (form == login || form is frm_Splash || form.IsDisposed)
                {
                    continue;
                }
                try
                {
                    form.Close();
                }
                catch (Exception ex)
                {
                    AppLog.Write("frm_MainMenu.LogOff", ex);
                }
            }
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Frm_CreditInvoice frm_CP = new Frm_CreditInvoice();
            frm_CP.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frm_Daily_Expences frm_Daily = new frm_Daily_Expences();
            frm_Daily.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            frm_Daily_Earnings frm_DailyE = new frm_Daily_Earnings();
            frm_DailyE.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            frm_Employee_Expences frm_EMPE = new frm_Employee_Expences();
            frm_EMPE.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frm_TranportCost frm_TRANS = new frm_TranportCost();
            frm_TRANS.Show();
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            frm_JobCreation frm_JOBC = new frm_JobCreation();
            frm_JOBC.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            frm_InventoryMaster frm_INV = new frm_InventoryMaster();
            frm_INV.Show();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            frm_InventoryMaster frm_INV = new frm_InventoryMaster();
            frm_INV.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            frm_InventoryMaster frm_INV = new frm_InventoryMaster();
            frm_INV.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            frm_JobCreation frm_JOBC = new frm_JobCreation();
            frm_JOBC.Show();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            frm_JobCreation frm_JOBC = new frm_JobCreation();
            frm_JOBC.Show();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            frm_JobCreation frm_JOBC = new frm_JobCreation();
            frm_JOBC.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frm_SupplierProfile frm_Sup = new frm_SupplierProfile();
            frm_Sup.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            frm_SupplierProfile frm_Sup = new frm_SupplierProfile();
            frm_Sup.Show();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            frm_SupplierProfile frm_Sup = new frm_SupplierProfile();
            frm_Sup.Show();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            frm_ReportCriteria frm_Rpts = new frm_ReportCriteria();
            frm_Rpts.Show();
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            frm_ReportCriteria frm_Rpts = new frm_ReportCriteria();
            frm_Rpts.Show();
        }

        private void btnShow_Click_1(object sender, EventArgs e)
        {

        }
    }
}
