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
    public partial class frm_LoanAdjestments : Form
    {
        public frm_LoanAdjestments()
        {
            InitializeComponent();
        }

        private SqlConnection _conn;

        private void frm_LoanAdjestments_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            ShowEmployees();
            LoanType();
            cmb_Find_Emp.Focus();
        }

        private void ShowEmployees()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT * FROM EMPLOYEES ORDER BY (CONVERT(INT,EMP_NO))";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmb_Find_Emp.Items.Add(dreader["EMP_NO"].ToString() + " - " + dreader["INITIALS"].ToString() + " " + dreader["NAME"].ToString());
            }
            cmb_Find_Emp.Focus();
            _conn.Close();
        }

        private void LoanType()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT LOAN_DESC, DED_ID FROM LOAN_MAIN";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmb_LoanType.Items.Add(dreader["DED_ID"].ToString() + " - " + dreader["LOAN_DESC"].ToString());
            }
            cmb_Find_Emp.Focus();
            _conn.Close();
        }

        private void ShowEmployeeNo()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT EMP_NO, INITIALS + ' ' + NAME AS NAME FROM EMPLOYEES WHERE (EMP_NO + ' - ' + INITIALS + ' ' + NAME = '" + cmb_Find_Emp.Text.Trim() + "')AND STATUS = 1";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txt_Emp_No.Text = dreader["EMP_NO"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _conn.Close();
        }

        private void FillData()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT SEQ_NO, EMP_NO, NAME, LOAN_ID, LOAN_AMOUNT, BAL_AMOUNT, NO_INST, BAL_INST, DED_ID, LOAN_DESC FROM VW_LOAN_PROCESS WHERE EMP_NO= '" + txt_Emp_No.Text + "' AND DED_ID + ' - ' + LOAN_DESC = '" + cmb_LoanType.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txt_LoanAmount.Text = dreader["LOAN_AMOUNT"].ToString();
                txt_BalAmount.Text = dreader["BAL_AMOUNT"].ToString();
                txt_Inst.Text = dreader["NO_INST"].ToString();
                txt_BalInst.Text = dreader["BAL_INST"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _conn.Close();
        }

        private void cmb_Find_Emp_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearText();
            ShowEmployeeNo();
            FillData();
            cmb_LoanType.Focus();
        }

        private void btn_Adjustments_Click(object sender, EventArgs e)
        {
            ClearText();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strLoanAdj = ("SELECT SEQ_NO, EMP_NO, NAME, LOAN_ID, LOAN_AMOUNT, BAL_AMOUNT, NO_INST, BAL_INST, DED_ID, LOAN_DESC FROM VW_LOAN_PROCESS WHERE EMP_NO= '" + txt_Emp_No.Text + "' AND DED_ID + ' - ' + LOAN_DESC = '"+ cmb_LoanType.Text +"'");

            DataTable tblLoanAdj = new DataTable();
            SqlCommand cmdLoanAdj = new SqlCommand(strLoanAdj, _conn);
            SqlDataAdapter daLoanAdj = new SqlDataAdapter();

            daLoanAdj.SelectCommand = cmdLoanAdj;
            daLoanAdj.Fill(tblLoanAdj);

            decimal InstallementAmount = 0;
            decimal BalanceAmount = 0;

            foreach (DataRow drLoanAdj in tblLoanAdj.Rows)
            {
                BalanceAmount = decimal.Parse(drLoanAdj["BAL_AMOUNT"].ToString());
                InstallementAmount = (decimal.Parse(drLoanAdj["LOAN_AMOUNT"].ToString()) / int.Parse(drLoanAdj["NO_INST"].ToString()));

                try
                {
                    string str_AdjINS = "UPDATE LOAN_DETAILS SET BAL_AMOUNT = '" + (BalanceAmount - InstallementAmount) + "',BAL_INST = (BAL_INST - 1) WHERE (SEQ_NO = '" + drLoanAdj["SEQ_NO"].ToString() + "')";
                    SqlCommand cmd_AdjINS = new SqlCommand(str_AdjINS, _conn);
                    cmd_AdjINS.ExecuteNonQuery();
                    cmd_AdjINS.Dispose();

                    string strUpINS = "SELECT BAL_INST FROM LOAN_DETAILS WHERE (SEQ_NO = '" + drLoanAdj["SEQ_NO"].ToString() + "')";
                    SqlCommand cmdUpINS = new SqlCommand(strUpINS, _conn);
                    SqlDataReader drUpINS = cmdUpINS.ExecuteReader();
                    drUpINS.Read();
                    cmdUpINS.Dispose();

                    if (int.Parse(drUpINS["BAL_INST"].ToString()) == 0)
                    {
                        drUpINS.Close();
                        string UP_strAdjINS = "UPDATE LOAN_DETAILS SET STATUS = 0 WHERE (SEQ_NO = '" + drLoanAdj["SEQ_NO"].ToString() + "')";
                        SqlCommand Up_cmdAdjINS = new SqlCommand(UP_strAdjINS, _conn);
                        Up_cmdAdjINS.ExecuteNonQuery();
                        Up_cmdAdjINS.Dispose();
                    }
                    MessageBox.Show("Loan Installment Adjestments are successfully Added", "Loan Installment Adjestments");
                    FillData();
                    return;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data Entering Error... Check Your Data & Proceed", "Loan Installment Adjestments");
                    return;
                }
            }

            MessageBox.Show("No Data for Selected Employee to Proceed", "Loan Installment Adjestments");
            return;
            _conn.Close();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearText()
        {
            txt_LoanAmount.Text = "";
            txt_BalAmount.Text = "";
            txt_Inst.Text = "";
            txt_BalInst.Text = "";
        }

        private void cmb_LoanType_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearText();
            btn_Adjustments.Focus();
            FillData();
        }
    }
}