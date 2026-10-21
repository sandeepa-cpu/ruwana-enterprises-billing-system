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
    public partial class frm_General : Form
    {
        private SqlConnection _Conn;

        public frm_General()
        {
            InitializeComponent();
        }

        private void ShowDetailsCat()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT CATEGORY FROM CATEGORY ORDER BY CATEGORY", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "CATEGORY");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "CATEGORY";

            _Conn.Close();

            FillGrid_A();
        }

        private void ShowDetailsMake()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT CATEGORY, MAKE FROM MAKE ORDER BY CATEGORY", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "MAKE");

            Grid_B.DataSource = dsLoan;
            Grid_B.DataMember = "MAKE";

            _Conn.Close();

            FillGrid_B();
        }

        private void ShowDetailsModel()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT CATEGORY, MAKE, SUBCAT FROM SUBCAT ORDER BY MAKE", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "SUBCAT");

            Grid_C.DataSource = dsLoan;
            Grid_C.DataMember = "SUBCAT";

            _Conn.Close();

            FillGrid_C();
        }

        private void FillGrid_A()
        {
            Grid_A.Columns[0].Width = 250;
            Grid_A.Columns[0].HeaderText = "CATEGORIES";
            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].ReadOnly = false;
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
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }
        
        private void FillGrid_B()
        {
            Grid_B.Columns[0].Width = 250;
            Grid_B.Columns[0].HeaderText = "MAKES";
            Grid_B.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[0].ReadOnly = false;
            Grid_B.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_B.AutoGenerateColumns = false;
            Grid_B.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            Grid_B.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Grid_B.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
            Grid_B.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            Grid_B.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_B.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            Grid_B.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_B.MultiSelect = false;
            Grid_B.RowHeadersVisible = true;
            Grid_B.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_B.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_B.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void FillGrid_C()
        {
            Grid_C.Columns[0].Width = 100;
            Grid_C.Columns[1].Width = 150;
            Grid_C.Columns[0].HeaderText = "MAKE";
            Grid_C.Columns[1].HeaderText = "MODELS";
            Grid_C.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_C.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_C.Columns[0].ReadOnly = true;
            Grid_C.Columns[1].ReadOnly = false;
            Grid_C.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_C.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
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
            Grid_C.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_C.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void btn_Save1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCat.Text == "" & txtMake.Text == "" & txtModel.Text == "")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Required Info.");
                    return;
                }
                else 
                if (txtCat.Text != "")
                {
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "INSERT INTO CATEGORY (CATEGORY) VALUES ('" + txtCat.Text + "')";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("New Category Successfully Added");
                    ShowDetailsCat();
                }
                if (txtMake.Text != "")
                {
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "INSERT INTO MAKE (MAKE) VALUES ('" + txtMake.Text + "')";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("New Brand / Model Successfully Added");
                    ShowDetailsMake();
                }
                if (txtModel.Text != "")
                {
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "INSERT INTO MODEL (MAKE, MODEL) VALUES ('" + cmb_MAKE.Text + "', '" + txtModel.Text + "')";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("New Model Successfully Added");
                    ShowDetailsModel();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Bank Information");
                return;
            }
            _Conn.Close();
            txtCat.Text= "";
            txtMake.Text = "";
            txtModel.Text = "";
            cmb_MAKE.Text = "";
            LoadMakes();
            LoadCats();

        }

        private void frm_General_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            ShowDetailsMake();
            ShowDetailsModel();
            ShowDetailsCat();
            LoadMakes();
            LoadCats();
            LoadCats1();

            //txtCat.Text = "-";
            //txtMake.Text = "-";
            //txtModel.Text = "-";
        }

        private void LoadMakes()
        {
            cmb_MAKE.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT MAKE FROM MAKE";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmb_MAKE.Items.Add(dreader["MAKE"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void LoadCats()
        {
            cmbCat.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT CATEGORY FROM CATEGORY";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbCat.Items.Add(dreader["CATEGORY"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void LoadCats1()
        {
            cmbCat1.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT CATEGORY FROM CATEGORY";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbCat1.Items.Add(dreader["CATEGORY"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void btn_Up1_Click(object sender, EventArgs e)
        {
            Update_A();
            Update_B();
            Update_C();

            LoadMakes();
            MessageBox.Show("All the Records are successfully Updated", "Update Details");
        }

        private void Update_A()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM CATEGORY ORDER BY CATEGORY", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "CATEGORY");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["CATEGORY"].Rows)
            {
                thisDataset.Tables["CATEGORY"].Rows[count]["CATEGORY"] = Grid_A.Rows[count].Cells[0].Value.ToString();
                thisAdapter.Update(thisDataset, "CATEGORY");
                count++;
            }
            _Conn.Close();
        }

        private void Update_B()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM MAKE ORDER BY MAKE", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "MAKE");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["MAKE"].Rows)
            {
                thisDataset.Tables["MAKE"].Rows[count]["MAKE"] = Grid_B.Rows[count].Cells[0].Value.ToString();
                thisAdapter.Update(thisDataset, "MAKE");
                count++;
            }
            _Conn.Close();
        }

        private void Update_C()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM MODEL ORDER BY MAKE", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "MODEL");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["MODEL"].Rows)
            {
                thisDataset.Tables["MODEL"].Rows[count]["MODEL"] = Grid_C.Rows[count].Cells[1].Value.ToString();
                thisAdapter.Update(thisDataset, "MODEL");
                count++;
            }
            _Conn.Close();
            
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_SPNo_Leave(object sender, EventArgs e)
        {
            txtMake.Focus();
        }

        private void txtCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 27)
            {
                btn_Quit.Focus();
            }
        }

    }
}