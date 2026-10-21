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
    public partial class frm_HoldLoanDeductions : Form
    {
        public frm_HoldLoanDeductions()
        {
            InitializeComponent();
        }

        private SqlConnection _Conn;
        int Hold;
        int Resume;

        private void chk_Hold_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
                if (cmb_FindEmp.Text == "")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Hold/Resume Loans");
                    return;
                }
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "UPDATE LOAN_DETAILS SET STATUS = 0 WHERE BAL_INST >= 1 AND (EMP_NO = '" + lblEmpNo.Text + "')";
                cmdsql.ExecuteNonQuery();
                //MessageBox.Show("Hold/Resume Loans Entry Successfully Updated");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Hold/Resume Loans");
            //    return;
            //}
            chk_Hold.Checked = false;
            chk_Hold.Enabled = false;
            Inactive();
            Active();
            
        }

        private void chk_Resume_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
                if (cmb_FindEmp.Text == "")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Hold/Resume Loans");
                    return;
                }
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "UPDATE LOAN_DETAILS SET STATUS = 1 WHERE BAL_INST >= 1 AND (EMP_NO = '" + lblEmpNo.Text + "')";
                cmdsql.ExecuteNonQuery();
                //MessageBox.Show("Hold/Resume Loans Entry Successfully Updated");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Hold/Resume Loans");
            //    return;
            //}
            chk_Resume.Checked = false;
            chk_Resume.Enabled = false;
            Inactive();
            Active();
           
        }
       
        private void frm_HoldLoanDeductions_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            cmb_FindEmp.MaxDropDownItems = 10;
            //cmb_EMP_NO.MaxDropDownItems = 10;
            //EMPLOYEESName();
            //Find_EMPLOYEESCodeSearch();
            Find_EMPLOYEESCode();
            //EMPLOYEESNameSearch();
            Inactive();
            Active();
        }

        private void Active()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT LOAN_DETAILS.EMP_NO, EMPLOYEES.INITIALS + ' ' + EMPLOYEES.NAME AS NAME, LOAN_DETAILS.LOAN_AMOUNT, LOAN_DETAILS.NO_INST, LOAN_DETAILS.BAL_AMOUNT, LOAN_DETAILS.BAL_INST FROM  LOAN_DETAILS INNER JOIN EMPLOYEES ON LOAN_DETAILS.EMP_NO = EMPLOYEES.EMP_NO WHERE (LOAN_DETAILS.STATUS = 1)", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "ACTIVE");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "ACTIVE";

            _Conn.Close();

            FillGrid_A();
        }

        private void Inactive()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT LOAN_DETAILS.EMP_NO, EMPLOYEES.INITIALS + ' ' + EMPLOYEES.NAME AS NAME, LOAN_DETAILS.LOAN_AMOUNT, LOAN_DETAILS.NO_INST, LOAN_DETAILS.BAL_AMOUNT, LOAN_DETAILS.BAL_INST FROM  LOAN_DETAILS INNER JOIN EMPLOYEES ON LOAN_DETAILS.EMP_NO = EMPLOYEES.EMP_NO WHERE LOAN_DETAILS.BAL_INST != 0 AND (LOAN_DETAILS.STATUS = 0)", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "INACTIVE");

            Grid_B.DataSource = dsLoan;
            Grid_B.DataMember = "INACTIVE";

            _Conn.Close();

            FillGrid_B();
        }

        private void FillGrid_A()
        {
            Grid_A.AutoGenerateColumns = false;
            Grid_A.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            Grid_A.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Grid_A.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
            Grid_A.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            Grid_A.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_A.MultiSelect = false;
            Grid_A.RowHeadersVisible = true;

            Grid_A.Columns[0].Width = 65;
            Grid_A.Columns[0].HeaderText = "EMP.NO.";
            Grid_A.Columns[1].Width = 200;
            Grid_A.Columns[1].HeaderText = "NAME";
            Grid_A.Columns[2].Width = 100;
            Grid_A.Columns[2].HeaderText = "LOAN AMOUNT";
            Grid_A.Columns[3].Width = 50;
            Grid_A.Columns[3].HeaderText = "INST.";
            Grid_A.Columns[4].Width = 100;
            Grid_A.Columns[4].HeaderText = "BALANCE AMOUNT";
            Grid_A.Columns[5].Width = 50;
            Grid_A.Columns[5].HeaderText = "BALANCE";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[5].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[3].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[5].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;
            Grid_A.Columns[3].ReadOnly = true;
            Grid_A.Columns[4].ReadOnly = true;
            Grid_A.Columns[5].ReadOnly = true;

            Grid_A.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void FillGrid_B()
        {
            Grid_B.AutoGenerateColumns = false;
            Grid_B.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            Grid_B.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Grid_B.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_B.Font, FontStyle.Bold);
            Grid_B.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            Grid_B.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_B.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            Grid_B.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_B.MultiSelect = false;
            Grid_B.RowHeadersVisible = true;

            Grid_B.Columns[0].Width = 65;
            Grid_B.Columns[0].HeaderText = "EMP.NO.";
            Grid_B.Columns[1].Width = 200;
            Grid_B.Columns[1].HeaderText = "NAME";
            Grid_B.Columns[2].Width = 100;
            Grid_B.Columns[2].HeaderText = "LOAN AMOUNT";
            Grid_B.Columns[3].Width = 50;
            Grid_B.Columns[3].HeaderText = "INST.";
            Grid_B.Columns[4].Width = 100;
            Grid_B.Columns[4].HeaderText = "BALANCE AMOUNT";
            Grid_B.Columns[5].Width = 50;
            Grid_B.Columns[5].HeaderText = "BALANCE";
           
            Grid_B.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[5].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[0].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_B.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_B.Columns[2].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_B.Columns[3].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_B.Columns[4].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_B.Columns[5].DefaultCellStyle.ForeColor = Color.Maroon;
       

            Grid_B.Columns[0].ReadOnly = true;
            Grid_B.Columns[1].ReadOnly = true;
            Grid_B.Columns[2].ReadOnly = true;
            Grid_B.Columns[3].ReadOnly = true;
            Grid_B.Columns[4].ReadOnly = true;
            Grid_B.Columns[5].ReadOnly = true;
           

            Grid_B.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_B.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_B.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_B.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_B.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_B.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void Find_EMPLOYEESCode()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdLoanA = new SqlCommand("SELECT LOAN_DETAILS.EMP_NO, EMPLOYEES.EMP_NO + ' - ' + EMPLOYEES.NAME + ' ' + EMPLOYEES.INITIALS AS NAME FROM LOAN_DETAILS INNER JOIN EMPLOYEES ON LOAN_DETAILS.EMP_NO = EMPLOYEES.EMP_NO WHERE (LOAN_DETAILS.BAL_INST >= '1')ORDER BY CONVERT(INT, LOAN_DETAILS.EMP_NO)", _Conn);
            SqlDataReader drLoanA = cmdLoanA.ExecuteReader();
            while (drLoanA.Read())
            {
                cmb_FindEmp.Items.Add(drLoanA["NAME"].ToString());// + " " + drLoanA["NAME"].ToString());
                //lblEmpNo.Text = drLoanA["EMP_NO"].ToString();
            }
            drLoanA.Close();
            _Conn.Close();
        }

        private void Find_EMPCode()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdLoanA = new SqlCommand("SELECT LOAN_DETAILS.EMP_NO, EMPLOYEES.EMP_NO + ' - ' + EMPLOYEES.NAME + ' ' + EMPLOYEES.INITIALS AS NAME FROM LOAN_DETAILS INNER JOIN EMPLOYEES ON LOAN_DETAILS.EMP_NO = EMPLOYEES.EMP_NO WHERE (LOAN_DETAILS.BAL_INST >= '1') AND (EMPLOYEES.EMP_NO + ' - ' + EMPLOYEES.NAME + ' ' + EMPLOYEES.INITIALS = '" + cmb_FindEmp.Text + "') ORDER BY CONVERT(INT, LOAN_DETAILS.EMP_NO)", _Conn);
            SqlDataReader drLoanA = cmdLoanA.ExecuteReader();
            while (drLoanA.Read())
            {
                lblEmpNo.Text = drLoanA["EMP_NO"].ToString();
            }
            drLoanA.Close();
            _Conn.Close();
        }

        private void cmb_FindEMP_Leave(object sender, EventArgs e)
        {
            //Find_EMPLOYEESCodeSearch();
            //LoanStatus();
        }

        private void cmb_EMP_NO_Leave(object sender, EventArgs e)
        {
            //EMPLOYEESNameSearch();
            //LoanStatus();
        }

        private void cmb_EMP_NO_SelectedValueChanged(object sender, EventArgs e)
        {
            //EMPLOYEESNameSearch();
            //LoanStatus();
        }

        private void cmb_FindEMP_SelectedValueChanged(object sender, EventArgs e)
        {
            //EMPLOYEESNameSearch();
            //LoanStatus();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoanStatus()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT EMPLOYEES.EMP_NO + ' - ' + EMPLOYEES.NAME + ' ' + EMPLOYEES.INITIALS AS NAME, LOAN_DETAILS.STATUS AS STATUS, LOAN_DETAILS.BAL_INST AS BAL_INST FROM LOAN_DETAILS INNER JOIN EMPLOYEES ON LOAN_DETAILS.EMP_NO = EMPLOYEES.EMP_NO WHERE (LOAN_DETAILS.BAL_INST >= 1) AND (EMPLOYEES.EMP_NO + ' - ' + EMPLOYEES.NAME + ' ' + EMPLOYEES.INITIALS = '" + cmb_FindEmp.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                Hold = int.Parse(dreader["STATUS"].ToString());
            }
            
            if (Hold == 0)
            {
                chk_Hold.Enabled = false;
                chk_Resume.Enabled = true;
            }
            else if (Hold == 1)
            {
                chk_Hold.Enabled = true;
                chk_Resume.Enabled = false;
            }

            cmdsql.Dispose();
            dreader.Dispose();
        }

        private void cmb_EMP_NO_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //EMPLOYEESNameSearch();
                //LoanStatus();
            }
        }

        private void cmb_FindEMP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Find_EMPLOYEESCodeSearch();
            //LoanStatus();
        }

        private void cmb_FindEmp_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //EMPLOYEESNameSearch();
            Find_EMPCode();
            LoanStatus();
        }

        private void cmb_FindEmp_Leave_1(object sender, EventArgs e)
        {
            //EMPLOYEESNameSearch();
            Find_EMPCode();
            LoanStatus();
        }

        private void cmb_FindEmp_SelectedValueChanged_1(object sender, EventArgs e)
        {
            //EMPLOYEESNameSearch();
            Find_EMPCode();
            LoanStatus();
        }
     
    }
}