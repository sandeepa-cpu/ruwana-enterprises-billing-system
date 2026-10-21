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
    public partial class frm_Employee_Leave_Taken : Form
    {
        public frm_Employee_Leave_Taken()
        {
            InitializeComponent();
        }
        private SqlConnection _Conn;
        string EMP_NO = "";
        decimal NODAYS = 0;
        decimal ALL = 0, BAL = 0;

        CommonProfiles getComProfiles = new CommonProfiles();

        private void button2_Click(object sender, EventArgs e)
        {
            if (BAL == 0)
            {
                MessageBox.Show("No " + cmbType.Text + " Leave Available for the Year");
                cmbType.Focus();
                return;
            }

            else if (BAL >= Convert.ToDecimal(txtAmnt.Text))
            {
                try
                {
                    Connection.DatabaseConnection obyConn;

                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _Conn;
                    cmdsql1.CommandText = "INSERT INTO EMPLOYEE_LEAVE (PRO_DATE, EMP_NO, LEAVE, NODAYS) VALUES ('" + dt_Start.Value + "', '" + EMP_NO + "', '" + cmbType.Text + "', '" + txtAmnt.Text + "')";
                    cmdsql1.ExecuteNonQuery();

                    SqlCommand cmdsql2 = new SqlCommand();
                    cmdsql2.Connection = _Conn;
                    cmdsql2.CommandText = "UPDATE EMPLOYEE_LEAVE_MAIN SET BALDAYS = BALDAYS - '" + txtAmnt.Text + "' WHERE EMP_NO = '" + EMP_NO + "' AND LEAVE = '" + cmbType.Text.Trim() + "' AND PRO_YEAR = '" + lblYear.Text + "' ";
                    cmdsql2.ExecuteNonQuery();

                    MessageBox.Show(cmbType.Text + " Added Successfully");
                    ShowDetails();
                    ShowDetailsA();
                }

                catch (Exception)
                {
                    MessageBox.Show(cmbType.Text + " has already Entered");
                }
            }
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT PRO_DATE, NAME, LEAVE, NODAYS FROM VW_EMPLOYEE_LEAVE WHERE EMP_NO = '" + EMP_NO + "' AND PRO_YEAR = '" + lblYear.Text + "'", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "VW_EMPLOYEE_LEAVE");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "VW_EMPLOYEE_LEAVE";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 120;
            Grid_A.Columns[0].HeaderText = "DATE";
            Grid_A.Columns[1].Width = 250;
            Grid_A.Columns[1].HeaderText = "NAME";
            Grid_A.Columns[2].Width = 150;
            Grid_A.Columns[2].HeaderText = "LEAVE TYPE";
            Grid_A.Columns[3].Width = 80;
            Grid_A.Columns[3].HeaderText = "NO OF DAYS";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;

            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_A.Columns[3].DefaultCellStyle.ForeColor = Color.Maroon;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = false;
            Grid_A.Columns[2].ReadOnly = false;

            Grid_A.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

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

            Grid_A.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }


        private void ShowDetailsA()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT LEAVE, NODAYS, BALDAYS FROM EMPLOYEE_LEAVE_MAIN WHERE EMP_NO = '" + EMP_NO + "' AND PRO_YEAR = '" + lblYear.Text + "' ORDER BY LEAVE", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "EMPLOYEE_LEAVE_MAIN");

            Grid_B.DataSource = dsLoan;
            Grid_B.DataMember = "EMPLOYEE_LEAVE_MAIN";

            _Conn.Close();

            FillGrid();
        }

        private void FillGridA()
        {
            Grid_B.Columns[0].Width = 230;
            Grid_B.Columns[0].HeaderText = "LEAVE TYPE";
            Grid_B.Columns[1].Width = 120;
            Grid_B.Columns[1].HeaderText = "UTILIEZED";

            Grid_B.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;

            Grid_B.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_B.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;

            Grid_B.Columns[0].ReadOnly = true;
            Grid_B.Columns[1].ReadOnly = false;

            Grid_B.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_B.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            Grid_B.AutoGenerateColumns = false;
            Grid_B.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            Grid_B.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Grid_B.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
            Grid_B.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            Grid_B.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_B.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            Grid_B.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_B.MultiSelect = false;
            Grid_B.RowHeadersVisible = true;

            Grid_B.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_B.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_B.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_B.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }


        private void frm_JobType_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            
            PRO_DATE();
            EMPNAME();
            TYPE();
            ShowDetails();
        }

        private void PRO_DATE()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT YEAR(PRO_DATE) AS YEAR, PRO_DATE FROM PRO_DATE";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                dt_Start.Value = Convert.ToDateTime(dreader["PRO_DATE"].ToString());
                lblYear.Text = dreader["YEAR"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void EMPNAME()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT NAME FROM VW_EMPLOYEES";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbEmp.Items.Add(dreader["NAME"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void EMPNO()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT EMP_NO FROM VW_EMPLOYEES WHERE NAME = '" + cmbEmp.Text.Trim() + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                EMP_NO = dreader["EMP_NO"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void TYPE()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT LEAVE FROM LEAVE_MAIN";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                //NODAYS = dreader["NODAYS"].ToString();
                cmbType.Items.Add(dreader["LEAVE"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }



        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

        private void cmbEmp_SelectedValueChanged(object sender, EventArgs e)
        {
            EMPNO();
            ShowDetails();
            ShowDetailsA();
        }

        private void cmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            ALLBALLEAVE();
        }

        private void ALLBALLEAVE()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT LEAVE, NODAYS, BALDAYS FROM  EMPLOYEE_LEAVE_MAIN WHERE PRO_YEAR = '" + lblYear.Text + "' AND LEAVE = '" + cmbType.Text.Trim() + "'AND EMP_NO = '" + EMP_NO + "' GROUP BY LEAVE, NODAYS, BALDAYS";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                ALL = decimal.Parse(dreader["NODAYS"].ToString());
                BAL = decimal.Parse(dreader["BALDAYS"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void txtAmnt_Leave(object sender, EventArgs e)
        {
            decimal amnts = decimal.Parse(txtAmnt.Text);
            if (amnts < 0)
            {
                MessageBox.Show(cmbType.Text + " Amount should be entered");
                txtAmnt.ResetText();
                txtAmnt.Focus();
                return;
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
