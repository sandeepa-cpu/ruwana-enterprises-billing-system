using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Reflection;

namespace Billing_Inventory_Management_System
{
    public partial class frm_ReportCriteria_Payroll : Form
    {
        private SqlConnection _conn;
        private SqlConnection _conn1;
        private string strReportName = "";
        private string strTitle = "Aqua Power Supporting Services (Pvt) Limited";
        private string strCriteria = "";
        string strEPFETF = "";

        decimal intUnit = 0;
        decimal dNoUnits = 0;
        decimal totVal = 0;
        string strSQL = null;
        string strEmp;
        string strCatID;
        string TENNO;
        decimal TOT_VAL = 0;
        decimal TOT_VALS = 0;
        decimal TOT_EPF = 0;
        decimal TOT_EPFS = 0;
        decimal TOT_ETF = 0;
        decimal TOT_ETFS = 0;

        bool bolNewEmp = true;
        DataRow dr = null;

        frmEPFParameters frmEPFPara = new frmEPFParameters();
        frm_PaySlipBankWiseBOC frmPayBankBOC = new frm_PaySlipBankWiseBOC();
        frm_PaySlipBankWiseAll frmPayBankAll = new frm_PaySlipBankWiseAll();
        frm_PaySlipBankWiseCOMM frmPayBankCOMM = new frm_PaySlipBankWiseCOMM();
        frm_PaySlipBankWiseOthers frmPayBankOthers = new frm_PaySlipBankWiseOthers();
        frm_COMMFormat frmCOMMFormat = new frm_COMMFormat();
        frm_HNBFormat frmHNBFormat = new frm_HNBFormat(); 

