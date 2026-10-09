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
    public partial class frm_Employee_Expences : Form
    {
        public frm_Employee_Expences()
        {
            InitializeComponent();
        }
        private string strCriteria = "";
        private string strReportName = "";
        private SqlConnection _Conn;
        private int EMPNO;

        private void frm_Daily_Expences_Load(object sender, EventArgs e)
        {
            
            Exp();
            PRO_DATE();
            ShowDetails();
            cmb_Exp.Focus();
            cmb_Exp.DroppedDown = true;
            timer1.Enabled = true;
        }

        private void Exp()
        {
            cmb_Exp.Items.Clear();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT FULL_NAME FROM EMPLOYEES";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmb_Exp.Items.Add(dreader["FULL_NAME"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void PRO_DATE()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT YEAR(PRO_DATE) AS YEAR, MONTH(PRO_DATE) AS MONTH, PRO_DATE FROM PRO_DATE";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                dt_Start.Text = dreader["PRO_DATE"].ToString();
                lblYear.Text = dreader["YEAR"].ToString();
                lblMonth.Text = dreader["MONTH"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT PRO_DATE, DESCRIPTION, AMOUNT, REMARKS, DEL, SEQNO FROM EMP_EXPENCES WHERE (MONTH(PRO_DATE) = '" + lblMonth.Text + "') ORDER BY PRO_DATE DESC", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "EMP_EXPENCES");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "EMP_EXPENCES";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 120;
            Grid_A.Columns[0].HeaderText = "PRO_DATE";
            Grid_A.Columns[1].Width = 230;
            Grid_A.Columns[1].HeaderText = "DESCRIPTION";
            Grid_A.Columns[2].Width = 130;
            Grid_A.Columns[2].HeaderText = "AMOUNT";
            Grid_A.Columns[3].Width = 160;
            Grid_A.Columns[3].HeaderText = "REMARKS";
            Grid_A.Columns[4].Width = 70;
            Grid_A.Columns[4].HeaderText = "DELETE";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;
            Grid_A.Columns[3].ReadOnly = true;
            Grid_A.Columns[4].Visible = true;
            Grid_A.Columns[5].Visible = false;

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
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }


        private void ShowDetailsA()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT EXPENCE, AMOUNT FROM EXPENCES ORDER BY EXPENCE", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "EXPENCES");

            Grid_B.DataSource = dsLoan;
            Grid_B.DataMember = "EXPENCES";

            _Conn.Close();

            FillGridA();
        }

        private void FillGridA()
        {
            Grid_B.Columns[0].Width = 230;
            Grid_B.Columns[0].HeaderText = "EXPENCES";
            Grid_B.Columns[1].Width = 100;
            Grid_B.Columns[1].HeaderText = "AMOUNT";

            Grid_B.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_B.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;

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
            Grid_B.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_B.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_B.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmb_Exp.Text == "" || txtAmount.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Expences Info");
                return;
            }

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;
            cmdsql1.CommandText = "INSERT INTO EMP_EXPENCES (EMP_NO, PRO_DATE, DESCRIPTION, AMOUNT, REMARKS) VALUES ('" + EMPNO + "', '" + dt_Start.Value + "', '" + cmb_Exp.Text + "', '" + txtAmount.Text + "', '" + txtRemark.Text + "')";
            cmdsql1.ExecuteNonQuery();

            MessageBox.Show("Job Entry Successfully Added. Proceed to the Next step");
            _Conn.Close();
            ShowDetails();
            cmb_Exp.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
            ShowDetailsA();
            txtnew.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;
            cmdsql1.CommandText = "INSERT INTO EXPENCES (EXPENCE, AMOUNT) VALUES ('" + txtnew.Text + "', '" + txtAmnt.Text + "')";
            cmdsql1.ExecuteNonQuery();

            MessageBox.Show("Expence Entry Successfully Added");
            _Conn.Close();
            Exp();
            panel1.Visible = false;
            cmb_Exp.Focus();
            cmb_Exp.DroppedDown = true;
            ShowDetailsA();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT EXPENCE, AMOUNT FROM EXPENCES ORDER BY EXPENCE", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "EXPENCES");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["EXPENCES"].Rows)
            {
                thisDataset.Tables["EXPENCES"].Rows[count]["EXPENCE"] = Grid_B.Rows[count].Cells[0].Value.ToString();
                thisDataset.Tables["EXPENCES"].Rows[count]["AMOUNT"] = Grid_B.Rows[count].Cells[1].Value.ToString();

                thisAdapter.Update(thisDataset, "EXPENCES");
                count++;
            }
            _Conn.Close();
            MessageBox.Show("Expences are successfully Updated", "Expences Details");
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_Exp_SelectedValueChanged(object sender, EventArgs e)
        {
            EMPNUM();
            AMNT();
        }

        private void EMPNUM()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT EMP_NO FROM EMPLOYEES WHERE FULL_NAME = '" + cmb_Exp.Text.Trim() + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                EMPNO = int.Parse(dreader["EMP_NO"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void AMNT()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT AMOUNT FROM EXPENCES WHERE EXPENCE = '" + cmb_Exp.Text.Trim() + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txtAmount.Text = dreader["AMOUNT"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtRemark.Focus();
            }
        }

        private void cmb_Exp_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtAmount.Focus();
            }
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                button2.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cmb_Exp.Focus();
            cmb_Exp.DroppedDown = true;
            timer1.Enabled = false;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //strReportName = "rpt_Print";
            strCriteria = "Reports";

            this.Text = "Report Criteria for " + strCriteria;

            strReportName = "rpt_Expences";

            frm_Reports frm_Reports = new frm_Reports();
            CommonProfiles objComPro = new CommonProfiles();

            frm_Reports.GetReportCriteriaB(strReportName, strCriteria, int.Parse(lblYear.Text), int.Parse(lblMonth.Text));
            //frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lblDate.Text), DateTime.Parse(lblDate.Text), txtNo.Text);
            frm_Reports.Show();
        }

        private void Grid_A_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT PRO_DATE, DESCRIPTION, AMOUNT, REMARKS, DEL, SEQNO FROM EMP_EXPENCES WHERE (MONTH(PRO_DATE) = '" + lblMonth.Text + "') ORDER BY PRO_DATE DESC", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "EMP_EXPENCES");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["EMP_EXPENCES"].Rows)
            {
                string APRVD = Grid_A.Rows[count].Cells[4].Value.ToString();
                //SEQNO = Convert.ToInt32(Grid_A.Rows[count].Cells[8].Value.ToString());
                int SEQNOD = Convert.ToInt32(Grid_A.Rows[count].Cells[5].Value.ToString());
                //INVNO = Grid_A.Rows[count].Cells[2].Value.ToString();

                if (APRVD == "True")
                {
                    SqlCommand cmdsql2 = new SqlCommand();
                    cmdsql2.Connection = _Conn;
                    cmdsql2.CommandText = "DELETE FROM EMP_EXPENCES WHERE SEQNO = '" + SEQNOD + "'";
                    SqlDataReader dreader2 = cmdsql2.ExecuteReader();
                    dreader2.Close();

                    _Conn.Dispose();
                }
                count++;
                _Conn = obyConn.Connect();
            }
            _Conn.Close();
            ShowDetails();
            MessageBox.Show("Records are Successfully Deleted", "Deleting Entries");
        }

      
    }
}