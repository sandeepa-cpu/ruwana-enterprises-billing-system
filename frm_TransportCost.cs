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
    public partial class frm_TranportCost : Form
    {
        public frm_TranportCost()
        {
            InitializeComponent();
        }

        string APRVD;
        int SEQNOD = 0;
        int RSEQ;
        decimal CASHWITH = 0;
        private string strCriteria = "";
        private string strReportName = "";
        private SqlConnection _Conn;
        decimal C = 0;
        decimal W = 0;
        decimal D = 0;
        int SEQ;

        private void frm_CashDepositWithdraw_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            PRO_DATE();
            ShowDetails();
            
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

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT PRO_DATE, DEPOSITS, WITHDRAW, REMARKS, SEQNO, DEL FROM TRANSPORT_COST ORDER BY PRO_DATE", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "TRANSPORT_COST");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "TRANSPORT_COST";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 120;
            Grid_A.Columns[0].HeaderText = "PRO_DATE";
            Grid_A.Columns[1].Width = 230;
            Grid_A.Columns[1].HeaderText = "EXPENCE";
            Grid_A.Columns[2].Width = 130;
            Grid_A.Columns[2].HeaderText = "WITHDRAW";
            Grid_A.Columns[3].Width = 70;
            Grid_A.Columns[3].HeaderText = "REMARKS";
            Grid_A.Columns[5].Width = 70;
            Grid_A.Columns[5].HeaderText = "DELETE";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;
            Grid_A.Columns[4].Visible = false;
            Grid_A.Columns[2].Visible = false;

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
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text == "0.00" || txtAmount.Text == "0" || txtAmount.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Transport Expences Info");
                return;
            }

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;
            try
            {
                cmdsql1.CommandText = "INSERT INTO TRANSPORT_COST (DEPOSITS, PRO_DATE, REMARKS) VALUES ('" + txtAmount.Text + "', '" + dt_Start.Value + "', '" + txtRemarks.Text + "')";
                cmdsql1.ExecuteNonQuery();
                MessageBox.Show("Transport Expences Successfully Added. Proceed to the Next step");
            }
            catch (Exception)
            {
                //cmdsql1.CommandText = "UPDATE DEPOSITS_WITHDRAW SET WITHDRAW = WITHDRAW + '" + txtAmount.Text.Trim() + "', REMARKS = '" + txtRemarks.Text + "' WHERE (PRO_DATE = '" + dt_Start.Value + "')";
                //cmdsql1.ExecuteNonQuery();
            }
            
            _Conn.Close();
            ShowDetails();
        }

        private void Find_OPB()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUM(DEPOSITS) AS OPB FROM TRANSPORT_COST WHERE (PRO_DATE < CONVERT(DATETIME, '" + lblYear.Text + "-" + lblMonth.Text + "-01 00:00:00', 102))";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                CASHWITH = 0;
                try
                {
                    CASHWITH = decimal.Parse(dreader["OPB"].ToString());
                    return;
                }
                catch (Exception)
                {

                }
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void OPB()
        {
            Find_OPB();
            
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;

            cmdsql1.CommandText = "UPDATE OPB_CASH_AMOUNT SET OPB_CASH_AMOUNT = '" + CASHWITH + "'";
            cmdsql1.ExecuteNonQuery();

            _Conn.Close(); 
            DIFF();
        }

        private void UP_DIFF()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;

            cmdsql1.CommandText = "UPDATE TRANSPORT_COST SET DIFF = 0";
            cmdsql1.ExecuteNonQuery();

            _Conn.Close();
        }

        private void DIFF()
        {
            D = 0;
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;

            cmdsql.CommandText = "SELECT SEQNO, DEPOSITS FROM TRANSPORT_COST WHERE (PRO_DATE >= CONVERT(DATETIME, '" + lblYear.Text + "-" + lblMonth.Text + "-01 00:00:00', 102)) ORDER BY PRO_DATE, DEPOSITS DESC";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                if (dreader.HasRows == true)
                {
                    SEQ = int.Parse(dreader["SEQNO"].ToString());
                    C = decimal.Parse(dreader["DEPOSITS"].ToString());
                    //W = decimal.Parse(dreader["WITHDRAW"].ToString());
                    //D = D + CASHWITH + C - W;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _Conn;
                    cmdsql1.CommandText = "UPDATE TRANSPORT_COST SET DIFF = '" + C + "'WHERE (SEQNO = '" + SEQ + "')";
                    cmdsql1.ExecuteNonQuery(); 
                    CASHWITH = 0;
                }

            }
            cmdsql.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UP_DIFF();
            OPB();
            //strReportName = "rpt_Print";
            strCriteria = "Reports";

            this.Text = "Report Criteria for " + strCriteria;

            strReportName = "rpt_Transport_Cost";

            frm_Reports frm_Reports = new frm_Reports();
            CommonProfiles objComPro = new CommonProfiles();

            frm_Reports.GetReportCriteriaB(strReportName, strCriteria, int.Parse(lblYear.Text), int.Parse(lblMonth.Text));
            //frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lblDate.Text), DateTime.Parse(lblDate.Text), txtNo.Text);
            frm_Reports.Show();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT PRO_DATE, DEPOSITS, WITHDRAW, REMARKS, SEQNO, DEL FROM TRANSPORT_COST ORDER BY PRO_DATE", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "TRANSPORT_COST");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["TRANSPORT_COST"].Rows)
            {
                string APRVD = Grid_A.Rows[count].Cells[5].Value.ToString();
                //SEQNO = Convert.ToInt32(Grid_A.Rows[count].Cells[8].Value.ToString());
                SEQNOD = Convert.ToInt32(Grid_A.Rows[count].Cells[4].Value.ToString());
                //INVNO = Grid_A.Rows[count].Cells[2].Value.ToString();

                if (APRVD == "True")
                {
                    //try

                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _Conn;
                    cmdsql1.CommandText = "DELETE FROM TRANSPORT_COST WHERE SEQNO = '" + SEQNOD + "'";
                    SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                    dreader1.Close();
                }
                count++;


            }
            _Conn.Close();
            MessageBox.Show("Transport Expences are successfully Removed", "Transport Expences...");
            ShowDetails();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}