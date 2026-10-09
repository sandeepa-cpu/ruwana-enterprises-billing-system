using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;

namespace Billing_Inventory_Management_System
{
    public partial class frm_InventoryMaster : Form
    {
        private SqlConnection _Conn;
        string SHOW = "";
        int SEQ = 0;
        decimal TOT_PURCHASE = 0;
        decimal PURCHASE = 0;
        decimal OPBCOSTS = 0;
        decimal OPB_PER = 0;
        string A = "";
        decimal QTY = 0;
        decimal SELLP = 0;
        decimal IU, TOTISSCOST;
        int count = 0;

        public frm_InventoryMaster()
        {
            InitializeComponent();
        }

        private void LoadLOC()
        {
            txtLocate.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT LOC FROM LOCATION";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txtLocate.Items.Add(dreader["LOC"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void ShowDetailsMake()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT CATEGORY, MAKE FROM MAKE WHERE CATEGORY = '"+ cmbC.Text +"' ORDER BY CATEGORY", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "MAKE");

            Grid_B.DataSource = dsLoan;
            Grid_B.DataMember = "MAKE";

            _Conn.Close();

            FillGrid_B();
        }

        private void ShowDetailsSub()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT CATEGORY, MAKE, SUB_CAT FROM SUB_CATEGORY WHERE CATEGORY = '" + cmbC1.Text + "' AND MAKE = '" + cmbM.Text + "' ORDER BY CATEGORY", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "SUB_CATEGORY");

            Grid_C.DataSource = dsLoan;
            Grid_C.DataMember = "SUB_CATEGORY";

            _Conn.Close();

            FillGrid_C();
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

            Grid_D.DataSource = dsLoan;
            Grid_D.DataMember = "CATEGORY";

            _Conn.Close();

