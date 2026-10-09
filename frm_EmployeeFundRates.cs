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
    public partial class frm_EmployeeFundRates : Form
    {
        public frm_EmployeeFundRates()
        {
            InitializeComponent();
        }

        private SqlConnection _conn;

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "UPDATE COMMON_PROFILES SET EPF_EMPLOYEE = " + txt_EPF_EE.Text + ", EPF_EMPLOYER = " + txt_EPF_ER.Text + ", ETF_EMPLOYER = " + txt_ETF_ER.Text + "";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                dreader.Close();
                MessageBox.Show("Employee Fund Rates Updated Successfully", "Update Rates");
                _conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Check Your Data & Proceed", "Data Error ......");
            }
        }

        private void frm_EmployeeFundRates_Load(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT EPF_EMPLOYER, EPF_EMPLOYEE, ETF_EMPLOYER FROM COMMON_PROFILES";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                //richTextBox1.SelectedText = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", dreader[0], dreader[1], dreader[2], dreader[3], dreader[4], dreader[5], dreader[6], dreader[7], dreader[8]) + "\n";

                txt_EPF_ER.Text = dreader["EPF_EMPLOYER"].ToString();
                txt_EPF_EE.Text = dreader["EPF_EMPLOYEE"].ToString();
                txt_ETF_ER.Text = dreader["ETF_EMPLOYER"].ToString();
            }
            dreader.Close();
            _conn.Close();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
