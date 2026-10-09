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
    public partial class frm_JobSubCat : Form
    {
        public frm_JobSubCat()
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
                cmdsql1.CommandText = "INSERT INTO SUB_CATEGORY (MAIN_CAT, SUB_CAT, AMOUNT) VALUES ('" + lblType.Text + "', '" + txtType.Text + "', '" + txtAmount.Text + "')";
                cmdsql1.ExecuteNonQuery();
                MessageBox.Show("Sub Category Added Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Already Added the Sub Category");
            }
            
            ShowDetails();
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT MAIN_CATEGORY.MAIN_CAT, SUB_CATEGORY.SUB_CAT, SUB_CATEGORY.AMOUNT FROM SUB_CATEGORY INNER JOIN MAIN_CATEGORY ON SUB_CATEGORY.MAIN_CAT = MAIN_CATEGORY.SEQ_NO", _Conn);// WHERE MAIN_CATEGORY.MAIN_CAT = '"+ cmbType.Text +"'", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "SUB_CATEGORY");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "SUB_CATEGORY";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 350;
            Grid_A.Columns[0].HeaderText = "MAIN_CATEGORY";
            Grid_A.Columns[1].Width = 350;
            Grid_A.Columns[1].HeaderText = "SUB_CATEGORY";
            Grid_A.Columns[2].Width = 200;
            Grid_A.Columns[2].HeaderText = "AMOUNT";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;

            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Maroon;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Maroon;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = false;
            Grid_A.Columns[2].ReadOnly = false;

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
            Grid_A.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void frm_JobType_Load(object sender, EventArgs e)
        {
            ADD_MAIN();
            ShowDetails();
        }

        private void ADD_MAIN()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT MAIN_CAT FROM MAIN_CATEGORY";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbType.Items.Add(dreader["MAIN_CAT"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQ_NO FROM MAIN_CATEGORY WHERE MAIN_CAT = '"+ cmbType.Text.Trim() +"'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblType.Text = dreader["SEQ_NO"].ToString();
                return;
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}