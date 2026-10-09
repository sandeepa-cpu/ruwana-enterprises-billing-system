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
    public partial class frm_OT_Rates : Form
    {
        CommonProfiles objComPro = new CommonProfiles();

        public frm_OT_Rates()
        {
            InitializeComponent();
        }

        private SqlConnection _conn;
        private int intYear = 0;
        private int intMonth = 0;
        private string skey;
        private string Emp;
        private string strTenNo;
        private string strOTMe;
        private string strFind;

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_OT_VALUE.Text == "")
            {
                MessageBox.Show("Please Enter Number of Hours and Proceed","Over Time Information");
                return;
            }
            else if (cmb_Find_Emp.Text == "")
            {
                MessageBox.Show("Please Select Employee and Proceed", "Over Time Information");
                return;
            }
            else
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();

                {
                    if (rb_Hired.Checked == true)
                    {
                        cmdsql.Connection = _conn;
                        cmdsql.CommandText = "INSERT INTO OVER_TIME_RATES(TEN_NO, EMP_NO, OT_VALUE, STATUS, OT_YEAR, OT_MONTH, OT_CATEGORY)VALUES ('" + strTenNo + "', '" + Emp + "', '" + txt_OT_VALUE.Text + "', 1,'" + intYear + "','" + intMonth + "', '" + cmbPeriod.Text + "')";
                        cmdsql.ExecuteNonQuery();
                        MessageBox.Show("Tender Over Time Entry Successfully Added", "Over Time Information");
                    }
                    else if (rb_Office.Checked == true)
                    {
                        cmdsql.Connection = _conn;
                        cmdsql.CommandText = "INSERT INTO OVER_TIME_RATES_OFFICE(EMP_NO, OT_VALUE, STATUS, OT_YEAR, OT_MONTH)VALUES ('" + Emp + "', '" + txt_OT_VALUE.Text + "', 1,'" + intYear + "','" + intMonth + "')";
                        cmdsql.ExecuteNonQuery();
                        MessageBox.Show("Office Over Time Entry Successfully Added", "Over Time Information");
                    }
                }
            txt_Emp_No.Clear();
            txt_OT_VALUE.Clear();
            cmb_Find_Emp.ResetText();
            cmbPeriod.Text = "";

            _conn.Close();
            }
        }

        private void rb_Hired_CheckedChanged(object sender, EventArgs e)
        {
            rbtDuration.Checked = false;
            rbtHalfday.Checked = false;
            rbtNormalOT.Checked = false;
            rbtSubLoc.Checked = false;
            pnlOTMethod.Enabled = true;
            txt_OT_VALUE.Text = "";
            lbl_Ten_No.Enabled = true;
            btn_Add.Enabled = false;      
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rb_Office_CheckedChanged(object sender, EventArgs e)
        {
            btn_Add.Enabled = false;
            txt_OT_VALUE.Text = "";
            pnlTender.Enabled = false;
            pnlOTMethod.Enabled = false;
            pnlDuration.Enabled = false;

            cmb_Find_Emp.Items.Clear();
            
            cmb_Find_Emp.ResetText();
            Find_Office_Emps();
        }

        private void Find_Office_Emps()
        {
            cmb_Find_Emp.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT EMP_NO, EMP_NO + ' - ' + INITIALS + ' ' + NAME AS NAME FROM EMPLOYEES WHERE (EMP_CATEGORY <> '2') AND (OFFICE_EMP = 0) ORDER BY (CONVERT(INT,EMP_NO))";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                cmb_Find_Emp.Items.Add(new KeyValuePair(dreader["EMP_NO"],dreader["NAME"].ToString()));
            }

            _conn.Close();
        }

        private void cmb_Ten_No_SelectedValueChanged(object sender, EventArgs e)
        {
            KeyValuePair TenNo = (KeyValuePair)cmb_Ten_No.SelectedItem;
            strTenNo = TenNo.Key.ToString();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strTenders;

            if (strOTMe == "LOC")
            {
                strTenders = "SELECT DISTINCT dbo.TENDER_DETAILS.EMP_NO, SUB_LOC_ID, dbo.TENDER_DETAILS.TEN_NO, dbo.TENDER_DETAILS.EMP_NO + ' - ' + dbo.EMPLOYEES.INITIALS + ' ' + dbo.EMPLOYEES.NAME AS NAME FROM dbo.TENDER_DETAILS INNER JOIN dbo.EMPLOYEES ON dbo.TENDER_DETAILS.EMP_NO = dbo.EMPLOYEES.EMP_NO WHERE (dbo.TENDER_DETAILS.SUB_LOC_ID = '" + skey + "') AND (dbo.TENDER_DETAILS.TEN_NO = '" + strTenNo + "') AND (dbo.TENDER_DETAILS.EMP_STATUS = 1)";
            }
            else
            {
                strTenders = "SELECT DISTINCT dbo.TENDER_DETAILS.EMP_NO, dbo.TENDER_DETAILS.TEN_NO, dbo.TENDER_DETAILS.EMP_NO + ' - ' + dbo.EMPLOYEES.INITIALS + ' ' + dbo.EMPLOYEES.NAME AS NAME FROM dbo.TENDER_DETAILS INNER JOIN dbo.EMPLOYEES ON dbo.TENDER_DETAILS.EMP_NO = dbo.EMPLOYEES.EMP_NO WHERE (dbo.TENDER_DETAILS.TEN_NO = '" + strTenNo + "') AND  (dbo.TENDER_DETAILS.EMP_STATUS = 1)";
            }

            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            
            cmdsql.CommandText = strTenders;
            SqlDataReader dreader = cmdsql.ExecuteReader();

            cmb_Find_Emp.Items.Clear();
            cmb_Find_Emp.Text = "";
            
            while (dreader.Read())
            {
                cmb_Find_Emp.Items.Add(new KeyValuePair(dreader["EMP_NO"], dreader["NAME"].ToString()));
            }

            _conn.Close();
        }       

        private void frm_OT_Rates_Load(object sender, EventArgs e)
        {
            rb_Office.Focus();
            rb_Office.Checked = true;

            intYear = objComPro.GetYear();
            intMonth = objComPro.GetMonth();          
        }

        private void cmb_Find_Emp_SelectedValueChanged(object sender, EventArgs e)
        {
            KeyValuePair EmpNo = (KeyValuePair)cmb_Find_Emp.SelectedItem;
            Emp = EmpNo.Key.ToString();
            Find_Employee_OT();
        }

        private void SubLocation()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdSubLocation = new SqlCommand("SELECT dbo.TENDER_DETAILS.SUB_LOC_ID, dbo.SUB_LOCATION.DESCRIPTION FROM dbo.TENDER_MAIN INNER JOIN dbo.TENDER_DETAILS ON dbo.TENDER_MAIN.TEN_NO = dbo.TENDER_DETAILS.TEN_NO INNER JOIN dbo.SUB_LOCATION ON dbo.TENDER_DETAILS.SUB_LOC_ID = dbo.SUB_LOCATION.SUB_LOC_ID WHERE (dbo.TENDER_MAIN.OT_METHOD = 'LOC') GROUP BY dbo.TENDER_DETAILS.SUB_LOC_ID, dbo.SUB_LOCATION.DESCRIPTION", _conn);
            SqlDataReader drSubLocation = cmdSubLocation.ExecuteReader();
            while (drSubLocation.Read())
            {
                cmbSubLocation.Items.Add(new KeyValuePair(drSubLocation["SUB_LOC_ID"], drSubLocation["DESCRIPTION"].ToString()));
            }

            drSubLocation.Close();
            _conn.Close();
        }

        private void Tenders()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            cmb_Ten_No.Items.Clear();
            cmb_Ten_No.Text = "";
            cmb_Find_Emp.Items.Clear();
            cmb_Find_Emp.Text = "";

            string strHired = ("SELECT TEN_NO, TEN_NO + ' - ' + DESCRIPTION AS DESCRIPTION FROM TENDER_MAIN WHERE OT_METHOD='" + strOTMe + "'");
            SqlCommand cmdTenNo = new SqlCommand(strHired, _conn);
            SqlDataReader drTenNo = cmdTenNo.ExecuteReader();

            while (drTenNo.Read())
            {
                cmb_Ten_No.Items.Add(new KeyValuePair(drTenNo["TEN_NO"], drTenNo["DESCRIPTION"].ToString()));
            }

            drTenNo.Close();
            _conn.Close();
        }

        public class KeyValuePair
        {
            public object Key;
            public string Value;

            public KeyValuePair(object NewValue, string NewDescription)
            {
                Key = NewValue;
                Value = NewDescription;
            }

            public override string ToString()
            {
                return Value;
            }
        }

        private void cmbSubLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            KeyValuePair SubLoc = (KeyValuePair)cmbSubLocation.SelectedItem;
            skey = SubLoc.Key.ToString();

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            cmb_Ten_No.Items.Clear();
            cmb_Ten_No.Text = "";
            cmb_Find_Emp.Items.Clear();
            cmb_Find_Emp.Text = "";

            string strHired = ("SELECT DISTINCT dbo.TENDER_DETAILS.SUB_LOC_ID, dbo.TENDER_DETAILS.TEN_NO, OT_METHOD , dbo.TENDER_MAIN.TEN_NO + ' - ' + dbo.TENDER_MAIN.DESCRIPTION AS DESCRIPTION FROM dbo.TENDER_MAIN INNER JOIN dbo.TENDER_DETAILS ON dbo.TENDER_MAIN.TEN_NO = dbo.TENDER_DETAILS.TEN_NO WHERE (dbo.TENDER_DETAILS.SUB_LOC_ID = '" + skey + "') AND OT_METHOD='" + strOTMe + "'");
            SqlCommand cmdTenNo = new SqlCommand(strHired, _conn);
            SqlDataReader drTenNo = cmdTenNo.ExecuteReader();

            while (drTenNo.Read())
            {
                cmb_Ten_No.Items.Add(new KeyValuePair(drTenNo["TEN_NO"], drTenNo["DESCRIPTION"].ToString()));
            }

            drTenNo.Close();
            _conn.Close();
        }

        private void rbtNormalOT_CheckedChanged(object sender, EventArgs e)
        {
            pnlTender.Enabled = true;
            strOTMe = "NOR";
            Tenders();
        }

        private void rbtSubLoc_CheckedChanged(object sender, EventArgs e)
        {
            pnlTender.Enabled = true;
            strOTMe = "LOC";
            if (rbtSubLoc.Checked == true)
            {
                cmbSubLocation.Enabled = true;
                cmbSubLocation.Items.Clear();
                cmbSubLocation.Text = "";
                SubLocation();
                Tenders();
            }
            else
            {
                cmbSubLocation.Enabled = false;
            }
        }

        private void rbtDuration_CheckedChanged(object sender, EventArgs e)
        {
            pnlTender.Enabled = true;
            if(rbtDuration.Checked==true)
                pnlDuration.Enabled = true;
            else
                pnlDuration.Enabled = false;
            strOTMe = "DUR";
            Tenders();
        }

        private void rbtHalfday_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtHalfday.Checked == true)
            {
                lblHalfDay.Visible = true;
            }
            else
            {
                lblHalfDay.Visible = false;
            }

            pnlTender.Enabled = true;
            strOTMe = "HFD";
            Tenders();               
        }

        private void Find_Employee_OT()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            if (rb_Hired.Checked == true)
            {
                strFind = ("SELECT TEN_NO, EMP_NO, OT_VALUE, OT_YEAR, OT_MONTH, OT_CATEGORY, STATUS FROM OVER_TIME_RATES WHERE (OT_YEAR = '" + intYear + "') AND (OT_MONTH = '" + intMonth + "') AND (EMP_NO = '" + Emp + "') AND (OT_CATEGORY = '" + cmbPeriod.Text + "')");// AND (STATUS = 1)");
            }
            else if (rb_Office.Checked == true)
            {
                strFind = ("SELECT EMP_NO, OT_VALUE, OT_YEAR, OT_MONTH, STATUS FROM OVER_TIME_RATES_OFFICE WHERE (OT_YEAR = '" + intYear + "') AND (OT_MONTH = '" + intMonth + "') AND (EMP_NO = '" + Emp + "')");// AND (STATUS = 1)");
            }

            SqlCommand cmdFind = new SqlCommand(strFind, _conn);
            SqlDataReader drFind = cmdFind.ExecuteReader();

            int intStatus = 0;
            while (drFind.Read())
            {
                txt_OT_VALUE.Text = drFind["OT_VALUE"].ToString();
                intStatus = int.Parse(drFind["STATUS"].ToString());
            }

            if (drFind.HasRows == true && intStatus==1)
            {
                btn_Add.Enabled = false;
                btn_Update.Enabled = true;
            }
            else if (drFind.HasRows == true && intStatus == 0)
            {
                btn_Add.Enabled = false;
                btn_Update.Enabled = false;
            }
            else if (drFind.HasRows == false)
            {
                btn_Add.Enabled = true;
                txt_OT_VALUE.Text = "";
                btn_Update.Enabled = false;
            }

            drFind.Close();
            _conn.Close();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;

                if (rb_Hired.Checked)
                {
                    cmdsql.CommandText = "UPDATE OVER_TIME_RATES SET OT_VALUE = '" + txt_OT_VALUE.Text + "' WHERE (STATUS = 1) AND (TEN_NO = '" + strTenNo + "') AND (EMP_NO = '" + Emp + "') AND (OT_YEAR = '" + intYear + "') AND (OT_MONTH = '" + intMonth + "') AND OT_CATEGORY = '" + cmbPeriod.Text + "'";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("Tender OT Successfully Updated", "Adjustment Details");
                }
                else if (rb_Office.Checked)
                {
                    cmdsql.CommandText = "UPDATE OVER_TIME_RATES_OFFICE SET OT_VALUE = '" + txt_OT_VALUE.Text + "' WHERE (STATUS = 1) AND (EMP_NO = '" + Emp + "') AND (OT_YEAR = '" + intYear + "') AND (OT_MONTH = '" + intMonth + "')";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("Office OT Successfully Updated", "Adjustment Details");
                }
                _conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Adjustment Update Error", "Adjustment Details");
            }
        }

        private void cmbPeriod_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            if (rb_Hired.Checked == true)
            {
                strFind = ("SELECT TEN_NO, EMP_NO, OT_VALUE, OT_YEAR, OT_MONTH, OT_CATEGORY, STATUS FROM OVER_TIME_RATES WHERE (OT_YEAR = '" + intYear + "') AND (OT_MONTH = '" + intMonth + "') AND (EMP_NO = '" + Emp + "') AND (OT_CATEGORY = '" + cmbPeriod.Text + "') AND (STATUS = 1)");
            }

            SqlCommand cmdFind = new SqlCommand(strFind, _conn);
            SqlDataReader drFind = cmdFind.ExecuteReader();

            while (drFind.Read())
            {
                txt_OT_VALUE.Text = drFind["OT_VALUE"].ToString();
            }

            if (drFind.HasRows == true)
            {
                btn_Add.Enabled = false;
                btn_Update.Enabled = true;
            }
            else if (drFind.HasRows == false)
            {
                btn_Add.Enabled = true;
                txt_OT_VALUE.Text = "";
                btn_Update.Enabled = false;
            }

            drFind.Close();
            _conn.Close();
        }

        private void cmb_Find_Emp_Enter(object sender, EventArgs e)
        {
            btn_Add.Enabled = false;
            btn_Update.Enabled = false;
        }
               

        //private void Find_Employee_OT_Leave()
        //{
        //    Connection.DatabaseConnection obyConn;

        //    obyConn = new Connection.DatabaseConnection();
        //    _conn = obyConn.Connect();

        //    if (rb_Hired.Checked == true)
        //    {
        //        strFind = ("SELECT TEN_NO, EMP_NO, OT_VALUE, OT_YEAR, OT_MONTH, OT_CATEGORY, STATUS FROM OVER_TIME_RATES WHERE (OT_YEAR = '" + intYear + "') AND (OT_MONTH = '" + intMonth + "') AND (EMP_NO = '" + cmb_Find_Emp.Text + "') AND (OT_CATEGORY = '" + cmbPeriod.Text + "') AND (STATUS = 1)");
        //    }
        //    else if (rb_Office.Checked == true)
        //    {
        //        strFind = ("SELECT EMP_NO, OT_VALUE, OT_YEAR, OT_MONTH, STATUS FROM OVER_TIME_RATES_OFFICE WHERE (OT_YEAR = '" + intYear + "') AND (OT_MONTH = '" + intMonth + "') AND (EMP_NO = '" + Emp + "') AND (STATUS = 1)");
        //    }

        //    SqlCommand cmdFind = new SqlCommand(strFind, _conn);
        //    SqlDataReader drFind = cmdFind.ExecuteReader();

        //    while (drFind.Read())
        //    {
        //        txt_OT_VALUE.Text = drFind["OT_VALUE"].ToString();
        //    }

        //    if (drFind.HasRows == true)
        //    {
        //        btn_Add.Enabled = false;
        //        btn_Update.Enabled = true;
        //    }
        //    else if (drFind.HasRows == false)
        //    {
        //        btn_Add.Enabled = true;
        //        txt_OT_VALUE.Text = "";
        //        btn_Update.Enabled = false;
        //    }

        //    drFind.Close();
        //    _conn.Close();
        //}

        //private void cmb_Find_Emp_Leave(object sender, EventArgs e)
        //{
        //    Find_Employee_OT_Leave();
        //}

      /* private void txt_OT_VALUE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (strOTMe == "HFD")
            {
                char c = e.KeyChar;
                int i = (int)c;

                // MessageBox.Show(i.ToString());
                if ((i == 51) || (i == 54))
                {
                    //txt_OT_VALUE.Text = "";
                }
                else
                    txt_OT_VALUE.Clear();
            }*/

    }
}

    