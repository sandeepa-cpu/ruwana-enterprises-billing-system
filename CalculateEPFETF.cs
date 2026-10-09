using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Billing_Inventory_Management_System
{
    class CalculateEPFETF
    {
        CommonProfiles objComPro = new CommonProfiles();
        private SqlConnection _conn;
        private decimal EPF_Employee;
        private decimal EPF_Employer;
        private decimal ETF_Employer;
        private decimal EPF_Rate;
        private decimal decTotal=0;

        public decimal GET_Earnings(string EmpNo, int SOStart, int SOEnd) //SO= Slip Order
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            decTotal = 0;

            SqlCommand cmdTotal = new SqlCommand("SELECT SUM(dbo.PAY_SLIPS_EARNINGS.PAY_VALUE) AS TOTAL" +
                                                 " FROM dbo.PAY_SLIPS_EARNINGS INNER JOIN dbo.EARNINGS ON dbo.PAY_SLIPS_EARNINGS.EAR_ID = dbo.EARNINGS.EAR_ID" +
                                                 " WHERE (dbo.PAY_SLIPS_EARNINGS.EMP_NO = '" + EmpNo + "') AND (dbo.PAY_SLIPS_EARNINGS.PAY_YEAR = '" + objComPro.GetYear() + "' ) AND (dbo.PAY_SLIPS_EARNINGS.PAY_MONTH = '" + objComPro.GetMonth() + "')" +
                                                 " AND (dbo.EARNINGS.SLIP_ORDER BETWEEN '" + SOStart + "' AND '" + SOEnd + "')",_conn);
            SqlDataReader drTotal = cmdTotal.ExecuteReader();
            drTotal.Read();

            if (drTotal["TOTAL"].ToString().Length > 0)
            decTotal = decimal.Parse(drTotal["TOTAL"].ToString());
            
            _conn.Close();
            drTotal.Close();

            return decTotal;
        }

        public decimal GET_Deductions(string EmpNo, int SOStart, int SOEnd) //SO= Slip Order
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            decTotal = 0;

            SqlCommand cmdTotal = new SqlCommand("SELECT SUM(dbo.PAY_SLIPS_DEDUCTIONS.DED_VALUE) AS TOTAL" +
                                                 " FROM dbo.PAY_SLIPS_DEDUCTIONS INNER JOIN dbo.DEDUCTIONS ON dbo.PAY_SLIPS_DEDUCTIONS.DED_ID = dbo.DEDUCTIONS.DED_ID" +
                                                 " WHERE (dbo.PAY_SLIPS_DEDUCTIONS.EMP_NO = '" + EmpNo + "') AND (dbo.PAY_SLIPS_DEDUCTIONS.DED_YEAR = '" + objComPro.GetYear() + "' ) AND (dbo.PAY_SLIPS_DEDUCTIONS.DED_MONTH = '" + objComPro.GetMonth() + "')" +
                                                 " AND (dbo.DEDUCTIONS.SLIP_ORDER BETWEEN '" + SOStart + "' AND '" + SOEnd + "')", _conn);
            SqlDataReader drTotal = cmdTotal.ExecuteReader();
            drTotal.Read();

            if (drTotal["TOTAL"].ToString().Length>0)
            decTotal = decimal.Parse(drTotal["TOTAL"].ToString());

            _conn.Close();
            drTotal.Close();

            return decTotal;
        }

        public decimal GET_SecDeposit(string EmpNo, int SOStart) //SO= Slip Order
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            decTotal = 0;

            SqlCommand cmdTotal = new SqlCommand("SELECT SUM(dbo.SEC_DEP_SLIPS.DED_VALUE) AS TOTAL" +
                                                 " FROM dbo.DEDUCTIONS INNER JOIN dbo.SEC_DEP_SLIPS ON dbo.DEDUCTIONS.DED_ID = dbo.SEC_DEP_SLIPS.DED_ID" +
                                                 " WHERE (dbo.DEDUCTIONS.SLIP_ORDER = '" + SOStart + "') AND (dbo.SEC_DEP_SLIPS.EMP_NO = '" + EmpNo + "') AND (dbo.SEC_DEP_SLIPS.PAY_YEAR = '" + objComPro.GetYear() + "') AND (dbo.SEC_DEP_SLIPS.PAY_MONTH = '" + objComPro.GetMonth() + "')",_conn);
           
            SqlDataReader drTotal = cmdTotal.ExecuteReader();
            drTotal.Read();

            if (drTotal["TOTAL"].ToString().Length > 0)
                decTotal = decimal.Parse(drTotal["TOTAL"].ToString());

            _conn.Close();
            drTotal.Close();

            return decTotal;
        }

        public decimal Calculate_EPF_Employee(decimal decTotAmount)
        {
            EPF_Rate = objComPro.GetEPFEmployee();

            EPF_Employee = ((decTotAmount / 100) * EPF_Rate);

            return EPF_Employee;
        }

        public decimal Calculate_EPF_Employer(decimal decTotAmount)
        {
            EPF_Rate = objComPro.GetEPFEmployer();

            EPF_Employer = ((decTotAmount / 100) * EPF_Rate);

            return EPF_Employer;
        }

        public decimal Calculate_ETF_Employer(decimal decTotAmount)
        {
            EPF_Rate = objComPro.GetETFEmployer();

            ETF_Employer = ((decTotAmount / 100) * EPF_Rate);

            return ETF_Employer;
        }
    }
}
