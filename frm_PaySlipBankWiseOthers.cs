using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AquaPowerServices;

namespace Billing_Inventory_Management_System
{
    public partial class frm_PaySlipBankWiseOthers : Form
    {
        private SqlConnection _conn;
      //  private MenuStrip mnumain = new MenuStrip();
        bool bolChecked = false;
        CommonProfiles objComPro = new CommonProfiles();
        
        public frm_PaySlipBankWiseOthers()
        {
            InitializeComponent();
        }

        private void GetReports()
        {
            trvTenders.Nodes.Add("Tenders");

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            string strSQL = "SELECT DISTINCT dbo.TENDER_DETAILS.TEN_NO, dbo.TENDER_MAIN.DESCRIPTION,"+ 
                            " CAST(dbo.TENDER_DETAILS.EMP_NO AS INT) AS EMP_NO, dbo.EMPLOYEES.INITIALS + ' ' + dbo.EMPLOYEES.NAME AS NAME"+
                            " FROM dbo.TENDER_DETAILS INNER JOIN dbo.EMPLOYEES ON dbo.TENDER_DETAILS.EMP_NO = dbo.EMPLOYEES.EMP_NO INNER JOIN" +
                            " dbo.TENDER_MAIN ON dbo.TENDER_DETAILS.TEN_NO = dbo.TENDER_MAIN.TEN_NO WHERE (dbo.TENDER_DETAILS.EMP_STATUS = 1) AND (dbo.TENDER_MAIN.STATUS = 1)"+
                            " ORDER BY dbo.TENDER_DETAILS.TEN_NO, CAST(dbo.TENDER_DETAILS.EMP_NO AS INT)";

            DataTable tblTenders = new DataTable();
            SqlCommand scmTenders = new SqlCommand(strSQL, _conn);
            SqlDataAdapter sdaTenders = new SqlDataAdapter();

            sdaTenders.SelectCommand = scmTenders;
            sdaTenders.Fill(tblTenders);

            string strTender = "";
            int iNode = 0;
            int icount = 0;
            int i = 0;
                        
            while (i < tblTenders.Rows.Count)
            {
                if (strTender != tblTenders.Rows[i]["TEN_NO"].ToString())
                {
                    trvTenders.Nodes[0].Nodes.Add(tblTenders.Rows[i]["TEN_NO"].ToString(), tblTenders.Rows[i]["TEN_NO"].ToString() + " - " + tblTenders.Rows[i]["DESCRIPTION"].ToString());
                  
                  if (i>0) // should increment after 0
                  iNode+=1;
                 
                     strTender = tblTenders.Rows[i]["TEN_NO"].ToString();

                    icount+=1;
                }
                trvTenders.Nodes[0].Nodes[iNode].Nodes.Add(tblTenders.Rows[i]["EMP_NO"].ToString(), tblTenders.Rows[i]["EMP_NO"].ToString() + " - " + tblTenders.Rows[i]["NAME"].ToString());

                  i++;
            }
            //trvTenders.ExpandAll();
            trvTenders.Nodes[0].Expand();
         //   MessageBox.Show(icount.ToString());
            _conn.Close();
        }

        bool isCheck;
        TreeNode trnNode;

        private void trvTenders_AfterCheck(object sender, TreeViewEventArgs e)
        {            
            if (e.Node.Checked == true)
            {
                isCheck = true;                
            }
            else
            {
                isCheck = false;
            }

            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                e.Node.Nodes[i].Checked = isCheck;
            }
        }

        private void trvTenders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(trnNode.Text);

            //for (int i = 0; i < trnNode.Nodes.Count; i++)
            //{
            //    if(trnNode.Nodes[i].Checked==true)
            //        MessageBox.Show(trnNode.Nodes[i].Text);
            //}
            if (cmbYear.Text == "" || cmbMonth.Text == "")
            {
                MessageBox.Show("Please Select Year and Month to proceed", "Bank Selection Criteria");
                return;
            }
            string strSQL;
            string strTenNode="";
            string strEmpNode = "";
            string strTen = "";

            strSQL = "SELECT EMP_NO, EMP_NAME, BANK, BRANCH, ACC_NO, PAY_VALUE, PAY_YEAR, SAL_MONTH, NAME_BANK, BANK_CODE, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (EAR_ID = 'NETSAL') AND (BANK_CODE <> '7010') AND (BANK_CODE <> '7056') AND PAY_YEAR='" + cmbYear.Text + "' AND SAL_MONTH = '" + cmbMonth.Text + "' AND BATCH_NO = '" + cmbBatchNo.Text + "' AND (EMP_NO IN(";
            int intTen = 0;
//===========
            foreach (TreeNode tNode in trvTenders.Nodes[0].Nodes)
            {
                if (tNode.Checked == true)
                {
                    if (intTen > 0)
                        strSQL += ",";

                    if (tNode.Nodes.Count > 0)
                    {
                        int i = 0;
                        foreach (TreeNode cNode in tNode.Nodes)
                        {
                            if (cNode.Checked == true)
                            {
                                if (i > 0)
                                    strEmpNode += ",";

                                strEmpNode += cNode.Name;
                                i++;
                            }                            
                        }
                    }
                    intTen++;
                    strSQL += strEmpNode;
                }

                //strSQL += strEmpNode;
                strTenNode = "";
                strEmpNode = "";
            }
            strSQL += "))";

// =============

           // ReportGenerate();

