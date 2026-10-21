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
    public partial class frm_EmployeeUnits : Form
    {
        public frm_EmployeeUnits()
        {
            InitializeComponent();
        }
        private SqlConnection _conn;
        private SqlConnection _conn1;

        CommonProfiles getComProfiles = new CommonProfiles();
        private int intYear = 0;
        private int intMonth = 0;
        private int ID;
        private string strUser;
        private int intUserLevel;
        //FIND DATASET
        private void btn_Find_Click_1(object sender, EventArgs e)
        {
            if (cmb_TenNo.Text == "" || txt_Year.Text == "" || txt_Month.Text == "")
            {
                MessageBox.Show("Please Enter the Tender Number, Year, Month and Proceed");
                txt_TenNo.Focus();
            }

            else
            {
                Connection.DatabaseConnection obyConn;

                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();

                SqlCommand cmdTenMain = new SqlCommand("SELECT TEN_NO, PERIOD_FROM_DATE, PERIOD_TO_DATE FROM TENDER_MAIN WHERE TEN_NO='" + txt_TenNo.Text + "'", _conn);
                SqlDataReader drTenMain = cmdTenMain.ExecuteReader();
                drTenMain.Read();                
                if (drTenMain.HasRows == true)
                {
                    int intFYear = Convert.ToDateTime(drTenMain["PERIOD_FROM_DATE"]).Year;
                    int intFMonth = Convert.ToDateTime(drTenMain["PERIOD_FROM_DATE"]).Month;

                    int intTYear = Convert.ToDateTime(drTenMain["PERIOD_TO_DATE"]).Year;
                    int intTMonth = Convert.ToDateTime(drTenMain["PERIOD_TO_DATE"]).Month;

                    if (Convert.ToInt32(txt_Year.Text.ToString()) < intFYear && Convert.ToInt32(txt_Month.Text.ToString()) < intFMonth)
                    {
                        MessageBox.Show("Entered Year and Month are Less than Tender Starting Date");
                        txt_Year.Text = intYear.ToString();
                        txt_Month.Text = intMonth.ToString();
                        return;
                    }

                    if (intYear > intTYear && intMonth > intTMonth)
                    {
                        if (MessageBox.Show("Entered Year and Month are NOT withing the Tender Period" + "\n" + "Do you really want to Proccess this?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            
                        }
                        else
                        {
                            txt_Year.Text = intYear.ToString();
                            txt_Month.Text = intMonth.ToString();
                            return;
                        }
                    }
                    
                    btn_Save.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No Data Found for the Selected Tender Number","Tender Information");
                    return;
                }
                drTenMain.Close();

                SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT  EMP_NO, INITIALS + ' ' + NAME AS FULLNAME, CATDES, UNITS, IN_YEAR, IN_MONTH FROM VW_INV_UNITS WHERE (TEN_NO = '" + txt_TenNo.Text + "') AND (IN_YEAR = " + txt_Year.Text + ") AND (IN_MONTH = " + txt_Month.Text + ") ORDER BY TEN_NO, EMP_NO", _conn);
                SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
                DataSet thisDataset = new DataSet();
                thisAdapter.Fill(thisDataset, "INVOICES");

                if (thisDataset.Tables["INVOICES"].Rows.Count == 0)
                {
                    try
                    {
                        SqlCommand cmdInvoices = new SqlCommand();
                        cmdInvoices.CommandText = "APSS_INS_BATCH_INVOICES";
                        cmdInvoices.Connection = _conn;
                        cmdInvoices.CommandType = CommandType.StoredProcedure;

                        cmdInvoices.Parameters.Add("@TEN_NO", txt_TenNo.Text.Trim());
                        cmdInvoices.Parameters.Add("@IN_YEAR", txt_Year.Text.Trim());
                        cmdInvoices.Parameters.Add("@IN_MONTH", txt_Month.Text.Trim());
                        cmdInvoices.ExecuteNonQuery();
                        cmdInvoices.Dispose();
                    }

                    catch (Exception)
                    {
                        btn_Save.Enabled = false;
                        MessageBox.Show("Already Processed for the Selected Month and Tender Number","Tender Information");
                    }
                }
                
                thisDataset.Clear();
                thisAdapter.Fill(thisDataset, "INVOICES");

                DataRow thisRow = thisDataset.Tables["INVOICES"].NewRow();

                if (thisDataset.Tables["INVOICES"].Rows.Count > 0)
                    thisDataset.Tables["INVOICES"].Rows.Add(thisRow);

                Grid_A.DataSource = thisDataset;
                Grid_A.DataMember = "INVOICES";

                _conn.Close();

                FillGrid();
            }
        }

        //UPDATE DATASET
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM INVOICES WHERE TEN_NO='" + txt_TenNo.Text + "' AND IN_YEAR='" + txt_Year.Text + "' AND IN_MONTH='" + txt_Month.Text + "' AND STATUS='1'", _conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "INVOICES");

            int count = 0;           

            foreach (DataRow dr in thisDataset.Tables["INVOICES"].Rows)
            {              
                thisDataset.Tables["INVOICES"].Rows[count]["UNITS"] = Grid_A.Rows[count].Cells[3].Value.ToString();
                //thisDataset.Tables["INVOICES"].Rows[count]["IN_YEAR"] = Grid_A.Rows[count].Cells[4].Value.ToString();
                //thisDataset.Tables["INVOICES"].Rows[count]["IN_MONTH"] = Grid_A.Rows[count].Cells[5].Value.ToString();

                thisAdapter.Update(thisDataset, "INVOICES");
                count++;
            }
            _conn.Close();
            MessageBox.Show("Units of Employees are successfully Updated","Employee Units");
        }

        private void frm_EmployeeUnits_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            txt_Year.Text = Convert.ToString(getComProfiles.GetYear());
            txt_Month.Text =Convert.ToString(getComProfiles.GetMonth());
            intYear = getComProfiles.GetYear();
            intMonth = getComProfiles.GetMonth();
            btn_Save.Enabled = false;
            txt_TenNo.Focus();

            UserLevels();
            Tender();
            Sub_Location();
        }

        public string GetUser
        {
            get
            {
                return strUser;
            }
        }

        public string SetUser
        {
            set
            {
                strUser = value;
            }
        }

        public int GetUserLevel
        {
            get
            {
                return intUserLevel;
            }
            set
            {
                intUserLevel = value;
            }
        }

        private void UserLevels()
        {
            if (GetUserLevel == 0)
            {
                btn_ReAllow.Enabled = true;
                lblOffEmpPay.Enabled = true;
            }
            else if (GetUserLevel == 1)
            {
                btn_ReAllow.Enabled = true;
                lblOffEmpPay.Enabled = true;
            }
            else if (GetUserLevel == 2)
            {
                btn_ReAllow.Enabled = false;
                lblOffEmpPay.Enabled = false;
            }
        }

        private void Sub_Location()
        {
            cmb_TenNo.Focus();

            Connection.DatabaseConnection obyConn;
            
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdSubLocation = new SqlCommand("SELECT dbo.TENDER_DETAILS.SUB_LOC_ID, dbo.SUB_LOCATION.DESCRIPTION FROM dbo.TENDER_MAIN INNER JOIN dbo.TENDER_DETAILS ON dbo.TENDER_MAIN.TEN_NO = dbo.TENDER_DETAILS.TEN_NO INNER JOIN dbo.SUB_LOCATION ON dbo.TENDER_DETAILS.SUB_LOC_ID = dbo.SUB_LOCATION.SUB_LOC_ID WHERE (dbo.TENDER_MAIN.OT_METHOD = 'LOC') GROUP BY dbo.TENDER_DETAILS.SUB_LOC_ID, dbo.SUB_LOCATION.DESCRIPTION", _conn);
            SqlDataReader drSubLocation = cmdSubLocation.ExecuteReader();

            cmb_SubLocation.Items.Add("- ALL -");

            while (drSubLocation.Read())
            {
                //cmb_SubLocation.Items.Add(drSubLocation["SUB_LOC_ID"].ToString()) + " - " + drSubLocation["DESCRIPTION"].ToString();
                cmb_SubLocation.Items.Add(drSubLocation["SUB_LOC_ID"].ToString() + " - " + drSubLocation["DESCRIPTION"].ToString());
            }

            drSubLocation.Close();
            _conn.Close();
        }

        private void Tender()
        {
            cmb_TenNo.Focus();

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            //Display All Tenders excpt LOCATION Tenders
            // SqlCommand cmdTenMain = new SqlCommand("SELECT TEN_NO,DESCRIPTION, PERIOD_FROM_DATE, PERIOD_TO_DATE FROM TENDER_MAIN WHERE (STATUS = 1) AND OT_METHOD<>'LOC'", _conn);

            SqlCommand cmdTenMain = new SqlCommand("SELECT TEN_NO,DESCRIPTION, PERIOD_FROM_DATE, PERIOD_TO_DATE FROM TENDER_MAIN WHERE (STATUS = 1)", _conn);
            SqlDataReader drTenMain = cmdTenMain.ExecuteReader();
            while (drTenMain.Read())
            {
                cmb_TenNo.Items.Add(drTenMain["TEN_NO"].ToString() + " - " + drTenMain["DESCRIPTION"].ToString());
            }

            drTenMain.Close();
            _conn.Close();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        //KEY PRESS
        private void txt_Month_KeyPress(object sender, KeyPressEventArgs e)
        {
            char Ent = e.KeyChar;
            int Key = (int)Ent;
            if (Key == 13)
            {
                if (txt_TenNo.Text == "" || txt_Year.Text == "" || txt_Month.Text == "")
                {
                    MessageBox.Show("Please Enter the Tender Number, Year, Month and Proceed");
                    txt_TenNo.Focus();
                }

                else
                {
                    Connection.DatabaseConnection obyConn;

                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();

                    SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT  EMP_NO, INITIALS, NAME, CATDES, UNITS, IN_YEAR, IN_MONTH FROM VW_INV_UNITS WHERE (TEN_NO = '" + txt_TenNo.Text + "') AND (IN_YEAR = " + txt_Year.Text + ") AND (IN_MONTH = " + txt_Month.Text + ")ORDER BY TEN_NO, EMP_NO", _conn);
                    //SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT EMP_NO, INITIALS, NAME, TENDES, CATDES, UNITS, IN_YEAR, IN_MONTH, LOCATION, PERIOD_FROM_DATE, PERIOD_TO_DATE FROM VW_INV_UNITS WHERE (TEN_NO = '" + txt_TenNo.Text + "') AND (IN_YEAR = " + txt_Year.Text + ") AND (IN_MONTH = " + txt_Month.Text + ")ORDER BY TEN_NO, EMP_NO", _conn);
                    SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
                    DataSet thisDataset = new DataSet();
                    thisDataset.Clear();
                    thisAdapter.Fill(thisDataset, "INVOICES");

                    if (thisDataset.Tables["INVOICES"].Rows.Count == 0)
                    {
                        // strSQL = "INSERT INTO INVOICES (TEN_NO,EMP_NO,PAY_CAT_ID,IN_YEAR,IN_MONTH) VALUES ('" + strEmp + "','" + dr["PAY_CAT_ID"] + "','" + dr["EAR_ID"].ToString() + "','" + dr["EARNINGS"].ToString() + "','" + intYear + "','" + intMonth + "')";
                        // SqlCommand objCmd = new SqlCommand(strSQL, _conn);
                        // objCmd.ExecuteNonQuery();
                    }

                    DataRow thisRow = thisDataset.Tables["INVOICES"].NewRow();

                    if (thisDataset.Tables["INVOICES"].Rows.Count > 0)
                        thisDataset.Tables["INVOICES"].Rows.Add(thisRow);

                    Grid_A.DataSource = thisDataset;
                    Grid_A.DataMember = "INVOICES";

                    _conn.Close();

                    FillGrid();
                }
            }
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 80;
            Grid_A.Columns[0].HeaderText = "EMP. NO.";
            Grid_A.Columns[1].Width = 200;
            Grid_A.Columns[1].HeaderText = "NAME";
            Grid_A.Columns[2].Width = 125;
            Grid_A.Columns[2].HeaderText = "PAY CATEGORY";
            Grid_A.Columns[3].Width = 100;
            Grid_A.Columns[3].HeaderText = "NO.OF UNITS";
            Grid_A.Columns[4].Width = 70;
            Grid_A.Columns[4].HeaderText = "YEAR";
            Grid_A.Columns[5].Width = 70;
            Grid_A.Columns[5].HeaderText = "MONTH";

            Grid_A.Columns[3].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[5].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[5].DefaultCellStyle.BackColor = Color.AliceBlue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;
            Grid_A.Columns[4].ReadOnly = true;
            Grid_A.Columns[5].ReadOnly = true;
        }

        //SORT TENDER NAME
        private void cmb_TenNo_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdTenMain = new SqlCommand("SELECT TEN_NO, TENDER FROM VW_SUB_LOCATION_TENDER_DETAILS WHERE (TENDER = '" + cmb_TenNo.Text + "')", _conn);
            SqlDataReader drTenMain = cmdTenMain.ExecuteReader();
            while (drTenMain.Read())
            {
                txt_TenNo.Text = drTenMain["TEN_NO"].ToString();
                //if (txt_TenNo.Text == "OFFICE")
                //{
                //    btn_Find.Text = "Manage Office Employees";
                //}
            }

            drTenMain.Close();
            _conn.Close();
        }

        private void cmb_SubLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            cmb_TenNo.Items.Clear();
            cmb_TenNo.Text = "";

            if (cmb_SubLocation.Text == "- ALL -")
            {
                Tender();
            }
            else
            {

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();

                SqlCommand cmdTenMain = new SqlCommand("SELECT * FROM VW_SUB_LOCATION_TENDER_DETAILS WHERE (SUB_LOCATION = '" + cmb_SubLocation.Text + "')", _conn);
                SqlDataReader drTenMain = cmdTenMain.ExecuteReader();

                while (drTenMain.Read())
                {
                    txtSubLoc.Text = drTenMain["SUB_LOC_ID"].ToString();
                    cmb_TenNo.Items.Add(drTenMain["TENDER"].ToString());
                }

                drTenMain.Close();
                _conn.Close();
            }
        }

        private void lblEarDed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_Adjustments frmAdj = new frm_Adjustments();
            frmAdj.Show();
        }

        private void lblOT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_OT_Rates frmOT = new frm_OT_Rates();
            frmOT.Show();
        }

        private void lblOffEmpPay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_HoldPayOfficeEmployee frmHOLDOFF = new frm_HoldPayOfficeEmployee();
            frmHOLDOFF.Show();
        }

        private void btn_ReAllow_Click(object sender, EventArgs e)
        {
            if (cmb_TenNo.Text == "" || txt_Year.Text == "" || txt_Month.Text == "")
            {
                MessageBox.Show("Please Enter the Tender Number, Year, Month and Proceed");
                txt_TenNo.Focus();
                return;
            }

            else
            {
                if (MessageBox.Show("Do you want to Allocate the Employees to this Tender again?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Connection.DatabaseConnection obyConn1;
                    obyConn1 = new Connection.DatabaseConnection();
                    _conn1 = obyConn1.Connect();
                    SqlCommand cmdsql1 = new SqlCommand();
                    cmdsql1.Connection = _conn1;
                    cmdsql1.CommandText = "DELETE FROM INVOICES WHERE (TEN_NO = '" + txt_TenNo.Text + "') AND (IN_YEAR = '" + txt_Year.Text + "') AND (IN_MONTH = '" + txt_Month.Text + "')";
                    cmdsql1.ExecuteNonQuery();

                    Connection.DatabaseConnection obyConn;

                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();

                    SqlCommand cmdTenMain = new SqlCommand("SELECT TEN_NO, PERIOD_FROM_DATE, PERIOD_TO_DATE FROM TENDER_MAIN WHERE TEN_NO='" + txt_TenNo.Text + "'", _conn);
                    SqlDataReader drTenMain = cmdTenMain.ExecuteReader();
                    drTenMain.Read();
                    if (drTenMain.HasRows == true)
                    {
                        int intFYear = Convert.ToDateTime(drTenMain["PERIOD_FROM_DATE"]).Year;
                        int intFMonth = Convert.ToDateTime(drTenMain["PERIOD_FROM_DATE"]).Month;

                        int intTYear = Convert.ToDateTime(drTenMain["PERIOD_TO_DATE"]).Year;
                        int intTMonth = Convert.ToDateTime(drTenMain["PERIOD_TO_DATE"]).Month;

                        if (Convert.ToInt32(txt_Year.Text.ToString()) < intFYear && Convert.ToInt32(txt_Month.Text.ToString()) < intFMonth)
                        {
                            MessageBox.Show("Entered Year and Month are Less than Tender Starting Date");
                            txt_Year.Text = intYear.ToString();
                            txt_Month.Text = intMonth.ToString();
                            return;
                        }

                        if (intYear > intTYear && intMonth > intTMonth)
                        {
                            if (MessageBox.Show("Entered Year and Month are NOT withing the Tender Period" + "\n" + "Do you really want to Proccess this?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {

                            }
                            else
                            {
                                txt_Year.Text = intYear.ToString();
                                txt_Month.Text = intMonth.ToString();
                                return;
                            }
                        }

                        btn_Save.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No Data Found for the Selected Tender Number", "Tender Information");
                        return;
                    }
                    drTenMain.Close();

                    SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT  EMP_NO, INITIALS + ' ' + NAME AS FULLNAME, CATDES, UNITS, IN_YEAR, IN_MONTH FROM VW_INV_UNITS WHERE (TEN_NO = '" + txt_TenNo.Text + "') AND (IN_YEAR = " + txt_Year.Text + ") AND (IN_MONTH = " + txt_Month.Text + ") ORDER BY TEN_NO, EMP_NO", _conn);
                    SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
                    DataSet thisDataset = new DataSet();
                    thisAdapter.Fill(thisDataset, "INVOICES");

                    if (thisDataset.Tables["INVOICES"].Rows.Count == 0)
                    {
                        try
                        {
                            SqlCommand cmdInvoices = new SqlCommand();
                            cmdInvoices.CommandText = "APSS_INS_BATCH_INVOICES";
                            cmdInvoices.Connection = _conn;
                            cmdInvoices.CommandType = CommandType.StoredProcedure;

                            cmdInvoices.Parameters.Add("@TEN_NO", txt_TenNo.Text.Trim());
                            cmdInvoices.Parameters.Add("@IN_YEAR", txt_Year.Text.Trim());
                            cmdInvoices.Parameters.Add("@IN_MONTH", txt_Month.Text.Trim());
                            cmdInvoices.ExecuteNonQuery();
                            cmdInvoices.Dispose();
                        }

                        catch (Exception)
                        {
                            btn_Save.Enabled = false;
                            MessageBox.Show("Already Processed for the Selected Month and Tender Number", "Tender Information");
                        }
                    }

                    thisDataset.Clear();
                    thisAdapter.Fill(thisDataset, "INVOICES");

                    DataRow thisRow = thisDataset.Tables["INVOICES"].NewRow();

                    if (thisDataset.Tables["INVOICES"].Rows.Count > 0)
                        thisDataset.Tables["INVOICES"].Rows.Add(thisRow);

                    Grid_A.DataSource = thisDataset;
                    Grid_A.DataMember = "INVOICES";

                    _conn.Close();

                    FillGrid();


                    MessageBox.Show("Employee Attendance are Verfied", "Attendace Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
     }
 }
