using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Drawing.Printing;

namespace Billing_Inventory_Management_System
{
    public partial class frm_ReceiveMode : Form
    {
        public frm_ReceiveMode()
        {
            InitializeComponent();
        }
        Decimal AMOUNT;
        decimal TOTAMOUNT, DISC, LOAD, TRANS, OTH, TOTAL, AA, BB = 0;
        decimal TOT = 0;
        decimal CASH = 0;
        decimal CREDIT = 0;
        decimal BAL = 0;
        int strINVNO = 0;
        private string strCriteria = "";
        private string strReportName = "";
        private SqlConnection _Conn;
        ReportDocument crdReportDocument = new ReportDocument();
        public static int LocID;

        private void btnCredit_Click(object sender, EventArgs e)
        {
            decimal CheckA, CheckB = 0;
            CheckA = decimal.Parse(txtCash.Text);
            CheckB = decimal.Parse(txtCredit.Text);

            if (decimal.Parse(txtCash.Text).ToString() == "0.00" & decimal.Parse(txtCredit.Text).ToString() == "0.00")
            {
                MessageBox.Show("Please Enter the Cash or Credit Value");
                txtCash.Focus();
                return;
            }

            if (TOTAL < CheckA)
            {
                MessageBox.Show("Entered Cash Value is higher than the Issuing Value");
                txtCash.Focus();
                return;
            }
            if (TOTAL < CheckB)
            {
                MessageBox.Show("Entered Credit Value is higher than the Issuing Value");
                txtCredit.Focus();
                return;
            }
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "UPDATE ISSUED_TOTALS SET CASH = '" + txtCash.Text + "', CREDIT = '" + txtCredit.Text + "' WHERE INV_NO = '" + lblInv.Text + "'";
            cmdsql.ExecuteNonQuery();

            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;
            cmdsql1.CommandText = "UPDATE ISSUED_ITEMS SET STATUS = '1' WHERE INV_NO = '" + lblInv.Text + "'";
            cmdsql1.ExecuteNonQuery();

            MessageBox.Show("Method of Issue has added Successfully");

            strReportName = "rpt_Print";
            strCriteria = "Reports";

            this.Text = "Report Criteria for " + strCriteria;

            strReportName = "rpt_Print";


            frm_Reports frm_Reports = new frm_Reports();
            CommonProfiles objComPro = new CommonProfiles();

            frm_Reports.GetReportCriteriaA(strReportName, strCriteria, DateTime.Parse(lbl_SysDate.Text), DateTime.Parse(lbl_SysLast.Text), lblInv.Text, lblSEQ.Text);
            frm_Reports.Show();
            LocID = int.Parse(lblLocID.Text);
            this.Close();

            //frm_Reports.Refresh();
            //frm_Reports.PrintToPrinter(2, true, 1, 2);
        }

        private void frm_ReceiveMode_Load(object sender, EventArgs e)
        {
            

            //INV();
            lblInv.Text = frm_IssueGoods.InvNo.ToString();
            lblLocID.Text = frm_IssueGoods.LocID.ToString();
            lbl_SysDate.Text = frm_IssueGoods.SysDate.ToString();
            AA = decimal.Parse(frm_IssueGoods.InvAmount.ToString());
            INV();
            rbcash.Checked = true;
            txtCash.Focus();
        }

        private void SEQ()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT MAX(SEQ_NO) AS SEQ_NO FROM ISSUED_ITEMS";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblSEQ.Text = dreader["SEQ_NO"].ToString().Trim();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void INV()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT INV_NO, DISCOUNT, TRANS, LOADING, OTHER FROM  ISSUED_TOTALS WHERE INV_NO = '" + lblInv.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblInv.Text = dreader["INV_NO"].ToString().Trim();
                //TOTAMOUNT = decimal.Parse(dreader["TOT"].ToString().Trim());
                DISC = decimal.Parse(dreader["DISCOUNT"].ToString().Trim());
                TRANS = decimal.Parse(dreader["TRANS"].ToString().Trim());
                LOAD = decimal.Parse(dreader["LOADING"].ToString().Trim());
                OTH = decimal.Parse(dreader["OTHER"].ToString().Trim());
                BB = TRANS + LOAD + OTH;
                TOTAL = (AA + BB) - DISC;
                lblAmount.Text = TOTAL.ToString("#####0.00");
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtCash.Focus();
            lblInv.Text = frm_IssueGoods.InvNo.ToString();
            INV();
            
            if (AA != 0)
            {
                AA = decimal.Parse(frm_IssueGoods.InvAmount.ToString());
            }
            rbcash.Checked = true;
            txtCash.Focus();
            INV();
            timer1.Enabled = false;
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                if (decimal.Parse(lblAmount.Text) < decimal.Parse(txtCash.Text))
                {
                    MessageBox.Show("Amount Entered is much higher than the Invoiced Amount", "Received Goods Info");
                    btnCredit.Enabled = false;
                    return;
                }
                else
                    btnCredit.Enabled = true;

                if (txtCash.Text == "")
                    txtCash.Text = "0.00";
                TOT = decimal.Parse(lblAmount.Text);
                CASH = decimal.Parse(txtCash.Text);
                CREDIT = decimal.Parse(txtCredit.Text);
                CREDIT = TOT - CASH;
                BAL = TOT - CASH;
                txtCash.Text = decimal.Parse(txtCash.Text).ToString("#####0.00");
                txtCredit.Text = CREDIT.ToString("#####0.00");
                lblBal.Text = CREDIT.ToString("#####0.00");
                btnCredit.Focus();
            }
        }

        private void txtCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                if (decimal.Parse(lblAmount.Text) < decimal.Parse(txtCredit.Text))
                {
                    MessageBox.Show("Amount Entered is much higher than the Invoiced Amount", "Received Goods Info");
                    btnCredit.Enabled = false;
                    return;
                }
                else
                    btnCredit.Enabled = true;

                if (txtCredit.Text == "")
                    txtCredit.Text = "0.00";
                TOT = decimal.Parse(lblAmount.Text);
                CASH = decimal.Parse(txtCash.Text);
                CREDIT = decimal.Parse(txtCredit.Text);
                CASH = TOT - CREDIT;
                BAL = TOT - CREDIT;
                txtCredit.Text = decimal.Parse(txtCredit.Text).ToString("#####0.00");
                txtCash.Text = CASH.ToString("#####0.00");
                lblBal.Text = CASH.ToString("#####0.00");
                btnCredit.Focus();
            }
        }

        private void rbcash_CheckedChanged(object sender, EventArgs e)
        {
            txtCash.Enabled = true;
            txtCredit.Enabled = false;
            txtCash.Focus();
            txtCredit.Text = "0.00";
        }

        private void rbCredit_CheckedChanged(object sender, EventArgs e)
        {
            txtCash.Enabled = false;
            txtCredit.Enabled = true;
            txtCredit.Focus();
            txtCash.Text = "0.00";
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCash_Leave(object sender, EventArgs e)
        {
            //if (txtCash.Text = "")
            //    txtCash.Text = "0.00";
        }

        private void txtCredit_Leave(object sender, EventArgs e)
        {
            //if (txtCredit.Text = "")
            //    txtCredit.Text = "0.00";
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}