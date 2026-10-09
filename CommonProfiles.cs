using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Billing_Inventory_Management_System
{
    public class CommonProfiles
    {
        
        private int intYear;
        private int intMonth;
        private DateTime ProDate;
        private string strOTMet;
        private int strINVNO;
        private int strVNO;

        private SqlConnection _Conn;
                
        public int GetYear()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
                       
            SqlCommand cmdComPro = new SqlCommand("SELECT * FROM COMMON_PROFILE", _Conn);
            SqlDataReader drComPro = cmdComPro.ExecuteReader();
            drComPro.Read();

            intYear = Convert.ToInt32(drComPro["PRO_YEAR"].ToString());
            
            _Conn.Close();            
            drComPro.Close();
            cmdComPro.Dispose();

            return intYear;
            
        }

        public int GetMonth()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdComPro = new SqlCommand("SELECT * FROM COMMON_PROFILE", _Conn);
            SqlDataReader drComPro = cmdComPro.ExecuteReader();
            drComPro.Read();

            intMonth = Convert.ToInt32(drComPro["PRO_MONTH"].ToString());
            
            _Conn.Close();
            drComPro.Close();
            cmdComPro.Dispose();

            return intMonth;
           
        }

        public string GetMonthConverted(int intMonth)
        {
            string strMonthDigit = null;

            switch (intMonth)
            {
                case 1:
                    strMonthDigit = "January";
                    break;
                case 2:
                    strMonthDigit = "February";
                    break;
                case 3:
                    strMonthDigit = "March";
                    break;
                case 4:
                    strMonthDigit = "April";
                    break;
                case 5:
                    strMonthDigit = "May";
                    break;
                case 6:
                    strMonthDigit = "June";
                    break;
                case 7:
                    strMonthDigit = "July";
                    break;
                case 8:
                    strMonthDigit = "August";
                    break;
                case 9:
                    strMonthDigit = "September";
                    break;
                case 10:
                    strMonthDigit = "October";
                    break;
                case 11:
                    strMonthDigit = "November";
                    break;
                case 12:
                    strMonthDigit = "December";
                    break;
            }

            return strMonthDigit;

        }

        public int GetMonthConverted(string strMonth)
        {
            int intMonthDigit = 0;

            switch (strMonth)
            {
                case "January":
                    intMonthDigit = 1;
                    break;
                case "February":
                    intMonthDigit = 2;
                    break;
                case "March":
                    intMonthDigit = 3;
                    break;
                case "April":
                    intMonthDigit = 4;
                    break;
                case "May":
                    intMonthDigit = 5;
                    break;
                case "June":
                    intMonthDigit = 6;
                    break;
                case "July":
                    intMonthDigit = 7;
                    break;
                case "August":
                    intMonthDigit = 8;
                    break;
                case "September":
                    intMonthDigit = 9;
                    break;
                case "October":
                    intMonthDigit = 10;
                    break;
                case "November":
                    intMonthDigit = 11;
                    break;
                case "December":
                    intMonthDigit = 12;
                    break;


            }

            return intMonthDigit;

        }

        public string GetOTMethod
        {
            get
            {
                return strOTMet;
            }
        }

        public string SetOTMethod
        {
            set
            {
                strOTMet = value;
            }
        }

        internal decimal GetEPFEmployee()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal decimal GetEPFEmployer()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal decimal GetETFEmployer()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
