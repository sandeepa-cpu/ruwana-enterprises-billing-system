using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using Billing_Inventory_Management_System;

namespace Billing_Inventory_Management_System
{
    public partial class frm_CreateUserRoles : Form
    {
        private SqlConnection _conn;
        int SelectValue;
        private string skey;

        public frm_CreateUserRoles()
        {
            InitializeComponent();
        }

        private void Connection()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
        }

        private void GetRoles()
        {
            //tv_UserRole.Nodes[0].Nodes["tvAdmin"].Nodes.Add(drBank["BANK_CODE"].ToString(), drBank["BANK"].ToString());
            tv_UserRole.Nodes[0].Nodes.Add("Select Member Details");
            tv_UserRole.Nodes[0].Nodes.Add("New Loan Entry");
            tv_UserRole.Nodes[0].Nodes[1].Nodes.Add("Loan Information");
            tv_UserRole.Nodes[0].Nodes[1].Nodes.Add("Hold Loans");

            tv_UserRole.Nodes[0].Nodes.Add("Company Settings");
            tv_UserRole.Nodes[0].Nodes[2].Nodes.Add("Loan Information");

            tv_UserRole.Nodes[1].Nodes.Add("Receiving Loan Payments");
            tv_UserRole.Nodes[1].Nodes.Add("Extend Current Loans");
            tv_UserRole.Nodes[1].Nodes.Add("Late Loan Charges");
            tv_UserRole.Nodes[1].Nodes.Add("Pending Approvals");

            tv_UserRole.Nodes[2].Nodes.Add("Daily Proccessing");
            tv_UserRole.Nodes[2].Nodes.Add("Change Process Period");
            tv_UserRole.Nodes[2].Nodes.Add("Loan Settlments");

            tv_UserRole.Nodes[3].Nodes.Add("User Management");
            tv_UserRole.Nodes[3].Nodes[0].Nodes.Add("Create New User");
            tv_UserRole.Nodes[3].Nodes[0].Nodes.Add("Change Password");
            tv_UserRole.Nodes[3].Nodes[0].Nodes.Add("Create User Roles");
            tv_UserRole.Nodes[3].Nodes.Add("Backup Database");

            tv_UserRole.Nodes[4].Nodes.Add("Report Viewer");
            tv_UserRole.Nodes[4].Nodes.Add("Verify Receiving Loan Payments");
            tv_UserRole.Nodes[4].Nodes.Add("Check Member Information");

            tv_UserRole.CheckBoxes = true;
        }

        private void CheckNodes()
        {

            //if (tv_UserRole.Nodes["SelectValueloyee Details"].Checked == true)

            //*********************** Administration **************************

            KeyValuePair SubLoc = (KeyValuePair)cmb_User.SelectedItem;
            skey = SubLoc.Key.ToString();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();

            if (tv_UserRole.Nodes[0].Nodes[0].Checked == true)
            {
                SelectValue = 1;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[0].Nodes[1].Checked == true)
            {
                SelectValue = 2;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[0].Nodes[1].Nodes[0].Checked == true)
            {
                SelectValue = 3;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[0].Nodes[1].Nodes[1].Checked == true)
            {
                SelectValue = 4;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[0].Nodes[2].Checked == true)
            {
                SelectValue = 5;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[0].Nodes[2].Nodes[0].Checked == true)
            {
                SelectValue = 6;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }

            //*********************** Edit Mode **************************

            if (tv_UserRole.Nodes[1].Nodes[0].Checked == true)
            {
                SelectValue = 11;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[1].Nodes[1].Checked == true)
            {
                SelectValue = 12;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[1].Nodes[2].Checked == true)
            {
                SelectValue = 13;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[1].Nodes[3].Checked == true)
            {
                SelectValue = 14;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }

            //*********************** Process **************************

            if (tv_UserRole.Nodes[2].Nodes[0].Checked == true)
            {
                SelectValue = 21;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[2].Nodes[1].Checked == true)
            {
                SelectValue = 22;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[2].Nodes[2].Checked == true)
            {
                SelectValue = 23;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }

            //*********************** Tools **************************

            if (tv_UserRole.Nodes[3].Nodes[0].Checked == true)
            {
                SelectValue = 31;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[3].Nodes[0].Nodes[0].Checked == true)
            {
                SelectValue = 32;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[3].Nodes[0].Nodes[1].Checked == true)
            {
                SelectValue = 33;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[3].Nodes[0].Nodes[2].Checked == true)
            {
                SelectValue = 34;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[3].Nodes[1].Checked == true)
            {
                SelectValue = 35;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }

            //*********************** Reports **************************

            if (tv_UserRole.Nodes[4].Nodes[0].Checked == true)
            {
                SelectValue = 41;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[4].Nodes[1].Checked == true)
            {
                SelectValue = 42;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }
            if (tv_UserRole.Nodes[4].Nodes[2].Checked == true)
            {
                SelectValue = 43;
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO USER_ROLES_DETAILS (USER_ID, USER_ROLE_ID) VALUES('" + skey + "', '" + SelectValue + "')";
                cmdsql.ExecuteNonQuery();
            }

            _conn.Close();
        }