        public frm_ReportCriteria_Payroll ()
        {
            InitializeComponent();
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            frm_Reports frm_Reports = new frm_Reports();
            CommonProfiles objComPro = new CommonProfiles();
                        
            if (cmbYear.Text == "" || cmbMonth.Text == "")
            {
                MessageBox.Show("Please Select Year and Month to proceed", "Criteria");
                return;
            }
            else
            {
                if (strReportName == "rptSalarySheet")
                {
                    CreateSalSheetDataSetHeader(txtTenNo.Text, int.Parse(cmbYear.Text.ToString()), cmbMonth.Text);
                    CreateSalSheetDataSetDetail(txtTenNo.Text, int.Parse(cmbYear.Text.ToString()), cmbMonth.Text);
                }
                else if (strReportName == "EPF_ETF_Contribution")
                {
                    int intMonth_Start = objComPro.GetMonthConverted(cmbMonth.Text);
                    int intMonth_End = objComPro.GetMonthConverted(cmbEndMonth.Text);

                    if ((intMonth_End - intMonth_Start) != 5)
                    {
                        MessageBox.Show("Please Select the Period of Six Months", "EPF_ETF Six Months", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    CreateSixMonth(intMonth_Start,intMonth_End);
                }
                else if (strReportName == "EPF_Monthly_Report" || strReportName == "ETF_Monthly_Report")
                {
                    txtTenNo.Text = txtCheNo.Text;
                    strEPFETF = txtBankBranch.Text;

                    if (strReportName == "EPF_Monthly_Report")// Added on 13-Apr-2011 - to Pause print ETF and brought forward to next month
                    {
                        HandleETFReport("Add", int.Parse(cmbYear.Text.ToString()), objComPro.GetMonthConverted(cmbMonth.Text));
                    }
                }

                frm_Reports.GetReportCriteria(strReportName, strCriteria, int.Parse(cmbYear.Text.ToString()), cmbMonth.Text, cmbEndMonth.Text, txtTenNo.Text, strEPFETF, strTitle);
                frm_Reports.Show();
                
            }
        }

        public void HandleETFReport(string ETFCalcMethod, int intCalcYear, int intCalcMonth)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            System.Data.DataTable tblEPFCalc = new System.Data.DataTable();
            SqlCommand cmdEPFCalc = new SqlCommand("SELECT * FROM PAY_SLIPS_EARNINGS WHERE EPF_CALC='A'", _conn);
            SqlDataAdapter daEPFCalc = new SqlDataAdapter();

            daEPFCalc.SelectCommand = cmdEPFCalc;
            daEPFCalc.Fill(tblEPFCalc);

            if (tblEPFCalc.Rows.Count < 1)
            {
                return;
            }
            else
            {
                SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM PAY_SLIPS_EARNINGS WHERE EAR_ID='TOT_EPF' AND PAY_YEAR='" + intCalcYear + "' AND PAY_MONTH='" + intCalcMonth + "'", _conn);
                SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
                DataSet thisDataset = new DataSet();

                thisAdapter.Fill(thisDataset, "PAY_SLIPS_EARNINGS");

                DataColumn[] MyKey = new DataColumn[1];

                MyKey[0] = thisDataset.Tables["PAY_SLIPS_EARNINGS"].Columns["EMP_NO"];
                thisDataset.Tables[0].PrimaryKey = MyKey;

                foreach (DataRow dr in tblEPFCalc.Rows)
                {
                    DataRow FindMyRow = thisDataset.Tables[0].Rows.Find(dr["EMP_NO"].ToString());

                    if (FindMyRow != null)
                    {
                        if (ETFCalcMethod == "Add")
                            FindMyRow["PAY_VALUE"] = double.Parse(FindMyRow["PAY_VALUE"].ToString()) + double.Parse(dr["PAY_VALUE"].ToString());
                        else
                            FindMyRow["PAY_VALUE"] = double.Parse(FindMyRow["PAY_VALUE"].ToString()) - double.Parse(dr["PAY_VALUE"].ToString());
                        
                        //MessageBox.Show(FindMyRow["EMP_NO"].ToString());
                        /*thisDataset.Tables["SUB_LOCATION"].Rows[count]["DESCRIPTION"] = Grid_A.Rows[count].Cells[1].Value.ToString();*/
                        thisAdapter.Update(thisDataset, "PAY_SLIPS_EARNINGS");
                    }
                }

                thisAdapter.Dispose();
                thisBuilder.Dispose();
                thisDataset.Dispose();
            }
            tblEPFCalc.Dispose();
            cmdEPFCalc.Dispose();
            daEPFCalc.Dispose();

            _conn.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void trvReports_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strCriteria = e.Node.Text;

            this.Text = "Report Criteria for " + strCriteria;

            switch (e.Node.Name)
            {
                case "chnPaySlip":
                    btnComBank.Visible = false;
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    strReportName = "rptPaySlip";
                    grbCriteria.Enabled = true;
                    dt_Date.Enabled = false;
                    break;
                case "chnBankLetters":
                    btnComBank.Visible = false;
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    dt_Date.Enabled = false;
                    strReportName = "Bank";
                    break;
                case "chnBankSelection":
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    //strReportName = "EPF_Monthly_Microsoft.Office.Interop.Excel";                    
                    this.Hide();
                    frmPayBankBOC.ShowDialog();
                    
                    frm_ReportCriteria_Payroll  frm_Rpt5 = new frm_ReportCriteria_Payroll ();
                    frm_Rpt5.Show();
                    break;
                case "chnBankSelection1":
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    //strReportName = "EPF_Monthly_Microsoft.Office.Interop.Excel";                    
                    this.Hide();
                    frmPayBankCOMM.ShowDialog();
                    
                    frm_ReportCriteria_Payroll  frm_Rpt4 = new frm_ReportCriteria_Payroll ();
                    frm_Rpt4.Show();
                    break;
                case "chnBankSelection2":
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    //strReportName = "EPF_Monthly_Microsoft.Office.Interop.Excel";                    
                    this.Hide();
                    frmPayBankOthers.ShowDialog();
                    
                    frm_ReportCriteria_Payroll  frm_Rpt3 = new frm_ReportCriteria_Payroll ();
                    frm_Rpt3.Show();
                    break;
                case "chnAll":
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    //strReportName = "EPF_Monthly_Microsoft.Office.Interop.Excel";                    
                    this.Hide();
                    frmPayBankAll.ShowDialog();

                    frm_ReportCriteria_Payroll  frm_Rpt2 = new frm_ReportCriteria_Payroll ();
                    frm_Rpt2.Show();
                    break;
                case "chnCOMMFormat":
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    //strReportName = "EPF_Monthly_Microsoft.Office.Interop.Excel";                    
                    this.Hide();
                    frmCOMMFormat.ShowDialog();
                    
                    frm_ReportCriteria_Payroll  frm_Rpt1 = new frm_ReportCriteria_Payroll ();
                    frm_Rpt1.Show();
                    break;
                case "chnHNBFormat":
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    //strReportName = "EPF_Monthly_Microsoft.Office.Interop.Excel";                    
                    this.Hide();
                    frmHNBFormat.ShowDialog();
                    
                    frm_ReportCriteria_Payroll  frm_Rpt = new frm_ReportCriteria_Payroll ();
                    frm_Rpt.Show();
                    break;     
                case "chnSalAdvance":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = false;
                    strReportName = "rptSalaryAdvance";
                    break;
                case "chnFesAdvance":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = true;
                    strReportName = "rptFestivalAdvance";
                    break;
                case "chnNoPay":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = false;
                    strReportName = "rptNoPay";
                    break;
                case "chnPenalty":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = false;
                    strReportName = "rptPenalty";
                    break;
                case "chnNetSal":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = false;
                    strReportName = "NetSalaryReport";
                    break;
                case "chnWelfair":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = false;
                    strReportName = "rptWelfair";
                    break;
                case "chnLoanPay":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = false;
                    strReportName = "rptLoanPayments";
                    break;
                case "chnEPF":
                    break;
                case "chnEPF6":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = false;
                    strReportName = "EPF_ETF_Contribution";
                    strEPFETF = "EPF";
                    break;
                case "chnEPFMonthly":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = false;
                    strReportName = "EPF_Monthly_Report";                    
                    break;
                case "chnEPFMonthlyExcel":
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    //strReportName = "EPF_Monthly_Microsoft.Office.Interop.Excel";                    
                    frmEPFPara.strExcel = "ExcelEPFTotal";
                    this.Hide();
                    frmEPFPara.ShowDialog();
                    frm_ReportCriteria_Payroll  frm_Rpt6 = new frm_ReportCriteria_Payroll ();
                    frm_Rpt6.Show();
                    break;
                case "chnEPFMonthlyIndividualExcel":
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    //strReportName = "EPF_Monthly_Microsoft.Office.Interop.Excel";
                    //frmEPFParameters frmEPFPara = new frmEPFParameters();
                    frmEPFPara.strExcel = "MonthlyIndividualExcelEPF";
                    this.Hide();
                    frmEPFPara.ShowDialog();
                    frm_ReportCriteria_Payroll  frm_Rpt7 = new frm_ReportCriteria_Payroll ();
                    frm_Rpt7.Show();
                    break;                              
                case "chnETF6":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = false;
                    strReportName = "EPF_ETF_Contribution";
                    strEPFETF = "ETF";
                    break;
                case "chnETFMonthly":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = false;
                    strReportName = "ETF_Monthly_Report";
                    break;                
                case "chnComBank":
                    dt_Date.Enabled = true;
                    cmbTender.Enabled = false;                    
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    strReportName = "ComBankExel";
                    break;
                case "chnSampathBank":
                    dt_Date.Enabled = true;
                    cmbTender.Enabled = false;                    
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    strReportName = "SampathBankExel";
                    break;
                case "chnBOC":
                    dt_Date.Enabled = true;
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    strReportName = "BOCExel";
                    break;
                case "chnPeoplesBank":
                    dt_Date.Enabled = true;
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    strReportName = "PeoBankExel";
                    break;     
                case "chnPaySheets":
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    btnComBank.Visible = false;
                    dt_Date.Enabled = false;
                    grbCriteria.Enabled = true;
                    strReportName = "rptSalarySheet";
                    break;
                case "chnTenderCost":
                    dt_Date.Enabled = true;
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    strReportName = "TenderCostDis";
                    break;
                case "chnOtherBanks":
                    dt_Date.Enabled = true;
                    cmbTender.Enabled = false;
                    btnSubmit.Visible = false;
                    btnComBank.Visible = true;
                    strReportName = "OtherBankExel";
                    break;      
            }

            if ((e.Node.Name == "chnEPF6") || (e.Node.Name == "chnETF6"))
                panel2.Visible = true;
            else
                panel2.Visible = false;
        }

        public void CommercialBank(string strComString)
        {
            //*********************************** Upload *************************************

            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            //int iNumQtrs;
            int AAA = 6; //Columns
            int BBB = 0; //Rows
            int CCC = 0;
            int AutoNo = 0;
            //int DDD = 0;

            try
            {
                //START Microsoft.Office.Interop.Excel
                oXL = new Microsoft.Office.Interop.Excel.Application();
                //oXL.Visible = true;

                //NEW WORKBOOK
                //oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                //oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                string File_Path;
                File_Path = (Environment.CurrentDirectory) + "\\" + "PayMaster Sample File Format-2.xlsm";

                //OPEN WORKBOOK
                oWB = oXL.Workbooks.Open(File_Path, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, true, Missing.Value);
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //FONT NAME & SIZE
                oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
                oSheet.get_Range("A6", "Z10000").Font.Size = 8;

                //BACKGROUNG
                oSheet = (Worksheet)oWB.Worksheets.get_Item(1);
                oSheet.Name = "com_upload ";

                //HEADERS
        /*        oSheet.Cells[5, 1] = "Tran ID (04)";
                oSheet.Cells[5, 2] = "Destination Bank (04)";
                oSheet.Cells[5, 3] = "Destination Br (03)";
                oSheet.Cells[5, 4] = "Destination  Account (12)";
                oSheet.Cells[5, 5] = "Destination Account Name (20)";
                oSheet.Cells[5, 6] = "TRN Code (02)";
                oSheet.Cells[5, 7] = "Return Code (02)";
                oSheet.Cells[5, 8] = "Cr/ Dr Code (01)";
                oSheet.Cells[5, 9] = "Return Date (06)";
                oSheet.Cells[5, 10] = "Amount (12)";
                oSheet.Cells[5, 11] = "Currency Code (03)";
                oSheet.Cells[5, 12] = "Originating Bank (04)";
                oSheet.Cells[5, 13] = "Originating Barnch (03)";
                oSheet.Cells[5, 14] = "Originating Account (12)";
                oSheet.Cells[5, 15] = "Originating Account Name (20)";
                oSheet.Cells[5, 16] = "Purticulars (15)";
                oSheet.Cells[5, 17] = "";
                oSheet.Cells[5, 18] = "Value Date (YYMMDD)(06)";
                oSheet.Cells[5, 19] = "Security Field (06)";
                oSheet.Cells[5, 20] = "Filler (01)"; 

                //SET ORIENTATION
                oSheet.get_Range("A5", "W5").Orientation = 90;

                //SET WRAP TEXT
                oSheet.get_Range("A5", "W5").WrapText = true;

                //CENTER TEXT
                oSheet.get_Range("A5", "W5").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A5", "W5").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                //COLUMN WIDTH
                oSheet.get_Range("A1", "A1").ColumnWidth = 4;
                oSheet.get_Range("B1", "B1").ColumnWidth = 4;
                oSheet.get_Range("C1", "C1").ColumnWidth = 3;
                oSheet.get_Range("D1", "D1").ColumnWidth = 12;
                oSheet.get_Range("E1", "E1").ColumnWidth = 23;
                oSheet.get_Range("F1", "F1").ColumnWidth = 2;
                oSheet.get_Range("G1", "G1").ColumnWidth = 2;
                oSheet.get_Range("H1", "H1").ColumnWidth = 1;
                oSheet.get_Range("I1", "I1").ColumnWidth = 6;
                oSheet.get_Range("J1", "J1").ColumnWidth = 12;
                oSheet.get_Range("K1", "K1").ColumnWidth = 3;
                oSheet.get_Range("L1", "L1").ColumnWidth = 4;
                oSheet.get_Range("M1", "M1").ColumnWidth = 3;
                oSheet.get_Range("N1", "N1").ColumnWidth = 12;
                oSheet.get_Range("O1", "O1").ColumnWidth = 20;
                oSheet.get_Range("P1", "P1").ColumnWidth = 15;
                oSheet.get_Range("Q1", "Q1").ColumnWidth = 15;
                oSheet.get_Range("R1", "R1").ColumnWidth = 6;
                oSheet.get_Range("S1", "S1").ColumnWidth = 6;
                oSheet.get_Range("T1", "T1").ColumnWidth = 3;

                //ROW HIGHT
                oSheet.get_Range("A5", "A5").RowHeight = 80;
                oSheet.get_Range("A6", "W10000").RowHeight = 20;

                //BOLD AND ALIGNMENT
                oSheet.get_Range("A5", "W5").Font.Bold = true;
                oSheet.get_Range("A1", "W1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;*/

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;

               // cmdsql.CommandText = "SELECT *, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')AND (EAR_ID = 'NETSAL') AND (BANK_CODE = '7056') ORDER BY(CONVERT(INT,EMP_NO))";
                cmdsql.CommandText = strComString;
                SqlDataReader dreader = cmdsql.ExecuteReader();

                while (dreader.Read())
                {
                    //oSheet.Cells[AAA + BBB, 1] = dreader["EMP_NO"].ToString();
                    //oSheet.Cells[AAA + BBB, 2] = dreader["BANK_CODE"].ToString();
                    //oSheet.Cells[AAA + BBB, 3] = dreader["SORT_BRANCH"].ToString();
                    //oSheet.Cells[AAA + BBB, 4] = dreader["ACC_NO"].ToString();
                    //oSheet.Cells[AAA + BBB, 5] = dreader["EMP_NAME"].ToString();
                    //oSheet.Cells[AAA + BBB, 6] = "23";
                    //oSheet.Cells[AAA + BBB, 7] = "00";
                    //oSheet.Cells[AAA + BBB, 8] = "0";
                    //oSheet.Cells[AAA + BBB, 9] = "000000";
                    //oSheet.Cells[AAA + BBB, 10] = dreader["PAY_VALUE"].ToString();
                    //oSheet.Cells[AAA + BBB, 11] = "SLR";
                    //oSheet.Cells[AAA + BBB, 12] = dreader["BANK_CODE"].ToString();
                    //oSheet.Cells[AAA + BBB, 13] = dreader["SORT_BRANCH"].ToString();
                    //oSheet.Cells[AAA + BBB, 14] = "001109010050";
                    //oSheet.Cells[AAA + BBB, 15] = "Aqua Power Services";
                    //AutoNo = AutoNo + 1;
                    //oSheet.Cells[AAA + BBB, 16] = AutoNo.ToString();
                    //oSheet.Cells[AAA + BBB, 17] = "Salary " + dreader["SAL_MONTH"].ToString();
                    //oSheet.Cells[AAA + BBB, 18] = dt_Date.Text.ToString();
                    //oSheet.Cells[AAA + BBB, 19] = "";
                    //oSheet.Cells[AAA + BBB, 20] = "@";

                    oSheet.Cells[AAA + BBB, 1] = "0000";
                    oSheet.Cells[AAA + BBB, 2] = dreader["BANK_CODE"].ToString();
                    oSheet.Cells[AAA + BBB, 3] = dreader["SORT_BRANCH"].ToString(); //"109";
                    oSheet.Cells[AAA + BBB, 4] = dreader["ACC_NO"].ToString();
                    oSheet.Cells[AAA + BBB, 5] = dreader["NAME_BANK"].ToString().Replace(".", " ");
                    oSheet.Cells[AAA + BBB, 6] = "23";
                    oSheet.Cells[AAA + BBB, 7] = "00";
                    oSheet.Cells[AAA + BBB, 8] = "0";
                    oSheet.Cells[AAA + BBB, 9] = "000000";
                    oSheet.Cells[AAA + BBB, 10] = dreader["PAY_VALUE"].ToString().Replace(".", "");
                    oSheet.Cells[AAA + BBB, 11] = "SLR";
                    oSheet.Cells[AAA + BBB, 12] = "7056";
                    oSheet.Cells[AAA + BBB, 13] = "109";
                    oSheet.Cells[AAA + BBB, 14] = "001109010050";
                    oSheet.Cells[AAA + BBB, 15] = "Aqua Power Services";
                    AutoNo = AutoNo + 1;
                    oSheet.Cells[AAA + BBB, 16] = AutoNo.ToString();
                    oSheet.Cells[AAA + BBB, 17] = "Salary " + dreader["SAL_MONTH"].ToString();
                    oSheet.Cells[AAA + BBB, 18] = DateTime.Today.ToString("yyMMdd"); //dt_Date.Text.ToString();
                    oSheet.Cells[AAA + BBB, 19] = "";
                    oSheet.Cells[AAA + BBB, 20] = "@";

                    AAA = AAA + 1;

                    BBB = 0;
                }

                //NUMBER FORMAT
                //oSheet.get_Range("A6", "A10000").NumberFormat = "0000";
                //oSheet.get_Range("B6", "B10000").NumberFormat = "0000";
                //oSheet.get_Range("C6", "C10000").NumberFormat = "109";
                oSheet.get_Range("D6", "D10000").NumberFormat = "000000000000";
                //oSheet.get_Range("F6", "F10000").NumberFormat = "00";
                //oSheet.get_Range("G6", "G10000").NumberFormat = "00";
                //oSheet.get_Range("H6", "H10000").NumberFormat = "0";
                //oSheet.get_Range("I6", "I10000").NumberFormat = "000000";
                oSheet.get_Range("J6", "J10000").NumberFormat = "000000000000";
                //oSheet.get_Range("L6", "L10000").NumberFormat = "7056";
                oSheet.get_Range("N6", "N10000").NumberFormat = "000000000000";
                //oSheet.get_Range("R6", "R10000").NumberFormat = "yymmdd";

                //APPLY BOARDS
                oRng = oSheet.get_Range("A5", "W5").get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                oRng = oSheet.get_Range("A6", "W" + AAA).get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline;

                oXL.Visible = true;
                oXL.UserControl = true;
                dreader.Close();




                //**************************************** Bank & Branches **********************************

                ////////////FONT NAME & SIZE
                //////////oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
                //////////oSheet.get_Range("A5", "Z10000").Font.Size = 8;

                ////////////BACKGROUNG
                //////////oSheet = (Worksheet)oWB.Worksheets.get_Item(2);
                //////////oSheet.Name = "Branch_code";

                ////////////COLUMN WIDTH
                //////////oSheet.get_Range("A1", "A1").ColumnWidth = 10;
                //////////oSheet.get_Range("B1", "B1").ColumnWidth = 10;
                //////////oSheet.get_Range("C1", "C1").ColumnWidth = 20;
                //////////oSheet.get_Range("E1", "E1").ColumnWidth = 10;
                //////////oSheet.get_Range("F1", "F1").ColumnWidth = 30;

                ////////////ROW HIGHT
                //////////oSheet.get_Range("A5", "W10000").RowHeight = 20;

                ////////////BOLD AND ALIGNMENT
                ////////////oSheet.get_Range("A5", "W5").Font.Bold = true;
                //////////oSheet.get_Range("A1", "W1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;

                //////////SqlCommand cmdsql1 = new SqlCommand();
                //////////cmdsql1.Connection = _conn;
                //////////cmdsql1.CommandText = "SELECT BANK, BANK_CODE, BRANCH, BRANCH_CODE, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (BANK_CODE = '7056') ORDER BY BANK";
                //////////SqlDataReader dreader1 = cmdsql1.ExecuteReader();

                //////////AAA = 5;
                //////////while (dreader1.Read())
                //////////{

                //////////    oSheet.Cells[AAA + BBB, 1] = dreader1["BANK_CODE"].ToString();
                //////////    oSheet.Cells[AAA + BBB, 2] = dreader1["BRANCH_CODE"].ToString();
                //////////    oSheet.Cells[AAA + BBB, 3] = dreader1["BRANCH"].ToString();

                //////////    AAA = AAA + 1;

                //////////    BBB = 0;
                //////////}

                //////////dreader1.Close();

                //////////SqlCommand cmdsql2 = new SqlCommand();
                //////////cmdsql2.Connection = _conn;
                //////////cmdsql2.CommandText = "SELECT BANK, BANK_CODE, BRANCH, BRANCH_CODE, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE(BANK_CODE <> '7056')";
                //////////SqlDataReader dreader2 = cmdsql2.ExecuteReader();

                //////////CCC = 5;
                //////////while (dreader2.Read())
                //////////{

                //////////    oSheet.Cells[CCC + BBB, 5] = dreader2["BANK_CODE"].ToString();
                //////////    oSheet.Cells[CCC + BBB, 6] = dreader2["BRANCH_CODE"].ToString() + " / "  + dreader2["BRANCH"].ToString();

                //////////    CCC = CCC + 1;

                //////////    BBB = 0;
                //////////}

                //////////dreader2.Close();

                //////////oXL.Visible = true;
                //////////oXL.UserControl = true;
                if(strReportName == "ComBankExel")
                    MessageBox.Show("Commercial Bank Report Successfully Generated", "Report Generation");
                else
                    MessageBox.Show("Other Banks Report Successfully Generated", "Report Generation");
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }

            _conn.Close();
        }

        private void SampathBank()
        {
            //*********************************** Upload *************************************

            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            int AAA = 2; //Columns
            int BBB = 1; //Rows
         
            try
            {
                //START Microsoft.Office.Interop.Excel
                oXL = new Microsoft.Office.Interop.Excel.Application();

                string File_Path;
                File_Path = (Environment.CurrentDirectory) + "\\" + "rptSampathBank.xls";

                //OPEN WORKBOOK
                oWB = oXL.Workbooks.Open(File_Path, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, true, Missing.Value);
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //FONT NAME & SIZE
                oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
                oSheet.get_Range("A6", "Z10000").Font.Size = 8;

                //BACKGROUNG
                oSheet = (Worksheet)oWB.Worksheets.get_Item(1);
                oSheet.Name = "Sampath_upload ";
                                
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;

                cmdsql.CommandText = "SELECT *, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')AND (EAR_ID = 'NETSAL') AND (BANK_CODE = '7278') ORDER BY(CONVERT(INT,EMP_NO))";
                SqlDataReader dreader = cmdsql.ExecuteReader();

                while (dreader.Read())
                {
                  //  MessageBox.Show(dreader["NAME_BANK"].ToString());

                    oSheet.Cells[AAA, 2] = dreader["NAME_BANK"].ToString().Replace(".", " ");
                    oSheet.Cells[AAA, 3] = dreader["ACC_NO"].ToString();
                    oSheet.Cells[AAA, 4] = dreader["PAY_VALUE"].ToString();
                    
                    AAA = AAA + 1;

                   // BBB = 0;
                }               

                //APPLY BOARDS
            /*    oRng = oSheet.get_Range("A1", "W5").get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                oRng = oSheet.get_Range("A3", "W" + AAA).get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline;
             * */

                oXL.Visible = true;
                oXL.UserControl = true;
                dreader.Close();
                                
                MessageBox.Show("Sampath Bank Report Successfully Generated", "Report Generation");
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }

        public void AllExel(string strALLSQL)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            //int iNumQtrs;
            int AAA = 6; //Columns
            int BBB = 0; //Rows
            int CCC = 0;
            int AutoNo = 0;
            //int DDD = 0;

            try
            {
                //START Microsoft.Office.Interop.Excel
                oXL = new Microsoft.Office.Interop.Excel.Application();

                string File_Path;
                File_Path = (Environment.CurrentDirectory) + "\\" + "BOC Sal Format.xlsm";

                //OPEN WORKBOOK
                oWB = oXL.Workbooks.Open(File_Path, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, true, Missing.Value);
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //FONT NAME & SIZE
                oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
                oSheet.get_Range("A6", "Z10000").Font.Size = 8;

                //BACKGROUNG
                oSheet = (Worksheet)oWB.Worksheets.get_Item(1);
                oSheet.Name = "All_upload ";

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;

                //cmdsql.CommandText = "SELECT *, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')AND (EAR_ID = 'NETSAL') AND (BANK_CODE = '7010') ORDER BY(CONVERT(INT,EMP_NO))";
                cmdsql.CommandText = strALLSQL;
                SqlDataReader dreader = cmdsql.ExecuteReader();

                while (dreader.Read())
                {                  

                    oSheet.Cells[AAA + BBB, 1] = "0000";
                    oSheet.Cells[AAA + BBB, 2] = dreader["BANK_CODE"].ToString();
                    oSheet.Cells[AAA + BBB, 3] = dreader["SORT_BRANCH"].ToString();
                    oSheet.Cells[AAA + BBB, 4] = dreader["ACC_NO"].ToString();
                    oSheet.Cells[AAA + BBB, 5] = dreader["NAME_BANK"].ToString().Replace(".", " ");
                    oSheet.Cells[AAA + BBB, 6] = "23";
                    oSheet.Cells[AAA + BBB, 7] = "00";
                    oSheet.Cells[AAA + BBB, 8] = "0";
                    oSheet.Cells[AAA + BBB, 9] = "000000";
                    oSheet.Cells[AAA + BBB, 10] = dreader["PAY_VALUE"].ToString().Replace(".", "");
                    oSheet.Cells[AAA + BBB, 11] = "SLR";
                    oSheet.Cells[AAA + BBB, 12] = "7010";
                    oSheet.Cells[AAA + BBB, 13] = "002";
                    oSheet.Cells[AAA + BBB, 14] = "000007079850";
                    oSheet.Cells[AAA + BBB, 15] = "Aqua Power Services";
                    //AutoNo = AutoNo + 1;
                    oSheet.Cells[AAA + BBB, 16] = "              ";//AutoNo.ToString();
                    oSheet.Cells[AAA + BBB, 17] = "              "; //"Salary " + dreader["SAL_MONTH"].ToString();
                    oSheet.Cells[AAA + BBB, 18] = DateTime.Today.ToString("yyMMdd"); //dt_Date.Text.ToString();
                    oSheet.Cells[AAA + BBB, 19] = "000000";
                   // oSheet.Cells[AAA + BBB, 20] = "@";

                    AAA = AAA + 1;

                    BBB = 0;
                }

                //NUMBER FORMAT
                //oSheet.get_Range("A6", "A10000").NumberFormat = "0000";
                //oSheet.get_Range("B6", "B10000").NumberFormat = "0000";
                //oSheet.get_Range("C6", "C10000").NumberFormat = "109";
                oSheet.get_Range("D6", "D10000").NumberFormat = "000000000000";
                //oSheet.get_Range("F6", "F10000").NumberFormat = "00";
                //oSheet.get_Range("G6", "G10000").NumberFormat = "00";
                //oSheet.get_Range("H6", "H10000").NumberFormat = "0";
                //oSheet.get_Range("I6", "I10000").NumberFormat = "000000";
                oSheet.get_Range("J6", "J10000").NumberFormat = "000000000000";
                oSheet.get_Range("N6", "N10000").NumberFormat = "000000000000";
                oSheet.get_Range("S6", "S10000").NumberFormat = "000000";
                //oSheet.get_Range("R6", "R10000").NumberFormat = "yymmdd";

                //APPLY BOARDS
                oRng = oSheet.get_Range("A5", "W5").get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                oRng = oSheet.get_Range("A6", "W" + AAA).get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline;

                oXL.Visible = true;
                oXL.UserControl = true;
                dreader.Close();



                MessageBox.Show("BOC Report Successfully Generated", "Report Generation");
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
            _conn.Close();
        }

        public void BankofCeylonExel(string strBOCSQL)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            //int iNumQtrs;
            int AAA = 6; //Columns
            int BBB = 0; //Rows
            int CCC = 0;
            int AutoNo = 0;
            //int DDD = 0;

            try
            {
                //START Microsoft.Office.Interop.Excel
                oXL = new Microsoft.Office.Interop.Excel.Application();

                string File_Path;
                File_Path = (Environment.CurrentDirectory) + "\\" + "BOC Sal Format.xlsm";

                //OPEN WORKBOOK
                oWB = oXL.Workbooks.Open(File_Path, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, true, Missing.Value);
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //FONT NAME & SIZE
                oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
                oSheet.get_Range("A6", "Z10000").Font.Size = 8;

                //BACKGROUNG
                oSheet = (Worksheet)oWB.Worksheets.get_Item(1);
                oSheet.Name = "BOC_upload ";

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;

                //cmdsql.CommandText = "SELECT *, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')AND (EAR_ID = 'NETSAL') AND (BANK_CODE = '7010') ORDER BY(CONVERT(INT,EMP_NO))";
                cmdsql.CommandText = strBOCSQL;
                SqlDataReader dreader = cmdsql.ExecuteReader();

                while (dreader.Read())
                {

                    oSheet.Cells[AAA + BBB, 1] = "0000";
                    oSheet.Cells[AAA + BBB, 2] = dreader["BANK_CODE"].ToString();
                    oSheet.Cells[AAA + BBB, 3] = dreader["SORT_BRANCH"].ToString();
                    oSheet.Cells[AAA + BBB, 4] = dreader["ACC_NO"].ToString();
                    oSheet.Cells[AAA + BBB, 5] = dreader["NAME_BANK"].ToString().Replace(".", " ");
                    oSheet.Cells[AAA + BBB, 6] = "23";
                    oSheet.Cells[AAA + BBB, 7] = "00";
                    oSheet.Cells[AAA + BBB, 8] = "0";
                    oSheet.Cells[AAA + BBB, 9] = "000000";
                    oSheet.Cells[AAA + BBB, 10] = dreader["PAY_VALUE"].ToString().Replace(".", "");
                    oSheet.Cells[AAA + BBB, 11] = "SLR";
                    oSheet.Cells[AAA + BBB, 12] = "7010";
                    oSheet.Cells[AAA + BBB, 13] = "002";
                    oSheet.Cells[AAA + BBB, 14] = "000007079850";
                    oSheet.Cells[AAA + BBB, 15] = "Aqua Power Services";
                    //AutoNo = AutoNo + 1;
                    oSheet.Cells[AAA + BBB, 16] = "              ";//AutoNo.ToString();
                    oSheet.Cells[AAA + BBB, 17] = "              "; //"Salary " + dreader["SAL_MONTH"].ToString();
                    oSheet.Cells[AAA + BBB, 18] = DateTime.Today.ToString("yyMMdd"); //dt_Date.Text.ToString();
                    oSheet.Cells[AAA + BBB, 19] = "000000";
                    // oSheet.Cells[AAA + BBB, 20] = "@";

                    AAA = AAA + 1;

                    BBB = 0;
                }

                //NUMBER FORMAT
                //oSheet.get_Range("A6", "A10000").NumberFormat = "0000";
                //oSheet.get_Range("B6", "B10000").NumberFormat = "0000";
                //oSheet.get_Range("C6", "C10000").NumberFormat = "109";
                oSheet.get_Range("D6", "D10000").NumberFormat = "000000000000";
                //oSheet.get_Range("F6", "F10000").NumberFormat = "00";
                //oSheet.get_Range("G6", "G10000").NumberFormat = "00";
                //oSheet.get_Range("H6", "H10000").NumberFormat = "0";
                //oSheet.get_Range("I6", "I10000").NumberFormat = "000000";
                oSheet.get_Range("J6", "J10000").NumberFormat = "000000000000";
                oSheet.get_Range("N6", "N10000").NumberFormat = "000000000000";
                oSheet.get_Range("S6", "S10000").NumberFormat = "000000";
                //oSheet.get_Range("R6", "R10000").NumberFormat = "yymmdd";

                //APPLY BOARDS
                oRng = oSheet.get_Range("A5", "W5").get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                oRng = oSheet.get_Range("A6", "W" + AAA).get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline;

                oXL.Visible = true;
                oXL.UserControl = true;
                dreader.Close();



                MessageBox.Show("BOC Report Successfully Generated", "Report Generation");
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
            _conn.Close();
        }

        public void HNBExel(string strHNBFormatSQL)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            //int iNumQtrs;
            int XXX = 6;
            int AAA = 7; //Rows
            int BBB = 0; //Columns
            int CCC = 1;
            int DDD = 0;
            int AutoNo = 0;
            decimal TOTVAL = 0;
            //int DDD = 0;

            try
            {
                //START Microsoft.Office.Interop.Excel
                oXL = new Microsoft.Office.Interop.Excel.Application();

                string File_Path;
                File_Path = (Environment.CurrentDirectory) + "\\" + "HNB Format.xlsm";

                //OPEN WORKBOOK
                oWB = oXL.Workbooks.Open(File_Path, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, true, Missing.Value);
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //FONT NAME & SIZE
                oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
                oSheet.get_Range("A6", "Z10000").Font.Size = 8;

                //BACKGROUNG
                oSheet = (Worksheet)oWB.Worksheets.get_Item(1);
                oSheet.Name = "HNB Format";

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;

                //cmdsql.CommandText = "SELECT *, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')AND (EAR_ID = 'NETSAL') AND (BANK_CODE = '7010') ORDER BY(CONVERT(INT,EMP_NO))";
                cmdsql.CommandText = strHNBFormatSQL;
                SqlDataReader dreader = cmdsql.ExecuteReader();

                while (dreader.Read())
                {

                    oSheet.Cells[AAA + BBB, 1] = CCC;
                    oSheet.Cells[AAA + BBB, 2] = dreader["NAME_BANK"].ToString().Replace(".", " ");
                    oSheet.Cells[AAA + BBB, 3] = dreader["BANK_CODE"].ToString();
                    oSheet.Cells[AAA + BBB, 4] = dreader["SORT_BRANCH"].ToString();
                    oSheet.Cells[AAA + BBB, 5] = dreader["ACC_NO"].ToString();
                    oSheet.Cells[AAA + BBB, 6] = "023";
                    oSheet.Cells[AAA + BBB, 7] = dreader["PAY_VALUE"].ToString().Replace(".", "");
                    TOTVAL = TOTVAL + Convert.ToDecimal(dreader["PAY_VALUE"].ToString().Replace(".", ""));
                    oSheet.Cells[AAA + BBB, 8] = DateTime.Today.ToString("yyMMdd"); //dt_Date.Text.ToString();
                    oSheet.Cells[AAA + BBB, 9] = "Salary" + dt_Date.Value.ToString("yyyyMMM");//AutoNo.ToString();

                    //oSheet.Cells[AAA + BBB, 11] = "000000";
                    // oSheet.Cells[AAA + BBB, 20] = "@";

                    AAA = AAA + 1;
                    CCC = CCC + 1;
                    DDD = DDD + 1;

                    BBB = 0;
                
                }

                //CCC = CCC + 2;
                //AAA = AAA + 2;
                
                 // Header Text

                if (TOTVAL >= 100000 & TOTVAL < 1000000)
                {
                    oSheet.Cells[XXX + BBB, 1] = "Aqua Power Services " + "00000" + TOTVAL.ToString().Replace(".", "") + "018010645692" + dt_Date.Value.ToString("yyMMdd") + "              " + DDD.ToString("00000") + "7083" + "018" + "223";
                }
                if (TOTVAL >= 1000000 & TOTVAL < 10000000)
                {
                    oSheet.Cells[XXX + BBB, 1] = "Aqua Power Services " + "0000" + TOTVAL.ToString().Replace(".", "") + "018010645692" + dt_Date.Value.ToString("yyMMdd") + "              " + DDD.ToString("00000") + "7083" + "018" + "223";
                }
                if (TOTVAL >= 10000000 & TOTVAL < 100000000)
                {
                    oSheet.Cells[XXX + BBB, 1] = "Aqua Power Services " + "000" + TOTVAL.ToString().Replace(".", "") + "018010645692" + dt_Date.Value.ToString("yyMMdd") + "              " + DDD.ToString("00000") + "7083" + "018" + "223";
                }
                if (TOTVAL >= 100000000 & TOTVAL < 1000000000)
                {
                    oSheet.Cells[XXX + BBB, 1] = "Aqua Power Services " + "00" + TOTVAL.ToString().Replace(".", "") + "018010645692" + dt_Date.Value.ToString("yyMMdd") + "              " + DDD.ToString("00000") + "7083" + "018" + "223";
                }
                if (TOTVAL >= 1000000000 & TOTVAL < 10000000000)
                {
                    oSheet.Cells[XXX + BBB, 1] = "Aqua Power Services " + "0" + TOTVAL.ToString().Replace(".", "") + "018010645692" + dt_Date.Value.ToString("yyMMdd") + "              " + DDD.ToString("00000") + "7083" + "018" + "223";
                }
                if (TOTVAL >= 10000000000 & TOTVAL <= 99999999999)
                {
                    oSheet.Cells[XXX + BBB, 1] = "Aqua Power Services " + TOTVAL.ToString().Replace(".", "") + "018010645692" + dt_Date.Value.ToString("yyMMdd") + "              " + DDD.ToString("00000") + "7083" + "018" + "223";
                }

                oSheet.get_Range("A1", "A1").ColumnWidth = 8;
                oSheet.get_Range("A6", "A6").WrapText = true;
                oSheet.get_Range("A6", "A6").Font.Name = "Script";
                oSheet.get_Range("A6", "A6").Font.Size = 1;
                ////NUMBER FORMAT
                //oSheet.get_Range("A6", "A6").NumberFormat = "                    ";
                //oSheet.get_Range("A6", "A6").NumberFormat = "00000000000";
                //oSheet.get_Range("C6", "C6").NumberFormat = "000000000000";
                //oSheet.get_Range("D6", "D6").NumberFormat = "ddMMyy";
                //oSheet.get_Range("E6", "E6").NumberFormat = "00000000000000";
                //oSheet.get_Range("F6", "F6").NumberFormat = "00000";
                //oSheet.get_Range("G6", "G6").NumberFormat = "0000";
                //oSheet.get_Range("H6", "H6").NumberFormat = "000";
                //oSheet.get_Range("I6", "I6").NumberFormat = "000";


                //NUMBER FORMAT
                oSheet.get_Range("A7", "A"+ AAA).NumberFormat = "00000000";
                oSheet.get_Range("C7", "C"+ AAA).NumberFormat = "0000";
                oSheet.get_Range("D7", "D"+ AAA).NumberFormat = "000";
                oSheet.get_Range("E7", "E"+ AAA).NumberFormat = "000000000000";
                oSheet.get_Range("F7", "F"+ AAA).NumberFormat = "000";
                oSheet.get_Range("G7", "G"+ AAA).NumberFormat = "00000000000";
                //oSheet.get_Range("H7", "H"+ AAA).NumberFormat = "yyMMdd";
                oSheet.get_Range("I7", "I"+ AAA).NumberFormat = "0000000000000";

                //CCC = CCC + 2;
                //AAA = AAA + 1;

                oSheet.Cells[AAA, 1] = "0";
                oSheet.get_Range("A" + AAA, "A" + AAA).NumberFormat = "00000000000000000000000000000000000000000000000000000000000000000000000000000000";
                //oSheet.get_Range("A" + AAA, "I" + AAA).MergeCells = true;
                //SET WRAP TEXT
                oSheet.get_Range("A" + AAA, "A" + AAA).WrapText = true;
                oSheet.get_Range("A" + AAA, "A" + AAA).Font.Name = "Script";
                oSheet.get_Range("A" + AAA, "A" + AAA).Font.Size = 1;
                //CENTER TEXT
                //oSheet.get_Range("A" + AAA, "A" + AAA).HorizontalAlignment = Microsoft.Office.Interop.Excel;
                //oSheet.get_Range("A6", "A10000").NumberFormat = "0000";
                //oSheet.get_Range("B6", "B10000").NumberFormat = "0000";
                //oSheet.get_Range("C6", "C10000").NumberFormat = "109";
                //oSheet.get_Range("D6", "D10000").NumberFormat = "000000000000";
                //oSheet.get_Range("F6", "F10000").NumberFormat = "00";
                //oSheet.get_Range("G6", "G10000").NumberFormat = "00";
                //oSheet.get_Range("H6", "H10000").NumberFormat = "0";
                //oSheet.get_Range("I6", "I10000").NumberFormat = "000000";
                //oSheet.get_Range("J6", "J10000").NumberFormat = "000000000000";
                //oSheet.get_Range("N6", "N10000").NumberFormat = "000000000000";
                //oSheet.get_Range("S6", "S10000").NumberFormat = "000000";
                //oSheet.get_Range("R6", "R10000").NumberFormat = "yymmdd";

                //APPLY BOARDS
                oRng = oSheet.get_Range("A5", "W5").get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                oRng = oSheet.get_Range("A6", "W" + AAA).get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline;

                oXL.Visible = true;
                oXL.UserControl = true;
                dreader.Close();



                MessageBox.Show("HNB Format Report Successfully Generated", "Report Generation");
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
            _conn.Close();
        }

        public void PeoplesBank()
        {
            //*********************************** Upload *************************************

            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            //int iNumQtrs;
            int AAA = 6; //Columns
            int BBB = 0; //Rows
            int CCC = 0;
            int AutoNo = 0;
            //int DDD = 0;

            try
            {
                //START Microsoft.Office.Interop.Excel
                oXL = new Microsoft.Office.Interop.Excel.Application();
                //oXL.Visible = true;

                //NEW WORKBOOK
                //oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                //oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                string File_Path;
                File_Path = (Environment.CurrentDirectory) + "\\" + "PeoplesBank.xlsm";

                //OPEN WORKBOOK
                oWB = oXL.Workbooks.Open(File_Path, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, true, Missing.Value);
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //FONT NAME & SIZE
                oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
                oSheet.get_Range("A6", "Z10000").Font.Size = 8;

                //BACKGROUNG
                oSheet = (Worksheet)oWB.Worksheets.get_Item(1);
                oSheet.Name = "com_upload ";

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;

                cmdsql.CommandText = "SELECT *, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')AND (EAR_ID = 'NETSAL') AND (BANK_CODE = '7135') ORDER BY(CONVERT(INT,EMP_NO))";
                SqlDataReader dreader = cmdsql.ExecuteReader();

                while (dreader.Read())
                {                    
                    oSheet.Cells[AAA + BBB, 1] = dreader["BANK_CODE"].ToString();
                    oSheet.Cells[AAA + BBB, 2] = dreader["SORT_BRANCH"].ToString(); //"109";
                    oSheet.Cells[AAA + BBB, 3] = "000";
                    int TempLen = dreader["ACC_NO"].ToString().Trim().Length;
                    if(TempLen > 12)
                        oSheet.Cells[AAA + BBB, 4] = dreader["ACC_NO"].ToString().Trim().Substring(TempLen-12, 12);
                    else
                        oSheet.Cells[AAA + BBB, 4] = dreader["ACC_NO"].ToString().Trim();
                    oSheet.Cells[AAA + BBB, 5] = dreader["NAME_BANK"].ToString().Replace(".", " ");
                    oSheet.Cells[AAA + BBB, 6] = "23";
                    oSheet.Cells[AAA + BBB, 7] = "0";
                    oSheet.Cells[AAA + BBB, 8] = dreader["PAY_VALUE"].ToString().Replace(".", "");
                    oSheet.Cells[AAA + BBB, 9] = "               ";
                    oSheet.Cells[AAA + BBB, 10] = "               ";
                    oSheet.Cells[AAA + BBB, 18] = DateTime.Today.ToString("yyMMdd"); //dt_Date.Text.ToString();
                    oSheet.Cells[AAA + BBB, 12] = "000000";
                    oSheet.Cells[AAA + BBB, 13] = "                             ";

                    AAA = AAA + 1;

                    BBB = 0;
                }

                //NUMBER FORMAT
                //oSheet.get_Range("A6", "A10000").NumberFormat = "0000";
                //oSheet.get_Range("B6", "B10000").NumberFormat = "0000";
                //oSheet.get_Range("C6", "C10000").NumberFormat = "109";
                oSheet.get_Range("D6", "D10000").NumberFormat = "000000000000";
                //oSheet.get_Range("F6", "F10000").NumberFormat = "00";
                //oSheet.get_Range("G6", "G10000").NumberFormat = "00";
                //oSheet.get_Range("H6", "H10000").NumberFormat = "0";
                //oSheet.get_Range("I6", "I10000").NumberFormat = "000000";
                //oSheet.get_Range("J6", "J10000").NumberFormat = "000000000000";
                //oSheet.get_Range("L6", "L10000").NumberFormat = "7056";
                //oSheet.get_Range("N6", "N10000").NumberFormat = "000000000000";
                //oSheet.get_Range("R6", "R10000").NumberFormat = "yymmdd";

                //APPLY BOARDS
                oRng = oSheet.get_Range("A5", "W5").get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                oRng = oSheet.get_Range("A6", "W" + AAA).get_Resize(Missing.Value, 20);
                oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline;

                oXL.Visible = true;
                oXL.UserControl = true;
                dreader.Close();
                MessageBox.Show("Peoples Bank Report Successfully Generated", "Report Generation");
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
            _conn.Close();
        }

        private void EmpwiseSalary()
        {
            //*********************************** Upload *************************************

            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            //int iNumQtrs;
            int AAA = 6; //Columns
            int BBB = 0; //Rows
            int CCC = 0;

            //try
            //{
            //START Microsoft.Office.Interop.Excel
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;

            //NEW WORKBOOK
            //oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            //oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

            string File_Path;
            File_Path = (Environment.CurrentDirectory) + "\\" + "rpt_Emp_Wise_Salary.xls";

            //OPEN WORKBOOK
            oWB = oXL.Workbooks.Open(File_Path, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, true, Missing.Value);
            oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

            //FONT NAME & SIZE
            oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
            oSheet.get_Range("A6", "Z10000").Font.Size = 8;

            //BACKGROUNG
            oSheet = (Worksheet)oWB.Worksheets.get_Item(1);
            oSheet.Name = "Employee wise Salary Sheet";

            //HEADERS
            //oSheet.Cells[5, 1] = "Name)";
            //oSheet.Cells[5, 2] = "EPF No";
            //oSheet.Cells[5, 3] = "NIC No";
            //oSheet.Cells[5, 4] = "Designation";
            //oSheet.Cells[5, 5] = "Basic Salary";
            //oSheet.Cells[5, 6] = "Allowance";
            //oSheet.Cells[5, 7] = "Under Payment";
            //oSheet.Cells[5, 8] = "SUB TOTAL";
            //oSheet.Cells[5, 9] = "DEDUCTIONS";
            //oSheet.Cells[5, 10] = "No Pay";
            //oSheet.Cells[5, 11] = "Over Payment";
            //oSheet.Cells[5, 12] = "TOTAL FOR EPF";
            //oSheet.Cells[5, 13] = "ADD - OverTime";
            //oSheet.Cells[5, 14] = "Subsistance";
            //oSheet.Cells[5, 15] = "Reimbursable Exp";
            //oSheet.Cells[5, 16] = "TOATL EARNINGS";
            //oSheet.Cells[5, 17] = "DEDUCTIONS";
            //oSheet.Cells[5, 18] = "EPF(8%)";
            //oSheet.Cells[5, 19] = "Basic Salary";
            //oSheet.Cells[5, 20] = "Salary Advance";
            //oSheet.Cells[5, 21] = "Festival Advance";
            //oSheet.Cells[5, 22] = "Interest on Loan";
            //oSheet.Cells[5, 23] = "Penalty";
            //oSheet.Cells[5, 24] = "Security Deposit";
            //oSheet.Cells[5, 25] = "Union/Welfair";
            //oSheet.Cells[5, 26] = "TOATL DEDUCTIONS";
            //oSheet.Cells[5, 27] = "NET SALARY";
            //oSheet.Cells[5, 28] = "EMPLOYER CONTR. EPF(12%)";
            //oSheet.Cells[5, 29] = "ETF(3%)";

            //SET ORIENTATION
            oSheet.get_Range("A5", "AC5").Orientation = 90;

            //SET WRAP TEXT
            oSheet.get_Range("A5", "AC5").WrapText = true;

            //CENTER TEXT
            oSheet.get_Range("A5", "AC5").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            oSheet.get_Range("A5", "AC5").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            //COLUMN WIDTH
            oSheet.get_Range("A1", "A1").ColumnWidth = 18;
            oSheet.get_Range("B1", "B1").ColumnWidth = 4;
            oSheet.get_Range("C1", "C1").ColumnWidth = 10;
            oSheet.get_Range("D1", "D1").ColumnWidth = 18;
            oSheet.get_Range("E1", "E1").ColumnWidth = 20;
            oSheet.get_Range("F1", "F1").ColumnWidth = 20;
            oSheet.get_Range("G1", "G1").ColumnWidth = 20;
            oSheet.get_Range("H1", "H1").ColumnWidth = 20;
            oSheet.get_Range("I1", "I1").ColumnWidth = 20;
            oSheet.get_Range("J1", "J1").ColumnWidth = 20;
            oSheet.get_Range("K1", "K1").ColumnWidth = 20;
            oSheet.get_Range("L1", "L1").ColumnWidth = 20;
            oSheet.get_Range("M1", "M1").ColumnWidth = 20;
            oSheet.get_Range("N1", "N1").ColumnWidth = 20;
            oSheet.get_Range("O1", "O1").ColumnWidth = 20;
            oSheet.get_Range("P1", "P1").ColumnWidth = 20;
            oSheet.get_Range("Q1", "Q1").ColumnWidth = 20;
            oSheet.get_Range("R1", "R1").ColumnWidth = 20;
            oSheet.get_Range("S1", "S1").ColumnWidth = 20;
            oSheet.get_Range("T1", "T1").ColumnWidth = 20;
            oSheet.get_Range("U1", "U1").ColumnWidth = 20;
            oSheet.get_Range("V1", "V1").ColumnWidth = 20;
            oSheet.get_Range("W1", "W1").ColumnWidth = 20;
            oSheet.get_Range("X1", "X1").ColumnWidth = 20;
            oSheet.get_Range("Y1", "Y1").ColumnWidth = 20;
            oSheet.get_Range("Z1", "Z1").ColumnWidth = 20;
            oSheet.get_Range("AA1", "AA1").ColumnWidth = 20;
            oSheet.get_Range("AB1", "AB1").ColumnWidth = 20;
            oSheet.get_Range("AC1", "AC1").ColumnWidth = 20;

            //ROW HIGHT
            oSheet.get_Range("A5", "A5").RowHeight = 80;
            oSheet.get_Range("A6", "W10000").RowHeight = 20;

            //BOLD AND ALIGNMENT
            oSheet.get_Range("A5", "W5").Font.Bold = true;
            oSheet.get_Range("A1", "W1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsqlA = new SqlCommand();
            cmdsqlA.Connection = _conn;
            cmdsqlA.CommandText = "SELECT *, PAY_YEAR, SAL_MONTH FROM RE_VW_PAY_SLIP WHERE EAR_ID = 'BASIC' AND (EMP_NO = 25) AND (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "') ORDER BY CONVERT(INT,EMP_NO)";
            SqlDataReader dreaderA = cmdsqlA.ExecuteReader();

            while (dreaderA.Read())
            {
                oSheet.Cells[AAA + BBB, 1] = dreaderA["EMP_NO"].ToString();
                oSheet.Cells[AAA + BBB, 2] = dreaderA["EMP_NAME"].ToString();
                oSheet.Cells[AAA + BBB, 3] = dreaderA["NIC_NO"].ToString();
                oSheet.Cells[AAA + BBB, 4] = dreaderA["DESIGNATION"].ToString();
                oSheet.Cells[AAA + BBB, 11] = dreaderA["ACC_NO"].ToString();
                oSheet.Cells[AAA + BBB, 8] = dreaderA["TEN_NO"].ToString();
                oSheet.Cells[AAA + BBB, 8] = dreaderA["DESCRIPTION"].ToString();
                //oSheet.Cells[AAA + BBB, 8] = dreaderA[""].ToString();
                //oSheet.Cells[AAA + BBB, 8] = dreaderA[""].ToString();
                //oSheet.Cells[AAA + BBB, 8] = dreaderA[""].ToString();
                //oSheet.Cells[AAA + BBB, 8] = dreaderA[""].ToString();
                //oSheet.Cells[AAA + BBB, 8] = dreaderA[""].ToString();
                //oSheet.Cells[AAA + BBB, 8] = dreaderA[""].ToString();
                //oSheet.Cells[AAA + BBB, 8] = dreaderA[""].ToString();
                //oSheet.Cells[AAA + BBB, 8] = dreaderA[""].ToString();
                //oSheet.Cells[AAA + BBB, 8] = dreaderA[""].ToString();

                AAA = AAA + 1;
                BBB = 0;
            }

            dreaderA.Close();

            //Connection.DatabaseConnection obyConn;
            //obyConn = new Connection.DatabaseConnection();
            //_conn = obyConn.Connect();
            SqlCommand cmdsqlB = new SqlCommand();
            cmdsqlB.Connection = _conn;
            cmdsqlB.CommandText = "SELECT *, PAY_YEAR, SAL_MONTH FROM RE_VW_PAY_SLIP WHERE EAR_ID = 'BASIC' AND (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "') ORDER BY CONVERT(INT,EMP_NO)";
            SqlDataReader dreaderB = cmdsqlB.ExecuteReader();

            AAA = 6;

            while (dreaderB.Read())
            {
                //oSheet.Cells[AAA + BBB, 8] = dreaderB["NAME"].ToString();
                //oSheet.Cells[AAA + BBB, 9] = dreaderB["BANK"].ToString();
                //oSheet.Cells[AAA + BBB, 10] = dreaderB["BRANCH"].ToString();
                //oSheet.Cells[AAA + BBB, 11] = dreaderB["NIC_NO"].ToString();
                //oSheet.Cells[AAA + BBB, 12] = dreaderB["DESIGNATION"].ToString();
                //oSheet.Cells[AAA + BBB, 13] = dreaderB["ACC_NO"].ToString();
                //oSheet.Cells[AAA + BBB, 14] = dreaderB["DATE_OF_JOINED"].ToString();


                AAA = AAA + 1;
                BBB = 0;
            }

            //NUMBER FORMAT
            //oSheet.get_Range("A6", "A10000").NumberFormat = "0000";
            //oSheet.get_Range("B6", "B10000").NumberFormat = "0000";
            //oSheet.get_Range("C6", "C10000").NumberFormat = "000";
            //oSheet.get_Range("D6", "D10000").NumberFormat = "000000000000000";
            //oSheet.get_Range("F6", "F10000").NumberFormat = "00";
            //oSheet.get_Range("G6", "G10000").NumberFormat = "00";
            //oSheet.get_Range("H6", "H10000").NumberFormat = "0";
            //oSheet.get_Range("I6", "I10000").NumberFormat = "000000";
            //oSheet.get_Range("J6", "J10000").NumberFormat = "000000000000";
            //oSheet.get_Range("N6", "N10000").NumberFormat = "000000000000";
            //oSheet.get_Range("R6", "R10000").NumberFormat = "MMddyy";

            //APPLY BOARDS
            oRng = oSheet.get_Range("A5", "X5").get_Resize(Missing.Value, 20);
            oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            oRng = oSheet.get_Range("A6", "X" + AAA).get_Resize(Missing.Value, 20);
            oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline;

            oXL.Visible = true;
            oXL.UserControl = true;
            dreaderB.Close();
            _conn.Close();

            //catch (Exception theException)
            //{
            //    String errorMessage;
            //    errorMessage = "Error: ";
            //    errorMessage = String.Concat(errorMessage, theException.Message);
            //    errorMessage = String.Concat(errorMessage, " Line: ");
            //    errorMessage = String.Concat(errorMessage, theException.Source);

            //    MessageBox.Show(errorMessage, "Error");
            //}
        }

        ////*********************************** New Upload for TenderCostDistributionNew ************

        //private void TenderCostDistribution()
        //{
        //    //*********************************** Upload *************************************

        //    Microsoft.Office.Interop.Excel.Application oXL;
        //    Microsoft.Office.Interop.Excel._Workbook oWB;
        //    Microsoft.Office.Interop.Excel._Worksheet oSheet;
        //    Microsoft.Office.Interop.Excel.Range oRng;
        //    int AAA = 5; //Columns
        //    int BBB = 1; //Rows
        //    int CCC = 0;
        //    int intSeq = 1;
        //    int intPrintOnce = 1;

        //    try
        //    {
        //        //START Microsoft.Office.Interop.Excel
        //        oXL = new Microsoft.Office.Interop.Excel.Application();

        //        string File_Path;
        //        File_Path = (Environment.CurrentDirectory) + "\\" + "TenderCostDis.xls";

        //        //OPEN WORKBOOK
        //        oWB = oXL.Workbooks.Open(File_Path, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, true, Missing.Value);
        //        oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

        //        //FONT NAME & SIZE
        //        //oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
        //        //oSheet.get_Range("A6", "Z10000").Font.Size = 9;

        //        //BACKGROUNG
        //        oSheet = (Worksheet)oWB.Worksheets.get_Item(1);
        //        oSheet.Name = "Tender_Cost";

        //        Connection.DatabaseConnection obyConn;
        //        obyConn = new Connection.DatabaseConnection();
        //        _conn = obyConn.Connect();
        //        SqlCommand cmdsql = new SqlCommand();
        //        cmdsql.Connection = _conn;

        //        //cmdsql.CommandText = "SELECT * FROM VW_TENDERWISE_COST_DISTRIBUTION_TOT WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')";
        //        //cmdsql.CommandText = "SELECT EAR_ID, SUM(PAY_VALUE) AS PAY_VALUE, PAY_YEAR, SAL_MONTH, TEN_NO, DESCRIPTION FROM VW_TENDERWISE_COST_DISTRIBUTION_TOT GROUP BY EAR_ID, PAY_YEAR, SAL_MONTH, TEN_NO, DESCRIPTION HAVING (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')";

        //        cmdsql.CommandText = "SELECT VW_TENDERWISE_COST_DISTRIBUTION_TOT.EAR_ID, SUM(VW_TENDERWISE_COST_DISTRIBUTION_TOT.PAY_VALUE) AS PAY_VALUE, VW_TENDERWISE_COST_DISTRIBUTION_TOT.PAY_YEAR, VW_TENDERWISE_COST_DISTRIBUTION_TOT.SAL_MONTH, VW_TENDERWISE_COST_DISTRIBUTION_TOT.TEN_NO, VW_TENDERWISE_COST_DISTRIBUTION_TOT.DESCRIPTION, TENDER_MAIN.STATUS FROM VW_TENDERWISE_COST_DISTRIBUTION_TOT INNER JOIN TENDER_MAIN ON VW_TENDERWISE_COST_DISTRIBUTION_TOT.TEN_NO = TENDER_MAIN.TEN_NO GROUP BY VW_TENDERWISE_COST_DISTRIBUTION_TOT.EAR_ID, VW_TENDERWISE_COST_DISTRIBUTION_TOT.PAY_YEAR, VW_TENDERWISE_COST_DISTRIBUTION_TOT.SAL_MONTH, VW_TENDERWISE_COST_DISTRIBUTION_TOT.TEN_NO, VW_TENDERWISE_COST_DISTRIBUTION_TOT.DESCRIPTION, TENDER_MAIN.STATUS HAVING (VW_TENDERWISE_COST_DISTRIBUTION_TOT.PAY_YEAR = '" + cmbYear.Text + "') AND (VW_TENDERWISE_COST_DISTRIBUTION_TOT.SAL_MONTH = '" + cmbMonth.Text + "') AND (TENDER_MAIN.STATUS = 1)";
        //        SqlDataReader dreader = cmdsql.ExecuteReader();

        //        oSheet.Cells[2, 4] = cmbMonth.Text;
        //        oSheet.Cells[2, 5] = cmbYear.Text;                

        //        while (dreader.Read())
        //        {
        //            if (intSeq == 1 || intPrintOnce == 4)
        //            {
        //                intPrintOnce = 1;
        //                oSheet.Cells[AAA, 1] = intSeq;
        //                oSheet.Cells[AAA, 2] = dreader["TEN_NO"].ToString();
        //                oSheet.Cells[AAA, 3] = dreader["DESCRIPTION"].ToString();                        
        //                intSeq++;
        //                CCC = AAA;
        //            //    MessageBox.Show("SEQ " + intSeq.ToString());
        //                AAA = AAA + 1;
        //            }
        //                if (dreader["EAR_ID"].ToString().CompareTo("TOT_EAR") == 0)
        //                    oSheet.Cells[CCC, 6] = dreader["PAY_VALUE"].ToString();
        //                else if (dreader["EAR_ID"].ToString().CompareTo("EPF12") == 0)
        //                    oSheet.Cells[CCC, 7] = dreader["PAY_VALUE"].ToString();
        //                else if (dreader["EAR_ID"].ToString().CompareTo("ETF") == 0)
        //                    oSheet.Cells[CCC, 8] = dreader["PAY_VALUE"].ToString();
                        
        //                intPrintOnce++;
        //              //  MessageBox.Show("PriOn " + intPrintOnce.ToString());
                        
        //            // BBB = 0;
        //        }

        //        //APPLY BOARDS
        //        /*    oRng = oSheet.get_Range("A1", "W5").get_Resize(Missing.Value, 20);
        //            oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
        //            oRng = oSheet.get_Range("A3", "W" + AAA).get_Resize(Missing.Value, 20);
        //            oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline;
        //         * */

        //        oXL.Visible = true;
        //        oXL.UserControl = true;
        //        dreader.Close();
        //        _conn.Close();

        //        MessageBox.Show("Tender Cost Comparrison Report Successfully Generated", "Report Generation");
        //    }
        //    catch (Exception theException)
        //    {
        //        String errorMessage;
        //        errorMessage = "Error: ";
        //        errorMessage = String.Concat(errorMessage, theException.Message);
        //        errorMessage = String.Concat(errorMessage, " Line: ");
        //        errorMessage = String.Concat(errorMessage, theException.Source);

        //        MessageBox.Show(errorMessage, "Error");
        //    }
        //}

        //*********************************** New Upload for TenderCostDistributionNew ************

        private void TenderCostDistribution()
        {
            //*********************************** Upload *************************************

            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            int AAA = 5; //Columns
            int BBB = 1; //Rows
            int CCC = 0;
            int intSeq = 1;
            int intPrintOnce = 1;

            //try
            //{
                //START Microsoft.Office.Interop.Excel
                oXL = new Microsoft.Office.Interop.Excel.Application();

                string File_Path;
                File_Path = (Environment.CurrentDirectory) + "\\" + "TenderCostDis.xls";

                //OPEN WORKBOOK
                oWB = oXL.Workbooks.Open(File_Path, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, true, Missing.Value);
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //FONT NAME & SIZE
                //oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
                //oSheet.get_Range("A6", "Z10000").Font.Size = 9;

                //BACKGROUNG
                oSheet = (Worksheet)oWB.Worksheets.get_Item(1);
                oSheet.Name = "Tender_Cost";

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;

                //cmdsql.CommandText = "SELECT * FROM VW_TENDERWISE_COST_DISTRIBUTION_TOT WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')";
                //cmdsql.CommandText = "SELECT EAR_ID, SUM(PAY_VALUE) AS PAY_VALUE, PAY_YEAR, SAL_MONTH, TEN_NO, DESCRIPTION FROM VW_TENDERWISE_COST_DISTRIBUTION_TOT GROUP BY EAR_ID, PAY_YEAR, SAL_MONTH, TEN_NO, DESCRIPTION HAVING (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')";

                cmdsql.CommandText = "SELECT * FROM VW_TENDER_COST_CONT WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')";
                SqlDataReader dreader = cmdsql.ExecuteReader();

                oSheet.Cells[2, 5] = cmbMonth.Text;
                oSheet.Cells[2, 6] = cmbYear.Text;

                while (dreader.Read())
                {
                    intPrintOnce = 1;
                    oSheet.Cells[AAA, 1] = intSeq;
                    oSheet.Cells[AAA, 2] = dreader["TEN_NO"].ToString();
                    oSheet.Cells[AAA, 3] = dreader["DESCRIPTION"].ToString();
                    oSheet.Cells[AAA, 4] = dreader["LOCATION"].ToString();
                        //if (dreader["EAR_ID"].ToString().CompareTo("TOT_EAR") == 0)
                    oSheet.Cells[AAA, 7] = dreader["TOT_EAR"].ToString();
                    TOT_VAL = Convert.ToDecimal(dreader["TOT_EAR"].ToString());
                        //else if (dreader["EAR_ID"].ToString().CompareTo("EPF12") == 0)
                    oSheet.Cells[AAA, 8] = dreader["TOT_EPF12"].ToString();
                    TOT_EPF = Convert.ToDecimal(dreader["TOT_EPF12"].ToString());
                        //else if (dreader["EAR_ID"].ToString().CompareTo("ETF") == 0)
                    oSheet.Cells[AAA, 9] = dreader["TOT_ETF"].ToString();
                    TOT_ETF = Convert.ToDecimal(dreader["TOT_ETF"].ToString());
                    TOT_VALS = Convert.ToDecimal(TOT_VAL) + Convert.ToDecimal(TOT_EPF) + Convert.ToDecimal(TOT_ETF);
                    oSheet.Cells[AAA, 10] = TOT_VALS.ToString();

                    intPrintOnce++;
                    //  MessageBox.Show("PriOn " + intPrintOnce.ToString());

                    // BBB = 0;
                    intSeq++;
                    CCC = AAA;
                        //    MessageBox.Show("SEQ " + intSeq.ToString());
                    AAA = AAA + 1;
                }

                //APPLY BOARDS
                /*    oRng = oSheet.get_Range("A1", "W5").get_Resize(Missing.Value, 20);
                    oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                    oRng = oSheet.get_Range("A3", "W" + AAA).get_Resize(Missing.Value, 20);
                    oRng.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline;
                 * */

                oXL.Visible = true;
                oXL.UserControl = true;
                dreader.Close();
                _conn.Close();

                MessageBox.Show("Tender Cost Comparrison Report Successfully Generated", "Report Generation");
            //}
            //catch (Exception theException)
            //{
            //    String errorMessage;
            //    errorMessage = "Error: ";
            //    errorMessage = String.Concat(errorMessage, theException.Message);
            //    errorMessage = String.Concat(errorMessage, " Line: ");
            //    errorMessage = String.Concat(errorMessage, theException.Source);

            //    MessageBox.Show(errorMessage, "Error");
            //}
        }

        private string Application()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void frm_ReportCriteria_Payroll_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            _conn1 = obyConn.Connect();

            dt_Date.Value = DateTime.Today.Date;
            trvReports.ExpandAll();
            GetAllTenders();
            GetAllBanks();

            cmbTender.Text = "";
            txtTenNo.Text = "";

        //    cmbLoan.Text = "";
            dt_Date.Value = DateTime.Today.Date;
        }

        private void GetAllTenders()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strHired = ("SELECT TEN_NO, DESCRIPTION, STATUS, TEN_NO + '  -  ' + DESCRIPTION AS COM_DESC FROM TENDER_MAIN WHERE STATUS=1");

            System.Data.DataTable tblHired = new System.Data.DataTable();
            SqlCommand cmdHired = new SqlCommand(strHired, _conn);
            SqlDataAdapter daHired = new SqlDataAdapter();

            daHired.SelectCommand = cmdHired;
            daHired.Fill(tblHired);

            //            cmbTender.Items.Add("Office Employee");

            cmbTender.DataSource = tblHired;
            cmbTender.DisplayMember = "COM_DESC";// tblHired.Columns["COM_DESC"].ToString();
            //cmbTender.ValueMember = tblHired.Columns["TEN_NO"].ToString();

            _conn.Close();

        }

        private void GetAllBanks()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdBank = new SqlCommand("SELECT * FROM BANK_DETAILS", _conn);
            SqlDataReader drBank = cmdBank.ExecuteReader();
            while (drBank.Read())
            {
                trvReports.Nodes[0].Nodes["chnBankLetters"].Nodes.Add(drBank["BANK_CODE"].ToString(), drBank["BANK"].ToString());
            }

            drBank.Close();
            _conn.Close();
        }

        private void cmbTender_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   txtTenNo.Text = cmbTender.Text.PadRight(cmbTender.Text.Length,Convert.ToChar("-")).ToString();
            /*    txtTenNo.Clear();

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "SELECT TEN_NO FROM  WHERE (DISPLAY_NAME = '" + cmb_Find_Emp.Text + "')";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                while (dreader.Read())
                {
                    txt_EmpNo.Text = dreader["EMP_NO"].ToString();
                }
                cmdsql.Dispose();
                dreader.Dispose();*/
        }

