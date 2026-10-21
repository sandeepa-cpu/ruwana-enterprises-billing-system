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
    public partial class frm_InsuranceCompany : Form
    {
        public frm_InsuranceCompany()
        {
            InitializeComponent();
        }

        private SqlConnection _Conn;

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql1 = new SqlCommand();
            cmdsql1.Connection = _Conn;
            cmdsql1.CommandText = "INSERT INTO INSURANCE_COMPANY (NAME, ADDRESS, CONTACT1, CONTACT2, FILE_NO) VALUES ('" + txtCompany.Text + "', '" + txtAddress.Text + "','" + txtCon1.Text + "', '" + txtCon2.Text + "','" + txtFile.Text + "')";
            cmdsql1.ExecuteNonQuery();

            MessageBox.Show("Insurance Company Added Successfully");
            ShowDetails();
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT NAME, ADDRESS, CONTACT1, CONTACT2, FILE_NO FROM INSURANCE_COMPANY", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "INSURANCE_COMPANY");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "INSURANCE_COMPANY";

            _Conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 220;
            Grid_A.Columns[0].HeaderText = "NAME";
            Grid_A.Columns[1].Width = 250;
            Grid_A.Columns[1].HeaderText = "ADDRESS";
            Grid_A.Columns[2].Width = 120;
            Grid_A.Columns[2].HeaderText = "CONTACT NO";
            Grid_A.Columns[3].Width = 120;
            Grid_A.Columns[3].HeaderText = "CONTACT NO";
            Grid_A.Columns[4].Width = 80;
            Grid_A.Columns[4].HeaderText = "FILE NO";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[3].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[1].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;
            //Grid_A.Columns[3].ReadOnly = true;
            Grid_A.Columns[4].ReadOnly = true;

            Grid_A.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

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
            Grid_A.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_A.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Grid_A.Columns[0].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();

            //SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT ISSUED_ITEMS.PARTNO, ISSUED_ITEMS.CUSTOMER, ISSUED_ITEMS.INV_NO, ISSUED_ITEMS.QTY, ISSUED_ITEMS.PRICE, ISSUED_ITEMS.TOT, ISSUED_ITEMS.S_NO, ISSUED_ITEMS.STATUS, ISSUED_ITEMS.DEL, ISSUED_ITEMS.SEQ_NO FROM ISSUED_ITEMS WHERE (ISSUED_ITEMS.PARTNO = '" + cmbPart.Text + "') AND (ISSUED_ITEMS.PRO_DATE = '" + lbl_Date.Text + "') ORDER BY ISSUED_ITEMS.INV_NO, ISSUED_ITEMS.SEQ_NO DESC", _Conn);
            //SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            //DataSet thisDataset = new DataSet();

            //thisAdapter.Fill(thisDataset, "ISSUED_ITEMS");

            //int count = 0;

            //foreach (DataRow dr in thisDataset.Tables["ISSUED_ITEMS"].Rows)
            //{
            //    thisDataset.Tables["ISSUED_ITEMS"].Rows[count]["INV_NO"] = Grid_A.Rows[count].Cells[2].Value.ToString();
            //    thisDataset.Tables["ISSUED_ITEMS"].Rows[count]["S_NO"] = Grid_A.Rows[count].Cells[6].Value.ToString();
            //    thisAdapter.Update(thisDataset, "ISSUED_ITEMS");
            //    count++;
            //}
            //_Conn.Close();
            //MessageBox.Show("Successfully Updated", "Update Info.");
            //ShowDetails();
        }

        private void frm_InsuranceCompany_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            ShowDetails();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}