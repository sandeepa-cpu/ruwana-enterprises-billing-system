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
    public partial class frm_JobCreation_Quotation : Form
    {
        public frm_JobCreation_Quotation()
        {
            InitializeComponent();
        }
        private SqlConnection _Conn;
        int SEQ = 0;
        string APRVD;
        int SEQNOD, SEQNO;
        decimal REMOVETOT = 0;
        private string strCriteria = "";
        private string strReportName = "";
        //public String VehicleNO;

        private void PRO_DATE()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PRO_DATE FROM PRO_DATE";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                dt_Start.Value = Convert.ToDateTime(dreader["PRO_DATE"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void frm_JobCreation_Load(object sender, EventArgs e)
        {
            CUS();
            PRO_DATE();
            //FindTypes();
            InsuranceCompany();

            DateTime Current = Convert.ToDateTime(dt_Start.Value);
            int Days = int.Parse("3");
            DateTime Next = (Current.AddDays(Days));
            dt_End.Value = Convert.ToDateTime(Next);
            txtNo.Focus();
            timer1.Enabled = true;
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT JOB_TYPE, QTY, TOTAL, DEL, SEQ_NO, SEQNO  FROM JOB_DESCRIPTION_QUOTATION WHERE SEQ_NO = '" + SEQ + "' AND JOB_TYPE <> '-'", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "JOB_DESCRIPTION_QUOTATION");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "JOB_DESCRIPTION_QUOTATION";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 350;
            Grid_A.Columns[0].HeaderText = "JOB_TYPE";
            Grid_A.Columns[1].Width = 200;
            Grid_A.Columns[1].HeaderText = "QTY";
            Grid_A.Columns[2].Width = 200;
            Grid_A.Columns[2].HeaderText = "TOTAL";
            Grid_A.Columns[3].Width = 40;
            Grid_A.Columns[3].HeaderText = "SELECT";

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
            Grid_A.Columns[5].Visible = false;

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
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }


        private void InsuranceCompany()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT NAME FROM INSURANCE_COMPANY", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                cmb_Insu.Items.Add(drReader["NAME"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }
            drReader.Close();
            _Conn.Close();
        }

        //private void Customers()
        //{

        //}


        private void button5_Click(object sender, EventArgs e)
        {
            frm_CustomerProfile frmGen = new frm_CustomerProfile();
            frmGen.Show();
            frmGen.TopMost = true;
            //this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_InsuranceCompany frmGen = new frm_InsuranceCompany();
            frmGen.Show();
            frmGen.TopMost = true;
            //this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNo.Text == "" || lblCusName.Text == "" || lblCusID.Text == "")
            {

                MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                return;
            }

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;
            cmdsql1.CommandText = "INSERT INTO JOB_DETAILS_QUOTATION (VEHICLE_NO, CUSTOMER_ID, JOB_START_DATE, JOB_END_DATE, MAKE, MODEL, ENGINE, CHASSI, MAN_YEAR, REMARK, INSURANCE, MILAGE) VALUES ('" + txtNo.Text + "', '" + lblCusID.Text + "', '" + dt_Start.Value + "', '" + dt_End.Value + "', '" + txtMake.Text + "', '" + txtModel.Text + "', '" + txtEngine.Text + "', '" + txtChass.Text + "', '" + txtYear.Text + "', '" + txtRemark.Text + "', '" + cmb_Insu.Text + "', '" + txtMile.Text + "')";
            cmdsql1.ExecuteNonQuery();

            FindSEQ();
            ADD_MAIN();
            ADD_SUB();
            ShowDetails();
            ShowDetailsC();

            cmdsql1.CommandText = "INSERT INTO JOB_DESCRIPTION_QUOTATION (SEQ_NO, JOB_TYPE, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '-', '0', '0', '" + dt_Start.Value + "')";
            cmdsql1.ExecuteNonQuery();

            cmdsql1.CommandText = "INSERT INTO JOB_ACCIDENT_REPAIR_QUOTATION (SEQ_NO, MAIN_CAT, SUB_CAT, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '0', '0', '0', '0', '" + dt_Start.Value + "')";
            cmdsql1.ExecuteNonQuery();

            MessageBox.Show("Job Quotation Entry Successfully Added. Proceed to the Next step");
            _Conn.Close();
            tabControl1.Visible = true;
            tb1.Visible = true;
            
            
            //ShowDetails();
            //ClearData();
            cmb_Type.Focus();
        }

        private void FindSEQ()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT SEQ_NO FROM JOB_DETAILS_QUOTATION WHERE  (VEHICLE_NO = '" + txtNo.Text + "') AND (JOB_START_DATE = CONVERT(DATETIME, '" + dt_Start.Text + " 00:00:00', 102)) AND (STATUS = 1)", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                SEQ = int.Parse(drReader["SEQ_NO"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }
            drReader.Close();
            _Conn.Close();
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //CUS();
                SHOW();
                ShowDetails();
                ShowDetailsC();
                ADD_MAIN();
                ADD_SUB();
                cmb_Type.Focus();

            }
        }

        private void ADD_MAIN()
        {
            cmbMain.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT MAIN_CAT FROM MAIN_CATEGORY WHERE MAIN_CAT <> '0'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbMain.Items.Add(dreader["MAIN_CAT"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void ADD_MAIN_ID()
        {
            lblMain.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQ_NO FROM MAIN_CATEGORY WHERE MAIN_CAT = '" + cmbMain.Text.Trim() + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblMain.Text = dreader["SEQ_NO"].ToString();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }


        private void ADD_SUB()
        {
            cmbSub.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SUB_CAT FROM SUB_CATEGORY WHERE MAIN_CAT = '" + lblMain.Text.Trim() + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbSub.Items.Add(dreader["SUB_CAT"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void ADD_SUB_ID()
        {
            lblSub.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQ_NO, AMOUNT FROM SUB_CATEGORY WHERE SUB_CAT = '" + cmbSub.Text.Trim() + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblSub.Text = dreader["SEQ_NO"].ToString();
                txtCostR.Text = dreader["AMOUNT"].ToString();
                return;
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }



        private void CUS()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT SEQ_NO, NAME FROM CUSTOMER_INFO", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                lblCusName.Text = drReader["NAME"].ToString(); // + " - " + drTenMain["NAME"].ToString());
                lblCusID.Text = drReader["SEQ_NO"].ToString(); // + " - " + drTenMain["NAME"].ToString());
                dt_End.Focus();
            }
            if (drReader.HasRows == false)
            {
                //MessageBox.Show("Vehicle Number & Customer Not Created", "Creation Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            drReader.Close();
            _Conn.Close();
        }

        private void TOTCOST()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT TOT_COST_AMOUNT FROM JOB_DETAILS_QUOTATION WHERE SEQ_NO = '" + SEQ + "'", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                lblTOTCOST.Text = drReader["TOT_COST_AMOUNT"].ToString(); // + " - " + drTenMain["NAME"].ToString());
            }
            drReader.Close();
            _Conn.Close();
        }


        private void SHOW()
        {
            button2.Enabled = true;

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT  ADVANCE_1, ADVANCE_2, ADVANCE_3, PAID_DATE1, PAID_DATE2, PAID_DATE3, SEQ_NO, VEHICLE_NO, JOB_START_DATE, JOB_END_DATE, MAKE, MODEL, ENGINE, CHASSI, MAN_YEAR, REMARK, INSURANCE, TOT_COST_AMOUNT FROM JOB_DETAILS_QUOTATION WHERE VEHICLE_NO = '" + txtNo.Text + "' AND STATUS = 1", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                button2.Enabled = false;
                tabControl1.Visible = true;

                SEQ = int.Parse(drReader["SEQ_NO"].ToString());
                lblSEQ.Text = drReader["SEQ_NO"].ToString();
                txtNo.Text = drReader["VEHICLE_NO"].ToString();
                dt_Start.Value = Convert.ToDateTime(drReader["JOB_START_DATE"].ToString());
                dt_End.Value = Convert.ToDateTime(drReader["JOB_END_DATE"].ToString());
                txtMake.Text = drReader["MAKE"].ToString();
                txtModel.Text = drReader["MODEL"].ToString();
                txtEngine.Text = drReader["ENGINE"].ToString();
                txtChass.Text = drReader["CHASSI"].ToString();
                txtYear.Text = drReader["MAN_YEAR"].ToString();
                txtRemark.Text = drReader["REMARK"].ToString();
                cmb_Insu.Text = drReader["INSURANCE"].ToString();
                lblTOTCOST.Text = drReader["TOT_COST_AMOUNT"].ToString();
            }
            drReader.Close();
            _Conn.Close();
        }

        private void CLEARDATA()
        {
            lblCusID.Text = "";
            lblCusName.Text = "";

            SEQ = 0;
            txtNo.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
            txtEngine.Text = "";
            txtChass.Text = "";
            txtYear.Text = "";
            txtRemark.Text = "";
            cmb_Insu.Text = "";
            lblTOTCOST.Text = "";
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (cmb_Type.Text == "" || txtNos.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                return;
            }

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;

            decimal Units = decimal.Parse(txtNos.Text);
            decimal UnitAmount = decimal.Parse(txtPrice.Text);
            decimal TOTAL = Units * UnitAmount;
            try
            {
                cmdsql1.CommandText = "INSERT INTO JOB_DESCRIPTION_QUOTATION (SEQ_NO, JOB_TYPE, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '" + cmb_Type.Text + "', '" + txtNos.Text + "', '" + TOTAL + "', '" + dt_Start.Value + "')";
                cmdsql1.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Job already Entered, Select another Job");
                cmb_Type.Focus();
                return;
            }
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "UPDATE JOB_DETAILS_QUOTATION SET TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + TOTAL + "' WHERE (SEQ_NO = '" + SEQ + "')";
            cmdsql.ExecuteNonQuery();

            MessageBox.Show("Job Entry Successfully Added. Proceed to the Next Entry");
            _Conn.Close();

            cmb_Type.Focus();

            ShowDetails();

            TOTCOST();

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT JOB_TYPE, QTY, TOTAL, DEL, SEQ_NO, SEQNO FROM JOB_DESCRIPTION_QUOTATION WHERE SEQ_NO = '" + SEQ + "'", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "DELETE_ENTRY");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["DELETE_ENTRY"].Rows)
            {
                APRVD = Grid_A.Rows[count].Cells[3].Value.ToString();
                REMOVETOT = Convert.ToDecimal(Grid_A.Rows[count].Cells[2].Value.ToString());
                SEQNOD = Convert.ToInt32(Grid_A.Rows[count].Cells[4].Value.ToString());
                SEQNO = Convert.ToInt32(Grid_A.Rows[count].Cells[5].Value.ToString());
                //INVNO = Grid_A.Rows[count].Cells[2].Value.ToString();

                if (APRVD == "True")
                {
                    try
                    {
                        SqlCommand cmdsql1 = new SqlCommand();
                        cmdsql1.Connection = _Conn;
                        cmdsql1.CommandText = "UPDATE JOB_DETAILS_QUOTATION SET TOT_COST_AMOUNT = TOT_COST_AMOUNT - '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
                        SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                        dreader1.Close();
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        SqlCommand cmdsql2 = new SqlCommand();
                        cmdsql2.Connection = _Conn;
                        cmdsql2.CommandText = "DELETE FROM JOB_DESCRIPTION_QUOTATION WHERE (SEQNO = '" + SEQNO + "')";
                        SqlDataReader dreader2 = cmdsql2.ExecuteReader();
                        dreader2.Close();
                    }
                    catch (Exception)
                    {
                        SqlCommand cmdsql1 = new SqlCommand();
                        cmdsql1.Connection = _Conn;
                        cmdsql1.CommandText = "UPDATE JOB_DETAILS_QUOTATION SET TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
                        SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                        dreader1.Close();
                    }
                    //}
                    _Conn.Dispose();
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("Member Loan Can not be Deleted, Error.....", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                }
                count++;
                _Conn = obyConn.Connect();
            }
            _Conn.Close();

            cmb_Type.Focus();

            ShowDetails();

            TOTCOST();

            MessageBox.Show("Records are Successfully Deleted", "Deleting Entries");
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            SHOW();





            //decimal A = (decimal.Parse(lblTOTCOST.Text)/100)*50;
            //decimal B = decimal.Parse(txtPrice.Text);
            //decimal C = A * B;


        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();

            //SqlCommand cmdsql1 = new SqlCommand();
            //cmdsql1.Connection = _Conn;
            //cmdsql1.CommandText = "UPDATE JOB_DETAILS_QUOTATION SET STATUS = 0 WHERE SEQ_NO = '" + SEQ + "'";
            //SqlDataReader dreader1 = cmdsql1.ExecuteReader();
            //dreader1.Close();

            //SqlCommand cmdsql2 = new SqlCommand();
            //cmdsql2.Connection = _Conn;
            //cmdsql2.CommandText = "UPDATE ISSUED_ITEMS SET STATUS = 0 WHERE SEQ_NO = '" + SEQ + "'";
            //SqlDataReader dreader2 = cmdsql2.ExecuteReader();
            //dreader2.Close();

            //SqlCommand cmdsql3 = new SqlCommand();
            //cmdsql3.Connection = _Conn;
            //cmdsql3.CommandText = "UPDATE EMPLOYEE_ALLOCATION SET STATUS = 0 WHERE SEQ_NO = '" + SEQ + "'";
            //SqlDataReader dreader3 = cmdsql3.ExecuteReader();
            //dreader3.Close();

            //CLEARDATA();
            
        }

        private void btn_Delete_Click_1(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT JOB_TYPE, QTY, TOTAL, DEL, SEQ_NO, SEQNO FROM JOB_DESCRIPTION_QUOTATION WHERE SEQ_NO = '" + SEQ + "'", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "DELETE_ENTRY");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["DELETE_ENTRY"].Rows)
            {
                APRVD = Grid_A.Rows[count].Cells[3].Value.ToString();
                REMOVETOT = Convert.ToDecimal(Grid_A.Rows[count].Cells[2].Value.ToString());
                SEQNOD = Convert.ToInt32(Grid_A.Rows[count].Cells[4].Value.ToString());
                SEQNO = Convert.ToInt32(Grid_A.Rows[count].Cells[5].Value.ToString());
                //INVNO = Grid_A.Rows[count].Cells[2].Value.ToString();

                if (APRVD == "True")
                {
                    try
                    {
                        SqlCommand cmdsql1 = new SqlCommand();
                        cmdsql1.Connection = _Conn;
                        cmdsql1.CommandText = "UPDATE JOB_DETAILS_QUOTATION SET TOT_COST_AMOUNT = TOT_COST_AMOUNT - '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
                        SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                        dreader1.Close();
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        SqlCommand cmdsql2 = new SqlCommand();
                        cmdsql2.Connection = _Conn;
                        cmdsql2.CommandText = "DELETE FROM JOB_DESCRIPTION_QUOTATION WHERE (SEQNO = '" + SEQNO + "')";
                        SqlDataReader dreader2 = cmdsql2.ExecuteReader();
                        dreader2.Close();
                    }
                    catch (Exception)
                    {
                        SqlCommand cmdsql1 = new SqlCommand();
                        cmdsql1.Connection = _Conn;
                        cmdsql1.CommandText = "UPDATE JOB_DETAILS_QUOTATION SET TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
                        SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                        dreader1.Close();
                    }
                    //}
                    _Conn.Dispose();
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("Member Loan Can not be Deleted, Error.....", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                }
                count++;
                _Conn = obyConn.Connect();
            }
            _Conn.Close();

            cmb_Type.Focus();

            ShowDetails();

            TOTCOST();

            MessageBox.Show("Job Detail Records are Successfully Deleted", "Deleting Entries");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //strReportName = "rpt_Print";
            strCriteria = "Reports";

            this.Text = "Report Criteria for " + strCriteria;

            strReportName = "rpt_Quotation";

            frm_Reports frm_Reports = new frm_Reports();
            CommonProfiles objComPro = new CommonProfiles();

            frm_Reports.GetReportCriteriaA(strReportName, strCriteria, txtNo.Text, SEQ);
            //frm_Reports.GetReportCriteria(strReportName, strCriteria, DateTime.Parse(lblDate.Text), DateTime.Parse(lblDate.Text), txtNo.Text);
            frm_Reports.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtNo.Focus();
            timer1.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_IssueGoods frm_IGOODS = new frm_IssueGoods();
            frm_IGOODS.VehicleNO = txtNo.Text;
            frm_IGOODS.Show();
        }

        private void dt_End_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmb_Insu.Focus();
            }
        }

        private void cmb_Insu_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtRemark.Focus();
            }
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Year.Focus();
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtEngine.Focus();
            }
        }

        private void txtEngine_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtChass.Focus();
            }
        }

        private void txtChass_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                button2.Focus();
            }
        }

        private void txtMake_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtModel.Focus();
            }
        }

        private void txtModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtYear.Focus();
            }
        }

        private void cmbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtNos.Focus();
            }
        }

        private void txtNos_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtPrice.Focus();
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                button6.Focus();
            }
        }

        private void cmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdReader = new SqlCommand("SELECT AMOUNT FROM JOB_TYPE WHERE JOB_TYPE = '" + cmb_Type.Text + "'", _Conn);
            SqlDataReader drReader = cmdReader.ExecuteReader();
            while (drReader.Read())
            {
                txtPrice.Text = drReader["AMOUNT"].ToString(); // + " - " + drTenMain["NAME"].ToString());
            }
            drReader.Close();
            _Conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frm_JobType frmGenq = new frm_JobType();
            frmGenq.TopMost = true;
            frmGenq.Show();
            //this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (lblMain.Text == "" || lblSub.Text == "" || txtNoR.Text == "" || txtCostR.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Received Goods Info");
                return;
            }

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;

            decimal Units = decimal.Parse(txtNoR.Text);
            decimal UnitAmount = decimal.Parse(txtCostR.Text);
            decimal TOTAL = Units * UnitAmount;

            try
            {
                cmdsql1.CommandText = "INSERT INTO JOB_ACCIDENT_REPAIR_QUOTATION (SEQ_NO, MAIN_CAT, SUB_CAT, QTY, TOTAL, JOB_DATE) VALUES ('" + SEQ + "', '" + lblMain.Text + "', '" + lblSub.Text + "', '" + txtNoR.Text + "', '" + TOTAL + "', '" + dt_Start.Value + "')";
                cmdsql1.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Accident Repair already Entered, Select another Job");
                cmb_Type.Focus();
                return;
            }

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "UPDATE JOB_DETAILS_QUOTATION SET TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + TOTAL + "' WHERE (SEQ_NO = '" + SEQ + "')";
            cmdsql.ExecuteNonQuery();

            MessageBox.Show("Job Quotation Successfully Added. Proceed to the Next Entry");
            _Conn.Close();

            cmbMain.Focus();
            cmbMain.ResetText();
            cmbSub.ResetText();

            ShowDetailsC();

            TOTCOST();

        }

        private void ShowDetailsC()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT MAIN_CAT, SUB_CAT, QTY, TOTAL, DEL FROM VW_ACCIDENT_REPAIR_QUOTATION WHERE SEQ_NO = '" + SEQ + "' AND SUB_CAT <> '-'", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "VW_ACCIDENT_REPAIR");

            Grid_C.DataSource = dsLoan;
            Grid_C.DataMember = "VW_ACCIDENT_REPAIR";

            _Conn.Close();

            FillGridC();
        }

        private void FillGridC()
        {
            Grid_C.Columns[0].Width = 250;
            Grid_C.Columns[0].HeaderText = "MAIN CATEGORY";
            Grid_C.Columns[1].Width = 250;
            Grid_C.Columns[1].HeaderText = "SUB CATEGORY";
            Grid_C.Columns[2].Width = 200;
            Grid_C.Columns[2].HeaderText = "QTY";
            Grid_C.Columns[3].Width = 200;
            Grid_C.Columns[3].HeaderText = "TOTAL";
            Grid_C.Columns[4].Width = 40;
            Grid_C.Columns[4].HeaderText = "SELECT";

            Grid_C.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_C.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_C.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_C.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_C.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_C.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_C.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_C.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_C.Columns[3].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_C.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_C.Columns[0].ReadOnly = true;
            Grid_C.Columns[1].ReadOnly = true;
            Grid_C.Columns[2].ReadOnly = true;
            Grid_C.Columns[3].ReadOnly = true;
            Grid_C.Columns[4].ReadOnly = true;

            //Grid_A.Columns[4].Visible = false;
            //Grid_A.Columns[5].Visible = false;

            Grid_C.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_C.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_C.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_C.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_C.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            Grid_C.AutoGenerateColumns = false;
            Grid_C.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            Grid_C.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Grid_C.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
            Grid_C.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            Grid_C.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_C.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            Grid_C.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_C.MultiSelect = false;
            Grid_C.RowHeadersVisible = true;

            Grid_C.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_C.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_C.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid_C.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_C.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_C.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_C.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT JOB_TYPE, QTY, TOTAL, DEL, SEQ_NO, SEQNO FROM JOB_ACCIDENT_REPAIR_QUOTATION WHERE SEQ_NO = '" + SEQ + "'", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "DELETE_ENTRY");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["DELETE_ENTRY"].Rows)
            {
                APRVD = Grid_A.Rows[count].Cells[3].Value.ToString();
                REMOVETOT = Convert.ToDecimal(Grid_A.Rows[count].Cells[2].Value.ToString());
                SEQNOD = Convert.ToInt32(Grid_A.Rows[count].Cells[4].Value.ToString());
                SEQNO = Convert.ToInt32(Grid_A.Rows[count].Cells[5].Value.ToString());
                //INVNO = Grid_A.Rows[count].Cells[2].Value.ToString();

                if (APRVD == "True")
                {
                    try
                    {
                        SqlCommand cmdsql1 = new SqlCommand();
                        cmdsql1.Connection = _Conn;
                        cmdsql1.CommandText = "UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = TOT_COST_AMOUNT - '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
                        SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                        dreader1.Close();
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        SqlCommand cmdsql2 = new SqlCommand();
                        cmdsql2.Connection = _Conn;
                        cmdsql2.CommandText = "DELETE FROM JOB_ACCIDENT_REPAIR_QUOTATION WHERE (SEQNO = '" + SEQNO + "')";
                        SqlDataReader dreader2 = cmdsql2.ExecuteReader();
                        dreader2.Close();
                    }
                    catch (Exception)
                    {
                        SqlCommand cmdsql1 = new SqlCommand();
                        cmdsql1.Connection = _Conn;
                        cmdsql1.CommandText = "UPDATE JOB_DETAILS SET TOT_COST_AMOUNT = TOT_COST_AMOUNT + '" + REMOVETOT + "' WHERE SEQ_NO = '" + SEQNOD + "'";
                        SqlDataReader dreader1 = cmdsql1.ExecuteReader();
                        dreader1.Close();
                    }
                    //}
                    _Conn.Dispose();
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("Member Loan Can not be Deleted, Error.....", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                }
                count++;
                _Conn = obyConn.Connect();
            }
            _Conn.Close();

            cmb_Type.Focus();

            ShowDetails();

            TOTCOST();

            MessageBox.Show("Job Detail Records are Successfully Deleted", "Deleting Entries");
        }

        private void cmbMain_SelectedValueChanged(object sender, EventArgs e)
        {
            ADD_MAIN_ID();
            ADD_SUB();
        }

        private void cmbMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbSub.Focus();
            }
        }

        private void cmbMain_Enter(object sender, EventArgs e)
        {
            cmbMain.DroppedDown = true;
        }

        private void cmbSub_Enter(object sender, EventArgs e)
        {
            cmbSub.DroppedDown = true;
        }

        private void cmbSub_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtNoR.Focus();
            }
        }

        private void cmbSub_SelectedValueChanged(object sender, EventArgs e)
        {
            ADD_SUB_ID();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (tabPage8.Text == "  ACCIDENT REPAIR  -  ")
            {
                cmbMain.Focus();
                //cmbEmp.DroppedDown = true;
                timer2.Enabled = false;
            }
            if (tabPage2.Text == "   JOB DESCRIPTION  -  ")
            {
                cmb_Type.Focus();
                //cmbType.DroppedDown = true;
                timer2.Enabled = false;

            }
        }

        private void txtNoR_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtCostR.Focus();
            }
        }

        private void txtCostR_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                button20.Focus();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frm_JobMainCat frmJM = new frm_JobMainCat();
            frmJM.TopMost = true;
            frmJM.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frm_JobSubCat frmJS = new frm_JobSubCat();
            frmJS.TopMost = true;
            frmJS.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Engine.Focus();
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Chassi.Focus();
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Make.Focus();
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Model.Focus();
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Mile.Focus();
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                button2.Focus();
            }
        }

        private void cmb_Type_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtPrice.Focus();
            }
        }

     

    }
}