        private void cmbTender_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT *, TEN_NO + '  -  ' +  DESCRIPTION AS DESCRIPTION FROM TENDER_MAIN WHERE (TEN_NO + '  -  ' + DESCRIPTION = '" + cmbTender.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                if (dreader["TEN_NO"].ToString() == "OFFICE")
                {
                    txtTenNo.Text = "OFFICE";
                }
                else
                {
                    txtTenNo.Text = dreader["TEN_NO"].ToString();
                }
            }

            _conn.Close();

            //    txtTenNo.Text = cmbTender.ValueMember;
        }

        private void btnComBank_Click(object sender, EventArgs e)
        {
            switch (strReportName)
            {
                case "SampathBankExel":
                    SampathBank();                    
                    break;
                case "ComBankExel":
                    CommercialBank("SELECT *, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')AND (EAR_ID = 'NETSAL') AND (BANK_CODE = '7056') ORDER BY(CONVERT(INT,EMP_NO))");
                    break;
                case "BOCExel":
                    BankofCeylonExel("SELECT *, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')AND (EAR_ID = 'NETSAL') AND (BANK_CODE = '7010') ORDER BY(CONVERT(INT,EMP_NO))");
                    break;  
                case "TenderCostDis":
                    TenderCostDistribution();
                    break;
                case "PeoBankExel":
                    PeoplesBank();
                    break;
                case "OtherBankExel":
                    CommercialBank("SELECT *, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')AND (EAR_ID = 'NETSAL') AND ( (BANK_CODE = '7083' OR BANK_CODE = '7287' OR BANK_CODE = '0000')) ORDER BY BANK_CODE,(CONVERT(INT,EMP_NO))");
                    break;

                //case "EPF_Monthly_Microsoft.Office.Interop.Excel":                    
                //    frmEPFParameters frmEPFPara = new frmEPFParameters();
                //    frmEPFPara.Show();
                //    break;                    
                
            }
        }

