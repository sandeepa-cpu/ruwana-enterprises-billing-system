using System;
using System.Drawing;
using System.Windows.Forms;

namespace Billing_Inventory_Management_System
{
    public class frm_PayrollDashboard : Form
    {
        public frm_PayrollDashboard()
        {
            this.Text = "Payroll";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(760, 520);
            this.Font = UiTheme.Font;
            this.ControlBox = true;

            FlowLayoutPanel tiles = new FlowLayoutPanel();
            tiles.Name = "payrollTiles";
            tiles.Dock = DockStyle.Fill;
            tiles.AutoScroll = true;
            tiles.WrapContents = true;
            tiles.Padding = new Padding(16);
            this.Controls.Add(tiles);

            Label heading = new Label();
            heading.Text = "Payroll";
            heading.Dock = DockStyle.Top;
            heading.Height = 48;
            heading.TextAlign = ContentAlignment.MiddleLeft;
            heading.Padding = new Padding(20, 0, 0, 0);
            heading.Font = UiTheme.TitleFont;
            this.Controls.Add(heading);

            AddTile(tiles, "Employees", delegate { return new frm_EmployeeDetails(); });
            AddTile(tiles, "Earnings", delegate { return new frm_Earnings(); });
            AddTile(tiles, "Deductions", delegate { return new frm_Deductions(); });
            AddTile(tiles, "Fund rates", delegate { return new frm_EmployeeFundRates(); });
            AddTile(tiles, "Employee loans", delegate { return new frm_LoanMain(); });
            AddTile(tiles, "Adjustments", delegate { return new frm_Adjustments(); });
            AddTile(tiles, "Loan entry", delegate { return new frm_LoanDetails(); });
            AddTile(tiles, "Salary process", delegate { return new frm_PayProcess(); });
            AddTile(tiles, "Loan settlements", delegate { return new frm_LoanAdjestments(); });
            AddTile(tiles, "Payroll reports", delegate { return new frm_ReportCriteria_Payroll(); });
            AddTile(tiles, "Banks", delegate { return new frm_BankBranchDetails(); });

            UiTheme.StyleForm(this);
            foreach (Control control in tiles.Controls)
            {
                Button tile = control as Button;
                if (tile != null)
                {
                    UiTheme.StylePrimary(tile);
                }
            }
        }

        private static void AddTile(FlowLayoutPanel tiles, string caption, Func<Form> create)
        {
            Button tile = new Button();
            tile.Text = caption;
            tile.Size = new Size(220, 72);
            tile.Margin = new Padding(12);
            tile.Tag = create;
            tile.Click += OpenTile;
            tiles.Controls.Add(tile);
        }

        private static void OpenTile(object sender, EventArgs e)
        {
            Button tile = sender as Button;
            if (tile == null)
            {
                return;
            }
            Func<Form> create = tile.Tag as Func<Form>;
            if (create == null)
            {
                return;
            }
            Form form = create();
            AppWorkspace.Open(form, tile.Text);
        }
    }
}
