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
    public partial class frm_PayProcess : Form
    {
        CommonProfiles getComProfiles = new CommonProfiles();
        CalculateEPFETF getEPFETF = new CalculateEPFETF();

        private SqlConnection _conn;
        private int count = 0;
        private int slcount = 0;
        private int intYear = 0;
        private int intMonth = 0;
        private int Off_Basic = 0;
        private int Off_Allow = 0;
        private int Nor_Basic = 0;
        private int Nor_Allow = 0;
        private int EPF_EE = 0;
        private int EPF_ER = 0;
        private int ETF = 0;
        private int EPF_EMP_CON = 0;
        private decimal No_Pay_Rate;
        private decimal No_Pay_Value;
        string strSQL = null;
        decimal TAXFROM = 0, TAXTO = 0, PERCENTAGE = 0;
        decimal PAYEE_TAX_AMOUNT = 0;

        public frm_PayProcess()
        {
            InitializeComponent();
        }


        private void cmdPaySlip_Click(object sender, EventArgs e)
        {
            decimal intUnit = 0;
            //decimal dNoUnits = 0;
            decimal totVal = 0;
            string strSQL = null;
            string strEmp;
            string strCatID;
            bool hasRecord = false;

            decimal dTAXMeth;
            string strCalcMeth;
            decimal dInvVal = 0;
            decimal dUnitVal = 0;
            decimal dNoUnits = 0;
            decimal dTaxAmount = 0;

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            DataTable tblProcess = new DataTable();
            SqlCommand cmdProcess = new SqlCommand();
            SqlDataAdapter daProcess = new SqlDataAdapter();

            cmdProcess.Connection = _conn;
            cmdProcess.CommandText = "SELECT * FROM VW_GET_INVOICES WHERE (EARNINGS > 0) AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "') ORDER BY TEN_NO";
            cmdProcess.CommandType = CommandType.Text;

            daProcess.SelectCommand = cmdProcess;
            daProcess.Fill(tblProcess);

            DataTable tblSlips = new DataTable();
            SqlCommand cmdSlips = new SqlCommand("SELECT * FROM PAY_SLIPS_EARNINGS", _conn);
            SqlDataAdapter daSlips = new SqlDataAdapter();

            daSlips.SelectCommand = cmdSlips;
            daSlips.Fill(tblSlips);


            if (tblProcess.Rows.Count > 0)
            {
                foreach (DataRow dr in tblProcess.Rows)
                {
                    //   intYear = Convert.ToInt16(dr["IN_YEAR"].ToString());
                    //   intMonth = Convert.ToInt16(dr["IN_MONTH"].ToString());
                    strEmp = dr["EMP_NO"].ToString();
                    strCatID = "BASIC";// dr["PAY_CAT_ID"].ToString();

                    dInvVal = decimal.Parse(dr["EARNINGS"].ToString());

                    if (dr["EAR_ID"].ToString() == strCatID && dr["TAX_METHOD"] != DBNull.Value)
                    {
                        dTAXMeth = decimal.Parse(dr["TAX_METHOD"].ToString());
                        strCalcMeth = dr["TAX"].ToString();
                        dUnitVal = decimal.Parse(dr["UNIT_RATE"].ToString());
                        dNoUnits = decimal.Parse(dr["TAX_UNITS"].ToString());

                        if (strCalcMeth == "DAY")
                        {
                            dTaxAmount = dNoUnits * dTAXMeth; // dTaxMeth define as integer in Database level
                            if (dTaxAmount > 1000)
                                dTaxAmount = 1000;
                            dInvVal = decimal.Parse(dr["EARNINGS"].ToString()) - dTaxAmount;
                        }
                        else if (strCalcMeth == "BAS")
                        {
                            if (decimal.Parse(dr["EARNINGS"].ToString()) < 20000)
                            {
                                dTaxAmount = dTAXMeth;
                                dInvVal = decimal.Parse(dr["EARNINGS"].ToString()) - dTAXMeth;
                            }
                            else
                            {
                                dInvVal = decimal.Parse(dr["EARNINGS"].ToString());
                            }
                        }
                        else if (strCalcMeth == "PIE")
                        {
                            dTaxAmount = decimal.Parse(dr["EARNINGS"].ToString()) * (dTAXMeth / 100);
                            if (dTaxAmount > 1000)
                                dTaxAmount = 1000;
                            dInvVal = decimal.Parse(dr["EARNINGS"].ToString()) - dTaxAmount;
                        }
                    }
                    //else

                    try
                    {
                        // if (tblSlips.Rows.Count > 0)
                        //  {
                        /*  foreach (DataRow drSlips in tblSlips.Rows)
                          {
                              if ((Convert.ToInt16(drSlips["PAY_YEAR"].ToString()) == intYear) && (Convert.ToInt16(drSlips["PAY_MONTH"].ToString()) == intMonth) && drSlips["EMP_NO"].ToString() == strEmp && drSlips["EAR_ID"].ToString() == strCatID)
                              {
                                  richTextBox1.SelectedText = intYear.ToString() + "   " + intMonth.ToString() + "  " + strEmp + "\n";
                                  //  MessageBox.Show("Already Entered");
                                  hasRecord = true;
                              }
                          }
                          */
                        DataRow[] drSlips = tblSlips.Select("PAY_YEAR='" + intYear + "' AND PAY_MONTH='" + intMonth + "' AND EMP_NO='" + strEmp + "' AND EAR_ID='" + strCatID + "' ");
                        if (drSlips.Length == 0)
                        {
                            strSQL = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEmp + "','" + dr["EAR_ID"].ToString() + "','" + dInvVal + "','" + intYear + "','" + intMonth + "')";
                            SqlCommand objCmd = new SqlCommand(strSQL, _conn);
                            objCmd.ExecuteNonQuery();

                            if (dr["EAR_ID"].ToString() == strCatID && dTaxAmount > 0)
                            {
                                strSQL = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEmp + "','" + "TAX" + "','" + dTaxAmount + "','" + intYear + "','" + intMonth + "')";
                                SqlCommand objCmdDed = new SqlCommand(strSQL, _conn);
                                objCmdDed.ExecuteNonQuery();
                            }

                            SqlCommand cmdUpdate = new SqlCommand("UPDATE INVOICES SET STATUS = 0 WHERE (EMP_NO = '" + strEmp + "') AND (IN_YEAR = " + intYear + ") AND (IN_MONTH = " + intMonth + ")", _conn);
                            cmdUpdate.ExecuteNonQuery();
                            cmdUpdate.Dispose();

                            //SqlCommand cmdUpdateDUP = new SqlCommand("UPDATE INVOICES_DUPLICATE SET STATUS = 0 WHERE (EMP_NO = '" + strEmp + "') AND (IN_YEAR = " + intYear + ") AND (IN_MONTH = " + intMonth + ")", _conn);
                            //cmdUpdateDUP.ExecuteNonQuery();
                            //cmdUpdateDUP.Dispose();
                        }
                        //}
                        //else
                        //{
                        //    strSQL = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEmp + "','" + dr["EAR_ID"].ToString() + "','" + dr["EARNINGS"].ToString() + "','" + intYear + "','" + intMonth + "')";
                        //    SqlCommand objCmd = new SqlCommand(strSQL, _conn);
                        //    objCmd.ExecuteNonQuery();
                        //}*/


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed for the Processing Month or Data Entry Error", "Invoices");
                        return;
                    }
                }
                MessageBox.Show("Processing of Invoices Successfully Completed", "Invoices");
            }
            else
            {
                MessageBox.Show("No Invoices Entered to Process", "Invoices");
            }
            _conn.Close();

        }

        private void frm_PayProcess_Load(object sender, EventArgs e)
        {
            //intYear = getComProfiles.GetYear();
            //intMonth = getComProfiles.GetMonth();
            //lbl_Year.Text = intYear.ToString();
            //lbl_Month.Text = getComProfiles.GetMonthConverted(intMonth);

            PRODATE();
            intYear = int.Parse(lbl_Year.Text);
            intMonth = int.Parse(lbl_Month.Text);

        }

        private void PRODATE()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT PRO_DATE AS PRODATE, YEAR(PRO_DATE) AS PROYEAR, MONTH(PRO_DATE) AS PROMONTH FROM PRO_DATE";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_Year.Text = dreader["PROYEAR"].ToString();
                lbl_Month.Text = dreader["PROMONTH"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();

            _conn.Close();
        }


        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdProSec_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strSQL = "SELECT DISTINCT dbo.TENDER_MAIN.TEN_NO, dbo.TENDER_DETAILS.EMP_NO, dbo.TENDER_MAIN.SECURITY_DEPOSIT, dbo.TENDER_MAIN.SECDEP_LIMIT,  dbo.EMPLOYEES.TOT_SECDEP ";
            strSQL += "FROM dbo.TENDER_MAIN INNER JOIN dbo.TENDER_DETAILS ON dbo.TENDER_MAIN.TEN_NO = dbo.TENDER_DETAILS.TEN_NO INNER JOIN dbo.EMPLOYEES ON dbo.TENDER_DETAILS.EMP_NO = dbo.EMPLOYEES.EMP_NO ";
            strSQL += "WHERE (dbo.TENDER_MAIN.SECURITY_DEPOSIT > 0) AND (dbo.TENDER_MAIN.STATUS = 1) AND (dbo.TENDER_DETAILS.EMP_STATUS = 1)";
            strSQL += "AND (NOT (dbo.TENDER_DETAILS.EMP_NO IN (SELECT EMP_NO FROM SEC_DEP_SLIPS WHERE DED_ID = 'SECDEP' AND PAY_YEAR = '" + intYear + "' AND PAY_MONTH = '" + intMonth + "')))";

            DataTable tblSlips = new DataTable();
            SqlCommand cmdSlips = new SqlCommand(strSQL, _conn);
            SqlDataAdapter daSlips = new SqlDataAdapter();

            daSlips.SelectCommand = cmdSlips;
            daSlips.Fill(tblSlips);

            //================ Security Deposit ==========
            if (tblSlips.Rows.Count > 0)
            {
                foreach (DataRow drSlips in tblSlips.Rows)
                {
                    if (double.Parse(drSlips["TOT_SECDEP"].ToString()) < double.Parse(drSlips["SECDEP_LIMIT"].ToString()))
                    {
                        try
                        {
                            string strSQLPAYSLIP = "INSERT INTO SEC_DEP_SLIPS (TEN_NO,EMP_NO,DED_ID,DED_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + drSlips["TEN_NO"].ToString() + "','" + drSlips["EMP_NO"].ToString() + "','" + "SECDEP" + "','" + drSlips["SECURITY_DEPOSIT"].ToString() + "','" + intYear + "','" + intMonth + "')";
                            SqlCommand objCmd = new SqlCommand(strSQLPAYSLIP, _conn);
                            objCmd.ExecuteNonQuery();
                            objCmd.Dispose();

                            string strSECDEPUPDATE = "UPDATE EMPLOYEES SET TOT_SECDEP = " + (double.Parse(drSlips["SECURITY_DEPOSIT"].ToString()) + double.Parse(drSlips["TOT_SECDEP"].ToString()) + " WHERE EMP_NO = '" + drSlips["EMP_NO"].ToString() + "'");
                            SqlCommand objSECDEPUPDATE = new SqlCommand(strSECDEPUPDATE, _conn);
                            objSECDEPUPDATE.ExecuteNonQuery();
                            objSECDEPUPDATE.Dispose();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Already Processed for the Processing Month", "Security Deposit");
                            return;
                        }
                    }
                }
                MessageBox.Show("Processing of Security Deposits Completed Successfully", "Security Deposit");
            }
            else
            {
                MessageBox.Show("NO Security Deposits to Process", "Security Deposit");
            }
            _conn.Close();
        }

        private void cmd_ProEPF_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            decimal Ear_Tot_EPF = 0;
            decimal Ded_Tot_EPF = 0;
            decimal EPF_EMPLOYEE = 0;
            decimal EPF_EMPLOYER = 0;
            decimal ETF_EMPLOYER = 0;
            decimal Tot_Earnings = 0;
            decimal Tot_Deductions = 0;
            decimal Sec_Dep = 0;

            decimal Total_Earnings = 0;
            decimal Total_Deductions = 0;

            string strEmp;

            int intBatchNo = GetBatchNumber();

            //  SqlDataAdapter daEPFEMP = new SqlDataAdapter("SELECT * FROM PAY_SLIPS_EARNINGS WHERE  (EAR_ID = 'BASIC') AND PAY_YEAR='" + getComProfiles.GetYear() + "' AND PAY_MONTH='" + getComProfiles.GetMonth() + "' AND (STATUS=1)", _conn);

            SqlDataAdapter daEPFEMP = new SqlDataAdapter("SELECT dbo.PAY_SLIPS_EARNINGS.SEQ_NO, dbo.PAY_SLIPS_EARNINGS.EMP_NO, dbo.PAY_SLIPS_EARNINGS.PAY_CAT_ID," +
                      " dbo.PAY_SLIPS_EARNINGS.EAR_ID, dbo.PAY_SLIPS_EARNINGS.PAY_VALUE, dbo.PAY_SLIPS_EARNINGS.PAY_YEAR," +
                      " dbo.PAY_SLIPS_EARNINGS.PAY_MONTH, dbo.PAY_SLIPS_EARNINGS.STATUS, dbo.EMPLOYEES.EMPLOYEE_STATUS" +
                      " FROM dbo.PAY_SLIPS_EARNINGS INNER JOIN dbo.EMPLOYEES ON dbo.PAY_SLIPS_EARNINGS.EMP_NO = dbo.EMPLOYEES.EMP_NO" +
                      " WHERE (EAR_ID = 'BASIC') AND PAY_YEAR='" + getComProfiles.GetYear() + "' AND PAY_MONTH='" + getComProfiles.GetMonth() + "' AND (dbo.PAY_SLIPS_EARNINGS.STATUS=1)", _conn);
            SqlCommandBuilder cbEPFEMP = new SqlCommandBuilder(daEPFEMP);
            DataSet dsEPFEMP = new DataSet();

            daEPFEMP.Fill(dsEPFEMP, "PAY_SLIPS_EARNINGS");

            if (dsEPFEMP.Tables["PAY_SLIPS_EARNINGS"].Rows.Count == 0)
            {
                MessageBox.Show("Already Process or No data entered for the current period", "EPF and ETF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            prbEPF_ETF.Visible = true;
            prbEPF_ETF.Maximum = dsEPFEMP.Tables["PAY_SLIPS_EARNINGS"].Rows.Count;
            int X = 0;

            foreach (DataRow dr in dsEPFEMP.Tables["PAY_SLIPS_EARNINGS"].Rows)
            {
                EPF_EMPLOYEE = 0;
                EPF_EMPLOYER = 0;
                ETF_EMPLOYER = 0;

                strEmp = dr["EMP_NO"].ToString();

                // *********** Calculating Totals for Pay Slip
                Ear_Tot_EPF = getEPFETF.GET_Earnings(strEmp.ToString(), 1, 9);
                Ded_Tot_EPF = getEPFETF.GET_Deductions(strEmp.ToString(), 11, 14);
                Tot_Earnings = getEPFETF.GET_Earnings(strEmp.ToString(), 16, 24);
                Tot_Deductions = getEPFETF.GET_Deductions(strEmp.ToString(), 26, 39);
                Sec_Dep = getEPFETF.GET_SecDeposit(strEmp.ToString(), 33);
                Tot_Deductions += Sec_Dep;

                // *********** Calculating EPF and ETF
                if (dr["EMPLOYEE_STATUS"].ToString().Trim() != "Probation") // Calculating Salary for Probation Employee Change Requested 03-Jun-2010
                {
                    EPF_EMPLOYEE = getEPFETF.Calculate_EPF_Employee(Ear_Tot_EPF - Ded_Tot_EPF);
                    EPF_EMPLOYER = getEPFETF.Calculate_EPF_Employer(Ear_Tot_EPF - Ded_Tot_EPF);
                    ETF_EMPLOYER = getEPFETF.Calculate_ETF_Employer(Ear_Tot_EPF - Ded_Tot_EPF);
                }

                Total_Earnings = ((Ear_Tot_EPF + Tot_Earnings) - Ded_Tot_EPF);
                Total_Deductions = (Tot_Deductions + EPF_EMPLOYEE);

                // ******* Earnings total for EPF
                string TOT = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEmp.ToString() + "','" + "TOT" + "','" + Ear_Tot_EPF + "','" + intYear + "','" + intMonth + "')";
                SqlCommand cmdTOT = new SqlCommand(TOT, _conn);
                cmdTOT.ExecuteNonQuery();
                cmdTOT.Dispose();

                // ******* Total for EPF
                string TOTFOREPF = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEmp.ToString() + "','" + "TOT_EPF" + "','" + (Ear_Tot_EPF - Ded_Tot_EPF) + "','" + intYear + "','" + intMonth + "')";
                SqlCommand cmdTOTFOREPF = new SqlCommand(TOTFOREPF, _conn);
                cmdTOTFOREPF.ExecuteNonQuery();
                cmdTOTFOREPF.Dispose();

                // ******* EPF 8% for Employee
                string EPF = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO,DED_ID,DED_VALUE,DED_YEAR,DED_MONTH) VALUES ('" + strEmp.ToString() + "','" + "EPF" + "','" + EPF_EMPLOYEE + "','" + intYear + "','" + intMonth + "')";
                SqlCommand cmdEPF = new SqlCommand(EPF, _conn);
                cmdEPF.ExecuteNonQuery();
                cmdEPF.Dispose();

                // ******** Total Earnings
                string TOTEAR = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEmp.ToString() + "','" + "TOT_EAR" + "','" + Total_Earnings + "','" + intYear + "','" + intMonth + "')";
                SqlCommand cmdTOTEAR = new SqlCommand(TOTEAR, _conn);
                cmdTOTEAR.ExecuteNonQuery();
                cmdTOTEAR.Dispose();

                // ******* Total Deductions
                string TOTDED = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO,DED_ID,DED_VALUE,DED_YEAR,DED_MONTH) VALUES ('" + strEmp.ToString() + "','" + "TOTDED" + "','" + Total_Deductions + "','" + intYear + "','" + intMonth + "')";
                SqlCommand cmdTOTDED = new SqlCommand(TOTDED, _conn);
                cmdTOTDED.ExecuteNonQuery();
                cmdTOTDED.Dispose();

                // ******** Net Salary
                string NETSAL = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEmp.ToString() + "','" + "NETSAL" + "','" + (Total_Earnings - Total_Deductions) + "','" + intYear + "','" + intMonth + "')";
                SqlCommand cmdNETSAL = new SqlCommand(NETSAL, _conn);
                cmdNETSAL.ExecuteNonQuery();
                cmdNETSAL.Dispose();

                // ******* EPF 12% for Employer
                string EPF12 = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO,DED_ID,DED_VALUE,DED_YEAR,DED_MONTH) VALUES ('" + strEmp.ToString() + "','" + "EPF12" + "','" + EPF_EMPLOYER + "','" + intYear + "','" + intMonth + "')";
                SqlCommand cmdEPF12 = new SqlCommand(EPF12, _conn);
                cmdEPF12.ExecuteNonQuery();
                cmdEPF12.Dispose();

                // ******* ETF 3% for Employer
                string ETF = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO,DED_ID,DED_VALUE,DED_YEAR,DED_MONTH) VALUES ('" + strEmp.ToString() + "','" + "ETF" + "','" + ETF_EMPLOYER + "','" + intYear + "','" + intMonth + "')";
                SqlCommand cmdETF = new SqlCommand(ETF, _conn);
                cmdETF.ExecuteNonQuery();
                cmdETF.Dispose();

                // dr["STATUS"] = 0;
                // daEPFEMP.Update(dsEPFEMP, "PAY_SLIPS_EARNINGS");                

                string strUpdate = "UPDATE PAY_SLIPS_EARNINGS SET STATUS = 0, BATCH_NO = '" + intBatchNo + "' WHERE (EMP_NO = '" + strEmp + "') AND (PAY_YEAR = '" + getComProfiles.GetYear() + "') AND (PAY_MONTH = '" + getComProfiles.GetMonth() + "')";
                SqlCommand cmdUpdate = new SqlCommand(strUpdate, _conn);
                cmdUpdate.ExecuteNonQuery();
                cmdUpdate.Dispose();

                prbEPF_ETF.Value = X;
                X++;
            }

            string strComPro = "UPDATE COMMON_PROFILES SET BATCH_NO = '" + intBatchNo + "'";
            SqlCommand cmdComPro = new SqlCommand(strComPro, _conn);
            cmdComPro.ExecuteNonQuery();
            cmdComPro.Dispose();
            _conn.Close();
            MessageBox.Show("Calculation of EPF and ETF Completed Successfully", "EPF and ETF");
        }

        private void TAXSTART()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT TAXFROM FROM PAYEE_TAX WHERE SEQ_NO = 1";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                TAXFROM = decimal.Parse(dreader["TAXFROM"].ToString());
                dreader.Dispose();
                return;
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _conn.Close();
        }

        private void TAX()
        {
            TAXSTART();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT TAXTO, PERCENTAGE FROM PAYEE_TAX WHERE TAXTO >= '" + PAYEE_TAX_AMOUNT + "' ORDER BY SEQ_NO";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                TAXTO = decimal.Parse(dreader["TAXTO"].ToString());

                if (PAYEE_TAX_AMOUNT >= TAXFROM)
                {
                    PERCENTAGE = decimal.Parse(dreader["PERCENTAGE"].ToString());
                    dreader.Dispose();
                    return;
                }
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _conn.Close();
        }


        private void btnPay_Tax_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strPayTax = ("SELECT PAY_VALUE, EMP_NO FROM PAY_SLIPS_EARNINGS WHERE (STATUS = 1) AND (PAY_MONTH = '" + lbl_Month.Text + "') AND (PAY_YEAR = '" + lbl_Year.Text + "') AND (EAR_ID = 'GROSS')");

            DataTable tblPayTax = new DataTable();
            SqlCommand cmdPayTax = new SqlCommand(strPayTax, _conn);
            SqlDataAdapter daPayTax = new SqlDataAdapter();

            daPayTax.SelectCommand = cmdPayTax;
            daPayTax.Fill(tblPayTax);

            if (tblPayTax.Rows.Count > 0)
            {
                foreach (DataRow drPAYTAX in tblPayTax.Rows)
                {
                   
                        PAYEE_TAX_AMOUNT = decimal.Parse(drPAYTAX["PAY_VALUE"].ToString());
                        
                        TAX();

                        if (PAYEE_TAX_AMOUNT >= TAXFROM)
                        {
                            decimal MONTHLY_TAX = (PAYEE_TAX_AMOUNT / 100) * PERCENTAGE;
                            
                            try
                            {
                                string strPAYTAX = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO,DED_ID,DED_VALUE,DED_YEAR,DED_MONTH) VALUES ('" + drPAYTAX["EMP_NO"].ToString() + "','" + "PAYTAX" + "','" + MONTHLY_TAX + "','" + intYear + "','" + intMonth + "')";
                                SqlCommand cmdPayTaxProcess = new SqlCommand(strPAYTAX, _conn);
                                cmdPayTaxProcess.ExecuteNonQuery();
                                cmdPayTaxProcess.Dispose();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Already Processed for the Processing Month", "Payee TAX Information");
                                return;
                            }
                        }
                }
                MessageBox.Show("Processing of Payee TAX Completed Successfully", "Payee TAX Information");
            }
            else
            {
                MessageBox.Show("NO Payee Tax data to Process", "Payee Tax");
            }
            _conn.Close();
            daPayTax.Dispose();

        }

        private void btn_AdjPro_Click(object sender, EventArgs e)
        {
            ADJ_EAR();
            ADJ_DED();
            ADJ_DED_NOPAY();
            UP_DUP();
        }

        private void UP_DUP()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strAdj = ("SELECT * FROM ADJUSTMENTS_DUPLICATE WHERE (STATUS = 1) AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')");

            DataTable tblAdj = new DataTable();
            SqlCommand cmdAdj = new SqlCommand(strAdj, _conn);
            SqlDataAdapter daAdj = new SqlDataAdapter();

            daAdj.SelectCommand = cmdAdj;
            daAdj.Fill(tblAdj);

            string UP_strAdjINS = "UPDATE ADJUSTMENTS_DUPLICATE SET STATUS = 0 WHERE (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')";
            SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
            Up_cmdAdjINS.ExecuteNonQuery();
            Up_cmdAdjINS.Dispose();

            _conn.Close();
            cmdAdj.Dispose();
        }

        private void ADJ_EAR()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strAdj = ("SELECT SEQ_NO, EMP_NO, CAT_ID, DESCRIPTION, AMOUNT, STATUS, IN_YEAR, IN_MONTH FROM VW_ADJUSTMENTS_EAR WHERE (CAT_ID <> 'TRV_ALW' )AND (STATUS = 1) AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')");

            DataTable tblAdj = new DataTable();
            SqlCommand cmdAdj = new SqlCommand(strAdj, _conn);
            SqlDataAdapter daAdj = new SqlDataAdapter();

            daAdj.SelectCommand = cmdAdj;
            daAdj.Fill(tblAdj);

            if (tblAdj.Rows.Count > 0)
            {
                foreach (DataRow drAdj in tblAdj.Rows)
                {
                    try
                    {
                        string strAdjINS = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO, EAR_ID, PAY_VALUE, PAY_YEAR, PAY_MONTH) VALUES ('" + drAdj["EMP_NO"].ToString() + "','" + drAdj["CAT_ID"].ToString() + "','" + drAdj["AMOUNT"].ToString() + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand cmdAdjINS = new SqlCommand(strAdjINS, _conn);
                        cmdAdjINS.ExecuteNonQuery();
                        cmdAdjINS.Dispose();

                        string UP_strAdjINS = "UPDATE ADJUSTMENTS SET STATUS = 0 WHERE (EMP_NO = '" + drAdj["EMP_NO"].ToString() + "') AND (CAT_ID = '" + drAdj["CAT_ID"].ToString() + "') AND (STATUS = 1) AND (AMOUNT = '" + drAdj["AMOUNT"].ToString() + "') AND (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "')";
                        SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
                        Up_cmdAdjINS.ExecuteNonQuery();
                        Up_cmdAdjINS.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed for the Processing Month", "Adjustment Process Information");
                        return;
                    }
                }
                MessageBox.Show("Processing of Earnings Completed Successfully", "Adjustments - Earnings");
            }
            else
            {
                MessageBox.Show("NO Earnings to Process", "Adjustments - Earnings");
            }

            _conn.Close();
            cmdAdj.Dispose();
        }

        private void ADJ_DED()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strAdj = ("SELECT SEQ_NO, EMP_NO, CAT_ID, DESCRIPTION, AMOUNT, STATUS, ADJ_DATE, IN_YEAR, IN_MONTH FROM VW_ADJUSTMENTS_DED WHERE CAT_ID <> 'NOP' AND (STATUS = 1) AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')");

            DataTable tblAdj = new DataTable();
            SqlCommand cmdAdj = new SqlCommand(strAdj, _conn);
            SqlDataAdapter daAdj = new SqlDataAdapter();

            daAdj.SelectCommand = cmdAdj;
            daAdj.Fill(tblAdj);

            if (tblAdj.Rows.Count > 0)
            {
                foreach (DataRow drAdj in tblAdj.Rows)
                {
                    try
                    {
                        string strAdjINS = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO, DED_ID, DED_VALUE, DED_YEAR, DED_MONTH, TRANS_DATE) VALUES ('" + drAdj["EMP_NO"].ToString() + "','" + drAdj["CAT_ID"].ToString() + "','" + drAdj["AMOUNT"].ToString() + "','" + intYear + "','" + intMonth + "','" + drAdj["ADJ_DATE"].ToString() + "')";
                        SqlCommand cmdAdjINS = new SqlCommand(strAdjINS, _conn);
                        cmdAdjINS.ExecuteNonQuery();
                        cmdAdjINS.Dispose();

                        string UP_strAdjINS = "UPDATE ADJUSTMENTS SET STATUS = 0 WHERE (EMP_NO = '" + drAdj["EMP_NO"].ToString() + "') AND (CAT_ID = '" + drAdj["CAT_ID"].ToString() + "') AND (STATUS = 1) AND (AMOUNT = '" + drAdj["AMOUNT"].ToString() + "') AND (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "')";
                        SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
                        Up_cmdAdjINS.ExecuteNonQuery();
                        Up_cmdAdjINS.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed for the Processing Month", "Adjustment Process Information");
                        return;
                    }
                }
                MessageBox.Show("Processing of Deductions Completed Successfully", "Adjustments -> Deductions");
            }
            else
            {
                MessageBox.Show("NO Deductions to Process", "Adjustments -> Deductions");
            }

            _conn.Close();
            cmdAdj.Dispose();
        }

        private void ADJ_DED_NOPAY()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strNoPay = ("SELECT dbo.ADJUSTMENTS.EMP_NO, dbo.ADJUSTMENTS.CAT_ID, dbo.DEDUCTIONS.DESCRIPTION, dbo.ADJUSTMENTS.AMOUNT," +
                      " dbo.ADJUSTMENTS.STATUS, dbo.ADJUSTMENTS.SEQ_NO, dbo.EMPLOYEES.EMP_CATEGORY, dbo.EMPLOYEES.BASIC_SALARY" +
                      " FROM dbo.DEDUCTIONS INNER JOIN dbo.ADJUSTMENTS ON dbo.DEDUCTIONS.DED_ID = dbo.ADJUSTMENTS.CAT_ID INNER JOIN" +
                      " dbo.EMPLOYEES ON dbo.ADJUSTMENTS.EMP_NO = dbo.EMPLOYEES.EMP_NO WHERE (dbo.ADJUSTMENTS.STATUS = 1) AND (dbo.ADJUSTMENTS.CAT_ID = 'NOP') AND (dbo.ADJUSTMENTS.IN_YEAR = '" + intYear + "') AND (dbo.ADJUSTMENTS.IN_MONTH = '" + intMonth + "')");

            DataTable dtNoPay = new DataTable();
            SqlCommand cmdNoPay = new SqlCommand(strNoPay, _conn);
            SqlDataAdapter daNoPay = new SqlDataAdapter();

            daNoPay.SelectCommand = cmdNoPay;
            daNoPay.Fill(dtNoPay);

            if (dtNoPay.Rows.Count > 0)
            {
                foreach (DataRow dr in dtNoPay.Rows)
                {
                    try
                    {
                        if ((int.Parse(dr["EMP_CATEGORY"].ToString()) == 1) || (int.Parse(dr["EMP_CATEGORY"].ToString()) == 2))
                            No_Pay_Rate = decimal.Parse(dr["BASIC_SALARY"].ToString()) / 30;
                        else if (int.Parse(dr["EMP_CATEGORY"].ToString()) == 0)
                            No_Pay_Rate = decimal.Parse(dr["BASIC_SALARY"].ToString()) / 20;

                        No_Pay_Value = (decimal.Parse(dr["AMOUNT"].ToString()) * No_Pay_Rate);

                        string strAdjINS = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO, DED_ID, DED_VALUE, DED_YEAR, DED_MONTH) VALUES ('" + dr["EMP_NO"].ToString() + "','" + dr["CAT_ID"].ToString() + "','" + No_Pay_Value + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand cmdAdjINS = new SqlCommand(strAdjINS, _conn);
                        cmdAdjINS.ExecuteNonQuery();
                        cmdAdjINS.Dispose();

                        string UP_strAdjINS = "UPDATE ADJUSTMENTS SET STATUS = 0 WHERE (EMP_NO = '" + dr["EMP_NO"].ToString() + "') AND (CAT_ID = '" + dr["CAT_ID"].ToString() + "') AND (STATUS = 1) AND (SEQ_NO = '" + dr["SEQ_NO"].ToString() + "')";
                        SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
                        Up_cmdAdjINS.ExecuteNonQuery();
                        Up_cmdAdjINS.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed for the Employee Number : " + dr["EMP_NO"].ToString(), "No-Pay Calculations", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("Processing of No-Pay details Completed Successfully", "Adjustments -> No-Pay");
            }
            else
            {
                MessageBox.Show("NO No-Pay Details to Process", "Adjustments -> No-Pay");
            }
            _conn.Close();
            dtNoPay.Dispose();
            daNoPay.Dispose();
            cmdNoPay.Dispose();
        }


        private void btn_PeriodChange_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdChangePeriod = new SqlCommand();
            cmdChangePeriod.CommandText = "CHANGE_PROCESSING_PERIOD";
            cmdChangePeriod.Connection = _conn;
            cmdChangePeriod.CommandType = CommandType.StoredProcedure;

            cmdChangePeriod.Parameters.Add("@NP_YEAR", "");
            cmdChangePeriod.Parameters.Add("@NP_MONTH", "");
            cmdChangePeriod.ExecuteNonQuery();
            cmdChangePeriod.Dispose();
            _conn.Close();

        }

        private void btn_Process_OT_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdTenMain = new SqlCommand("SELECT EMP_NO, AMOUNT FROM ADJUSTMENTS WHERE (CAT_ID = 'OT') AND (STATUS = 1) AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')", _conn);
            SqlDataReader dreader = cmdTenMain.ExecuteReader();
            dreader.Read();
            if (dreader.HasRows == true)
            {
                decimal BAMNT = decimal.Parse(dreader["AMOUNT"].ToString());
                string strEMP = dreader["EMP_NO"].ToString();

                dreader.Dispose();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEMP + "','OT','" + BAMNT + "','" + intYear + "','" + intMonth + "')";
                cmdsql1.ExecuteNonQuery();

                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE ADJUSTMENTS SET STATUS = 0 WHERE (CAT_ID = 'OT') AND (EMP_NO = '" + strEMP + "') AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')";
                cmdsql2.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("NO OT Amount Detail to Process", "OT Amounts Process");
                return;
            }

            MessageBox.Show("Office Employee OT Amount Calculations are Completed Successfully", "Office OT Amount Process");

            dreader.Dispose();
            _conn.Close();
        }

        private void UP_DUP_OFF()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strAdj = ("SELECT * FROM OVER_TIME_RATES_OFFICE_DUPLICATE WHERE (STATUS = 1) AND (OT_YEAR = '" + intYear + "') AND (OT_MONTH = '" + intMonth + "')");

            DataTable tblAdj = new DataTable();
            SqlCommand cmdAdj = new SqlCommand(strAdj, _conn);
            SqlDataAdapter daAdj = new SqlDataAdapter();

            daAdj.SelectCommand = cmdAdj;
            daAdj.Fill(tblAdj);

            string UP_strAdjINS = "UPDATE OVER_TIME_RATES_OFFICE_DUPLICATE SET STATUS = 0 WHERE (OT_YEAR = '" + intYear + "') AND (OT_MONTH = '" + intMonth + "')";
            SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
            Up_cmdAdjINS.ExecuteNonQuery();
            Up_cmdAdjINS.Dispose();

            _conn.Close();
            cmdAdj.Dispose();
        }

        private void UP_DUP_TEN()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strAdj = ("SELECT * FROM OVER_TIME_RATES_DUPLICATE WHERE (STATUS = 1) AND (OT_YEAR = '" + intYear + "') AND (OT_MONTH = '" + intMonth + "')");

            DataTable tblAdj = new DataTable();
            SqlCommand cmdAdj = new SqlCommand(strAdj, _conn);
            SqlDataAdapter daAdj = new SqlDataAdapter();

            daAdj.SelectCommand = cmdAdj;
            daAdj.Fill(tblAdj);

            string UP_strAdjINS = "UPDATE OVER_TIME_RATES_DUPLICATE SET STATUS = 0 WHERE (OT_YEAR = '" + intYear + "') AND (OT_MONTH = '" + intMonth + "')";
            SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
            Up_cmdAdjINS.ExecuteNonQuery();
            Up_cmdAdjINS.Dispose();

            _conn.Close();
            cmdAdj.Dispose();
        }

        private void OT_OFF_EMP()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strAdj = ("SELECT * FROM VW_OVER_TIME_OFFICE");

            DataTable tblAdj = new DataTable();
            SqlCommand cmdAdj = new SqlCommand(strAdj, _conn);
            SqlDataAdapter daAdj = new SqlDataAdapter();

            daAdj.SelectCommand = cmdAdj;
            daAdj.Fill(tblAdj);

            if (tblAdj.Rows.Count > 0)
            {
                foreach (DataRow drAdj in tblAdj.Rows)
                {
                    try
                    {
                        decimal TotalValue = 0;
                        decimal Rate = 0;
                        decimal TotalAmount = 0;

                        TotalValue = decimal.Parse(drAdj["OT_VALUE"].ToString());
                        Rate = decimal.Parse(drAdj["BASIC_SALARY"].ToString());

                        if (TotalValue > 0)
                        {
                            TotalAmount = TotalValue * (Rate / 160);
                        }

                        string strAdjINS = "INSERT INTO PAY_SLIPS_EARNINGS  (EMP_NO, EAR_ID, PAY_VALUE, PAY_YEAR, PAY_MONTH) VALUES ('" + drAdj["EMP_NO"].ToString() + "', 'OT_OFF','" + TotalAmount + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand cmdAdjINS = new SqlCommand(strAdjINS, _conn);
                        cmdAdjINS.ExecuteNonQuery();
                        cmdAdjINS.Dispose();

                        string UP_strAdjINS = "UPDATE OVER_TIME_RATES_OFFICE SET STATUS = 0 WHERE (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "') AND (STATUS = 1) AND (EMP_NO = '" + drAdj["EMP_NO"].ToString() + "')";
                        SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
                        Up_cmdAdjINS.ExecuteNonQuery();
                        Up_cmdAdjINS.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed Over Time for the Processing Month", "Over Time Process Information");
                        return;
                    }
                }
                MessageBox.Show("Processing of Over Time for Office Employee Completed Successfully", "Over Time -> Office");
            }
            else
                MessageBox.Show("NO Records to Process Data for Office Employee OT Calculation", "Office Employee - OT");
            _conn.Close();
            cmdAdj.Dispose();
        }

        private void OT_TEN_EMP()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            // =============== Normal and Halfday Method of Calculating OT ===================
            string strAdj = ("SELECT * FROM VW_OVER_TIME WHERE OT_YEAR='" + intYear + "' AND OT_MONTH='" + intMonth + "'");

            DataTable tblAdj = new DataTable();
            SqlCommand cmdAdj = new SqlCommand(strAdj, _conn);
            SqlDataAdapter daAdj = new SqlDataAdapter();

            daAdj.SelectCommand = cmdAdj;
            daAdj.Fill(tblAdj);

            if (tblAdj.Rows.Count == 0)
            {
                MessageBox.Show("NO Records to Process Data for NORMAL or Halfday OT Calculation", "Tender Employee - Normal and Halfday OT");

            }
            else
            {
                foreach (DataRow drAdj in tblAdj.Rows)
                {
                    try
                    {
                        decimal TotalValue = 0;
                        decimal Rate = 0;
                        decimal TotalAmount = 0;

                        TotalValue = decimal.Parse(drAdj["OT_VALUE"].ToString());
                        Rate = decimal.Parse(drAdj["RATE"].ToString());

                        if (TotalValue > 0)
                        {
                            TotalAmount = TotalValue * Rate;
                        }

                        string strAdjINS = "INSERT INTO PAY_SLIPS_EARNINGS  (EMP_NO, EAR_ID, PAY_VALUE, PAY_YEAR, PAY_MONTH) VALUES ('" + drAdj["EMP_NO"].ToString() + "', 'OT_TEN','" + TotalAmount + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand cmdAdjINS = new SqlCommand(strAdjINS, _conn);
                        cmdAdjINS.ExecuteNonQuery();
                        cmdAdjINS.Dispose();

                        string UP_strAdjINS = "UPDATE OVER_TIME_RATES SET STATUS = 0 WHERE (SEQ_NO = " + drAdj["SEQ_NO"].ToString() + ") AND (STATUS = 1) AND (EMP_NO = '" + drAdj["EMP_NO"].ToString() + "')";
                        SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
                        Up_cmdAdjINS.ExecuteNonQuery();
                        Up_cmdAdjINS.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed Over Time for the Processing Month", "Over Time Process Information");
                        return;
                    }
                }
                MessageBox.Show("Processing of Over Time for Normal and Halfday Employee Completed Successfully", "Over Time -> Tender");
            }
            cmdAdj.Dispose();


            // =============== Sub Location Method of Calculating OT ===================
            string strSubLoc = ("SELECT * FROM VW_OVERTIME_SUB_LOCATION");

            DataTable tblSubLoc = new DataTable();
            SqlCommand cmdSubLoc = new SqlCommand(strSubLoc, _conn);
            SqlDataAdapter daSubLoc = new SqlDataAdapter();

            daSubLoc.SelectCommand = cmdSubLoc;
            daSubLoc.Fill(tblSubLoc);

            if (tblSubLoc.Rows.Count == 0)
            {
                MessageBox.Show("NO Records to Process Data for Sub Location OT Calculation", "Tender Employee - Sublocation OT");

            }
            else
            {
                foreach (DataRow drSubLoc in tblSubLoc.Rows)
                {
                    try
                    {
                        string strSubLocINS = "INSERT INTO PAY_SLIPS_EARNINGS  (EMP_NO, EAR_ID, PAY_VALUE, PAY_YEAR, PAY_MONTH) VALUES ('" + drSubLoc["EMP_NO"].ToString() + "', 'OT_TEN','" + drSubLoc["TOT_OT"].ToString() + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand cmdSubLocINS = new SqlCommand(strSubLocINS, _conn);
                        cmdSubLocINS.ExecuteNonQuery();
                        cmdSubLocINS.Dispose();

                        string UP_strSubLocINS = "UPDATE OVER_TIME_RATES SET STATUS = 0 WHERE (SEQ_NO = " + drSubLoc["SEQ_NO"].ToString() + ") AND (STATUS = 1) AND (EMP_NO = '" + drSubLoc["EMP_NO"].ToString() + "')";
                        SqlCommand Up_cmdSubLocINS = new SqlCommand(UP_strSubLocINS, _conn);
                        Up_cmdSubLocINS.ExecuteNonQuery();
                        Up_cmdSubLocINS.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed Over Time for the Processing Month", "Over Time Process Information -- SUB LOCATION");
                        //return;
                    }
                }
                MessageBox.Show("Processing of Over Time for Sublocation Tender Employee Completed Successfully", "Over Time -> Tender --> Sub Location");

            }
            cmdSubLoc.Dispose();

            // =============== Duration Method of Calculating OT ===================
            string strDuration = ("SELECT * FROM VW_OVERTIME_DURATION");

            DataTable tblDuration = new DataTable();
            SqlCommand cmdDuration = new SqlCommand(strDuration, _conn);
            SqlDataAdapter daDuration = new SqlDataAdapter();

            daDuration.SelectCommand = cmdDuration;
            daDuration.Fill(tblDuration);

            if (tblDuration.Rows.Count == 0)
            {
                MessageBox.Show("NO Records to Process Data for Duration wise OT Calculation", "Tender Employee - Duration OT");

            }
            else
            {
                foreach (DataRow drDuration in tblDuration.Rows)
                {
                    try
                    {
                        string strDurationINS = "INSERT INTO PAY_SLIPS_EARNINGS  (EMP_NO, EAR_ID, PAY_VALUE, PAY_YEAR, PAY_MONTH) VALUES ('" + drDuration["EMP_NO"].ToString() + "', 'OT_TEN','" + drDuration["TOT_OT"].ToString() + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand cmdDurationINS = new SqlCommand(strDurationINS, _conn);
                        cmdDurationINS.ExecuteNonQuery();
                        cmdDurationINS.Dispose();

                        string UP_strDurationINS = "UPDATE OVER_TIME_RATES SET STATUS = 0 WHERE ((STATUS = 1) AND (EMP_NO = '" + drDuration["EMP_NO"].ToString() + "') AND (OT_YEAR = '" + drDuration["OT_YEAR"].ToString() + "') AND (OT_MONTH = '" + drDuration["OT_MONTH"].ToString() + "'))";
                        SqlCommand Up_cmdDurationINS = new SqlCommand(UP_strDurationINS, _conn);
                        Up_cmdDurationINS.ExecuteNonQuery();
                        Up_cmdDurationINS.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed Over Time for the Processing Month", "Over Time Process Information -- DURATION");
                        // return;
                    }
                }
                MessageBox.Show("Processing of Over Time for Duration Tender Employee Completed Successfully", "Over Time -> Tender --> Duration");

            }
            cmdDuration.Dispose();
            _conn.Close();

        }

        //################################# Loan Process #################################

        private void btn_Loan_Process_Click(object sender, EventArgs e)
        {
            Loan_Process();
        }

        private void Loan_Process()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strAdj = ("SELECT * FROM VW_LOAN_PROCESS WHERE LOAN_ID=1 AND BAL_INST > 0");

            DataTable tblAdj = new DataTable();
            SqlCommand cmdAdj = new SqlCommand(strAdj, _conn);
            SqlDataAdapter daAdj = new SqlDataAdapter();

            daAdj.SelectCommand = cmdAdj;
            daAdj.Fill(tblAdj);

            if (tblAdj.Rows.Count > 0)
            {
                foreach (DataRow drAdj in tblAdj.Rows)
                {
                    try
                    {
                        decimal BalanceAmount = 0;
                        decimal Rate = 0;
                        decimal InterestAmount = 0;
                        decimal InstallementAmount = 0;

                        BalanceAmount = decimal.Parse(drAdj["BAL_AMOUNT"].ToString());
                        Rate = decimal.Parse(drAdj["INTEREST"].ToString());

                        if (BalanceAmount > 0)
                        {
                            InterestAmount = ((BalanceAmount * Rate) / 100) / 12;
                        }

                        InstallementAmount = (decimal.Parse(drAdj["LOAN_AMOUNT"].ToString()) / int.Parse(drAdj["NO_INST"].ToString()));

                        string strAdjINS = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO, DED_ID, DED_VALUE, DED_YEAR, DED_MONTH) VALUES ('" + drAdj["EMP_NO"].ToString() + "', '" + drAdj["DED_ID"].ToString() + "','" + InstallementAmount + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand cmdAdjINS = new SqlCommand(strAdjINS, _conn);
                        cmdAdjINS.ExecuteNonQuery();
                        cmdAdjINS.Dispose();

                        string strLoanInterest = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO, DED_ID, DED_VALUE, DED_YEAR, DED_MONTH) VALUES ('" + drAdj["EMP_NO"].ToString() + "', 'HSLINT','" + InterestAmount + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand cmdLoanInterest = new SqlCommand(strLoanInterest, _conn);
                        cmdLoanInterest.ExecuteNonQuery();
                        cmdLoanInterest.Dispose();

                        string str_AdjINS = "UPDATE LOAN_DETAILS SET BAL_AMOUNT = '" + (BalanceAmount - InstallementAmount) + "', BAL_INST = BAL_INST - 1 WHERE (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "')";
                        SqlCommand cmd_AdjINS = new SqlCommand(str_AdjINS, _conn);
                        cmd_AdjINS.ExecuteNonQuery();
                        cmd_AdjINS.Dispose();

                        string strUpINS = "SELECT BAL_INST FROM LOAN_DETAILS WHERE (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "')";
                        SqlCommand cmdUpINS = new SqlCommand(strUpINS, _conn);
                        SqlDataReader drUpINS = cmdUpINS.ExecuteReader();
                        drUpINS.Read();
                        cmdUpINS.Dispose();

                        if (int.Parse(drUpINS["BAL_INST"].ToString()) == 0)
                        {
                            drUpINS.Close();
                            string UP_strAdjINS = "UPDATE LOAN_DETAILS SET STATUS = 0 WHERE (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "')";
                            SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
                            Up_cmdAdjINS.ExecuteNonQuery();
                            Up_cmdAdjINS.Dispose();
                        }
                        cmdAdjINS.Dispose();
                        cmdAdjINS.Dispose();
                        cmdLoanInterest.Dispose();
                        cmd_AdjINS.Dispose();
                        cmdUpINS.Dispose();
                        drUpINS.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed Loans for the Processing Month", "Loan Process Information");
                        return;
                    }

                }
                MessageBox.Show("Processing of Loan Details Completed Successfully", "Loan Details");
            }
            else
                MessageBox.Show("NO Records to Process Data for Loan Details", "Loan Details");

            _conn.Close();
            cmdAdj.Dispose();
            daAdj.Dispose();
            tblAdj.Dispose();
        }

        private void btnFESADVANCE_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strAdj = ("SELECT * FROM VW_LOAN_PROCESS WHERE LOAN_ID = 2 AND BAL_INST > 0");

            DataTable tblAdj = new DataTable();
            SqlCommand cmdAdj = new SqlCommand(strAdj, _conn);
            SqlDataAdapter daAdj = new SqlDataAdapter();

            daAdj.SelectCommand = cmdAdj;
            daAdj.Fill(tblAdj);

            if (tblAdj.Rows.Count > 0)
            {
                foreach (DataRow drAdj in tblAdj.Rows)
                {
                    try
                    {
                        decimal BalanceAmount = 0;
                        decimal Rate = 0;
                        decimal InterestAmount = 0;
                        decimal InstallementAmount = 0;

                        BalanceAmount = decimal.Parse(drAdj["BAL_AMOUNT"].ToString());

                        InstallementAmount = (decimal.Parse(drAdj["LOAN_AMOUNT"].ToString()) / int.Parse(drAdj["NO_INST"].ToString()));

                        string strAdjINS = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO, DED_ID, DED_VALUE, DED_YEAR, DED_MONTH) VALUES ('" + drAdj["EMP_NO"].ToString() + "', '" + drAdj["DED_ID"].ToString() + "','" + InstallementAmount + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand cmdAdjINS = new SqlCommand(strAdjINS, _conn);
                        cmdAdjINS.ExecuteNonQuery();
                        cmdAdjINS.Dispose();

                        string str_AdjINS = "UPDATE LOAN_DETAILS SET BAL_AMOUNT = '" + (BalanceAmount - InstallementAmount) + "', BAL_INST = BAL_INST - 1 WHERE (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "')";
                        SqlCommand cmd_AdjINS = new SqlCommand(str_AdjINS, _conn);
                        cmd_AdjINS.ExecuteNonQuery();
                        cmd_AdjINS.Dispose();

                        string strUpINS = "SELECT BAL_INST FROM LOAN_DETAILS WHERE (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "')";
                        SqlCommand cmdUpINS = new SqlCommand(strUpINS, _conn);
                        SqlDataReader drUpINS = cmdUpINS.ExecuteReader();
                        drUpINS.Read();
                        cmdUpINS.Dispose();

                        if (int.Parse(drUpINS["BAL_INST"].ToString()) == 0)
                        {
                            drUpINS.Close();
                            string UP_strAdjINS = "UPDATE LOAN_DETAILS SET STATUS = 0 WHERE (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "')";
                            SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
                            Up_cmdAdjINS.ExecuteNonQuery();
                            Up_cmdAdjINS.Dispose();
                        }
                        cmdAdjINS.Dispose();
                        cmdAdjINS.Dispose();
                        cmd_AdjINS.Dispose();
                        cmdUpINS.Dispose();
                        drUpINS.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed Festival Advance for the Processing Month", "Festival Advance Information");
                        return;
                    }

                }
                MessageBox.Show("Processing of Festival Advance Completed Successfully", "Festival Advance");
            }
            else
                MessageBox.Show("NO Records to Process Data for Festival Advance", "Festival Advance");

            _conn.Close();
            cmdAdj.Dispose();
            daAdj.Dispose();
            tblAdj.Dispose();
        }

        private void btn_Travelling_Click(object sender, EventArgs e)
        {
            Travelling_Allowance();
        }

        private void Travelling_Allowance()
        {
            decimal TravallingAllowance = 0;
            decimal No_of_Days = 0;
            decimal TotalAllowance = 0;
            string strEmpNo;
            string str_SQL = null;

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            DataTable tblDays = new DataTable();
            SqlCommand cmdDays = new SqlCommand("SELECT * FROM VW_CALC_TRAV_ALLOWANCE WHERE (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')", _conn);
            SqlDataAdapter daDays = new SqlDataAdapter();

            daDays.SelectCommand = cmdDays;
            daDays.Fill(tblDays);

            if (tblDays.Rows.Count == 0)
            {
                MessageBox.Show("No Data to Process", "Travelling Allowances");
                return;
            }
            foreach (DataRow dr in tblDays.Rows)
            {
                strEmpNo = dr["EMP_NO"].ToString();
                TravallingAllowance = Convert.ToDecimal(dr["TRAVELLING_ALLOWANCE"].ToString());
                No_of_Days = Convert.ToDecimal(dr["AMOUNT"].ToString());
                TotalAllowance = TravallingAllowance * No_of_Days;

                try
                {
                    str_SQL = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO, EAR_ID, PAY_VALUE, PAY_YEAR, PAY_MONTH) VALUES ('" + strEmpNo + "', 'TRV_ALW', '" + TotalAllowance + "', '" + intYear + "', '" + intMonth + "')";
                    SqlCommand objCmd = new SqlCommand(str_SQL, _conn);
                    objCmd.ExecuteNonQuery();
                    objCmd.Dispose();

                    SqlCommand cmdUpdate = new SqlCommand("UPDATE ADJUSTMENTS SET STATUS = 0 WHERE (EMP_NO = '" + strEmpNo + "') AND (CAT_ID = 'TRV_ALW') AND (AMOUNT= " + No_of_Days + ")", _conn);
                    cmdUpdate.ExecuteNonQuery();
                    cmdUpdate.Dispose();
                }

                catch (Exception)
                {
                    MessageBox.Show("Proccessing Travelling Allowances Failed!", "Travelling Allowances");
                }

            }
            MessageBox.Show("Processing of Travelling Allowances Completed Successfully", "Travelling Allowances");
            _conn.Close();
        }

        private void btn_Super_Allow_Click(object sender, EventArgs e)
        {
            decimal SupervisorAllowance = 0;
            string strEmpNo;
            string str_SQL = null;

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            DataTable tblSupervior = new DataTable();
            strSQL = "SELECT DISTINCT dbo.TENDER_DETAILS.TEN_NO, dbo.TENDER_MAIN.DESCRIPTION, dbo.TENDER_DETAILS.EMP_NO, dbo.EMPLOYEES.INITIALS + ' ' + dbo.EMPLOYEES.NAME AS NAME, dbo.TENDER_MAIN.SUP_ALLOWANCE, dbo.EMPLOYEES.SUPERVISOR, ";
            strSQL += "dbo.EMPLOYEES.STATUS AS EMP_STATUS, dbo.TENDER_MAIN.STATUS AS TEN_STATUS FROM dbo.EMPLOYEES INNER JOIN dbo.TENDER_DETAILS ON dbo.EMPLOYEES.EMP_NO = dbo.TENDER_DETAILS.EMP_NO INNER JOIN dbo.TENDER_MAIN ON dbo.TENDER_DETAILS.TEN_NO = dbo.TENDER_MAIN.TEN_NO ";
            strSQL += "WHERE (dbo.TENDER_MAIN.STATUS = 1) AND (dbo.EMPLOYEES.STATUS = 1) AND (dbo.TENDER_MAIN.SUP_ALLOWANCE > 0) AND (dbo.EMPLOYEES.SUPERVISOR = 1) AND (NOT (dbo.TENDER_DETAILS.EMP_NO IN (SELECT EMP_NO FROM PAY_SLIPS_EARNINGS ";
            strSQL += "WHERE EAR_ID = 'OT_TEN_SUP' AND PAY_YEAR = '" + intYear + "' AND PAY_MONTH = '" + intMonth + "')))";

            //   SqlCommand cmdSupervior = new SqlCommand("SELECT TEN_NO, DESCRIPTION, EMP_NO, NAME, SUP_ALLOWANCE, SUPERVISOR, EMP_STATUS, TEN_STATUS FROM VW_PROCESS_SUPERVISOR", _conn);
            SqlCommand cmdSupervior = new SqlCommand(strSQL, _conn);
            SqlDataAdapter daSupervior = new SqlDataAdapter();

            daSupervior.SelectCommand = cmdSupervior;
            daSupervior.Fill(tblSupervior);

            if (tblSupervior.Rows.Count > 0)
            {
                foreach (DataRow dr in tblSupervior.Rows)
                {
                    strEmpNo = dr["EMP_NO"].ToString();
                    SupervisorAllowance = Convert.ToDecimal(dr["SUP_ALLOWANCE"].ToString());

                    try
                    {
                        str_SQL = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO, EAR_ID, PAY_VALUE, PAY_YEAR, PAY_MONTH) VALUES ('" + strEmpNo + "', 'OT_TEN_SUP', '" + SupervisorAllowance + "', '" + intYear + "', '" + intMonth + "')";
                        SqlCommand objCmd = new SqlCommand(str_SQL, _conn);
                        objCmd.ExecuteNonQuery();
                        objCmd.Dispose();
                    }


                    catch (Exception)
                    {
                        MessageBox.Show("Allready Proccessed Supervisor Allowances!", "Supervisor Allowance");
                        return;
                    }
                }
                MessageBox.Show("Processing of Supervisor Allowances Completed Successfully", "Supervisor Allowance");
            }
            else
            {
                MessageBox.Show("NO Supervisor Allowances to Process", "Supervisor Allowance");
            }

            _conn.Close();
        }


        private void btnOfficeBasic_Click(object sender, EventArgs e)
        {
            ProcessBasics();
        }

        private void ProcessBasics()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdTenMain = new SqlCommand("SELECT EMP_NO, BASIC_SALARY, STATUS FROM dbo.EMPLOYEES WHERE (STATUS = 1)", _conn);
            SqlDataReader dreader = cmdTenMain.ExecuteReader();
            dreader.Read();
            if (dreader.HasRows == true)
            {
                decimal BAMNT = decimal.Parse(dreader["BASIC_SALARY"].ToString());
                string strEMP = dreader["EMP_NO"].ToString();

                dreader.Dispose();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEMP + "','BASIC','" + BAMNT + "','" + intYear + "','" + intMonth + "')";
                cmdsql1.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("NO Basic Salary Detail to Process", "Basic Salary Process");
                return;
            }

            MessageBox.Show("Office Employee Basic Salary Calculations are Completed Successfully", "Office Basic Salary Process");

            dreader.Dispose();
            _conn.Close();

        }

        private void cmdWelfair_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strSQL = "SELECT DISTINCT dbo.TENDER_MAIN.TEN_NO, dbo.TENDER_DETAILS.EMP_NO, dbo.TENDER_MAIN.WELFAIR_AMOUNT ";
            strSQL += "FROM dbo.TENDER_MAIN INNER JOIN dbo.TENDER_DETAILS ON dbo.TENDER_MAIN.TEN_NO = dbo.TENDER_DETAILS.TEN_NO ";
            strSQL += "WHERE (dbo.TENDER_MAIN.STATUS = 1) AND (dbo.TENDER_MAIN.WELFAIR_AMOUNT > 0) AND (dbo.TENDER_DETAILS.EMP_STATUS = 1)";
            //strSQL += "AND (NOT (TENDER_DETAILS.EMP_NO IN (SELECT EMP_NO FROM PAY_SLIPS_DEDUCTIONS WHERE DED_ID = 'WEFDED' AND DED_YEAR = '" + intYear + "' AND DED_MONTH = '" + intMonth + "')))";
            //strSQL += "AND DED_YEAR = '" + intYear + "' AND DED_MONTH = '" + intMonth + "'";
            /*
             * SELECT DISTINCT TENDER_MAIN.TEN_NO, TENDER_DETAILS.EMP_NO, TENDER_MAIN.WELFAIR_AMOUNT
FROM         TENDER_MAIN INNER JOIN
                      TENDER_DETAILS ON TENDER_MAIN.TEN_NO = TENDER_DETAILS.TEN_NO
WHERE     (TENDER_MAIN.STATUS = 1) AND (TENDER_MAIN.WELFAIR_AMOUNT > 0) AND (TENDER_DETAILS.EMP_STATUS = 1) AND 
                      (TENDER_MAIN.TEN_NO = '513') AND (NOT (TENDER_DETAILS.EMP_NO IN
                          (SELECT     EMP_NO
                            FROM          PAY_SLIPS_DEDUCTIONS
                            WHERE      DED_ID = 'WEFDED' AND DED_YEAR = 2010 AND DED_MONTH = 07)))
             */
            DataTable tblWelfair = new DataTable();
            SqlCommand cmdWelfair = new SqlCommand(strSQL, _conn);
            SqlDataAdapter daWelfair = new SqlDataAdapter();

            daWelfair.SelectCommand = cmdWelfair;
            daWelfair.Fill(tblWelfair);

            //================ Welfair Deduction ==========
            if (tblWelfair.Rows.Count > 0)
            {
                foreach (DataRow drWelfair in tblWelfair.Rows)
                {
                    try
                    {
                        string strSQLPAYSLIP = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO,DED_ID,DED_VALUE,DED_YEAR,DED_MONTH) VALUES ('" + drWelfair["EMP_NO"].ToString() + "','" + "WEFDED" + "','" + drWelfair["WELFAIR_AMOUNT"].ToString() + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand objCmd = new SqlCommand(strSQLPAYSLIP, _conn);
                        objCmd.ExecuteNonQuery();
                        objCmd.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed for the Processing Month", "Welfair Deduction");
                        return;
                    }
                }
                MessageBox.Show("Processing of Welfair Deduction Completed Successfully", "Welfair Deduction");
            }
            else
            {
                MessageBox.Show("NO Welfair Deductions to Process", "Welfair Deduction");
            }
            _conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private int GetBatchNumber()
        {
            int BatchNo = 0;
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_conn = obyConn.Connect();

            string strSQL = "SELECT dbo.[FN_GET_BATCH_NUMBER]()";

            DataTable tblSlips = new DataTable();
            SqlCommand cmdSlips = new SqlCommand(strSQL, _conn);
            SqlDataAdapter daSlips = new SqlDataAdapter();

            daSlips.SelectCommand = cmdSlips;
            daSlips.Fill(tblSlips);

            BatchNo = Convert.ToInt16(tblSlips.Rows[0][0].ToString());

            //_conn.Close();
            return BatchNo;
        }

        private void btnBatchSumReport_Click(object sender, EventArgs e)
        {
            //frm_Reports frm_Reports = new frm_Reports();

            //frm_Reports.GetReportCriteria("rptBatchSummary", "", intYear, getComProfiles.GetMonthConverted(intMonth), "","", "", "");
            //frm_Reports.Show();

            //frm_Reports.TopMost = true;
        }

        private void btnBatchBankSumReport_Click(object sender, EventArgs e)
        {
            //frm_Reports frm_Reports = new frm_Reports();

            //frm_Reports.GetReportCriteria("NetSalaryReportBatchWise", "", intYear, getComProfiles.GetMonthConverted(intMonth),"" , "", "", "");
            //frm_Reports.Show();

            //frm_Reports.TopMost = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdTenMain = new SqlCommand("SELECT EMP_NO, AMOUNT FROM ADJUSTMENTS WHERE (CAT_ID = 'ALW') AND (STATUS = 1) AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')", _conn);
            SqlDataReader dreader = cmdTenMain.ExecuteReader();
            dreader.Read();
            if (dreader.HasRows == true)
            {
                decimal BAMNT = decimal.Parse(dreader["AMOUNT"].ToString());
                string strEMP = dreader["EMP_NO"].ToString();

                dreader.Dispose();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEMP + "','ALW','" + BAMNT + "','" + intYear + "','" + intMonth + "')";
                cmdsql1.ExecuteNonQuery();

                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE ADJUSTMENTS SET STATUS = 0 WHERE (CAT_ID = 'ALW') AND (EMP_NO = '" + strEMP + "') AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')";
                cmdsql2.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("NO Allowance Detail to Process", "Allowance Process");
                return;
            }

            MessageBox.Show("Allowance Amount Calculations are Completed Successfully", "Allowance Amount Process");

            dreader.Dispose();
            _conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdTenMain = new SqlCommand("SELECT CAT_ID, EMP_NO, AMOUNT FROM ADJUSTMENTS WHERE (CAT_ID <> 'OT') AND (CAT_ID <> 'ALW') AND (STATUS = 1) AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')", _conn);
            SqlDataReader dreader = cmdTenMain.ExecuteReader();
            dreader.Read();
            if (dreader.HasRows == true)
            {
                decimal BAMNT = decimal.Parse(dreader["AMOUNT"].ToString());
                string strEMP = dreader["EMP_NO"].ToString();
                string CATID = dreader["CAT_ID"].ToString();

                dreader.Dispose();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEMP + "','" + CATID + "','" + BAMNT + "','" + intYear + "','" + intMonth + "')";
                cmdsql1.ExecuteNonQuery();

                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE ADJUSTMENTS SET STATUS = 0 WHERE (CAT_ID = '" + CATID + "') AND (EMP_NO = '" + strEMP + "') AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')";
                cmdsql2.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("No Earnings Detail to Process", "Al the Earnings Process");
                return;
            }

            MessageBox.Show("Al the Earnings Amount Calculations are Completed Successfully", "Al the Earnings Process");

            dreader.Dispose();
            _conn.Close();
        }

        private void cmdWelfair_Click_1(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdTenMain = new SqlCommand("SELECT EMP_NO, AMOUNT FROM ADJUSTMENTS WHERE (CAT_ID = 'WELDED') AND (STATUS = 1) AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')", _conn);
            SqlDataReader dreader = cmdTenMain.ExecuteReader();
            dreader.Read();
            if (dreader.HasRows == true)
            {
                decimal BAMNT = decimal.Parse(dreader["AMOUNT"].ToString());
                string strEMP = dreader["EMP_NO"].ToString();

                dreader.Dispose();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO,DED_ID,DED_VALUE,DED_YEAR,DED_MONTH) VALUES ('" + strEMP + "','WELDED','" + BAMNT + "','" + intYear + "','" + intMonth + "')";
                cmdsql1.ExecuteNonQuery();

                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE ADJUSTMENTS SET STATUS = 0 WHERE (CAT_ID = 'WELDED') AND (EMP_NO = '" + strEMP + "') AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')";
                cmdsql2.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("No Deduct Amounts to Process", "Welfare Process");
                return;
            }

            MessageBox.Show("Welfare Deduction Calculations are Completed Successfully", "Welfare Amount Process");

            dreader.Dispose();
            _conn.Close();
        }

        private void btnFESADVANCE_Click_1(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdTenMain = new SqlCommand("SELECT EMP_NO, AMOUNT FROM ADJUSTMENTS WHERE (CAT_ID = 'FESTADV') AND (STATUS = 1) AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')", _conn);
            SqlDataReader dreader = cmdTenMain.ExecuteReader();
            dreader.Read();
            if (dreader.HasRows == true)
            {
                decimal BAMNT = decimal.Parse(dreader["AMOUNT"].ToString());
                string strEMP = dreader["EMP_NO"].ToString();

                dreader.Dispose();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEMP + "','FESTADV','" + BAMNT + "','" + intYear + "','" + intMonth + "')";
                cmdsql1.ExecuteNonQuery();

                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE ADJUSTMENTS SET STATUS = 0 WHERE (CAT_ID = 'FESTADV') AND (EMP_NO = '" + strEMP + "') AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')";
                cmdsql2.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("No Festival Advance Amounts to Process", "Festival Advance Process");
                return;
            }

            MessageBox.Show("Festival Advance Calculations are Completed Successfully", "Festival Advance Process");

            dreader.Dispose();
            _conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdTenMain = new SqlCommand("SELECT EMP_NO, AMOUNT FROM ADJUSTMENTS WHERE (CAT_ID = 'SALADV') AND (STATUS = 1) AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')", _conn);
            SqlDataReader dreader = cmdTenMain.ExecuteReader();
            dreader.Read();
            if (dreader.HasRows == true)
            {
                decimal BAMNT = decimal.Parse(dreader["AMOUNT"].ToString());
                string strEMP = dreader["EMP_NO"].ToString();

                dreader.Dispose();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO,DED_ID,DED_VALUE,DED_YEAR,DED_MONTH) VALUES ('" + strEMP + "','SALADV','" + BAMNT + "','" + intYear + "','" + intMonth + "')";
                cmdsql1.ExecuteNonQuery();

                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE ADJUSTMENTS SET STATUS = 0 WHERE (CAT_ID = 'SALADV') AND (EMP_NO = '" + strEMP + "') AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')";
                cmdsql2.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("No Salary Advance to Process", "Salary Advance  Process");
                return;
            }

            MessageBox.Show("Salary Advance Calculations are Completed Successfully", "Salary Advance  Process");

            dreader.Dispose();
            _conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdTenMain = new SqlCommand("SELECT CAT_ID, EMP_NO, AMOUNT FROM ADJUSTMENTS WHERE (CAT_ID <> 'OT') AND (CAT_ID <> 'ALW') AND (STATUS = 1) AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')", _conn);
            SqlDataReader dreader = cmdTenMain.ExecuteReader();
            dreader.Read();
            if (dreader.HasRows == true)
            {
                decimal BAMNT = decimal.Parse(dreader["AMOUNT"].ToString());
                string strEMP = dreader["EMP_NO"].ToString();
                string CATID = dreader["CAT_ID"].ToString();

                dreader.Dispose();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _conn;
                cmdsql1.CommandText = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEMP + "','" + CATID + "','" + BAMNT + "','" + intYear + "','" + intMonth + "')";
                cmdsql1.ExecuteNonQuery();

                SqlCommand cmdsql2 = new SqlCommand();
                cmdsql2.Connection = _conn;
                cmdsql2.CommandText = "UPDATE ADJUSTMENTS SET STATUS = 0 WHERE (CAT_ID = '" + CATID + "') AND (EMP_NO = '" + strEMP + "') AND (IN_YEAR = '" + intYear + "') AND (IN_MONTH = '" + intMonth + "')";
                cmdsql2.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("No Earnings Detail to Process", "Al the Earnings Process");
                return;
            }

            MessageBox.Show("All the Earnings Amount Calculations are Completed Successfully", "Al the Earnings Process");

            dreader.Dispose();
            _conn.Close();
        }

        private void btn_Loan_Process_Click_1(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strAdj = ("SELECT * FROM VW_LOAN_PROCESS WHERE LOAN_ID= 'COM' AND BAL_INST > 0");

            DataTable tblAdj = new DataTable();
            SqlCommand cmdAdj = new SqlCommand(strAdj, _conn);
            SqlDataAdapter daAdj = new SqlDataAdapter();

            daAdj.SelectCommand = cmdAdj;
            daAdj.Fill(tblAdj);

            if (tblAdj.Rows.Count > 0)
            {
                foreach (DataRow drAdj in tblAdj.Rows)
                {
                    try
                    {
                        decimal BalanceAmount = 0;
                        decimal Rate = 0;
                        decimal InterestAmount = 0;
                        decimal InstallementAmount = 0;

                        BalanceAmount = decimal.Parse(drAdj["BAL_AMOUNT"].ToString());
                        Rate = decimal.Parse(drAdj["INTEREST"].ToString());

                        if (BalanceAmount > 0)
                        {
                            InterestAmount = ((BalanceAmount * Rate) / 100) / 12;
                        }

                        InstallementAmount = (decimal.Parse(drAdj["LOAN_AMOUNT"].ToString()) / int.Parse(drAdj["NO_INST"].ToString()));

                        string strAdjINS = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO, DED_ID, DED_VALUE, DED_YEAR, DED_MONTH) VALUES ('" + drAdj["EMP_NO"].ToString() + "', '" + drAdj["DED_ID"].ToString() + "','" + InstallementAmount + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand cmdAdjINS = new SqlCommand(strAdjINS, _conn);
                        cmdAdjINS.ExecuteNonQuery();
                        cmdAdjINS.Dispose();

                        string strLoanInterest = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO, DED_ID, DED_VALUE, DED_YEAR, DED_MONTH) VALUES ('" + drAdj["EMP_NO"].ToString() + "', 'COMINST','" + InterestAmount + "','" + intYear + "','" + intMonth + "')";
                        SqlCommand cmdLoanInterest = new SqlCommand(strLoanInterest, _conn);
                        cmdLoanInterest.ExecuteNonQuery();
                        cmdLoanInterest.Dispose();

                        string str_AdjINS = "UPDATE LOAN_DETAILS SET BAL_AMOUNT = '" + (BalanceAmount - InstallementAmount) + "', BAL_INST = BAL_INST - 1 WHERE (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "')";
                        SqlCommand cmd_AdjINS = new SqlCommand(str_AdjINS, _conn);
                        cmd_AdjINS.ExecuteNonQuery();
                        cmd_AdjINS.Dispose();

                        string strUpINS = "SELECT BAL_INST FROM LOAN_DETAILS WHERE (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "')";
                        SqlCommand cmdUpINS = new SqlCommand(strUpINS, _conn);
                        SqlDataReader drUpINS = cmdUpINS.ExecuteReader();
                        drUpINS.Read();
                        cmdUpINS.Dispose();

                        if (int.Parse(drUpINS["BAL_INST"].ToString()) == 0)
                        {
                            drUpINS.Close();
                            string UP_strAdjINS = "UPDATE LOAN_DETAILS SET STATUS = 0 WHERE (SEQ_NO = '" + drAdj["SEQ_NO"].ToString() + "')";
                            SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
                            Up_cmdAdjINS.ExecuteNonQuery();
                            Up_cmdAdjINS.Dispose();
                        }
                        cmdAdjINS.Dispose();
                        cmdAdjINS.Dispose();
                        cmdLoanInterest.Dispose();
                        cmd_AdjINS.Dispose();
                        cmdUpINS.Dispose();
                        drUpINS.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Already Processed Loans for the Processing Month", "Loan Process Information");
                        return;
                    }

                }
                MessageBox.Show("Processing of Loan Details Completed Successfully", "Loan Details");
            }
            else
                MessageBox.Show("NO Records to Process Data for Loan Details", "Loan Details");

            _conn.Close();
            cmdAdj.Dispose();
            daAdj.Dispose();
            tblAdj.Dispose();
        }

        private void btnOfficeBasic_Click_1(object sender, EventArgs e)
        {
            string strEmp;
            decimal BASICSAL = 0;

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            DataTable tblProcess = new DataTable();
            SqlCommand cmdProcess = new SqlCommand();
            SqlDataAdapter daProcess = new SqlDataAdapter();

            cmdProcess.Connection = _conn;
            cmdProcess.CommandText = "SELECT EMP_NO, BASIC_SALARY FROM EMPLOYEES " + strSQL;
            cmdProcess.CommandType = CommandType.Text;

            daProcess.SelectCommand = cmdProcess;
            daProcess.Fill(tblProcess);

            foreach (DataRow dr in tblProcess.Rows)
            {
                strEmp = dr["EMP_NO"].ToString();
                BASICSAL = decimal.Parse(dr["BASIC_SALARY"].ToString());
                try
                {
                    strSQL = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEmp + "','BASIC','" + BASICSAL + "','" + intYear + "','" + intMonth + "')";
                    SqlCommand objCmd = new SqlCommand(strSQL, _conn);
                    objCmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
            }

            MessageBox.Show("Employee Basic Salary Calculations are Completed Successfully", "Basic Salary Process");

            _conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string strEmp;
            decimal FixedEarn = 0;
            decimal FixedDeduct = 0;


            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            DataTable tblProcess = new DataTable();
            SqlCommand cmdProcess = new SqlCommand();
            SqlDataAdapter daProcess = new SqlDataAdapter();

            cmdProcess.Connection = _conn;
            cmdProcess.CommandText = "SELECT EMP_NO, FIXED_EARNINGS, FIXED_DEDUCTIONS FROM EMPLOYEES";
            cmdProcess.CommandType = CommandType.Text;

            daProcess.SelectCommand = cmdProcess;
            daProcess.Fill(tblProcess);

            foreach (DataRow dr in tblProcess.Rows)
            {
                strEmp = dr["EMP_NO"].ToString();
                FixedEarn = decimal.Parse(dr["FIXED_EARNINGS"].ToString());
                FixedDeduct = decimal.Parse(dr["FIXED_DEDUCTIONS"].ToString());
                try
                {
                    string UP_strAdjINS = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + strEmp + "','FXDEARN','" + FixedEarn + "','" + intYear + "','" + intMonth + "')";
                    SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
                    Up_cmdAdjINS.ExecuteNonQuery();
                    Up_cmdAdjINS.Dispose();
                }
                catch (Exception)
                {

                }

                try
                {
                    string UP_strAdjINSA = "INSERT INTO PAY_SLIPS_DEDUCTIONS (EMP_NO,DED_ID,DED_VALUE,DED_YEAR,DED_MONTH) VALUES ('" + strEmp + "','FIXDED','" + FixedDeduct + "','" + intYear + "','" + intMonth + "')";
                    SqlCommand Up_cmdAdjINSA = new SqlCommand(UP_strAdjINSA, _conn);
                    Up_cmdAdjINSA.ExecuteNonQuery();
                    Up_cmdAdjINSA.Dispose();
                }
                catch (Exception)
                {

                }
            }
            MessageBox.Show("Employee Basic Salary Calculations are Completed Successfully", "Basic Salary Process");

            _conn.Close();
        }
    }
}
        
    
        

