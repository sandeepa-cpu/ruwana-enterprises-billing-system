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
    public partial class frm_ReceiveGoods : Form
    {
        public frm_ReceiveGoods()
        {
            InitializeComponent();
        }
        Decimal AMOUNT;
        private SqlConnection _Conn;
        decimal PURCHASE = 0;
        decimal TOT_PURCHASE = 0;
        decimal DISC = 0;
        decimal TRANS = 0;
        decimal LOAD = 0;
        decimal OTHER = 0;
        decimal ALLDISPER, PERCENTAGE = 0;
        decimal QTY = 0;
        decimal DISCOUNTPRICE, NORMALPRICE, TOT = 0;
        decimal CASH, ALLDISC, DISPER, PER, RTOT, SEQ, ITOT, ETOT = 0;
        public static string InvNo = "";
        public static string InvAmount = "";
        string BARCODE = "";
        int SEQNO;

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdTenMain = new SqlCommand("SELECT INV_NO FROM RECEIVED_TOTALS WHERE INV_NO ='" + txtInvoice.Text + "'", _Conn);
            SqlDataReader drTenMain = cmdTenMain.ExecuteReader();
            drTenMain.Read();
            if (drTenMain.HasRows == false)
            {
                drTenMain.Dispose();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _Conn;
                cmdsql1.CommandText = "INSERT INTO RECEIVED_TOTALS (INV_NO) VALUES ('" + txtInvoice.Text + "')";
                cmdsql1.ExecuteNonQuery();
            }
            drTenMain.Dispose();
            _Conn.Close();
                //try
                //{
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();

                    if (txt_Price.Text == "" || txtInvoice.Text == "" || txt_Qty.Text == "" || cmb_SupDesc.Text == "" || cmbPartNO.Text == "")
                    {
                        //MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                        cmb_SupDesc.Focus();
                        return;
                    }

                    decimal A = decimal.Parse(textBox9.Text);
                    decimal B = decimal.Parse(txt_Qty.Text);
                    decimal C = A * B;

                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "INSERT INTO RECEIVED_ITEMS (BARNO, SYS_USER, PARTNO, SUPPLIER, INV_NO, QTY, BAL_QTY, PRICE, S_NO, REMARKS, PRO_DATE, TOT, STATUS, DIS_PRICE, ISSUE_PRICE) VALUES ('" + txtBarNo.Text + "', '" + lblUser.Text + "', '" + cmbPartNO.Text + "','" + lbl_SupCode.Text + "','" + txtInvoice.Text + "', '" + txt_Qty.Text + "', '" + txt_Qty.Text + "','" + txt_Price.Text + "', '" + txtBarNo.Text + "','" + txtRemarks.Text + "',Convert(DateTime,'" + lbl_Date.Text + "'),'" + lbl_TotCost.Text + "', '1','" + txt_Dis.Text + "', '" + C + "')";
                    cmdsql.ExecuteNonQuery();
                    AuditLog.Write("EDIT", "frm_ReceiveGoods", cmbPartNO.Text + " invoice " + txtInvoice.Text);
                    //MessageBox.Show("Items Received Entry Successfully Added");
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Received Goods Info");
                //    return;
                //}

            //SqlCommand cmdsql1 = new SqlCommand();
            //cmdsql1.Connection = _Conn;
            //cmdsql1.CommandText = "INSERT INTO RECEIVED_TOTALS (INV_NO) VALUES ('" + txtInvoice.Text + "')";
            //cmdsql1.ExecuteNonQuery();
            lblAll.Text = "";
            lblShow.Text = "";
            txt_Qty.Text = "";
            txt_Price.Text = "";
            textBox9.Text = "";
            txt_Dis.Text = "";
            txtBarNo.Text = "";

            TOTAMOUNT();
            _Conn.Close();
            ShowDetails();
            timer4.Enabled = true;
            txtBarNo.Focus();
        }

        private void ClearData()
        {
            cmbMake.ResetText();
            cmbPart.ResetText();
            cmbCat.ResetText();
            cmbSub.ResetText();
            //cmb_SupDesc.ResetText();
            lbl_UOM.Text = "";
            lbl_ROL.Text = "";
            lbl_ROQ.Text = "";
            lbl_Locate.Text = "";
            lbl_CabNo.Text = "";
            lbl_RackNo.Text = "";
            lbl_BinNo.Text = "";
            lbl_SPNo.Text = "";
            txt_Load.Text = "0.00";
            txt_Other.Text = "0.00";
            txt_Price.Text = "0.00";
            txt_Qty.Text = "0.00";
            txt_Trans.Text = "0.00";
            txt_Dis.Text = "0.00";
            //txtInvoice.Text = "";
            txtRemarks.Text = "";
            txtSN.Text = "";
            lbl_BalQty.Text = "";
            lbl_MaxQty.Text = "0";
            lbl_MinQty.Text = "0";
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
            lbl_SPNo.Text = "";
            txt_Load.Text = "0.00";
            txt_Other.Text = "0.00";
            txt_Trans.Text = "0.00";
            txt_Dis.Text = "0.00";
            lbl_BalQty.Text = "";
            lbl_MaxQty.Text = "0";
            lbl_MinQty.Text = "0";
        }


        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            //SqlDataAdapter drLoan = new SqlDataAdapter("SELECT RECEIVED_ITEMS.PARTNO, SUPPLIER_INFO.NAME, RECEIVED_ITEMS.INV_NO, RECEIVED_ITEMS.BAL_QTY, RECEIVED_ITEMS.PRICE, RECEIVED_ITEMS.DISCOUNT, RECEIVED_ITEMS.TOT, RECEIVED_ITEMS.S_NO, RECEIVED_ITEMS.STATUS, RECEIVED_ITEMS.DEL, RECEIVED_ITEMS.SEQ_NO FROM RECEIVED_ITEMS INNER JOIN SUPPLIER_INFO ON RECEIVED_ITEMS.SUPPLIER = SUPPLIER_INFO.SEQ_NO WHERE (RECEIVED_ITEMS.INVNO = '" + txtInvoice.Text + "') AND (RECEIVED_ITEMS.PRO_DATE =  CONVERT(DATETIME, '" + lbl_Date.Text + "', 102)) ORDER BY RECEIVED_ITEMS.INV_NO, RECEIVED_ITEMS.SEQ_NO", _Conn);
            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT RECEIVED_ITEMS.PARTNO, MASTER.DESCRIPTION, RECEIVED_ITEMS.BAL_QTY, RECEIVED_ITEMS.PRICE, RECEIVED_ITEMS.TOT, RECEIVED_ITEMS.S_NO, RECEIVED_ITEMS.STATUS, RECEIVED_ITEMS.DEL, RECEIVED_ITEMS.SEQ_NO FROM RECEIVED_ITEMS INNER JOIN SUPPLIER_INFO ON RECEIVED_ITEMS.SUPPLIER = SUPPLIER_INFO.SEQ_NO INNER JOIN MASTER ON RECEIVED_ITEMS.PARTNO = MASTER.PARTNO WHERE (RECEIVED_ITEMS.INV_NO = '" + txtInvoice.Text + "') ORDER BY RECEIVED_ITEMS.SEQ_NO DESC", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "RECEIVED_ITEMS");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "RECEIVED_ITEMS";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 150;
            Grid_A.Columns[0].HeaderText = "PART NO";
            Grid_A.Columns[1].Width = 220;
            Grid_A.Columns[1].HeaderText = "DESCRIPTION";
            Grid_A.Columns[2].Width = 120;
            Grid_A.Columns[2].HeaderText = "QUANTITY";
            Grid_A.Columns[3].Width = 120;
            Grid_A.Columns[3].HeaderText = "PRICE";
            Grid_A.Columns[4].Width = 150;
            Grid_A.Columns[4].HeaderText = "TOTAL";
            Grid_A.Columns[5].Width = 150;
            Grid_A.Columns[5].HeaderText = "S_NO";
            Grid_A.Columns[6].Width = 120;
            Grid_A.Columns[6].HeaderText = "";
            Grid_A.Columns[7].Width = 0;
            Grid_A.Columns[7].HeaderText = "";
            Grid_A.Columns[8].Width = 20;
            Grid_A.Columns[8].HeaderText = "*";


            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[5].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[6].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[7].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[8].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[3].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[5].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[6].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[7].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[8].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;
            //Grid_A.Columns[3].ReadOnly = true;
            Grid_A.Columns[4].ReadOnly = true;
            Grid_A.Columns[5].ReadOnly = true;
            //Grid_A.Columns[6].ReadOnly = true;
            Grid_A.Columns[7].ReadOnly = true;
            //Grid_A.Columns[8].ReadOnly = true;
            Grid_A.Columns[7].Visible = false;

            Grid_A.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

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

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            lblShow.Text = "";
            lblAll.Text = "";

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT RECEIVED_ITEMS.PARTNO, MASTER.PART, MASTER.DESCRIPTION, RECEIVED_ITEMS.BAL_QTY, RECEIVED_ITEMS.PRICE, RECEIVED_ITEMS.TOT, RECEIVED_ITEMS.S_NO, RECEIVED_ITEMS.STATUS, RECEIVED_ITEMS.DEL, RECEIVED_ITEMS.SEQ_NO FROM RECEIVED_ITEMS INNER JOIN SUPPLIER_INFO ON RECEIVED_ITEMS.SUPPLIER = SUPPLIER_INFO.SEQ_NO INNER JOIN MASTER ON RECEIVED_ITEMS.PARTNO = MASTER.PARTNO WHERE (RECEIVED_ITEMS.INV_NO = '" + txtInvoice.Text + "') ORDER BY RECEIVED_ITEMS.SEQ_NO DESC", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "RECEIVED_ITEMS");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["RECEIVED_ITEMS"].Rows)
            {
                thisDataset.Tables["RECEIVED_ITEMS"].Rows[count]["SEQ_NO"] = Grid_A.Rows[count].Cells[9].Value.ToString();
                thisDataset.Tables["RECEIVED_ITEMS"].Rows[count]["S_NO"] = Grid_A.Rows[count].Cells[6].Value.ToString();
                
                SEQNO = int.Parse(Grid_A.Rows[count].Cells[9].Value.ToString());
                BARCODE = Grid_A.Rows[count].Cells[6].Value.ToString();
                
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "UPDATE RECEIVED_ITEMS SET S_NO = '"+ BARCODE +"'WHERE (SEQ_NO = '" + SEQNO + "')";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                _Conn.Dispose();
                count++;
            }
            _Conn.Close();
            MessageBox.Show("Successfully Updated", "Update Info.");
            ShowDetails();
        }

        private void cmb_SupDesc_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQ_NO FROM SUPPLIER_INFO WHERE (NAME = '" + cmb_SupDesc.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_SupCode.Text = dreader["SEQ_NO"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
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

        private void frm_ReceiveGoods_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            //frm_SupplierProfile frm_User = new frm_SupplierProfile();
            //frm_User.MdiParent = this;
            LoadINo();
            LoadSup();
            PRO_DATE();
            txtInvoice.Focus();
            //txtInvoice.Text = "-";
            txtInvoice.SelectAll();
            txt_Qty.Text = "-";
        }

        private void LoadINo()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            SqlDataReader dreader = null;
            try
            {
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "SELECT SEQ_NO AS SEQ_NO, INV_NO AS INV_NO FROM RECEIVED_ITEMS ORDER BY SEQ_NO DESC";
                dreader = cmdsql.ExecuteReader();
                while (dreader.Read())
                {
                    int NO = int.Parse(dreader["INV_NO"].ToString());
                    NO = NO + 1;
                    txtInvoice.Text = NO.ToString();
                    break;
                }
            }
            finally
            {
                if (dreader != null)
                {
                    dreader.Dispose();
                }
                cmdsql.Dispose();
                if (_Conn != null)
                {
                    _Conn.Close();
                }
            }
        }

        private void Load_Data_PARTNO()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO, BARNO FROM  MASTER WHERE PARTNO  = '" + cmbPartNO.Text + "'";
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
                txtBarNo.Text = dreader["BARNO"].ToString();

            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Load_Data_BARNO()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNo FROM  MASTER WHERE BARNO  = '" + txtBarNo.Text + "'";
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
                lbl_SPNo.Text = dreader["SPNO"].ToString();
                //lbl_MaxQty.Text = dreader["MAXQTY"].ToString();
                //lbl_MinQty.Text = dreader["MINQTY"].ToString();
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
                lbl_MaxQty.Text = dreader["MAXQTY"].ToString();
                lbl_MinQty.Text = dreader["MINQTY"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void LoadUSER()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT C_USER FROM  [CURRENT_USER]";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblUser.Text = dreader["C_USER"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Load_BALQTY()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUM(BAL_QTY) AS QTY, STATUS, PARTNO FROM RECEIVED_ITEMS GROUP BY STATUS, PARTNO HAVING (STATUS = 1) AND (PARTNO  = '" + cmbPartNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                if (lbl_UOM.Text == "LITERS")
                {
                    lblCLOSE.Visible = false;
                }
                else if (lbl_UOM.Text != "LITERS")
                {
                    lblCLOSE.Visible = true;
                }
                lbl_BalQty.Text = dreader["QTY"].ToString();
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
            cmdsql.CommandText = "SELECT SUM(BAL_QTY) AS QTY, STATUS FROM RECEIVED_ITEMS WHERE (BARNO = '" + txtBarNo.Text + "')GROUP BY STATUS, PARTNO, BARNO HAVING (STATUS = 1)";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_BalQty.Text = dreader["QTY"].ToString();

                if (lbl_UOM.Text == "LITERS")
                {
                    lblCLOSE.Visible = false;
                }
                else if (lbl_UOM.Text != "LITERS")
                {
                    lblCLOSE.Visible = true;
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
              //l_ProDate.Text = dreader["PRO_DATE"].ToString();
                lbl_Date.Text = dreader["PRO_DATE"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
            //lbl_DATE.Text = DateTime.Today.Date.ToLongDateString();
            lbl_Date.Text = String.Format("{0:yyyy - MM - dd}", lbl_Date.Text);
             //this.dt_Birth.CustomFormat = "yyyy-MM-dd";
        }

        private void LoadSup()
        {
            cmb_SupDesc.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT NAME FROM SUPPLIER_INFO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmb_SupDesc.Items.Add(dreader["NAME"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        //private void LoadCat()
        //{
        //    cmbCat.Items.Clear();

        //    Connection.DatabaseConnection obyConn;
        //    obyConn = new Connection.DatabaseConnection();
        //    _Conn = obyConn.Connect();
        //    SqlCommand cmdsql = new SqlCommand();
        //    cmdsql.Connection = _Conn;
        //    cmdsql.CommandText = "SELECT CATEGORY FROM CATEGORY";
        //    SqlDataReader dreader = cmdsql.ExecuteReader();
        //    while (dreader.Read())
        //    {
        //        cmbCat.Items.Add(dreader["CATEGORY"].ToString());
        //    }
        //    cmdsql.Dispose();
        //    dreader.Dispose();
        //    _Conn.Close();
        //}

        //private void LoadModel()
        //{
        //    cmbPart.Items.Clear();

        //    Connection.DatabaseConnection obyConn;
        //    obyConn = new Connection.DatabaseConnection();
        //    _Conn = obyConn.Connect();
        //    SqlCommand cmdsql = new SqlCommand();
        //    cmdsql.Connection = _Conn;
        //    cmdsql.CommandText = "SELECT PART FROM PART WHERE MAKE = '" + cmbMake.Text + "'";
        //    SqlDataReader dreader = cmdsql.ExecuteReader();
        //    while (dreader.Read())
        //    {
        //        cmbPart.Items.Add(dreader["MODEL"].ToString());

        //    }
        //    cmdsql.Dispose();
        //    dreader.Dispose();
        //    _Conn.Close();
        //}

        //private void LoadMakes()
        //{
        //    cmbMake.Items.Clear();

        //    Connection.DatabaseConnection obyConn;
        //    obyConn = new Connection.DatabaseConnection();
        //    _Conn = obyConn.Connect();
        //    SqlCommand cmdsql = new SqlCommand();
        //    cmdsql.Connection = _Conn;
        //    cmdsql.CommandText = "SELECT MAKE FROM MAKE";
        //    SqlDataReader dreader = cmdsql.ExecuteReader();
        //    while (dreader.Read())
        //    {
        //        cmbMake.Items.Add(dreader["MAKE"].ToString());
        //    }
        //    cmdsql.Dispose();
        //    dreader.Dispose();
        //    _Conn.Close();
        //}

        private void cmbMake_SelectedValueChanged(object sender, EventArgs e)
        {

            cmbPart.Enabled = true;
            cmbPartNO.Enabled = true;
            cmbPart.Items.Clear();
            cmbPartNO.Items.Clear();
            LoadPart();
            cmbDesc.Enabled = false;
            MAKESEQ();
        }

        private void LoadPart()
        {
            cmbPart.Items.Clear();
            cmbPartNO.Items.Clear();
            cmbPart.Text = "";
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

        private void MAKESEQ()
        {
            txtMake.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQNO FROM MAKE WHERE CATEGORY = '" + cmbCat.Text + "' AND MAKE = '" + cmbMake.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txtMake.Text = dreader["SEQNO"].ToString().Trim();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void cmbMake_Enter(object sender, EventArgs e)
        {
            //cmbPart.Enabled = false;
            //cmbPart.Text = "";
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void cmbCat_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbMake.Enabled = true;
            LoadMake();
        }

        private void PARTSEQ()
        {
            txtPart.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQNO FROM PART WHERE PART = '" + cmbPart.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txtPart.Text = dreader["SEQNO"].ToString().Trim();
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
            cmdsql.CommandText = "SELECT SEQNO, PART, PARTNO, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO FROM MASTER WHERE (PART = '" + cmbPart.Text.Trim() + "') ORDER BY DESCRIPTION";
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

        private void LoadByPartNo()
        {
            cmbPart.Text = "";
            cmbDesc.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO, DESCRIPTION FROM MASTER WHERE (PARTNO = '" + cmbPartNO.Text + "')";
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

        private void LoadByBarNo()
        {
            cmbPart.Text = "";
            cmbDesc.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO, PART FROM MASTER WHERE (BARNO = '" + txtBarNo.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPartNO.Text = dreader["PARTNO"].ToString();
                cmbPart.Text = dreader["PART"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
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

        private void LoadMake()
        {
            cmbMake.Enabled = true;
            cmbMake.Items.Clear();
            cmbPart.Items.Clear();
            cmbMake.Text = "";
            cmbPart.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT MAKE FROM MAKE WHERE CATEGORY = '" + cmbCat.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbMake.Items.Add(dreader["MAKE"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
            CATSEQ();
        }

        private void CATSEQ()
        {
            txtCat.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQNO FROM CATEGORY WHERE CATEGORY = '" + cmbCat.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txtCat.Text = dreader["SEQNO"].ToString().Trim();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void txt_Price_Leave(object sender, EventArgs e)
        {
            //try
            //{
                if (txt_Price.Text == "")
                    txt_Price.Text = "0";
                PURCHASE = decimal.Parse(txt_Price.Text);
                txt_Price.Text = PURCHASE.ToString("#####0");
                //txt_Price.Text = PURCHASE.ToString("###,##0"); 
                QTY = decimal.Parse(txt_Qty.Text);
                TOT_PURCHASE = PURCHASE * QTY;


                LOAD = decimal.Parse(txt_Load.Text);
                TRANS = decimal.Parse(txt_Trans.Text);
                OTHER = decimal.Parse(txt_Other.Text);
                TOT = (TOT_PURCHASE - DISC) + LOAD + TRANS + OTHER;
                lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("#####0");
                lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,##0");
                //this.dt_Birth.CustomFormat = "yyyy-MM-dd";

            //}
            //catch (Exception)
            //{

            //}
        }

        private void txt_Trans_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_Trans.Text == "")
                    txt_Trans.Text = "0";
                //PURCHASE = decimal.Parse(txt_Price.Text);
                LOAD = decimal.Parse(txt_Load.Text);
                TRANS = decimal.Parse(txt_Trans.Text);
                txt_Trans.Text = TRANS.ToString("#####0");

                OTHER = decimal.Parse(txt_Other.Text);
                TOT = (TOT_PURCHASE - DISC) + LOAD + TRANS + OTHER;
                lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("#####0");
                lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,##0");
            }
            catch (Exception)
            {

            }
        }

        private void txt_Load_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_Load.Text == "")
                    txt_Load.Text = "0";
                //PURCHASE = decimal.Parse(txt_Price.Text);
                LOAD = decimal.Parse(txt_Load.Text);
                txt_Load.Text = LOAD.ToString("#####0");

                TRANS = decimal.Parse(txt_Trans.Text);
                OTHER = decimal.Parse(txt_Other.Text);
                TOT = (TOT_PURCHASE - DISC) + LOAD + TRANS + OTHER;
                lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("#####0");
                lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,##0");
            }
            catch (Exception)
            {

            }

        }

        private void txt_Other_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_Other.Text == "")
                    txt_Other.Text = "0";
                //PURCHASE = decimal.Parse(txt_Price.Text);
                LOAD = decimal.Parse(txt_Load.Text);
                TRANS = decimal.Parse(txt_Trans.Text);
                OTHER = decimal.Parse(txt_Other.Text);
                txt_Other.Text = OTHER.ToString("#####0");

                TOT = (TOT_PURCHASE - DISC) + LOAD + TRANS + OTHER;
                lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("#####0");
                lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,##0");
            }
            catch (Exception)
            {

            }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_SupplierProfile frmGen = new frm_SupplierProfile();
            frmGen.TopMost = true;
            frmGen.Show();
            this.Hide();
            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string APRVD;
            int SEQNO;

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT RECEIVED_ITEMS.PARTNO, MASTER.PART, MASTER.DESCRIPTION, RECEIVED_ITEMS.BAL_QTY, RECEIVED_ITEMS.PRICE, RECEIVED_ITEMS.TOT, RECEIVED_ITEMS.S_NO, RECEIVED_ITEMS.STATUS, RECEIVED_ITEMS.DEL, RECEIVED_ITEMS.SEQ_NO FROM RECEIVED_ITEMS INNER JOIN SUPPLIER_INFO ON RECEIVED_ITEMS.SUPPLIER = SUPPLIER_INFO.SEQ_NO INNER JOIN MASTER ON RECEIVED_ITEMS.PARTNO = MASTER.PARTNO WHERE (RECEIVED_ITEMS.INV_NO = '" + txtInvoice.Text + "') ORDER BY RECEIVED_ITEMS.SEQ_NO DESC", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "DELETE_ENTRY");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["DELETE_ENTRY"].Rows)
            {
                APRVD = Grid_A.Rows[count].Cells[8].Value.ToString();
                SEQNO = Convert.ToInt32(Grid_A.Rows[count].Cells[9].Value.ToString());

                if (APRVD == "True")
                {
                    //try
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "DELETE FROM RECEIVED_ITEMS WHERE SEQ_NO = '" + SEQNO + "'";
                    SqlDataReader dreader = cmdsql.ExecuteReader();
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
            MessageBox.Show("Records are Successfully Deleted", "Deleting Entries");
            lblAll.Text = "";
            lblShow.Text = "";
            TOTAMOUNT();
        }

        private void cmbPart_SelectedValueChanged(object sender, EventArgs e)
        {
            //PARTSEQ();
            LoadPartNoDesc();
            //cmbDesc.Enabled = true;
            //cmbPartNO.Enabled = true;
            cmbDesc.Enabled = false;
            txtInvoice.Enabled = true;
        }

        private void cmbPartNO_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearDataPartNo();
            //lbl_BalQty.Text = "";
            //lblShow.Text = "";
            LoadByPartNo();
            Load_Data_PARTNO();
            Load_BALQTY();
            //ShowDetails();
            cmbDesc.Enabled = false;
        }

        private void cmbDesc_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearDataPartNo();
            //lbl_BalQty.Text = "";
            //lblShow.Text = "";
            LoadByDesc();
            Load_Data_DESC();
            Load_BALQTY();
            ShowDetails();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtInvoice.Focus();
            //cmb_SupDesc.Focus();
            //cmb_SupDesc.DroppedDown = true;
            timer1.Enabled = false;

        }

        private void cmb_SupDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                 if (cmb_SupDesc.Text == "")
                {
                    cmb_SupDesc.Text = "CASH";

                }
                cmbPart.Enabled = true;
                cmbPartNO.Enabled = true;
                cmbPart.Items.Clear();
                cmbPartNO.Items.Clear();
                LoadPart();

                cmbPartNO.Focus();
            }
        }

        private void cmbCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbMake.Focus();
            }
        }

        private void cmbMake_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbPartNO.Focus();
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
                txtInvoice.Enabled = true;
                txtInvoice.Focus();
            }
        }

        private void txtInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (txtInvoice.Text == "")
            {
                MessageBox.Show("Please Enter the Invoice No. to proceed");
                txtInvoice.Focus();
                return;
            }

            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //ShowDetails();
                TOTAMOUNT();
                cmb_SupDesc.Focus();
                SelectSUPPLIER();
              

            }
            
        }

        private void SelectSUPPLIER()
        {
            //Connection.DatabaseConnection obyConn;
            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();
            //SqlCommand cmdsql = new SqlCommand();
            //cmdsql.Connection = _Conn;
            //cmdsql.CommandText = "SELECT INV_NO, SUPPLIER FROM RECEIVED_ITEMS WHERE (INV_NO = '" + txtInvoice.Text + "')";
            //SqlDataReader dreader = cmdsql.ExecuteReader();
            //while (dreader.Read())
            //{
            //    CUS = dreader["SUPPLIER"].ToString().Trim();
            //    return;
            //    dreader.Dispose();
            //}
            //cmdsql.Dispose();


            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();
            //SqlCommand cmdsql1 = new SqlCommand();
            //cmdsql1.Connection = _Conn;
            //cmdsql1.CommandText = "SELECT SEQ_NO, NAME FROM SUPPLIER_INFO WHERE (SEQ_NO = '" + CUS + "')";
            //SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            //while (dreader1.Read())
            //{
            //    int CUSNAME = int.Parse(dreader1["SEQ_NO"].ToString());
            //    CUS = dreader1["NAME"].ToString().Trim();
            //    lbl_CusCode.Text = CUSNAME.ToString();
            //    cmb_CusDesc.Text = CUS.ToString();
            //    return;
            //    dreader1.Dispose();
            //}
            //cmdsql1.Dispose();
            //dreader1.Dispose();

            //_Conn.Close();
        }

        private void txt_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Qty.Text == "")
            {
                //MessageBox.Show("Please Enter the Quantity to proceed");
                txt_Qty.Focus();
                return;
            }

            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Price.Focus();
            }
        }

        private void txt_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Dis.Text = decimal.Parse(txt_Price.Text).ToString();
                textBox9.Focus();
            }
        }

        private void txtDis_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Trans.Focus();
            }
        }

        private void txt_Trans_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Load.Focus();
            }
        }

        private void txt_Load_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Other.Focus();
            }
        }

        private void txt_Other_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btnOK.Focus();
            }
        }

        private void txtSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtRemarks.Focus();
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

        private void btn_Save_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 27)
            {
                btn_Back.Focus();
            }
        }

        private void btn_Back_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 27)
            {
                this.Close();
            }
        }

        private void cmbSub_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                
            }
        }

        private void cmbSub_SelectedValueChanged(object sender, EventArgs e)
        {
       
            
        }

        private void LoadSub()
        {
            cmbSub.Items.Clear();
            cmbPart.Items.Clear();
            cmbPartNO.Items.Clear();
            cmbSub.Text = "";
            cmbPart.Text = "";
            cmbPartNO.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUBCAT FROM SUBCAT WHERE CATEGORY = '" + cmbCat.Text + "' AND MAKE = '" + cmbMake.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbSub.Items.Add(dreader["SUBCAT"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void SUBSEQ()
        {
            txtSub.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQNO FROM SUBCAT WHERE CATEGORY = '" + cmbCat.Text + "' AND MAKE = '" + cmbMake.Text + "'AND SUBCAT = '" + cmbSub.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txtSub.Text = dreader["SEQNO"].ToString().Trim();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void TOTAMOUNT()
        {
            txtSub.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUM(TOT) AS TOT, INV_NO FROM RECEIVED_ITEMS GROUP BY INV_NO HAVING (INV_NO = '" + txtInvoice.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblAll.Text = dreader["TOT"].ToString().Trim();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            InvNo = txtInvoice.Text;
            InvAmount = lblAll.Text;

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

                if (txt_Load.Text == "")
                {
                    txt_Load.Text = "0";
                }
                if (txt_Other.Text == "")
                {
                    txt_Other.Text = "0";
                }
                if (txt_Trans.Text == "")
                {
                    txt_Trans.Text = "0";
                }
              
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "UPDATE RECEIVED_TOTALS SET TRANS = '" + txt_Trans.Text + "', LOADING = '" + txt_Load.Text + "', OTHER = '" + txt_Other.Text + "' WHERE (INV_NO = '" + txtInvoice.Text + "')";
                cmdsql.ExecuteNonQuery();
                

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Received Goods Info");
            //    return;
            //}
            tbAdd.Visible = false;

            //if (MessageBox.Show("Do you want to Print the Invoice  ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //{
                //frm_PaymentMode frmPay = new frm_PaymentMode();
                //frmPay.Show();
                //tbAdd.Visible = false;
            //}
            _Conn.Close();

            //if (ckb1.Checked == true)
            //{
            //    PerDiscount();
            //    ckb1.Focus();
            //}
            //if (ckb2.Checked == true)
            //{
            //    TOTDiscount();
            //    ckb2.Focus();
            //}
            
            ShowDetails();
            ClearData();

            //tbProfit.Visible = true;
            //lblProfitPer.Focus();

            frm_PaymentMode frmPay = new frm_PaymentMode();
            frmPay.Show();

            //MessageBox.Show("Items Received Discount & Additional charges are Successfully Added");
        }
        
        //private void PerDiscount()
        //{
        //    DISPER = 0;
        //    DISCOUNTPRICE = 0;

        //    Connection.DatabaseConnection obyConn;

        //    obyConn = new Connection.DatabaseConnection();
        //    _Conn = obyConn.Connect();

        //    SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT RECEIVED_ITEMS.PARTNO, MASTER.PART, MASTER.DESCRIPTION, RECEIVED_ITEMS.BAL_QTY, RECEIVED_ITEMS.PRICE, RECEIVED_ITEMS.TOT, RECEIVED_ITEMS.S_NO, RECEIVED_ITEMS.STATUS, RECEIVED_ITEMS.DEL, RECEIVED_ITEMS.SEQ_NO FROM RECEIVED_ITEMS INNER JOIN SUPPLIER_INFO ON RECEIVED_ITEMS.SUPPLIER = SUPPLIER_INFO.SEQ_NO INNER JOIN MASTER ON RECEIVED_ITEMS.PARTNO = MASTER.PARTNO WHERE (RECEIVED_ITEMS.INV_NO = '" + txtInvoice.Text + "') ORDER BY RECEIVED_ITEMS.SEQ_NO DESC", _Conn);
        //    SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
        //    DataSet thisDataset = new DataSet();

        //    thisAdapter.Fill(thisDataset, "RECEIVED_ITEMS");

        //    int count = 0;

        //    foreach (DataRow dr in thisDataset.Tables["RECEIVED_ITEMS"].Rows)
        //    {
        //        thisDataset.Tables["RECEIVED_ITEMS"].Rows[count]["SEQ_NO"] = Grid_A.Rows[count].Cells[9].Value.ToString();
        //        thisDataset.Tables["RECEIVED_ITEMS"].Rows[count]["PRICE"] = Grid_A.Rows[count].Cells[4].Value.ToString();

        //        SEQNO = int.Parse(Grid_A.Rows[count].Cells[9].Value.ToString());
        //        NORMALPRICE = decimal.Parse(Grid_A.Rows[count].Cells[4].Value.ToString());
        //        DISPER = decimal.Parse(txtper.Text);

        //        if (DISPER != 0)
        //        {
        //            DISCOUNTPRICE = (NORMALPRICE / DISPER);
        //        }
        //        DISCOUNTPRICE = (NORMALPRICE - DISCOUNTPRICE);

        //        obyConn = new Connection.DatabaseConnection();
        //        _Conn = obyConn.Connect();
        //        SqlCommand cmdsql = new SqlCommand();
        //        cmdsql.Connection = _Conn;
        //        cmdsql.CommandText = "UPDATE RECEIVED_ITEMS SET DIS_PRICE = '" + DISCOUNTPRICE + "'WHERE (SEQ_NO = '" + SEQNO + "')";
        //        SqlDataReader dreader = cmdsql.ExecuteReader();
        //        _Conn.Dispose();
        //        count++;
        //    }
        //    _Conn.Close();
        //    //MessageBox.Show("Successfully Updated", "Update Info.");
        //    //ShowDetails();
        //}

        //private void TOTDiscount()
        //{
        //    CASH = 0;
        //    ALLDISC = 0;
        //    DISCOUNTPRICE = 0;
        //    ALLDISPER = 0;

        //    Connection.DatabaseConnection obyConn;

        //    obyConn = new Connection.DatabaseConnection();
        //    _Conn = obyConn.Connect();
            
        //    SqlCommand cmdsql = new SqlCommand();
        //    cmdsql.Connection = _Conn;
        //    cmdsql.CommandText = "SELECT CASH, DISCOUNT FROM RECEIVED_TOTALS WHERE (INV_NO  = '" + txtInvoice.Text + "')";
        //    SqlDataReader dreader = cmdsql.ExecuteReader();
        //    while (dreader.Read())
        //    {
        //        //CASH = decimal.Parse(dreader["CASH"].ToString());
        //        CASH = Convert.ToDecimal(lblAll.Text);
        //        ALLDISC = decimal.Parse(dreader["DISCOUNT"].ToString());
        //    }
        //    cmdsql.Dispose();
        //    dreader.Dispose();

        //    SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT RECEIVED_ITEMS.PARTNO, MASTER.PART, MASTER.DESCRIPTION, RECEIVED_ITEMS.BAL_QTY, RECEIVED_ITEMS.PRICE, RECEIVED_ITEMS.TOT, RECEIVED_ITEMS.S_NO, RECEIVED_ITEMS.STATUS, RECEIVED_ITEMS.DEL, RECEIVED_ITEMS.SEQ_NO FROM RECEIVED_ITEMS INNER JOIN SUPPLIER_INFO ON RECEIVED_ITEMS.SUPPLIER = SUPPLIER_INFO.SEQ_NO INNER JOIN MASTER ON RECEIVED_ITEMS.PARTNO = MASTER.PARTNO WHERE (RECEIVED_ITEMS.INV_NO = '" + txtInvoice.Text + "') ORDER BY RECEIVED_ITEMS.SEQ_NO DESC", _Conn);
        //    SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
        //    DataSet thisDataset = new DataSet();

        //    thisAdapter.Fill(thisDataset, "RECEIVED_ITEMS");

        //    int count = 0;

        //    foreach (DataRow dr in thisDataset.Tables["RECEIVED_ITEMS"].Rows)
        //    {
        //        thisDataset.Tables["RECEIVED_ITEMS"].Rows[count]["SEQ_NO"] = Grid_A.Rows[count].Cells[9].Value.ToString();
        //        thisDataset.Tables["RECEIVED_ITEMS"].Rows[count]["PRICE"] = Grid_A.Rows[count].Cells[4].Value.ToString();

        //        SEQNO = int.Parse(Grid_A.Rows[count].Cells[9].Value.ToString());
        //        NORMALPRICE = decimal.Parse(Grid_A.Rows[count].Cells[4].Value.ToString());
        //        DISPER = decimal.Parse(txtdis.Text);

        //        ALLDISPER = (ALLDISC / CASH) * 100;

        //        //ALLDISPER = Math.Round(ALLDISPER / 5, 0) * 5;
        //        //txt_Price.Text = ALLDISPER.ToString("###,###");
        //        //XXXX        =  11150       *  2.99
        //        DISCOUNTPRICE = (NORMALPRICE * ALLDISPER)/100;
        //        DISCOUNTPRICE = Math.Round(DISCOUNTPRICE / 5, 0) * 5;
        //        DISCOUNTPRICE = (NORMALPRICE - DISCOUNTPRICE);

        //        obyConn = new Connection.DatabaseConnection();
        //        _Conn = obyConn.Connect();
        //        SqlCommand cmdsql1 = new SqlCommand();
        //        cmdsql1.Connection = _Conn;
        //        cmdsql1.CommandText = "UPDATE RECEIVED_ITEMS SET DIS_PRICE = '" + DISCOUNTPRICE + "'WHERE (SEQ_NO = '" + SEQNO + "')";
        //        SqlDataReader dreader1 = cmdsql1.ExecuteReader();
        //        _Conn.Dispose();
        //        count++;
        //    }
        //    _Conn.Close();
        //    //MessageBox.Show("Successfully Updated", "Update Info.");
        //    //ShowDetails();
        //}

        //private void UPDISTOTS()
        //{
        //    Connection.DatabaseConnection obyConn;
        //    obyConn = new Connection.DatabaseConnection();
        //    _Conn = obyConn.Connect();
        //    SqlCommand cmdsql = new SqlCommand();
        //    cmdsql.Connection = _Conn;
        //    cmdsql.CommandText = "SELECT PRICE, SEQ_NO FROM RECEIVED_ITEMS WHERE (INV_NO  = '" + txtInvoice.Text + "')";
        //    SqlDataReader dreader = cmdsql.ExecuteReader();
        //    while (dreader.Read())
        //    {
        //        if (dreader.HasRows == true)
        //        {
        //            RTOT = decimal.Parse(dreader["PRICE"].ToString());
        //            SEQ = int.Parse(dreader["SEQ_NO"].ToString());


        //            decimal SUBDISPRICE, DISPRICE, DIS, TOTAMT, PER = 0;

        //            DIS = decimal.Parse(txt_Dis.Text);
        //            TOTAMT = decimal.Parse(InvAmount);
        //            if (DIS == 0)
        //            {
        //                SUBDISPRICE = 0;
        //                PER = 0;
        //            }
        //            else
        //            {
        //                SUBDISPRICE = (TOTAMT / DIS);
        //                PER = 100 / SUBDISPRICE;
        //            }

                    
        //            DISPRICE = RTOT - (RTOT * PER / 100);

        //            obyConn = new Connection.DatabaseConnection();
        //            _Conn = obyConn.Connect();
        //            SqlCommand cmdsql1 = new SqlCommand();
        //            cmdsql1.Connection = _Conn;
        //            cmdsql1.CommandText = "UPDATE RECEIVED_ITEMS SET DIS_PRICE = DIS_PRICE + '" + DISPRICE + "'WHERE (SEQ_NO = '" + SEQ + "')";
        //            cmdsql1.ExecuteNonQuery();
        //        }
        //    }
        //}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            tbAdd.Visible = true;
            txt_Trans.Focus();
            UpdatedRecs();
        }


        private void UpdatedRecs()
        {
            InvNo = txtInvoice.Text;
            InvAmount = lblAll.Text;

            ShowDetails();
            ClearData();


            frm_PaymentMode frmPay = new frm_PaymentMode();
            frmPay.Show();

        }

        private void txtInvoice_Leave(object sender, EventArgs e)
        {
            if (txtInvoice.Text == "")
            {
                MessageBox.Show("Please Enter the Invoice No. to proceed");
                txtInvoice.Focus();
                return;
            }
            ShowDetails();
            TOTAMOUNT();
            btn_Save.Enabled = true;
            btnPrint.Enabled = true;
            btn_Update.Enabled = true;
            btn_Delete.Enabled = true;
            lblInvNo.Text = txtInvoice.Text;
            lblInNo.Text = txtInvoice.Text;
            cmb_SupDesc.Focus();
            cmb_SupDesc.DroppedDown = true;
            //ShowDetails();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            tbAdd.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm_InventoryMaster frmIM = new frm_InventoryMaster();
            frmIM.TopMost = true;
            frmIM.Show();
            this.Hide();
        }

        private void txt_Qty_Leave(object sender, EventArgs e)
        {
            if (txt_Qty.Text == "")
            {
               //MessageBox.Show("Please Enter the Quantity to proceed");
                txt_Qty.Focus();
                return;
            }
        }

        private void UpdateProfit()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PROFIT_PER FROM RECEIVED_TOTALS WHERE (INV_NO  = '" + txtInvoice.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                PER = decimal.Parse(dreader["PROFIT_PER"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();


            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql2 = new SqlCommand();
            cmdsql2.Connection = _Conn;
            cmdsql2.CommandText = "SELECT TOT, SEQ_NO FROM RECEIVED_ITEMS WHERE (INV_NO  = '" + txtInvoice.Text + "')";
            SqlDataReader dreader2 = cmdsql2.ExecuteReader();
            while (dreader2.Read())
            {
                if (dreader2.HasRows == true)
                {
                    RTOT = decimal.Parse(dreader2["TOT"].ToString());
                    SEQ = int.Parse(dreader2["SEQ_NO"].ToString());
                    ITOT = RTOT + (RTOT / 100 * PER);

                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _Conn;
                    cmdsql1.CommandText = "UPDATE RECEIVED_ITEMS SET ISSUE_PRICE = '" + ITOT + "'WHERE (SEQ_NO = '" + SEQ + "')";
                    cmdsql1.ExecuteNonQuery();

                    //SqlCommand cmdsql2 = new SqlCommand();
                    //cmdsql2.Connection = _Conn;
                    //cmdsql2.CommandText = "UPDATE RECEIVED_ITEMS SET BAL_QTY = '" + (BAL_QTY - TOTCALQTY) + "' WHERE SEQ_NO = '" + SEQ_NO + "'";
                    //cmdsql2.ExecuteNonQuery();

                    //            TOTCALQTY = TOTCALQTY - TOTCALQTY;
                    //        }

                    //        if (BAL_QTY <= TOTCALQTY)
                    //        {
                    //            obyConn = new Connection.DatabaseConnection();
                    //            _Conn = obyConn.Connect();
                    //            SqlCommand cmdsql1 = new SqlCommand();
                    //            cmdsql1.Connection = _Conn;

                    //            ENDCAL = CALUNIT * BAL_QTY;

                    //            cmdsql1.CommandText = "INSERT INTO ISSUED_ITEMS (PARTNO, CUSTOMER, INV_NO, QTY, PRICE, DISCOUNT, S_NO, REMARKS, PRO_DATE, TRANS, LOADING, OTHER, TOT, STATUS, RECEIVE_SEQNO) VALUES ('" + cmbPartNO.Text + "','" + lbl_CusCode.Text + "', '" + txtInvoice.Text + "','" + BAL_QTY + "','" + CALUNIT + "','0.00','" + txtSN.Text + "','" + txtRemarks.Text + "',Convert(DateTime,'" + lblDate.Text + "'),'0.00','0.00','0.00','" + ENDCAL + "', '1', '" + SEQ_NO + "')";
                    //            cmdsql1.ExecuteNonQuery();

                    //            SqlCommand cmdsql2 = new SqlCommand();
                    //            cmdsql2.Connection = _Conn;
                    //            cmdsql2.CommandText = "UPDATE RECEIVED_ITEMS SET BAL_QTY = '0', STATUS = '0' WHERE SEQ_NO = '" + SEQ_NO + "'";
                    //            cmdsql2.ExecuteNonQuery();
                    //            TOTCALQTY = TOTCALQTY - BAL_QTY;
                    //        }
                    //    }
                    //}






                    //Connection.DatabaseConnection obyConn;
                    //obyConn = new Connection.DatabaseConnection();
                    //_Conn = obyConn.Connect();
                    //SqlCommand cmdsql1 = new SqlCommand();
                    //cmdsql1.Connection = _Conn;
                    //cmdsql1.CommandText = "SELECT TOT, SEQ_NO FROM RECEIVED_ITEMS WHERE (INV_NO  = '" + txtInvoice.Text + "')";
                    //SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                    //while (dreader1.Read())
                    //{
                    //    RTOT = decimal.Parse(dreader1["TOT"].ToString());
                    //    SEQ = int.Parse(dreader1["SEQ_NO"].ToString());
                    //    ITOT = RTOT + (RTOT / 100 * PER);

                    //    cmdsql1.Dispose();

                    //    SqlCommand cmdsql2 = new SqlCommand();
                    //    cmdsql2.Connection = _Conn;
                    //    cmdsql2.CommandText = "UPDATE RECEIVED_ITEMS SET ISSUE_PRICE = '" + ITOT + "'WHERE (SEQ_NO = '" + SEQ + "')";
                    //    cmdsql2.ExecuteNonQuery();

                }
            }
            cmdsql2.Dispose();
           
        }

        private void lblProfitPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char c = e.KeyChar;
            //int i = (int)c;
            //if (i == 13)
            //{
            //    if (Convert.ToDecimal(lblProfitPer.Text) == 0)
            //    {
            //        //lblProfitPer.Focus();
            //        ////MessageBox.Show("Profit Percentage should be given to proceed");
            //    }
            //    else
            //        button8.Focus();
                
            //}
        }

        private void lblProfitPer_Leave(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(lblProfitPer.Text) == 0)
            //{
            //    //MessageBox.Show("Profit Percentage should be given to proceed");
            //    //lblProfitPer.Focus();
            //}
        }

        private void txtInvoice_Enter(object sender, EventArgs e)
        {
            btn_Update.Enabled = false;
            btn_Delete.Enabled = false;
            btn_Save.Enabled = false;
            btnPrint.Enabled = false;
        }

        private void btn_FindCode_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;

            cmdsql.CommandText = "SELECT MASTER.PARTNO, MASTER.PART, CATEGORY.CATEGORY, MAKE.MAKE, SUBCAT.SUBCAT FROM CATEGORY INNER JOIN MASTER ON CATEGORY.SEQNO = MASTER.CATEGORY INNER JOIN MAKE ON MASTER.MAKE = MAKE.SEQNO INNER JOIN SUBCAT ON MASTER.SUBCAT = SUBCAT.SEQNO WHERE PARTNO = '" + cmbPartNO.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblMsg.Text = "PART ALLREADY EXCISTS AS... - '" + dreader["PART"].ToString() + "'";
                cmbCat.Text = dreader["CATEGORY"].ToString();
                cmbMake.Text = dreader["MAKE"].ToString();
                cmbSub.Text = dreader["SUBCAT"].ToString();
                //cmbPartNO.Focus();
                return;
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void btn_Barcode_Click(object sender, EventArgs e)
        {
            //frm_GenarateBarcode frm_GB = new frm_GenarateBarcode();
            //frm_GB.Show();
            //frm_GB.TopMost = true;
        }

        private void txtPercentage_Leave(object sender, EventArgs e)
        {
            try
            {
                LOAD = decimal.Parse(txt_Load.Text);
                TRANS = decimal.Parse(txt_Trans.Text);
                OTHER = decimal.Parse(txt_Other.Text);
                TOT = (TOT_PURCHASE - DISC) + LOAD + TRANS + OTHER;
                lbl_TotCost.Text = Convert.ToDecimal(TOT).ToString("#####0");
                lblShow.Text = Convert.ToDecimal(TOT).ToString("###,###,##0");

            }
            catch (Exception)
            {

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            LoadUSER();
            timer3.Enabled = false;
        }

        private void FIND_CATS()
        {
            //Connection.DatabaseConnection obyConn;
            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();
            //SqlCommand cmdsql = new SqlCommand();
            //cmdsql.Connection = _Conn;
            //cmdsql.CommandText = "SELECT MASTER.PARTNO FROM MAKE INNER JOIN MASTER WHERE(MASTER.PARTNO = '" + cmbPartNO.Text + "')";
            //SqlDataReader dreader = cmdsql.ExecuteReader();
            //while (dreader.Read())
            //{
            //    cmbCat.SelectedText = dreader["CATEGORY"].ToString().Trim();
            //    cmbMake.SelectedText = dreader["MAKE"].ToString().Trim();
            //}
            //cmdsql.Dispose();
            //dreader.Dispose();
            //_Conn.Close();
        }

        private void txtBarNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                if (txtBarNo.Text == "")
                {
                    MessageBox.Show("Please Enter the Barcode Number to Proceed....");
                    txtBarNo.Focus();
                    return;
                }
                //ClearDataPartNo();
                cmbCat.ResetText();
                cmbSub.ResetText();
                cmbMake.ResetText();

                Load_Data_BARNO();
                Load_BALQTYS_BARCODE();
                LoadByBARCODE();
                btn_Save.Enabled = true;
                btnPrint.Enabled = true;
                btn_Update.Enabled = true;
                btn_Delete.Enabled = true;
                txt_Qty.Focus();
                LoadByBarNo();
                FIND_CATS();
                FillDGV("");
            
            }

            char cc = e.KeyChar;
            int ii = (int)cc;
            if (ii == 27)
            {
                cmbPart.Enabled = true;
                cmbPartNO.Enabled = true;
                cmbPart.Items.Clear();
                cmbPartNO.Items.Clear();
                LoadPart();

                cmbPartNO.Focus();
            }
            
        }

        public void FillDGV(string valueToSearch)
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();

            //SqlCommand command = new SqlCommand("SELECT IMAGE FROM PHOTOS WHERE PARTNO = '" + cmbPartNO.Text + "'", _Conn);

            //SqlDataAdapter adapter = new SqlDataAdapter(command);

            //DataTable table = new DataTable();

            //adapter.Fill(table);

            //dataGridView1.RowTemplate.Height = 200;

            //dataGridView1.AllowUserToAddRows = false;

            //dataGridView1.DataSource = table;

            //dataGridView1.Columns[0].Width = 200;
            //dataGridView1.ColumnHeadersVisible = false;
            ////dataGridView1.Columns[1].Width = 150;
            ////dataGridView1.Columns[1].Visible = false;

            //DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            //imgCol = (DataGridViewImageColumn)dataGridView1.Columns[0];
            //imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }


        private void LoadByBARCODE()
        {
            cmbPart.Text = "";
            cmbDesc.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT MASTER.PART, MASTER.PARTNO, MASTER.DESCRIPTION, RECEIVED_ITEMS.BARNO, MASTER.UOM, MASTER.ROL, MASTER.ROQ, MASTER.LOC, MASTER.CAB, MASTER.RACK, MASTER.BIN, MASTER.SPNO FROM RECEIVED_ITEMS INNER JOIN MASTER ON RECEIVED_ITEMS.PARTNO = MASTER.PARTNO WHERE (RECEIVED_ITEMS.BARNO = '" + txtBarNo.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPart.Text = dreader["PART"].ToString();
                cmbPartNO.Text = dreader["PARTNO"].ToString();
                cmbDesc.Text = dreader["DESCRIPTION"].ToString();
                lbl_UOM.Text = dreader["UOM"].ToString();
                lbl_ROL.Text = dreader["ROL"].ToString();
                lbl_ROQ.Text = dreader["ROQ"].ToString();
                lbl_Locate.Text = dreader["LOC"].ToString();
                lbl_CabNo.Text = dreader["CAB"].ToString();
                lbl_RackNo.Text = dreader["RACK"].ToString();
                lbl_BinNo.Text = dreader["BIN"].ToString();
                lbl_SPNo.Text = dreader["SPNO"].ToString();
                //lbl_MaxQty.Text = dreader["MAXQTY"].ToString();
                //lbl_MinQty.Text = dreader["MINQTY"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void New()
        {
            //LoadINo();
            //txtSN.Focus();
            //TOTAMOUNTS();
            //cmb_CusDesc.Focus();
            //ChecksStatus();
            tbAdd.Visible = false;
        }

        private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            //int ccc = e.KeyValue;
            //int iii = (int)ccc;
            //if (iii == 119)
            //{
            //    New();
            //    ClearData();
            //    txtBarNo.Text = "";
            //    cmb_SupDesc.ResetText();
            //    txtInvoice.Text = "";

            //}

            //int cc = e.KeyValue;
            //int ii = (int)cc;
            //if (ii == 121)
            //{
            //    //timer7.Enabled = true;

            //    Connection.DatabaseConnection obyConn;
            //    obyConn = new Connection.DatabaseConnection();
            //    _Conn = obyConn.Connect();
            //    SqlCommand cmdsql = new SqlCommand();
            //    cmdsql.Connection = _Conn;
            //    cmdsql.CommandText = "SELECT STATUS, INV_NO FROM RECEIVED_ITEMS WHERE INV_NO = '" + txtInvoice.Text + "'";
            //    SqlDataReader dreader = cmdsql.ExecuteReader();
            //    while (dreader.Read())
            //    {
            //        if (dreader.HasRows == true)
            //        {
            //            tbAdd.Visible = true;
            //            txtper.Focus();
            //        }
            //    }
            //}
        }

        private void txtBarNo_KeyDown(object sender, KeyEventArgs e)
        {
            //int ccc = e.KeyValue;
            //int iii = (int)ccc;
            //if (iii == 119)
            //{
            //    New();
            //    ClearData();
            //    txtBarNo.Text = "";
            //    cmb_SupDesc.ResetText();
            //    txtInvoice.Text = "";
            //}

            //int cc = e.KeyValue;
            //int ii = (int)cc;
            //if (ii == 121)
            //{
            //    //timer7.Enabled = true;

            //    Connection.DatabaseConnection obyConn;
            //    obyConn = new Connection.DatabaseConnection();
            //    _Conn = obyConn.Connect();
            //    SqlCommand cmdsql = new SqlCommand();
            //    cmdsql.Connection = _Conn;
            //    cmdsql.CommandText = "SELECT STATUS, INV_NO FROM RECEIVED_ITEMS WHERE INV_NO = '" + txtInvoice.Text + "'";
            //    SqlDataReader dreader = cmdsql.ExecuteReader();
            //    while (dreader.Read())
            //    {
            //        if (dreader.HasRows == true)
            //        {
            //            tbAdd.Visible = true;
            //            txtper.Focus();
            //        }
            //    }
            //}
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Dis_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                textBox9.Focus();
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtSN.Focus();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            txtBarNo.Focus();
            timer4.Enabled = false;
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void txtBarNo_TextChanged(object sender, EventArgs e)
        {
            FillDGV("");
        }
    }
}