        private void CreateSalSheetDataSetHeader(string strTenNo, int intYear, string strMonth)
        {
            if (txtTenNo.Text == "")
            {
                MessageBox.Show("Please Select the Tender & Proceed", "Report Generation");
                return;
            }
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strColName = "";
            string strSQLHeader = "SELECT DISTINCT TOP 100 PERCENT EMP_NO, EMP_NAME, DESIGNATION, NIC_NO, BANK, BRANCH, ACC_NO FROM dbo.RE_VW_PAY_SLIP WHERE TEN_NO='" + strTenNo + "' AND PAY_YEAR= '" + intYear + "' AND SAL_MONTH= '" + strMonth + "' ORDER BY EMP_NO";

            System.Data.DataTable tblSalSheet = new System.Data.DataTable();
            SqlCommand cmdSalSheet = new SqlCommand(strSQLHeader, _conn);
            SqlDataAdapter daSalSheet = new SqlDataAdapter();

            daSalSheet.SelectCommand = cmdSalSheet;
            daSalSheet.Fill(tblSalSheet);
            SqlDataAdapter shtAdap = new SqlDataAdapter("SELECT * FROM SAL_SHEET", _conn);
            SqlCommandBuilder shtBuiil = new SqlCommandBuilder(shtAdap);
            DataSet shtDaset = new DataSet();

            shtAdap.Fill(shtDaset, "SAL_SHEET");

            // Deleting Existing data on SAL_SHEET table
            foreach (DataRow dr in shtDaset.Tables["SAL_SHEET"].Rows)
            {
                dr.Delete();
            }
            shtAdap.Update(shtDaset, "SAL_SHEET");


            //  string[] strDes ={ "EMP_NO", "EMP_NAME", "DESIGNATION", "NIC_NO", "BANK", "BRANCH", "ACC_NO" };
            string[] strDesDet = { "EPF NO", "Name", "Designation", "NIC NO", "Bank", "Branch", "Account No" };

            // while (intTotRec <= tblSalSheet.Rows.Count)
            // {
            string[] strDes ={ "EMP_NO", "EMP_NAME", "DESIGNATION", "NIC_NO", "BANK", "BRANCH", "ACC_NO" };

            int intRecord = 0;
            int intEmp = 1;
            string strSalSheetField = "";
            bool isLast = false;

            foreach (DataRow drSalSheet in tblSalSheet.Rows)
            {
                DataRow dr = shtDaset.Tables["SAL_SHEET"].NewRow();

                dr["DESCRIPTION"] = "EPF NO";

                if (intRecord == tblSalSheet.Rows.Count)
                {
                    isLast = true;
                    goto EmpName;

                }

                for (int intSal = 0; intSal < 6; intSal++)
                {
                    if (intRecord == tblSalSheet.Rows.Count)
                    {
                        intRecord = intRecord - 1;
                        isLast = true;
                        goto AddData;

                    }
                    strSalSheetField = tblSalSheet.Rows[intRecord]["EMP_NO"].ToString();
                    strColName = "EMP_" + intEmp;
                    dr[strColName] = strSalSheetField;
                    dr["EMP_ORDER"] = intRecord;
                    intEmp++;
                    intRecord++;
                    if (intEmp == 7)
                        intEmp = 1;

                }
            AddData:
                shtDaset.Tables["SAL_SHEET"].Rows.Add(dr);
                shtAdap.Update(shtDaset, "SAL_SHEET");
                if (isLast == true)
                    goto EmpName;

            }
        //intEmp = 1;
        // NAME
        EmpName:
            intRecord = 0;
            intEmp = 1;
            strSalSheetField = "";
            isLast = false;

            foreach (DataRow drSalSheet in tblSalSheet.Rows)
            {
                DataRow dr = shtDaset.Tables["SAL_SHEET"].NewRow();

                dr["DESCRIPTION"] = "Name";

                if (intRecord == tblSalSheet.Rows.Count)
                {
                    isLast = true;
                    goto DESIGNATION;

                }

                for (int intSal = 0; intSal < 6; intSal++)
                {
                    if (intRecord == tblSalSheet.Rows.Count)
                    {
                        intRecord = intRecord - 1;
                        isLast = true;
                        goto AddData;

                    }
                    strSalSheetField = tblSalSheet.Rows[intRecord]["EMP_NAME"].ToString();
                    strColName = "EMP_" + intEmp;
                    dr[strColName] = strSalSheetField;
                    dr["EMP_ORDER"] = intRecord;
                    intEmp++;
                    intRecord++;
                    if (intEmp == 7)
                        intEmp = 1;

                }
            AddData:
                shtDaset.Tables["SAL_SHEET"].Rows.Add(dr);
                shtAdap.Update(shtDaset, "SAL_SHEET");
                if (isLast == true)
                    goto DESIGNATION;
            }

        DESIGNATION:
            intRecord = 0;
            intEmp = 1;
            strSalSheetField = "";
            isLast = false;

            foreach (DataRow drSalSheet in tblSalSheet.Rows)
            {
                DataRow dr = shtDaset.Tables["SAL_SHEET"].NewRow();

                dr["DESCRIPTION"] = "Designation";

                if (intRecord == tblSalSheet.Rows.Count)
                {
                    isLast = true;
                    goto NIC_NO;
                }

                for (int intSal = 0; intSal < 6; intSal++)
                {
                    if (intRecord == tblSalSheet.Rows.Count)
                    {
                        intRecord = intRecord - 1;
                        isLast = true;
                        goto AddData;

                    }
                    strSalSheetField = tblSalSheet.Rows[intRecord]["DESIGNATION"].ToString();
                    strColName = "EMP_" + intEmp;
                    dr[strColName] = strSalSheetField;
                    dr["EMP_ORDER"] = intRecord;
                    intEmp++;
                    intRecord++;
                    if (intEmp == 7)
                        intEmp = 1;

                }
            AddData:
                shtDaset.Tables["SAL_SHEET"].Rows.Add(dr);
                shtAdap.Update(shtDaset, "SAL_SHEET");
                if (isLast == true)
                    goto NIC_NO;
            }
        NIC_NO:
            intRecord = 0;
            intEmp = 1;
            strSalSheetField = "";
            isLast = false;

            foreach (DataRow drSalSheet in tblSalSheet.Rows)
            {
                DataRow dr = shtDaset.Tables["SAL_SHEET"].NewRow();

                dr["DESCRIPTION"] = "NIC NO";

                if (intRecord == tblSalSheet.Rows.Count)
                {
                    isLast = true;
                    goto Bank;
                }

                for (int intSal = 0; intSal < 6; intSal++)
                {
                    if (intRecord == tblSalSheet.Rows.Count)
                    {
                        intRecord = intRecord - 1;
                        isLast = true;
                        goto AddData;

                    }
                    strSalSheetField = tblSalSheet.Rows[intRecord]["NIC_NO"].ToString();
                    strColName = "EMP_" + intEmp;
                    dr[strColName] = strSalSheetField;
                    dr["EMP_ORDER"] = intRecord;
                    intEmp++;
                    intRecord++;
                    if (intEmp == 7)
                        intEmp = 1;

                }
            AddData:
                shtDaset.Tables["SAL_SHEET"].Rows.Add(dr);
                shtAdap.Update(shtDaset, "SAL_SHEET");
                if (isLast == true)
                    goto Bank;
            }

        Bank:
            intRecord = 0;
            intEmp = 1;
            strSalSheetField = "";
            isLast = false;

            foreach (DataRow drSalSheet in tblSalSheet.Rows)
            {
                DataRow dr = shtDaset.Tables["SAL_SHEET"].NewRow();

                dr["DESCRIPTION"] = "Bank";

                if (intRecord == tblSalSheet.Rows.Count)
                {
                    isLast = true;
                    goto BRANCH;
                }

                for (int intSal = 0; intSal < 6; intSal++)
                {
                    if (intRecord == tblSalSheet.Rows.Count)
                    {
                        intRecord = intRecord - 1;
                        isLast = true;
                        goto AddData;

                    }
                    strSalSheetField = tblSalSheet.Rows[intRecord]["BANK"].ToString();
                    strColName = "EMP_" + intEmp;
                    dr[strColName] = strSalSheetField;
                    dr["EMP_ORDER"] = intRecord;
                    intEmp++;
                    intRecord++;
                    if (intEmp == 7)
                        intEmp = 1;

                }
            AddData:
                shtDaset.Tables["SAL_SHEET"].Rows.Add(dr);
                shtAdap.Update(shtDaset, "SAL_SHEET");
                if (isLast == true)
                    goto BRANCH;
            }

        BRANCH:
            intRecord = 0;
            intEmp = 1;
            strSalSheetField = "";
            isLast = false;

            foreach (DataRow drSalSheet in tblSalSheet.Rows)
            {
                DataRow dr = shtDaset.Tables["SAL_SHEET"].NewRow();

                dr["DESCRIPTION"] = "Branch";

                if (intRecord == tblSalSheet.Rows.Count)
                {
                    isLast = true;
                    goto ACC_NO;
                }

                for (int intSal = 0; intSal < 6; intSal++)
                {
                    if (intRecord == tblSalSheet.Rows.Count)
                    {
                        intRecord = intRecord - 1;
                        isLast = true;
                        goto AddData;

                    }
                    strSalSheetField = tblSalSheet.Rows[intRecord]["BRANCH"].ToString();
                    strColName = "EMP_" + intEmp;
                    dr[strColName] = strSalSheetField;
                    dr["EMP_ORDER"] = intRecord;
                    intEmp++;
                    intRecord++;
                    if (intEmp == 7)
                        intEmp = 1;

                }
            AddData:
                shtDaset.Tables["SAL_SHEET"].Rows.Add(dr);
                shtAdap.Update(shtDaset, "SAL_SHEET");
                if (isLast == true)
                    goto ACC_NO;
            }


        ACC_NO:
            intRecord = 0;
            intEmp = 1;
            strSalSheetField = "";
            isLast = false;

            foreach (DataRow drSalSheet in tblSalSheet.Rows)
            {
                DataRow dr = shtDaset.Tables["SAL_SHEET"].NewRow();

                dr["DESCRIPTION"] = "Account No";

                if (intRecord == tblSalSheet.Rows.Count)
                {
                    isLast = true;
                    return;
                }
                for (int intSal = 0; intSal < 6; intSal++)
                {
                    if (intRecord == tblSalSheet.Rows.Count)
                    {
                        intRecord = intRecord - 1;
                        isLast = true;
                        goto AddData;

                    }
                    strSalSheetField = tblSalSheet.Rows[intRecord]["ACC_NO"].ToString();
                    strColName = "EMP_" + intEmp;
                    dr[strColName] = strSalSheetField;
                    dr["EMP_ORDER"] = intRecord;
                    intEmp++;
                    intRecord++;
                    if (intEmp == 7)
                        intEmp = 1;

                }
            AddData:
                shtDaset.Tables["SAL_SHEET"].Rows.Add(dr);
                shtAdap.Update(shtDaset, "SAL_SHEET");
                if (isLast == true)
                    return;
            }

            _conn.Close();

        }

