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
    public partial class frm_CreateUsers : Form
    {
        public frm_CreateUsers()
        {
            InitializeComponent();
        }
        
        private SqlConnection _Conn;

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "" || txt_UserID.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Please Enter the User Name, User ID, Password and Proceed");
                txt_UserName.Focus();
            }

            else
            {
                try
                {
                    if (txt_Password.Text.Trim() != txt_ConfimPWD.Text.Trim())
                    {
                        MessageBox.Show("Passwords are not matching, Verify your Data", "Invalid Password");
                    }
                    else
                    {
                        Connection.DatabaseConnection obyConn;

                        obyConn = new Connection.DatabaseConnection();
                        _Conn = obyConn.Connect();

                        SqlCommand cmdLoanMain = new SqlCommand("INSERT INTO USER_LOGIN (USER_NAME, USER_ID, PASSWORD, ACC_LEVEL) VALUES (@name, @id, @password, @level)", _Conn);
                        cmdLoanMain.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = txt_UserName.Text;
                        cmdLoanMain.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = txt_UserID.Text;
                        cmdLoanMain.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = txt_Password.Text;
                        cmdLoanMain.Parameters.Add("@level", SqlDbType.VarChar, 20).Value = cmb_AccLevel.Text;
                        cmdLoanMain.ExecuteNonQuery();
                        MessageBox.Show("Entered User Successfully Added", "Create Users");
                        _Conn.Close();
                        txt_ConfimPWD.Text = "";
                        txt_Password.Text = "";
                        txt_UserID.Text = "";
                        txt_UserName.Text = "";
                        txt_UserName.Focus();
                    }
                }
                catch (Exception ex)
                {
                    AppLog.Write("frm_CreateUsers", ex);
                    MessageBox.Show(ex.Message, "Create Users");
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
            txt_UserName.Focus();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ADMIN")
            {
                cmb_AccLevel.Text = "0";
            }
            else if (comboBox1.Text == "USER")
            {
                cmb_AccLevel.Text = "1";
            }
            else if (comboBox1.Text == "REPORTS ONLY")
            {
                cmb_AccLevel.Text = "2";
            }
        }

        private void txt_UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_UserID.Focus();
            }
        }

        private void txt_UserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Password.Focus();
            }
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_ConfimPWD.Focus();
            }
        }

        private void txt_ConfimPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                comboBox1.Focus();
            }
        }

     
    }
}