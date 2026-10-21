using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Billing_Inventory_Management_System
{
    public class frm_Accounts : Form
    {
        private TextBox txtSearch;
        private DateTimePicker dtFrom;
        private DateTimePicker dtTo;
        private Label cashInValue;
        private Label cashOutValue;
        private Label debtorsValue;
        private Label creditorsValue;
        private TabControl pages;
        private readonly Dictionary<string, DataGridView> grids = new Dictionary<string, DataGridView>();

        public frm_Accounts()
        {
            this.Name = "frm_Accounts";
            this.Text = "Accounts";
            this.Font = UiTheme.Font;
            this.BackColor = UiTheme.Canvas;
            this.ClientSize = new Size(1100, 700);

            Panel searchBar = BuildSearchBar();
            Panel cards = BuildCards();
            pages = new TabControl();
            pages.Name = "accountTabs";
            pages.Dock = DockStyle.Fill;
            pages.Font = UiTheme.Font;
            pages.Padding = new Point(16, 6);
            pages.TabPages.Add(Page("Cash book"));
            pages.TabPages.Add(Page("Advances"));
            pages.TabPages.Add(Page("Debtors"));
            pages.TabPages.Add(Page("Creditors"));
            pages.TabPages.Add(Page("Expenses"));

            this.Controls.Add(pages);
            this.Controls.Add(cards);
            this.Controls.Add(searchBar);
            UiTheme.StyleForm(this);
            UiTheme.StylePrimary(searchBar.Controls["btnAccountSearch"] as Button);
            this.Shown += delegate { Reload(); };
        }

        private Panel BuildSearchBar()
        {
            Panel bar = new Panel();
            bar.Name = "accountSearchBar";
            bar.Dock = DockStyle.Top;
            bar.Height = 72;
            bar.BackColor = Color.White;
            bar.Padding = new Padding(16, 16, 16, 12);

            Label findLabel = new Label();
            findLabel.Text = "Job, invoice, or customer";
            findLabel.AutoSize = true;
            findLabel.ForeColor = UiTheme.Muted;
            findLabel.Location = new Point(16, 8);

            txtSearch = new TextBox();
            txtSearch.Name = "txtAccountSearch";
            txtSearch.Location = new Point(16, 32);
            txtSearch.Width = 280;
            txtSearch.KeyDown += SearchKeyDown;

            Label fromLabel = new Label();
            fromLabel.Text = "From";
            fromLabel.AutoSize = true;
            fromLabel.ForeColor = UiTheme.Muted;
            fromLabel.Location = new Point(312, 8);

            dtFrom = new DateTimePicker();
            dtFrom.Name = "dtAccountFrom";
            dtFrom.Format = DateTimePickerFormat.Short;
            dtFrom.Location = new Point(312, 32);
            dtFrom.Width = 130;
            dtFrom.Value = DateTime.Today;

            Label toLabel = new Label();
            toLabel.Text = "To";
            toLabel.AutoSize = true;
            toLabel.ForeColor = UiTheme.Muted;
            toLabel.Location = new Point(456, 8);

            dtTo = new DateTimePicker();
            dtTo.Name = "dtAccountTo";
            dtTo.Format = DateTimePickerFormat.Short;
            dtTo.Location = new Point(456, 32);
            dtTo.Width = 130;
            dtTo.Value = DateTime.Today;

            Button search = new Button();
            search.Name = "btnAccountSearch";
            search.Text = "Search";
            search.Location = new Point(604, 30);
            search.Size = new Size(110, 30);
            search.Click += delegate { Reload(); };

            bar.Controls.Add(findLabel);
            bar.Controls.Add(txtSearch);
            bar.Controls.Add(fromLabel);
            bar.Controls.Add(dtFrom);
            bar.Controls.Add(toLabel);
            bar.Controls.Add(dtTo);
            bar.Controls.Add(search);
            return bar;
        }

        private Panel BuildCards()
        {
            Panel row = new Panel();
            row.Name = "accountCards";
            row.Dock = DockStyle.Top;
            row.Height = 104;
            row.BackColor = UiTheme.Canvas;
            row.Padding = new Padding(12, 12, 12, 8);
            TableLayoutPanel table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.ColumnCount = 4;
            table.RowCount = 1;
            for (int i = 0; i < 4; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }
            cashInValue = Card(table, 0, "Total Cash In");
            cashOutValue = Card(table, 1, "Total Cash Out");
            debtorsValue = Card(table, 2, "Total Debtors Balance");
            creditorsValue = Card(table, 3, "Total Creditors Balance");
            row.Controls.Add(table);
            return row;
        }

        private static Label Card(TableLayoutPanel table, int column, string caption)
        {
            Panel card = new Panel();
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(4, 0, 4, 0);
            card.BackColor = Color.White;
            card.Padding = new Padding(12, 8, 12, 8);
            Label title = new Label();
            title.Text = caption;
            title.Dock = DockStyle.Top;
            title.Height = 22;
            title.ForeColor = UiTheme.Muted;
            Label value = new Label();
            value.Text = "0.00";
            value.Dock = DockStyle.Fill;
            value.Font = UiTheme.ValueFont;
            value.ForeColor = UiTheme.Ink;
            value.TextAlign = ContentAlignment.MiddleLeft;
            card.Controls.Add(value);
            card.Controls.Add(title);
            table.Controls.Add(card, column, 0);
            return value;
        }

        private TabPage Page(string caption)
        {
            TabPage page = new TabPage(caption);
            page.BackColor = UiTheme.Canvas;
            page.Padding = new Padding(8);
            DataGridView grid = new DataGridView();
            grid.Name = caption;
            grid.Dock = DockStyle.Fill;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.MultiSelect = false;
            if (caption == "Cash book" || caption == "Advances" || caption == "Debtors")
            {
                grid.CellDoubleClick += OpenHistory;
            }
            page.Controls.Add(grid);
            grids[caption] = grid;
            return page;
        }

        private void SearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Reload();
            }
        }

        private void Reload()
        {
            if (dtFrom.Value.Date > dtTo.Value.Date)
            {
                MessageBox.Show("From date must be on or before To date.", "Accounts");
                return;
            }
            try
            {
                EnsureCategory(null);
                DataTable cash = Fill(CashBookSql(), "", null);
                Bind("Cash book", cash);
                Bind("Advances", Fill(AdvancesSql(), "", null));
                DataTable debtors = Fill(DebtorsSql(), "", null);
                Bind("Debtors", debtors);
                DataTable creditors = Fill(CreditorsSql(), "", null);
                Bind("Creditors", creditors);
                Bind("Expenses", Fill(ExpensesSql(), "", null));
                cashInValue.Text = Sum(cash, "IN").ToString("0.00");
                cashOutValue.Text = Sum(cash, "OUT").ToString("0.00");
                debtorsValue.Text = Sum(debtors, "BALANCE").ToString("0.00");
                creditorsValue.Text = Sum(creditors, "RECEIVED").ToString("0.00");
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_Accounts.Reload", ex);
                MessageBox.Show(ex.Message, "Accounts");
            }
        }

        private void Bind(string caption, DataTable table)
        {
            DataGridView grid = grids[caption];
            grid.DataSource = null;
            grid.DataSource = table;
            UiTheme.StyleGrid(grid);
        }

        private static decimal Sum(DataTable table, string column)
        {
            decimal total = 0;
            if (table == null || !table.Columns.Contains(column))
            {
                return 0;
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                decimal value;
                if (decimal.TryParse(table.Rows[i][column].ToString(), out value))
                {
                    total += value;
                }
            }
            return total;
        }

        private DataTable Fill(string sql, string extraName, object extraValue)
        {
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                AddRange(adapter.SelectCommand);
                if (extraName != null && extraName.Length > 0)
                {
                    adapter.SelectCommand.Parameters.Add("@" + extraName, SqlDbType.VarChar, 200).Value = extraValue == null ? "" : extraValue.ToString();
                }
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private void AddRange(SqlCommand cmd)
        {
            string find = txtSearch.Text.Trim();
            string like = "%" + find.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]") + "%";
            cmd.Parameters.Add("@from", SqlDbType.Date).Value = dtFrom.Value.Date;
            cmd.Parameters.Add("@to", SqlDbType.Date).Value = dtTo.Value.Date;
            cmd.Parameters.Add("@find", SqlDbType.VarChar, 200).Value = find;
            cmd.Parameters.Add("@like", SqlDbType.VarChar, 220).Value = like;
        }

        private void OpenHistory(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridView grid = sender as DataGridView;
            if (grid == null || grid.CurrentRow == null)
            {
                return;
            }
            try
            {
                if (grid.Name == "Debtors")
                {
                    string name = Cell(grid, "CUSTOMER");
                    ShowHistory(name, DebtorHistorySql(), "name", name);
                }
                else if (grid.Name == "Advances")
                {
                    string job = Cell(grid, "JOB_NO");
                    ShowHistory("Job " + job, AdvanceHistorySql(), "job", job);
                }
                else if (grid.Name == "Cash book")
                {
                    OpenCashHistory(grid);
                }
            }
            catch (Exception ex)
            {
                AppLog.Write("frm_Accounts.OpenHistory", ex);
                MessageBox.Show(ex.Message, "Accounts");
            }
        }

        private void OpenCashHistory(DataGridView grid)
        {
            string job = JobFromRemarks(Cell(grid, "REMARKS"));
            if (job.Length > 0)
            {
                ShowHistory("Job " + job, CashJobSql(), "job", job);
                return;
            }
            string source = Cell(grid, "SOURCE");
            string description = Cell(grid, "DESCRIPTION");
            if (source == "Expenses")
            {
                ShowHistory(description, "SELECT PRO_DATE, DESCRIPTION, " + SqlMoney("AMOUNT") + " AS AMOUNT, ISNULL(CATEGORY, '') AS CATEGORY, REMARKS FROM DAY_EXPENCES WHERE DESCRIPTION = @desc AND " + Between("PRO_DATE") + " ORDER BY PRO_DATE DESC", "desc", description);
            }
            else if (source == "Petty cash")
            {
                ShowHistory(description, "SELECT PRO_DATE, DESCRIPTION, " + SqlMoney("IN_AMOUNT") + " AS [IN], " + SqlMoney("OUT_AMOUNT") + " AS [OUT] FROM PETTY_CASH_DETAILS WHERE DESCRIPTION = @desc AND " + Between("PRO_DATE") + " ORDER BY PRO_DATE DESC", "desc", description);
            }
            else
            {
                ShowHistory(description, "SELECT PRO_DATE, DESCRIPTION, " + SqlMoney("AMOUNT") + " AS AMOUNT, REMARKS FROM DAY_EARNINGS WHERE DESCRIPTION = @desc AND " + Between("PRO_DATE") + " ORDER BY PRO_DATE DESC", "desc", description);
            }
        }

        private static string Cell(DataGridView grid, string column)
        {
            if (grid.CurrentRow == null || grid.CurrentRow.Cells[column].Value == null)
            {
                return "";
            }
            return grid.CurrentRow.Cells[column].Value.ToString().Trim();
        }

        private static string JobFromRemarks(string remarks)
        {
            int at = remarks.IndexOf("Job ");
            if (at < 0)
            {
                return "";
            }
            string rest = remarks.Substring(at + 4).Trim();
            int space = rest.IndexOf(' ');
            if (space > 0)
            {
                rest = rest.Substring(0, space);
            }
            return rest.Trim();
        }

        private void ShowHistory(string title, string sql, string extraName, string extraValue)
        {
            Form dialog = new Form();
            dialog.Text = title.Length == 0 ? "History" : title;
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.ClientSize = new Size(760, 420);
            dialog.Font = UiTheme.Font;
            dialog.BackColor = UiTheme.Canvas;
            Panel pad = new Panel();
            pad.Dock = DockStyle.Fill;
            pad.Padding = new Padding(12);
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pad.Controls.Add(grid);
            dialog.Controls.Add(pad);
            grid.DataSource = Fill(sql, extraName, extraValue);
            UiTheme.StyleForm(dialog);
            UiTheme.StyleGrid(grid);
            dialog.ShowDialog(this);
        }

        internal static void EnsureCategory(SqlConnection existing)
        {
            SqlConnection conn = existing;
            bool opened = false;
            try
            {
                if (conn == null)
                {
                    Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                    conn = link.Connect();
                    opened = true;
                }
                SqlCommand cmd = new SqlCommand("IF COL_LENGTH('DAY_EXPENCES','CATEGORY') IS NULL ALTER TABLE DAY_EXPENCES ADD CATEGORY varchar(30) NULL", conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (opened && conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        private static string SqlMoney(string column)
        {
            return "CASE WHEN ISNUMERIC(" + column + ") = 1 THEN CAST(" + column + " AS decimal(18,2)) ELSE 0 END";
        }

        private static string Between(string column)
        {
            return "CONVERT(date, " + column + ") >= @from AND CONVERT(date, " + column + ") <= @to";
        }

        private static string CashBookSql()
        {
            string amount = SqlMoney("AMOUNT");
            string pettyIn = SqlMoney("IN_AMOUNT");
            string pettyOut = SqlMoney("OUT_AMOUNT");
            string text = "(@find = '' OR DESCRIPTION LIKE @like OR ISNULL(REMARKS,'') LIKE @like)";
            return "SELECT 'Earnings' AS SOURCE, DESCRIPTION, " + amount + " AS [IN], CAST(0 AS decimal(18,2)) AS [OUT], REMARKS FROM DAY_EARNINGS WHERE " + Between("PRO_DATE") + " AND " + text
                + " UNION ALL SELECT 'Expenses', DESCRIPTION, CAST(0 AS decimal(18,2)), " + amount + ", REMARKS FROM DAY_EXPENCES WHERE " + Between("PRO_DATE") + " AND " + text
                + " UNION ALL SELECT 'Petty cash', DESCRIPTION, " + pettyIn + ", " + pettyOut + ", '' FROM PETTY_CASH_DETAILS WHERE " + Between("PRO_DATE") + " AND (@find = '' OR DESCRIPTION LIKE @like)";
        }

        private static string AdvancesSql()
        {
            string paid = SqlMoney("j.ADVANCE_1") + " + " + SqlMoney("j.ADVANCE_2") + " + " + SqlMoney("j.ADVANCE_3");
            string total = SqlMoney("j.TOT_COST_AMOUNT");
            return "SELECT j.JOB_NO, j.INV_NO, ISNULL(c.NAME, '') AS CUSTOMER, " + total + " AS TOTAL, " + paid + " AS PAID, " + total + " - (" + paid + ") AS BALANCE FROM JOB_DETAILS j LEFT JOIN CUSTOMER_INFO c ON CAST(c.SEQ_NO AS varchar(20)) = j.CUSTOMER_ID WHERE j.STATUS = 1 AND (" + paid + ") > 0 AND " + total + " - (" + paid + ") > 0 AND " + Between("j.JOB_START_DATE") + " AND (@find = '' OR j.JOB_NO LIKE @like OR ISNULL(j.INV_NO,'') LIKE @like OR ISNULL(c.NAME,'') LIKE @like) ORDER BY j.SEQ_NO DESC";
        }

        private static string DebtorsSql()
        {
            string paid = SqlMoney("j.ADVANCE_1") + " + " + SqlMoney("j.ADVANCE_2") + " + " + SqlMoney("j.ADVANCE_3");
            string total = SqlMoney("j.TOT_COST_AMOUNT");
            return "SELECT c.NAME AS CUSTOMER, SUM(" + total + " - (" + paid + ")) AS BALANCE FROM JOB_DETAILS j INNER JOIN CUSTOMER_INFO c ON CAST(c.SEQ_NO AS varchar(20)) = j.CUSTOMER_ID WHERE j.STATUS = 1 AND " + Between("j.JOB_START_DATE") + " AND (@find = '' OR c.NAME LIKE @like OR j.JOB_NO LIKE @like OR ISNULL(j.INV_NO,'') LIKE @like) GROUP BY c.NAME HAVING SUM(" + total + " - (" + paid + ")) > 0 ORDER BY c.NAME";
        }

        private static string CreditorsSql()
        {
            string name = "ISNULL(s.NAME, CAST(r.SUPPLIER AS varchar(20)))";
            return "SELECT " + name + " AS SUPPLIER, SUM(" + SqlMoney("r.TOT") + ") AS RECEIVED FROM RECEIVED_ITEMS r LEFT JOIN SUPPLIER_INFO s ON CAST(r.SUPPLIER AS varchar(20)) = CAST(s.SEQ_NO AS varchar(20)) WHERE " + Between("r.PRO_DATE") + " AND (@find = '' OR " + name + " LIKE @like) GROUP BY " + name + " ORDER BY SUPPLIER";
        }

        private static string ExpensesSql()
        {
            return "SELECT PRO_DATE, DESCRIPTION, " + SqlMoney("AMOUNT") + " AS AMOUNT, ISNULL(CATEGORY, '') AS CATEGORY, REMARKS FROM DAY_EXPENCES WHERE " + Between("PRO_DATE") + " AND (@find = '' OR DESCRIPTION LIKE @like OR ISNULL(REMARKS,'') LIKE @like) ORDER BY PRO_DATE DESC";
        }

        private static string DebtorHistorySql()
        {
            string paid = SqlMoney("j.ADVANCE_1") + " + " + SqlMoney("j.ADVANCE_2") + " + " + SqlMoney("j.ADVANCE_3");
            string total = SqlMoney("j.TOT_COST_AMOUNT");
            return "SELECT j.JOB_NO, j.INV_NO, CONVERT(varchar(10), j.JOB_START_DATE, 23) AS JOB_DATE, " + total + " AS TOTAL, " + paid + " AS PAID, " + total + " - (" + paid + ") AS BALANCE FROM JOB_DETAILS j INNER JOIN CUSTOMER_INFO c ON CAST(c.SEQ_NO AS varchar(20)) = j.CUSTOMER_ID WHERE c.NAME = @name AND j.STATUS = 1 AND " + Between("j.JOB_START_DATE") + " ORDER BY j.SEQ_NO DESC";
        }

        private static string AdvanceHistorySql()
        {
            return "SELECT 'Advance 1' AS PAYMENT, " + SqlMoney("ADVANCE_1") + " AS AMOUNT, CAST(PAID_DATE1 AS varchar(30)) AS PAID_DATE FROM JOB_DETAILS WHERE JOB_NO = @job AND STATUS = 1"
                + " UNION ALL SELECT 'Advance 2', " + SqlMoney("ADVANCE_2") + ", CAST(PAID_DATE2 AS varchar(30)) FROM JOB_DETAILS WHERE JOB_NO = @job AND STATUS = 1"
                + " UNION ALL SELECT 'Advance 3', " + SqlMoney("ADVANCE_3") + ", CAST(PAID_DATE3 AS varchar(30)) FROM JOB_DETAILS WHERE JOB_NO = @job AND STATUS = 1";
        }

        private static string CashJobSql()
        {
            string paid = SqlMoney("j.ADVANCE_1") + " + " + SqlMoney("j.ADVANCE_2") + " + " + SqlMoney("j.ADVANCE_3");
            string total = SqlMoney("j.TOT_COST_AMOUNT");
            return "SELECT j.JOB_NO, j.INV_NO, ISNULL(c.NAME, '') AS CUSTOMER, CONVERT(varchar(10), j.JOB_START_DATE, 23) AS JOB_DATE, " + total + " AS TOTAL, " + paid + " AS PAID, " + total + " - (" + paid + ") AS BALANCE FROM JOB_DETAILS j LEFT JOIN CUSTOMER_INFO c ON CAST(c.SEQ_NO AS varchar(20)) = j.CUSTOMER_ID WHERE j.JOB_NO = @job AND j.STATUS = 1";
        }
    }
}
