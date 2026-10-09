using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Reflection;

namespace Billing_Inventory_Management_System
{
    public partial class frm_ReportCriteria : Form
    {
        private SqlConnection _conn;
        private SqlConnection _conn1;
        private string strReportName = "";
        private string strTitle = "NIMSARA MOTORS";
        private string strCriteria = "";
        string strEPFETF = "";

        decimal TOTCASH = 0;
        decimal TOTCRESDIT = 0;

        int FINDINV_NO;
        private string strINVNO;
        string strSQL = null;
        DateTime YEAR, MONTH, STS, SEQNO, RPT_SEQNO;
        bool bolNewEmp = true;
        DataRow dr = null;
        SqlCommand cmdsql1;

        decimal IQTY, QTY, PRICE, DIS_PRICE, TOT, RECEIVE_PRICE, TOTAL, ISSUE_PRICE, CREDIT_AMNT, CASH_AMNT = 0;
        int RSEQ_NO = 0;
        string I_PARTNO, PARTNO, INV_NO, I_INV_NO, PREDESC;
        DateTime DTPRO;

        public frm_ReportCriteria()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            frm_Reports frm_Reports = new frm_Reports();
            CommonProfiles objComPro = new CommonProfiles();
            if (lblPwdOK.Text == "1")
            {
                if (txtPwd.Text == lblPwd.Text)
                {
                    if (strReportName == "rpt_Profit")
                    {

                        PRINTINV_II();
                        PRINTINV_RR();
                        PRINTINV_RVALS();

                        frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lbl_SysDate.Text), DateTime.Parse(lbl_SysLast.Text), lblINVNO.Text, lblCUSSUP.Text);
                        frm_Reports.Show();
                    }
                    if (strReportName == "rpt_GRNCreditDateRange")
                    {
                        FINDGRNCASHCREDIT();

                        frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lbl_SysDate.Text), DateTime.Parse(lbl_SysLast.Text), lblINVNO.Text, lblCUSSUP.Text);
                        frm_Reports.Show();
                    }
                    if (strReportName == "rpt_MIRCreditDateRange")
                    {
                        FINDMIRCASHCREDIT();

                        frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lbl_SysDate.Text), DateTime.Parse(lbl_SysLast.Text), lblINVNO.Text, lblCUSSUP.Text);
                        frm_Reports.Show();
                    }
                 
                    if (strReportName == "rpt_DayProfit")
                    {
                        lblwait.Visible = true;

                        DAYISSUES();
                        DAYISSUES_CASH_CREDIT();
                        UP_BEFORE_CASH();
                        PRINTINV_III();
                        UP_DAY_PROFIT();
                        UP_DAY_PROFIT_DIFF();
                        DAY_EXP();
                        EMP_EXP();

                        frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lbl_SysDate.Text), DateTime.Parse(lbl_SysLast.Text), lblINVNO.Text, lblCUSSUP.Text);
                        frm_Reports.Show();

                    }
                    else
                    {
                        lblwait.Visible = false;
                        MessageBox.Show("Please Enter the Correct Password", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (lblPwdOK.Text == "0")
            {
                //if (lblINVNO.Text == "")
                //    lblINVNO.Text = "0";
                frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lbl_SysDate.Text), DateTime.Parse(lbl_SysLast.Text), lblINVNO.Text, lblCUSSUP.Text);
                frm_Reports.Show();

            }
            txtPwd.Text = "";
        }


           //frm_Reports frm_Reports = new frm_Reports();
           // CommonProfiles objComPro = new CommonProfiles();
           // //if (lblPwdOK.Text == "1")
           // //{
           // //    if (txtPwd.Text == lblPwd.Text)
           // //    {
                    
           // if (strReportName == "rpt_Profit")
           // {
           //     lblwait.Visible = true;
           //     PRINTINV_R();
           //     PRINTINV_I();

           // }
           // //if (strReportName == "rpt_ItemIssuesDateWise")
           // //{
           // //    ISSUENET();
           // //}
           // if (lblINVNO.Text == "")
           //     lblINVNO.Text = "0";
           // frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lbl_SysDate.Text), DateTime.Parse(lbl_SysLast.Text), lblINVNO.Text);
           // frm_Reports.Show();
           // //    }
           // //    else 
           // //    {
           // //        lblwait.Visible = false;
           // //        MessageBox.Show("Please Enter the Correct Password", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           // //    }
           // //}
           // //else if (lblPwdOK.Text == "0")
           // //{
           // //    //if (lblINVNO.Text == "")
           // //    //    lblINVNO.Text = "0";
           // //    frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lbl_SysDate.Text), DateTime.Parse(lbl_SysLast.Text), lblINVNO.Text);
           // //    frm_Reports.Show();
             
           // //}

        private void PRINTINV_R()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "DELETE FROM PRINT_INVOICE";
            cmdsql.ExecuteNonQuery();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT QTY, SEQ_NO, PARTNO, INV_NO, PRICE, QTY - BAL_QTY AS IQTY, QTY, PRICE, DIS_PRICE, TOT, ISSUE_PRICE / QTY AS ISSUE_PRICE FROM RECEIVED_ITEMS WHERE (QTY > BAL_QTY)";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                RSEQ_NO = int.Parse(dreader1["SEQ_NO"].ToString().Trim());
                IQTY = decimal.Parse(dreader1["IQTY"].ToString().Trim());
                QTY = decimal.Parse(dreader1["QTY"].ToString().Trim());
                PRICE = decimal.Parse(dreader1["PRICE"].ToString().Trim());
                DIS_PRICE = decimal.Parse(dreader1["DIS_PRICE"].ToString().Trim());
                ISSUE_PRICE = decimal.Parse(dreader1["ISSUE_PRICE"].ToString().Trim());
                PARTNO = dreader1["PARTNO"].ToString().Trim();
                INV_NO = dreader1["INV_NO"].ToString().Trim();

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "INSERT INTO PRINT_INVOICE (QTY, RSEQ_NO, PARTNO, INV_NO, RQTY, RPRICE, RDIS_PRICE, RISSUE_PRICE, RTOT)VALUES ('" + QTY + "', '" + RSEQ_NO + "', '" + PARTNO + "', '" + INV_NO + "', '" + IQTY + "', '" + PRICE + "', '" + DIS_PRICE + "', '" + ISSUE_PRICE + "', '" + QTY * PRICE + "')";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }
            _conn.Close();
        }

        private void PRINTINV_I()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT INV_NO, PRO_DATE, RECEIVE_SEQNO, SUM(QTY) AS QTY, PRICE, SUM(TOT) AS TOT FROM ISSUED_ITEMS WHERE (PRO_DATE = CONVERT(DATETIME, '"+ lbl_SysDate.Text +"', 102))GROUP BY INV_NO, RECEIVE_SEQNO, PARTNO, PRICE, PRO_DATE";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                RSEQ_NO = int.Parse(dreader1["RECEIVE_SEQNO"].ToString().Trim());
                QTY = decimal.Parse(dreader1["QTY"].ToString().Trim());
                PRICE = decimal.Parse(dreader1["PRICE"].ToString().Trim());
                ISSUE_PRICE = decimal.Parse(dreader1["TOT"].ToString().Trim());
                I_INV_NO = dreader1["INV_NO"].ToString().Trim();
                DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE PRINT_INVOICE SET PRO_DATE = Convert(DateTime,'" + DTPRO + "'),ISS_INV_NO = '" + I_INV_NO + "',ISEQ_NO = '" + RSEQ_NO + "', IQTY = '" + QTY + "', IPRICE = '" + PRICE + "', ITOT = '" + ISSUE_PRICE + "'WHERE RSEQ_NO = '" + RSEQ_NO + "'";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }
            _conn.Close();
        }

        private void ISSUENET()
        {
            int SEQNO;
            string INVNO;
            decimal QTY, UNIT, TOTV, DIS, LOAD, TRAN, OTH, NETVAL = 0;

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT SEQ_NO, QTY, PRICE, TOT, DISCOUNT, TRANS, LOADING, OTHER FROM VW_ISSUES";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                if (dreader.HasRows == true)
                {
                    SEQNO = int.Parse(dreader["SEQ_NO"].ToString().Trim());
                    QTY = decimal.Parse(dreader["QTY"].ToString().Trim());
                    UNIT = decimal.Parse(dreader["PRICE"].ToString().Trim());
                    TOTV = decimal.Parse(dreader["TOT"].ToString().Trim());
                    DIS = decimal.Parse(dreader["DISCOUNT"].ToString().Trim());
                    TRAN = decimal.Parse(dreader["TRANS"].ToString().Trim());
                    LOAD = decimal.Parse(dreader["LOADING"].ToString().Trim());
                    OTH = decimal.Parse(dreader["OTHER"].ToString().Trim());

                    NETVAL = TOTV - DIS + TRAN + LOAD + OTH;

                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();
                    SqlCommand cmdsql2 = new SqlCommand();
                    cmdsql2.Connection = _conn;
                    cmdsql2.CommandText = "UPDATE ISSUED_ITEMS SET NET = '" + NETVAL + "' WHERE (SEQ_NO = '" + SEQNO + "')";
                    cmdsql2.ExecuteNonQuery();
                }
            }
        }

        private void RECEIVENET()
        {
            int SEQNO;
            string INVNO;
            decimal QTY, UNIT, TOTV, DIS, LOAD, TRAN, OTH, NETVAL = 0;

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT SEQ_NO, QTY, PRICE, TOT, ISSUE_PRICE, DISCOUNT, TRANS, LOADING, OTHER FROM VW_RECEIVED";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                if (dreader.HasRows == true)
                {
                    SEQNO = int.Parse(dreader["SEQ_NO"].ToString().Trim());
                    QTY = decimal.Parse(dreader["QTY"].ToString().Trim());
                    UNIT = decimal.Parse(dreader["PRICE"].ToString().Trim());
                    TOTV = decimal.Parse(dreader["TOT"].ToString().Trim());
                    DIS = decimal.Parse(dreader["DISCOUNT"].ToString().Trim());
                    TRAN = decimal.Parse(dreader["TRANS"].ToString().Trim());
                    LOAD = decimal.Parse(dreader["LOADING"].ToString().Trim());
                    OTH = decimal.Parse(dreader["OTHER"].ToString().Trim());

                    NETVAL = TOTV - DIS + TRAN + LOAD + OTH;

                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();
                    SqlCommand cmdsql2 = new SqlCommand();
                    cmdsql2.Connection = _conn;
                    cmdsql2.CommandText = "UPDATE RECEIVED_ITEMS SET NET = '" + NETVAL + "' WHERE (SEQ_NO = '" + SEQNO + "')";
                    cmdsql2.ExecuteNonQuery();
                }
            }
        }

        private void FINDCASHCREDIT()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql3 = new SqlCommand();
            cmdsql3.Connection = _conn;
            cmdsql3.CommandText = "DELETE FROM RPT_MIR_RANGE";
            cmdsql3.ExecuteNonQuery();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT PRO_DATE, INV_NO FROM ISSUED_ITEMS GROUP BY PRO_DATE, INV_NO HAVING (PRO_DATE BETWEEN CONVERT(DATETIME, '" + lbl_SysDate.Text + "', 102) AND CONVERT(DATETIME, '" + lbl_SysLast.Text + "', 102))ORDER BY INV_NO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                FINDINV_NO = Convert.ToInt16(dreader["INV_NO"].ToString());
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "SELECT INV_NO, CASH, CREDIT FROM ISSUED_TOTALS WHERE (INV_NO = '" + FINDINV_NO + "') AND (CASH IS NOT NULL) AND (CREDIT IS NOT NULL)";
                SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                while (dreader1.Read())
                {
                    TOTCASH = Convert.ToDecimal(dreader1["CASH"].ToString());
                    TOTCRESDIT = Convert.ToDecimal(dreader1["CREDIT"].ToString());

                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();
                    SqlCommand cmdsql2 = new SqlCommand();
                    cmdsql2.Connection = _conn;
                    cmdsql2.CommandText = "INSERT INTO RPT_MIR_RANGE (INV_NO, CASH, CREDIT) VALUES ('" + FINDINV_NO + "', '" + TOTCASH + "', '" + TOTCRESDIT + "')";
                    cmdsql2.ExecuteNonQuery();

                }
                dreader1.Close();
            }
            dreader.Close();
            
            _conn.Close();
        }

        private void trvReports_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strCriteria = e.Node.Text;

            this.Text = "Report Criteria for " + strCriteria;

            switch (e.Node.Name)
            {
                case "chnMIR":
                    lblPwdOK.Text = "0";
                    MIRINVNOS();
                    lblINVNO.DroppedDown = true;
                    panel2.Visible = true;
                    panel2.Enabled = true;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_MIRCredit";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    
                    break;
                case "chnGRN":
                    lblPwdOK.Text = "0";
                    GRNINVNOS();
                    lblINVNO.DroppedDown = true;
                    panel2.Visible = true;
                    panel2.Enabled = true;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_GRNCredit";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnGRNP":
                    lblPwdOK.Text = "1";
                    //GRNINVNOS();
                   
                    //lblINVNO.DroppedDown = true;
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_GRNProfit";
                    pnlDt.Enabled = true;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    gbPSW.Visible = true;
                    txtPwd.Focus();
                    ProfitPWD();
                    timer2.Enabled = true;
                    break;
                case "chnMIRR":
                    lblPwdOK.Text = "1";
                    MIRINVNOS();
                    TOTISSUE();
                    //FINDCASHCREDIT();
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = true;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_MIRCreditDateRange";
                    pnlDt.Visible = true;
                    pnlDt.Enabled = true;
                    lbl_SysLast.Enabled = true;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    txtPwd.Focus();
                    ProfitPWD();
                    timer2.Enabled = true;
                    break;
                case "chnGRNR":
                    lblPwdOK.Text = "0";
                    GRNINVNOS();
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_GRNCreditDateRange";
                    lbl_SysLast.Enabled = true;
                    pnlDt.Visible = true;
                    pnlDt.Enabled = true;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnSBD":
                    lblPwdOK.Text = "0";
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_ItemBalance";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnSBS":
                    lblPwdOK.Text = "0";
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_ItemBalanceSumm";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnMain":
                    lblPwdOK.Text = "0";
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_Master";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnSup":
                    lblPwdOK.Text = "0";
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_Supplier";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnSupSum":
                    SUP();
                    lblCUSSUP.DroppedDown = true;
                    lblPwdOK.Text = "0";
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = true;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_SupplierWise";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnRSup":
                    lblPwdOK.Text = "0";
                    gbPSW.Visible = false;
                    panel4.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_RSupplier";
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnCus":
                    lblPwdOK.Text = "0";
                    panel2.Visible = false;
                    panel4.Visible = false;
                    panel2.Enabled = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_Customer";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnCusSum":
                    CUS();
                    lblCUSSUP.DroppedDown = true;
                    lblPwdOK.Text = "0";
                    panel2.Visible = false;
                    panel4.Visible = true;
                    panel2.Enabled = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_CustomerWise";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnRCus":
                    lblPwdOK.Text = "0";
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_RCustomer";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnPro":
                    lblPwdOK.Text = "1";
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = true;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    timer1.Enabled = true;
                    strReportName = "rpt_Profit";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    pnlDt.Enabled = true;
                    //grbDates.Enabled = false;
                    txtPwd.Focus();
                    ProfitPWD();
                    break;
                case "chnDayPro":
                    lblPwdOK.Text = "1";
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = true;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    timer1.Enabled = true;
                    strReportName = "rpt_DayProfit";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    pnlDt.Enabled = true;
                    //grbDates.Enabled = false;
                    txtPwd.Focus();
                    ProfitPWD();
                    break;
                case "chnInv":
                    lblPwdOK.Text = "0";
                    MIRINVNOS();
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_Print";
                    pnlDt.Enabled = false;
                    panel2.Visible = true;
                    panel2.Enabled = true;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnSC":
                    lblPwdOK.Text = "0";
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_GRNCredit";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnCC":
                    lblPwdOK.Text = "0";
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_MIRCredit";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
                case "chnRe":
                    lblPwdOK.Text = "0";
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel4.Visible = false;
                    gbPSW.Visible = false;
                    //btnSubmit.Visible = true;
                    //btnSubmit.Enabled = true;
                    //pnlDt.Enabled = false;
                    strReportName = "rpt_ROL";
                    pnlDt.Enabled = false;
                    grbCriteria.Visible = false;
                    //grbDates.Enabled = false;
                    break;
            }
        }

        private void MIRINVNOS()
        {
            lblINVNO.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT DISTINCT INV_NO FROM ISSUED_ITEMS";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                lblINVNO.Items.Add(dreader["INV_NO"].ToString());
            }
            
            dreader.Close();
            _conn.Dispose();
        }

        private void CUS()
        {
            lblCUSSUP.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT DISTINCT NAME FROM CUSTOMER_INFO";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                lblCUSSUP.Items.Add(dreader["NAME"].ToString());
            }
            
            dreader.Close();
            _conn.Dispose();
        }

        private void SUP()
        {
            lblCUSSUP.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT DISTINCT NAME FROM SUPPLIER_INFO";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                lblCUSSUP.Items.Add(dreader["NAME"].ToString());
            }
            
            dreader.Close();
            _conn.Dispose();
        }

        private void GRNINVNOS()
        {
            lblINVNO.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT DISTINCT INV_NO FROM RECEIVED_ITEMS";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                lblINVNO.Items.Add(dreader["INV_NO"].ToString());
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
                lbl_SysDate.Text = dreader["PRO_DATE"].ToString();
                lbl_SysLast.Text = dreader["PRO_DATE"].ToString();
            }

            dreader.Close();
            _conn.Dispose();
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

        private void frm_ReportCriteria_Load(object sender, EventArgs e)
        {
            
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            _conn1 = obyConn.Connect();

            trvReports.ExpandAll();
            txtPW.Focus();
            //lbl_SysDate.Value = DateTime.Today.Date;
            SystemDate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblPwd_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

         private void PRINTINV_RR()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();



            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT QTY, SEQ_NO, PARTNO, INV_NO, PRICE, QTY - BAL_QTY AS IQTY, QTY, PRICE, DIS_PRICE, TOT, ISSUE_PRICE / QTY AS ISSUE_PRICE FROM RECEIVED_ITEMS WHERE (QTY > BAL_QTY)";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                RSEQ_NO = int.Parse(dreader1["SEQ_NO"].ToString().Trim());
                IQTY = decimal.Parse(dreader1["IQTY"].ToString().Trim());
                QTY = decimal.Parse(dreader1["QTY"].ToString().Trim());
                PRICE = decimal.Parse(dreader1["PRICE"].ToString().Trim());
                DIS_PRICE = decimal.Parse(dreader1["DIS_PRICE"].ToString().Trim());
                ISSUE_PRICE = decimal.Parse(dreader1["ISSUE_PRICE"].ToString().Trim());
                PARTNO = dreader1["PARTNO"].ToString().Trim();
                INV_NO = dreader1["INV_NO"].ToString().Trim();

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE PRINT_INVOICE SET INV_NO = '" + INV_NO + "', RSEQ_NO = '" + RSEQ_NO + "', IQTY = '" + QTY + "', IPRICE = '" + PRICE + "', ITOT = '" + ISSUE_PRICE + "'WHERE RSEQ_NO = '" + RSEQ_NO + "'";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }
            _conn.Close();
        }

        private void PRINTINV_II()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "DELETE FROM PRINT_INVOICE";
            cmdsql.ExecuteNonQuery();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT INV_NO, PARTNO, PRO_DATE, RECEIVE_SEQNO, SUM(QTY) AS QTY, PRICE, SUM(TOT) AS TOT FROM ISSUED_ITEMS WHERE (PRO_DATE BETWEEN CONVERT(DATETIME, '" + lbl_SysDate.Text + "', 102) AND CONVERT(DATETIME, '" + lbl_SysLast.Text + "', 102))GROUP BY INV_NO, RECEIVE_SEQNO, PARTNO, PRICE, PRO_DATE ORDER BY PRO_DATE, INV_NO";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                RSEQ_NO = int.Parse(dreader1["RECEIVE_SEQNO"].ToString().Trim());
                QTY = decimal.Parse(dreader1["QTY"].ToString().Trim());
                PRICE = decimal.Parse(dreader1["PRICE"].ToString().Trim());
                ISSUE_PRICE = decimal.Parse(dreader1["TOT"].ToString().Trim());
                I_INV_NO = dreader1["INV_NO"].ToString().Trim();
                I_PARTNO = dreader1["PARTNO"].ToString().Trim();
                DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "INSERT INTO PRINT_INVOICE (QTY, ISEQ_NO, PARTNO, ISS_INV_NO, RQTY, IQTY, IPRICE, ITOT, IPRO_DATE, PRO_DATE)VALUES ('" + QTY + "', '" + RSEQ_NO + "', '" + I_PARTNO + "', '" + I_INV_NO + "', '" + QTY + "', '" + QTY + "', '" + PRICE + "', '" + ISSUE_PRICE + "', Convert(DateTime,'" + DTPRO + "', 102), Convert(DateTime,'" + DTPRO + "', 102))";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();

                
            }
            _conn.Close();
        }

        private void PRINTINV_RRR()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();



            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT QTY, SEQ_NO, PARTNO, INV_NO, PRICE, QTY - BAL_QTY AS IQTY, QTY, PRICE, DIS_PRICE, TOT, ISSUE_PRICE / QTY AS ISSUE_PRICE FROM RECEIVED_ITEMS WHERE  SEQ_NO = '" + RSEQ_NO + "'";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                RSEQ_NO = int.Parse(dreader1["SEQ_NO"].ToString().Trim());
                IQTY = decimal.Parse(dreader1["IQTY"].ToString().Trim());
                QTY = decimal.Parse(dreader1["QTY"].ToString().Trim());
                PRICE = decimal.Parse(dreader1["PRICE"].ToString().Trim());
                DIS_PRICE = decimal.Parse(dreader1["DIS_PRICE"].ToString().Trim());
                ISSUE_PRICE = decimal.Parse(dreader1["ISSUE_PRICE"].ToString().Trim());
                PARTNO = dreader1["PARTNO"].ToString().Trim();
                INV_NO = dreader1["INV_NO"].ToString().Trim();
                decimal RECV_TOT = QTY * PRICE;

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE PRINT_INVOICE SET INV_NO = '" + INV_NO + "', RPRICE = '" + PRICE + "', RTOT = '" + RECV_TOT + "', RDIS_PRICE = '" + DIS_PRICE + "', RSEQ_NO = '" + RSEQ_NO + "', IQTY = '" + QTY + "', IPRICE = '" + PRICE + "', ITOT = '" + ISSUE_PRICE + "'WHERE ISEQ_NO = '" + RSEQ_NO + "'";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }
            _conn.Close();
        }

        private void PRINTINV_III()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "DELETE FROM PRINT_INVOICE";
            cmdsql.ExecuteNonQuery();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT INV_NO, PARTNO, PRO_DATE, RECEIVE_SEQNO, SUM(QTY) AS QTY, PRICE, SUM(TOT) AS TOT FROM ISSUED_ITEMS WHERE (PRO_DATE BETWEEN CONVERT(DATETIME, '" + lbl_SysDate.Text + "', 102) AND CONVERT(DATETIME, '" + lbl_SysLast.Text + "', 102))GROUP BY INV_NO, RECEIVE_SEQNO, PARTNO, PRICE, PRO_DATE ORDER BY INV_NO";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                RSEQ_NO = int.Parse(dreader1["RECEIVE_SEQNO"].ToString().Trim());
                QTY = decimal.Parse(dreader1["QTY"].ToString().Trim());
                PRICE = decimal.Parse(dreader1["PRICE"].ToString().Trim());
                ISSUE_PRICE = decimal.Parse(dreader1["TOT"].ToString().Trim());
                I_INV_NO = dreader1["INV_NO"].ToString().Trim();
                I_PARTNO = dreader1["PARTNO"].ToString().Trim();
                DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "INSERT INTO PRINT_INVOICE (QTY, ISEQ_NO, PARTNO, ISS_INV_NO, RQTY, IQTY, IPRICE, ITOT, IPRO_DATE, PRO_DATE)VALUES ('" + QTY + "', '" + RSEQ_NO + "', '" + I_PARTNO + "', '" + I_INV_NO + "', '" + QTY + "', '" + QTY + "', '" + PRICE + "', '" + ISSUE_PRICE + "', Convert(DateTime,'" + DTPRO + "', 102), Convert(DateTime,'" + DTPRO + "', 102))";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();

                PRINTINV_RRR();
            }
            _conn.Close();
        }


        private void PRINTINV_RVALS()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT ISEQ_NO FROM PRINT_INVOICE ORDER BY INV_NO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                RSEQ_NO = int.Parse(dreader["ISEQ_NO"].ToString().Trim());

                _conn = obyConn.Connect();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "SELECT PRICE, DIS_PRICE FROM RECEIVED_ITEMS WHERE (SEQ_NO = '" + RSEQ_NO + "')";
                SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                while (dreader1.Read())
                {
                    PRICE = decimal.Parse(dreader1["PRICE"].ToString().Trim());
                    DIS_PRICE = decimal.Parse(dreader1["DIS_PRICE"].ToString().Trim());

                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();
                    SqlCommand cmdsql2 = new SqlCommand();
                    cmdsql2.Connection = _conn;
                    cmdsql2.CommandText = "UPDATE PRINT_INVOICE SET RPRICE = '" + PRICE + "', RDIS_PRICE = '" + DIS_PRICE + "' WHERE ISEQ_NO = '" + RSEQ_NO + "'";
                    cmdsql2.ExecuteNonQuery();
                    cmdsql2.Dispose();
                }
                dreader1.Close();
            }
            dreader.Close();
        }


	           
        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                frm_Reports frm_Reports = new frm_Reports();
                CommonProfiles objComPro = new CommonProfiles();
                if (txtPwd.Text == lblPwd.Text)
                {
                    lblwait.Visible = true;
                    if (strReportName == "rpt_Profit")
                    {

                        PRINTINV_II();
                        PRINTINV_RR();
                        PRINTINV_RVALS();


                    }
                    if (strReportName == "rpt_GRNCreditDateRange")
                    {
                        FINDGRNCASHCREDIT();
                    }
                    if (strReportName == "rpt_MIRCreditDateRange")
                    {
                        FINDMIRCASHCREDIT();
                        FINDTOTS();
                    }

                    if (strReportName == "rpt_DayProfit")
                    {
                        lblwait.Visible = true;

                        DAYISSUES();
                        DAYISSUES_CASH_CREDIT();
                        UP_BEFORE_CASH();
                        PRINTINV_III();
                        UP_DAY_PROFIT();
                        UP_DAY_PROFIT_DIFF();
                        DAY_EXP();
                        EMP_EXP();
                    }
                        
                    
                    frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lbl_SysDate.Text), DateTime.Parse(lbl_SysLast.Text), lblINVNO.Text, lblCUSSUP.Text);
                    frm_Reports.Show();
                }
                else
                {
                    lblwait.Visible = false;
                    MessageBox.Show("Please Enter the Correct Password", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                txtPwd.Text = "";
            }
            
        }

        private void FINDGRNCASHCREDIT()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql3 = new SqlCommand();
            cmdsql3.Connection = _conn;
            cmdsql3.CommandText = "DELETE FROM RPT_GRN_RANGE";
            cmdsql3.ExecuteNonQuery();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT PRO_DATE, INV_NO FROM RECEIVED_ITEMS GROUP BY PRO_DATE, INV_NO HAVING (PRO_DATE BETWEEN CONVERT(DATETIME, '" + lbl_SysDate.Text + "', 102) AND CONVERT(DATETIME, '" + lbl_SysLast.Text + "', 102))ORDER BY INV_NO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                FINDINV_NO = Convert.ToInt16(dreader["INV_NO"].ToString());
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "SELECT INV_NO, CASH, CREDIT FROM RECEIVED_TOTALS WHERE (INV_NO = '" + FINDINV_NO + "') AND (CASH IS NOT NULL) AND (CREDIT IS NOT NULL)";
                SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                while (dreader1.Read())
                {
                    TOTCASH = Convert.ToDecimal(dreader1["CASH"].ToString());
                    TOTCRESDIT = Convert.ToDecimal(dreader1["CREDIT"].ToString());

                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();
                    SqlCommand cmdsql2 = new SqlCommand();
                    cmdsql2.Connection = _conn;
                    cmdsql2.CommandText = "INSERT INTO RPT_GRN_RANGE (INV_NO, CASH, CREDIT) VALUES ('" + FINDINV_NO + "', '" + TOTCASH + "', '" + TOTCRESDIT + "')";
                    cmdsql2.ExecuteNonQuery();

                }
                dreader1.Close();
            }
            dreader.Close();

            _conn.Close();
        }

        private void FINDMIRCASHCREDIT()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql3 = new SqlCommand();
            cmdsql3.Connection = _conn;
            cmdsql3.CommandText = "DELETE FROM RPT_MIR_RANGE";
            cmdsql3.ExecuteNonQuery();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT PRO_DATE, INV_NO FROM ISSUED_ITEMS GROUP BY PRO_DATE, INV_NO HAVING (PRO_DATE BETWEEN CONVERT(DATETIME, '" + lbl_SysDate.Text + "', 102) AND CONVERT(DATETIME, '" + lbl_SysLast.Text + "', 102))ORDER BY INV_NO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                FINDINV_NO = Convert.ToInt16(dreader["INV_NO"].ToString());
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "SELECT INV_NO, CASH, CREDIT FROM ISSUED_TOTALS WHERE (INV_NO = '" + FINDINV_NO + "') AND (CASH IS NOT NULL) AND (CREDIT IS NOT NULL)";
                SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                while (dreader1.Read())
                {
                    TOTCASH = Convert.ToDecimal(dreader1["CASH"].ToString());
                    TOTCRESDIT = Convert.ToDecimal(dreader1["CREDIT"].ToString());

                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();
                    SqlCommand cmdsql2 = new SqlCommand();
                    cmdsql2.Connection = _conn;
                    cmdsql2.CommandText = "INSERT INTO RPT_MIR_RANGE (INV_NO, CASH, CREDIT) VALUES ('" + FINDINV_NO + "', '" + TOTCASH + "', '" + TOTCRESDIT + "')";
                    cmdsql2.ExecuteNonQuery();

                }
                dreader1.Close();
            }
            dreader.Close();

            _conn.Close();
        }


        private void FINDTOTS()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT SUM(CASH) AS CASH, SUM(CREDIT) AS CREDIT FROM RPT_MIR_RANGE";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                TOTCASH = Convert.ToDecimal(dreader["CASH"].ToString());
                TOTCRESDIT = Convert.ToDecimal(dreader["CREDIT"].ToString());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "INSERT INTO RPT_MIR_RANGE (INV_NO, CASH, CREDIT) VALUES ('" + FINDINV_NO + "', '" + TOTCASH + "', '" + TOTCRESDIT + "')";
                cmdsql2.ExecuteNonQuery();
            }
            dreader.Close();

            _conn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtPwd.Focus();
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            txtPwd.Focus();
            timer2.Enabled = false;
        }

        private void lblCus_SelectedValueChanged(object sender, EventArgs e)
        {
            lblSEQ.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT SEQ_NO FROM CUSTOMER_INFO WHERE NAME = '"+ lblCUSSUP.Text +"'";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                lblSEQ.Text = dreader["SEQ_NO"].ToString();
                return;
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void lblSup_SelectedValueChanged(object sender, EventArgs e)
        {
            lblSEQ.Text = "";
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT SEQ_NO FROM SUPPLIER_INFO WHERE NAME = '" + lblCUSSUP.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                lblSEQ.Text = dreader["SEQ_NO"].ToString();
                return;
            }

            dreader.Close();
            _conn.Dispose();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlDt_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_SysLast_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DAYISSUES()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "DELETE FROM DAY_PROFIT";
            cmdsql.ExecuteNonQuery();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            //cmdsql1.CommandText = "SELECT INV_NO, PRO_DATE, SUM(TOT) AS TOTAL FROM ISSUED_ITEMS GROUP BY INV_NO, PRO_DATE HAVING(PRO_DATE BETWEEN CONVERT(DATETIME, '" + lbl_SysDate.Text + "', 102) AND CONVERT(DATETIME, '" + lbl_SysLast.Text + "', 102))";
            cmdsql1.CommandText = "SELECT PRO_DATE, SUM(TOT) AS TOTAL FROM ISSUED_ITEMS GROUP BY PRO_DATE HAVING(PRO_DATE BETWEEN CONVERT(DATETIME, '" + lbl_SysDate.Text + "', 102) AND CONVERT(DATETIME, '" + lbl_SysLast.Text + "', 102))";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                ISSUE_PRICE = decimal.Parse(dreader1["TOTAL"].ToString().Trim());
                //I_INV_NO = dreader1["INV_NO"].ToString().Trim();
                DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "INSERT INTO DAY_PROFIT (PRO_DATE, DAY_ISSUES)VALUES (Convert(DateTime,'" + DTPRO + "', 102), '" + ISSUE_PRICE + "')";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }

            _conn.Close();
        }

        private void DAYISSUES_CASH_CREDIT()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT DISTINCT ISSUED_TOTALS.INV_NO AS INV_NO, ISSUED_TOTALS.CASH AS CASH, ISSUED_TOTALS.CREDIT AS CREDIT, ISSUED_ITEMS.PRO_DATE FROM ISSUED_TOTALS INNER JOIN ISSUED_ITEMS ON ISSUED_TOTALS.INV_NO = ISSUED_ITEMS.INV_NO GROUP BY ISSUED_TOTALS.INV_NO, ISSUED_ITEMS.PRO_DATE, ISSUED_TOTALS.CASH, ISSUED_TOTALS.CREDIT ORDER BY ISSUED_ITEMS.PRO_DATE";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                CASH_AMNT = decimal.Parse(dreader1["CASH"].ToString().Trim());
                CREDIT_AMNT = decimal.Parse(dreader1["CREDIT"].ToString().Trim());
                //I_INV_NO = dreader1["INV_NO"].ToString().Trim();
                DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE DAY_PROFIT SET CASH = CASH + '" + CASH_AMNT + "', CREDIT = CREDIT + '" + CREDIT_AMNT + "' WHERE PRO_DATE = '" + DTPRO + "'";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }

            _conn.Close();
        }


        private void TOTISSUE()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT SUM(TOT) AS TOTAL FROM ISSUED_ITEMS WHERE (PRO_DATE BETWEEN CONVERT(DATETIME, '" + lbl_SysDate.Text + "', 102) AND CONVERT(DATETIME, '" + lbl_SysLast.Text + "', 102))";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                ISSUE_PRICE = decimal.Parse(dreader1["TOTAL"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE TOTALS SET MIR_RANGE = '" + ISSUE_PRICE + "'";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }

            _conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAYISSUES();

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_Reports frm_Reports = new frm_Reports();
            CommonProfiles objComPro = new CommonProfiles();

            strReportName = "rpt_DayProfit";
            if (strReportName == "rpt_DayProfit")
            {
                lblwait.Visible = true;

               

                if (lblINVNO.Text == "")
                    lblINVNO.Text = "0";
                frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lbl_SysDate.Text), DateTime.Parse(lbl_SysLast.Text), lblINVNO.Text, lblCUSSUP.Text);
                frm_Reports.Show();
            }
        }

        private void UP_BEFORE_CASH()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT PRO_DATE, SUM(AMOUNT) AS AMOUNT FROM DAY_EARNINGS WHERE (DESCRIPTION = 'PREVIOUS DAY INCOME') AND (PRO_DATE BETWEEN CONVERT(DATETIME, '" + lbl_SysDate.Text + "', 102) AND CONVERT(DATETIME,'" + lbl_SysLast.Text + "', 102))GROUP BY PRO_DATE";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                TOT = decimal.Parse(dreader1["AMOUNT"].ToString().Trim());
                //decimal DIFF = ISSUE_PRICE - RECEIVE_PRICE;
                DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE DAY_PROFIT SET PRE_CASH = '" + TOT + "' WHERE PRO_DATE = '" + DTPRO + "'";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }

            _conn.Close();
        }

        private void UP_DAY_PROFIT()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT PRO_DATE, SUM(QTY * ITOT) AS ISSUED, SUM(QTY * RDIS_PRICE) AS RECEIVED FROM PRINT_INVOICE GROUP BY PRO_DATE ORDER BY PRO_DATE";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                ISSUE_PRICE = decimal.Parse(dreader1["ISSUED"].ToString().Trim());
                RECEIVE_PRICE = decimal.Parse(dreader1["RECEIVED"].ToString().Trim());
                //decimal DIFF = ISSUE_PRICE - RECEIVE_PRICE;
                DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE DAY_PROFIT SET DAY_RECEIVES = '" + RECEIVE_PRICE + "' WHERE PRO_DATE = '" + DTPRO + "'";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }

            _conn.Close();
        }

        private void UP_DAY_PROFIT_DIFF()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT PRO_DATE, DAY_RECEIVES, DAY_ISSUES FROM DAY_PROFIT ORDER BY PRO_DATE";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                ISSUE_PRICE = decimal.Parse(dreader1["DAY_ISSUES"].ToString().Trim());
                RECEIVE_PRICE = decimal.Parse(dreader1["DAY_RECEIVES"].ToString().Trim());
                decimal DIFF = ISSUE_PRICE - RECEIVE_PRICE;
                DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE DAY_PROFIT SET DAY_PROFIT = '" + DIFF + "' WHERE PRO_DATE = '" + DTPRO + "'";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }

            _conn.Close();
        }

        //private void UP_DAY_PROFIT_ORG()
        //{
        //    Connection.DatabaseConnection obyConn;
        //    obyConn = new Connection.DatabaseConnection();
        //    _conn = obyConn.Connect();

        //    obyConn = new Connection.DatabaseConnection();
        //    _conn = obyConn.Connect();
        //    SqlCommand cmdsql1 = new SqlCommand();
        //    cmdsql1.Connection = _conn;
        //    cmdsql1.CommandText = "SELECT PRO_DATE, SUM(QTY * ITOT) AS ISSUED, SUM(QTY * RDIS_PRICE) AS RECEIVED FROM PRINT_INVOICE GROUP BY PRO_DATE ORDER BY PRO_DATE";
        //    SqlDataReader dreader1 = cmdsql1.ExecuteReader();
        //    while (dreader1.Read())
        //    {
        //        ISSUE_PRICE = decimal.Parse(dreader1["ISSUED"].ToString().Trim());
        //        RECEIVE_PRICE = decimal.Parse(dreader1["RECEIVED"].ToString().Trim());
        //        decimal DIFF = ISSUE_PRICE - RECEIVE_PRICE;
        //        DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

        //        obyConn = new Connection.DatabaseConnection();
        //        _conn = obyConn.Connect();
        //        SqlCommand cmdsql2 = new SqlCommand();
        //        cmdsql2.Connection = _conn;
        //        cmdsql2.CommandText = "UPDATE DAY_PROFIT SET DAY_PROFIT = '" + DIFF + "', DAY_RECEIVES = '" + RECEIVE_PRICE + "' WHERE PRO_DATE = '" + DTPRO + "'";
        //        cmdsql2.ExecuteNonQuery();
        //        cmdsql2.Dispose();
        //    }

        //    _conn.Close();
        //}


        private void button3_Click(object sender, EventArgs e)
        {
            DAY_EXP();
            EMP_EXP();
        }

        private void DAY_EXP()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT PRO_DATE, SUM(AMOUNT) AS TOTAL FROM DAY_EXPENCES GROUP BY PRO_DATE HAVING (PRO_DATE BETWEEN CONVERT(DATETIME, '" + lbl_SysDate.Text + "', 102) AND CONVERT(DATETIME, '" + lbl_SysLast.Text + "', 102)) ORDER BY PRO_DATE";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                TOTAL = decimal.Parse(dreader1["TOTAL"].ToString().Trim());
                DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE DAY_PROFIT SET DAY_EXP = '" + TOTAL + "' WHERE PRO_DATE = '" + DTPRO + "'";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }

            _conn.Close();
        }

        private void EMP_EXP()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _conn;
            cmdsql1.CommandText = "SELECT PRO_DATE, SUM(AMOUNT) AS TOTAL FROM EMP_EXPENCES GROUP BY PRO_DATE HAVING (PRO_DATE BETWEEN CONVERT(DATETIME, '" + lbl_SysDate.Text + "', 102) AND CONVERT(DATETIME, '" + lbl_SysLast.Text + "', 102)) ORDER BY PRO_DATE";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                TOTAL = decimal.Parse(dreader1["TOTAL"].ToString().Trim());
                DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE DAY_PROFIT SET EMP_EXP = '" + TOTAL + "' WHERE PRO_DATE = '" + DTPRO + "'";
                cmdsql2.ExecuteNonQuery();
                cmdsql2.Dispose();
            }

            _conn.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
