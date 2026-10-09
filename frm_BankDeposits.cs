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
    public partial class frm_BankDeposits : Form
    {
        private SqlConnection _Conn;
        public frm_BankDeposits()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtChequeNo.Text == "")
                txtChequeNo.Text = "000000";

            try
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "INSERT INTO BANK_DEPOSITS(CHEQUE_NO, DEBIT, DETAILS, LOAN_DATE, CHEQUE_DATE)VALUES (" + txtChequeNo.Text + ", " + txt_Loan_Amount.Text + ", '" + txt_Details.Text + "', CONVERT(DATETIME, '" + dtp_LoanDate.Text + "', 102), CONVERT(DATETIME, '" + dtp_ChequeDate.Text + "', 102))";    
                cmdsql.ExecuteNonQuery();
                MessageBox.Show("Money Deposited Entry Successfully Added", "Deposit Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error.... Record Cannot be Entered. Check and Verify Your Entry", "Deposit Info.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ShowDetails();
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT LOAN_DATE, DETAILS, CHEQUE_DATE, CHEQUE_NO, DEBIT FROM BANK_DEPOSITS ORDER BY SEQ_NO DESC", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "BANK_DEPOSITS");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "BANK_DEPOSITS";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 90;
            Grid_A.Columns[0].HeaderText = "DEPOSITED DATE";
            Grid_A.Columns[1].Width = 250;
            Grid_A.Columns[1].HeaderText = "DETAILS";
            Grid_A.Columns[2].Width = 90;
            Grid_A.Columns[2].HeaderText = "CHEQUE DATE";
            Grid_A.Columns[3].Width = 100;
            Grid_A.Columns[3].HeaderText = "CHEQUE NO.";
            Grid_A.Columns[4].Width = 120;
            Grid_A.Columns[4].HeaderText = "AMOUNT";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[3].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;

            Grid_A.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

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

            Grid_A.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid_A.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid_A.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);

            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            //Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM BANK_DEPOSITS ORDER BY SEQ_NO DESC", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "BANK_DEPOSITS");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["BANK_DEPOSITS"].Rows)
            {
                thisDataset.Tables["BANK_DEPOSITS"].Rows[count]["DETAILS"] = Grid_A.Rows[count].Cells[1].Value.ToString();
                thisDataset.Tables["BANK_DEPOSITS"].Rows[count]["CHEQUE_NO"] = Grid_A.Rows[count].Cells[3].Value.ToString();
                thisDataset.Tables["BANK_DEPOSITS"].Rows[count]["DEBIT"] = Grid_A.Rows[count].Cells[4].Value.ToString();

                thisAdapter.Update(thisDataset, "BANK_DEPOSITS");
                count++;
            }
            _Conn.Close();
            MessageBox.Show("Bank Deposits are successfully Updated", "Deposit Details");
        }

        private void frm_BankDeposits_Load(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}