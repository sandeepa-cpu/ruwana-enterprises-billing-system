using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Reflection;

namespace Billing_Inventory_Management_System
{
    public partial class frm_ReportCriteria_Inventory : Form
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

        decimal IQTY, QTY, PRICE, DIS_PRICE, TOT, ISSUE_PRICE = 0;
        int RSEQ_NO = 0;
        string PARTNO, INV_NO, I_INV_NO;
        DateTime DTPRO;

        public frm_ReportCriteria_Inventory()
        {
            InitializeComponent();
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
                if (strReportName == "ComBankExel")
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
                oSheet.get_Range("A7", "A" + AAA).NumberFormat = "00000000";
                oSheet.get_Range("C7", "C" + AAA).NumberFormat = "0000";
                oSheet.get_Range("D7", "D" + AAA).NumberFormat = "000";
                oSheet.get_Range("E7", "E" + AAA).NumberFormat = "000000000000";
                oSheet.get_Range("F7", "F" + AAA).NumberFormat = "000";
                oSheet.get_Range("G7", "G" + AAA).NumberFormat = "00000000000";
                //oSheet.get_Range("H7", "H"+ AAA).NumberFormat = "yyMMdd";
                oSheet.get_Range("I7", "I" + AAA).NumberFormat = "0000000000000";

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
                        lblwait.Visible = true;
                        PRINTINV_R();
                        PRINTINV_I();


                        if (lblINVNO.Text == "")
                            lblINVNO.Text = "0";
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
            cmdsql1.CommandText = "SELECT PRO_DATE, RECEIVE_SEQNO, SUM(QTY) AS QTY, PRICE, SUM(TOT) AS TOT FROM ISSUED_ITEMS WHERE (PRO_DATE = CONVERT(DATETIME, '"+ lbl_SysDate.Text +"', 102))GROUP BY INV_NO, RECEIVE_SEQNO, PARTNO, PRICE, PRO_DATE";
            SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            while (dreader1.Read())
            {
                RSEQ_NO = int.Parse(dreader1["RECEIVE_SEQNO"].ToString().Trim());
                QTY = decimal.Parse(dreader1["QTY"].ToString().Trim());
                PRICE = decimal.Parse(dreader1["PRICE"].ToString().Trim());
                ISSUE_PRICE = decimal.Parse(dreader1["TOT"].ToString().Trim());
                DTPRO = DateTime.Parse(dreader1["PRO_DATE"].ToString().Trim());

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE PRINT_INVOICE SET PRO_DATE = Convert(DateTime,'" + DTPRO + "'),ISEQ_NO = '" + RSEQ_NO + "', IQTY = '" + QTY + "', IPRICE = '" + PRICE + "', ITOT = '" + ISSUE_PRICE + "'WHERE RSEQ_NO = '" + RSEQ_NO + "'";
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
                case "chnMIRR":
                    lblPwdOK.Text = "1";
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
                    //grbDates.Enabled = false;
                    txtPwd.Focus();
                    ProfitPWD();
                    break;
                case "chnInv":
                    lblPwdOK.Text = "0";
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
            UiTheme.StyleForm(this);
            
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

                        PRINTINV_R();
                        PRINTINV_I();

                    }
                    if (strReportName == "rpt_GRNCreditDateRange")
                    {
                        FINDGRNCASHCREDIT();
                    }
                    if (strReportName == "rpt_MIRCreditDateRange")
                    {
                        FINDMIRCASHCREDIT();
                    }

                    if (lblINVNO.Text == "")
                        lblINVNO.Text = "0";
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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
