using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace Billing_Inventory_Management_System
{
    public partial class frm_IssueGoods : Form
    {
        public frm_IssueGoods()
        {
            InitializeComponent();
        }
        public String VehicleNO;
        public Int32 SEQ__NO;

        Bitmap bitmA;
        String UserName;
        private SqlConnection _Conn;
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
        int SEQ = 0;
        string APRVD;
        int SEQNOD, SEQNO;
        decimal REMOVETOT = 0;

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
        private string strCriteria = "";
        private string strReportName = "";

        public static string InvNo = "";
        public static string InvAmount = "";
        public static string SysDate = "";
        public static int LocID;



        private void btn_Save_Click(object sender, EventArgs e)
        {
            lblShow.Text = "0";
            timer1.Enabled = true;
            if (txt_Price.Text == "0" || txt_Price.Text == "" || txt_Qty.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                return;
            }
            
            //try
            //{
                QTY = decimal.Parse(txt_Qty.Text);
                BAL_QTY = decimal.Parse(lbl_BalQty.Text);

                if (QTY > BAL_QTY)
                    {
                        MessageBox.Show("Please Enter Less Issue Amount to Proceed", "Issue Goods Info");
                        return;
                    }

                if (txt_Price.Text == "" || txt_Qty.Text == "")
                    {
                        MessageBox.Show("Please Enter Required Data and Proceed", "Issue Goods Info");
                        return;
                    }

                decimal CALQTY = Convert.ToDecimal(txt_Qty.Text);
                decimal CALVAL = Convert.ToDecimal(lblShow.Text);
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
                                cmdsql1.CommandText = "INSERT INTO ISSUED_ITEMS (SEQ, SYS_USER, PARTNO, ORGQTY, QTY, PRICE, REMARKS, PRO_DATE, TOT, STATUS, RECEIVE_SEQNO, LOCATION, PRO_TIME) VALUES ('" + SEQ + "', '" + lblUser.Text + "', '" + cmbPartNO.Text + "','" + QTY + "', '" + TOTCALQTY + "','" + CALUNIT + "', '" + txtRemarks.Text + "',Convert(DateTime,'" + lblDate.Text + "'),'" + TOT_ISSUE + "', '1', '" + SEQ_NO + "', '" + lblLocation.Text + "', '" + DateTime.Now + "')";
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

                                cmdsql1.CommandText = "INSERT INTO ISSUED_ITEMS (SEQ, SYS_USER, PARTNO, ORGQTY, QTY, PRICE, REMARKS, PRO_DATE, TOT, STATUS, RECEIVE_SEQNO, LOCATION, PRO_TIME) VALUES ('" + SEQ + "', '" + lblUser.Text + "', '" + cmbPartNO.Text + "','" + QTY + "', '" + BAL_QTY + "', '" + CALUNIT + "','" + txtRemarks.Text + "',Convert(DateTime,'" + lblDate.Text + "'),'" + ENDCAL + "', '1', '" + SEQ_NO + "', '" + lblLocation.Text + "', '" + DateTime.Now + "')";
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
                MessageBox.Show("Items Issue Entry Successfully Added");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Issue Goods Info");
            //    return;
            //}
            _Conn.Close();
            ShowDetails();
            //ClearData();
            btn_Save.Enabled = false;
            
            
            Load_BALQTYS();

            lblAll.Text = "";
            lblShow.Text = "";
            txt_Price.Text = "";
            txt_Qty.Text = "";
            TOTAMOUNTS();
            timer10.Enabled = true;
            cmbDesc.Enabled = true;
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT ISSUED_ITEMS.PARTNO, MASTER.PART, MASTER.DESCRIPTION, ISSUED_ITEMS.QTY, ISSUED_ITEMS.PRICE, ISSUED_ITEMS.TOT, ISSUED_ITEMS.S_NO, ISSUED_ITEMS.STATUS, ISSUED_ITEMS.DEL, ISSUED_ITEMS.SEQ_NO, ISSUED_ITEMS.SEQ FROM ISSUED_ITEMS INNER JOIN MASTER ON ISSUED_ITEMS.PARTNO = MASTER.PARTNO WHERE (ISSUED_ITEMS.STATUS = 1) AND (ISSUED_ITEMS.SEQ = '" + SEQ + "')ORDER BY ISSUED_ITEMS.SEQ_NO DESC", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "ISSUED_ITEMS");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "ISSUED_ITEMS";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 120;
            Grid_A.Columns[0].HeaderText = "PART NO";
            Grid_A.Columns[1].Width = 120;
            Grid_A.Columns[1].HeaderText = "PART";
            Grid_A.Columns[2].Width = 140;
            Grid_A.Columns[2].HeaderText = "DESCRIPTION";
            Grid_A.Columns[3].Width = 100;
            Grid_A.Columns[3].HeaderText = "BAL_QTY";
            Grid_A.Columns[4].Width = 90;
            Grid_A.Columns[4].HeaderText = "PRICE";
            Grid_A.Columns[5].Width = 60;
            Grid_A.Columns[5].HeaderText = "TOT";
            Grid_A.Columns[6].Width = 120;
            Grid_A.Columns[6].HeaderText = "S_NO";
            Grid_A.Columns[7].Width = 120;
            Grid_A.Columns[7].HeaderText = "STATUS";
            Grid_A.Columns[8].Width = 20;
            Grid_A.Columns[8].HeaderText = "DELETE";
            //Grid_A.Columns[10].Width = 20;
            //Grid_A.Columns[10].HeaderText = "SEQ_NO";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[5].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[6].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[7].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[8].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[9].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[3].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[5].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[6].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[7].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[8].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[9].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;
            //Grid_A.Columns[3].ReadOnly = true;
            Grid_A.Columns[4].ReadOnly = true;
            Grid_A.Columns[5].ReadOnly = true;
            Grid_A.Columns[6].ReadOnly = true;
            Grid_A.Columns[7].ReadOnly = true;
            Grid_A.Columns[8].ReadOnly = false;
            Grid_A.Columns[9].Visible = true;

            Grid_A.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;

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
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid_A.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT ISSUED_ITEMS.PARTNO, MASTER.PART, MASTER.DESCRIPTION, ISSUED_ITEMS.QTY, ISSUED_ITEMS.PRICE, ISSUED_ITEMS.TOT, ISSUED_ITEMS.S_NO, ISSUED_ITEMS.STATUS, ISSUED_ITEMS.DEL, ISSUED_ITEMS.SEQ_NO FROM ISSUED_ITEMS WHERE (ISSUED_ITEMS.PARTNO = '" + cmbPartNO.Text + "') AND (ISSUED_ITEMS.PRO_DATE = '" + lbl_Date.Text + "') ORDER BY ISSUED_ITEMS.INV_NO, ISSUED_ITEMS.SEQ_NO DESC", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "ISSUED_ITEMS");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["ISSUED_ITEMS"].Rows)
            {
                thisDataset.Tables["ISSUED_ITEMS"].Rows[count]["INV_NO"] = Grid_A.Rows[count].Cells[2].Value.ToString();
                thisDataset.Tables["ISSUED_ITEMS"].Rows[count]["S_NO"] = Grid_A.Rows[count].Cells[6].Value.ToString();
                thisAdapter.Update(thisDataset, "ISSUED_ITEMS");
                count++;
            }
            _Conn.Close();
            MessageBox.Show("Successfully Updated", "Update Info.");
            ShowDetails();
        }

        private void SelectBank()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT BANK FROM BANK_DETAILS";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                // cmb_SelectBank.Items.Add(dreader["BANK"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
        }

        private void LoadUSER()
        {

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdPwd = new SqlCommand("SELECT C_USER FROM  [CURRENT_USER]", _Conn);
            SqlDataReader drPwd = cmdPwd.ExecuteReader();
            while (drPwd.Read())
            {
                lblUser.Text = drPwd["C_USER"].ToString();
            }
            cmdPwd.Dispose();
            drPwd.Dispose();
            _Conn.Close();
        }

        private void frm_IssueGoods_Load(object sender, EventArgs e)
        {
            frm_JobCreation frm_Job = new frm_JobCreation();
            try
            {
                txtNo.Text = VehicleNO.ToString();
            }
            catch (Exception)
            {

            }
            
            timer12.Enabled = true;
            //LoadCat();
            //LoadMakes();
            PRO_DATE();
            //LoadPart();
//            txtInvoice.Text = "-";
            txt_Qty.Text = "-";
            //pnlBarcode.Visible = true;
            CUS();
            SHOW();
            ShowDetails();
            cmbPartNO.Focus();
            LoadParts();

            cmbPartNO.Focus();
        }

        private void ClearData()
        {
            cmbPartNO.ResetText();
            lbl_UOM.Text = "";
            lbl_ROL.Text = "";
            lbl_ROQ.Text = "";
            lbl_Locate.Text = "";
            lbl_CabNo.Text = "";
            lbl_RackNo.Text = "";
            lbl_BinNo.Text = "";
            lbl_SPNo.Text = "";
            txt_Price.Text = "0";
            txt_Qty.Text = "0";
            //txtInvoice.Text = "";
            txtRemarks.Text = "";
            lblShow.Text = "0";
        }

        private void Load_BALQTY()
        {
            lbl_BalQty.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUM(BAL_QTY) AS QTY, STATUS, PARTNO FROM RECEIVED_ITEMS GROUP BY STATUS, PARTNO HAVING (STATUS = 1) AND (PARTNO  = '" + cmbPartNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_BalQty.Text = dreader["QTY"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Load_BALQTYMAKE()
        {
            lbl_BalQty.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUM(BAL_QTY) AS QTY, STATUS, PARTNO FROM RECEIVED_ITEMS GROUP BY STATUS, HAVING (STATUS = 1) AND (PARTNO  = '" + cmbPartNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_BalQty.Text = dreader["QTY"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Load_BALQTYMODEL()
        {
            lbl_BalQty.Text = "";
            txtSysGen.Text = "";
            TOTAMOUNT = 0;
            TOTPRICE = 0;
            TOTQTY = 0;
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUM(TOT) AS TOTPRICE, SUM(QTY) AS TOTQTY, SUM(BAL_QTY) AS QTY, STATUS, PARTNO FROM RECEIVED_ITEMS GROUP BY STATUS, PARTNO HAVING (STATUS = 1) AND (PARTNO  = '" + cmbPartNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_BalQty.Text = dreader["QTY"].ToString();
                TOTPRICE = decimal.Parse(dreader["TOTPRICE"].ToString());
                TOTQTY = decimal.Parse(dreader["TOTQTY"].ToString());
                
            }
            
            if (TOTPRICE > 0 || TOTQTY > 0)
                TOTAMOUNT = TOTPRICE / TOTQTY;
            else
            {

            }

            //txtSysGen.Text = Convert.ToDecimal(TOTAMOUNT).ToString();
            txtSysGen.Text = Convert.ToDecimal(TOTAMOUNT).ToString("###,###,###");
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }



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
            //lbl_DATE.Text = DateTime.Today.Date.ToLongDateString();
            //lbl_DATE.Text = String.Format("{0:yyyy - MM - dd}", lbl_DATE.Text);
            //this.dt_Birth.CustomFormat = "yyyy-MM-dd";
        }

        private void cmbMake_SelectedValueChanged(object sender, EventArgs e)
        {
            Load_BALQTYMAKE();
        }

        private void cmbMake_Enter(object sender, EventArgs e)
        {
            btn_Save.Enabled = false;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void cmbCat_SelectedValueChanged(object sender, EventArgs e)
        {
            Load_BALQTY();
            //Load_Data();
            ShowDetails();
        }

        private void txt_Price_Leave(object sender, EventArgs e)
        {
            try
            {
                LoadTOT();
                //this.dt_Birth.CustomFormat = "yyyy-MM-dd";
            }
            catch (Exception)
            {
                
            }
        }

        private void LoadTOT()
        {
            if (txt_Price.Text == "")
                txt_Price.Text = "0";
            PURCHASE = decimal.Parse(txt_Price.Text);
            txt_Price.Text = PURCHASE.ToString("###,###");
            //txt_Price.Text = PURCHASE.ToString("###,##0.00"); 
            QTY = int.Parse(txt_Qty.Text);
            TOT_PURCHASE = PURCHASE;


            //DISC = decimal.Parse(txtDis.Text);
            //LOAD = decimal.Parse(txt_Load.Text);
            //TRANS = decimal.Parse(txt_Trans.Text);
            //OTHER = decimal.Parse(txt_Other.Text);
            //TOT = (TOT_PURCHASE - DISC) + LOAD + TRANS + OTHER;
            lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("###,###");
            lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,###");
        }

        private void txtDis_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtDis.Text == "")
            //        txtDis.Text = "0";
            //        PURCHASE = decimal.Parse(txt_Price.Text);
            //    DISC = decimal.Parse(txtDis.Text);
            //    txtDis.Text = DISC.ToString("###,###");

            //    LOAD = decimal.Parse(txt_Load.Text);
            //    TRANS = decimal.Parse(txt_Trans.Text);
            //    OTHER = decimal.Parse(txt_Other.Text);
            //    TOT = (PURCHASE - DISC) + LOAD + TRANS + OTHER;
            //    lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("###,###");
            //    lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,###");
            //}
            //catch (Exception)
            //{

            //}
        }

        private void txt_Trans_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txt_Trans.Text == "")
            //        txt_Trans.Text = "0";
            //    PURCHASE = decimal.Parse(txt_Price.Text);
            //    DISC = decimal.Parse(txtDis.Text);
            //    LOAD = decimal.Parse(txt_Load.Text);
            //    TRANS = decimal.Parse(txt_Trans.Text);
            //    txt_Trans.Text = TRANS.ToString("###,###");

            //    OTHER = decimal.Parse(txt_Other.Text);
            //    TOT = (PURCHASE - DISC) + LOAD + TRANS + OTHER;
            //    lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("###,###");
            //    lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,###");
            //}
            //catch (Exception)
            //{

            //}
        }

        private void txt_Load_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txt_Load.Text == "")
            //        txt_Load.Text = "0";
            //    PURCHASE = decimal.Parse(txt_Price.Text);
            //    DISC = decimal.Parse(txtDis.Text);
            //    LOAD = decimal.Parse(txt_Load.Text);
            //    txt_Load.Text = LOAD.ToString("###,###");

            //    TRANS = decimal.Parse(txt_Trans.Text);
            //    OTHER = decimal.Parse(txt_Other.Text);
            //    TOT = (PURCHASE - DISC) + LOAD + TRANS + OTHER;
            //    lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("###,###");
            //    lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,###");
            //}
            //catch (Exception)
            //{

            //}
        }

        private void txt_Other_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txt_Other.Text == "")
            //        txt_Other.Text = "0";
            //    PURCHASE = decimal.Parse(txt_Price.Text);
            //    DISC = decimal.Parse(txtDis.Text);
            //    LOAD = decimal.Parse(txt_Load.Text);
            //    TRANS = decimal.Parse(txt_Trans.Text);
            //    OTHER = decimal.Parse(txt_Other.Text);
            //    txt_Other.Text = OTHER.ToString("###,###");

            //    TOT = (PURCHASE - DISC) + LOAD + TRANS + OTHER;
            //    lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("###,###");
            //    lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,###");
            //}
            //catch (Exception)
            //{

            //}
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            lblShow.Text = "";
            lblAll.Text = "";

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT ISSUED_ITEMS.PARTNO, MASTER.PART, MASTER.DESCRIPTION, ISSUED_ITEMS.QTY, ISSUED_ITEMS.PRICE, ISSUED_ITEMS.TOT, ISSUED_ITEMS.S_NO, ISSUED_ITEMS.STATUS, ISSUED_ITEMS.DEL, ISSUED_ITEMS.SEQ_NO, ISSUED_ITEMS.SEQ FROM ISSUED_ITEMS INNER JOIN MASTER ON ISSUED_ITEMS.PARTNO = MASTER.PARTNO WHERE (ISSUED_ITEMS.STATUS = 1) AND (ISSUED_ITEMS.SEQ = '" + SEQ + "')ORDER BY ISSUED_ITEMS.SEQ_NO DESC", _Conn);
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
            ShowDetails();
            Load_BALQTYS();
            MessageBox.Show("Records are Successfully Deleted", "Deleting Entries");
            TOTAMOUNTS();
        }

        private void cmbModel_SelectedValueChanged(object sender, EventArgs e)
        {
            Load_BALQTYMODEL();
            if (lbl_BalQty.Text != "")
                btn_Save.Enabled = true;
            else 
                btn_Save.Enabled = false;
        }

        private void cmbCat_Enter(object sender, EventArgs e)
        {
            btn_Save.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void txt_Qty_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal CALCQTY;
                decimal CALCPRICE;
                decimal CALCTOT;
                //lblShow.Text = "0.00";
                CALCQTY = decimal.Parse(txt_Qty.Text);
                CALCPRICE = decimal.Parse(lblLastPrice.Text);
                CALCTOT = CALCQTY * CALCPRICE;

                decimal V = Math.Round(CALCTOT / 5, 0) * 5;
                decimal Q = decimal.Parse(txt_Qty.Text);
                decimal T = Math.Round(V * Q / 5, 0) * 5;
                txt_Price.Text = Convert.ToDecimal(V).ToString("###,###,###");
                lblShow.Text = Convert.ToDecimal(T).ToString("###,###,###");


                txt_Price.Text = CALCTOT.ToString("###,###");
                LoadTOT();
                //TOT = (PURCHASE - DISC) + LOAD + TRANS + OTHER;
                //lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("#####0.00");
                //lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,##0.00");
            }
            catch (Exception)
            {
                MessageBox.Show("Error.... Entered Value Incorrect. Check and Verify Your Entry", "Issue Goods Info");
                return;
                txt_Qty.Focus();
            }
        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            frm_CustomerProfile frmGen = new frm_CustomerProfile();
            frmGen.TopMost = true;
            frmGen.Show();
            this.Hide();
        }

        private void PARTSEQ()
        {
            txtPart.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQNO FROM PART WHERE PART = '" + cmbPartNO.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txtPart.Text = dreader["SEQNO"].ToString().Trim();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbDesc.Enabled = false;
            LoadPart();
        }

        private void LoadPart()
        {
            cmbPartNO.Items.Clear();
            cmbPartNO.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            //cmdsql.CommandText = "SELECT PART, PARTNO FROM MASTER";
            cmdsql.CommandText = "SELECT PART, PARTNO FROM MASTER ORDER BY PART";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPartNO.Items.Add(dreader["PARTNO"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void LoadPartNoDesc()
        {
            cmbPartNO.Text = "";
            cmbDesc.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;

            

            cmdsql.CommandText = "SELECT SEQNO, PART, PARTNO, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO FROM MASTER WHERE (PART = '" + cmbPartNO.Text.Trim() + "') ORDER BY DESCRIPTION";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPartNO.Text = dreader["PARTNO"].ToString();
                cmbDesc.Text = dreader["DESCRIPTION"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void LoadByPart()
        {
            cmbPartNO.Text = "";
            cmbDesc.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;

            cmdsql.CommandText = "SELECT BARNO, SEQNO, CATEGORY, MAKE, PART, PARTNO, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO FROM MASTER WHERE (PART = '" + cmbPartNO.Text.Trim() + "') ORDER BY DESCRIPTION";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPartNO.Text = dreader["BARNO"].ToString();
                //cmbPartNO.Text = dreader["BARNO"].ToString();
                
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }


        private void cmbPart_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearDataPartNo();
            if (txtCat.Text != "")
            {
                LoadPartNoDesc();
            }
            else
            {
                LoadByPart();
            }
            //LoadPartNoDesc();
            //LoadByPart();

            cmbDesc.Enabled = false;
            cmbPartNO.Enabled = true;
            ShowDetailsB();
        }

        private void Load_Data_PARTNO()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO, MINQTY, MAXQTY FROM  MASTER WHERE PARTNO  = '" + cmbPartNO.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_UOM.Text = dreader["UOM"].ToString();
                lbl_ROL.Text = dreader["ROL"].ToString();
                lbl_ROQ.Text = dreader["ROQ"].ToString();
                lbl_Locate.Text = dreader["LOC"].ToString();
                lbl_CabNo.Text = dreader["CAB"].ToString();
                lbl_RackNo.Text = dreader["RACK"].ToString();
                lbl_BinNo.Text = dreader["BIN"].ToString();
                lbl_SPNo.Text = dreader["SPNO"].ToString();
                lbl_MinQty.Text = dreader["MINQTY"].ToString();
                lbl_MaxQty.Text = dreader["MAXQTY"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void LoadByBARCODE()
        {
            //cmbPart.Text = "";
            //cmbDesc.Text = "";
            //cmbPart.Enabled = false;
            //cmbDesc.Enabled = false;
            //Connection.DatabaseConnection obyConn;
            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();
            //SqlCommand cmdsql = new SqlCommand();
            //cmdsql.Connection = _Conn;
            //cmdsql.CommandText = "SELECT MASTER.PART, MASTER.PARTNO, MASTER.DESCRIPTION, RECEIVED_ITEMS.S_NO, MASTER.UOM, MASTER.ROL, MASTER.ROQ, MASTER.LOC, MASTER.CAB, MASTER.RACK, MASTER.BIN, MASTER.SPNO, MASTER.MINQTY, MASTER.MAXQTY FROM RECEIVED_ITEMS INNER JOIN MASTER ON RECEIVED_ITEMS.PARTNO = MASTER.PARTNO WHERE (RECEIVED_ITEMS.S_NO = '" + cmbPartNO.Text + "')";
            //SqlDataReader dreader = cmdsql.ExecuteReader();
            //while (dreader.Read())
            //{
            //    if (dreader.HasRows == true)
            //    {
            //        cmbPart.Text = dreader["PART"].ToString();
            //        cmbPartNO.Text = dreader["PARTNO"].ToString();
            //        cmbDesc.Text = dreader["DESCRIPTION"].ToString();
            //        lbl_UOM.Text = dreader["UOM"].ToString();
            //        lbl_ROL.Text = dreader["ROL"].ToString();
            //        lbl_ROQ.Text = dreader["ROQ"].ToString();
            //        lbl_Locate.Text = dreader["LOC"].ToString();
            //        lbl_CabNo.Text = dreader["CAB"].ToString();
            //        lbl_RackNo.Text = dreader["RACK"].ToString();
            //        lbl_BinNo.Text = dreader["BIN"].ToString();
            //        lbl_SPNo.Text = dreader["SPNO"].ToString();
            //        lbl_MinQty.Text = dreader["MINQTY"].ToString();
            //        lbl_MaxQty.Text = dreader["MAXQTY"].ToString();
            //        //cmbPart.DroppedDown = false;
            //        return;
                    
            //    }
            //}
            //cmdsql.Dispose();
            //dreader.Dispose();
            //_Conn.Close();
            //cmbPart.Enabled = true;
            //cmbDesc.Enabled = true;
        }

        private void ClearDataPartNo()
        {
            lbl_UOM.Text = "";
            lbl_ROL.Text = "";
            lbl_ROQ.Text = "";
            lbl_Locate.Text = "";
            lbl_CabNo.Text = "";
            lbl_RackNo.Text = "";
            lbl_BinNo.Text = "";
            //lbl_SPNo.Text = "";
            lbl_BalQty.Text = "";
        }

        private void cmbPartNO_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearDataPartNo();
            Load_Data_PARTNO();
            Load_BALQTYS_PARTNO();
            Load_SysGenPrice();
            //ShowDetails();
            Load_LastPrice();
            btn_Save.Enabled = true;
            ShowDetailsB();
        }

        private void LoadByDesc()
        {
            //cmbPartNO.Items.Clear();
            cmbPartNO.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO, DESCRIPTION FROM MASTER WHERE (DESCRIPTION = '" + cmbDesc.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPartNO.Text = dreader["PARTNO"].ToString();
                //cmbDesc.Text = dreader["DESCRIPTION"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Load_Data_DESC()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO, MINQTY, MAXQTY FROM  MASTER WHERE DESCRIPTION  = '" + cmbDesc.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_UOM.Text = dreader["UOM"].ToString();
                lbl_ROL.Text = dreader["ROL"].ToString();
                lbl_ROQ.Text = dreader["ROQ"].ToString();
                lbl_Locate.Text = dreader["LOC"].ToString();
                lbl_CabNo.Text = dreader["CAB"].ToString();
                lbl_RackNo.Text = dreader["RACK"].ToString();
                lbl_BinNo.Text = dreader["BIN"].ToString();
                lbl_SPNo.Text = dreader["SPNO"].ToString();
                lbl_MinQty.Text = dreader["MINQTY"].ToString();
                lbl_MaxQty.Text = dreader["MAXQTY"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Load_BALQTYS()
        {
            lbl_BalQty.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT S_NO, SUM(BAL_QTY) AS QTY, STATUS FROM RECEIVED_ITEMS GROUP BY S_NO, STATUS, PARTNO HAVING (STATUS = 1) AND (S_NO  = '" + cmbPartNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_BalQty.Text = dreader["QTY"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Load_BALQTYS_PARTNO()
        {
            lbl_BalQty.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT S_NO, SUM(BAL_QTY) AS QTY, STATUS FROM RECEIVED_ITEMS GROUP BY S_NO, STATUS, PARTNO HAVING (STATUS = 1) AND (PARTNO  = '" + cmbPartNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_BalQty.Text = dreader["QTY"].ToString();

                if (lbl_UOM.Text == "LITERS")
                {
                    //lblCLOSE.Visible = false;
                }
                else if (lbl_UOM.Text != "LITERS")
                {
                    //lblCLOSE.Visible = true;
                }
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Load_BALQTYS_BARCODE()
        {
            lbl_BalQty.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUM(BAL_QTY) AS QTY, STATUS FROM RECEIVED_ITEMS GROUP BY STATUS, PARTNO, S_NO HAVING (STATUS = 1) AND (S_NO = '" + cmbPartNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_BalQty.Text = dreader["QTY"].ToString();

                if (lbl_UOM.Text == "LITERS")
                {
                    //lblCLOSE.Visible = false;
                }
                else if (lbl_UOM.Text != "LITERS")
                {
                    //lblCLOSE.Visible = true;
                }
            }
            if (lbl_BalQty.Text == "")
            {
                lbl_BalQty.Text = "0";
            }

            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }


        private void Load_LastPrice()
        {
            if (cmbPartNO.Text == "")
            {
                
            }
            else
            {
                try
                {
                    lblLastPrice.Text = "";
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "SELECT STATUS, ISSUE_PRICE/QTY AS ISSUE_PRICE FROM RECEIVED_ITEMS WHERE (STATUS = 1) AND (PARTNO = '" + cmbPartNO.Text + "')ORDER BY SEQ_NO";
                    SqlDataReader dreader = cmdsql.ExecuteReader();
                    while (dreader.Read())
                    {
                        Decimal LP = Convert.ToDecimal(dreader["ISSUE_PRICE"].ToString());
                        lblLastPrice.Text = Convert.ToDecimal(LP).ToString("###,###");
                    }
                    cmdsql.Dispose();
                    dreader.Dispose();
                    _Conn.Close();
                }
                catch (Exception)
                {

                }
            }
        }
        private void Load_LastPriceBARCODE()
        {
            if (cmbPartNO.Text == "")
            {
                cmbPartNO.Focus();
                //MessageBox.Show("Please Enter the Barcode No & Proceed", "Require Barcode No",MessageBoxButtons.OK);
            }
            else
            {
                lblLastPrice.Text = "";
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "SELECT STATUS, ISSUE_PRICE/QTY AS ISSUE_PRICE FROM RECEIVED_ITEMS WHERE (STATUS = 1) AND (S_NO  = '" + cmbPartNO.Text + "')ORDER BY SEQ_NO";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                while (dreader.Read())
                {
                    Decimal LP = Convert.ToDecimal(dreader["ISSUE_PRICE"].ToString());
                    lblLastPrice.Text = Convert.ToDecimal(LP).ToString("###,###");
                }
                cmdsql.Dispose();
                dreader.Dispose();
                _Conn.Close();
            }
        }

        private void Load_SysGenPrice()
        {
            txtSysGen.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT ISSUE_PRICE/QTY AS PRICE FROM RECEIVED_ITEMS WHERE (STATUS = 1) AND (PARTNO = '" + cmbPartNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                Decimal SG = Convert.ToDecimal(dreader["PRICE"].ToString());
                txtSysGen.Text = Convert.ToDecimal(SG).ToString("###,###");
                return;
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Load_SysGenPriceBARCODE()
        {
            txtSysGen.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT ISSUE_PRICE/QTY AS PRICE FROM RECEIVED_ITEMS WHERE (STATUS = 1) AND (S_NO  = '" + cmbPartNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                Decimal SG = Convert.ToDecimal(dreader["PRICE"].ToString());
                txtSysGen.Text = Convert.ToDecimal(SG).ToString("###,###");
                return;
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void cmbDesc_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadByDesc();
            Load_Data_DESC();
            Load_BALQTYS();
            Load_LastPrice();
            ShowDetails();
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //cmbPart.Focus();
            }
        }

        private void cmbPartNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Qty.Focus();
            }
        }

        private void cmbPart_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbPartNO.Focus();
                cmbPartNO.Enabled = true;

                //cmbPart.DroppedDown = false;
            }
        }

        private void txtInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Qty.Focus();
            }
        }

        private void txt_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Price.Focus();
            }
        }

        private void txtDis_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //txt_Trans.Focus();
            }
        }

        private void txt_Trans_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //txt_Load.Focus();
            }
        }

        private void txt_Load_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //txt_Other.Focus();
            }
        }

        private void txt_Other_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbPartNO.Focus();
            }
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btn_Save.Focus();
            }
        }

        private void cmbSub_SelectedValueChanged(object sender, EventArgs e)
        {
            //cmbPart.Enabled = true;
            cmbPartNO.Enabled = true;
            LoadPart();
            cmbDesc.Enabled = false;
            
        }

       
        private void cmbSub_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbPartNO.DroppedDown = true;
                cmbPartNO.Focus();
               
            }
        }


        private void txt_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //cmbPartNO.DroppedDown = true;
                //cmbPartNO.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //timer7.Enabled = true;

            //if (lblLocation.Text == "1")
            //{
            //    tbProfit.Visible = true;
            //    lblProfitPer.Focus();
            //}
            //else if (lblLocation.Text == "0")
            //{
            //    tbAdd.Visible = true;
            //    txtDis.Focus();
            //}

            
        }

        private void UPRECSISSUES()
        {
            if (lblLocation.Text == "1")
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "INSERT INTO NMICS_2.dbo.RECEIVED_ITEMS (SUPPLIER, PARTNO, INV_NO, QTY, BAL_QTY, PRICE, DIS_PRICE, S_NO, REMARKS, PRO_DATE, ISSUE_PRICE, TOT, STATUS, SYS_USER)SELECT RECEIVE_SEQNO, PARTNO, INV_NO, QTY, QTY, PRICE, PRICE, S_NO, REMARKS, PRO_DATE, TOT, TOT, STATUS, SYS_USER FROM NMICS.dbo.ISSUED_ITEMS WHERE (LOCATION = 1) AND (UPDATED = 1)";
                cmdsql.ExecuteNonQuery();

                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _Conn;
                cmdsql1.CommandText = "UPDATE NMICS.dbo.ISSUED_ITEMS SET UPDATED = '0' WHERE (LOCATION = 1) AND (UPDATED = 1)";
                cmdsql1.ExecuteNonQuery();

                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql43 = new SqlCommand();
                cmdsql43.Connection = _Conn;
                //cmdsql43.CommandText = "SELECT SEQ_NO, INV_NO, DIS_PRICE, TOT FROM NMICS_2.dbo.RECEIVED_ITEMS WHERE INV_NO = '" + txtInvoice.Text + "'";
                SqlDataReader dreader = cmdsql43.ExecuteReader();
                while (dreader.Read())
                {
                    if (dreader.HasRows == true)
                    {
                        int SEQ = int.Parse(dreader["SEQ_NO"].ToString());

                        decimal DIS_P = decimal.Parse(dreader["DIS_PRICE"].ToString());
                        decimal TOT_P = decimal.Parse(dreader["TOT"].ToString());

                        int PRO = 0;

                        decimal NEW_DIS_P = DIS_P - ((DIS_P * PRO)/100);
                        decimal NEW_TOT_P = TOT_P - ((TOT_P * PRO) / 100);

                        obyConn = new Connection.DatabaseConnection();
                        _Conn = obyConn.Connect();
                        SqlCommand cmdsql34 = new SqlCommand();
                        cmdsql34.Connection = _Conn;

                        cmdsql34.CommandText = "UPDATE  NMICS_2.dbo.RECEIVED_ITEMS SET DIS_PRICE = '" + NEW_DIS_P + "', TOT = '" + NEW_TOT_P + "' WHERE (SEQ_NO = '" + SEQ + "')";
                        cmdsql34.ExecuteNonQuery();

                    }

                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            timer7.Enabled = false;

            try
            {
                //if (txt_Other.Text == "")
                //    txt_Other.Text = "0";
                ////PURCHASE = decimal.Parse(txt_Price.Text);
                //DISC = decimal.Parse(txtDis.Text);
                //LOAD = decimal.Parse(txt_Load.Text);
                //TRANS = decimal.Parse(txt_Trans.Text);
                //OTHER = decimal.Parse(txt_Other.Text);
                //txt_Other.Text = OTHER.ToString("###,###");

                //TOT = (TOT_PURCHASE - DISC) + LOAD + TRANS + OTHER;
                //lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("###,###");
                //lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,###");
            }
            catch (Exception)
            {
            }

            InvNo = lblINVD.Text;
            InvAmount = lblAll.Text;
            SysDate = lblDate.Text;


            //try
            //{
                //if (txtDis.Text == "" || txt_Load.Text == "" || txt_Other.Text == "" || txt_Trans.Text == "")
                //{
                //    MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                //    txtDis.Text = "";
                //    txt_Load.Text = "";
                //    txt_Other.Text = "";
                //    txt_Trans.Text = "";
                //    return;
                //}

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                
                //cmdsql.CommandText = "UPDATE ISSUED_TOTALS SET DISCOUNT = '" + Convert.ToDecimal(txtDis.Text) + "', TRANS = '" + Convert.ToDecimal(txt_Trans.Text) + "', LOADING = '" + Convert.ToDecimal(txt_Load.Text) + "', OTHER = '" + Convert.ToDecimal(txt_Other.Text) + "' WHERE (INV_NO = '" + txtInvoice.Text + "')";
                cmdsql.ExecuteNonQuery();
                MessageBox.Show("Items Issued Discount / Additional charges Successfully Added");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Issued Goods Info");
            //    return;
            //}

            //if (MessageBox.Show("Do you want to Print the Invoice  ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //{
                frm_ReceiveMode frmRec = new frm_ReceiveMode();
                frmRec.Show();
            //}
            _Conn.Close();
            //ShowDetails();
            ClearData();
            InvNo = lblINVD.Text;
            InvAmount = lblAll.Text;
            LocID = int.Parse(lblLocation.Text);

            //UPRECSISSUES();
        }

        private void txtInvoice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //if (txtInvoice.Text == "")
            //{
            //    MessageBox.Show("Please Enter the Invoice No. to proceed");
            //    txtInvoice.Focus();
            //    return;
            //}
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                ShowDetails();
                TOTAMOUNTS();
                //ISSUEAMOUNT();
                //ChecksStatus();
                //txtInvoice.Enabled = false;
                btn_Update.Enabled = true;
                btn_Delete.Enabled = true;
                btnPrint.Enabled = true;
                btn_Save.Enabled = true;
                button1.Enabled = true;
            }

            if (i == 27)
            {
                cmbPartNO.Text = "";
            }
        }

        private void ISSUEAMOUNT()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT TOT, ISSUE_PRICE FROM RECEIVED_ITEMS WHERE (INV_NO = '" + lblINVD.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblAll.Text = dreader["TOT"].ToString().Trim();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void TOTAMOUNTS()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUM(TOT) AS TOT, SEQ FROM ISSUED_ITEMS GROUP BY SEQ HAVING (SEQ = '" + SEQ + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblAll.Text = dreader["TOT"].ToString().Trim();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }


        private void ChecksStatus()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
           // cmdsql.CommandText = "SELECT STATUS, INV_NO FROM ISSUED_ITEMS WHERE INV_NO = '" + txtInvoice.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                if (dreader.HasRows == true)
                {
                    int STAT;
                    STAT = int.Parse(dreader["STATUS"].ToString());
                    Grid_A.Refresh();
                    Grid_A.Enabled = true;

                    if (STAT == 0)
                    {
                        MessageBox.Show("Selected Invoice has Successfully Updated, No more Ammendments can be Done.....", "Updating....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Grid_A.Refresh();
                        txtNo.Focus();
                        New();
                        return;
                    }

                    //ShowDetails();
                    //txtInvoice.Enabled = false;
                }

            }
            btn_Save.Enabled = true;
            button1.Enabled = true;
            btn_Update.Enabled = true;
            btn_Delete.Enabled = true;
            btnPrint.Enabled = true;
            ShowDetails();
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }
       

        private void txt_Qty_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 27)
            {
                cmbPartNO.Text = "";
                cmbPartNO.Focus();
            }

            if (i == 13)
            {
                txt_Price.Focus();
                try
                {
                    decimal V = Math.Round(decimal.Parse(lblLastPrice.Text) / 5, 0) * 5;
                    decimal Q = decimal.Parse(txt_Qty.Text);
                    decimal T = Math.Round(V * Q / 5, 0) * 5;
                    txt_Price.Text = Convert.ToDecimal(V).ToString("###,###,###");
                    lblShow.Text = Convert.ToDecimal(T).ToString("###,###,###");
                }
                catch (Exception)
                {
                }
            }
        }

        private void txt_Price_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtRemarks.Focus();
            }

            if (i == 27)
            {
                cmbPartNO.Text = "";
                cmbPartNO.Focus();
            }
        }

        private void cmbPartNO_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                if (cmbPartNO.Text != "")
                {
                    //pnlBarcode.Visible = false;
                    ClearDataPartNo();
                    LoadByBARCODE();
                    Load_BALQTYS_BARCODE();
                    Load_SysGenPriceBARCODE();
                    Load_LastPriceBARCODE();
                    btn_Save.Enabled = true;
                    ShowDetailsB();

                    txt_Qty.Focus();
                    //cmb_CusDesc.Text = "CASH";
                    //cmbPartNO.Text = "";
                }
            }

            char cc = e.KeyChar;
            int ii = (int)cc;
            if (ii == 27)
            {
                txtNo.Focus();
            
            }
            cmbDesc.Enabled = true;
        
        }

        private void txtRemarks_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btn_Save.Focus();
            }
        }

        private void btn_Save_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 27)
            {
                cmbPartNO.Text = "";
                cmbPartNO.Focus();
            }

        }

        private void txtDis_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //txt_Trans.Focus();
            }
        }

        private void txt_Trans_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //txt_Load.Focus();
            }
        }

        private void txt_Load_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //txt_Other.Focus();
            }
        }

        private void txt_Other_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //btnOK.Focus();
            }
        }

        private void txtDis_Leave_1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtDis.Text == "")
            //        txtDis.Text = "0";
            //    //PURCHASE = decimal.Parse(txt_Price.Text);
            //    DISC = decimal.Parse(txtDis.Text);
            //    txtDis.Text = DISC.ToString("###,###");

            //    LOAD = decimal.Parse(txt_Load.Text);
            //    TRANS = decimal.Parse(txt_Trans.Text);
            //    OTHER = decimal.Parse(txt_Other.Text);
            //    TOT = (TOT_PURCHASE - DISC) + LOAD + TRANS + OTHER;
            //    lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("###,###");
            //    lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,###");
            //}
            //catch (Exception)
            //{
            //}
        }

        private void txt_Trans_Leave_1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txt_Trans.Text == "")
            //        txt_Trans.Text = "0";
            //    //PURCHASE = decimal.Parse(txt_Price.Text);
            //    DISC = decimal.Parse(txtDis.Text);
            //    LOAD = decimal.Parse(txt_Load.Text);
            //    TRANS = decimal.Parse(txt_Trans.Text);
            //    txt_Trans.Text = TRANS.ToString("###,###");

            //    OTHER = decimal.Parse(txt_Other.Text);
            //    TOT = (TOT_PURCHASE - DISC) + LOAD + TRANS + OTHER;
            //    lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("###,###");
            //    lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,###");
            //}
            //catch (Exception)
            //{
            //}
        }

        private void txt_Load_Leave_1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txt_Load.Text == "")
            //        txt_Load.Text = "0";
            //    //PURCHASE = decimal.Parse(txt_Price.Text);
            //    DISC = decimal.Parse(txtDis.Text);
            //    LOAD = decimal.Parse(txt_Load.Text);
            //    txt_Load.Text = LOAD.ToString("###,###");

            //    TRANS = decimal.Parse(txt_Trans.Text);
            //    OTHER = decimal.Parse(txt_Other.Text);
            //    TOT = (TOT_PURCHASE - DISC) + LOAD + TRANS + OTHER;
            //    lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("###,###");
            //    lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,###");
            // }
            // catch (Exception)
            // {
            // }
        }
        

        private void txt_Other_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txt_Other.Text == "")
            //        txt_Other.Text = "0";
            //    //PURCHASE = decimal.Parse(txt_Price.Text);
            //    DISC = decimal.Parse(txtDis.Text);
            //    LOAD = decimal.Parse(txt_Load.Text);
            //    TRANS = decimal.Parse(txt_Trans.Text);
            //    OTHER = decimal.Parse(txt_Other.Text);
            //    txt_Other.Text = OTHER.ToString("###,###");

            //    TOT = (TOT_PURCHASE - DISC) + LOAD + TRANS + OTHER;
            //    lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("###,###");
            //    lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,###");
            //}
            //catch (Exception)
            //{
            //}
        }

        private void txt_Price_Leave_1(object sender, EventArgs e)
        {
            try
            {
                if (txt_Price.Text == "")
                    txt_Price.Text = "0";
                //PURCHASE = decimal.Parse(lblLastPrice.Text);
                //txt_Price.Text = txt_Price.Text.ToString("#####0.00");
                //txt_Price.Text = PURCHASE.ToString("###,##0.00"); 
                QTY = int.Parse(txt_Qty.Text);
                TOT_PURCHASE = PURCHASE * QTY;

                TOT_PURCHASE = Math.Round(TOT_PURCHASE / 5, 0) * 5;
                
                lblShow.Text = Convert.ToDecimal(TOT_PURCHASE).ToString("###,###,###");
                
                //this.dt_Birth.CustomFormat = "yyyy-MM-dd";
            }
            catch (Exception)
            {
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm_InventoryMaster frmIM = new frm_InventoryMaster();
            frmIM.TopMost = true;
            frmIM.Show();
            this.Hide();
        }

        private void txt_Qty_Leave_1(object sender, EventArgs e)
        {
            if (txt_Qty.Text == "")
            {
                //MessageBox.Show("Please Enter the Quantity to proceed");
                txt_Qty.Focus();
                return;
            }
        }

        private void ShowDetailsB()
        {
            try
            {
                Connection.DatabaseConnection obyConn;

                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();

                SqlDataAdapter drLoan = new SqlDataAdapter("SELECT BAL_QTY, ISSUE_PRICE, ISSUE_PRICE / QTY AS ISSUE FROM RECEIVED_ITEMS WHERE (PARTNO = '" + cmbPartNO.Text + "') AND STATUS = 1", _Conn);
                SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
                DataSet dsLoan = new DataSet();

                drLoan.Fill(dsLoan, "RECEIVED_ITEMS");

                GridB.DataSource = dsLoan;
                GridB.DataMember = "RECEIVED_ITEMS";

                _Conn.Close();

                FillGridB();
            }
            catch (Exception)
            {

            }
        }

        private void FillGridB()
        {
            GridB.Columns[0].Width = 80;
            GridB.Columns[0].HeaderText = "QUANTITY";
            GridB.Columns[1].Width = 100;
            GridB.Columns[1].HeaderText = "PRICE";
            GridB.Columns[2].Width = 100;
            GridB.Columns[2].HeaderText = "ISSUE PRICE";

            GridB.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            GridB.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            GridB.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            GridB.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
            GridB.Columns[1].DefaultCellStyle.ForeColor = Color.Red;
            GridB.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            GridB.Columns["DIS_PRICE"].DefaultCellStyle.Format = "###,###,###";
            GridB.Columns["ISSUE"].DefaultCellStyle.Format = "###,###,###";

            GridB.Columns[0].ReadOnly = true;
            GridB.Columns[1].ReadOnly = true;
            GridB.Columns[2].ReadOnly = true;

            GridB.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            GridB.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            GridB.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            GridB.AutoGenerateColumns = false;
            GridB.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            GridB.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            GridB.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
            GridB.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            GridB.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            GridB.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            GridB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridB.MultiSelect = false;
            GridB.RowHeadersVisible = true;

            GridB.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            GridB.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            GridB.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //GridB.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Regular);
            GridB.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            GridB.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            strReportName = "rpt_Print";
            strCriteria = "Reports";

            this.Text = "Report Criteria for " + strCriteria;

            strReportName = "rpt_Print";


            frm_Reports frm_Reports = new frm_Reports();
            CommonProfiles objComPro = new CommonProfiles();

            frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lblDate.Text), DateTime.Parse(lblDate.Text), txtNo.Text, lblCUSSUP.Text);
            frm_Reports.Show();
        }

        private void txtInvoice_Enter(object sender, EventArgs e)
        {
            btn_Update.Enabled = true;
            btn_Delete.Enabled = true;
            btnPrint.Enabled = true;
            btn_Save.Enabled = true;
            button1.Enabled = true;
            lblShow.Text = "";
            lblAll.Text = "";
        }

        private void txtInvoice_TextChanged(object sender, EventArgs e)
        {
            //TOTAMOUNTS();
        }

        private void btn_FindCode_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;

            cmdsql.CommandText = "SELECT MASTER.BARNO, MASTER.PARTNO, MASTER.PART, CATEGORY.CATEGORY, MAKE.MAKE, SUBCAT.SUBCAT FROM CATEGORY INNER JOIN MASTER ON CATEGORY.SEQNO = MASTER.CATEGORY INNER JOIN MAKE ON MASTER.MAKE = MAKE.SEQNO INNER JOIN SUBCAT ON MASTER.SUBCAT = SUBCAT.SEQNO WHERE PARTNO = '" + cmbPartNO.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblMsg.Text = "PART ALLREADY EXCISTS AS... - '" + dreader["PART"].ToString() + "'";
                //cmbPartNO.Text = dreader["BARNO"].ToString();
                txt_Qty.Focus();
                return;
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
            timer11.Enabled = true;
        }

        //private void BarcodeNew()
        //{
        //    string barcodeZ = cmbPartNO.Text;
        //    btnSN.Text = barcodeZ.ToString();

        //}

        private void BARCODE()
        {
            //string barcodeA = textBox1.Text;

            //bitmA = new Bitmap(barcodeA.Length * 65, 180);

            //using (Graphics graphic = Graphics.FromImage(bitmA))
            //{
            //    Font newfont = new Font("IDAutomationHC39M", 16);
            //    Font newfontB = new Font("verdana", 10);
            //    PointF pointA = new PointF(5f, 5f);
            //    SolidBrush black = new SolidBrush(Color.Black);
            //    SolidBrush white = new SolidBrush(Color.White);
            //    graphic.FillRectangle(white, 5, 5, bitmA.Width, bitmA.Height);
            //    graphic.DrawString("*" + barcodeA + "*", newfont, black, pointA);
            //    //graphic.DrawString(A, newfontB, blue, pointB);
            //}
            //using (MemoryStream Mmst = new MemoryStream())
            //{
            //    bitmA.Save("ms", ImageFormat.Jpeg);
            //    pictureBox1.Image = bitmA;
            //    pictureBox1.Width = bitmA.Width;
            //    pictureBox1.Height = bitmA.Height;
            //}
        }

        private void btn_Barcode_Click(object sender, EventArgs e)
        {
            cmbPartNO.Text = "";
            cmbPartNO.Focus();
        }

        private void frm_IssueGoods_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 27)
            {
                cmbPartNO.Text = "";
                cmbPartNO.Focus();
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("");

            if (txt_Price.Text == "" || cmbPartNO.Text == "")
            {
                //MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                timer2.Enabled = false;
                timer3.Enabled = false;
                return;
            }

            //if (txt_Qty.Text == "-" || txt_Qty.Text == "" || txt_Qty.Text == "0")
            //{
            //    txt_Qty.Text = "1";
            //}

            try
            {
                QTY = int.Parse(txt_Qty.Text);
                
                if (lbl_UOM.Text == "LITERS")
                {
                    
                    try
                    {
                        BAL_QTY = int.Parse(lbl_BalQty.Text);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else if (lbl_UOM.Text != "LITERS")
                {
                    try
                    {
                        BAL_QTY = decimal.Parse(lbl_BalQty.Text);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }

                if (QTY > BAL_QTY)
                {
                    //MessageBox.Show("Please Enter Less Issue Amount to Proceed", "Issue Goods Info");
                    timer2.Enabled = false;
                    timer3.Enabled = false;
                    return;
                }

                if (txt_Price.Text == "" ||  txt_Qty.Text == "")
                {
                    //MessageBox.Show("Please Enter Required Data and Proceed", "Issue Goods Info");
                    timer2.Enabled = false;
                    timer3.Enabled = false;
                    return;
                }

                decimal CALQTY = Convert.ToDecimal(txt_Qty.Text);
                if (lblShow.Text == "")
                {
                    lblShow.Text = "0";
                }
                decimal CALVAL = Convert.ToDecimal(lblShow.Text);
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
                         
                        if (lbl_UOM.Text == "LITERS")
                        {
                            QTY = Convert.ToInt16(dreader["QTY"].ToString().Trim());
                            BAL_QTY = Convert.ToInt16(dreader["BAL_QTY"].ToString().Trim());
                        }
                        else if (lbl_UOM.Text != "LITERS")
                        {
                            QTY = Convert.ToDecimal(dreader["QTY"].ToString().Trim());
                            BAL_QTY = Convert.ToDecimal(dreader["BAL_QTY"].ToString().Trim());
                        }
                        
                       
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
                                cmdsql1.CommandText = "INSERT INTO ISSUED_ITEMS (PARTNO, ORGQTY, QTY, PRICE, S_NO, REMARKS, PRO_DATE, TOT, STATUS, RECEIVE_SEQNO) VALUES ('" + cmbPartNO.Text + "','" + QTY + "', '" + TOTCALQTY + "','" + CALUNIT + "', '" + cmbPartNO.Text + "','" + txtRemarks.Text + "',Convert(DateTime,'" + lblDate.Text + "'),'" + TOT_ISSUE + "', '1', '" + SEQ_NO + "')";
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

                                cmdsql1.CommandText = "INSERT INTO ISSUED_ITEMS (PARTNO, ORGQTY, QTY, PRICE, S_NO, REMARKS, PRO_DATE, TOT, STATUS, RECEIVE_SEQNO) VALUES ('" + cmbPartNO.Text + "','" + QTY + "', '" + BAL_QTY + "', '" + CALUNIT + "', '" + cmbPartNO.Text + "','" + txtRemarks.Text + "',Convert(DateTime,'" + lblDate.Text + "'),'" + ENDCAL + "', '1', '" + SEQ_NO + "')";
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
                //MessageBox.Show("Items Issue Entry Successfully Added");
            }
            catch (Exception)
            {
                ////MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Issue Goods Info");
                return;
            }
            _Conn.Close();
            ShowDetails();
            //ClearData();
            btn_Save.Enabled = false;

            timer6.Enabled = true;
            
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = false;

            Load_BALQTYS();

            lblAll.Text = "";
            lblShow.Text = "";
            txt_Price.Text = "";
            txt_Qty.Text = "";
            TOTAMOUNTS();
            cmbPartNO.Text = "";
            cmbPartNO.Focus();
        }

        private void txt_Qty_Enter(object sender, EventArgs e)
        {
            cmbPartNO.DroppedDown = false;
            timer5.Enabled = true;

            timer3.Enabled = true;
        }

        private void cmbPartNO_TextChanged(object sender, EventArgs e)
        {
            //timer4.Enabled = true;
        }

        private void txt_Qty_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //double XXX = 123.45;
            //double XXXX = 123.45;
            //double XXXXX = 123.45;
            ////double VVV= Math.Round(Convert.ToDouble(VV).ToString(), MidpointRounding.AwayFromZero);
            //double VVV = Math.Round(XXX, 2, MidpointRounding.ToEven); // Rounds to even
            //double VVVV = Math.Round(XXXX, 1, MidpointRounding.AwayFromZero); // Rounds to even
            //double VVVVV = Math.Round(XXXXX, 0); // Rounds to even
            //textBox4.Text = Convert.ToDecimal(VVV).ToString();
            //textBox3.Text = Convert.ToDecimal(VVVV).ToString();
            //textBox5.Text = Convert.ToDecimal(VVVVV).ToString();
            ////.ToString("###,###,##0.00");


            decimal B = decimal.Parse(textBox3.Text);
            decimal C = Math.Round(B / 5, 0) * 5;
            textBox5.Text = Convert.ToDecimal(C).ToString();
        }

        private void timer5_Tick_1(object sender, EventArgs e)
        {
            try
            {
                decimal V = Math.Round(decimal.Parse(lblLastPrice.Text) / 5, 0) * 5;
                decimal Q = decimal.Parse(txt_Qty.Text);
                decimal T = Math.Round(V * Q / 5, 0) * 5;
                txt_Price.Text = Convert.ToDecimal(V).ToString("###,###,###");
                lblShow.Text = Convert.ToDecimal(T).ToString("###,###,###");
            }
            catch (Exception)
            {

            }
        }

        private void cmbPartNO_Enter(object sender, EventArgs e)
        {
            ClearDataPartNo();
         
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = false;

            //chn_Auto.Enabled = false;
        }

        private void txtDis_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            LoadUSER();
            timer8.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cmbPartNO.Focus();
            TOTAMOUNTS();
            ChecksStatus();
        }

        private void cmbPartNO_KeyDown(object sender, KeyEventArgs e)
        {
            //int ccc = e.KeyValue;
            //int iii = (int)ccc;
            //if (iii == 119)
            //{
            //    LoadINo();
            //    cmbPartNO.Focus();
            //    TOTAMOUNTS();
            //    cmb_CusDesc.Focus();
            //    ChecksStatus();
            //    tbAdd.Visible = false;
            //}

            //int cc = e.KeyValue;
            //int ii = (int)cc;
            //if (ii == 121)
            //{
            //    timer7.Enabled = true;

            //    Connection.DatabaseConnection obyConn;
            //    obyConn = new Connection.DatabaseConnection();
            //    _Conn = obyConn.Connect();
            //    SqlCommand cmdsql = new SqlCommand();
            //    cmdsql.Connection = _Conn;
            //    cmdsql.CommandText = "SELECT STATUS, INV_NO FROM ISSUED_ITEMS WHERE INV_NO = '" + txtInvoice.Text + "'";
            //    SqlDataReader dreader = cmdsql.ExecuteReader();
            //    while (dreader.Read())
            //    {
            //        if (dreader.HasRows == true)
            //        {
            //            tbAdd.Visible = true;
            //            txtDis.Focus();
            //        }
            //    }
            //}
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            Grid_A.Refresh();
            Grid_A.ClearSelection();
            timer9.Enabled = false;
        }

        private void New()
        {
            cmbPartNO.Focus();
            TOTAMOUNTS();
            ChecksStatus();
            //tbAdd.Visible = false;
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPart_TextChanged(object sender, EventArgs e)
        {
            //Connection.DatabaseConnection obyConn;
            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();
            //SqlCommand cmdsql = new SqlCommand();
            //cmdsql.Connection = _Conn;
            //cmdsql.CommandText = "SELECT PART FROM MASTER WHERE (PART LIKE '%" + cmbPart.Text + "%')ORDER BY CASE WHEN PART = '" + cmbPart.Text + "' THEN 0 WHEN PART LIKE '" + cmbPart.Text + " % ' THEN 1 WHEN PART LIKE ' %" + cmbPart.Text + "% ' THEN 2 WHEN PART LIKE ' %" + cmbPart.Text + "' THEN 3 ELSE 4 END, PART";
            ////SELECT PART FROM MASTER WHERE (PART LIKE '" + cmbPart.Text + "')ORDER BY LEFT(PARTNO, 1)";
            //SqlDataReader dreader = cmdsql.ExecuteReader();
            //while (dreader.Read())
            //{
            //    if (dreader.HasRows == true)
            //    {
                    
            //        cmbPart.Items.Add(dreader["PART"].ToString());
                    
            //    }
                
            //}
            //cmbPart.DroppedDown = true;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            lblShow.Text = "";
            lblAll.Text = "";


            TOTAMOUNTS();
            //ISSUEAMOUNT();
            ChecksStatus();



        }

        private void cmb_CusDesc_Leave(object sender, EventArgs e)
        {
            //if (cmb_CusDesc.Text == "")
            //{
            //    cmb_CusDesc.Text = "CASH";
            //}
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //tbProfit.Visible = false;
            //tbAdd.Visible = true;
            //txtDis.Focus();
            cmbCat.Focus();
            cmbCat.DroppedDown = true;
        }

        private void lblProfitPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //tbProfit.Visible = false;
                //tbAdd.Visible = true;
                //txtDis.Focus();
                cmbCat.Focus();
                cmbCat.DroppedDown = true;
            }
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            txt_Qty.Text = "-";
            cmbPartNO.Focus();
            timer10.Enabled = false;
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            cmbPartNO.Focus();
            timer11.Enabled = false;
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                CUS();
                SHOW();
                ShowDetails();
                cmbPartNO.Focus();
                LoadParts();
            }
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

        private void CUS()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT SEQ_NO, NAME FROM CUSTOMER_INFO", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                lblCusName.Text = drReader["NAME"].ToString(); // + " - " + drTenMain["NAME"].ToString());
                lblCusID.Text = drReader["SEQ_NO"].ToString(); // + " - " + drTenMain["NAME"].ToString());
            }
            drReader.Close();
            _Conn.Close();
        }

        private void TOTCOST()
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();

            //SqlCommand cmdReader = new SqlCommand("SELECT TOT_COST_AMOUNT FROM JOB_DETAILS WHERE SEQ_NO = '" + SEQ + "'", _Conn);
            //SqlDataReader drReader = cmdReader.ExecuteReader();
            //while (drReader.Read())
            //{
            //    lblTOTCOST.Text = drReader["TOT_COST_AMOUNT"].ToString(); // + " - " + drTenMain["NAME"].ToString());
            //}
            //drReader.Close();
            //_Conn.Close();
        }
          

        private void SHOW()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT  SEQ_NO, JOB_NO FROM JOB_DETAILS WHERE JOB_NO = '" + txtNo.Text + "' AND STATUS = 1", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                SEQ = int.Parse(drReader["SEQ_NO"].ToString());
                txtNo.Text = drReader["JOB_NO"].ToString();
            }
            drReader.Close();
            _Conn.Close();
        }

        private void timer12_Tick_1(object sender, EventArgs e)
        {
            txtNo.Focus();
            timer12.Enabled = false;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (chkNo.Checked == true)
            {
                try
                {
                    Connection.DatabaseConnection obyConn;

                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _Conn;
                    cmdsql1.CommandText = "INSERT INTO ISSUED_ITEMS (SEQ, SYS_USER, PARTNO, ORGQTY, QTY, PRICE, REMARKS, PRO_DATE, TOT, STATUS, RECEIVE_SEQNO, LOCATION, PRO_TIME) VALUES ('" + SEQ__NO + "', '" + lblUser.Text + "', '0','0', '0','0', '',Convert(DateTime,'" + lblDate.Text + "'),'0', '1', '0', '', '" + DateTime.Now + "')";
                    cmdsql1.ExecuteNonQuery();
                    MessageBox.Show("Completed Not Issuing any Items for the job - Proceed Now", "Issue Goods Info");
                }
                catch (Exception)
                {

                }
            }
            
        }
    }
}