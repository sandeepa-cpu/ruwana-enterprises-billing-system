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

namespace Billing_Inventory_Management_System
{
    public partial class frm_PaymentMode : Form
    {
        public frm_PaymentMode()
        {
            InitializeComponent();
        }

        Decimal AMOUNT;
        decimal TOT = 0;
        decimal CASH = 0;
        decimal CREDIT = 0;
        decimal BAL = 0;
        decimal TOTAMOUNT, DISC, LOAD, TRANS, OTH, TOTAL, AA, BB = 0;
        private SqlConnection _Conn;
        ReportDocument crdReportDocument = new ReportDocument();

        //public void GetReportCriteria(string strReportName, string strCriteria, DateTime strDate, DateTime strEndDate, int strINV)
        //{
        //    crystalReportViewer1.Refresh();

        //    crdReportDocument.Load(Application.StartupPath + "\\" + strReportName + ".rpt");
        //    crdReportDocument.Refresh();

        //    CommonProfiles objComPro = new CommonProfiles();
        //    frm_ReportCriteria objRepCriteria = new frm_ReportCriteria();

        //    ApplyInfo(crdReportDocument);

        //    bool ParExist = true;

        //    switch (strReportName)
        //    {
        //        case "rpt_Print":
        //            crdReportDocument.SetParameterValue("INVOICE", strINV);
        //            ParExist = false;
        //            break;
        //    }

        //    if (ParExist == true)
        //    {
        //        //crdReportDocument.SetParameterValue("Month", strDate);
        //    }

        //    if (crdReportDocument.Rows.Count > 0)
        //    {
        //        crystalReportViewer1.Refresh();
        //        crystalReportViewer1.ReportSource = crdReportDocument;

        //    }
        //    else
        //    {
        //        MessageBox.Show("No data for Selected Criteria");
        //    }
        //    // Used to Add back educted previous month EPF amount from Data Base
        //    //      if (strReportName == "EPF_Monthly_Report")// Added on 13-Apr-2011 - to Pause print ETF and brought forward to next month
        //    //      {
        //    //          objRepCriteria.HandleETFReport("Ded", intYear, objComPro.GetMonthConverted(strMonth));
        //    //      }
        //}

        //public void ApplyInfo(CrystalDecisions.CrystalReports.Engine.ReportDocument _oRpt)
        //{
        //    Connection.DatabaseConnection obyConn;

        //    obyConn = new Connection.DatabaseConnection();
        //    _conn = obyConn.Connect();

        //    CrystalDecisions.CrystalReports.Engine.Database oCRDb = _oRpt.Database;

        //    CrystalDecisions.CrystalReports.Engine.Tables oCRTables = oCRDb.Tables;

        //    //CrystalDecisions.CrystalReports.Engine.Table oCRTable;

        //    CrystalDecisions.Shared.TableLogOnInfo oCRTableLogonInfo;

        //    CrystalDecisions.Shared.ConnectionInfo oCRConnectionInfo = new CrystalDecisions.Shared.ConnectionInfo();

        //    string sqlsconnection = _conn.ConnectionString;

        //    Match m = Regex.Match(sqlsconnection, @"server=(?<server>((\d+.\d+.\d+.\d+)|(\w+)|(.)));(\w|\W)*uid=(?<uid>(\w+));(\w|\W)");

        //    string sServer = m.Groups["server"].ToString();
        //    string sPassword = m.Groups["pwd"].ToString();
        //    string sUid = m.Groups["uid"].ToString();

        //    oCRConnectionInfo.DatabaseName = "NMICS";

        //    oCRConnectionInfo.ServerName = sServer;

        //    oCRConnectionInfo.UserID = "NMICS_ADMIN";

        //    oCRConnectionInfo.Password = builder.Password;

        //    foreach (CrystalDecisions.CrystalReports.Engine.Table oCRTabl in oCRTables)
        //    {

        //        oCRTableLogonInfo = oCRTabl.LogOnInfo;

        //        oCRTableLogonInfo.ConnectionInfo = oCRConnectionInfo;

        //        oCRTabl.ApplyLogOnInfo(oCRTableLogonInfo);

        //    }
        //    _conn.Close();
        //}

        //internal static void GetReportCriteria(string strReportName, string strCriteria, int p)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        private void btnCredit_Click(object sender, EventArgs e)
        {
            decimal CheckA, CheckB = 0;
            CheckA = decimal.Parse(txtCash.Text);
            CheckB = decimal.Parse(txtCredit.Text);

            if (CheckA == '0')
            {
                MessageBox.Show("Please Enter the Cash or Credit Value");
                txtCash.Focus();
                return;
            }

            if (CheckB == '0')
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
            cmdsql.CommandText = "UPDATE RECEIVED_TOTALS SET CASH = '" + txtCash.Text + "', CREDIT = '" + txtCredit.Text + "' WHERE INV_NO = '"+ lblInv.Text +"'";
            cmdsql.ExecuteNonQuery();
            MessageBox.Show("Method of Payment has added Successfully");
            this.Close();
        }

        private void frm_PaymentMode_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            
            lblInv.Text = frm_ReceiveGoods.InvNo.ToString();
            AA = decimal.Parse(frm_ReceiveGoods.InvAmount.ToString());
            INV();
            //lblAmountA.Text = decimal.Parse(AA) - decimal.Parse(TOTAL);
            rbcash.Checked = true;
            txtCash.Focus();
            //SEQ();
            
        }
        private void SEQ()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT MAX(SEQ_NO) AS SEQ_NO FROM RECEIVED_ITEMS";
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
            cmdsql.CommandText = "SELECT INV_NO, DISCOUNT, TRANS, LOADING, OTHER FROM  RECEIVED_TOTALS WHERE INV_NO = '" + lblInv.Text + "'";
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
                txtCash.Text =  decimal.Parse(txtCash.Text).ToString("#####0.00");
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

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}