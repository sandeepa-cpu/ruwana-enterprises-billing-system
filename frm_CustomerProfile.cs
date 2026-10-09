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
    public partial class frm_CustomerProfile : Form
    {
        private SqlConnection _Conn;

        public frm_CustomerProfile()
        {
            InitializeComponent();
        }
        public String CustomerNO;

        private void ShowDetailsModel()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT TITLE, NAME, ADDRESS, RESIDENT_NO, MOBILE_NO, FILE_NO FROM CUSTOMER_INFO ORDER BY NAME", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "CUSTOMER_INFO");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "CUSTOMER_INFO";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 36;
            Grid_A.Columns[1].Width = 250;
            Grid_A.Columns[0].HeaderText = "";
            Grid_A.Columns[1].HeaderText = "CUSTOMER";
            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].ReadOnly = false;
            Grid_A.Columns[1].ReadOnly = false;
            Grid_A.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
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
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.None;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "INSERT INTO CUSTOMER_INFO (TITLE, NAME, ADDRESS, RESIDENT_NO, MOBILE_NO, FILE_NO, USER_ACTION) VALUES ('" + txt_Title.Text + "', '" + txt_Initials.Text + "', '" + txt_Address.Text + "', '" + txt_Resident.Text + "', '" + txt_Mobile.Text + "', '" + txt_FileNo.Text + "', '1')";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("New Customer Successfully Added");
                    ShowDetailsModel();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Customer Information");
                return;
            }
            _Conn.Close();
            txt_Initials.Text = "";
            txt_AccNo.Text = "";
            txt_Address.Text = "";
            txt_BankCode.Text = "";
            txt_BranchCode.Text = "";
            txt_FileNo.Text = "";
            txt_Mobile.Text = "";
            txt_Resident.Text = "";
            txt_Title.Text = "";


            frm_JobCreation child = new frm_JobCreation(); //create new isntance of form
            child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            child.Hide();
            child.Show(); //show child
            this.Close();

            timer1.Enabled = false;
            //txt_Title.DroppedDown = false;
            //frm_JobCreation frmGen = new frm_JobCreation();
            //frmGen.VVehicleNO = txtNo.Text;
            
        }

        void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            this.Hide();
        }

        private void frm_CustomerProfile_Load(object sender, EventArgs e)
        {
            FormActions.Standardize(this);
            ShowDetailsModel();
            timer1.Enabled = true;
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.DatabaseConnection obyConn;

                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();

                SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT TITLE, NAME, VEHICLE_NO, ADDRESS, RESIDENT_NO, MOBILE_NO, FILE_NO FROM CUSTOMER_INFO ORDER BY NAME", _Conn);
                SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
                DataSet thisDataset = new DataSet();

                thisAdapter.Fill(thisDataset, "CUSTOMER_INFO");

                int count = 0;

                foreach (DataRow dr in thisDataset.Tables["CUSTOMER_INFO"].Rows)
                {
                    thisDataset.Tables["CUSTOMER_INFO"].Rows[count]["NAME"] = Grid_A.Rows[count].Cells[1].Value.ToString();
                    thisDataset.Tables["CUSTOMER_INFO"].Rows[count]["VEHICLE_NO"] = Grid_A.Rows[count].Cells[2].Value.ToString();
                    thisDataset.Tables["CUSTOMER_INFO"].Rows[count]["ADDRESS"] = Grid_A.Rows[count].Cells[3].Value.ToString();
                    thisDataset.Tables["CUSTOMER_INFO"].Rows[count]["RESIDENT_NO"] = Grid_A.Rows[count].Cells[4].Value.ToString();
                    thisDataset.Tables["CUSTOMER_INFO"].Rows[count]["MOBILE_NO"] = Grid_A.Rows[count].Cells[5].Value.ToString();
                    thisDataset.Tables["CUSTOMER_INFO"].Rows[count]["FILE_NO"] = Grid_A.Rows[count].Cells[6].Value.ToString();
                    thisAdapter.Update(thisDataset, "CUSTOMER_INFO");
                    count++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error.... Similer Record Found. Verify Your Updated Entry", "Customer Information");
                return;
            }
            _Conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txt_Resident_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Title.Focus();
            }
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
                txt_FileNo.Focus();
            }
        }

        private void txt_FileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btn_Add.Focus();
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            txt_Title.Focus();
            txt_Title.DroppedDown = true;
            timer1.Enabled = false;
        }
    }
}