        private void CreateSalSheetDataSetDetail(string strTenNo, int intYear, string strMonth)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();


            string strEmployee = "SELECT DISTINCT TOP 100 PERCENT EMP_NO FROM dbo.RE_VW_PAY_SLIP WHERE (TEN_NO = '" + strTenNo + "') AND (PAY_YEAR = '" + intYear + "') AND (SAL_MONTH = '" + strMonth + "') GROUP BY EMP_NO ORDER BY EMP_NO";

            System.Data.DataTable tblEmployee = new System.Data.DataTable();
            SqlCommand cmdEmployee = new SqlCommand(strEmployee, _conn);
            SqlDataAdapter daEmployee = new SqlDataAdapter();

            daEmployee.SelectCommand = cmdEmployee;
            daEmployee.Fill(tblEmployee);

            int intTotRecDet = tblEmployee.Rows.Count;

            SqlDataAdapter shtAdap = new SqlDataAdapter("SELECT * FROM SAL_SHEET", _conn);
            SqlCommandBuilder shtBuiil = new SqlCommandBuilder(shtAdap);
            DataSet shtDaset = new DataSet();

            shtAdap.Fill(shtDaset, "SAL_SHEET");

            string strEmp = "";
            string strEarDes = "";
            string strSalSheetField = "";

