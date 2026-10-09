using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace Billing_Inventory_Management_System
{
    public partial class frm_ReturnSuppliers : Form
    {
        private SqlConnection _Conn;
        decimal PER, RTOT, SEQ, ITOT, ETOT = 0;

        public frm_ReturnSuppliers()
        {
            InitializeComponent();
        }

        private void Find_Suppliers()
        {
            cmbSup.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT NAME FROM  SUPPLIER_INFO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbSup.Items.Add(dreader["NAME"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void Find_PartNOs()
        {
            cmbPartNo.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PARTNO FROM  RECEIVED_ITEMS WHERE STATUS = '1' AND INV_NO = '"+ cmbINVNO.Text +"'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbPartNo.Items.Add(dreader["PARTNO"].ToString());

            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
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
            cmdsql.CommandText = "SELECT MASTER.PART AS PART, MASTER.PARTNO AS PARTNO FROM RECEIVED_ITEMS INNER JOIN MASTER ON RECEIVED_ITEMS.PARTNO = MASTER.PARTNO WHERE (RECEIVED_ITEMS.STATUS = '1') AND (RECEIVED_ITEMS.INV_NO = '" + cmbINVNO.Text + "')";
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

        private void Find_Data()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT RECEIVED_ITEMS.DIS_PRICE, RECEIVED_ITEMS.BAL_QTY, RECEIVED_ITEMS.SUPPLIER, RECEIVED_ITEMS.SEQ_NO, SUPPLIER_INFO.NAME, RECEIVED_ITEMS.QTY, RECEIVED_ITEMS.TOT FROM RECEIVED_ITEMS INNER JOIN SUPPLIER_INFO ON RECEIVED_ITEMS.SUPPLIER = SUPPLIER_INFO.SEQ_NO WHERE INV_NO = '" + cmbINVNO.Text + "' AND PARTNO = '" + cmbPartNo.Text + "' ";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblSEQNO.Text = dreader["SEQ_NO"].ToString();
                //lblCat.Text = dreader["CATEGORY"].ToString();
                //lblMake.Text = dreader["MAKE"].ToString();
                
                lblName.Text = dreader["NAME"].ToString();
                lblQty.Text = dreader["QTY"].ToString();
                lblBal.Text = dreader["BAL_QTY"].ToString();
                lblSup.Text = dreader["SUPPLIER"].ToString();
                lbl_TotCost.Text = dreader["TOT"].ToString();
                decimal QTY = decimal.Parse(dreader["QTY"].ToString());
                decimal TOT = decimal.Parse(dreader["TOT"].ToString());
                decimal TOTVALD = TOT / QTY;
                lblUnitPriceD.Text = Convert.ToDecimal(TOTVALD).ToString();

                decimal TOTVALA = decimal.Parse(dreader["DIS_PRICE"].ToString());
                lblUnitPriceA.Text = Convert.ToDecimal(TOTVALA).ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void SUPCODE()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQ_NO FROM SUPPLIER_INFO WHERE NAME = '" + cmbSup.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblSup.Text = dreader["SEQ_NO"].ToString();
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
            cmdsql.CommandText = "SELECT DISTINCT RECEIVED_ITEMS.INV_NO, SUPPLIER_INFO.SEQ_NO FROM RECEIVED_ITEMS INNER JOIN SUPPLIER_INFO ON RECEIVED_ITEMS.SUPPLIER = SUPPLIER_INFO.SEQ_NO WHERE(SUPPLIER_INFO.SEQ_NO = '" + lblSup.Text + "') AND (RECEIVED_ITEMS.STATUS = 1)ORDER BY RECEIVED_ITEMS.INV_NO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbINVNO.Items.Add(dreader["INV_NO"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void frm_ReturnSuppliers_Load(object sender, EventArgs e)
        {
            Find_Suppliers();
            //Load_Data();
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


        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateProfit()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PROFIT_PER FROM RECEIVED_TOTALS WHERE (INV_NO  = '" + cmbINVNO.Text + "')";
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
            cmdsql2.CommandText = "SELECT TOT, SEQ_NO FROM RECEIVED_ITEMS WHERE (INV_NO  = '" + cmbINVNO.Text + "')";
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
                }
            }
            cmdsql2.Dispose();

        }

        private void btn_Save1_Click(object sender, EventArgs e)
        {
           

            decimal QTY;
            decimal BAL_QTY;
            decimal TOTALRETURN;
            decimal UNITPRICERETURN;
            QTY = int.Parse(txt_Qty.Text);
            BAL_QTY = int.Parse(lblBal.Text);
            UNITPRICERETURN = decimal.Parse(lblUnitPriceA.Text);
            TOTALRETURN = QTY * UNITPRICERETURN;

            //if (BAL_QTY == "0")
            //{
            //    MessageBox.Show("Please Enter Less Issue Amount to Proceed", "Issue Goods Info");
            //    return;
            //}
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
            cmdsql1.CommandText = "INSERT INTO RETURN_SUPPLIER (PARTNO, SUPPLIER, INV_NO, QTY, PRICE, S_NO, REMARKS, PRO_DATE, TOTAL, STATUS) VALUES ('" + cmbPartNo.Text + "','" + lblSup.Text + "','" + cmbINVNO.Text + "', '" + txt_Qty.Text + "', '" + lblUnitPriceA.Text + "','" + txtSN.Text + "','" + txtRemarks.Text + "',Convert(DateTime,'" + lbl_ProDate.Text + "'),'" + TOTALRETURN + "', '1')";
            cmdsql1.ExecuteNonQuery();


            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "UPDATE RECEIVED_ITEMS SET QTY = (QTY - '" + txt_Qty.Text + "'), BAL_QTY = (BAL_QTY - '" + txt_Qty.Text + "'), TOT = (TOT - '" + TOTALRETURN + "'), STATUS = 1 WHERE (SEQ_NO = '" + lblSEQNO.Text + "')";
            cmdsql.ExecuteNonQuery();

            if (QTY == BAL_QTY)
            {
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _Conn;
                cmdsql2.CommandText = "UPDATE RECEIVED_ITEMS SET STATUS = '0' WHERE SEQ_NO = '" + lblSEQNO.Text + "'";
                cmdsql2.ExecuteNonQuery();
            }
            MessageBox.Show("Items Returned to Supplier are Successfully Added");
            UpdateProfit();
            ClearData();
            cmbSup.ResetText();
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

        private void ClearData()
        {
            lblSEQNO.Text = "";
            lblSup.Text = "";
            lblQty.Text = "";
            lblUnitPriceA.Text = "";
            lblUnitPriceD.Text = "";
            lbl_TotCost.Text = "";
            lblBal.Text = "0";
            lblReTOTPrice.Text = "0.00";
            txtRemarks.Text = "";
            txtSN.Text = "";
            txt_Qty.Text = "";
        }


        private void cmbPartNo_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDesc();
            Find_Data();
            btn_Save1.Enabled = true;
            txt_Qty.Enabled = true;
            txtSN.Enabled = true;
            txtRemarks.Enabled = true;
            //cmbDesc.Focus();
            //cmbDesc.DroppedDown = true;
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
            cmdsql.CommandText = "SELECT PARTNO, PART FROM MASTER WHERE (PART = '" + cmbDesc.Text + "')";
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

        private void txt_Qty_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal RQTY = decimal.Parse(txt_Qty.Text);
                decimal RUNIT = decimal.Parse(lblUnitPriceA.Text);
                decimal RTOTVAL = RUNIT * RQTY;
                lblReTOTPrice.Text = Convert.ToDecimal(RTOTVAL).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void cmbINVNO_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearData();
            cmbPartNo.ResetText();
            cmbDesc.ResetText();
            //Find_PartNOs();
            Find_Desc();
            //cmbPartNo.Focus();
            //cmbPartNo.DroppedDown = true;
        }

        private void cmbSup_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearData();
            cmbPartNo.ResetText();
            cmbDesc.ResetText();
            SUPCODE();
            Load_Data();
            //cmbINVNO.Focus();
            //cmbINVNO.DroppedDown = true;
        }

        private void cmbDesc_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadPartNo();
            btn_Save1.Enabled = true;
            //txt_Qty.Focus();
        }

        private void lblReTOTPrice_TextChanged(object sender, EventArgs e)
        {
            decimal TCOST = 0;
            decimal PCOST = 0;

            if(lblReTOTPrice.Text == "")
            lblReTOTPrice.Text = "0.00";
            if (lbl_TotCost.Text == "")
            lbl_TotCost.Text = "0.00";

            TCOST = decimal.Parse(lblReTOTPrice.Text);
            PCOST = decimal.Parse(lbl_TotCost.Text);

            if (TCOST > PCOST)
                lblReTOTPrice.Text = lbl_TotCost.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cmbSup.Focus();
            cmbSup.DroppedDown = true;
            timer1.Enabled = false;
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

        private void SS(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbSup_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbINVNO.Focus();
                cmbINVNO.DroppedDown = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_ProDate_Click(object sender, EventArgs e)
        {

        }
    }
}