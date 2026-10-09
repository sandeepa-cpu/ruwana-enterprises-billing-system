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
    public partial class frm_Splash : Form
    {
        public frm_Splash()
        {
            InitializeComponent();
        }
        private SqlConnection _conn;

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            frm_UserLogIn frm_ON = new frm_UserLogIn();
            frm_ON.Show();
            timer1.Enabled = false;
        }

        private void LOADDATA()
        {
            //Connection.DatabaseConnection obyConn;
            //obyConn = new Connection.DatabaseConnection();
            //_conn = obyConn.Connect();
            //SqlCommand cmdsql = new SqlCommand();
            //cmdsql.Connection = _conn;
            //cmdsql.CommandText = "SELECT NAME, ADDRESS, CITY, SYSTEM1, CONTACT1 + ' / ' + CONTACT2 AS CONTACT FROM COMPANY_INFO";
            //SqlDataReader dreader = cmdsql.ExecuteReader();

            //while (dreader.Read())
            //{
            //    lblCompany.Text = dreader["NAME"].ToString();
            //    label10.Text = dreader["CITY"].ToString();
            //    label2.Text = dreader["SYSTEM1"].ToString();
            //}

            //dreader.Close();
            //_conn.Dispose();
        }

        private void frm_Splash_Load(object sender, EventArgs e)
        {
            LOADDATA();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}