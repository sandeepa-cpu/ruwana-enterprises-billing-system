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
    public partial class frmManageEPFCalc : Form
    {
        CommonProfiles getComProfiles = new CommonProfiles();

        public frmManageEPFCalc()
        {
            InitializeComponent();
        }

        private SqlConnection _Conn;
        private int intYear = 0;
        private int intMonth = 0;

        private void frmManageEPFCalc_Load(object sender, EventArgs e)
        {
            intYear = getComProfiles.GetYear();
            intMonth = getComProfiles.GetMonth();
            Tenders();            
        }

        private void Tenders()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            cmbTenNo.Items.Clear();
            cmbTenNo.Text = "";
            //cmb_Find_Emp.Items.Clear();
            //cmb_Find_Emp.Text = "";

            string strHired = ("SELECT TEN_NO, TEN_NO + ' - ' + DESCRIPTION AS DESCRIPTION FROM TENDER_MAIN WHERE STATUS='1'");
            ///  SqlCommand cmdTenNo = new SqlCommand(strHired, _Conn);
            //  SqlDataReader drTenNo = cmdTenNo.ExecuteReader();

            DataTable tblTen = new DataTable();
            SqlCommand cmdTen = new SqlCommand(strHired, _Conn);
            SqlDataAdapter daTen = new SqlDataAdapter();

            daTen.SelectCommand = cmdTen;
            daTen.Fill(tblTen);

            cmbTenNo.DataSource = tblTen;
            cmbTenNo.DisplayMember = "DESCRIPTION";
            cmbTenNo.ValueMember = "TEN_NO";
            /*
            while (drTenNo.Read())
            {
                cmb_Ten_No.Items.Add(new KeyValuePair(drTenNo["TEN_NO"], drTenNo["DESCRIPTION"].ToString()));
            }*/

            //   drTenNo.Close();
            _Conn.Close();
        }

        private void Find_Employees()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            string strSQL = "";
            
            if (cmbTenNo.SelectedValue.ToString() == "OFFICE")
            {
                strSQL = "SELECT DISTINCT TOP 100 PERCENT CAST(EMP_NO AS INT) AS EMP_NO, EMP_NO + ' - ' + INITIALS + ' ' + NAME AS NAME" +
                                     " FROM dbo.EMPLOYEES WHERE (STATUS = 1) AND (EMP_CATEGORY = 0) OR (EMP_CATEGORY = 1) ORDER BY CAST(EMP_NO AS INT)";
            }
            else
            {
                strSQL = "SELECT DISTINCT CAST(dbo.TENDER_DETAILS.EMP_NO AS INT) AS EMP_NO,  dbo.TENDER_DETAILS.EMP_NO + ' - ' + dbo.EMPLOYEES.INITIALS + ' ' + dbo.EMPLOYEES.NAME AS NAME" +
                                 " FROM dbo.TENDER_DETAILS INNER JOIN dbo.EMPLOYEES ON dbo.TENDER_DETAILS.EMP_NO = dbo.EMPLOYEES.EMP_NO WHERE (dbo.TENDER_DETAILS.EMP_STATUS = 1) AND (dbo.TENDER_DETAILS.TEN_NO = '" + cmbTenNo.SelectedValue + "')" +
                                 " ORDER BY CAST(dbo.TENDER_DETAILS.EMP_NO AS INT)";
            }
             

            DataTable tblEmp = new DataTable();
            SqlCommand cmdEmp = new SqlCommand(strSQL, _Conn);
            SqlDataAdapter daEmp = new SqlDataAdapter();

            daEmp.SelectCommand = cmdEmp;
            daEmp.Fill(tblEmp);

            lsbEmpNo.DataSource = tblEmp;
            lsbEmpNo.DisplayMember = "NAME";
            lsbEmpNo.ValueMember = "EMP_NO";
                       
            _Conn.Close();
            
        }      

        private void cmbTenNo_SelectedValueChanged(object sender, EventArgs e)
        {
            Find_Employees();
            lsbEmpNo.ClearSelected();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsbEmpNo.Items.Count; i++)
            {
                lsbEmpNo.SetSelected(i, true);
            }
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            lsbEmpNo.ClearSelected();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM PAY_SLIPS_EARNINGS WHERE EAR_ID='TOT_EPF' AND PAY_YEAR='" + intYear + "' AND PAY_MONTH='" + intMonth + "'", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "PAY_SLIPS_EARNINGS");

            DataColumn[] MyKey = new DataColumn[1];

            MyKey[0] = thisDataset.Tables["PAY_SLIPS_EARNINGS"].Columns["EMP_NO"];
            thisDataset.Tables[0].PrimaryKey = MyKey;

            int iCount = 0;

            foreach (DataRowView objData in lsbEmpNo.SelectedItems)
            {
                DataRow FindMyRow = thisDataset.Tables[0].Rows.Find(objData["EMP_NO"].ToString());

                if (FindMyRow != null)
                {
                    FindMyRow["EPF_CALC"] = "P";
                    thisAdapter.Update(thisDataset, "PAY_SLIPS_EARNINGS");

                    iCount++;
                }
                    //strEmpList += objData["EMP_NO"].ToString();                                
            }

            if (iCount > 0)
                MessageBox.Show(iCount.ToString() + " Number of Selected Employees Stop Print in EPF Report",this.Text);
            else
                MessageBox.Show("No Records found to update",this.Text);

            thisAdapter.Dispose();
            thisBuilder.Dispose();
            thisDataset.Dispose();

            _Conn.Close();
        }

        private void btnAddBacktoReport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure of Updating the EPF Report Settings?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();

                string strEPFCalc = "UPDATE PAY_SLIPS_EARNINGS SET EPF_CALC = 'C' WHERE EPF_CALC='A'";
                SqlCommand cmdEPFCalc = new SqlCommand(strEPFCalc, _Conn);
                cmdEPFCalc.ExecuteNonQuery();
                cmdEPFCalc.Dispose();
                _Conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}