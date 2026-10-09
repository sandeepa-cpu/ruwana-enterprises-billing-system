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
    public partial class frm_PettyCash : Form
    {
        public frm_PettyCash()
        {
            InitializeComponent();
        }

        private string strCriteria = "";
        private string strReportName = "";
        private SqlConnection _Conn;
        decimal OUT = 0;
        decimal IN = 0;
        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (rb_In.Checked == true)
            {
                try
                {
                    if (txt_Amnt.Text == "" || txt_Desc.Text == "")
                    {
                        MessageBox.Show("Please Enter Required Data and Proceed", "Petty Cash Info.");
                        return;
                    }
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;

                    cmdsql.CommandText = "INSERT INTO PETTY_CASH_DETAILS (PRO_DATE, DESCRIPTION, IN_AMOUNT, OUT_AMOUNT) VALUES ('" + lblDate.Value + "','" + txt_Desc.Text + "','" + txt_Amnt.Text + "','0')";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("Petty Cash Entry Successfully Added");
                    txt_Desc.Clear();
                    txt_Amnt.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Petty Cash Information");
                    return;
                }
                _Conn.Close();
                ShowInOutDetails();
            }
            else if (rb_Out.Checked == true)
            {
                try
                {
                    if (txt_Amnt.Text == "" || txt_Desc.Text == "")
                    {
                        MessageBox.Show("Please Enter Required Data and Proceed", "Petty Cash Info.");
                        return;
                    }
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;

                    cmdsql.CommandText = "INSERT INTO PETTY_CASH_DETAILS (PRO_DATE, DESCRIPTION, IN_AMOUNT, OUT_AMOUNT) VALUES ('" + lblDate.Value + "','" + txt_Desc.Text + "', '0', '" + txt_Amnt.Text + "')";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("Petty Cash Entry Successfully Added");
                    txt_Desc.Clear();
                    txt_Amnt.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Petty Cash Information");
                    return;
                }
                _Conn.Close();
                ShowInOutDetails();
            }
            txt_Desc.Focus();
        }

        private void frm_BankBranchDetails_Load(object sender, EventArgs e)
        {
            ShowInOutDetails();
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
                lblDate.Text = dreader["PRO_DATE"].ToString();
                lblYear.Text = dreader["YEAR"].ToString();
                lblMonth.Text = dreader["MONTH"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void ShowInOutDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT PRO_DATE, DESCRIPTION, IN_AMOUNT, OUT_AMOUNT FROM PETTY_CASH_DETAILS ORDER BY SEQ_NO", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "PETTY_CASH_DETAILS");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "PETTY_CASH_DETAILS";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 100;
            Grid_A.Columns[0].HeaderText = "DATE";
            Grid_A.Columns[1].Width = 335;
            Grid_A.Columns[1].HeaderText = "DESCRIPTION";
            Grid_A.Columns[2].Width = 100;
            Grid_A.Columns[2].HeaderText = "IN";
            Grid_A.Columns[3].Width = 335;
            Grid_A.Columns[3].HeaderText = "OUT";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[3].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
        }

        private void UpdateInOutData()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT PRO_DATE, DESCRIPTION, IN_AMOUNT, OUT_AMOUNT FROM PETTY_CASH_DETAILS ORDER BY SEQ_NO", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "PETTY_CASH_DETAILS");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["PETTY_CASH_DETAILS"].Rows)
            {
                thisDataset.Tables["PETTY_CASH_DETAILS"].Rows[count]["DESCRIPTION"] = Grid_A.Rows[count].Cells[1].Value.ToString();
                thisDataset.Tables["PETTY_CASH_DETAILS"].Rows[count]["IN_AMOUNT"] = Grid_A.Rows[count].Cells[2].Value.ToString();
                thisDataset.Tables["PETTY_CASH_DETAILS"].Rows[count]["OUT_AMOUNT"] = Grid_A.Rows[count].Cells[3].Value.ToString();

                thisAdapter.Update(thisDataset, "PETTY_CASH_DETAILS");
                count++;
            }
            _Conn.Close();
            MessageBox.Show("Petty Cash Descriptions are successfully Updated", "Petty Cash Details");
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateInOutData();
        }

        private void rb_Bank_CheckedChanged(object sender, EventArgs e)
        {
            txt_Amnt.Focus();
            lbl_Code.Text = "IN AMOUNT";
            ShowInOutDetails();
        }

        private void rb_Branch_CheckedChanged(object sender, EventArgs e)
        {
            txt_Amnt.Focus();
            lbl_Code.Text = "OUT AMOUNT";
            ShowInOutDetails();
        }

        private void txt_Desc_Leave(object sender, EventArgs e)
        {
            if (rb_In.Checked == true)
            {
                btn_Add.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Amnt.Text = "";
            txt_Desc.Text = "";
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Desc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //strReportName = "rpt_Print";
            strCriteria = "Reports";

            this.Text = "Report Criteria for " + strCriteria;

            strReportName = "rpt_PettyCash";

            frm_Reports frm_Reports = new frm_Reports();
            CommonProfiles objComPro = new CommonProfiles();

            frm_Reports.GetReportCriteriaB(strReportName, strCriteria, int.Parse(lblYear.Text), int.Parse(lblMonth.Text));
            //frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lblDate.Text), DateTime.Parse(lblDate.Text), txtNo.Text);
            frm_Reports.Show();
        }
    }
}