        private void DeleteRoles()
        {
             KeyValuePair SubLoc = (KeyValuePair)cmb_User.SelectedItem;
            skey = SubLoc.Key.ToString();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();

            cmdsql.Connection = _conn;
            cmdsql.CommandText = "DELETE FROM USER_ROLES_DETAILS WHERE (USER_ID = '" + skey + "')";
            cmdsql.ExecuteNonQuery();

            _conn.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRoles();
                CheckNodes();
                MessageBox.Show("User Roles are Successfully Created", "User Role Creation");
            }
            catch (Exception)
            {
                MessageBox.Show("Some Error Occured", "User Role Creation");
            }
        }

        private void frm_CreateUserRoles_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            GetRoles();
            Loadtv();
            AddComboUsers();
        }

        private void Loadtv()
        {
            tv_UserRole.Nodes[0].Expand();
            tv_UserRole.Nodes[1].Expand();
            tv_UserRole.Nodes[2].Expand();
            tv_UserRole.Nodes[3].Expand();
            tv_UserRole.Nodes[4].Expand();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class KeyValuePair
        {
            public object Key;
            public string Value;

            public KeyValuePair(object NewValue, string NewDescription)
            {
                Key = NewValue;
                Value = NewDescription;
            }

            public override string ToString()
            {
                return Value;
            }
        }

        private void AddComboUsers()
        {
            ClearTreeViewData();
            //cmb_User.Items.Clear();
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdUser = new SqlCommand("SELECT ACC_LEVEL, USER_NAME, USER_ID FROM USER_LOGIN WHERE (USER_ID <> 'SysAdmin')", _conn);
            SqlDataReader drUser = cmdUser.ExecuteReader();
            while (drUser.Read())
            {
                cmb_User.Items.Add(new KeyValuePair(drUser["USER_ID"], drUser["USER_NAME"].ToString()));
            }
            
            drUser.Close();
            _conn.Close();
        }

        private void ClearTreeViewData()
        {
                tv_UserRole.Nodes[0].Nodes[0].Checked = false;
                tv_UserRole.Nodes[0].Nodes[1].Checked = false;
                tv_UserRole.Nodes[0].Nodes[1].Nodes[0].Checked = false;
                tv_UserRole.Nodes[0].Nodes[1].Nodes[1].Checked = false;
                tv_UserRole.Nodes[0].Nodes[2].Checked = false;
                tv_UserRole.Nodes[0].Nodes[2].Nodes[0].Checked = false;
                tv_UserRole.Nodes[1].Nodes[0].Checked = false;
                tv_UserRole.Nodes[1].Nodes[1].Checked = false;
                tv_UserRole.Nodes[1].Nodes[2].Checked = false;
                tv_UserRole.Nodes[1].Nodes[3].Checked = false;
                tv_UserRole.Nodes[2].Nodes[0].Checked = false;
                tv_UserRole.Nodes[2].Nodes[1].Checked = false;
                tv_UserRole.Nodes[2].Nodes[2].Checked = false;
                tv_UserRole.Nodes[3].Nodes[0].Checked = false;
                tv_UserRole.Nodes[3].Nodes[0].Nodes[0].Checked = false;
                tv_UserRole.Nodes[3].Nodes[0].Nodes[1].Checked = false;
                tv_UserRole.Nodes[3].Nodes[0].Nodes[2].Checked = false;
                tv_UserRole.Nodes[3].Nodes[1].Checked = false;
                tv_UserRole.Nodes[4].Nodes[0].Checked = false;
                tv_UserRole.Nodes[4].Nodes[1].Checked = false;
                tv_UserRole.Nodes[4].Nodes[2].Checked = false;
        }

        private void cmb_User_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearTreeViewData();
            LoadUserMenu();
            btnOK.Enabled = true;
        }

        private void LoadUserMenu()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdUser = new SqlCommand("SELECT USER_NAME, USER_ID, ACC_LEVEL, USER_ROLE_ID FROM VW_USER_ROLE WHERE USER_NAME = '" + cmb_User.Text.Trim() + "'", _conn);
            SqlDataReader drUser = cmdUser.ExecuteReader();

            while (drUser.Read())
            {
                //cmb_User.Items.Add(new KeyValuePair(drUser["ACC_LEVEL"], drUser["USER_NAME"].ToString()));

                //************** Admin ***************

                if (drUser["USER_ROLE_ID"].ToString() == "1")
                {
                    tv_UserRole.Nodes[0].Nodes[0].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "2")
                {
                    tv_UserRole.Nodes[0].Nodes[1].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "3")
                {
                    tv_UserRole.Nodes[0].Nodes[1].Nodes[0].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "4")
                {
                    tv_UserRole.Nodes[0].Nodes[1].Nodes[1].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "5")
                {
                    tv_UserRole.Nodes[0].Nodes[2].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "6")
                {
                    tv_UserRole.Nodes[0].Nodes[2].Nodes[0].Checked = true;
                }

                //************** Edit Mode ***************

                if (drUser["USER_ROLE_ID"].ToString() == "11")
                {
                    tv_UserRole.Nodes[1].Nodes[0].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "12")
                {
                    tv_UserRole.Nodes[1].Nodes[1].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "13")
                {
                    tv_UserRole.Nodes[1].Nodes[2].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "14")
                {
                    tv_UserRole.Nodes[1].Nodes[3].Checked = true;
                }

                //************** Process ***************

                if (drUser["USER_ROLE_ID"].ToString() == "21")
                {
                    tv_UserRole.Nodes[2].Nodes[0].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "22")
                {
                    tv_UserRole.Nodes[2].Nodes[1].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "23")
                {
                    tv_UserRole.Nodes[2].Nodes[2].Checked = true;
                }

                //************** Tools ***************

                if (drUser["USER_ROLE_ID"].ToString() == "31")
                {
                    tv_UserRole.Nodes[3].Nodes[0].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "32")
                {
                    tv_UserRole.Nodes[3].Nodes[0].Nodes[0].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "33")
                {
                    tv_UserRole.Nodes[3].Nodes[0].Nodes[1].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "34")
                {
                    tv_UserRole.Nodes[3].Nodes[0].Nodes[2].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "35")
                {
                    tv_UserRole.Nodes[3].Nodes[1].Checked = true;
                }

                //************** Reports ***************

                if (drUser["USER_ROLE_ID"].ToString() == "41")
                {
                    tv_UserRole.Nodes[4].Nodes[0].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "42")
                {
                    tv_UserRole.Nodes[4].Nodes[1].Checked = true;
                }
                if (drUser["USER_ROLE_ID"].ToString() == "43")
                {
                    tv_UserRole.Nodes[4].Nodes[2].Checked = true;
                }
            }
            drUser.Close();
            _conn.Close();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}