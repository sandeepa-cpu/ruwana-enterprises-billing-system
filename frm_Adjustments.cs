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
    public partial class frm_Adjustments : Form
    {
        CommonProfiles objComPro = new CommonProfiles();

        public frm_Adjustments()
        {
            InitializeComponent();
        }

        private SqlConnection _Conn;
        private int intYear = 0;
        private int intMonth = 0;
        private DateTime dtProDate;
        private string Emp;
        private string strFind;

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_EmpNo.Text=="" || txt_AMOUNT.Text == "")
            {
                MessageBox.Show("Please Enter the Employee Number, Amount and Proceed","Adjustments");
                txt_EmpNo.Focus();
            }

            else
            {
                try
                {
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "INSERT INTO ADJUSTMENTS (EMP_NO, CAT_ID, AMOUNT, STATUS, ADJ_DATE, IN_YEAR, IN_MONTH)VALUES ('" + txt_EmpNo.Text + "', '" + txt_CAT_ID.Text + "', '" + txt_AMOUNT.Text + "', 1,'" + DateTime.Now.Date.ToShortDateString() + "', '" + intYear + "', '" + intMonth + "')";
                    cmdsql.ExecuteNonQuery();
                    if (rb_Earnings.Checked)
                    {
                        MessageBox.Show("Earning Successfully Added", "Adjustment Details");
                    }
                    else if (rb_Deduction.Checked)
                    {
                        MessageBox.Show("Deduction Successfully Added", "Adjustment Details");
                    }
                    _Conn.Close();

                    txt_EmpNo.Text = "";
                    cmb_Find_Emp.Text = "";

                    cmb_Find_Emp.Focus();
                    cmb_Find_Emp.DroppedDown = true;
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Adjustment Detail Already Entered","Adjustment Details");

                    cmb_Find_Emp.Focus();
                    cmb_Find_Emp.DroppedDown = true;
                }
            }

        }

        private void rb_Earnings_CheckedChanged(object sender, EventArgs e)
        {
            cmb_Category.Enabled = true;
            btn_Add.Enabled = true;
            cmb_Find_Emp.Text = "";
            txt_AMOUNT.Text = "";

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            string strPayTax = ("SELECT EAR_ID, DESCRIPTION, SLIP_ORDER FROM EARNINGS WHERE (STATUS = 1) AND (EAR_ID <> 'BASIC') AND (EAR_ID <> 'TOTEARN') AND (EAR_ID <> 'NETASAL') AND (EAR_ID <> 'TOTEPF')");

            DataTable tblPayTax = new DataTable();
            SqlCommand cmdPayTax = new SqlCommand(strPayTax, _Conn);
            SqlDataAdapter daPayTax = new SqlDataAdapter();

            daPayTax.SelectCommand = cmdPayTax;
            daPayTax.Fill(tblPayTax);

            cmb_Category.DataSource = tblPayTax;
            cmb_Category.DisplayMember = "DESCRIPTION";

            _Conn.Close();

            cmb_Category.Focus();
            cmb_Category.DroppedDown = true;

        }

        private void rb_Deduction_CheckedChanged(object sender, EventArgs e)
        {
            cmb_Category.Enabled = true;
            btn_Add.Enabled = true;
            cmb_Find_Emp.Text = "";
            txt_AMOUNT.Text = "";

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            string strPayTax = ("SELECT DED_ID, DESCRIPTION, SLIP_ORDER FROM DEDUCTIONS WHERE (STATUS = 1) AND (DED_ID <> 'EPF') AND (DED_ID <> 'EPF12') AND (DED_ID <> 'ETF') AND (DED_ID <> 'TOTDED') AND (DED_ID <> 'PAYTAX')");

            DataTable tblPayTax = new DataTable();
            SqlCommand cmdPayTax = new SqlCommand(strPayTax, _Conn);
            SqlDataAdapter daPayTax = new SqlDataAdapter();

            daPayTax.SelectCommand = cmdPayTax;
            daPayTax.Fill(tblPayTax);

            cmb_Category.DataSource = tblPayTax;
            cmb_Category.DisplayMember = "DESCRIPTION";
            _Conn.Close();

            cmb_Category.Focus();
            cmb_Category.DroppedDown = true;
        }

        private void cmb_Category_SelectedValueChanged(object sender, EventArgs e)
        {
            cmb_Find_Emp.Text = "";
            txt_AMOUNT.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            if (rb_Deduction.Checked)
            {                
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "SELECT DED_ID, DESCRIPTION FROM DEDUCTIONS WHERE (DESCRIPTION = '" + cmb_Category.Text + "')";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                while (dreader.Read())
                {
                    txt_CAT_ID.Text = dreader["DED_ID"].ToString();
                }
                cmdsql.Dispose();
                dreader.Dispose();
            }
           
            else if (rb_Earnings.Checked)
            {
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "SELECT EAR_ID, DESCRIPTION FROM EARNINGS WHERE (DESCRIPTION =  '" + cmb_Category.Text + "')";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                while (dreader.Read())
                {
                    txt_CAT_ID.Text = dreader["EAR_ID"].ToString();
                }
                cmdsql.Dispose();
                dreader.Dispose();
            }
           
            _Conn.Close();
        }
    
        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Adjustments_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            EMPLOYEES();
            //intYear = objComPro.GetYear();
            //intMonth = objComPro.GetMonth();
            rb_Earnings.Checked = true;
            cmb_Category.Focus();
            cmb_Category.DroppedDown = true;
            
        }

        private void EMPLOYEES()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT EMP_NO, NAME, EMP_RATE FROM VW_EMPLOYEES";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmb_Find_Emp.Items.Add(dreader["NAME"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();

            _Conn.Close();
        }

      
        private void cmb_Find_Emp_SelectedValueChanged(object sender, EventArgs e)
        {
            txt_EmpNo.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT EMP_NO, NAME FROM VW_EMPLOYEES WHERE (NAME = '" + cmb_Find_Emp.Text + "')";
                SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txt_EmpNo.Text = dreader["EMP_NO"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();

           
            Find_Entry();

        }

        private void Find_Entry()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            strFind = ("SELECT EMP_NO, CAT_ID, AMOUNT, ADJ_DATE FROM ADJUSTMENTS WHERE (STATUS = 1) AND (EMP_NO = '" + txt_EmpNo.Text + "') AND (CAT_ID = '" + txt_CAT_ID.Text + "')");

            SqlCommand cmdFind = new SqlCommand(strFind, _Conn);
            SqlDataReader drFind = cmdFind.ExecuteReader();

            while (drFind.Read())
            {
                txt_AMOUNT.Text = drFind["AMOUNT"].ToString();
            }

            if (drFind.HasRows == true)
            {
                btn_Add.Enabled = false;
                btn_Update.Enabled = true;
            }
            else if (drFind.HasRows == false)
            {
                btn_Add.Enabled = true;
                txt_AMOUNT.Text = "";
                btn_Update.Enabled = false;
            }

            drFind.Close();
            _Conn.Close();
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "UPDATE ADJUSTMENTS SET AMOUNT = '" + txt_AMOUNT.Text + "', ADJ_DATE = '" + DateTime.Now.Date.ToShortDateString() + "' WHERE (EMP_NO = '" + txt_EmpNo.Text + "') AND (CAT_ID = '" + txt_CAT_ID.Text + "') AND (STATUS = 1)";
                cmdsql.ExecuteNonQuery();
                if (rb_Earnings.Checked)
                {
                    MessageBox.Show("Earning Successfully Updated", "Adjustment Details");
                }
                else if (rb_Deduction.Checked)
                {
                    MessageBox.Show("Deduction Successfully Updated", "Adjustment Details");
                }
                _Conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Adjustment Update Error", "Adjustment Details");
            }
        }

        private void txt_EmpNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_Category_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmb_Find_Emp.Focus();
                cmb_Find_Emp.DroppedDown = true;
            }
           
        }

        private void cmb_Find_Emp_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_AMOUNT.Focus();
        }

    }
}