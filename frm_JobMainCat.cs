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
    public partial class frm_JobMainCat : Form
    {
        public frm_JobMainCat()
        {
            InitializeComponent();
        }
        private SqlConnection _Conn;

        CommonProfiles getComProfiles = new CommonProfiles();
        private string ProDate;

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            try
            {
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _Conn;
                cmdsql1.CommandText = "INSERT INTO MAIN_CATEGORY (MAIN_CAT) VALUES ('" + txtType.Text + "')";
                cmdsql1.ExecuteNonQuery();
                MessageBox.Show("Main Category Added Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Already Entered the Main Category");
                return;
            }
            
            ShowDetails();
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT MAIN_CAT FROM MAIN_CATEGORY", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "MAIN_CATEGORY");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "MAIN_CATEGORY";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 500;
            Grid_A.Columns[0].HeaderText = "MAIN_CATEGORY";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;

            Grid_A.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

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

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void frm_JobType_Load(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}