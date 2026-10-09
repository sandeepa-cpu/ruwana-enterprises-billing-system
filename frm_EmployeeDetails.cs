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
    public partial class frm_EmployeeDetails : Form
    {
        CommonProfiles getComProfiles = new CommonProfiles(); 

        private int intYear = 0;
        private int intMonth = 0;

        private int intSTATUS = 0;
        private string strUser;
        private int intUserLevel;

        public frm_EmployeeDetails()
        {
            InitializeComponent();
        }
        private SqlConnection _conn;
        int Find_EMP = 0;
        int Find_OFF_EMP = 0;
        int Find_EMP_CAT = 0;
        int Find_SUPERVISORS = 0;

        private void tb_EmployeeDetails_Load(object sender, EventArgs e)
        {           

            txt_Title.Focus();
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT EMP_NO FROM EMPLOYEES WHERE EMP_NO = (SELECT MAX(CONVERT(INT,EMP_NO))FROM EMPLOYEES)";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                int EMP_SEL = 0;
                txt_EmpNo.Text = dreader["EMP_NO"].ToString();
                EMP_SEL = Convert.ToInt32(txt_EmpNo.Text.ToString());
                txt_EmpNo.Text = Convert.ToString(EMP_SEL + 1);
            }
            
            dreader.Close();
            _conn.Dispose();
            txt_Basic.Text = "0.00";
            txt_FxDeduct.Text = "0.00";
            txt_FxEarn.Text = "0.00";
            txt_PayeeTax.Text = "0.00";

            if (txt_EmpNo.Text == "")
            {
                txt_EmpNo.Text = "1";
            }

            SelectBank();
         
            UserLevels();
            txt_Title.Focus();
        }

        private void SelectBank()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdBankMain = new SqlCommand("SELECT BANK_CODE, BANK FROM BANK_DETAILS", _conn);
            SqlDataReader drBankMain = cmdBankMain.ExecuteReader();
            while (drBankMain.Read())
            {
                cmb_Bank.Items.Add(drBankMain["BANK"].ToString());
            }
            drBankMain.Close();
            _conn.Close();
        }

        private void SelectBankCode()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdBankMain = new SqlCommand("SELECT BANK_CODE, BANK FROM BANK_DETAILS WHERE BANK = '" + cmb_Bank.Text.Trim() + "'", _conn);
            SqlDataReader drBankMain = cmdBankMain.ExecuteReader();
            while (drBankMain.Read())
            {
                txt_BankCode.Text = drBankMain["BANK_CODE"].ToString();
            }
            drBankMain.Close();
            _conn.Close();
        }
        
        private void SelectBranch()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdBranchMain = new SqlCommand("SELECT BRANCH_CODE, BRANCH FROM BRANCH_DETAILS WHERE BANK_CODE = '"+ txt_BankCode.Text.Trim() +"'", _conn);
            SqlDataReader drBranchMain = cmdBranchMain.ExecuteReader();
            while (drBranchMain.Read())
            {
                cmb_Branch.Items.Add(drBranchMain["BRANCH"].ToString());
            }
            drBranchMain.Close();
            _conn.Close();
        }

        private void Find_Employee()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "SELECT * FROM EMPLOYEES WHERE (EMP_NO = '" + txt_EmpNo.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txt_EmpNo.Text = dreader["EMP_NO"].ToString();
            }
            dreader.Close();
            _conn.Close();
        }

       //SEARCH EMPLOYEE RECORDS

        private void txt_EmpNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                e.Handled = true;
                if (txt_EmpNo.Text != "")
                {
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _conn;
                    cmdsql.CommandText = "SELECT * FROM EMPLOYEES WHERE (EMP_NO = '" + txt_EmpNo.Text + "')";
                    SqlDataReader dreader = cmdsql.ExecuteReader();
                    while (dreader.Read())
                    {
                        if (dreader.HasRows == true)
                        {
                            txt_EmpNo.Text = dreader["EMP_NO"].ToString().Trim();
                            txt_Grade.Text = dreader["GRADE"].ToString().Trim();
                            txt_Title.Text = dreader["TITLE"].ToString().Trim();
                            txt_Initials.Text = dreader["INITIALS"].ToString().Trim();
                            txt_SurName.Text = dreader["NAME"].ToString().Trim();
                            txt_FullName.Text = dreader["FULL_NAME"].ToString().Trim();
                            dt_Birth.Text = Convert.ToString(dreader["DATE_OF_BIRTH"]).ToString().Trim();
                            txt_NICNo.Text = dreader["NIC_NO"].ToString().Trim();
                            txt_Sex.Text = dreader["SEX"].ToString().Trim();
                            txt_Civil.Text = dreader["CIVIL_STATUS"].ToString().Trim();
                            cmb_Bank.Text = dreader["BANK"].ToString().Trim();
                            cmb_Branch.Text = dreader["BRANCH"].ToString().Trim();
                            txt_Basic.Text = dreader["BASIC_SALARY"].ToString().Trim();
                            txt_FxEarn.Text = dreader["FIXED_EARNINGS"].ToString().Trim();
                            txt_FxDeduct.Text = dreader["FIXED_DEDUCTIONS"].ToString().Trim();
                            txt_AccNo.Text = dreader["ACC_NO"].ToString().Trim();
                            txt_Address.Text = dreader["ADDRESS"].ToString().Trim();
                            //      txt_PayMode.Text = dreader["PAYMENT_MODE"].ToString().Trim();
                            txt_EmpStatus.Text = dreader["EMPLOYEE_STATUS"].ToString().Trim();
                            txt_Designation.Text = dreader["DESIGNATION"].ToString().Trim();
                            txt_PayeeTax.Text = dreader["EMP_RATE"].ToString().Trim();
                            txt_Department.Text = dreader["DEPARTMENT"].ToString().Trim();
                            txt_BankCode.Text = dreader["BANK_CODE"].ToString().Trim();
                            txt_BranchCode.Text = dreader["BRANCH_CODE"].ToString().Trim();
                            txt_FileNo.Text = dreader["FILE_NO"].ToString().Trim();
                            txt_Mobile.Text = dreader["MOBILE_NO"].ToString().Trim();
                            txt_Resident.Text = dreader["RESIDENT_NO"].ToString().Trim();
                            txt_Grade.Text = dreader["GRADE"].ToString().Trim();
                            dt_Joined.Text = Convert.ToString(dreader["DATE_OF_JOINED"]).ToString().Trim();

                            Find_EMP_CAT = Convert.ToInt16(dreader["EMP_CATEGORY"].ToString().Trim());
                            if (Find_EMP_CAT == 0)
                            {
                                rb_Exe.Checked = true;
                                rb_Off.Checked = false;
                                rb_Ten.Checked = false;
                            }
                            else if (Find_EMP_CAT == 1)
                            {
                                rb_Off.Checked = true;
                                rb_Exe.Checked = false;
                                rb_Ten.Checked = false;
                            }
                            else if (Find_EMP_CAT == 2)
                            {
                                rb_Ten.Checked = true;
                                rb_Exe.Checked = false;
                                rb_Off.Checked = false;
                            }

                            Find_EMP = Convert.ToInt16(dreader["STATUS"].ToString().Trim());
                            string Action = dreader["USER_ACTION"].ToString().Trim();
                            if (Find_EMP == 1)
                            {
                                btn_ReActivate.Enabled = false;
                                btn_Deactivate.Enabled = true;
                                if (Action == "Approve")
                                {
                                    lblApprove.Text = "Employee is Approved";
                                }
                            }
                            else if (Find_EMP == 0)
                            {
                                btn_ReActivate.Enabled = true;
                                btn_Deactivate.Enabled = false;
                                if (Action != "Approve")
                                {
                                    lblApprove.Text = "Employee is Deactivated";
                                }
                            }
                            else if (Find_EMP == 2)
                            {
                                btn_ReActivate.Enabled = false;
                                btn_Deactivate.Enabled = false;
                                if (Action != "Approve")
                                {
                                    lblApprove.Text = "Employee is Not Approved";
                                }
                            }

                            lblTotSecDep.Text = dreader["TOT_SECDEP"].ToString().Trim();
                            
                            intSTATUS = int.Parse(dreader["STATUS"].ToString()); // EMPLOYEE Approval process
                            
                            txt_Title.Focus();
                        }
                    }
                    if (dreader.HasRows == false)
                        {
                            MessageBox.Show("The Number Entered is not Assigned to an Employee", "Employee Details");
                            txt_EmpNo.Focus();
                        }

                    dreader.Close();
                    _conn.Close();
                }
                else
                    MessageBox.Show("Nothing was entered! Please Enter Employee Number and Retry.", "Entry Error");
                
                txt_Title.Focus();
            }
        }
        
        //ADD NEW EMPLOYEE RECORDS
        private void btn_Add_Click(object sender, EventArgs e)
        {      
            int ExeOffTen = 0;

            if (rb_Exe.Checked == true)
            {
                ExeOffTen = 0;
            }
            else if (rb_Off.Checked == true)
            {
                ExeOffTen = 1;
            }
            else if (rb_Ten.Checked == true)
            {
                ExeOffTen = 2;
            }

            if (txt_AccNo.Text == "" || txt_BankCode.Text == "" || txt_BranchCode.Text == "" || txt_EmpStatus.Text == "" || txt_SurName.Text == "" || txt_Initials.Text == "" || txt_NICNo.Text == "" || txt_Title.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Procceed", "Data Entry Error.....");
            }
            else
            {
                try
                {
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _conn;
                    cmdsql.CommandText = "INSERT INTO EMPLOYEES (EMP_NO, TITLE, INITIALS, NAME, FULL_NAME, DATE_OF_BIRTH, NIC_NO, SEX, CIVIL_STATUS, BANK, BRANCH, BASIC_SALARY, FIXED_EARNINGS, FIXED_DEDUCTIONS, DEPARTMENT, DESIGNATION, STATUS, ACC_NO, EMPLOYEE_STATUS, EMP_CATEGORY, ADDRESS, RESIDENT_NO, MOBILE_NO, BANK_CODE, BRANCH_CODE, DATE_OF_JOINED, FILE_NO, EMP_RATE, TOT_SECDEP, ADDED_BY, ADDED_DATE, USER_ACTION, GRADE)VALUES ('" + txt_EmpNo.Text + "', '" + txt_Title.Text + "', '" + txt_Initials.Text + "', '" + txt_SurName.Text + "', '" + txt_FullName.Text + "', '" + dt_Birth.Text + "', '" + txt_NICNo.Text + "', '" + txt_Sex.Text + "', '" + txt_Civil.Text + "', '" + cmb_Bank.Text + "', '" + cmb_Branch.Text + "', " + txt_Basic.Text + ", " + txt_FxEarn.Text + "," + txt_FxDeduct.Text + ", '" + txt_Department.Text + "', '" + txt_Designation.Text + "', '2', '" + txt_AccNo.Text + "', '" + txt_EmpStatus.Text + "', '" + ExeOffTen + "','" + txt_Address.Text + "','" + txt_Resident.Text + "','" + txt_Mobile.Text + "', '" + txt_BankCode.Text + "', '" + txt_BranchCode.Text + "', '" + dt_Joined.Text + "', '" + txt_FileNo.Text + "','" + txt_PayeeTax.Text + "', '0', '" + GetUser +"', '" + DateTime.Now + "', 'Added', '"+ txt_Grade.Text +"')";
                    SqlDataReader dreader = cmdsql.ExecuteReader();
                    MessageBox.Show("Employee is added Successfully", "Add New Employee");
                    _conn.Close();
                }

                catch (Exception)
                {
                    MessageBox.Show("Employee is already Added or Data Entry Error", "Add New Employee");
                }
            }
        }


        //UPDATE EMPLOYEE RECORDS

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int ExeOffTen = 0;

            if (rb_Exe.Checked == true)
            {
                ExeOffTen = 0;
            }
            else if (rb_Off.Checked == true)
            {
                ExeOffTen = 1;
            }
            else if (rb_Ten.Checked == true)
            {
                ExeOffTen = 2;
            }

            try
            {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;

            //cmdsql.CommandText = "UPDATE EMPLOYEES SET EMP_CATEGORY = '" + ExeOffTen + "', TITLE = '" + txt_Title.Text.Trim() + "', INITIALS = '" + txt_Initials.Text.Trim() + "', NAME = '" + txt_SurName.Text.Trim() + "', FULL_NAME = '" + txt_FullName.Text.Trim() + "', ADDRESS = '" + txt_Address.Text.Trim() + "', RESIDENT_NO = '" + txt_Resident.Text.Trim() + "', MOBILE_NO = '" + txt_Mobile.Text.Trim() + "', DATE_OF_BIRTH = Convert(DateTime,'" + dt_Birth.Text.ToString().Trim() + "'), NIC_NO = '" + txt_NICNo.Text.Trim() + "', SEX = '" + txt_Sex.Text.Trim() + "', CIVIL_STATUS = '" + txt_Civil.Text.Trim() + "', BANK_CODE = '" + txt_BankCode.Text.Trim() + "', BANK = '" + cmb_Bank.Text.Trim() + "', BRANCH_CODE = '" + txt_BranchCode.Text.Trim() + "', BRANCH = '" + cmb_Branch.Text.Trim() + "', BASIC_SALARY = Convert(Money,'" + txt_Basic.Text + "'), FIXED_EARNINGS = Convert(Money,'" + txt_FxEarn.Text + "'), FIXED_DEDUCTIONS = Convert(Money,'" + txt_FxDeduct.Text + "'), DEPARTMENT = '" + txt_Department.Text.Trim() + "', DESIGNATION = '" + txt_Designation.Text.Trim() + "', DATE_OF_JOINED = Convert(DateTime,'" + dt_Joined.Text.ToString().Trim() + "'), ACC_NO = '" + txt_AccNo.Text.Trim() + "', EMP_RATE = Convert(Money,'" + txt_PayeeTax.Text.Trim() + "'), FILE_NO = '" + txt_FileNo.Text.Trim() + "', EMPLOYEE_STATUS = '" + txt_EmpStatus.Text.Trim() + "', OFFICE_EMP = " + OfficeEmp + ", SUPERVISOR = '" + Supervisors + "', STATUS = '2', MODIFIED_BY = '" + GetUser + "', MODIFIED_DATE = '" + DateTime.Now + "', USER_ACTION = 'Modify' WHERE (EMP_NO = '" + txt_EmpNo.Text.Trim() + "')";
            cmdsql.CommandText = "UPDATE EMPLOYEES SET EMP_CATEGORY = '" + ExeOffTen + "', TITLE = '" + txt_Title.Text.Trim() + "', INITIALS = '" + txt_Initials.Text.Trim() + "', NAME = '" + txt_SurName.Text.Trim() + "', FULL_NAME = '" + txt_FullName.Text.Trim() + "', ADDRESS = '" + txt_Address.Text.Trim() + "', RESIDENT_NO = '" + txt_Resident.Text.Trim() + "', MOBILE_NO = '" + txt_Mobile.Text.Trim() + "', DATE_OF_BIRTH = Convert(DateTime,'" + dt_Birth.Text.ToString().Trim() + "'), NIC_NO = '" + txt_NICNo.Text.Trim() + "', SEX = '" + txt_Sex.Text.Trim() + "', CIVIL_STATUS = '" + txt_Civil.Text.Trim() + "', BANK_CODE = '" + txt_BankCode.Text.Trim() + "', BANK = '" + cmb_Bank.Text.Trim() + "', BRANCH_CODE = '" + txt_BranchCode.Text.Trim() + "', BRANCH = '" + cmb_Branch.Text.Trim() + "', BASIC_SALARY = Convert(Money,'" + txt_Basic.Text + "'), FIXED_EARNINGS = Convert(Money,'" + txt_FxEarn.Text + "'), FIXED_DEDUCTIONS = Convert(Money,'" + txt_FxDeduct.Text + "'), DEPARTMENT = '" + txt_Department.Text.Trim() + "', DESIGNATION = '" + txt_Designation.Text.Trim() + "', DATE_OF_JOINED = Convert(DateTime,'" + dt_Joined.Text.ToString().Trim() + "'), ACC_NO = '" + txt_AccNo.Text.Trim() + "', EMP_RATE = Convert(Money,'" + txt_PayeeTax.Text.Trim() + "'), FILE_NO = '" + txt_FileNo.Text.Trim() + "', EMPLOYEE_STATUS = '" + txt_EmpStatus.Text.Trim() + "', STATUS = '2', MODIFIED_BY = '" + GetUser + "', MODIFIED_DATE = '" + DateTime.Now + "', USER_ACTION = 'Modify', GRADE = '" + txt_Grade.Text + "' WHERE (EMP_NO = '" + txt_EmpNo.Text.Trim() + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            MessageBox.Show("Modification of Employee Information are Completed", "Modify Employee");
            _conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Employee not Found or Data Entry Error", "Modify Employee");
            }

            if (Find_EMP_CAT == 2)
            {
                if (ExeOffTen == 0 || ExeOffTen == 1)
                {
                    ClearRecords();
                    ClearDupRecords();
                    ClearTenderRecords();
                }
            }
        }

        private void ClearRecords()
        {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;

                cmdsql.CommandText = "DELETE FROM INVOICES WHERE (EMP_NO = '" + txt_EmpNo.Text.Trim() + "')";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                _conn.Close();
        }

        private void ClearDupRecords()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;

            cmdsql.CommandText = "DELETE FROM INVOICES_DUPLICATE WHERE (EMP_NO = '" + txt_EmpNo.Text.Trim() + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            _conn.Close();
        }

        private void ClearTenderRecords()
        {

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;

            cmdsql.CommandText = "DELETE FROM TENDER_DETAILS WHERE (EMP_NO = '" + txt_EmpNo.Text.Trim() + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            _conn.Close();
        }
        
        //DELETE EMPLOYEE RECORDS

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            cmdsql.CommandText = "DELETE FROM EMPLOYEES WHERE (EMP_NO = '" + txt_EmpNo.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            _conn.Close();
        }
       


        //QUIT EMPLOYEE FORM

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_NICNo_Leave(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _conn;
            //cmdsql.CommandText = "SELECT EMP_NO, TITLE, INITIALS, NAME, FULL_NAME, DATE_OF_BIRTH, NIC_NO, SEX, CIVIL_STATUS, BANK, BRANCH, BASIC_SALARY, FIXED_EARNINGS, FIXED_DEDUCTIONS, DEPARTMENT, DESIGNATION, EMPLOYEE_STATUS, PAYMENT_MODE, ACC_NO, STATUS FROM EMPLOYEES WHERE (NIC_NO = '" + txt_NICNo.Text + "')";
            cmdsql.CommandText = "SELECT * FROM EMPLOYEES WHERE (NIC_NO = '"+ txt_NICNo.Text +"')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                if (Convert.ToInt32(dreader["STATUS"]) == 0)
                {
                    MessageBox.Show("Already Assigned & Inactivated Employee");
                    txt_EmpNo.Text = dreader["EMP_NO"].ToString();
                    txt_Title.Text = dreader["TITLE"].ToString();
                    txt_Initials.Text = dreader["INITIALS"].ToString();
                    txt_SurName.Text = dreader["NAME"].ToString();
                    txt_FullName.Text = dreader["FULL_NAME"].ToString();
                    dt_Birth.Text = Convert.ToString(dreader["DATE_OF_BIRTH"]).ToString();
                    txt_NICNo.Text = dreader["NIC_NO"].ToString();
                    txt_Sex.Text = dreader["SEX"].ToString();
                    txt_Civil.Text = dreader["CIVIL_STATUS"].ToString();
                    cmb_Bank.Text = dreader["BANK"].ToString();
                    cmb_Branch.Text = dreader["BRANCH"].ToString();
                    txt_Basic.Text = dreader["BASIC_SALARY"].ToString().Trim();
                    txt_FxEarn.Text = dreader["FIXED_EARNINGS"].ToString().Trim();
                    txt_FxDeduct.Text = dreader["FIXED_DEDUCTIONS"].ToString().Trim();
                    txt_AccNo.Text = dreader["ACC_NO"].ToString();
                //    txt_PayMode.Text = dreader["PAYMENT_MODE"].ToString();
                    txt_EmpStatus.Text = dreader["EMPLOYEE_STATUS"].ToString();
                    txt_Designation.Text = dreader["DESIGNATION"].ToString();
                    txt_PayeeTax.Text = dreader["EMP_RATE"].ToString();
                    txt_Address.Text = dreader["ADDRESS"].ToString();
                    txt_Department.Text = dreader["DEPARTMENT"].ToString();
                    txt_BankCode.Text = dreader["BANK_CODE"].ToString();
                    txt_BranchCode.Text = dreader["BRANCH_CODE"].ToString();
                    txt_FileNo.Text = dreader["FILE_NO"].ToString();
                    txt_Mobile.Text = dreader["MOBILE_NO"].ToString();
                    txt_Resident.Text = dreader["RESIDENT_NO"].ToString();
                    dt_Joined.Text = Convert.ToString(dreader["DATE_OF_JOINED"]).ToString();

                    Find_EMP_CAT = Convert.ToInt16(dreader["EMP_CATEGORY"].ToString());
                    if (Find_EMP_CAT == 0)
                    {
                        rb_Exe.Checked = true;
                        rb_Off.Checked = false;
                        rb_Ten.Checked = false;
                    }
                    else if (Find_EMP_CAT == 1)
                    {
                        rb_Off.Checked = true;
                        rb_Exe.Checked = false;
                        rb_Ten.Checked = false;
                    }
                    else if (Find_EMP_CAT == 2)
                    {
                        rb_Ten.Checked = true;
                        rb_Exe.Checked = false;
                        rb_Off.Checked = false;
                    }

                    Find_EMP = Convert.ToInt16(dreader["STATUS"].ToString());
                    if (Find_EMP == 1)
                    {
                        btn_ReActivate.Enabled = false;
                    }
                    else if (Find_EMP == 0)
                    {
                        btn_ReActivate.Enabled = true;
                    }
                    else if (Find_EMP == 2)
                    {
                        btn_ReActivate.Enabled = false;
                        btn_ReActivate.Enabled = false;
                    }

                    lblTotSecDep.Text = dreader["TOT_SECDEP"].ToString().Trim();

                }
                else  
                {
                    MessageBox.Show("Employee is already Assigned or Inactivated!", "Employee Details");
                    txt_EmpNo.Text = dreader["EMP_NO"].ToString();
                    txt_Title.Text = dreader["TITLE"].ToString();
                    txt_Initials.Text = dreader["INITIALS"].ToString();
                    txt_SurName.Text = dreader["NAME"].ToString();
                    txt_FullName.Text = dreader["FULL_NAME"].ToString();
                    dt_Birth.Text = Convert.ToString(dreader["DATE_OF_BIRTH"]).ToString();
                    txt_NICNo.Text = dreader["NIC_NO"].ToString();
                    txt_Sex.Text = dreader["SEX"].ToString();
                    txt_Civil.Text = dreader["CIVIL_STATUS"].ToString();
                    cmb_Bank.Text = dreader["BANK"].ToString();
                    cmb_Branch.Text = dreader["BRANCH"].ToString();
                    txt_Basic.Text = dreader["BASIC_SALARY"].ToString().Trim();
                    txt_FxEarn.Text = dreader["FIXED_EARNINGS"].ToString().Trim();
                    txt_FxDeduct.Text = dreader["FIXED_DEDUCTIONS"].ToString().Trim();
                    txt_AccNo.Text = dreader["ACC_NO"].ToString();
               //     txt_PayMode.Text = dreader["PAYMENT_MODE"].ToString();
                    txt_EmpStatus.Text = dreader["EMPLOYEE_STATUS"].ToString();
                    txt_Designation.Text = dreader["DESIGNATION"].ToString();
                    txt_PayeeTax.Text = dreader["EMP_RATE"].ToString();
                    txt_Department.Text = dreader["DEPARTMENT"].ToString();
                    txt_BankCode.Text = dreader["BANK_CODE"].ToString();
                    txt_BranchCode.Text = dreader["BRANCH_CODE"].ToString();
                    txt_FileNo.Text = dreader["FILE_NO"].ToString();
                    txt_Mobile.Text = dreader["MOBILE_NO"].ToString();
                    txt_Address.Text = dreader["ADDRESS"].ToString();
                    txt_Resident.Text = dreader["RESIDENT_NO"].ToString();
                    dt_Joined.Text = Convert.ToString(dreader["DATE_OF_JOINED"]).ToString();

                    Find_EMP_CAT = Convert.ToInt16(dreader["EMP_CATEGORY"].ToString());
                    if (Find_EMP_CAT == 0)
                    {
                        rb_Exe.Checked = true;
                        rb_Off.Checked = false;
                        rb_Ten.Checked = false;
                    }
                    else if (Find_EMP_CAT == 1)
                    {
                        rb_Off.Checked = true;
                        rb_Exe.Checked = false;
                        rb_Ten.Checked = false;
                    }
                    else if (Find_EMP_CAT == 2)
                    {
                        rb_Ten.Checked = true;
                        rb_Exe.Checked = false;
                        rb_Off.Checked = false;
                    }

                    Find_EMP = Convert.ToInt16(dreader["STATUS"].ToString());
                    if (Find_EMP == 1)
                    {
                        btn_ReActivate.Enabled = false;
                    }
                    else if (Find_EMP == 0)
                    {
                        btn_ReActivate.Enabled = true;
                    }
                    else if (Find_EMP == 2)
                    {
                        btn_ReActivate.Enabled = false;
                        btn_ReActivate.Enabled = false;
                    }

                    lblTotSecDep.Text = dreader["TOT_SECDEP"].ToString().Trim();
                }
              
            }
            dreader.Dispose();
            _conn.Close();
        }

        private void btn_ReActivate_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "UPDATE EMPLOYEES SET STATUS = '1' , MODIFIED_BY = '" + GetUser + "', MODIFIED_DATE = '" + DateTime.Now + "', USER_ACTION = 'ReActiveUser' WHERE EMP_NO = '" + txt_EmpNo.Text + "'";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                MessageBox.Show("Selected Employee is Successfully Re-activated", "Activation");
                dreader.Close();
                _conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Select an Employee to Re-activate", "Activation Error ......");
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            {
                txt_EmpNo.Focus();
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "SELECT EMP_NO FROM EMPLOYEES WHERE EMP_NO = (SELECT MAX(CONVERT(INT,EMP_NO))FROM EMPLOYEES)";
                SqlDataReader dreader = cmdsql.ExecuteReader();

                while (dreader.Read())
                {
                    int EMP_SEL = 0;
                    txt_EmpNo.Text = dreader["EMP_NO"].ToString();
                    EMP_SEL = Convert.ToInt32(txt_EmpNo.Text.ToString());
                    txt_EmpNo.Text = Convert.ToString(EMP_SEL + 1);
                }

                dreader.Close();
                _conn.Dispose();
                txt_Basic.Text = "0.00";
                txt_FxDeduct.Text = "0.00";
                txt_FxEarn.Text = "0.00";
                txt_PayeeTax.Text ="0.00";
                txt_Title.ResetText();
                txt_Initials.Clear();
                txt_SurName.Clear();
                txt_FullName.Clear();
                dt_Birth.ResetText();
                txt_NICNo.Clear();
                txt_Sex.ResetText();
                txt_Civil.ResetText();
                cmb_Bank.ResetText();
                cmb_Branch.ResetText();
                txt_AccNo.Clear();
           //     txt_PayMode.Clear();
                txt_EmpStatus.ResetText();
                txt_Designation.Clear();
                txt_Department.Clear();
                txt_BankCode.Clear();
                txt_BranchCode.Clear();
                txt_Address.Clear();
                txt_FileNo.Clear();
                txt_Mobile.Clear();
                txt_Resident.Clear();
                dt_Joined.ResetText();
                rb_Exe.Checked = false;
                rb_Off.Checked = false;
                rb_Ten.Checked = false;
                lblTotSecDep.Text = "";
            }
            txt_Title.Focus();
            _conn.Close();
        }

        private void txt_EmpNo_Leave(object sender, EventArgs e)
        {
            {
                if (txt_EmpNo.Text != "")
                {
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _conn;
                    cmdsql.CommandText = "Select * from Employees Where (EMP_NO = '" + txt_EmpNo.Text + "')";
                    SqlDataReader dreader = cmdsql.ExecuteReader();
                    while (dreader.Read())
                    {
                        txt_EmpNo.Text = dreader["EMP_NO"].ToString();
                        txt_Grade.Text = dreader["GRADE"].ToString().Trim();
                        txt_Title.Text = dreader["TITLE"].ToString();
                        txt_Initials.Text = dreader["INITIALS"].ToString();
                        txt_SurName.Text = dreader["NAME"].ToString();
                        txt_FullName.Text = dreader["FULL_NAME"].ToString();
                        dt_Birth.Text = Convert.ToString(dreader["DATE_OF_BIRTH"]).ToString();
                        txt_NICNo.Text = dreader["NIC_NO"].ToString();
                        txt_Sex.Text = dreader["SEX"].ToString();
                        txt_Civil.Text = dreader["CIVIL_STATUS"].ToString();
                        cmb_Bank.Text = dreader["BANK"].ToString();
                        cmb_Branch.Text = dreader["BRANCH"].ToString();
                        txt_Basic.Text = dreader["BASIC_SALARY"].ToString().Trim();
                        txt_FxEarn.Text = dreader["FIXED_EARNINGS"].ToString().Trim();
                        txt_FxDeduct.Text = dreader["FIXED_DEDUCTIONS"].ToString().Trim();
                        txt_AccNo.Text = dreader["ACC_NO"].ToString();
                   //     txt_PayMode.Text = dreader["PAYMENT_MODE"].ToString();
                        txt_EmpStatus.Text = dreader["EMPLOYEE_STATUS"].ToString();
                        txt_Designation.Text = dreader["DESIGNATION"].ToString();
                        txt_PayeeTax.Text = dreader["EMP_RATE"].ToString();
                        txt_Department.Text = dreader["DEPARTMENT"].ToString();
                        txt_BankCode.Text = dreader["BANK_CODE"].ToString();
                        txt_BranchCode.Text = dreader["BRANCH_CODE"].ToString();
                        txt_Address.Text = dreader["ADDRESS"].ToString();
                        txt_FileNo.Text = dreader["FILE_NO"].ToString();
                        txt_Mobile.Text = dreader["MOBILE_NO"].ToString().Trim();
                        txt_Resident.Text = dreader["RESIDENT_NO"].ToString().Trim();
                        txt_Grade.Text = dreader["GRADE"].ToString().Trim();
                        dt_Joined.Text = Convert.ToString(dreader["DATE_OF_JOINED"]).ToString();

                        Find_EMP_CAT = Convert.ToInt16(dreader["EMP_CATEGORY"].ToString());
                        if (Find_EMP_CAT == 0)
                        {
                            rb_Exe.Checked = true;
                            rb_Off.Checked = false;
                            rb_Ten.Checked = false;
                        }
                        else if (Find_EMP_CAT == 1)
                        {
                            rb_Off.Checked = true;
                            rb_Exe.Checked = false;
                            rb_Ten.Checked = false;
                        }
                        else if (Find_EMP_CAT == 2)
                        {
                            rb_Ten.Checked = true;
                            rb_Exe.Checked = false;
                            rb_Off.Checked = false;
                        }

                        Find_EMP = Convert.ToInt16(dreader["STATUS"].ToString().Trim());
                        string Action = dreader["USER_ACTION"].ToString().Trim();
                        if (Find_EMP == 1)
                        {
                            btn_ReActivate.Enabled = false;
                            btn_Deactivate.Enabled = true;
                            if (Action == "Approve")
                            {
                            lblApprove.Text = "Employee is Approved";
                            }
                        }
                        else if (Find_EMP == 0)
                        {
                            btn_ReActivate.Enabled = true;
                            btn_Deactivate.Enabled = false;
                            if (Action != "Approve")
                            {
                                lblApprove.Text = "Employee is Deactivated";
                            }
                        }
                        else if (Find_EMP == 2)
                        {
                            btn_ReActivate.Enabled = false;
                            btn_Deactivate.Enabled = false;
                            if (Action != "Approve")
                            {
                                lblApprove.Text = "Employee is Not Approved";
                            }
                        }

                        lblTotSecDep.Text = dreader["TOT_SECDEP"].ToString().Trim();

                        intSTATUS = int.Parse(dreader["STATUS"].ToString()); // EMPLOYEE Approval process

                        txt_Title.Focus();

                        if (Convert.ToInt16(dreader["STATUS"].ToString()) == 1)
                        btn_Deactivate.Enabled = true;
                        else if(Convert.ToInt16(dreader["STATUS"].ToString())== 0)
                        btn_Deactivate.Enabled = false;
                    }
                    if (dreader.HasRows == false)
                    {
                        MessageBox.Show("The Number Entered is not Assigned to an Employee", "Employee Details");
                        //txt_EmpNo.Focus();
                    }
                    dreader.Close();
                    _conn.Close();
                }
                else
                    MessageBox.Show("Nothing was entered! Please Enter Employee Number and Retry.", "Entry Error");
            }
        }

        private void txt_EmpNo_Enter(object sender, EventArgs e)
        {
            btn_Deactivate.Enabled = false;
            txt_Basic.Text = "0.00";
            txt_FxDeduct.Text = "0.00";
            txt_FxEarn.Text = "0.00";
            txt_PayeeTax.Text = "0.00";
            txt_Title.ResetText();
            txt_Initials.Clear();
            txt_SurName.Clear();
            txt_FullName.Clear();
            dt_Birth.ResetText();
            txt_NICNo.Clear();
            txt_Sex.ResetText();
            txt_Civil.ResetText();
            cmb_Bank.ResetText();
            cmb_Branch.ResetText();
            txt_AccNo.Clear();
         //   txt_PayMode.Clear();
            txt_EmpStatus.ResetText();
            txt_Designation.Clear();
            txt_Department.Clear();
            txt_BankCode.Clear();
            txt_BranchCode.Clear();
            txt_Address.Clear();
            txt_FileNo.Clear();
            txt_Mobile.Clear();
            txt_Resident.Clear();
            dt_Joined.ResetText();
            rb_Exe.Checked = false;
            rb_Off.Checked = false;
            rb_Ten.Checked = false;
            lblTotSecDep.Text = "";
        }

        private void cmb_Bank_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdBankCode = new SqlCommand("SELECT BANK_CODE, BANK FROM BANK_DETAILS WHERE BANK = '" + cmb_Bank.Text + "'", _conn);
            SqlDataReader drBankCode = cmdBankCode.ExecuteReader();
            drBankCode.Read();
            
            txt_BankCode.Text = drBankCode["BANK_CODE"].ToString();
            
            drBankCode.Close();

            SqlCommand cmdBranchDetail = new SqlCommand("SELECT * FROM BRANCH_DETAILS WHERE BANK_CODE = '" + txt_BankCode.Text + "' ORDER BY BRANCH" , _conn);
            SqlDataReader drBranchDetail = cmdBranchDetail.ExecuteReader();

            cmb_Branch.Items.Clear();
            txt_BranchCode.Text = "";
            cmb_Branch.Text = "";

            while(drBranchDetail.Read())
            {
                cmb_Branch.Items.Add(new KeyValuePair(drBranchDetail["BRANCH_CODE"], drBranchDetail["BRANCH"].ToString()));
            }
            drBranchDetail.Close();
            _conn.Close();
        }

        private void cmb_Branch_SelectedValueChanged(object sender, EventArgs e)
        {
            KeyValuePair maxPages = (KeyValuePair)cmb_Branch.SelectedItem;
            string skey = maxPages.Key.ToString();   
            string svalue = maxPages.Value.ToString();

            txt_BranchCode.Text = skey;
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

        private void txt_Title_SelectedValueChanged(object sender, EventArgs e)
        {
            if (txt_Title.Text == "Mr.")
                txt_Sex.Text = "Male";
            else
                txt_Sex.Text = "Female";
        }

        private void txt_FileNo_Leave(object sender, EventArgs e)
        {
           // txt_FileNo.Text = "AP/HRS/05/" + txt_FileNo.Text;
        }

        private void btn_Deactivate_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "UPDATE EMPLOYEES SET STATUS = '0', MODIFIED_BY = '" + GetUser + "', MODIFIED_DATE = '" + DateTime.Now + "', USER_ACTION = 'DeActive' WHERE EMP_NO = '" + txt_EmpNo.Text + "'";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                MessageBox.Show("Selected Employee is Successfully Deactivated", "Deactivation......");
                dreader.Close();
                _conn.Close();
                btn_Deactivate.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Select an Employee to Deactivate", "Deactivation......");
            }
        }

        private void btn_PayBackSecDep_Click(object sender, EventArgs e)
        {
            if (double.Parse(lblTotSecDep.Text) > 0)
            {
                getComProfiles = new CommonProfiles();

                intYear = getComProfiles.GetYear();
                intMonth = getComProfiles.GetMonth();

                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();

                string strSecDep = "INSERT INTO PAY_SLIPS_EARNINGS (EMP_NO,EAR_ID,PAY_VALUE,PAY_YEAR,PAY_MONTH) VALUES ('" + txt_EmpNo.Text + "','" + "SDTOT" + "','" + lblTotSecDep.Text + "','" + intYear + "','" + intMonth + "')";
                SqlCommand objCmd = new SqlCommand(strSecDep, _conn);
                objCmd.ExecuteNonQuery();
                objCmd.Dispose();

                string strSECDEPUPDATE = "UPDATE EMPLOYEES SET TOT_SECDEP = '0', MODIFIED_BY = '" + GetUser + "', MODIFIED_DATE = '" + DateTime.Now + "', USER_ACTION = 'PaidSecDep' WHERE EMP_NO = '" + txt_EmpNo.Text + "'";
                SqlCommand objSECDEPUPDATE = new SqlCommand(strSECDEPUPDATE, _conn);
                objSECDEPUPDATE.ExecuteNonQuery();
                objSECDEPUPDATE.Dispose();

                MessageBox.Show("Total of " + lblTotSecDep.Text + " Security Deposits has been added to the Employee Salaries","Security Deposit Payback");

                lblTotSecDep.Text = "0";
                _conn.Close();
            }   
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (intSTATUS == 2)
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "UPDATE EMPLOYEES SET STATUS = '1', MODIFIED_BY = '" + GetUser + "', MODIFIED_DATE = '" + DateTime.Now + "', USER_ACTION = 'Approve' WHERE (EMP_NO = '" + txt_EmpNo.Text.Trim() + "')";
                //cmdsql.CommandText =   "UPDATE EMPLOYEES SET TITLE = '" + txt_Title.Text + "', INITIALS = '" + txt_Initials.Text + "', NAME = '" + txt_SurName.Text + "', FULL_NAME = '" + txt_FullName.Text + "', ADDRESS = '" + txt_Address.Text + "', RESIDENT_NO = '" + txt_Resident.Text + "', MOBILE_NO = '" + txt_Mobile.Text + "', DATE_OF_BIRTH = Convert(DateTime,'" + dt_Birth.Text.ToString().Trim() + "'), SEX = '" + txt_Sex.Text + "', CIVIL_STATUS = '" + txt_Civil.Text + "', BANK_CODE = '" + txt_BankCode.Text + "', BANK = '" + cmb_Bank.Text + "', BRANCH_CODE = '" + txt_BranchCode.Text + "', BRANCH = '" + cmb_Branch.Text + "', BASIC_SALARY = Convert(Money,'" + txt_Basic.Text + "'), FIXED_EARNINGS = Convert(Money,'" + txt_FxEarn.Text + "'), FIXED_DEDUCTIONS = Convert(Money,'" + txt_FxDeduct.Text + "'), DEPARTMENT = '" + txt_Department.Text + "', DESIGNATION = '" + txt_Designation.Text + "', DATE_OF_JOINED = Convert(DateTime,'" + dt_Joined.Text.ToString().Trim() + "'), PAYMENT_MODE = '" + txt_PayMode.Text + "', ACC_NO = '" + txt_AccNo.Text + "', EMP_RATE = " + txt_PayeeTax.Text + ", FILE_NO = '" + txt_FileNo.Text + "' WHERE (EMP_NO = '" + txt_EmpNo.Text + "')";
                SqlDataReader dreader = cmdsql.ExecuteReader();
                MessageBox.Show("Approval of Employee Information are Completed", "Approve Employee");
                _conn.Close();
                lblApprove.Text = "Employee is Approved";
            }
            else
                MessageBox.Show("Employee is Already Approved", "Approve Employee");

           
                

        }

        private void UserLevels()
        {
            if (GetUserLevel == 1)
            {
                grbApprove.Enabled = false;
            }
            else if (GetUserLevel == 2)
            {
                grbApprove.Enabled = false;
                grbModify.Enabled = false;
            }
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

        private void txt_Department_TextChanged(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Title_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Initials.Focus();
            }
        }

        private void txt_Initials_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_SurName.Focus();
            }
        }

        private void txt_SurName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_FullName.Text = txt_Initials.Text + " " +  txt_SurName.Text;
                txt_FullName.Focus();
            }
        }

        private void txt_FullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Address.Focus();
            }
        }

        private void txt_Address_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Resident.Focus();
            }
        }

        private void txt_Resident_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Mobile.Focus();
            }
        }

        private void txt_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                dt_Birth.Focus();
            }
        }

        private void dt_Birth_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_NICNo.Focus();
            }
        }

        private void txt_NICNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Sex.Focus();
            }
        }

        private void txt_Sex_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Civil.Focus();
            }
        }

        private void txt_Civil_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Department.Focus();
            }
        }

        private void txt_Department_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Designation.Focus();
            }
        }

        private void txt_Designation_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                rb_Exe.Focus();
            }
        }

        private void rb_Exe_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                rb_Off.Focus();
            }
        }

        private void rb_Off_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                rb_Ten.Focus();
            }
        }

        private void rb_Ten_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_EmpStatus.Focus();
            }
        }

        private void txt_EmpStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_PayeeTax.Focus();
            }
        }

        private void txt_PayeeTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                dt_Joined.Focus();
            }
        }

        private void dt_Joined_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_FileNo.Focus();
            }
        }

        private void txt_FileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Grade.Focus();
            }
        }

        private void txt_Grade_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Basic.Focus();
            }
        }

        private void txt_Basic_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_FxEarn.Focus();
            }
        }

        private void txt_FxEarn_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_FxDeduct.Focus();
            }
        }

        private void txt_FxDeduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmb_Bank.Focus();
            }
        }

        private void cmb_Bank_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmb_Branch.Focus();
            }
        }

        private void cmb_Branch_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_AccNo.Focus();
            }
        }

        private void txt_AccNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btn_Add.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_Title.Focus();
            timer1.Enabled = false;
        }

        private void txt_Department_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Designation.Focus();
            }
        }

        private void txt_Designation_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                rb_Exe.Focus();
            }
        }

        private void rb_Exe_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                rb_Off.Focus();
            }
        }

        private void rb_Off_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                rb_Ten.Focus();
            }
        }

        private void rb_Ten_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_EmpStatus.Focus();
            }
        }

        private void txt_EmpStatus_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_PayeeTax.Focus();
            }
        }

        private void txt_PayeeTax_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                dt_Joined.Focus();
            }
        }

        private void dt_Joined_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_FileNo.Focus();
            }
        }

        private void txt_FileNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Grade.Focus();
            }
        }

        private void txt_Grade_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Basic.Focus();
            }
        }

        private void txt_Basic_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_FxEarn.Focus();
            }
        }

        private void txt_FxEarn_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_FxDeduct.Focus();
            }
        }

        private void txt_FxDeduct_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmb_Bank.Focus();
            }
        }

        private void cmb_Bank_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmb_Branch.Focus();
            }
        }

        private void cmb_Branch_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_AccNo.Focus();
            }
        }

        private void txt_AccNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btn_Add.Focus();
            }
        }

        private void cmb_Bank_SelectedValueChanged_1(object sender, EventArgs e)
        {
            cmb_Branch.Items.Clear();
            SelectBankCode();
            SelectBranch();
        }

        private void cmb_Branch_SelectedValueChanged_1(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlCommand cmdBankMain = new SqlCommand("SELECT BRANCH_CODE FROM BRANCH_DETAILS WHERE BRANCH = '" + cmb_Branch.Text.Trim() + "'", _conn);
            SqlDataReader drBankMain = cmdBankMain.ExecuteReader();
            while (drBankMain.Read())
            {
                txt_BranchCode.Text = drBankMain["BRANCH_CODE"].ToString();
            }
            drBankMain.Close();
            _conn.Close();
        }



       
    }
}