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
    public partial class frm_ChangeProcessPeriod : Form
    {
        CommonProfiles getComProfiles = new CommonProfiles();

        private SqlConnection _conn;

        public frm_ChangeProcessPeriod()
        {
            InitializeComponent();
        }

        private void btn_PeriodChange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Change the Current Processing Period?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _conn;
                    cmdsql.CommandText = "UPDATE PRO_DATE SET PRO_DATE = PRO_DATE + 1";
                    cmdsql.ExecuteNonQuery();

                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _conn;
                    cmdsql1.CommandText = "UPDATE COMPANY_INFO SET SYSTEM3 = SYSTEM3 - 1";
                    cmdsql1.ExecuteNonQuery();

                    _conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Changing Next Date Update Error", "Change Next Date");
                }
            }
            lbl_NextDate.Visible = true;
            lblNextlabel.Visible = true;
            GetProcessPeriodNext();
            AddMembersAttn();
        }

        private void AddMembersAttn()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strLoanAdj = ("SELECT CONVERT(Int, EMP_NO) AS EMP_NO FROM EMPLOYEES WHERE (STATUS = 1)ORDER BY CONVERT(Int, EMP_NO)");

            DataTable tblLoanAdj = new DataTable();
            SqlCommand cmdLoanAdj = new SqlCommand(strLoanAdj, _conn);
            SqlDataAdapter daLoanAdj = new SqlDataAdapter();

            daLoanAdj.SelectCommand = cmdLoanAdj;
            daLoanAdj.Fill(tblLoanAdj);

            string EMP;

            foreach (DataRow drLoanAdj in tblLoanAdj.Rows)
            {
                string str_AdjINS;
                EMP = drLoanAdj["EMP_NO"].ToString();

                //try
                //{
                    str_AdjINS = "INSERT INTO ATTEND_INFO (EMP_NO, ATTEND, PRO_DATE) VALUES ('" + EMP + "', 0, '" + lbl_NextDate.Text + "')";
                    SqlCommand cmd_AdjINS = new SqlCommand(str_AdjINS, _conn);
                    cmd_AdjINS.ExecuteNonQuery();
                    cmd_AdjINS.Dispose();

                //    //return;
                //}
                //catch (Exception)
                //{

                //}
            }

            return;
            _conn.Close();
        }


        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_ChangeProcessPeriod_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            GetProcessPeriodCurrent();
        }

        private void GetProcessPeriodCurrent()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT PRO_DATE FROM PRO_DATE";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_CurrentDate.Text = dreader["PRO_DATE"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _conn.Close();
        }

        private void GetProcessPeriodNext()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT PRO_DATE FROM PRO_DATE";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lbl_NextDate.Text = dreader["PRO_DATE"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

    }
}