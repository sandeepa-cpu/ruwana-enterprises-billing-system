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
    public partial class frm_Deductions : Form
    {
        public frm_Deductions()
        {
            InitializeComponent();
        }

        private SqlConnection _conn;

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_ID.Text == "" || txt_Des.Text == "" || txt_Order.Text == "")
            {
                MessageBox.Show("Please Enter the Deduction Code, Description, Order No. and Proceed");
                txt_ID.Focus();
            }

            else
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _conn;
                cmdsql.CommandText = "INSERT INTO DEDUCTIONS (DED_ID, DESCRIPTION, SLIP_ORDER,STATUS) VALUES ('" + txt_ID.Text + "', '" + txt_Des.Text + "', " + txt_Order.Text + ",1)";
                cmdsql.ExecuteNonQuery();
                MessageBox.Show("Deduction Successfully Added");
            }
            _conn.Close();

            ShowDetails();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlDataAdapter drDedct = new SqlDataAdapter("SELECT DED_ID, DESCRIPTION, SLIP_ORDER FROM DEDUCTIONS WHERE (STATUS = 1) ORDER BY CONVERT(INT,SLIP_ORDER)", _conn);
            SqlCommandBuilder cmdDedct = new SqlCommandBuilder(drDedct);
            DataSet dsDedct = new DataSet();

            drDedct.Fill(dsDedct, "DEDUCTIONS");

            Grid_A.DataSource = dsDedct;
            Grid_A.DataMember = "DEDUCTIONS";

            _conn.Close();

            FillGrid();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 88;
            Grid_A.Columns[0].HeaderText = "DEDUCTION";
            Grid_A.Columns[1].Width = 188;
            Grid_A.Columns[1].HeaderText = "DESCRIPTION";
            Grid_A.Columns[2].Width = 55;
            Grid_A.Columns[2].HeaderText = "SLIP_ORDER";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;
        }

        private void frm_Deductions_Load(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM DEDUCTIONS WHERE STATUS = 1 ORDER BY CONVERT(INT,SLIP_ORDER)", _conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "DEDUCTIONS");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["DEDUCTIONS"].Rows)
            {
                thisDataset.Tables["DEDUCTIONS"].Rows[count]["DED_ID"] = Grid_A.Rows[count].Cells[0].Value.ToString();
                thisDataset.Tables["DEDUCTIONS"].Rows[count]["DESCRIPTION"] = Grid_A.Rows[count].Cells[1].Value.ToString();
                thisDataset.Tables["DEDUCTIONS"].Rows[count]["SLIP_ORDER"] = Grid_A.Rows[count].Cells[2].Value.ToString();

                thisAdapter.Update(thisDataset, "DEDUCTIONS");
                count++;
            }
            _conn.Close();
            MessageBox.Show("Deduction Descriptions are successfully Updated", "Deduction Details");
        }
    }
}