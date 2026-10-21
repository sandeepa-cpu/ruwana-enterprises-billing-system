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
    public partial class frm_HoldPayOfficeEmployee : Form
    {
        public frm_HoldPayOfficeEmployee()
        {
            InitializeComponent();
        }
        private SqlConnection _Conn;
        int Hold;
        int Resume;

        private void btn_Resume_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "UPDATE EMPLOYEES SET STATUS = '1' WHERE EMP_NO = '" + lblEmpNo.Text + "'";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                MessageBox.Show("Selected Employee is Successfully Deactivated", "Deactivation......");
                dreader.Close();
                _Conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Select an Employee to Deactivate", "Deactivation......");
            }

            btn_Hold.Enabled = false;
            btn_Resume.Enabled = false;
            Inactive();
            Active();

        }


        private void btn_Hold_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "UPDATE EMPLOYEES SET STATUS = '0'WHERE EMP_NO = '" + lblEmpNo.Text + "'";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                MessageBox.Show("Selected Employee is Successfully Deactivated", "Deactivation......");
                dreader.Close();
                _Conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Select an Employee to Deactivate", "Deactivation......");
            }
            
            btn_Hold.Enabled = false;
            btn_Resume.Enabled = false;
            Inactive();
            Active();
        }

        private void frm_HoldPayOfficeEmployee_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            cmb_FindEmp.MaxDropDownItems = 10;
            Find_EMPLOYEESCode();
            Inactive();
            Active();
        }

        private void Active()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT EMP_NO, INITIALS + ' ' + NAME AS NAME FROM EMPLOYEES WHERE (EMP_CATEGORY = 1 OR EMP_CATEGORY = 0) AND (STATUS = 1)ORDER BY CONVERT(INT,EMP_NO)", _Conn);
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

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT EMP_NO, INITIALS + ' ' + NAME AS NAME FROM EMPLOYEES WHERE (EMP_CATEGORY = 1 OR EMP_CATEGORY = 0) AND (STATUS = 0) ORDER BY CONVERT(INT,EMP_NO)", _Conn);
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
            Grid_A.Columns[1].Width = 220;
            Grid_A.Columns[1].HeaderText = "NAME";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = true;

            Grid_A.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
            Grid_B.Columns[1].Width = 220;
            Grid_B.Columns[1].HeaderText = "NAME";

            Grid_B.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[0].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_B.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;

            Grid_B.Columns[0].ReadOnly = true;
            Grid_B.Columns[1].ReadOnly = true;

            Grid_B.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_B.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void Find_EMPLOYEESCode()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdLoanA = new SqlCommand("SELECT EMP_NO, EMP_NO + ' - ' + NAME + ' ' + INITIALS AS NAME FROM EMPLOYEES WHERE (EMP_CATEGORY = 1 OR EMP_CATEGORY = 0) ORDER BY CONVERT(INT, EMP_NO)", _Conn);
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

            SqlCommand cmdLoanA = new SqlCommand("SELECT EMP_NO, EMP_NO + ' - ' + NAME + ' ' + INITIALS AS NAME FROM EMPLOYEES WHERE (EMP_CATEGORY = 1 OR EMP_CATEGORY = 0) AND (EMP_NO + ' - ' + NAME + ' ' + INITIALS = '" + cmb_FindEmp.Text + "') ORDER BY CONVERT(INT, EMP_NO)", _Conn);
            SqlDataReader drLoanA = cmdLoanA.ExecuteReader();
            while (drLoanA.Read())
            {
                lblEmpNo.Text = drLoanA["EMP_NO"].ToString();
            }
            drLoanA.Close();
            _Conn.Close();
        }

        private void LoanStatus()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT EMP_NO + ' - ' + NAME + ' ' + INITIALS AS NAME, STATUS FROM EMPLOYEES WHERE (EMP_CATEGORY = 1 OR EMP_CATEGORY = 0) AND (EMP_NO + ' - ' + NAME + ' ' + INITIALS = '" + cmb_FindEmp.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                Hold = int.Parse(dreader["STATUS"].ToString());
            }

            if (Hold == 0)
            {
                btn_Hold.Enabled = false;
                btn_Resume.Enabled = true;
            }
            else if (Hold == 1)
            {
                btn_Hold.Enabled = true;
                btn_Resume.Enabled = false;
            }

            cmdsql.Dispose();
            dreader.Dispose();
        }

        private void cmb_FindEmp_Leave(object sender, EventArgs e)
        {
            Find_EMPCode();
            LoanStatus();
        }

        private void cmb_FindEmp_SelectedValueChanged(object sender, EventArgs e)
        {
            Find_EMPCode();
            LoanStatus();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_FindEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Find_EMPCode();
            LoanStatus();
        }
    }
}