            FillGrid_D();
        } 

        private void button5_Click(object sender, EventArgs e)
        {
            if (tbUOM.Visible == true)
                tbUOM.Visible = false;
            else
            {
                tbMake.Visible = false;
                tbUOM.Visible = true;
                tbLOC.Visible = false;
                txtUOM.Focus();
            }
        }

        private void ShowDetailsPart()
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

        private void LoadCats()
        {
            cmbCat.Items.Clear();
            cmbC.Items.Clear();
            cmbC1.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT CATEGORY, TOT_COST, PER_PAGE FROM CATEGORY";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbCat.Items.Add(dreader["CATEGORY"].ToString());
                cmbC.Items.Add(dreader["CATEGORY"].ToString());
                cmbC1.Items.Add(dreader["CATEGORY"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void frm_InventoryMaster_Load(object sender, EventArgs e)
        {
            tbCatInfo.Enabled = true;
            //ShowDetails();
            LoadCats();
            ShowDetailsCat();
            ShowDetailsMake();
            ShowDetailsPart();
            LoadUOM();
            LoadLOC();
            FormActions.Standardize(this);
            SystemDate();
            SHOW = "SELECT SEQNO, PARTNO, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO, DEL FROM MASTER ORDER BY PARTNO DESC";
            ShowDetails();
            timer2.Enabled = true;
        }

        private void SystemDate()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT PRO_DATE FROM PRO_DATE";
            SqlDataReader dreader = cmdsql.ExecuteReader();

            while (dreader.Read())
            {
                lbl_ProDate.Text = dreader["PRO_DATE"].ToString();
                //DateTime dt = new DateTime(DateTime.Parse(drEmp["LOAN_DATE"].ToString()));
                //String DT = String.Format("{0:MM/dd/yyyy}", DTM);
                //lblSD.Text = String.Format("{0:yyyy-MM-dd}", DTM); 
            }

            dreader.Close();
            _Conn.Dispose();
        }

        private void btnUOM_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "INSERT INTO UOM (UOM) VALUES ('" + txtUOM.Text + "')";
            cmdsql.ExecuteNonQuery();
            MessageBox.Show("New Unit of Measure Successfully Added, Proceed your Entry.....");
            LoadUOM();
            tbUOM.Visible = false;
        }

        private void LoadUOM()
        {
            txt_UOM.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT UOM FROM UOM";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txt_UOM.Items.Add(dreader["UOM"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

     

        private void btnLocation_Click(object sender, EventArgs e)
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "INSERT INTO LOCATION (LOC) VALUES ('" + txtLOC.Text + "')";
            cmdsql.ExecuteNonQuery();
            MessageBox.Show("New Location Successfully Added, Proceed your Entry.....");
            LoadLOC();
            tbLOC.Visible = false;
        }

        ////private void btn_Save_Click(object sender, EventArgs e)
        ////{
        ////    try
        ////    {
        ////        if (txtCat.Text != "")
        ////        {
        ////            Connection.DatabaseConnection obyConn;
        ////            obyConn = new Connection.DatabaseConnection();
        ////            _Conn = obyConn.Connect();
        ////            SqlCommand cmdsql = new SqlCommand();
        ////            cmdsql.Connection = _Conn;
        ////            cmdsql.CommandText = "INSERT INTO CATEGORY (CATEGORY, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO) VALUES ('" + txtCat.Text + "', '" + cmb_UOM.Text + "', '" + txt_ROL.Text + "', '" + txt_ROQ.Text + "', '" + txtLocate.Text + "', '" + txt_CabNo.Text + "', '" + txt_RackNo.Text + "', '" + txt_BinNo.Text + "', '" + txt_SPNo.Text + "')";
        ////            cmdsql.ExecuteNonQuery();
        ////            MessageBox.Show("New Category Successfully Added");
        ////        }
        ////        if (txtMake.Text != "")
        ////        {
        ////            Connection.DatabaseConnection obyConn;
        ////            obyConn = new Connection.DatabaseConnection();
        ////            _Conn = obyConn.Connect();
        ////            SqlCommand cmdsql = new SqlCommand();
        ////            cmdsql.Connection = _Conn;
        ////            cmdsql.CommandText = "INSERT INTO MAKE (MAKE) VALUES ('" + txtMake.Text + "')";
        ////            cmdsql.ExecuteNonQuery();
        ////            MessageBox.Show("New Brand / Model Successfully Added");
        ////        }
        ////        if (txtModel.Text != "")
        ////        {
        ////            Connection.DatabaseConnection obyConn;
        ////            obyConn = new Connection.DatabaseConnection();
        ////            _Conn = obyConn.Connect();
        ////            SqlCommand cmdsql = new SqlCommand();
        ////            cmdsql.Connection = _Conn;
        ////            cmdsql.CommandText = "INSERT INTO MODEL (MAKE, MODEL) VALUES ('" + cmb_MAKE.Text + "', '" + txtModel.Text + "')";
        ////            cmdsql.ExecuteNonQuery();
        ////            MessageBox.Show("New Model Successfully Added");
        ////        }
        ////    }
        ////    catch (Exception)
        ////    {
        ////        MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Bank Information");
        ////        return;
        ////    }
        ////    _Conn.Close();
        ////    cmbCat.Text = "";
        ////    txtMake.Text = "";
        ////    cmbModel.Text = "";
        ////    cmb_MAKE.Text = "";
        ////    cmb_UOM.Text = "";
        ////    txt_ROL.Text = "";
        ////    txt_ROQ.Text = "";
        ////    txtLocate.Text = "";
        ////    txt_CabNo.Text = "";
        ////    txt_RackNo.Text = "";
        ////    txt_BinNo.Text = "";
        ////    txt_SPNo.Text = "";
        ////    tbCatInfo.Visible = false;
        ////    LoadMakes();
        ////}

        private void ShowDetails()
        {
            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter(SHOW.ToString().Trim(), _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "MASTER");

            Grid_A.DataSource = dsLoan;
            Grid_A.DataMember = "MASTER";

            _Conn.Close();

            FillGrid_A();
        }

        private void FillGrid_A()
        {
            Grid_A.Columns[1].Width = 200;
            Grid_A.Columns[1].HeaderText = "PART NO";
            Grid_A.Columns[2].Width = 90;
            Grid_A.Columns[2].HeaderText = "DESCRIPTION";
            Grid_A.Columns[3].Width = 50;
            Grid_A.Columns[3].HeaderText = "UNIT";
            Grid_A.Columns[4].Width = 75;
            Grid_A.Columns[4].HeaderText = "RE-OR.LVL";
            Grid_A.Columns[5].Width = 75;
            Grid_A.Columns[5].HeaderText = "RE-OR.QTY";
            Grid_A.Columns[6].Width = 70;
            Grid_A.Columns[6].HeaderText = "LOCATION";
            Grid_A.Columns[7].Width = 60;
            Grid_A.Columns[7].HeaderText = "CABINET";
            Grid_A.Columns[8].Width = 60;
            Grid_A.Columns[8].HeaderText = "RACK";
            Grid_A.Columns[9].Width = 60;
            Grid_A.Columns[9].HeaderText = "BIN";
            Grid_A.Columns[10].Width = 60;
            Grid_A.Columns[10].HeaderText = "SPECIAL";
            Grid_A.Columns[11].Width = 20;
            Grid_A.Columns[11].HeaderText = "X";
            Grid_A.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[3].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[4].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[5].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[6].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[7].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[8].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[9].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[10].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_A.Columns[11].DefaultCellStyle.BackColor = Color.AliceBlue;

            Grid_A.Columns[0].Visible = false;

            Grid_A.Columns[0].ReadOnly = false;
            Grid_A.Columns[1].ReadOnly = false;
            Grid_A.Columns[2].ReadOnly = false;
            Grid_A.Columns[3].ReadOnly = true;
            Grid_A.Columns[4].ReadOnly = false;
            Grid_A.Columns[5].ReadOnly = false;
            Grid_A.Columns[6].ReadOnly = false;
            Grid_A.Columns[7].ReadOnly = false;
            Grid_A.Columns[8].ReadOnly = false;
            Grid_A.Columns[9].ReadOnly = false;
            Grid_A.Columns[10].ReadOnly = false;
            Grid_A.Columns[11].ReadOnly = false;

            Grid_A.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_A.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
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
            Grid_A.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_A.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_A.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void btnLOC_Click_1(object sender, EventArgs e)
        {
            if (tbLOC.Visible == true)
                tbLOC.Visible = false;
            else
            {
                tbPart.Visible = false;
                tbMake.Visible = false;
                tbUOM.Visible = false;
                tbLOC.Visible = true;
                txtLOC.Focus();
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (txt_Code.Text == "" || txtLocate.Text == "")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Required Info.");
                    return;
                }
                if (txtDesc.Text == "")
                {
                    txtDesc.Text = "-";
                }

                else
                {
                    Connection.DatabaseConnection obyConn;
                    obyConn = new Connection.DatabaseConnection();
                    _Conn = obyConn.Connect();
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "INSERT INTO MASTER(CATEGORY, MAKE, SUB_CAT, DESCRIPTION, PARTNO, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO)VALUES ('" + cmbCat.Text + "', '" + cmb_MAKE.Text + "', '" + cmbSub.Text + "', '" + txtDesc.Text + "', '" + txt_Code.Text + "', '" + txt_UOM.Text + "', " + txt_ROL.Text + ", " + txt_ROQ.Text + ", '" + txtLocate.Text + "', '" + txt_CabNo.Text + "', '" + txt_RackNo.Text + "', '" + txt_BinNo.Text + "', '" + txt_SP.Text + "')";
                    cmdsql.ExecuteNonQuery();
                    MessageBox.Show("New Part Info Successfully Added");
                    ShowDetails();
                    OPBQTY.Focus();
                    //tbCatInfo.Enabled = false;
                    //panel1.Visible = true;
                    //OPBQTY.Focus();
                }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Part Creation Info....");
            //    return;
            //}
            _Conn.Close();


            panel1.Visible = true;
            //frm_GenarateBarcode frm_Reces = new frm_GenarateBarcode();
            //frm_Reces.CODE = txt_Code.Text;
            //frm_Reces.BARNO = txtBarNo.Text;


            //frm_Reces.Show();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {

            if (tbCategory.Visible == true)
                tbCategory.Visible = false;
            else
            {
                tbCategory.Visible = true;
                tbPart.Visible = false;
                tbMake.Visible = false;
                tbUOM.Visible = false;
                tbLOC.Visible = false;
                txtC.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbMake.Visible == true)
                tbMake.Visible = false;
            else
            {
                tbPart.Visible = false;
                tbMake.Visible = true;
                tbUOM.Visible = false;
                tbLOC.Visible = false;
                cmbC.Focus();
                cmbC.DroppedDown = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tbPart.Visible == true)
                tbPart.Visible = false;
            else
            {
                tbPart.Visible = true;
                tbMake.Visible = false;
                tbUOM.Visible = false;
                tbLOC.Visible = false;
                cmbC1.Focus();
                cmbC1.DroppedDown = true;
            }
        }

        private void FillGrid_D()
        {
            Grid_D.Columns[0].Width = 360;
            Grid_D.Columns[0].HeaderText = "METHOD";
            Grid_D.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_D.Columns[0].ReadOnly = true;
            Grid_D.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_D.AutoGenerateColumns = false;
            Grid_D.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            Grid_D.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Grid_D.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
            Grid_D.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            Grid_D.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_D.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            Grid_D.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_D.MultiSelect = false;
            Grid_D.RowHeadersVisible = true;
            Grid_D.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_D.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_D.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void FillGrid_B()
        {
            Grid_B.Columns[0].Width = 180;
            Grid_B.Columns[1].Width = 180;
            Grid_B.Columns[0].HeaderText = "METHOD";
            Grid_B.Columns[1].HeaderText = "MEDIA";
            Grid_B.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_B.Columns[0].ReadOnly = true;
            Grid_B.Columns[1].ReadOnly = true;
            Grid_B.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_B.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
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
            Grid_B.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_B.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_B.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void FillGrid_C()
        {
            Grid_C.Columns[0].Width = 120;
            Grid_C.Columns[1].Width = 120;
            Grid_C.Columns[2].Width = 120;
            Grid_C.Columns[0].HeaderText = "METHOD";
            Grid_C.Columns[1].HeaderText = "MEDIA";
            Grid_C.Columns[2].HeaderText = "CATEGORY";
            Grid_C.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_C.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_C.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
            Grid_C.Columns[0].ReadOnly = true;
            Grid_C.Columns[1].ReadOnly = true;
            Grid_C.Columns[2].ReadOnly = false;
            Grid_C.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_C.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Grid_C.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
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
            Grid_C.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Grid_C.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Grid_C.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        //private void FillGrid_D()
        //{
        //    Grid_C.Columns[0].Width = 120;
        //    Grid_C.Columns[1].Width = 120;
        //    Grid_C.Columns[2].Width = 120;
        //    Grid_C.Columns[0].HeaderText = "CATEGORY";
        //    Grid_C.Columns[1].HeaderText = "MAKE";
        //    Grid_C.Columns[2].HeaderText = "PART";
        //    Grid_C.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
        //    Grid_C.Columns[1].DefaultCellStyle.BackColor = Color.AliceBlue;
        //    Grid_C.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;
        //    Grid_C.Columns[0].ReadOnly = true;
        //    Grid_C.Columns[1].ReadOnly = true;
        //    Grid_C.Columns[2].ReadOnly = false;
        //    Grid_C.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    Grid_C.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    Grid_C.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    Grid_C.AutoGenerateColumns = false;
        //    Grid_C.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
        //    Grid_C.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    Grid_C.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
        //    Grid_C.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        //    Grid_C.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        //    Grid_C.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
        //    Grid_C.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    Grid_C.MultiSelect = false;
        //    Grid_C.RowHeadersVisible = true;
        //    Grid_C.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    Grid_C.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    Grid_C.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    Grid_C.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        //    Grid_C.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        //}


        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtP.Text == "")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Required Info.");
                    return;
                }
                else

                    if (txtP.Text != "")
                    {
                        Connection.DatabaseConnection obyConn;
                        obyConn = new Connection.DatabaseConnection();
                        _Conn = obyConn.Connect();
                        SqlCommand cmdsql = new SqlCommand();
                        cmdsql.Connection = _Conn;
                        cmdsql.CommandText = "INSERT INTO SUBCAT (CATEGORY, MAKE, SUBCAT) VALUES (@cat, @make, @part)";
                        cmdsql.Parameters.Add("@cat", SqlDbType.VarChar, 100).Value = cmbC1.Text;
                        cmdsql.Parameters.Add("@make", SqlDbType.VarChar, 100).Value = cmbM.Text;
                        cmdsql.Parameters.Add("@part", SqlDbType.VarChar, 100).Value = txtP.Text;
                        cmdsql.ExecuteNonQuery();
                        MessageBox.Show("New Part Successfully Added");
                    }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_InventoryMaster", ex);
                MessageBox.Show(ex.Message, "Inventory");
            }
            finally
            {
                if (_Conn != null)
                {
                    _Conn.Dispose();
                    _Conn = null;
                }
            }
            //LoadCats();
            txtP.Text = "";
            cmbC1.ResetText();
            cmbM.ResetText();
            tbPart.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtM.Text == "")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Required Info.");
                    return;
                }
                else

                    if (txtM.Text != "")
                    {
                        Connection.DatabaseConnection obyConn;
                        obyConn = new Connection.DatabaseConnection();
                        _Conn = obyConn.Connect();
                        SqlCommand cmdsql = new SqlCommand();
                        cmdsql.Connection = _Conn;
                        cmdsql.CommandText = "INSERT INTO MAKE (CATEGORY, MAKE) VALUES ('" + cmbC.Text + "', '" + txtM.Text + "')";
                        cmdsql.ExecuteNonQuery();
                        MessageBox.Show("New Make Successfully Added");
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Bank Information");
                return;
            }
            _Conn.Close();
            txtM.Text = "";
            cmbC.ResetText();
            tbMake.Visible = false;
            ShowDetailsMake();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (txtC.Text == "")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Required Info.");
                    return;
                }
                else

                    if (txtC.Text != "")
                    {
                        Connection.DatabaseConnection obyConn;
                        obyConn = new Connection.DatabaseConnection();
                        _Conn = obyConn.Connect();
                        SqlCommand cmdsql = new SqlCommand();
                        cmdsql.Connection = _Conn;
                        cmdsql.CommandText = "INSERT INTO CATEGORY (CATEGORY, TOT_COST, PER_PAGE) VALUES ('" + txtC.Text + "', '" + txtCost.Text + "', '" + txtPage.Text + "')";
                        cmdsql.ExecuteNonQuery();
                        MessageBox.Show("New Category Successfully Added");
                    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Bank Information");
            //    return;
            //}
            _Conn.Close();
            ShowDetailsCat();
            txtC.Text = "";
        }

        private void frm_InventoryMaster_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 27)
            {
                //MessageBox.Show("OOOOOOOOOOOOOPPS");
            }
        }

        private void frm_InventoryMaster_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("OOOOOOOOOOOOOPPS");

        }

        private void txt_ROL_Leave(object sender, EventArgs e)
        {
            if (txt_ROL.Text == "")
            {
                txt_ROL.Text = "0";
            }
            if (Convert.ToDecimal(txt_ROL.Text) <= 0)
            {
                MessageBox.Show("Re Order Level should be More than '0'");
                txt_ROL.Focus();
            }

        }

        private void txt_ROQ_Leave(object sender, EventArgs e)
        {
            if (txt_ROQ.Text == "")
            {
                txt_ROQ.Text = "0";
            }
            if (Convert.ToDecimal(txt_ROQ.Text) <= 0)
            {
                MessageBox.Show("Re Order Quantity should be More than '0'");
                txt_ROQ.Focus();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void cmb_MAKE_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Code.Focus();
            }
        }

        private void txt_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                FIND_EXCIST();
                FillDGV("");
                txtDesc.Focus();
            }
        }

        private void FIND_EXCIST()
        {
            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;

            cmdsql.CommandText = "SELECT MASTER.PARTNO FROM MASTER WHERE PARTNO = '" + txt_Code.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                lblMsg.Text = "PART ALLREADY EXCISTS AS... - '" + dreader["PARTNO"].ToString() + "'";
                txt_Code.Focus();
                return;
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        
        private void cmbPart_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                //txtBarNo.Focus();
            }
        }

        private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_ROL.Focus();
            }
        }

        private void txt_ROQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_UOM.Focus();
            }
        }

        private void txt_ROL_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_ROQ.Focus();
            }
        }

        private void txt_CabNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_RackNo.Focus();
            }
        }

        private void txt_RackNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_BinNo.Focus();
            }
        }

        private void txt_BinNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_UOM.DroppedDown = true;
                txt_UOM.Focus();
            }
        }

        private void txt_UOM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtLocate.DroppedDown = true;
                txtLocate.Focus();
            }
        }

        private void txt_SP_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                btn_Save.Focus();
            }
        }

        private void txtLocate_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_SP.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                Connection.DatabaseConnection obyConn;

                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();

                SqlDataAdapter thisAdapter = new SqlDataAdapter(SHOW.ToString().Trim(), _Conn);
                SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
                DataSet thisDataset = new DataSet();

                thisAdapter.Fill(thisDataset, "MASTER");

                int count = 0;

                foreach (DataRow dr in thisDataset.Tables["MASTER"].Rows)
                {
                    //SELECT SEQNO, PARTNO, PART, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO, DEL, BARNO FROM MASTER ORDER BY PARTNO DESC
                    
                    thisDataset.Tables["MASTER"].Rows[count]["PARTNO"] = Grid_A.Rows[count].Cells[1].Value.ToString();
                    thisDataset.Tables["MASTER"].Rows[count]["PART"] = Grid_A.Rows[count].Cells[2].Value.ToString();
                    thisDataset.Tables["MASTER"].Rows[count]["DESCRIPTION"] = Grid_A.Rows[count].Cells[3].Value.ToString();
                    thisDataset.Tables["MASTER"].Rows[count]["ROL"] = Grid_A.Rows[count].Cells[5].Value.ToString();
                    thisDataset.Tables["MASTER"].Rows[count]["ROQ"] = Grid_A.Rows[count].Cells[6].Value.ToString();
                    thisDataset.Tables["MASTER"].Rows[count]["CAB"] = Grid_A.Rows[count].Cells[8].Value.ToString();
                    thisDataset.Tables["MASTER"].Rows[count]["RACK"] = Grid_A.Rows[count].Cells[9].Value.ToString();
                    thisDataset.Tables["MASTER"].Rows[count]["BIN"] = Grid_A.Rows[count].Cells[10].Value.ToString();
                    thisDataset.Tables["MASTER"].Rows[count]["SPNO"] = Grid_A.Rows[count].Cells[11].Value.ToString();
                    thisDataset.Tables["MASTER"].Rows[count]["BARNO"] = Grid_A.Rows[count].Cells[13].Value.ToString();
                    thisAdapter.Update(thisDataset, "MASTER");
                    count++;
                }
                _Conn.Close();
                MessageBox.Show("Records Updated Successfully ", "Update Info.");

                ShowDetails();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error.... Similer Record Found. Verify Your Entry", "Inventory Master Information");
            //    return;
            //}
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string APRVD;
            int SEQNO;

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter thisAdapter = new SqlDataAdapter(SHOW.ToString().Trim(), _Conn);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();

            thisAdapter.Fill(thisDataset, "DELETE_ENTRY");

            int count = 0;

            foreach (DataRow dr in thisDataset.Tables["DELETE_ENTRY"].Rows)
            {
                APRVD = Grid_A.Rows[count].Cells[11].Value.ToString();
                SEQNO = Convert.ToInt32(Grid_A.Rows[count].Cells[0].Value.ToString());

                if (APRVD == "True")
                {
                    //try
                    SqlCommand cmdsql = new SqlCommand();
                    cmdsql.Connection = _Conn;
                    cmdsql.CommandText = "DELETE FROM MASTER WHERE SEQNO = '" + SEQNO + "'";
                    SqlDataReader dreader = cmdsql.ExecuteReader();
                    //}
                    _Conn.Dispose();
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("Member Loan Can not be Deleted, Error.....", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                }
                count++;
                _Conn = obyConn.Connect();
            }
            _Conn.Close();
            ShowDetails();
            MessageBox.Show("Records are Successfully Deleted", "Deleting Entries");
        }

        private void cmbPart1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Code.Focus();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            lblC.Visible = false;
            lblM.Visible = false;
            lblS.Visible = false;
        }

        private void txt_Code_Leave(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblC.Text = "";
            lblM.Text = "";
            lblS.Text = "";
            FIND_EXCIST();
            FillDGV("");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //frm_UpdateBarcode frm_BARNOs = new frm_UpdateBarcode();
            //frm_BARNOs.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarNo_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtCost.Focus();

            }
        }

        private void txtM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                try
                {
                    if (txtM.Text == "")
                    {
                        MessageBox.Show("Please Enter Required Data and Proceed", "Required Info.");
                        return;
                    }
                    else

                        if (txtM.Text != "")
                        {
                            Connection.DatabaseConnection obyConn;
                            obyConn = new Connection.DatabaseConnection();
                            _Conn = obyConn.Connect();
                            SqlCommand cmdsql = new SqlCommand();
                            cmdsql.Connection = _Conn;
                            cmdsql.CommandText = "INSERT INTO MAKE (CATEGORY, MAKE) VALUES ('" + cmbC.Text + "', '" + txtM.Text + "')";
                            cmdsql.ExecuteNonQuery();
                            MessageBox.Show("New Make Successfully Added");
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Bank Information");
                    return;
                }
                _Conn.Close();
                txtM.Text = "";
                cmbC.ResetText();
                //tbMake.Visible = false;
                ShowDetailsMake();
            }
        }

        private void txtP_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                try
                {
                    if (txtP.Text == "")
                    {
                        MessageBox.Show("Please Enter Required Data and Proceed", "Required Info.");
                        return;
                    }
                    else

                        if (txtP.Text != "")
                        {
                            Connection.DatabaseConnection obyConn;
                            obyConn = new Connection.DatabaseConnection();
                            _Conn = obyConn.Connect();
                            SqlCommand cmdsql = new SqlCommand();
                            cmdsql.Connection = _Conn;
                            cmdsql.CommandText = "INSERT INTO SUBCAT (CATEGORY, MAKE, SUBCAT) VALUES ('" + cmbC1.Text + "', '" + cmbM.Text + "', '" + txtP.Text + "')";
                            cmdsql.ExecuteNonQuery();
                            MessageBox.Show("New Part Successfully Added");
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Bank Information");
                    return;
                }
                _Conn.Close();
                txtP.Text = "";
                cmbC1.ResetText();
                cmbM.ResetText();
                tbPart.Visible = false;
            }
        }

        private void txtLOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "INSERT INTO LOCATION (LOC) VALUES ('" + txtLOC.Text + "')";
                cmdsql.ExecuteNonQuery();
                MessageBox.Show("New Location Successfully Added, Proceed your Entry.....");
                LoadLOC();
                tbLOC.Visible = false;
            }
        }

        private void txtUOM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                Connection.DatabaseConnection obyConn;
                obyConn = new Connection.DatabaseConnection();
                _Conn = obyConn.Connect();
                SqlCommand cmdsql = new SqlCommand();
                cmdsql.Connection = _Conn;
                cmdsql.CommandText = "INSERT INTO UOM (UOM) VALUES ('" + txtUOM.Text + "')";
                cmdsql.ExecuteNonQuery();
                MessageBox.Show("New Unit of Measure Successfully Added, Proceed your Entry.....");
                LoadUOM();
                tbUOM.Visible = false;
            }
        }

        private void cmbC_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtM.Focus();
            }
        }

        private void cmbC1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbM.Focus();
            }
        }

        private void cmbM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtP.Focus();
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            //PURCHASE = decimal.Parse(OPBCOST.Text);                 //1000
            //OPBCOST.Text = PURCHASE.ToString("#####0.00");          //1000.00
            ////txt_Price.Text = PURCHASE.ToString("###,##0"); 
            //QTY = int.Parse(OPBQTY.Text);                           //10

            //PURCHASE = decimal.Parse(OPBCOST.Text);                 
            //TOT_PURCHASE = PURCHASE * QTY;                          // 10000 = 1000 * 10


            PURCHASE = decimal.Parse(OPBCOST.Text);                 //1000
            OPBCOST.Text = PURCHASE.ToString("#####0.00");          //1000.00
            //txt_Price.Text = PURCHASE.ToString("###,##0"); 
            QTY = int.Parse(OPBQTY.Text);                           //10
            PURCHASE = decimal.Parse(OPBCOST.Text);

            OPB_PER = decimal.Parse(lblIU.Text);                   //

            TOT_PURCHASE = OPB_PER * QTY;                          // 10000 = 1000 * 10


            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdTenMain = new SqlCommand("SELECT INV_NO FROM RECEIVED_TOTALS WHERE INV_NO = 0", _Conn);
            SqlDataReader drTenMain = cmdTenMain.ExecuteReader();
            drTenMain.Read();
            if (drTenMain.HasRows == false)
            {
                drTenMain.Dispose();
                SqlCommand cmdsql1 = new SqlCommand();
                cmdsql1.Connection = _Conn;
                cmdsql1.CommandText = "INSERT INTO RECEIVED_TOTALS (INV_NO) VALUES (0)";
                cmdsql1.ExecuteNonQuery();
            }
            drTenMain.Dispose();
            _Conn.Close();
            //try
            //{
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            if (OPBPRICE.Text == "" || OPBQTY.Text == "")
            {
                MessageBox.Show("Please Enter Required Data and Proceed", "Openning Balance Entry");
                OPBQTY.Focus();
                return;
            }

            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "INSERT INTO RECEIVED_ITEMS (SYS_USER, PARTNO, SUPPLIER, INV_NO, QTY, BAL_QTY, DIS_PRICE, ISSUE_PRICE, PRICE, REMARKS, PRO_DATE, TOT, STATUS) VALUES ('ADMIN', '" + txt_Code.Text + "','1','0', '" + OPBQTY.Text + "', '" + OPBQTY.Text + "' ,'" + OPBCOST.Text + "', '" + TOTISSCOST + "', '" + IU + "', 'OPB',Convert(DateTime,'" + lbl_ProDate.Text + "'),'" + TOT_PURCHASE + "', '1')";
            cmdsql.ExecuteNonQuery();

            MessageBox.Show("Openning Balance Entry Successfully Added");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Received Goods Info");
            //    return;
            //}

            //SqlCommand cmdsql1 = new SqlCommand();
            //cmdsql1.Connection = _Conn;
            //cmdsql1.CommandText = "INSERT INTO RECEIVED_TOTALS (INV_NO) VALUES ('" + txtInvoice.Text + "')";
            //cmdsql1.ExecuteNonQuery();
            OPBQTY.Text = "";
            OPBPRICE.Text = "";
            _Conn.Close();
            panel1.Visible = false;

        }

        private void OPBQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                OPBCOST.Focus();
            }
        }

        private void OPBPRICE_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void OPBCOST_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                lblIU.Focus();
            }
        }

        private void OPBPER_KeyPress(object sender, KeyPressEventArgs e)
        {

            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                lblIU.Focus();
            }
        }

        private void OPBPER_Leave(object sender, EventArgs e)
        {
            //PURCHASE = decimal.Parse(OPBCOST.Text);               
            //QTY = int.Parse(OPBQTY.Text);                          

            //decimal OPBPRS = decimal.Parse(OPBPER.Text);

            //TOT_PURCHASE = PURCHASE * QTY; 

            //SELLP = (TOT_PURCHASE / 100) * OPBPRS;

            //TOTISSCOST = TOT_PURCHASE - SELLP;
            //OPBPRICE.Text = TOTISSCOST.ToString();
            //IU = TOTISSCOST / QTY;
            //lblIUO.Text = IU.ToString();
            
            //OPBCOST.Text = PURCHASE.ToString("#####0.00");
            //OPBPRICE.Text = TOTISSCOST.ToString("#####0.00");
            //lblIUO.Text = IU.ToString("###,##0.00");


           
        }

        private void OPBPER_TextChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void lblIU_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                button13.Focus();
            }
        }

        private void lblIU_Leave(object sender, EventArgs e)
        {
            try
            {
                PURCHASE = decimal.Parse(lblIU.Text);
                OPBCOSTS = decimal.Parse(OPBCOST.Text);
                QTY = int.Parse(OPBQTY.Text);

                TOT_PURCHASE = PURCHASE * QTY;

                TOTISSCOST = TOT_PURCHASE - SELLP;
                OPBPRICE.Text = TOTISSCOST.ToString();
                IU = TOTISSCOST / QTY;
                lblIU.Text = IU.ToString();

                OPBCOST.Text = OPBCOSTS.ToString("#####0.00");
                OPBPRICE.Text = TOTISSCOST.ToString("#####0.00");
                lblIU.Text = IU.ToString("###,##0.00");
            }
            catch (Exception)
            {
            }
        }

        private void OPBCOST_Leave(object sender, EventArgs e)
        {
            OPBCOSTS = decimal.Parse(OPBCOST.Text);
            OPBCOST.Text = OPBCOSTS.ToString("###,##0.00");  
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void txtBarNo_Leave(object sender, EventArgs e)
        {
            //Connection.DatabaseConnection obyConn;
            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();
            //SqlCommand cmdTenMain = new SqlCommand("SELECT BARNO FROM MASTER WHERE BARNO = '"+ txtBarNo.Text +"'", _Conn);
            //SqlDataReader drTenMain = cmdTenMain.ExecuteReader();
            //drTenMain.Read();
            //if (drTenMain.HasRows == true)
            //{
            //    MessageBox.Show("Barcode Number you have entered is in Use...., Please select another Barcode to proceed","",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtBarNo.Focus();
            //}
            //drTenMain.Dispose();
            //_Conn.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;

            Connection.DatabaseConnection obyConn;

            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();

            SqlDataAdapter drLoan = new SqlDataAdapter("SELECT BARNO FROM MASTER ORDER BY BARNO DESC", _Conn);
            SqlCommandBuilder cmdLoan = new SqlCommandBuilder(drLoan);
            DataSet dsLoan = new DataSet();

            drLoan.Fill(dsLoan, "MASTER");

            GRID_G.DataSource = dsLoan;
            GRID_G.DataMember = "MASTER";

            _Conn.Close();

            FillGrid_G();
        }

        private void FillGrid_G()
        {
            GRID_G.Columns[0].Width = 250;
            GRID_G.Columns[0].HeaderText = "USED BARCODE NOS";
            GRID_G.Columns[0].DefaultCellStyle.BackColor = Color.AliceBlue;
            GRID_G.Columns[0].ReadOnly = true;
            GRID_G.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            GRID_G.AutoGenerateColumns = false;
            GRID_G.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            GRID_G.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            GRID_G.ColumnHeadersDefaultCellStyle.Font = new Font(Grid_A.Font, FontStyle.Bold);
            GRID_G.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            GRID_G.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            GRID_G.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            GRID_G.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GRID_G.MultiSelect = false;
            GRID_G.RowHeadersVisible = true;
            GRID_G.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            GRID_G.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            GRID_G.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GRID_G_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            SqlCommand command = new SqlCommand("INSERT INTO PHOTOS(PARTNO, FILE_NAME, IMAGE) VALUES (@id,@name,@img)", _Conn);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = txt_Code.Text;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = A.ToString();
            command.Parameters.Add("@img", SqlDbType.Image).Value = img;

            ExecMyQuery(command, "Picture Uploaded Successfully");



        }

        //private void ExecMyQuery(SqlCommand command, string p)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        public void ExecMyQuery(SqlCommand mcomd, string myMsg)
        {
            try
            {
                _Conn.Open();
            }
            catch (Exception)
            {

            }


            if (mcomd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(myMsg);
            }
            else
            {
                MessageBox.Show("Query Not Executed");
            }

            FillDGV("");
            _Conn.Close();
        }

        public void FillDGV(string valueToSearch)
        {
            //Connection.DatabaseConnection obyConn;

            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();

            //SqlCommand command = new SqlCommand("SELECT * FROM PHOTOS WHERE JOB_NO = '" + txt_Code.Text + "'", _Conn);

            //SqlDataAdapter adapter = new SqlDataAdapter(command);

            //DataTable table = new DataTable();

            //adapter.Fill(table);

            //dataGridView1.RowTemplate.Height = 100;

            //dataGridView1.AllowUserToAddRows = false;

            //dataGridView1.DataSource = table;

            //dataGridView1.Columns[0].Visible = false;
            ////dataGridView1.Columns[2].Visible = false;

            //dataGridView1.Columns[0].Width = 40;
            //dataGridView1.Columns[1].Width = 150;

            //DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            //imgCol = (DataGridViewImageColumn)dataGridView1.Columns[1];
            //imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }


        private void button25_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(opf.FileName);
                    A = opf.FileName.ToString();
                    //txtPath.Text = A.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Size of the Picture is too large or Not a supported Format");
                }
            }

            //Byte[] img = (Byte[])dataGridView1.CurrentRow.Cells[3].Value;

            //MemoryStream ms = new MemoryStream(img);

            //pictureBox1.Image = Image.FromStream(ms);

            //textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //textBox22.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //textBox23.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM PHOTOS WHERE PARTNO = @id", _Conn);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = txt_Code.Text;

            ExecMyQuery(command, "Picture Deleted Successully");

            ClearFields();

        }
        public void ClearFields()
        {
            pictureBox1.Image = null;

        }

        private void button31_Click(object sender, EventArgs e)
        {
            ClearFields();
            tb3.Visible = true;
            FillDGV("");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            Byte[] img = (Byte[])dataGridView1.CurrentRow.Cells[1].Value;

            MemoryStream ms = new MemoryStream(img);

            pictureBox1.Image = Image.FromStream(ms);

            //SEQ = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPath.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //pictureBox1.Image = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            tb3.Visible = false;
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            cmbCat.Focus();
            cmbCat.DroppedDown = true;
            timer2.Enabled = false;
        }

        private void tbCat_Click(object sender, EventArgs e)
        {

        }

        private void cmbWarrenty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_ROL.Focus();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //frm_GenarateBarcode frm_Reces = new frm_GenarateBarcode();
            //frm_Reces.CODE = txt_Code.Text;
            //frm_Reces.BARNO = txtBarNo.Text;

                            
            //frm_Reces.Show();
        }

        private void txtBarNo_KeyDown(object sender, KeyEventArgs e)
        {
            //int ccc = e.KeyValue;
            //int iii = (int)ccc;
            //if (iii == 121)
            //{
            //    Connection.DatabaseConnection obyConn;
            //    obyConn = new Connection.DatabaseConnection();
            //    _Conn = obyConn.Connect();
            //    SqlCommand cmdTenMain = new SqlCommand("SELECT BARNO FROM MASTER WHERE BARNO = '" + txtBarNo.Text + "'", _Conn);
            //    SqlDataReader drTenMain = cmdTenMain.ExecuteReader();
            //    drTenMain.Read();
            //    if (drTenMain.HasRows == true)
            //    {
            //        MessageBox.Show("Barcode Number you have entered is in Use...., Please select another Barcode to proceed", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtBarNo.Focus();
            //        return;
            //    }
            //    drTenMain.Dispose();
            //    _Conn.Close();

            //    //frm_GenarateBarcode frm_Reces = new frm_GenarateBarcode();
            //    //frm_Reces.CODE = txt_Code.Text;
            //    //frm_Reces.BARNO = txtBarNo.Text;


            //    //frm_Reces.Show();
            //}
            //this.TopMost = false;
        }

        private void Grid_A_MouseClick(object sender, MouseEventArgs e)
        {
            
            //Int32 SelectedRowCount = Grid_A.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //if (SelectedRowCount > 0)
            //{
            //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //    int i = 0;
            //    for (int < SelectedRowCount; i++;
            //    {
            //        sb.Append("Row: ");
            //        sb.Append(Grid_A.SelectedRows[i].Index.ToString());
            //        sb.Append(Environment.NewLine);

            //    }
            //}
                
               
            //}



            //string AAAA = Grid_A.Rows[SelectedRow].Cells[1].Value.ToString();
            //txt_Code.Text = AAAA.ToString();
        }

        private void txt_Code_KeyDown(object sender, KeyEventArgs e)
        {
            //int ccc = e.KeyValue;
            //int iii = (int)ccc;
            //if (iii == 121)
            //{
            //    Connection.DatabaseConnection obyConn;
            //    obyConn = new Connection.DatabaseConnection();
            //    _Conn = obyConn.Connect();
            //    SqlCommand cmdTenMain = new SqlCommand("SELECT BARNO FROM MASTER WHERE BARNO = '" + txtBarNo.Text + "'", _Conn);
            //    SqlDataReader drTenMain = cmdTenMain.ExecuteReader();
            //    drTenMain.Read();
            //    if (drTenMain.HasRows == true)
            //    {
            //        MessageBox.Show("Barcode Number you have entered is in Use...., Please select another Barcode to proceed", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtBarNo.Focus();
            //        return;
            //    }
            //    drTenMain.Dispose();
            //    _Conn.Close();

            //    //frm_GenarateBarcode frm_Reces = new frm_GenarateBarcode();
            //    //frm_Reces.CODE = txt_Code.Text;
            //    //frm_Reces.BARNO = txtBarNo.Text;


            //    //frm_Reces.Show();
            //}
            //this.TopMost = false;
        }

        private void cmbCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmb_MAKE.DroppedDown = true;
                cmb_MAKE.Focus();
            }
        }

        private void cmb_MAKE_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbSub.DroppedDown = true;
                cmbSub.Focus();
            }
        }

        private void cmbSub_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txt_Code.Focus();

            }
        }

        private void cmbCat_SelectedValueChanged(object sender, EventArgs e)
        {
            tbCatInfo.Enabled = false;
            cmb_MAKE.Enabled = true;
            cmb_MAKE.Items.Clear();
            cmbSub.Items.Clear();
            cmb_MAKE.Text = "";
            cmbSub.Text = "";
            txtMake.Text = "";
            txtSub.Text = "";


            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT MAKE FROM MAKE WHERE CATEGORY = '" + cmbCat.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmb_MAKE.Items.Add(dreader["MAKE"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
            CATSEQ();
            SHOW = "SELECT SEQNO, CATEGORY, MAKE, PARTNO, PART, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO, DEL, BARNO FROM MASTER WHERE (CATEGORY = '" + txtCat.Text + "')ORDER BY SEQNO";
            ShowDetails();
        }
        private void CATSEQ()
        {
            txtCat.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQNO FROM CATEGORY WHERE CATEGORY = '" + cmbCat.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txtCat.Text = dreader["SEQNO"].ToString().Trim();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void MAKESEQ()
        {
            txtMake.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQNO FROM MAKE WHERE CATEGORY = '" + cmbCat.Text + "' AND MAKE = '" + cmb_MAKE.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txtMake.Text = dreader["SEQNO"].ToString().Trim();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void SUBSEQ()
        {
            txtSub.Text = "";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT SEQNO FROM SUBCAT WHERE CATEGORY = '" + cmbCat.Text + "' AND MAKE = '" + cmb_MAKE.Text + "'AND SUBCAT = '" + cmbSub.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                txtSub.Text = dreader["SEQNO"].ToString().Trim();
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }



        private void cmb_MAKE_SelectedValueChanged(object sender, EventArgs e)
        {
            tbCatInfo.Enabled = true;
            cmbSub.Enabled = true;
            cmbSub.Items.Clear();
            cmbSub.Text = "";
            txtSub.Text = "";
            txt_UOM.Text = "NOS";
            txtLocate.Text = "Main Stores";

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;

            cmdsql.CommandText = "SELECT SUB_CAT FROM SUB_CATEGORY WHERE CATEGORY = '" + cmbCat.Text + "' AND MAKE = '" + cmb_MAKE.Text + "'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbSub.Items.Add(dreader["SUB_CAT"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
            MAKESEQ();
            SHOW = "SELECT SEQNO, CATEGORY, MAKE, PARTNO, PART, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO, DEL, BARNO FROM MASTER WHERE (CATEGORY = '" + txtCat.Text + "')AND (MAKE = '" + txtMake.Text + "')ORDER BY SEQNO";
            ShowDetails();
        }

        private void cmbSub_SelectedValueChanged(object sender, EventArgs e)
        {
            SUBSEQ();
            SHOW = "SELECT SEQNO, CATEGORY, MAKE, PARTNO, PART, DESCRIPTION, UOM, ROL, ROQ, LOC, CAB, RACK, BIN, SPNO, DEL, BARNO FROM MASTER WHERE (CATEGORY = '" + txtCat.Text + "')AND (MAKE = '" + txtMake.Text + "')AND (SUB_CAT = '" + txtSub.Text + "')ORDER BY SEQNO DESC";
            ShowDetails();
            tbCatInfo.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (tbCategory.Visible == true)
                tbCategory.Visible = false;
            else
            {
                tbCategory.Visible = true;
                tbPart.Visible = false;
                tbMake.Visible = false;
                tbUOM.Visible = false;
                tbLOC.Visible = false;
            }
            txtC.Focus();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            LoadCats();

            if (tbMake.Visible == true)
                tbMake.Visible = false;
            else
            {
                tbCategory.Visible = false;
                tbPart.Visible = false;
                tbMake.Visible = true;
                tbUOM.Visible = false;
                tbLOC.Visible = false;
            }
            cmbC.Focus();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            LoadCats();
            if (tbPart.Visible == true)
                tbPart.Visible = false;
            else
            {
                tbCategory.Visible = false;
                tbPart.Visible = true;
                tbMake.Visible = false;
                tbUOM.Visible = false;
                tbLOC.Visible = false;
            }
            cmbC1.Focus();
        }

        private void txtPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                try
                {
                    if (txtC.Text == "")
                    {
                        MessageBox.Show("Please Enter Required Data and Proceed", "Required Info.");
                        return;
                    }
                    else

                        if (txtC.Text != "")
                        {
                            Connection.DatabaseConnection obyConn;
                            obyConn = new Connection.DatabaseConnection();
                            _Conn = obyConn.Connect();
                            SqlCommand cmdsql = new SqlCommand();
                            cmdsql.Connection = _Conn;
                            cmdsql.CommandText = "INSERT INTO CATEGORY (CATEGORY, TOT_COST, PER_PAGE) VALUES ('" + txtC.Text + "', '" + txtCost.Text + "', '" + txtPage.Text + "')";
                            cmdsql.ExecuteNonQuery();
                            MessageBox.Show("New Category Successfully Added");
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Bank Information");
                    return;
                }
                _Conn.Close();
                txtC.Text = "";
                txtCost.Text = "";
                txtPage.Text = "";
                ShowDetailsCat();
                txtC.Focus();
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtPage.Focus();

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
        }

        private void txtP_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                try
                {
                    if (cmbM.Text == "")
                    {
                        MessageBox.Show("Please Enter Required Data and Proceed", "Required Info.");
                        return;
                    }
                    else

                        if (cmbM.Text != "")
                        {
                            Connection.DatabaseConnection obyConn;
                            obyConn = new Connection.DatabaseConnection();
                            _Conn = obyConn.Connect();
                            SqlCommand cmdsql = new SqlCommand();
                            cmdsql.Connection = _Conn;
                            cmdsql.CommandText = "INSERT INTO SUB_CATEGORY (CATEGORY, MAKE, SUB_CAT) VALUES ('" + cmbC1.Text + "', '" + cmbM.Text + "', '" + txtP.Text + "')";
                            cmdsql.ExecuteNonQuery();
                            MessageBox.Show("New Category Successfully Added");
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Information");
                    return;
                }
                _Conn.Close();
                txtM.Text = "";
                cmbC.ResetText();
                //tbMake.Visible = false;
                //ShowDetailsMake();
                //ShowDetailsCat();
                ShowDetailsSub();
                txt_Code.Focus();
            }
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbC1_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbM.Items.Clear();

            Connection.DatabaseConnection obyConn;
            obyConn = new Connection.DatabaseConnection();
            _Conn = obyConn.Connect();
            SqlCommand cmdsql = new SqlCommand();
            cmdsql.Connection = _Conn;
            cmdsql.CommandText = "SELECT CATEGORY, MAKE FROM MAKE WHERE CATEGORY = '"+ cmbC1.Text +"'";
            SqlDataReader dreader = cmdsql.ExecuteReader();
            while (dreader.Read())
            {
                cmbM.Items.Add(dreader["MAKE"].ToString());
            }
            cmdsql.Dispose();
            dreader.Dispose();
            _Conn.Close();
        }

        private void cmbC1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                cmbM.Focus();
            }
        }

        private void cmbM_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int i = (int)c;
            if (i == 13)
            {
                txtP.Focus();
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbM.Text == "")
                {
                    MessageBox.Show("Please Enter Required Data and Proceed", "Required Info.");
                    return;
                }
                else

                    if (cmbM.Text != "")
                    {
                        Connection.DatabaseConnection obyConn;
                        obyConn = new Connection.DatabaseConnection();
                        _Conn = obyConn.Connect();
                        SqlCommand cmdsql = new SqlCommand();
                        cmdsql.Connection = _Conn;
                        cmdsql.CommandText = "INSERT INTO SUB_CATEGORY (CATEGORY, MAKE, SUB_CAT) VALUES ('" + cmbC1.Text + "', '" + cmbM.Text + "', '" + txtP.Text + "')";
                        cmdsql.ExecuteNonQuery();
                        MessageBox.Show("New Category Successfully Added");
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("Error.... Record Already Entered. Check and Verify Your Entry", "Information");
                return;
            }
            _Conn.Close();
            txtM.Text = "";
            cmbC.ResetText();
            //tbMake.Visible = false;
            ShowDetailsMake();
            ShowDetailsSub();
            txt_Code.Focus();
        }

        private void cmbM_SelectedValueChanged(object sender, EventArgs e)
        {
            //txtP.Text = "";

            //Connection.DatabaseConnection obyConn;
            //obyConn = new Connection.DatabaseConnection();
            //_Conn = obyConn.Connect();
            //SqlCommand cmdsql = new SqlCommand();
            //cmdsql.Connection = _Conn;
            //cmdsql.CommandText = "SELECT CATEGORY, MAKE FROM MAKE WHERE CATEGORY = '" + cmbC1.Text + "'";
            //SqlDataReader dreader = cmdsql.ExecuteReader();
            //while (dreader.Read())
            //{
            //    cmbM.Items.Add(dreader["MAKE"].ToString());
            //}
            //cmdsql.Dispose();
            //dreader.Dispose();
            //_Conn.Close();
        }

        private void cmbM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Grid_D_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}