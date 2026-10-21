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
    public partial class frm_Overtime_Period : Form
    {
        public frm_Overtime_Period()
        {
            InitializeComponent();
        }
        private SqlConnection _conn;
        private string skey;
        private string strTen;

        private void frm_Overtime_Period_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            TenNos();
            cmb_Ten_No.Focus();
        }

        private void TenNos()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strHired = ("SELECT TEN_NO, TEN_NO + ' - ' + DESCRIPTION AS DESCRIPTION FROM TENDER_MAIN WHERE (OT_METHOD = 'DUR')");
            SqlCommand cmdTenNo = new SqlCommand(strHired, _conn);
            SqlDataReader drTenNo = cmdTenNo.ExecuteReader();

            while (drTenNo.Read())
            {
                cmb_Ten_No.Items.Add(new KeyValuePair(drTenNo["TEN_NO"], drTenNo["DESCRIPTION"].ToString()));
            }

            drTenNo.Close();
            _conn.Close();
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

        private void cmb_Ten_No_SelectedValueChanged(object sender, EventArgs e)
        {
            txtRate.Text = "";

            KeyValuePair TenNo = (KeyValuePair)cmb_Ten_No.SelectedItem;
            strTen = TenNo.Key.ToString();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPeriod.Text == "")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Over Time - Period");
                    return;
                }

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();

                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO OVER_TIME_RATES_PERIOD (TEN_NO, OT_CATEGORY, RATE) VALUES ('" + strTen + "','" + cmbPeriod.Text + "', '" + txtRate.Text + "')";
                cmdsql.ExecuteNonQuery();

                MessageBox.Show("Entry Successfully Added");
            }
            catch (Exception)
            {
                MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Duration Information");
                return;
            }
            _conn.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbPeriod_SelectedValueChanged(object sender, EventArgs e)
        {
            txtRate.Text = "";

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strPeriod = ("SELECT TEN_NO, OT_CATEGORY, RATE FROM OVER_TIME_RATES_PERIOD WHERE (OT_CATEGORY = '" + cmbPeriod.Text + "') AND (TEN_NO = '" + strTen + "')");
            SqlCommand cmdPeriod = new SqlCommand(strPeriod, _conn);
            SqlDataReader drPeriod = cmdPeriod.ExecuteReader();

            while (drPeriod.Read())
            {
                txtRate.Text = drPeriod["RATE"].ToString();
            }

            if (drPeriod.HasRows == true)
            {
                btn_Update.Enabled = true;
            }
            else
                btn_Update.Enabled = false;

            drPeriod.Close();
            _conn.Close();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;

                
                    cmdsql.CommandText = "UPDATE OVER_TIME_RATES_PERIOD SET RATE = '" + txtRate.Text + "' WHERE (TEN_NO = '" + strTen + "') AND (OT_CATEGORY = '" + cmbPeriod.Text + "')";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("Entry Successfully Added", "Duration Information");
                    _conn.Close();   
            }                
            catch (Exception)
            {
                MessageBox.Show("Update Error", "Duration Information");
            }
        }
    }
}