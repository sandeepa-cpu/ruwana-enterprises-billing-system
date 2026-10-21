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
    public partial class frm_BankBranchDetails : Form
    {
        public frm_BankBranchDetails()
        {
            InitializeComponent();
        }
        private SqlConnection _Conn;

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (rb_Bank.Checked == true)
            {
                try
                {
                    if (txt_Code.Text == "" || txt_Desc.Text == "")
                    {
                        MessageBox.Show("Please Enter Required Data and Proceed", "Bank Information");
                        return;
                    }
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "INSERT INTO BANK_DETAILS (BANK_CODE, BANK) VALUES ('" + txt_Code.Text + "','" + txt_Desc.Text + "')";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("New Bank Entry Successfully Added");
                    txt_Desc.Clear();
                    txt_Code.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Bank Information");
                    return;
                }
                _Conn.Close();
                ShowBankDetails();
            }
            else if (rb_Branch.Checked == true)
            {
                try
                {
                    if (txt_Code.Text == "" || txt_Desc.Text == "")
                    {
                        MessageBox.Show("Please Enter Required Data and Proceed", "Branch Information");
                        return;
                    }
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "INSERT INTO BRANCH_DETAILS (BRANCH_CODE, BRANCH, BANK_CODE) VALUES ('" + txt_Code.Text + "','" + txt_Desc.Text + "','" + txt_SelectBank.Text + "')";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("New Branch Entry Successfully Added");
                    txt_Desc.Clear();
                    txt_Code.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Branch Information");
                    return;
                }
                _Conn.Close();
                ShowBranchDetails();
            }
            txt_Code.Focus();
        }

        private void frm_BankBranchDetails_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            ShowBankDetails();
        }

        private void ShowBankDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT BANK_CODE, BANK FROM BANK_DETAILS ORDER BY BANK_CODE", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "BANK_DETAILS");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "BANK_DETAILS";

            _Conn.Close();

            BankFillGrid();
        }

        private void ShowBranchDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT BANK_CODE, BRANCH_CODE, BRANCH FROM BRANCH_DETAILS ORDER BY BRANCH_CODE", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "BRANCH_DETAILS");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "BRANCH_DETAILS";

            _Conn.Close();

            BranchFillGrid();
        }

        private void BankFillGrid()
        {
            Grid_A.Columns[0].Width = 100;
            Grid_A.Columns[0].HeaderText = "BANK CODE";
            Grid_A.Columns[1].Width = 335;
            Grid_A.Columns[1].HeaderText = "BANK DESCRIPTION";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
        }

        private void BranchFillGrid()
        {
            Grid_A.Columns[0].Width = 70;
            Grid_A.Columns[0].HeaderText = "BANK CODE";
            Grid_A.Columns[1].Width = 70;
            Grid_A.Columns[1].HeaderText = "BRANCH CODE";
            Grid_A.Columns[2].Width = 295;
            Grid_A.Columns[2].HeaderText = "BRANCH DESCRIPTION";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = true;
        }

        private void UpdateBankData()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM BANK_DETAILS ORDER BY BANK_CODE", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "BANK_DETAILS");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["BANK_DETAILS"].Rows)
            {
                thisDataset.Tables["BANK_DETAILS"].Rows[count]["BANK_CODE"] = Grid_A.Rows[count].Cells[0].Value.ToString();
                thisDataset.Tables["BANK_DETAILS"].Rows[count]["BANK"] = Grid_A.Rows[count].Cells[1].Value.ToString();

                thisAdapter.Update(thisDataset, "BANK_DETAILS");
                count++;
            }
            _Conn.Close();
            MessageBox.Show("Bank Descriptions are successfully Updated", "Bank Details");
        }

        private void UpdateBranchData()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM BRANCH_DETAILS ORDER BY BRANCH_CODE", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "BRANCH_DETAILS");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["BRANCH_DETAILS"].Rows)
            {
                thisDataset.Tables["BRANCH_DETAILS"].Rows[count]["BANK_CODE"] = Grid_A.Rows[count].Cells[0].Value.ToString();
                thisDataset.Tables["BRANCH_DETAILS"].Rows[count]["BRANCH_CODE"] = Grid_A.Rows[count].Cells[1].Value.ToString();
                thisDataset.Tables["BRANCH_DETAILS"].Rows[count]["BRANCH"] = Grid_A.Rows[count].Cells[2].Value.ToString();

                thisAdapter.Update(thisDataset, "BRANCH_DETAILS");
                count++;
            }
            _Conn.Close();
            MessageBox.Show("Branch Descriptions are successfully Updated", "Branch Details");
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (rb_Bank.Checked == true)
            {
                UpdateBankData();
            }
            else if (rb_Branch.Checked == true)
            {
                UpdateBranchData();
            }
        }

        private void rb_Bank_CheckedChanged(object sender, EventArgs e)
        {
            txt_Code.Focus();
            lbl_Code.Text = "Bank Code";
            ShowBankDetails();
            cmb_SelectBank.Enabled = false;
        }

        private void rb_Branch_CheckedChanged(object sender, EventArgs e)
        {
            txt_Code.Focus();
            lbl_Code.Text = "Branch Code";
            ShowBranchDetails();
            SelectBank();
            cmb_SelectBank.Enabled = true;
        }

        private void cmb_Bank_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT BANK_CODE, BANK FROM BANK_DETAILS WHERE (BANK = '" + cmb_SelectBank.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txt_SelectBank.Text = dreader["BANK_CODE"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            btn_Add.Focus();
        }

        private void SelectBank()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT BANK FROM BANK_DETAILS";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmb_SelectBank.Items.Add(dreader["BANK"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
        }

        private void txt_Desc_Leave(object sender, EventArgs e)
        {
            if (rb_Bank.Checked == true)
            {
                btn_Add.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Code.Text = "";
            txt_Desc.Text = "";
            cmb_SelectBank.ResetText();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}