            if (intTen == 0)
            {
                //MessageBox.Show("Please Select Tender Number to Proceed","Bank Wise Payslips");
                if (chbExcel.Checked == true)
                    strSQL = "SELECT EMP_NO, EMP_NAME, BANK, BRANCH, ACC_NO, PAY_VALUE, PAY_YEAR, SAL_MONTH, NAME_BANK, BANK_CODE, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (EAR_ID = 'NETSAL') AND PAY_YEAR='" + cmbYear.Text + "' AND SAL_MONTH = '" + cmbMonth.Text + "' AND BATCH_NO = '" + cmbBatchNo.Text + "' AND (BANK_CODE <> '7010') AND (BANK_CODE <> '7056') ORDER BY BANK_CODE";
                else
                    strSQL = "SELECT EMP_NO, EMP_NAME, BANK, BRANCH, ACC_NO, PAY_VALUE, PAY_YEAR, SAL_MONTH, NAME_BANK, BANK_CODE, RIGHT(BRANCH_CODE, 3) AS SORT_BRANCH FROM RE_VW_PAY_SLIP WHERE (EAR_ID = 'NETSAL') AND PAY_YEAR='" + cmbYear.Text + "' AND SAL_MONTH = '" + cmbMonth.Text + "' AND BATCH_NO = '" + cmbBatchNo.Text + "' AND (BANK_CODE <> '7010') AND (BANK_CODE <> '7056') ORDER BY BANK_CODE";                //return;
            }

            SqlDataAdapter dscmd = new SqlDataAdapter(strSQL, _conn);
           // MessageBox.Show(strSQL);
            PaySlipBankWise ds = new PaySlipBankWise();
            dscmd.Fill(ds, "Product");
           // MessageBox.Show(ds.Tables[1].Rows.Count.ToString());
            if (ds.Tables[1].Rows.Count == 0)
            {
                MessageBox.Show("No Data for Provided Selection", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _conn.Close();
                return;
            }

            if (chbExcel.Checked == true)
            {
                if (intTen > 0)
                    strSQL = strSQL + " ORDER BY BANK_CODE"; // To avoid duplicate ORDER BY clause in SQL

                frm_ReportCriteria_Inventory objRepCriteria = new frm_ReportCriteria_Inventory();
                //objRepCriteria.CommercialBank(strSQL);
                objRepCriteria.BankofCeylonExel(strSQL);
                
            }
            else
            {
                BankWisePaySlip objRpt = new BankWisePaySlip();
                objRpt.SetDataSource(ds.Tables[1]);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
            }
        }

        private void trvTenders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count > 0 && e.Node.Checked==true)
                trnNode = e.Node;
            else
                trnNode = e.Node.Parent;
        }

        private void ReportGenerate()
        {
            
        }

        private void frmPaySlipBankWise_Load(object sender, EventArgs e)
        {
            trvTenders.Nodes.Clear();
            GetReports();
            //LoadMenu();
        }

        private void btnSelection_Click(object sender, EventArgs e)
        {
            if (bolChecked == true)
            {
                btnSelection.Text = "Select ALL";
                trvTenders.Nodes[0].Checked = false;
                bolChecked = false;
            }
            else
            {
                btnSelection.Text = "Deselect ALL";
                trvTenders.Nodes[0].Checked = true;
                bolChecked = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chbExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chbExcel.Checked == true)
                btnPrint.Text = "Upload";
            else
                btnPrint.Text = "Print";
            
        }

        private void cmbMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            int intMonth = objComPro.GetMonthConverted(cmbMonth.Text);

            string strSQL = "SELECT TOP 100 PERCENT PAY_YEAR, PAY_MONTH, BATCH_NO FROM dbo.PAY_SLIPS_EARNINGS" +
                            " GROUP BY PAY_YEAR, PAY_MONTH, BATCH_NO HAVING (PAY_YEAR = '" + cmbYear.Text + "') AND (PAY_MONTH = " + intMonth + ") ORDER BY BATCH_NO";
 
            DataTable tblBatchNo = new DataTable();
            SqlCommand scmBatchNo = new SqlCommand(strSQL, _conn);
            SqlDataAdapter sdaBatchNo = new SqlDataAdapter();

            sdaBatchNo.SelectCommand = scmBatchNo;
            sdaBatchNo.Fill(tblBatchNo);

            cmbBatchNo.DataSource = tblBatchNo;
            cmbBatchNo.DisplayMember = "BATCH_NO";

            _conn.Close();
            //tblBatchNo.Dispose();
            scmBatchNo.Dispose();
            sdaBatchNo.Dispose();
        }

        

        /*
         * 
         * foreach (TreeNode tNode in trvTenders.Nodes[0].Nodes)
            {
                if (tNode.Checked == true)
                {
                        strTen = "' AND EMP_NO=";
               
                    if (intTen > 1)
                        strTenNode += " OR TEN_NO='" + tNode.Name + strTen;
                    else
                        strTenNode += " TEN_NO='" + tNode.Name + strTen;

                    if (tNode.Nodes.Count > 0)
                    {
                        int i = 1;
                        foreach (TreeNode cNode in tNode.Nodes)
                        {
                            if (i == tNode.Nodes.Count || cNode.Checked == false)
                                strEmpNode = "";
                            else if (i == tNode.Nodes.Count && cNode.Checked == true)
                                strEmpNode = " AND ";
                            else if (i == (tNode.Nodes.Count - 1) && cNode.NextNode.Checked == false)
                                strEmpNode = "";
                            else
                                strEmpNode = " OR EMP_NO=";

                            if (cNode.Checked == true)
                            {
                                strTenNode += cNode.Name + strEmpNode;
                            }
                            i++;
                        }
                    }
                    intTen++;
                }

                strSQL += strTenNode;
                strTenNode = "";
                strEmpNode = "";
            }
            strSQL += strTenNode;

            txtSQL.Text = strSQL;
         * */
    }
}