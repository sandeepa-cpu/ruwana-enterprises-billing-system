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
    public partial class frm_Earnings : Form
    {
        public frm_Earnings()
        {
            InitializeComponent();
        }

        public SqlConnection _conn;
        
        private void btn_Save_Click(object sender, EventArgs e)
        {
                if (txt_ID.Text == "" || txt_Des.Text == "" || txt_Order.Text == "")
                {
                    MessageBox.Show("Please Enter the Earning Code, Description, Order No. and Proceed");
                    txt_ID.Focus();
                }

                else
                {
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _conn;
                    cmdsql.CommandText = "INSERT INTO EARNINGS (EAR_ID, DESCRIPTION, SLIP_ORDER,STATUS)VALUES ('"+ txt_ID.Text +"', '"+ txt_Des.Text +"', "+ txt_Order.Text +",1)";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("Earning Successfully Added");
                }
                _conn.Close();
 
                ShowDetails();
            }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Earnings_Load(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlDataAdapter drEarn = new SqlDataAdapter("SELECT EAR_ID, DESCRIPTION, SLIP_ORDER FROM EARNINGS WHERE (STATUS = 1) ORDER BY CONVERT(INT,SLIP_ORDER)", _conn);
            SqlCommandBuilder cmdEarn = new SqlCommandBuilder(drEarn);
            DataSet dsEarn = new DataSet();

            drEarn.Fill(dsEarn, "EARNINGS");

            Grid_A.DataSource = dsEarn;
            Grid_A.DataMember = "EARNINGS";

            _conn.Close();

            FillGrid();
        }
        
        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 88;
            Grid_A.Columns[0].HeaderText = "EARNING";
            Grid_A.Columns[1].Width = 188;
            Grid_A.Columns[1].HeaderText = "DESCRIPTION";
            Grid_A.Columns[2].Width = 55;
            Grid_A.Columns[2].HeaderText = "SLIP ORDER";

            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            Grid_A.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            Grid_A.Columns[0].ReadOnly = true;
            Grid_A.Columns[2].ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM EARNINGS WHERE STATUS = 1 ORDER BY CONVERT(INT,SLIP_ORDER)", _conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "EARNINGS");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["EARNINGS"].Rows)
            {
                thisDataset.Tables["EARNINGS"].Rows[count]["EAR_ID"] = Grid_A.Rows[count].Cells[0].Value.ToString();
                thisDataset.Tables["EARNINGS"].Rows[count]["DESCRIPTION"] = Grid_A.Rows[count].Cells[1].Value.ToString();
                thisDataset.Tables["EARNINGS"].Rows[count]["SLIP_ORDER"] = Grid_A.Rows[count].Cells[2].Value.ToString();

                thisAdapter.Update(thisDataset, "EARNINGS");
                count++;
            }
            _conn.Close();
            MessageBox.Show("Earning Descriptions are successfully Updated", "Earning Details");
        }
    }
}