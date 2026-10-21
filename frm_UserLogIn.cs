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
    public partial class frm_UserLogIn : Form
    {
        public frm_UserLogIn()
        {
            InitializeComponent();
        }
        private SqlConnection _Conn;
              
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UP_USER()
        {
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection obyConn = new Connection.DatabaseConnection();
                conn = obyConn.Connect();
                SqlCommand cmdsql0 = new SqlCommand("DELETE FROM [CURRENT_USER]", conn);
                cmdsql0.ExecuteNonQuery();
                SqlCommand cmdsql1 = new SqlCommand("INSERT INTO [CURRENT_USER](C_USER) VALUES (@user)", conn);
                cmdsql1.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = txt_User.Text;
                cmdsql1.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }
        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_User.Text == "" || txt_Password.Text == "")
                {
                    MessageBox.Show("Please Enter the User Name, Password and Proceed");
                    txt_User.Focus();
                }

                else
                {
                    Connection.DatabaseConnection obyConn;

                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();

                    SqlCommand cmdPwd = new SqlCommand("SELECT USER_NAME, USER_ID, PASSWORD, ACC_LEVEL FROM USER_LOGIN WHERE USER_ID = @id", _Conn);
                    cmdPwd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = txt_User.Text;
                    SqlDataReader drPwd = cmdPwd.ExecuteReader();
                    while (drPwd.Read())
                    {
                        if (txt_Password.Text == drPwd["PASSWORD"].ToString())
                        {
                            UP_USER();
                            frm_MainMenu frm_Main = new frm_MainMenu();
                            frm_Main.lblUser.Text = drPwd["USER_NAME"].ToString();
                            frm_Main.lblUserLevel.Text = drPwd["ACC_LEVEL"].ToString();
                            
                            frm_Main.Show();
                            this.Hide();
                            AuditLog.Write("LOGIN", "frm_UserLogIn", "Signed in");
                        }
                        else if (txt_Password.Text != drPwd["PASSWORD"].ToString())
                        {
                            MessageBox.Show("Invalid User Name or Password", "Invalid User LogIn");
                            txt_Password.Focus();
                        }
                    }
                    drPwd.Close();
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_UserLogIn", ex);
                MessageBox.Show(ex.Message, "Login");
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

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                if (txt_User.Text == "" || txt_Password.Text == "")
                {
                    MessageBox.Show("Please Enter the User Name, Password and Proceed");
                    txt_User.Focus();
                }

                else
                {
                    Connection.DatabaseConnection obyConn;

                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();

                    SqlCommand cmdPwd = new SqlCommand("SELECT USER_NAME, USER_ID, PASSWORD, ACC_LEVEL FROM USER_LOGIN WHERE USER_ID = @id", _Conn);
                    cmdPwd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = txt_User.Text;
                    SqlDataReader drPwd = cmdPwd.ExecuteReader();
                    while (drPwd.Read())
                    {
                        if (txt_Password.Text == drPwd["PASSWORD"].ToString())
                        {
                            UP_USER();
                            frm_MainMenu frm_Main = new frm_MainMenu();
                            frm_Main.lblUser.Text = drPwd["USER_NAME"].ToString();
                            frm_Main.lblUserLevel.Text = drPwd["ACC_LEVEL"].ToString();

                            frm_Main.Show();
                            this.Hide();
                            AuditLog.Write("LOGIN", "frm_UserLogIn", "Signed in");
                        }
                        else if (txt_Password.Text != drPwd["PASSWORD"].ToString())
                        {
                            MessageBox.Show("Invalid User Name or Password", "Invalid User LogIn");
                            txt_Password.Focus();
                        }
                    }
                    drPwd.Close();
                    _Conn.Close();
                }
            }
        }

        private void txt_User_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Password.Focus();
            }
        }

        private void frm_UserLogIn_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            UiTheme.RoundPanel(loginCard, 8);
            this.BackColor = Color.FromArgb(10, 31, 68);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MainMenu));
            object logo = resources.GetObject("pictureBox1.Image");
            if (logo is Image)
            {
                pictureBox1.Image = (Image)logo;
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackColor = Color.FromArgb(10, 31, 68);
            pictureBox1.Visible = true;
            txt_Password.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int ccc = e.KeyValue;
            int iii = (int)ccc;
            if ((iii == 1) || (iii == 2) || (iii == 3) || (iii == 4) || (iii == 5) || (iii == 6) || (iii == 7) || (iii == 8) || (iii == 9) || (iii == 10) || (iii == 11) || (iii == 12) || (iii == 13) || (iii == 14) || (iii == 15) || (iii == 16) || (iii == 17) || (iii == 18) || (iii == 19) || (iii == 20) || (iii == 21) || (iii == 22) || (iii == 23) || (iii == 24) || (iii == 25) || (iii == 26) || (iii == 27) || (iii == 28) || (iii == 29) || (iii == 30) || (iii == 31) || (iii == 32) || (iii == 33) || (iii == 34) || (iii == 35) || (iii == 36) || (iii == 37) || (iii == 38) || (iii == 39) || (iii == 40) || (iii == 41) || (iii == 42) || (iii == 43) || (iii == 44) || (iii == 45) || (iii == 46) || (iii == 47) || (iii == 48) || (iii == 49) || (iii == 50) || (iii == 51) || (iii == 52) || (iii == 53) || (iii == 54) || (iii == 55) || (iii == 56) || (iii == 57) || (iii == 58) || (iii == 59) || (iii == 60) || (iii == 61) || (iii == 62) || (iii == 63) || (iii == 64) || (iii == 65) || (iii == 66) || (iii == 67) || (iii == 68) || (iii == 69) || (iii == 70) || (iii == 71) || (iii == 72) || (iii == 73) || (iii == 74) || (iii == 75) || (iii == 76) || (iii == 77) || (iii == 78) || (iii == 79) || (iii == 80) || (iii == 81) || (iii == 82) || (iii == 83) || (iii == 84) || (iii == 85) || (iii == 86) || (iii == 87) || (iii == 88) || (iii == 89) || (iii == 90) || (iii == 91) || (iii == 92) || (iii == 93) || (iii == 94) || (iii == 95) || (iii == 96) || (iii == 97) || (iii == 98) || (iii == 99) || (iii == 100) || (iii == 101) || (iii == 102) || (iii == 103) || (iii == 104) || (iii == 105) || (iii == 106) || (iii == 107) || (iii == 108) || (iii == 109) || (iii == 110) || (iii == 111) || (iii == 112) || (iii == 113) || (iii == 114) || (iii == 115) || (iii == 116) || (iii == 117) || (iii == 118) || (iii == 119) || (iii == 120) || (iii == 121) || (iii == 122) || (iii == 123) || (iii == 124) || (iii == 125) || (iii == 126) || (iii == 127) || (iii == 128) || (iii == 129) || (iii == 130) || (iii == 131) || (iii == 132) || (iii == 133) || (iii == 134) || (iii == 135) || (iii == 136) || (iii == 137) || (iii == 138) || (iii == 139) || (iii == 140) || (iii == 141) || (iii == 142) || (iii == 143) || (iii == 144) || (iii == 145) || (iii == 146) || (iii == 147) || (iii == 148) || (iii == 149) || (iii == 150) || (iii == 151) || (iii == 152) || (iii == 153) || (iii == 154) || (iii == 155) || (iii == 156) || (iii == 157) || (iii == 158) || (iii == 159) || (iii == 160) || (iii == 161) || (iii == 162) || (iii == 163) || (iii == 164) || (iii == 165) || (iii == 166) || (iii == 167) || (iii == 168) || (iii == 169) || (iii == 170) || (iii == 171) || (iii == 172) || (iii == 173) || (iii == 174) || (iii == 175) || (iii == 176) || (iii == 177) || (iii == 178) || (iii == 179) || (iii == 180) || (iii == 181) || (iii == 182) || (iii == 183) || (iii == 184) || (iii == 185) || (iii == 186) || (iii == 187) || (iii == 188) || (iii == 189) || (iii == 190) || (iii == 191) || (iii == 192) || (iii == 193) || (iii == 194) || (iii == 195) || (iii == 196) || (iii == 197) || (iii == 198) || (iii == 199) || (iii == 200) || (iii == 201) || (iii == 202) || (iii == 203) || (iii == 204) || (iii == 205) || (iii == 206) || (iii == 207))
            {
                MessageBox.Show("");
            }
        }

      
    }
}