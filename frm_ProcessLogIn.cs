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
    public partial class frm_ProcessLogIn : Form
    {
        public frm_ProcessLogIn()
        {
            InitializeComponent();
        }
        string PWD = "";
        private SqlConnection _Conn;

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdLoanA = new SqlCommand("SELECT PASSWORD FROM USER_LOGIN WHERE USER_ID = 'Process'", _Conn);
            SqlDataReader drLoanA = cmdLoanA.ExecuteReader();
            while (drLoanA.Read())
            {
                 PWD = drLoanA["PASSWORD"].ToString();
            }
            drLoanA.Close();
            _Conn.Close();

            if (this.Text == "Change Process Period")
            {
                if (this.txt_Password.Text == PWD.ToString())
                {
                    frm_ChangeProcessPeriod frmChangePro = new frm_ChangeProcessPeriod();
                    frmChangePro.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Proccessing Password, Try again!", "Password Required!");
                }
            }
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                Connection.DatabaseConnection obyConn;

                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();

                SqlCommand cmdLoanA = new SqlCommand("SELECT PASSWORD FROM USER_LOGIN WHERE USER_ID = 'Process'", _Conn);
                SqlDataReader drLoanA = cmdLoanA.ExecuteReader();
                while (drLoanA.Read())
                {
                    PWD = drLoanA["PASSWORD"].ToString();
                }
                drLoanA.Close();
                _Conn.Close();

                if (this.Text == "Change Process Period")
                {
                    if (this.txt_Password.Text == PWD.ToString())
                    {
                        frm_ChangeProcessPeriod frmChangePro = new frm_ChangeProcessPeriod();
                        frmChangePro.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Proccessing Password, Try again!", "Password Required!");
                    }
                }
            }
        }

        private void frm_ProcessLogIn_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            txt_Password.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_Password.Focus();
            timer1.Enabled = false;
        }
    }
}