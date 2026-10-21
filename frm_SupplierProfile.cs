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
    public partial class frm_SupplierProfile : Form
    {
        private SqlConnection _Conn;

        public frm_SupplierProfile()
        {
            InitializeComponent();
        }

          

        private void ShowDetailsModel()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT TITLE, NAME FROM SUPPLIER_INFO ORDER BY NAME", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "SUPPLIER_INFO");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "SUPPLIER_INFO";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 55;
            Grid_A.Columns[1].Width = 482;
            Grid_A.Columns[0].HeaderText = "";
            Grid_A.Columns[1].HeaderText = "SUPPLIER";
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
                    cmdsql.CommandText = "INSERT INTO SUPPLIER_INFO (TITLE, NAME, ADDRESS, T_NO, F_NO, EMAIL, FILE_NO, USER_ACTION) VALUES ('" + txt_Title.Text + "', '" + txt_Initials.Text + "', '" + txt_Address.Text + "', '" + txt_Resident.Text + "', '" + txt_Mobile.Text + "', '" + txtEmail.Text + "', '" + txt_FileNo.Text + "', '1')";
                    cmdsql.ExecuteNonQuery();
                    AuditLog.Write("EDIT", "frm_SupplierProfile", txt_Initials.Text);
                    MessageBox.Show("New Supplier Successfully Added");
                    ShowDetailsModel();
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_SupplierProfile", ex);
                MessageBox.Show(ex.Message, "Supplier Information");
            }
            finally
            {
                if (_Conn != null)
                {
                    _Conn.Dispose();
                    _Conn = null;
                }
            }
            txt_Initials.Text = "";
            txt_AccNo.Text = "";
            txt_Address.Text = "";
            txt_BankCode.Text = "";
            txt_BranchCode.Text = "";
            txt_FileNo.Text = "";
            txt_Mobile.Text = "";
            txt_Resident.Text = "";
            txt_Title.Text = "";

            ////////frm_ReceiveGoods child = new frm_ReceiveGoods(); //create new isntance of form
            ////////child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            ////////child.Hide();
            ////////child.Show(); //show child
            ////////this.Hide();

            txt_Title.Focus();
        }

        void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
        }

        private void frm_SupplierProfile_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            FormActions.Standardize(this);
            ShowDetailsModel();
            txt_Title.Focus();
            timer1.Enabled = true;
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frm_MainMenu frm_Main = new frm_MainMenu();
            frm_Main.lblTime.Text = "";
            //drPwd["USER_NAME"].ToString();
            //frm_Main.lblUserLevel.Text = drPwd["ACC_LEVEL"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Address_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            txt_Title.Focus();
            timer1.Enabled = false;
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
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btn_Add.Focus();
            }
        }

    



         

    }
}