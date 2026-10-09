using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Billing_Inventory_Management_System
{
    public partial class frmEPFParameters : Form
    {
        public frmEPFParameters()
        {
            InitializeComponent();
        }
        CommonProfiles objComPro = new CommonProfiles();
        private SqlConnection _conn;
        private SqlConnection _ConnDW;
        public string strExcel = "";
        decimal EMP_NODAYS = 0;
        decimal NODAYS = 0;
        int EMP_NO = 0;
        private int intYear = 0;
        private int intMonth = 0;

        private void btnGenerateExel_Click(object sender, EventArgs e)
        {
            if (cmbYear.Text == "" || cmbMonth.Text == "")
            {
                MessageBox.Show("Please Select Year and Month to proceed", "Criteria");
                return;
            }
            if (strExcel == "MonthlyIndividualExcelEPF")
                EPFMonthlyIndividualTotal();
            else if (strExcel=="ExcelEPFTotal")
                EPFMonthlyTotal();

        }

        private void frmEPFParameters_Load(object sender, EventArgs e)
        {
            if (strExcel == "MonthlyIndividualExcelEPF")
            {
                grbEvemp.Enabled = false;
            }
        }

        private void EPFMonthlyTotal()
        {
            //*********************************** Upload *************************************

            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;

            try
            {
                //START EXCEL
                oXL = new Microsoft.Office.Interop.Excel.Application();

                string File_Path;
                File_Path = (Environment.CurrentDirectory) + "\\" + "EVEMP.xls";

                //OPEN WORKBOOK
                oWB = oXL.Workbooks.Open(File_Path, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, true, Missing.Value);
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //FONT NAME & SIZE
                oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
                oSheet.get_Range("A6", "Z10000").Font.Size = 8;

                //BACKGROUNG
                oSheet = (Worksheet)oWB.Worksheets.get_Item(1);
                oSheet.Name = "evemp";

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;                              
                cmdsql.CommandText = "SELECT TOP 100 PERCENT SUM(PAY_VALUE) AS TOTAL_EPF, COUNT(EMP_NO) AS NO_EMP FROM dbo.VW_PAY_SLIPS WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "') GROUP BY EAR_ID HAVING (EAR_ID = 'EPF') OR (EAR_ID = 'EPF12')";
                SqlDataReader dreader = cmdsql.ExecuteReader();

                int intMonth = objComPro.GetMonthConverted(cmbMonth.Text);
                double dblTotCont = 0;
                int intNoEmp = 0;
                int intPayMode = 0;

                if (rdbCheque.Checked == true)
                    intPayMode = 1;
                else if (rdbCash.Checked == true)
                    intPayMode = 2;
                else if (rdbMoneyOrder.Checked == true)
                    intPayMode = 3;
                else if (rdbDirectDebit.Checked == true)
                    intPayMode = 4;

                while (dreader.Read())
                {
                    dblTotCont += double.Parse(dreader["TOTAL_EPF"].ToString());
                    intNoEmp = int.Parse(dreader["NO_EMP"].ToString());
                }

                    oSheet.Cells[2, 1] = "D";
                    oSheet.Cells[2, 2] = "15729";
                    
                    if(intMonth<10)
                    oSheet.Cells[2, 3] = cmbYear.Text + "0" + intMonth.ToString();
                    else
                    oSheet.Cells[2, 3] = cmbYear.Text + intMonth.ToString();
                    
                    oSheet.Cells[2, 4] = "1";
                    if (dblTotCont.ToString().Length > 14)
                    {
                        MessageBox.Show("Total Contribution Amount Length Exceeding the Range 14", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    oSheet.Cells[2, 5] = dblTotCont.ToString();
                    oSheet.Cells[2, 6] = intNoEmp.ToString();
                    oSheet.Cells[2, 7] = intPayMode.ToString();
                    oSheet.Cells[2, 8] = txtPayRef.Text;
                    oSheet.Cells[2, 9] = dtpDate.Value.ToString("yyyyMMdd");
                    oSheet.Cells[2, 10] = "14";

                oXL.Visible = true;
                oXL.UserControl = true;
                dreader.Close();

                MessageBox.Show("EPF Summary Report Successfully Generated", "Report Generation");
                _conn.Close();
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

        private void EPFMonthlyIndividualTotal()
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;

            try
            {
                //START EXCEL
                oXL = new Microsoft.Office.Interop.Excel.Application();

                string File_Path;
                File_Path = (Environment.CurrentDirectory) + "\\" + "EVEMC.xls";

                //OPEN WORKBOOK
                oWB = oXL.Workbooks.Open(File_Path, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, true, Missing.Value);
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //FONT NAME & SIZE
                oSheet.get_Range("A1", "Z10000").Font.Name = "Verdana";
                oSheet.get_Range("A6", "Z10000").Font.Size = 8;

                //BACKGROUNG
                oSheet = (Worksheet)oWB.Worksheets.get_Item(1);
                oSheet.Name = "EVEMC";

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;

                //cmdsql.CommandText = "SELECT NIC_NO, NAME, INITIALS, EMP_NO, TOTAL_EPF, TOTAL_EMPLOYER, TOTAL_EMPLOYEE, PAY_VALUE, GRADE FROM RE_VW_EPF_MONTHLY WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "') ORDER BY EMP_NO";
                cmdsql.CommandText = "SELECT TOP 100 PERCENT NIC_NO, NAME, INITIALS, EMP_NO, TOTAL_EPF, TOTAL_EMPLOYER, TOTAL_EMPLOYEE, PAY_VALUE, GRADE," +
                                     " (SELECT COUNT(DED_ID) FROM dbo.PAY_SLIPS_DEDUCTIONS WHERE (EMP_NO = RE_VW_EPF_MONTHLY.EMP_NO) AND (DED_ID = 'EPF')) AS EPF_EXI_EMP" +
                                     " FROM dbo.RE_VW_EPF_MONTHLY WHERE (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "') ORDER BY EMP_NO";
                
                SqlDataReader dreader = cmdsql.ExecuteReader();

                int intMonth = objComPro.GetMonthConverted(cmbMonth.Text);
                int intRow = 2;

                while (dreader.Read())
                {
                    oSheet.Cells[intRow, 1] = dreader["NIC_NO"].ToString();
                    oSheet.Cells[intRow, 2] = dreader["NAME"].ToString();
                    oSheet.Cells[intRow, 3] = dreader["INITIALS"].ToString().Replace(".", " ");
                    oSheet.Cells[intRow, 4] = dreader["EMP_NO"].ToString();
                    EMP_NO = Convert.ToInt16(dreader["EMP_NO"].ToString());
                    oSheet.Cells[intRow, 5] = dreader["TOTAL_EPF"].ToString();
                    oSheet.Cells[intRow, 6] = dreader["TOTAL_EMPLOYER"].ToString();
                    oSheet.Cells[intRow, 7] = dreader["TOTAL_EMPLOYEE"].ToString();
                    oSheet.Cells[intRow, 8] = dreader["PAY_VALUE"].ToString();

                    if (int.Parse(dreader["EPF_EXI_EMP"].ToString())==1)
                        oSheet.Cells[intRow, 9] = "N";
                    else
                        oSheet.Cells[intRow, 9] = "E";

                    oSheet.Cells[intRow, 10] = "D";
                    oSheet.Cells[intRow, 11] = "15729";

                    if (intMonth < 10)
                        oSheet.Cells[intRow, 12] = cmbYear.Text + "0" + intMonth.ToString();
                    else
                        oSheet.Cells[intRow, 12] = cmbYear.Text + intMonth.ToString();

                    oSheet.Cells[intRow, 13] = "1";

                    GetDaysWorked();
                    oSheet.Cells[intRow, 14] = Convert.ToDecimal(EMP_NODAYS.ToString());//.Replace(".", ""));
                    EMP_NODAYS = 0;
                    //oSheet.Cells[intRow, 14] = EMP_NODAYS.ToString().Replace(".", " ");
                    oSheet.Cells[intRow, 15] = dreader["GRADE"].ToString();
                    intRow++;


                    //NUMBER FORMAT
                    //oSheet.get_Range("A6", "A10000").NumberFormat = "0000";
                    //oSheet.get_Range("B6", "B10000").NumberFormat = "0000";
                    //oSheet.get_Range("C6", "C10000").NumberFormat = "109";
                    oSheet.get_Range("N1", "N4000").NumberFormat = "00.00";
                    oSheet.get_Range("O1", "O4000").NumberFormat = "000";
                    //oSheet.get_Range("F6", "F10000").NumberFormat = "00";
                    //oSheet.get_Range("G6", "G10000").NumberFormat = "00";
                    //oSheet.get_Range("H6", "H10000").NumberFormat = "0";
                    //oSheet.get_Range("I6", "I10000").NumberFormat = "000000";
                    //oSheet.get_Range("J6", "J10000").NumberFormat = "000000000000";
                    //oSheet.get_Range("L6", "L10000").NumberFormat = "7056";
                    //oSheet.get_Range("N6", "N10000").NumberFormat = "000000000000";
                    //oSheet.get_Range("R6", "R10000").NumberFormat = "yymmdd";
                }
                    oXL.Visible = true;
                    oXL.UserControl = true;
                    dreader.Close();

                    _conn.Close();
                MessageBox.Show("EPF Mnothly Individual Report Successfully Generated", "Report Generation");
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

        private void GetDaysWorked()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _ConnDW = obyConn.Connect();

            SqlCommand cmdPwd = new SqlCommand("SELECT UNITS FROM RE_VW_GET_UNITS_WORKED WHERE PAY_CAT_ID = '1' AND (EMP_NO = '" + EMP_NO + "') AND (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')", _ConnDW);
            //SqlCommand cmdPwd = new SqlCommand("SELECT UNITS FROM RE_VW_GET_UNITS_WORKED WHERE PAY_CAT_ID = '1' AND UNITS > '30' AND (EMP_NO = '" + EMP_NO + "') AND (PAY_YEAR = '" + cmbYear.Text + "') AND (SAL_MONTH = '" + cmbMonth.Text + "')", _ConnDW);
            SqlDataReader drReader = cmdPwd.ExecuteReader();
            while (drReader.Read())
            {
                
                NODAYS = Convert.ToDecimal(drReader["UNITS"].ToString());
                EMP_NODAYS = EMP_NODAYS + NODAYS;
            }
            drReader.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}