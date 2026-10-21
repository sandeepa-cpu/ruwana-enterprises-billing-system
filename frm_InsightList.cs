using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Billing_Inventory_Management_System
{
    public class frm_InsightList : Form
    {
        public frm_InsightList(string title, string sql)
        {
            this.Text = title;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(760, 420);
            this.Font = UiTheme.Font;

            DataGridView grid = new DataGridView();
            grid.Name = "gridInsight";
            grid.Dock = DockStyle.Fill;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Controls.Add(grid);

            Label heading = new Label();
            heading.Text = title;
            heading.Dock = DockStyle.Top;
            heading.Height = 36;
            heading.TextAlign = ContentAlignment.MiddleLeft;
            heading.Padding = new Padding(12, 0, 0, 0);
            heading.Font = UiTheme.FontBold;
            this.Controls.Add(heading);

            UiTheme.StyleForm(this);
            UiTheme.StyleGrid(grid);
            LoadRows(grid, sql);
        }

        private static void LoadRows(DataGridView grid, string sql)
        {
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                grid.DataSource = table;
                UiTheme.StyleGrid(grid);
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_InsightList", ex);
                grid.DataSource = null;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }
    }
}
