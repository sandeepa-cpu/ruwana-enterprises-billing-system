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
    public partial class frm_ChangePassword : Form
    {
        public frm_ChangePassword()
        {
            InitializeComponent();
        }
        private SqlConnection _Conn;
        private string PWD = "";

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            if (cmb_Users.Text=="" || txt_ConfirmPWD.Text == "" || txt_CurrentPWD.Text == "" || txt_NewPWD.Text == "")
            {
                MessageBox.Show("Please Select the User Name, Confirmation Passwords and Proceed", "Change Passwords");
                cmb_Users.Focus();
            }

            else
            {
                try
                {
                    if (txt_CurrentPWD.Text != PWD.ToString())
                    {
                        MessageBox.Show("Incorrect Current Password", "Password Entering......");
                    }
                    else
                    {
                        if (txt_NewPWD.Text.Trim() != txt_ConfirmPWD.Text.Trim())
                        {
                            MessageBox.Show("New Password & Confirm Password are not Equal, Verify your Data", "Invalid Password");
                        }
                        else
                        {
                            Connection.DatabaseConnection obyConn;

                            obyConn = new Connection.DatabaseConnection();
                            _Conn = obyConn.Connect();

                            SqlCommand cmdLoanMain = new SqlCommand("UPDATE USER_LOGIN SET PASSWORD = @password WHERE USER_NAME = @name", _Conn);
                            cmdLoanMain.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = txt_NewPWD.Text;
                            cmdLoanMain.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = cmb_Users.Text.Trim();
                            cmdLoanMain.ExecuteNonQuery();
                            MessageBox.Show("Selected User Password Successfully Updated", "Update Users");
                            _Conn.Close();
                            txt_ConfirmPWD.Text = "";
                            txt_CurrentPWD.Text = "";
                            txt_NewPWD.Text = "";
                            cmb_Users.Text = "";
                            cmb_Users.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    AppLog.Write("frm_ChangePassword", ex);
                    MessageBox.Show(ex.Message, "Change Password");
                }
                finally
                {
                    if (_Conn != null)
                    {
                        _Conn.Dispose();
                        _Conn = null;
                    }
                }
            }
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_ChangePassword_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT USER_NAME, USER_ID, PASSWORD FROM USER_LOGIN";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmb_Users.Items.Add(dreader["USER_NAME"].ToString());
                PWD = dreader["PASSWORD"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void cmb_Users_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT USER_NAME, PASSWORD FROM USER_LOGIN WHERE USER_NAME = @name";
            cmdsql.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = cmb_Users.Text;
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                PWD = dreader["PASSWORD"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}