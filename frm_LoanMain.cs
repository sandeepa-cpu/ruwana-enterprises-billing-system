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
    public partial class frm_LoanMain : Form
    {
        public frm_LoanMain()
        {
            InitializeComponent();
        }
        private SqlConnection _Conn;

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_LoanID.Text=="" || txt_Desc.Text=="" || txt_DED_ID.Text=="")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Loan Information");
                    return;
                }
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "INSERT INTO LOAN_MAIN (LOAN_ID, LOAN_DESC, DED_ID) VALUES ('" + txt_LoanID.Text + "','" + txt_Desc.Text + "','"+ txt_DED_ID.Text +"')";
                cmdsql.ExecuteNonQuery();
                MessageBox.Show("Loan Entry Successfully Added");
                txt_DED_ID.Clear();
                txt_Desc.Clear();
                txt_LoanID.Clear();
                cmb_Find_Deduct.ResetText();
            }
            catch (Exception)
            {
                MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Loan Information");
                return;
            }
            _Conn.Close();

            ShowDetails();
        }

        private void frm_LoanDetails_Load(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdLoanMain = new SqlCommand("SELECT * FROM DEDUCTIONS", _Conn);
            SqlDataReader drLoanMain = cmdLoanMain.ExecuteReader();
            while (drLoanMain.Read())
            {
                cmb_Find_Deduct.Items.Add(drLoanMain["DESCRIPTION"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }

            drLoanMain.Close();
            _Conn.Close();
            ShowDetails();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_Find_Deduct_SelectedValueChanged(object sender, EventArgs e)
        {
            txt_DED_ID.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT * FROM DEDUCTIONS WHERE (DESCRIPTION= '" + cmb_Find_Deduct.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txt_DED_ID.Text = dreader["DED_ID"].ToString();
            }

            cmdsql.Dispose();
            dreader.Dispose();
            btn_Add.Focus();
            _Conn.Close();
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT * FROM LOAN_MAIN", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "LOAN_MAIN");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "LOAN_MAIN";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 87;
            Grid_A.Columns[0].HeaderText = "LOAN NO";
            Grid_A.Columns[1].Width = 180;
            Grid_A.Columns[1].HeaderText = "DESCRIPTION";
            Grid_A.Columns[2].Width = 90;
            Grid_A.Columns[2].HeaderText = "DEDUCTION";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;
        }

        //private void frm_Deductions_Load(object sender, EventArgs e)
        //{
        //    ShowDetails();
        //}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM LOAN_MAIN", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "LOAN_MAIN");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["LOAN_MAIN"].Rows)
            {
                thisDataset.Tables["LOAN_MAIN"].Rows[count]["LOAN_DESC"] = Grid_A.Rows[count].Cells[1].Value.ToString();

                thisAdapter.Update(thisDataset, "LOAN_MAIN");
                count++;
            }
            _Conn.Close();
            MessageBox.Show("Loan Descriptions are successfully Updated", "Loan Details");
        }
    }
}