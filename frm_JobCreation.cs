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
        string APRVD;
        int SEQNOD, SEQNO;
        decimal REMOVETOT = 0;
        private string strCriteria = "";
        private string strReportName = "";
        public String VVehicleNO;
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
                dt_Start.Value = Convert.ToDateTime(dreader["PRO_DATE"].ToString());
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
            
            FormActions.Standardize(this);
            btnPay.Enabled = false;
            button31.Enabled = false;

            try
            {
                frm_CustomerProfile frm_Job = new frm_CustomerProfile();
                txtNo.Text = VVehicleNO.ToString();
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_JobCreation", ex);
            }

            FindEmps();
            PRO_DATE();
            //FindTypes();
            //InsuranceCompany();

            DateTime Current = Convert.ToDateTime(dt_Start.Value);
            int Days = int.Parse("3");
            DateTime Next = (Current.AddDays(Days));
            dt_End.Value = Convert.ToDateTime(Next);
            txtNo.Focus();
            timer1.Enabled = true;
            LoadParts();
            cmbPartNO.Focus();
            LoadCats();
        }

        private void LoadCats()
        {
            cmbCat.Items.Clear();
            cmbMethod.Items.Clear();
            cmbCat.Items.Clear();
            cmbPartNO.Items.Clear();

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
            

            frmGen.TopMost = true;
            frmGen.Show();
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
            if (decimal.Parse(lbl_BalQty.Text) < decimal.Parse(txtQty.Text))
            {
                MessageBox.Show("Quantity not Enough for the Job", "Received Goods Info");
                return;
            }

            if (txtNo.Text == "" || lblCusName.Text == "" || lblSEQ .Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                return;
            }

            Connection.DatabaseConnection obyConn;

            try
            {
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _Conn;
                cmdsql1.CommandText = "INSERT INTO JOB_DETAILS (JOB_DATE, JOB_TIME, JOB_NO, CUSTOMER_ID, JOB_START_DATE, JOB_END_DATE, P_SIZE, QTY, P_METHOD, P_MEDIA, P_CAT, REMARK) VALUES ('" + DateTime.Now + "', '" + DateTime.Now + "', '" + txtNo.Text + "', '" + lblSEQ.Text + "', '" + dt_Start.Value + "', '" + dt_End.Value + "', '" + cmbPartNO.Text + "', '" + txtQty.Text + "', '" + cmbMethod.Text + "', '" + cmbCat.Text + "', '" + cmbCat.Text + "', '" + txtRemark.Text + "')";
                cmdsql1.ExecuteNonQuery();
           

                FindSEQ();
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
            tabControl1.Visible = true;
            tb1.Visible = true;
            tb2.Visible = true;
            FindSEQ();
            FindEmps();
            UPSTOCKS();
            lblBalQty.Text = "";
            txtINVNO.Focus();
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
            cmbCat.Items.Clear();

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT SUB_CAT FROM SUB_CATEGORY WHERE MAKE = '"+ cmbMedia.Text +"' AND CATEGORY = '" + cmbMethod.Text + "'", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                cmbCat.Items.Add(drReader["SUB_CAT"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }

            drReader.Close();
            _Conn.Close();
        }



        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClearData();
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
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
            lblCusName.Items.Clear();

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT NAME FROM CUSTOMER_INFO", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                lblCusName.Items.Add(drReader["NAME"].ToString()); // + " - " + drTenMain["NAME"].ToString());
                lblCusName.Focus();
            }
            if (drReader.HasRows == false)
            {
                //MessageBox.Show("Job has Not Created", "Creation Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ///return;
            }

            drReader.Close();
            _Conn.Close();
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
        }

        private void SHOW()
        {
            lblCusName.Focus();
            lblCusName.DroppedDown = true;
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
                button2.Enabled = false;
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
                    lblCusName.DroppedDown = true;
                }
            }

            

            drReader.Close();
            _Conn.Close();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            UP_STS();
            UP_EMPS();

            if (txtNo.Text == "")
            {
                MessageBox.Show("You have not assigned a Job. Assigne a Job & try again....", "Invalid Job", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                strCriteria = "Reports";

                this.Text = "Report Criteria for " + strCriteria;

                strReportName = "rpt_JobDetails";

                frm_Reports frm_Reports = new frm_Reports();
                CommonProfiles objComPro = new CommonProfiles();

                frm_Reports.GetReportCriteriaA(strReportName, strCriteria, txtNo.Text, SEQ);
                //frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lblDate.Text), DateTime.Parse(lblDate.Text), txtNo.Text);
                frm_Reports.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtNo.Focus();
            timer1.Enabled = false;
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
                cmbMethod.DroppedDown = true;

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
            cmbEmp.DroppedDown = true;
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
                cmbMedia.DroppedDown = true;
            }
        }

        private void cmbMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbCat.Focus();
                cmbCat.DroppedDown = true;
            }
        }

        private void cmbCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbPartNO.Focus();
                cmbPartNO.DroppedDown = true;
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
                txtSpare.DroppedDown = true;
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
                Connection.DatabaseConnection obyConn;

                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();

                SqlCommand cmdReader = new SqlCommand("SELECT SEQ_NO FROM CUSTOMER_INFO WHERE NAME = '" + lblCusName.Text + "'", _Conn);
                SqlDataReader drReader = cmdReader.ExecuteReader();
                while (drReader.Read())
                {
                    lblSEQ.Text = drReader["SEQ_NO"].ToString(); // + " - " + drTenMain["NAME"].ToString());
                    dt_Start.Focus();
                }
                if (drReader.HasRows == false)
                {
                    //MessageBox.Show("Job has Not Created", "Creation Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ///return;
                }

                drReader.Close();
                _Conn.Close();
            }
        }

        private void lblCusName_Leave(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT SEQ_NO FROM CUSTOMER_INFO WHERE NAME = '" + lblCusName.Text + "'", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                lblSEQ.Text = drReader["SEQ_NO"].ToString(); // + " - " + drTenMain["NAME"].ToString());
                dt_Start.Focus();
            }
            if (drReader.HasRows == false)
            {
                //MessageBox.Show("Job has Not Created", "Creation Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ///return;
            }

            drReader.Close();
            _Conn.Close();
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
            lblBalQty.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT S_NO, SUM(BAL_QTY) AS QTY, STATUS FROM RECEIVED_ITEMS GROUP BY S_NO, STATUS, PARTNO HAVING (STATUS = 1) AND (PARTNO  = '" + cmbPartNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblBalQty.Text = dreader["QTY"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void UOM()
        {
            lblUOM.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT UOM FROM MASTER WHERE (PARTNO  = '" + cmbPartNO.Text + "')";
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
            Load_BALQTYS_PARTNO();
            UOM();
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
            if (txtNo.Text == "")
            {
                MessageBox.Show("You have not assigned a Job. Assigne a Job & try again....", "Invalid Job", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                strCriteria = "Reports";

                this.Text = "Report Criteria for " + strCriteria;

                strReportName = "rpt_Invoice";

                frm_Reports frm_Reports = new frm_Reports();
                CommonProfiles objComPro = new CommonProfiles();

                frm_Reports.GetReportCriteriaA(strReportName, strCriteria, txtNo.Text, SEQ);
                //frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lblDate.Text), DateTime.Parse(lblDate.Text), txtNo.Text);
                frm_Reports.Show();
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
            cmbMethod.ResetText();
            cmbCat.ResetText();
            cmbCat.ResetText();
            cmbPartNO.ResetText();
            txtQty.Text = "";
            txtRemark.Text = "";
            tabControl1.Visible = false;
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
            if (txtNo.Text == "")
            {
                MessageBox.Show("You have not assigned a Job. Assigne a Job & try again....", "Invalid Job", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                strCriteria = "Reports";

                this.Text = "Report Criteria for " + strCriteria;

                strReportName = "rpt_JobCredit";

                frm_Reports frm_Reports = new frm_Reports();
                CommonProfiles objComPro = new CommonProfiles();

                frm_Reports.GetReportCriteriaA(strReportName, strCriteria, txtNo.Text, SEQ);
                //frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lblDate.Text), DateTime.Parse(lblDate.Text), txtNo.Text);
                frm_Reports.Show();
            }
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

        private void cmbMedia_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbCat.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUB_CAT FROM SUB_CATEGORY WHERE CATEGORY = '" + cmbMethod.Text + "' AND MAKE = '" + cmbCat.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbCat.Items.Add(dreader["SUB_CAT"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
            //SHOW = "SELECT SEQNO, CATEGORY, MAKE, PARTNO, PART, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO, DEL, BARNO FROM MASTER WHERE (CATEGORY = '" + cmbMethod.Text + "')ORDER BY SEQNO";
            //ShowDetails();
        }

        private void cmbCat_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbPartNO.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUB_CATEGORY FROM SUB_CATEGORY WHERE CATEGORY = '" + cmbMethod.Text + "' AND MAKE = '" + cmbCat.Text + "' AND SUB_CAT = '" + cmbCat.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPartNO.Items.Add(dreader["SUB_CATEGORY"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
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
            cmbMedia.DroppedDown = true;
        }

        private void txtNo_Leave(object sender, EventArgs e)
        {
            FINDMETHOD();
            cmbMethod.Enabled = true;
            cmbMethod.DroppedDown = true;
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
                cmbCat.DroppedDown = true;
            }
        }

        private void cmbCat_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbPartNO.Focus();
                cmbPartNO.DroppedDown = true;
            }
        }

        private void cmbCat_SelectedValueChanged_1(object sender, EventArgs e)
        {
            FINDParts();
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