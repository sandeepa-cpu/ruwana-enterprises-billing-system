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
    public partial class frm_JobType : Form
    {
        public frm_JobType()
        {
            InitializeComponent();
        }
        private SqlConnection _Conn;

        CommonProfiles getComProfiles = new CommonProfiles();
        private string ProDate;

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;
            cmdsql1.CommandText = "INSERT INTO JOB_TYPE (JOB_TYPE, AMOUNT) VALUES ('" + txtType.Text + "', '" + txtAmount.Text + "')";
            cmdsql1.ExecuteNonQuery();

            MessageBox.Show("Insurance Company Added Successfully");
            ShowDetails();

        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT JOB_TYPE, AMOUNT FROM JOB_TYPE", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "JOB_TYPE");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "JOB_TYPE";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 350;
            Grid_A.Columns[0].HeaderText = "JOB_TYPE";
            Grid_A.Columns[1].Width = 200;
            Grid_A.Columns[1].HeaderText = "AMOUNT";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;

            Grid_A.Columns[0].ReadOnly = true;
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
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtType_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtAmount.Focus();
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                button2.Focus();
            }
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtType.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {

        }
    }
}