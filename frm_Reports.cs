using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Billing_Inventory_Management_System
{
    public partial class frm_Reports : Form
    {
        private SqlConnection _conn;
        ReportDocument crdReportDocument = new ReportDocument();
        int LocID;
        private string strCriteria = "";
        private string strReportName = "";

        public frm_Reports()
        {
            InitializeComponent();
        }

        public void GetReportCriteria(string strReportName, string strCriteria, DateTime strDate, DateTime strEndDate, string strVNO, string strNAME)
        {
            crystalReportViewer1.Refresh();

            crdReportDocument.Load(Application.StartupPath + "\\" + strReportName + ".rpt");
            crdReportDocument.Refresh();

            CommonProfiles objComPro = new CommonProfiles();
            frm_ReportCriteria_Inventory objRepCriteria = new frm_ReportCriteria_Inventory();
            frm_ReceiveMode objRepCriteria1 = new frm_ReceiveMode();

            ApplyInfo(crdReportDocument);

            bool ParExist = true;

            switch (strReportName)
            {
                case "rpt_Profit":
                    crdReportDocument.SetParameterValue("NDATE", strDate);
                    crdReportDocument.SetParameterValue("LDATE", strEndDate);
                    ParExist = false;
                    break;
                case "rpt_DayProfit":
                    crdReportDocument.SetParameterValue("NDATE", strDate);
                    crdReportDocument.SetParameterValue("LDATE", strEndDate);
                    ParExist = false;
                    break;
                case "rpt_GRNCredit":
                    crdReportDocument.SetParameterValue("DATE", strDate);
                    //crdReportDocument.SetParameterValue("LASTDATE", strEndDate);
                    ParExist = false;
                    break;
                case "rpt_MIRCredit":
                    crdReportDocument.SetParameterValue("DATE", strDate);
                    //crdReportDocument.SetParameterValue("LASTDATE", strEndDate);
                    ParExist = false;
                    break;
                case "rpt_GRNCreditDateRange":
                    crdReportDocument.SetParameterValue("DATE", strDate);
                    crdReportDocument.SetParameterValue("LDATE", strEndDate);
                    ParExist = false;
                    break;
                case "rpt_MIRCreditDateRange":
                    crdReportDocument.SetParameterValue("DATE", strDate);
                    crdReportDocument.SetParameterValue("LDATE", strEndDate);
                    ParExist = false;
                    break;
                case "rpt_CustomerWise":
                    crdReportDocument.SetParameterValue("NAME", strNAME);
                    ParExist = false;
                    break;
                case "rpt_SupplierWise":
                    crdReportDocument.SetParameterValue("NAME", strNAME);
                    ParExist = false;
                    break;
                //case "rpt_ItemReceivedDateRange":
                //    crdReportDocument.SetParameterValue("DATE", strDate);
                //    crdReportDocument.SetParameterValue("DATE", strEndDate);
                //    ParExist = false;
                //    break;
                //case "rpt_ItemIssuesDateRange":
                //    crdReportDocument.SetParameterValue("DATE", strDate);
                //    crdReportDocument.SetParameterValue("DATE", strEndDate);
                //    ParExist = false;
                //    break;
                case "rpt_Print":
                    crdReportDocument.SetParameterValue("INVOICE", strVNO);
                    //crdReportDocument.SetParameterValue("LASTDATE", strEndDate);
                    ParExist = false;
                    break;
                case "rpt_Customer":
                    ParExist = false;
                    break;
                case "rpt_ROL":
                    ParExist = false;
                    break;
                case "rpt_Supplier":
                    ParExist = false;
                    break;
                case "rpt_RSupplier":
                    ParExist = false;
                    break;
                case "rpt_CSupplier":
                    ParExist = false;
                    break;
                case "rpt_Master":
                    ParExist = false;
                    break;
                case "rpt_SBDetail":
                    ParExist = false;
                    break;
                case "rpt_ItemBalance":
                    ParExist = false;
                    break;
                //case "rpt_GRNCredit":
                //    crdReportDocument.SetParameterValue("DateSort", strDate);
                //    ParExist = false;
                //    break;
                //case "rpt_MIRCredit":
                //    crdReportDocument.SetParameterValue("DateSort", strDate);
                //    ParExist = false;
                //    break;

            }

            if (ParExist == true)
            {
                //crdReportDocument.SetParameterValue("Month", strDate);
            }

            if (crdReportDocument.Rows.Count > 0)
            {
                crystalReportViewer1.Refresh();
                crystalReportViewer1.ReportSource = crdReportDocument;

            }
            else
            {
                MessageBox.Show("No data for Selected Criteria");
            }
            // Used to Add back educted previous month EPF amount from Data Base
            //      if (strReportName == "EPF_Monthly_Report")// Added on 13-Apr-2011 - to Pause print ETF and brought forward to next month
            //      {
            //          objRepCriteria.HandleETFReport("Ded", intYear, objComPro.GetMonthConverted(strMonth));
            //      }
        }


        public void GetReportCriteriaA(string strReportName, string strCriteria, string strVNO, int intSEQ)
        //    public void GetReportCriteriaA(string strReportName, string strCriteria, string strVNO, string strNAME, int intSEQ)
        {
            crystalReportViewer1.Refresh();

            crdReportDocument.Load(Application.StartupPath + "\\" + strReportName + ".rpt");
            crdReportDocument.Refresh();
            ApplyBrand(crdReportDocument);

            CommonProfiles objComPro = new CommonProfiles();
            frm_ReportCriteria_Inventory objRepCriteria = new frm_ReportCriteria_Inventory();
            frm_ReceiveMode objRepCriteria1 = new frm_ReceiveMode();

            ApplyInfo(crdReportDocument);

            bool ParExist = true;

            switch (strReportName)
            {
                case "rpt_JobDetails":
                    crdReportDocument.SetParameterValue("VNO", strVNO);
                    //crdReportDocument.SetParameterValue("VNO1", strVNO);
                    crdReportDocument.SetParameterValue("SEQ", strVNO);
                    ParExist = false;
                    break;
                case "rpt_Invoice":
                    crdReportDocument.SetParameterValue("VNO", strVNO);
                    crdReportDocument.SetParameterValue("CASHIER", GetCurrentCashier());
                    ParExist = false;
                    break;
            }

            if (ParExist == true)
            {
                //crdReportDocument.SetParameterValue("Month", strDate);
            }

            if (crdReportDocument.Rows.Count > 0)
            {
                crystalReportViewer1.Refresh();
                crystalReportViewer1.ReportSource = crdReportDocument;

            }
            else
            {
                MessageBox.Show("No data for Selected Criteria");
            }
            // Used to Add back educted previous month EPF amount from Data Base
            //      if (strReportName == "EPF_Monthly_Report")// Added on 13-Apr-2011 - to Pause print ETF and brought forward to next month
            //      {
            //          objRepCriteria.HandleETFReport("Ded", intYear, objComPro.GetMonthConverted(strMonth));
            //                  }
        }

        private static void ApplyBrand(ReportDocument report)
        {
            if (report == null)
            {
                return;
            }
            foreach (Section section in report.ReportDefinition.Sections)
            {
                foreach (ReportObject item in section.ReportObjects)
                {
                    TextObject text = item as TextObject;
                    if (text != null && text.Text != null && text.Text.IndexOf("LOGICAL DATA", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        text.Text = "Software by - NEXUS CODE LABS";
                    }
                }
            }
        }

        public void PrintJobCard(string jobNo)
        {
            crdReportDocument.Load(Application.StartupPath + "\\rpt_JobDetails.rpt");
            crdReportDocument.Refresh();
            ApplyBrand(crdReportDocument);
            ApplyInfo(crdReportDocument);
            crdReportDocument.SetParameterValue("VNO", jobNo);
            crdReportDocument.SetParameterValue("SEQ", jobNo);
            if (crdReportDocument.Rows.Count > 0)
            {
                crdReportDocument.PrintToPrinter(1, false, 0, 0);
            }
            else
            {
                MessageBox.Show("No data for Selected Criteria");
            }
        }

        public void PrintInvoice(string jobNo)
        {
            ReportDocument invoice = new ReportDocument();
            try
            {
                invoice.Load(Application.StartupPath + "\\rpt_Invoice.rpt");
                invoice.Refresh();
                ApplyBrand(invoice);
                ApplyInfo(invoice);
                invoice.SetParameterValue("VNO", jobNo);
                if (invoice.Rows.Count > 0)
                {
                    invoice.PrintToPrinter(1, false, 0, 0);
                }
                else
                {
                    MessageBox.Show("No data for Selected Criteria");
                }
            }
            finally
            {
                invoice.Close();
                invoice.Dispose();
            }
        }

        public void GetReportCriteriaB(string strReportName, string strCriteria, int intYEAR, int intMONTH)
        {
            crystalReportViewer1.Refresh();

            crdReportDocument.Load(Application.StartupPath + "\\" + strReportName + ".rpt");
            crdReportDocument.Refresh();

            CommonProfiles objComPro = new CommonProfiles();
            frm_ReportCriteria_Inventory objRepCriteria = new frm_ReportCriteria_Inventory();
            frm_ReceiveMode objRepCriteria1 = new frm_ReceiveMode();

            ApplyInfo(crdReportDocument);

            bool ParExist = true;

            switch (strReportName)
            {
                case "rpt_PettyCash":
                    crdReportDocument.SetParameterValue("YEAR", intYEAR);
                    crdReportDocument.SetParameterValue("MONTH", intMONTH);
                    //crdReportDocument.SetParameterValue("VNO(JOB_DESC)", strVNO);
                    //crdReportDocument.SetParameterValue("VNO(ISSUES)", strVNO);
                    ParExist = false;
                    break;
                case "rpt_Expences_Earnings":
                    crdReportDocument.SetParameterValue("YEAR", intYEAR);
                    crdReportDocument.SetParameterValue("MONTH", intMONTH);
                    crdReportDocument.SetParameterValue("YEAR1", intYEAR);
                    crdReportDocument.SetParameterValue("MONTH1", intMONTH);
                    crdReportDocument.SetParameterValue("YEAR2", intYEAR);
                    crdReportDocument.SetParameterValue("MONTH2", intMONTH);
                    //crdReportDocument.SetParameterValue("VNO(JOB_DESC)", strVNO);
                    //crdReportDocument.SetParameterValue("VNO(ISSUES)", strVNO);
                    ParExist = false;
                    break;


            }

            if (ParExist == true)
            {
                //crdReportDocument.SetParameterValue("Month", strDate);
            }

            if (crdReportDocument.Rows.Count > 0)
            {
                crystalReportViewer1.Refresh();
                crystalReportViewer1.ReportSource = crdReportDocument;

            }
            else
            {
                MessageBox.Show("No data for Selected Criteria");
            }
            // Used to Add back educted previous month EPF amount from Data Base
            //      if (strReportName == "EPF_Monthly_Report")// Added on 13-Apr-2011 - to Pause print ETF and brought forward to next month
            //      {
            //          objRepCriteria.HandleETFReport("Ded", intYear, objComPro.GetMonthConverted(strMonth));
            //      }
        }

        private static string GetCurrentCashier()
        {
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                SqlConnection conn = obyConn.Connect();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT C_USER FROM [CURRENT_USER]", conn);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            catch
            {
            }
            return "";
        }

        public void ApplyInfo(CrystalDecisions.CrystalReports.Engine.ReportDocument _oRpt)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            CrystalDecisions.CrystalReports.Engine.Database oCRDb = _oRpt.Database;

            CrystalDecisions.CrystalReports.Engine.Tables oCRTables = oCRDb.Tables;

            //CrystalDecisions.CrystalReports.Engine.Table oCRTable;

            CrystalDecisions.Shared.TableLogOnInfo oCRTableLogonInfo;

            CrystalDecisions.Shared.ConnectionInfo oCRConnectionInfo = new CrystalDecisions.Shared.ConnectionInfo();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(_conn.ConnectionString);

            oCRConnectionInfo.DatabaseName = builder.InitialCatalog;
            oCRConnectionInfo.ServerName = builder.DataSource;
            oCRConnectionInfo.UserID = builder.UserID;
            oCRConnectionInfo.Password = builder.Password;
            oCRConnectionInfo.IntegratedSecurity = false;

            foreach (CrystalDecisions.CrystalReports.Engine.Table oCRTabl in oCRTables)
            {

                oCRTableLogonInfo = oCRTabl.LogOnInfo;

                oCRTableLogonInfo.ConnectionInfo = oCRConnectionInfo;

                oCRTabl.ApplyLogOnInfo(oCRTableLogonInfo);

            }
            foreach (CrystalDecisions.CrystalReports.Engine.ReportDocument subReport in _oRpt.Subreports)
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table subTable in subReport.Database.Tables)
                {
                    oCRTableLogonInfo = subTable.LogOnInfo;
                    oCRTableLogonInfo.ConnectionInfo = oCRConnectionInfo;
                    subTable.ApplyLogOnInfo(oCRTableLogonInfo);
                }
            }
            _conn.Close();
        }

        //internal static void GetReportCriteria(string strReportName, string strCriteria, int strINVNO)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        internal static void GetReportCriteria(string strReportName, string strCriteria, int strVNO, string strNAME)
        {
            UnsupportedReport("GetReportCriteria");
        }

        internal static void GetReportCriteriaA(string strReportName, string strCriteria, int strVNO)
        {
            UnsupportedReport("GetReportCriteriaA");
        }

        internal static void GetReportCriteriaB(string strReportName, string strCriteria, int strVNO)
        {
            UnsupportedReport("GetReportCriteriaB");
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Reports_Load(object sender, EventArgs e)
        {
            LocID = int.Parse(frm_ReceiveMode.LocID.ToString());
        }

        //internal static void PrintToPrinter(int p, bool p_2, int p_3, int p_4)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        internal static void GetReportCriteria(string strReportName, string strCriteria, int p, string p_4, string p_5, string p_6, string strEPFETF, string strTitle)
        {
            UnsupportedReport("GetReportCriteria");
        }

        internal static void GetReportCriteriaA(string strReportName, string strCriteria)
        {
            UnsupportedReport("GetReportCriteriaA");
        }


        internal static void GetReportCriteriaA(string strReportName, string strCriteria, DateTime dateTime, DateTime dateTime_4, string p, string p_6)
        {
            UnsupportedReport("GetReportCriteriaA");
        }

        private static void UnsupportedReport(string methodName)
        {
            InvalidOperationException ex = new InvalidOperationException(methodName + " is not used by invoice printing. Open the report from the job card or report viewer.");
            AppLog.Write("frm_Reports", ex);
            MessageBox.Show(ex.Message, "Report");
        }
    }
}