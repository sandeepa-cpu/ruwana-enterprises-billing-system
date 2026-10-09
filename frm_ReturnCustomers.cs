using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Billing_Inventory_Management_System
{
    public partial class frm_ReturnCustomers : Form
    {
        private SqlConnection _Conn;

        public frm_ReturnCustomers()
        {
            InitializeComponent();
        }

        private void Find_PartNOs()
        {
            cmbPartNo.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO FROM  ISSUED_ITEMS WHERE STATUS = '1' AND INV_NO = '" + cmbINVNO.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPartNo.Items.Add(dreader["PARTNO"].ToString());

            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Find_Data()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT ISSUED_ITEMS.RECEIVE_SEQNO, ISSUED_ITEMS.PRICE, ISSUED_ITEMS.CUSTOMER, ISSUED_ITEMS.SEQ_NO, ISSUED_ITEMS.QTY, ISSUED_ITEMS.TOT FROM ISSUED_ITEMS INNER JOIN CUSTOMER_INFO ON ISSUED_ITEMS.CUSTOMER = CUSTOMER_INFO.SEQ_NO WHERE INV_NO = '" + cmbINVNO.Text + "' AND PARTNO = '" + cmbPartNo.Text + "' ";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblSEQNO.Text = dreader["SEQ_NO"].ToString();
                lblQty.Text = dreader["QTY"].ToString();
                lblBal.Text = dreader["QTY"].ToString();
                lblCus.Text = dreader["CUSTOMER"].ToString();
                lbl_TotCost.Text = dreader["TOT"].ToString();
                decimal QTY = decimal.Parse(dreader["QTY"].ToString());
                decimal TOT = decimal.Parse(dreader["TOT"].ToString());
                decimal TOTVALA = decimal.Parse(dreader["PRICE"].ToString());
                lblUnitPriceA.Text = Convert.ToDecimal(TOTVALA).ToString();
                lblRSEQNO.Text = dreader["RECEIVE_SEQNO"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        
        }

        private void Load_Data()
        {
            cmbINVNO.Items.Clear();
            cmbINVNO.ResetText();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT DISTINCT ISSUED_ITEMS.INV_NO, CUSTOMER_INFO.SEQ_NO FROM ISSUED_ITEMS INNER JOIN CUSTOMER_INFO ON ISSUED_ITEMS.CUSTOMER = CUSTOMER_INFO.SEQ_NO WHERE(CUSTOMER_INFO.SEQ_NO = '" + lblCus.Text + "') AND (ISSUED_ITEMS.STATUS = 1)ORDER BY ISSUED_ITEMS.INV_NO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbINVNO.Items.Add(dreader["INV_NO"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void CUSCODE()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQ_NO FROM CUSTOMER_INFO WHERE NAME = '" + cmbCus.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblCus.Text = dreader["SEQ_NO"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void ShowDetails()
        {
            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 120;
            Grid_A.Columns[0].HeaderText = "MAKE";
            Grid_A.Columns[1].Width = 120;
            Grid_A.Columns[1].HeaderText = "MODEL";
            Grid_A.Columns[2].Width = 140;
            Grid_A.Columns[2].HeaderText = "CUSTOMER";
            Grid_A.Columns[3].Width = 100;
            Grid_A.Columns[3].HeaderText = "INVOICE NO.";
            Grid_A.Columns[4].Width = 90;
            Grid_A.Columns[4].HeaderText = "QUANTITY";
            Grid_A.Columns[5].Width = 90;
            Grid_A.Columns[5].HeaderText = "PRICE";
            Grid_A.Columns[6].Width = 60;
            Grid_A.Columns[6].HeaderText = "";
            Grid_A.Columns[7].Width = 120;
            Grid_A.Columns[7].HeaderText = "TOTAL COST";
            Grid_A.Columns[8].Width = 120;
            Grid_A.Columns[8].HeaderText = "SERIAL NO.";

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
            Grid_A.Columns[6].ReadOnly = true;
            Grid_A.Columns[7].ReadOnly = true;
            //Grid_A.Columns[8].ReadOnly = true;

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

        private void cmbInvNo_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearData();
            cmbPartNo.ResetText();
            cmbDesc.ResetText();
            //Find_PartNOs();
            Find_Desc();
        }

        private void ClearData()
        {
            lblSEQNO.Text = "";
            lblCus.Text = "";
            lblQty.Text = "";
            lblUnitPriceA.Text = "";
            lbl_TotCost.Text = "";
            lblBal.Text = "0";
            lblReTOTPrice.Text = "0.00";
            txtRemarks.Text = "";
            txtSN.Text = "";
            txt_Qty.Text = "";
        }

        private void Find_Desc()
        {
            cmbPartNo.Items.Clear();
            cmbDesc.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT MASTER.PART AS PART, MASTER.PARTNO AS PARTNO FROM ISSUED_ITEMS INNER JOIN MASTER ON ISSUED_ITEMS.PARTNO = MASTER.PARTNO WHERE (ISSUED_ITEMS.STATUS = '1') AND (ISSUED_ITEMS.INV_NO = '" + cmbINVNO.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPartNo.Items.Add(dreader["PARTNO"].ToString());
                cmbDesc.Items.Add(dreader["PART"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void LoadInvNo()
        {
            cmbINVNO.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT DISTINCT INV_NO FROM ISSUED_ITEMS";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbINVNO.Items.Add(dreader["INV_NO"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Find_Customer()
        {
            cmbCus.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT NAME FROM  CUSTOMER_INFO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbCus.Items.Add(dreader["NAME"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void frm_ReturnCustomers_Load(object sender, EventArgs e)
        {
            Find_Customer();
            Load_Data();
            PRO_DATE();
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
                lbl_ProDate.Text = dreader["PRO_DATE"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
            //lbl_DATE.Text = DateTime.Today.Date.ToLongDateString();
            //lbl_DATE.Text = String.Format("{0:yyyy - MMMM - dd}", DateTime.Today.Date);
            //this.dt_Birth.CustomFormat = "yyyy-MM-dd";
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save1_Click(object sender, EventArgs e)
        {
            //try
            //{

            decimal QTY;
            decimal BAL_QTY;
            decimal UNITPRICERETURN;
            decimal TOTALRETURN;
            QTY = int.Parse(txt_Qty.Text);
            BAL_QTY = int.Parse(lblBal.Text);
            UNITPRICERETURN = decimal.Parse(lblUnitPriceA.Text);
            TOTALRETURN = QTY * UNITPRICERETURN;

            if (QTY > BAL_QTY)
            {
                MessageBox.Show("Please Enter Less Issue Amount to Proceed", "Issue Goods Info");
                return;
            }
            if (txt_Qty.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Return Info....");
                return;
            }

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;
            cmdsql1.CommandText = "INSERT INTO RETURN_CUSTOMER (PARTNO, CUSTOMER, INV_NO, QTY, PRICE, S_NO, REMARKS, PRO_DATE, TOTAL, STATUS) VALUES ('" + cmbPartNo.Text + "','" + lblCus.Text + "','" + cmbINVNO.Text + "', '" + txt_Qty.Text + "', '" + lblUnitPriceA.Text + "','" + txtSN.Text + "','" + txtRemarks.Text + "',Convert(DateTime,'" + lbl_ProDate.Text + "'),'" + TOTALRETURN + "', '1')";
            cmdsql1.ExecuteNonQuery();

            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "UPDATE ISSUED_ITEMS SET QTY = (QTY - '" + txt_Qty.Text + "'), TOT = (TOT - '" + TOTALRETURN + "'), STATUS = 1 WHERE (SEQ_NO = '" + lblSEQNO.Text + "')";
            cmdsql.ExecuteNonQuery();

            SqlCommand cmdsql3 = new SqlCommand();
            cmdsql3.Connection = _Conn;
            cmdsql3.CommandText = "UPDATE RECEIVED_ITEMS SET BAL_QTY = BAL_QTY + '" + txt_Qty.Text + "', STATUS = 1 WHERE (SEQ_NO = '" + lblRSEQNO.Text + "')";
            cmdsql3.ExecuteNonQuery();

            if (QTY == BAL_QTY)
            {
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _Conn;
                cmdsql2.CommandText = "UPDATE ISSUED_ITEMS SET STATUS = '0' WHERE SEQ_NO = '" + lblSEQNO.Text + "'";
                cmdsql2.ExecuteNonQuery();
            }
            MessageBox.Show("Items Returned by Customer are Successfully Added");
            ClearData();
            cmbCus.ResetText();
            cmbINVNO.ResetText();
            cmbPartNo.ResetText();
            cmbDesc.ResetText();
            cmbPartNo.Items.Clear();
            cmbDesc.Items.Clear();
            txt_Qty.Enabled = false;
            txtSN.Enabled = false;
            txtRemarks.Enabled = false;
            //catch (Exception)
            //{
            //    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Received Goods Info");
            //    return;
            //}
            _Conn.Close();
            btn_Save1.Enabled = false;
        }

        private void LoadDesc()
        {
            //cmbDesc.Items.Clear();
            cmbDesc.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO, PART FROM MASTER WHERE (PARTNO = '" + cmbPartNo.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                //cmbPartNO.Items.Add(dreader["PARTNO"].ToString());
                cmbDesc.Text = dreader["PART"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void cmbPartNo_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDesc();
            Find_Data();
            btn_Save1.Enabled = true;
            txt_Qty.Enabled = true;
            txtSN.Enabled = true;
            txtRemarks.Enabled = true;
        }

        private void txt_Qty_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal QTY = decimal.Parse(txt_Qty.Text);
                decimal BALQTY = decimal.Parse(lblBal.Text);
                if (BALQTY == QTY)
                {
                    lblReTOTPrice.Text = Convert.ToDecimal(lbl_TotCost.Text).ToString();
                    return;
                }
                else
                {
                    decimal RQTY = decimal.Parse(txt_Qty.Text);
                    decimal RUNIT = decimal.Parse(lblUnitPriceA.Text);
                    decimal RTOTVAL = RUNIT * RQTY;
                    lblReTOTPrice.Text = Convert.ToDecimal(RTOTVAL).ToString();
                }
            }
            catch (Exception)
            {
            
            }
        }

        private void lblName_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearData();
            cmbPartNo.ResetText();
            cmbDesc.ResetText();
            CUSCODE();
            Load_Data();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblReTOTPrice_TextChanged(object sender, EventArgs e)
        {
            decimal TCOST = 0;
            decimal PCOST = 0;

            if (lblReTOTPrice.Text == "")
                lblReTOTPrice.Text = "0.00";
            if (lbl_TotCost.Text == "")
                lbl_TotCost.Text = "0.00";

            TCOST = decimal.Parse(lblReTOTPrice.Text);
            PCOST = decimal.Parse(lbl_TotCost.Text);

            if (TCOST > PCOST)
                lblReTOTPrice.Text = lbl_TotCost.Text;
        }

        private void cmbDesc_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadPartNo();
            btn_Save1.Enabled = true;
        }

        private void LoadPartNo()
        {
            //cmbPartNO.Items.Clear();
            cmbPartNo.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO, PART  FROM MASTER WHERE (PART  = '" + cmbDesc.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPartNo.Text = dreader["PARTNO"].ToString();
                //cmbDesc.Text = dreader["DESCRIPTION"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void cmbCus_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbINVNO.Focus();
                cmbINVNO.DroppedDown = true;
            }
        }

        private void cmbINVNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbPartNo.Focus();
                cmbPartNo.DroppedDown = true;
            }
        }

        private void cmbPartNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbDesc.Focus();
                cmbDesc.DroppedDown = true;
            }
        }

        private void cmbDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Qty.Focus();
                //txt_Qty.DroppedDown = true;
            }
        }

        private void txt_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtSN.Focus();
                //txt_Qty.DroppedDown = true;
            }
        }

        private void txtSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtRemarks.Focus();
                //txt_Qty.DroppedDown = true;
            }
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btn_Save1.Focus();
                //txt_Qty.DroppedDown = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cmbCus.Focus();
            cmbCus.DroppedDown = true;
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}