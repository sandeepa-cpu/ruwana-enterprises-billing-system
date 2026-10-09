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
    public partial class frm_Attendance : Form
    {
        CommonProfiles objComPro = new CommonProfiles();

        public frm_Attendance()
        {
            InitializeComponent();
        }
        private SqlConnection _conn;
        private int intYear = 0;
        private int intMonth = 0;
        string EMP;
        int EMPNO;
        public static string UserName;
        public static string UserID;
        private int GetUserLevel;
        string FINDEMP = "";

        private void PRO_DATE()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT YEAR(PRO_DATE) AS YEAR, MONTH(PRO_DATE) AS MONTH, PRO_DATE FROM PRO_DATE";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblDate.Text = dreader["PRO_DATE"].ToString();
                lblYear.Text = dreader["YEAR"].ToString();
                lblMonth.Text = dreader["MONTH"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _conn.Close();
        }

        private void EMPLOAD()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT NAME FROM VW_EMPLOYEES ORDER BY CONVERT(INT, EMP_NO)";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbEmp.Items.Add(dreader["NAME"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _conn.Close();
        }

        private void frm_Attendance_Load(object sender, EventArgs e)
        {
            PRO_DATE();
            EMPLOAD();
            //lblUser.Text = frm_UserLogIn.UserID;
            ShowDetails();
            intYear = objComPro.GetYear();
            intMonth = objComPro.GetMonth();
            string Month = "";
            
           if (intMonth == 1)
               Month = "JANUARY";
           if (intMonth == 2)
               Month = "FEBRUARY";
           if (intMonth == 3)
               Month = "MARCH";
           if (intMonth == 4)
               Month = "APRIL";
           if (intMonth == 5)
               Month = "MAY";
           if (intMonth == 6)
               Month = "JUNE";
           if (intMonth == 7)
               Month = "JULY";
           if (intMonth == 8)
               Month = "AUGUST";
           if (intMonth == 9)
               Month = "SEPTEMBER";
           if (intMonth == 10)
               Month = "OCTOBER";
           if (intMonth == 11)
               Month = "NOVEMBER";
           if (intMonth == 12)
               Month = "DECEMBER";

            lblYM.Text = intYear + " - " + Month + " udih ioyd meusKSfus f,aLKh";

            PRO_DATE();
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            //SqlDataAdapter drLoan = new SqlDataAdapter("SELECT EMP_NO, NAME, ATTEND, PRO_DATE, TIME_IN, TIME_OUT FROM VW_ATTENDANCE WHERE PRO_YEAR = '" + lblYear.Text + "' AND PRO_MONTH = '" + lblMonth.Text + "' ORDER BY CONVERT(int, EMP_NO)", _conn);
            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT EMP_NO, NAME, ATTEND, PRO_DATE, TIME_IN, TIME_OUT FROM VW_ATTENDANCE WHERE PRO_DATE = '" + lblDate.Value + "' ORDER BY CONVERT(int, EMP_NO)", _conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "VW_ATTENDANCE");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "VW_ATTENDANCE";

            _conn.Close();

            FillGrid();
        }

        private void ShowDetailsEmployee()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT EMP_NO, NAME, ATTEND, PRO_DATE, TIME_IN, TIME_OUT FROM VW_ATTENDANCE WHERE EMP_NO = '" + FINDEMP + "' AND PRO_YEAR = '" + lblYear.Text + "' AND PRO_MONTH = '" + lblMonth.Text + "' ORDER BY PRO_DATE", _conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "VW_ATTENDANCE");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "VW_ATTENDANCE";

            _conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 100;
            Grid_A.Columns[0].HeaderText = "EMP_NO";
            Grid_A.Columns[1].Width = 300;
            Grid_A.Columns[1].HeaderText = "EMPLOYEE NAME";
            Grid_A.Columns[2].Width = 120;
            Grid_A.Columns[2].HeaderText = "ATTENDANCE";
            Grid_A.Columns[3].Width = 120;
            Grid_A.Columns[3].HeaderText = "DATE";
            Grid_A.Columns[4].Width = 120;
            Grid_A.Columns[4].HeaderText = "TIME IN";
            Grid_A.Columns[5].Width = 120;
            Grid_A.Columns[5].HeaderText = "TIME OUT";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.Wheat;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.Wheat;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.White;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Maroon;

            Grid_A.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            Grid_A.Columns[4].DefaultCellStyle.Format = "hh:mm tt";
            Grid_A.Columns[5].DefaultCellStyle.Format = "hh:mm tt";

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = true;
            Grid_A.Columns[3].ReadOnly = true;

            Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Aradana", 8, FontStyle.Regular);

            Grid_A.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid_A.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid_A.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid_A.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;

            Grid_A.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT EMP_NO, NAME, ATTEND, PRO_DATE, TIME_IN, TIME_OUT FROM VW_ATTENDANCE WHERE PRO_YEAR = '" + lblYear.Text + "' AND PRO_MONTH = '" + lblMonth.Text + "' ORDER BY CONVERT(int, EMP_NO)", _conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "VW_ATTENDANCE");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["VW_ATTENDANCE"].Rows)
            {
                EMPNO = Convert.ToInt16(Grid_A.Rows[count].Cells[0].Value.ToString());
                
                DataGridViewCheckBoxCell ch2 = new DataGridViewCheckBoxCell();
                ch2 = (DataGridViewCheckBoxCell)Grid_A.Rows[count].Cells[2];

                if (ch2.Value == null)
                    ch2.Value = false;
                switch (ch2.Value.ToString())
                {
                    case "True":
                        ch2.Value = true;
                        string str_AdjINS = "UPDATE ATTEND_INFO SET ADDED_BY = '" + lblUser.Text + "', ADDED_DATE = '" + lblDate.Text + "', ATTEND = 1 WHERE EMP_NO = '" + EMPNO + "' AND (PRO_DATE = CONVERT(DATETIME, '" + lblDate.Text + "', 102))";
                        SqlCommand cmd_AdjINS = new SqlCommand(str_AdjINS, _conn);
                        cmd_AdjINS.ExecuteNonQuery();
                        cmd_AdjINS.Dispose();
                        break;
                    case "False":
                        ch2.Value = false;
                        string str_AdjINST = "UPDATE ATTEND_INFO SET  ADDED_BY = '" + lblUser.Text + "', ADDED_DATE = '" + lblDate.Text + "', ATTEND = 0 WHERE EMP_NO = '" + EMPNO + "' AND (PRO_DATE = CONVERT(DATETIME, '" + lblDate.Text + "', 102))";
                        SqlCommand cmd_AdjINST = new SqlCommand(str_AdjINST, _conn);
                        cmd_AdjINST.ExecuteNonQuery();
                        cmd_AdjINST.Dispose();
                        break;
                }
                count++;
            }
            _conn.Close();
            //MessageBox.Show("Member's Attendance are successfully Updated", "Member Attendance");
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowDetailsEmployee();
        }

        private void cmbEmp_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT EMP_NO FROM VW_EMPLOYEES WHERE NAME = '"+ cmbEmp.Text.Trim() +"'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                FINDEMP = dreader["EMP_NO"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}