            int intSalRec = 1;
            string[] strDesDet ={"Gross Salary", "Allowance", "Under Payment", "Budgetary Relife Allowance", "Total", "Over Payment", "No Pay", "Total for EPF", "Subsistsnce", "Over Time Office Employees", "Over Time Tender Employees", "Supervisors Over Time", "Security Deposit Total", "Total Earnings", "EPF (8%)", "Festival Advance", "Salary Advance", "Housing Loan", "Housing Loan Interest", "Penalty", "Payee Tax", "Security Deposit", "Welfair Deduction", "Telephone Chargers", "Total Deductions", "Net Salary", "EPF (12%)", "ETF (3%)" };
            // string[] strDesDet ={ "Salary Advance" };
            bool isLast = false;
            string strColName = "";

            foreach (string strDes in strDesDet)
            {
                string strSQLHeader = "SELECT DISTINCT TOP 100 PERCENT EMP_NO, EAR_DESCRIPTION, PAY_VALUE, PAY_YEAR, SLIP_ORDER  FROM  dbo.RE_VW_PAY_SLIP WHERE TEN_NO='" + strTenNo + "' AND PAY_YEAR= '" + intYear + "' AND SAL_MONTH= '" + strMonth + "' AND EAR_DESCRIPTION ='" + strDes + "' ORDER BY SLIP_ORDER, EMP_NO";

                System.Data.DataTable tblSalSheet = new System.Data.DataTable();
                SqlCommand cmdSalSheet = new SqlCommand(strSQLHeader, _conn);
                SqlDataAdapter daSalSheet = new SqlDataAdapter();

                daSalSheet.SelectCommand = cmdSalSheet;
                daSalSheet.Fill(tblSalSheet);

                if (tblSalSheet.Rows.Count < intTotRecDet && tblSalSheet.Rows.Count > 0)
                {
                    int rec = 0;
                    foreach (DataRow drEmp in tblEmployee.Rows)
                    {
                        if (drEmp["EMP_NO"].ToString() != tblSalSheet.Rows[rec]["EMP_NO"].ToString())
                        {
                            DataRow drEmpSal = tblSalSheet.NewRow();

                            drEmpSal["EMP_NO"] = drEmp["EMP_NO"].ToString();
                            drEmpSal["EAR_DESCRIPTION"] = strDes;
                            drEmpSal["PAY_VALUE"] = 0;

                            tblSalSheet.Rows.Add(drEmpSal);
                        }
                    }

                }


                int intRec = 1;
                int intTotRec = 1;
                int intOrEMP = 0; // set the order by column equal to the above header data set
                int intSalSheetEmp = 0;

                // if(tblSalSheet.Rows.Count==0)
                // {
                DataRow drSalSheet = shtDaset.Tables["SAL_SHEET"].NewRow();
                intOrEMP = 5;
                for (int i = 0; i < intTotRecDet; i++)
                {
                    if (intRec == 1)
                    {
                        drSalSheet = shtDaset.Tables["SAL_SHEET"].NewRow();
                        drSalSheet["DESCRIPTION"] = strDes;
                        drSalSheet["EMP_ORDER"] = intOrEMP;
                        intOrEMP += 6;
                    }

                    strColName = "EMP_" + intRec;

                    double dblPayValue = 0;

                    if (tblSalSheet.Rows.Count > 0)
                    {
                        if (tblEmployee.Rows[i]["EMP_NO"].ToString() == tblSalSheet.Rows[intSalSheetEmp]["EMP_NO"].ToString())
                        {
                            dblPayValue = Convert.ToDouble(tblSalSheet.Rows[intSalSheetEmp]["PAY_VALUE"].ToString());
                            intSalSheetEmp++;
                        }
                        else
                        {
                            dblPayValue = 0;
                        }
                    }

                    drSalSheet[strColName] = dblPayValue.ToString("N2");

                    if (intRec == 6 || intTotRecDet == i + 1)
                    {
                        shtDaset.Tables["SAL_SHEET"].Rows.Add(drSalSheet);
                        shtAdap.Update(shtDaset, "SAL_SHEET");
                        // intRec = 1;
                    }

                    intRec++;
                    if (intRec > 6)
                        intRec = 1;

                    //intSalSheetEmp++;
                }
                //}
            }
            /*   else if (tblSalSheet.Rows.Count > 0 && tblSalSheet.Rows.Count == intTotRecDet)
               {
                   DataRow drSalSheet = shtDaset.Tables["SAL_SHEET"].NewRow();
                   intOrEMP = 4;
                   foreach (DataRow dr in tblSalSheet.Rows)
                   {
                       if (intRec == 1)
                       {
                           drSalSheet = shtDaset.Tables["SAL_SHEET"].NewRow();
                           strEarDes = dr["EAR_DESCRIPTION"].ToString();
                           drSalSheet["DESCRIPTION"] = strDes;
                           drSalSheet["EMP_ORDER"] = intOrEMP;
                           intOrEMP += 5;
                       }
                       strColName = "EMP_" + intRec;
                       drSalSheet[strColName] = dr["PAY_VALUE"].ToString();
                        
                        
                       
                       if (intRec == 5 || intTotRec == tblSalSheet.Rows.Count)
                           {
                               shtDaset.Tables["SAL_SHEET"].Rows.Add(drSalSheet);
                               shtAdap.Update(shtDaset, "SAL_SHEET");
                               // intRec = 1;
                           }
                        
                        
                       intRec++;
                       if (intRec > 5)
                           intRec = 1;

                       intTotRec++;
                   }
               }
               else if (tblSalSheet.Rows.Count < intTotRecDet)
               {
                   string strColName5 = "";
                   bool bolFound = false;

                   DataRow drSalSheet = shtDaset.Tables["SAL_SHEET"].NewRow();
                   intOrEMP = 4;
                   foreach (DataRow dr in tblSalSheet.Rows)
                   {
                       int i = 0;
                       //  MessageBox.Show(shtDaset.Tables["SAL_SHEET"].Rows[i]["Description"].ToString());
                       if (intRec == 1)
                       {
                           drSalSheet = shtDaset.Tables["SAL_SHEET"].NewRow();
                           strEarDes = dr["EAR_DESCRIPTION"].ToString();
                           drSalSheet["DESCRIPTION"] = strDes;
                           drSalSheet["EMP_ORDER"] = intOrEMP;
                           intOrEMP += 5;
                       }

                       while (shtDaset.Tables["SAL_SHEET"].Rows[i]["Description"].ToString() == "EPF NO")// && bolFound == true)
                       {
                           for (int intEmp5 = 1; intEmp5 < 6; intEmp5++)
                           {
                               strColName5 = "EMP_" + intEmp5;

                               if (shtDaset.Tables["SAL_SHEET"].Rows[i][strColName5].ToString() == dr["EMP_NO"].ToString())
                               {
                                   // MessageBox.Show(shtDaset.Tables["SAL_SHEET"].Rows[i][strColName5].ToString() + " AND " + dr["EMP_NO"].ToString() + " EMP " + strColName5);
                                   drSalSheet[strColName5] = dr["PAY_VALUE"].ToString();
                                   //   break;
                                   // intRec = intEmp5;
                                   if (intRec != intEmp5)
                                       intRec++;
                                   bolFound = true;
                                 //  break;
                               }
                           }
                           if (bolFound == true)
                               break;
                           i++;
                       }

                       // strColName = "EMP_" + intRec;

                       // drSalSheet[strColName] = dr["PAY_VALUE"].ToString();


                       if (intRec == 5 || intTotRec == tblSalSheet.Rows.Count)
                       {
                           shtDaset.Tables["SAL_SHEET"].Rows.Add(drSalSheet);
                           shtAdap.Update(shtDaset, "SAL_SHEET");
                           // intRec = 1;
                       }


                       intRec++;
                       if (intRec > 5)
                           intRec = 1;

                       intTotRec++;
                       bolFound = false;
                   }

               }

             //  MessageBox.Show(tblSalSheet.Rows.Count.ToString());

           }
           /*    for (int intRec = 0; intRec < intTotRec;intRec++)
               {

          
               }*/
            _conn.Close();

        }

        private void CreateSixMonth(int intMonth_Start,int intMonth_End)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strSQLHeader = "SELECT * FROM RE_VW_" + strEPFETF +" WHERE PAY_YEAR = " + cmbYear.Text + " AND MONTH_NUMBER BETWEEN " + intMonth_Start + " AND " + intMonth_End + " ORDER BY EMP_NO, MONTH_NUMBER";

            System.Data.DataTable tblSixMonth = new System.Data.DataTable();
            SqlCommand cmdSixMonth = new SqlCommand(strSQLHeader, _conn);
            SqlDataAdapter daSixMonth = new SqlDataAdapter();

            daSixMonth.SelectCommand = cmdSixMonth;
            daSixMonth.Fill(tblSixMonth);

            SqlDataAdapter shtAdap = new SqlDataAdapter("SELECT * FROM EPF_ETF_SIX_MONTH", _conn);
            SqlCommandBuilder shtBuiil = new SqlCommandBuilder(shtAdap);
            DataSet shtDaset = new DataSet();

            shtAdap.Fill(shtDaset, "EPF_ETF_SIX_MONTH");

            // Deleting Existing data on SAL_SHEET table
            foreach (DataRow dr in shtDaset.Tables["EPF_ETF_SIX_MONTH"].Rows)
            {
                dr.Delete();
            }
            shtAdap.Update(shtDaset, "EPF_ETF_SIX_MONTH");

            string strEmployee="";
            double dblTotCon = 0;
            string strField = "TOTAL_" + strEPFETF;

            for(int i=0; i<tblSixMonth.Rows.Count;i++)//                (DataRow drSix in tblSixMonth.Rows)
            {

                if (bolNewEmp == true)
                {                   
                    dr = shtDaset.Tables["EPF_ETF_SIX_MONTH"].NewRow();

                    dr["EMP_NO"] = tblSixMonth.Rows[i]["EMP_NO"].ToString();
                    bolNewEmp = false;
                }                

               
                if (bolNewEmp == false)
                {
                    dblTotCon += Convert.ToDouble(tblSixMonth.Rows[i][strField].ToString());

                    switch (tblSixMonth.Rows[i]["MONTH_NUMBER"].ToString())
                    {                            
                        case "1":
                            dr["1_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["1_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;
                        case "2":
                            dr["2_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["2_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;
                        case "3":
                            dr["3_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["3_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;
                        case "4":
                            dr["4_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["4_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;
                        case "5":
                            dr["5_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["5_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;
                        case "6":
                            dr["6_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["6_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;
                        case "7":
                            dr["1_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["1_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;
                        case "8":
                            dr["2_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["2_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;
                        case "9":
                            dr["3_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["3_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;
                        case "10":
                            dr["4_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["4_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;
                        case "11":
                            dr["5_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["5_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;
                        case "12":
                            dr["6_TOT_EAR"] = tblSixMonth.Rows[i]["PAY_VALUE"].ToString();
                            dr["6_CONT"] = tblSixMonth.Rows[i][strField].ToString();
                            break;                            
                    }
                }
                if (i + 1 == tblSixMonth.Rows.Count)
                    strEmployee = "";
                else
                    strEmployee = tblSixMonth.Rows[i+1]["EMP_NO"].ToString();

                if (strEmployee != tblSixMonth.Rows[i]["EMP_NO"].ToString())
                {
                    dr["TOT_CONTRIBUTION"] = dblTotCon;
                    shtDaset.Tables["EPF_ETF_SIX_MONTH"].Rows.Add(dr);
                    shtAdap.Update(shtDaset, "EPF_ETF_SIX_MONTH");
                    bolNewEmp = true;
                    dblTotCon = 0;
                }                               
            }
            _conn.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbTender.Text = "";
            txtTenNo.Text = "";

        }

        private void grbCriteria_Enter(object sender, EventArgs e)
        {

        }
    }
}



        // 23-October-2009 
        /*

            for (int intRec = 0; intRec < tblSalSheet.Rows.Count;intRec++)
            {
                strEmp = tblSalSheet.Rows[intRec]["EMP_NO"].ToString();

               // if (strEmp == tblSalSheet.Rows[intRec]["EMP_NO"].ToString())
                //{
                DataRow drSalSheet = shtDaset.Tables["SAL_SHEET"].NewRow();

                for (int intRepeat = 1; intRepeat < 5; intRepeat++)
                {
                    strEarDes = tblSalSheet.Rows[intRec]["EAR_DESCRIPTION"].ToString();
                    for (int intDes = 0; intDes < strDesDet.Length; intDes++)
                    {

                        
                        //
                        if (strEarDes == strDesDet[intDes] && tblSalSheet.Rows[intRec]["PAY_VALUE"].ToString() != "")
                        {
                            drSalSheet["DESCRIPTION"] = strEarDes;
                            strSalSheetField = tblSalSheet.Rows[intRec]["PAY_VALUE"].ToString();
                        }
                      /*  else
                        {
                            drSalSheet["DESCRIPTION"] = strDesDet[intDes];
                            strSalSheetField = "0";
                        }   */             
         /*           }

                    strColName = "EMP_" + intRepeat;
                    drSalSheet[strColName] = strSalSheetField;
                }
                shtDaset.Tables["SAL_SHEET"].Rows.Add(drSalSheet);
                shtAdap.Update(shtDaset, "SAL_SHEET");
                   
                    //  dr["EMP_ORDER"] = intRecord;                        


                    if (intTotRec >= tblSalSheet.Rows.Count)
                    {
                        isLast = true;
                        goto AddRecord;
                    }
                //  }
                AddRecord:
                    
                    if (isLast == true)
                        return;
                    intSalRec = intSalRec + 1;
                    if (intSalRec > 5)
                        intSalRec = 1; 
                    //
                    
              //  } 

            }
            
                           
        }

    }


}
            //    intTotRec++;
            // intTotRec = intTotRec + 5;

            // intRecord = intRecord + intTotRec;
            //  }
           
            //Inserting Earnings / Deductions Detail
            /*     string strSQLDetail = "SELECT TOP 100 PERCENT EMP_NO, EAR_DESCRIPTION, PAY_VALUE, SLIP_ORDER, EAR_ID FROM  dbo.RE_VW_PAY_SLIP WHERE TEN_NO='" + strTenNo + "' AND PAY_YEAR= '" + intYear + "' AND SAL_MONTH= '" + strMonth + "' ORDER BY EMP_NO, SLIP_ORDER";

                 System.Data.DataTable tblSalShtDet = new System.Data.DataTable();
                 SqlCommand cmdSalShtDet = new SqlCommand(strSQLDetail, _conn);
                 SqlDataAdapter daSalShtDet = new SqlDataAdapter();

                 daSalShtDet.SelectCommand = cmdSalShtDet;
                 daSalShtDet.Fill(tblSalShtDet);

                 string[] strDesDet ={ "ALW", "BASIC", "UNP", "TOT", "OVP", "NOP", "TOT_EPF" };

                 for (int intDes = 0; intDes < strDesDet.Length; intDes++)
                 {

                 }
             * */
    
