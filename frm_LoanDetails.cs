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
    public partial class frm_LoanDetails : Form
    {
        public frm_LoanDetails()
        {
            InitializeComponent();
        }

        private SqlConnection _Conn;
        
        private void cmb_Find_Emp_SelectedValueChanged(object sender, EventArgs e)
        {
            txt_Emp_No.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT * FROM VW_EMPLOYEES WHERE (NAME = '" + cmb_Find_Emp.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txt_Emp_No.Text = dreader["EMP_NO"].ToString();
            }

            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void frm_LoanDetails_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            Loan_Details();
            Find_Employees();
            cmb_Loan_ID.Focus();
            cmb_Loan_ID.MaxDropDownItems = 5;
            cmb_Find_Emp.MaxDropDownItems = 5;
        }

        private void Loan_Details()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdLoan = new SqlCommand("SELECT LOAN_ID, LOAN_DESC, DED_ID, LOAN_ID + '  -  ' + LOAN_DESC AS COM_LOAN_DESC FROM LOAN_MAIN", _Conn);
            SqlDataReader drLoan = cmdLoan.ExecuteReader();
            while (drLoan.Read())
            {
                cmb_Loan_ID.Items.Add(drLoan["COM_LOAN_DESC"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }
            drLoan.Close();
            _Conn.Close();
        }

        private void Find_Employees()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdLoanA = new SqlCommand("SELECT * FROM VW_EMPLOYEES ORDER BY CONVERT(INT,EMP_NO)", _Conn);
            SqlDataReader drLoanA = cmdLoanA.ExecuteReader();
            while (drLoanA.Read())
            {
                cmb_Find_Emp.Items.Add(drLoanA["NAME"].ToString());// + " " + drLoanA["NAME"].ToString());
            }
            drLoanA.Close();
            _Conn.Close();
        }
      

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Emp_No.Text == "" || txt_Interest.Text == "" || txt_Loan_Amount.Text == "" || txt_Loan_ID.Text == "" || txt_No_Installments.Text == "")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Loan Information");
                    return;
                }
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "INSERT INTO LOAN_DETAILS (LOAN_ID, EMP_NO, LOAN_AMOUNT, BAL_AMOUNT, INTEREST, NO_INST, BAL_INST, STATUS, LOAN_DATE) VALUES ('" + txt_Loan_ID.Text + "','" + txt_Emp_No.Text + "','" + txt_Loan_Amount.Text + "','" + txt_Loan_Amount.Text + "','" + txt_Interest.Text + "','" + txt_No_Installments.Text + "','" + txt_No_Installments.Text + "','1', Convert(DateTime,'"+ dtp_LoanDate.Text +"'))";
                cmdsql.ExecuteNonQuery();
                MessageBox.Show("Employee Loan Entry Successfully Added");
                txt_Emp_No.Clear();
                txt_Interest.Clear();
                txt_Loan_Amount.Clear();
                txt_No_Installments.Clear();
                cmb_Find_Emp.ResetText();
                _Conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Loan Information");
                return;
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_Loan_ID_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT LOAN_ID, LOAN_DESC, DED_ID, LOAN_ID + '  -  ' + LOAN_DESC AS COM_LOAN_DESC FROM LOAN_MAIN WHERE(LOAN_ID + '  -  ' + LOAN_DESC = '" + cmb_Loan_ID.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txt_Loan_ID.Text = dreader["LOAN_ID"].ToString();
                if (dreader["LOAN_DESC"].ToString().Trim() == "Festival Advance")
                {
                    txt_Interest.Text = "0";
                    txt_Interest.Enabled = false;
                }
                else
                {
                    txt_Interest.Enabled = true;
                }
            }
            
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void txt_Interest_TextChanged(object sender, EventArgs e)
        {

        }

      }
}