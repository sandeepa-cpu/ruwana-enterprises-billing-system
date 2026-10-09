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
    public partial class Frm_CreditInvoice : Form
    {
        public Frm_CreditInvoice()
        {
            InitializeComponent();
        }

        private SqlConnection _Conn;
        string APRVD, INVNOS;
        int SEQNOD = 0;
        int RSEQ;
        decimal CRD = 0;
        int LASTINVNO;

        private void Frm_CreditInvoice_Load(object sender, EventArgs e)
        {
            ShowSupDetails();
            ShowCusDetails();
            PRO_DATE();
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
                lbl_Date.Text = dreader["PRO_DATE"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }


        private void ShowSupDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT INV_NO, CREDIT, PAID, SEQ_NO FROM RECEIVED_TOTALS WHERE (INV_NO <> '0') AND(INV_NO <> '-') AND PAID = 0 AND (CREDIT > 0)ORDER BY INV_NO", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "RECEIVED_TOTALS");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "RECEIVED_TOTALS";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
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

            Grid_A.Columns[0].Width = 120;
            Grid_A.Columns[0].HeaderText = "INVOICE NO";
            Grid_A.Columns[1].Width = 150;
            Grid_A.Columns[1].HeaderText = "CREDIT";
            Grid_A.Columns[2].Width = 80;
            Grid_A.Columns[2].HeaderText = "PAID";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            Grid_A.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[3].ReadOnly = true;
            Grid_A.Columns[3].Visible= false;
        }

        private void ShowCusDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT INV_NO, CREDIT, PAID, SEQ_NO  FROM ISSUED_TOTALS WHERE (INV_NO <> '0') AND(INV_NO <> '-') AND PAID = 0 AND (CREDIT > 0)ORDER BY INV_NO", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "ISSUED_TOTALS");

            Grid_B.DataSource = dsLoan;
            Grid_B.DataMember = "ISSUED_TOTALS";

            _Conn.Close();

            FillGridB();
        }

        private void FillGridB()
        {
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

            Grid_B.Columns[0].Width = 120;
            Grid_B.Columns[0].HeaderText = "INVOICE NO";
            Grid_B.Columns[1].Width = 150;
            Grid_B.Columns[1].HeaderText = "CREDIT";
            Grid_B.Columns[2].Width = 80;
            Grid_B.Columns[2].HeaderText = "PAID";

            Grid_B.Columns[0].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            Grid_B.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_B.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_B.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_B.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_B.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_B.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            Grid_B.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_B.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Grid_B.Columns[0].ReadOnly = true;
            Grid_B.Columns[3].ReadOnly = true;
            Grid_B.Columns[3].Visible = false;
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT INV_NO, CREDIT, PAID, SEQ_NO FROM RECEIVED_TOTALS WHERE (INV_NO <> '0') AND(INV_NO <> '-') AND (CASH IS NOT NULL) AND (PAID = 0) ORDER BY INV_NO", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "RECEIVED_TOTALS");

            int CCount = 0;

            foreach (DataRow dr in thisDataset.Tables["RECEIVED_TOTALS"].Rows)
            {
                APRVD = Grid_A.Rows[CCount].Cells[2].Value.ToString();
                //SEQNO = Convert.ToInt32(Grid_A.Rows[count].Cells[8].Value.ToString());
                SEQNOD = Convert.ToInt32(Grid_A.Rows[CCount].Cells[3].Value.ToString());
                //INVNO = Grid_A.Rows[count].Cells[2].Value.ToString();

                if (APRVD == "True")
                {
                    //try

                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _Conn;
                    cmdsql1.CommandText = "UPDATE RECEIVED_TOTALS SET PAID = 1, CREDIT = 0 WHERE SEQ_NO = '" + SEQNOD + "'";
                    SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                    dreader1.Close();
                }

                CCount++;
            }
            _Conn.Close();
            MessageBox.Show("Supplier Paid details are successfully updated", "Paid Info...");
            ShowSupDetails();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int CCount = 0;

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT INV_NO, CREDIT, PAID, SEQ_NO FROM ISSUED_TOTALS WHERE (INV_NO <> '0') AND(INV_NO <> '-') AND (CASH IS NOT NULL) AND (PAID = 0)AND (CREDIT > 0)ORDER BY INV_NO", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "ISSUED_TOTALS");


            foreach (DataRow dr in thisDataset.Tables["ISSUED_TOTALS"].Rows)
            {
                APRVD = Grid_B.Rows[CCount].Cells[2].Value.ToString();
                INVNOS = Grid_B.Rows[CCount].Cells[0].Value.ToString().Trim();
                SEQNOD = Convert.ToInt32(Grid_B.Rows[CCount].Cells[3].Value.ToString());
                CRD = Convert.ToDecimal(Grid_B.Rows[CCount].Cells[1].Value.ToString());
                //INVNO = Grid_A.Rows[count].Cells[2].Value.ToString();

                if (APRVD == "True")
                {
                    //try
                    FIND_LASTINVNO();
                    
                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _Conn;
                    cmdsql1.CommandText = "UPDATE ISSUED_TOTALS SET PAID = 1, CREDIT = 0 WHERE SEQ_NO = '" + SEQNOD + "'";
                    SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                    dreader1.Close();

                    SqlCommand cmdsql2 = new SqlCommand();
                    cmdsql2.Connection = _Conn;
                    cmdsql2.CommandText = "INSERT INTO ISSUED_TOTALS (INV_NO, CASH) VALUES('" + LASTINVNO + "', '" + CRD + "')";
                    SqlDataReader dreader2 = cmdsql2.ExecuteReader();
                    dreader2.Close();

                    //FIND_RSEQ();
                    

                    SqlCommand cmdsql3 = new SqlCommand();
                    cmdsql3.Connection = _Conn;
                    cmdsql3.CommandText = "INSERT INTO ISSUED_ITEMS (SYS_USER, PARTNO, CUSTOMER, INV_NO, ORGQTY, QTY, PRICE, S_NO, REMARKS, PRO_DATE, TOT, STATUS, RECEIVE_SEQNO) VALUES ('ADMIN', 'CREDITORS','1', '" + LASTINVNO + "','1', '1', '" + CRD + "', '99999','-',Convert(DateTime,'" + lbl_Date.Text + "'),'" + CRD + "', '1', '13183')";
                    SqlDataReader dreader3 = cmdsql3.ExecuteReader();
                    dreader3.Close();
                }

                CCount++;
            }

            _Conn.Close();
            
            MessageBox.Show("Customer Paid details are successfully updated", "Paid Info...");
            ShowCusDetails();
        }

        private void FIND_RSEQ()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT RECEIVE_SEQNO FROM ISSUED_ITEMS WHERE INV_NO = '"+ INVNOS +"'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblRSEQ.Text = dreader["RECEIVE_SEQNO"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
        }

        private void FIND_LASTINVNO()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT CONVERT(int, INV_NO) AS LASTINV FROM ISSUED_ITEMS ORDER BY CONVERT(int, INV_NO) DESC";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                LASTINVNO = int.Parse(dreader["LASTINV"].ToString());
                LASTINVNO = LASTINVNO + 1; 
                cmdsql.Dispose();
                dreader.Dispose();
                return;
            }
           
        }
    }
}