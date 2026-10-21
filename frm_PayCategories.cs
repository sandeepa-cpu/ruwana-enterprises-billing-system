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
    public partial class frm_PayCategories : Form
    {
        public frm_PayCategories()
        {
            InitializeComponent();
        }
        private SqlConnection _Conn;

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_PAY_CAT_ID.Text == "" || txt_Desc.Text == "" || txt_Earn_ID.Text == "")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Pay Category Information");
                    return;
                }
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "INSERT INTO PAY_CATEGORIES (PAY_CAT_ID, DESCRIPTION, EAR_ID) VALUES ('" + txt_PAY_CAT_ID.Text + "','" + txt_Desc.Text + "','" + txt_Earn_ID.Text + "')";
                cmdsql.ExecuteNonQuery();
                MessageBox.Show("Pay Category Successfully Added");
                txt_Earn_ID.Clear();
                txt_Desc.Clear();
                txt_PAY_CAT_ID.Clear();
                cmb_Find_Earn.ResetText();
                _Conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Loan Information");
                return;
            }
            ShowDetails();
        }

        private void frm_PayCategories_Load(object sender, EventArgs e)
        {
            UiTheme.StyleForm(this);
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlCommand cmdLoanMain = new SqlCommand("SELECT * FROM EARNINGS WHERE (STATUS = 1)", _Conn);
            SqlDataReader drLoanMain = cmdLoanMain.ExecuteReader();
            while (drLoanMain.Read())
            {
                cmb_Find_Earn.Items.Add(drLoanMain["DESCRIPTION"].ToString()); // + " - " + drTenMain["NAME"].ToString());
            }

            drLoanMain.Close();
            _Conn.Close();

            ShowDetails();
        }

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drPayCat = new SqlDataAdapter("SELECT * FROM PAY_CATEGORIES", _Conn);
            SqlCommandBuilder cmdPayCat = new SqlCommandBuilder(drPayCat);
            DataSet dsPayCat = new DataSet();

            drPayCat.Fill(dsPayCat, "PAY_CATEGORIES");

            Grid_A.DataSource = dsPayCat;
            Grid_A.DataMember = "PAY_CATEGORIES";

            _Conn.Close();

            FillGrid();
        }

        private void cmb_Find_Deduct_SelectedValueChanged(object sender, EventArgs e)
        {
            txt_Earn_ID.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT * FROM EARNINGS WHERE (DESCRIPTION= '" + cmb_Find_Earn.Text + "')";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txt_Earn_ID.Text = dreader["EAR_ID"].ToString();
            }

            cmdsql.Dispose();
            dreader.Dispose();
            btn_Add.Focus();
            _Conn.Close();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillGrid()
        {
            Grid_A.Columns[0].Width = 80;
            Grid_A.Columns[0].HeaderText = "CATEGORY";
            Grid_A.Columns[1].Width = 185;
            Grid_A.Columns[1].HeaderText = "DESCRIPTION";
            Grid_A.Columns[2].Width = 90;
            Grid_A.Columns[2].HeaderText = "MODE";

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
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM PAY_CATEGORIES", _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "PAY_CATEGORIES");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["PAY_CATEGORIES"].Rows)
            {
                thisDataset.Tables["PAY_CATEGORIES"].Rows[count]["DESCRIPTION"] = Grid_A.Rows[count].Cells[1].Value.ToString();

                thisAdapter.Update(thisDataset, "PAY_CATEGORIES");
                count++;
            }
            _Conn.Close();
            MessageBox.Show("Pay Category Descriptions are successfully Updated", "Pay Category Details");
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}