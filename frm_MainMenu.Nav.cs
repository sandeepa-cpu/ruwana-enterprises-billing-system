using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Billing_Inventory_Management_System
{
    public partial class frm_MainMenu
    {
        private Panel navSidebar;
        private Panel navTopBar;
        private Button navToggle;
        private bool navExpanded = true;
        private ToolTip navTips;
        private readonly Dictionary<Button, Color> navAccents = new Dictionary<Button, Color>();
        private readonly HashSet<Button> navHover = new HashSet<Button>();
        private Color navCanvas = Color.Empty;
        private static readonly Color AccentJob = Color.FromArgb(37, 99, 235);
        private static readonly Color AccentStock = Color.FromArgb(5, 150, 105);
        private static readonly Color AccentCustomer = Color.FromArgb(217, 119, 6);
        private static readonly Color AccentSupplier = Color.FromArgb(124, 58, 237);
        private static readonly Color AccentReport = Color.FromArgb(13, 148, 136);
        private static readonly Color AccentNavy = Color.FromArgb(31, 78, 121);
        private static readonly Color NavHover = Color.FromArgb(230, 240, 250);

        private void BuildNavigation()
        {
            menuStrip1.Visible = false;
            HideLegacyChrome();

            navTopBar = new Panel();
            navTopBar.Name = "navTopBar";
            navTopBar.Dock = DockStyle.Top;
            navTopBar.Height = 56;
            navTopBar.BackColor = Color.White;

            navSidebar = new Panel();
            navSidebar.Name = "navSidebar";
            navSidebar.Dock = DockStyle.Left;
            navSidebar.Width = 220;
            navSidebar.BackColor = Color.White;

            navToggle = new Button();
            navToggle.Name = "navToggle";
            navToggle.Text = "Hide";
            navToggle.Dock = DockStyle.Top;
            navToggle.Height = 40;
            navToggle.FlatStyle = FlatStyle.Flat;
            navToggle.FlatAppearance.BorderSize = 0;
            navToggle.BackColor = Color.White;
            navToggle.ForeColor = UiTheme.Ink;
            navToggle.Font = UiTheme.FontBold;
            navToggle.Cursor = Cursors.Hand;
            navToggle.TextAlign = ContentAlignment.MiddleLeft;
            navToggle.Padding = new Padding(12, 0, 0, 0);
            navToggle.Click += navToggle_Click;

            Panel navList = new Panel();
            navList.Name = "navList";
            navList.Dock = DockStyle.Fill;
            navList.AutoScroll = true;
            navList.BackColor = Color.White;
            navTips = new ToolTip();
            AddNav(navList, NavButton("navJob", "Job Card", "\uE8A5", AccentJob, toolStripMenuItem10_Click));
            AddNav(navList, NavButton("navInventory", "Inventory", "\uE14C", AccentStock, button8_Click));
            AddNav(navList, NavButton("navReceive", "Receive stock", "\uE8B7", AccentStock, button16_Click_1));
            AddNav(navList, NavButton("navCustomers", "Customers", "\uE77B", AccentCustomer, button6_Click_1));
            AddNav(navList, NavButton("navSuppliers", "Suppliers", "\uE716", AccentSupplier, button7_Click_1));
            AddNav(navList, NavButton("navReports", "Reports", "\uE9F9", AccentReport, reportViewerToolStripMenuItem_Click));
            AddNav(navList, NavButton("navExpenses", "Daily expenses", "\uE8C7", AccentNavy, dailyExpencesToolStripMenuItem1_Click));
            AddNav(navList, NavButton("navAccounts", "Accounts", "\uE8C7", AccentNavy, navAccounts_Click));
            AddNav(navList, NavButton("navPayroll", "Payroll", "\uE8F1", AccentNavy, navPayroll_Click));
            AddNav(navList, NavButton("navUser", "New user", "\uE77B", AccentNavy, createNewUserToolStripMenuItem_Click));
            AddNav(navList, NavButton("navPassword", "Change password", "\uE72E", AccentNavy, changePasswordToolStripMenuItem_Click));
            AddNav(navList, NavButton("navBackup", "Backup", "\uE74E", AccentNavy, backupDatabaseToolStripMenuItem_Click));
            AddNav(navList, NavButton("navLogOff", "Log off", "\uE7E8", AccentNavy, toolStripMenuItem2_Click));

            navSidebar.Controls.Add(navList);
            navSidebar.Controls.Add(navToggle);
            UiTheme.RoundPanel(navSidebar, 8);

            PlaceTopBar();
            this.Controls.Add(navSidebar);
            this.Controls.Add(navTopBar);
            navSidebar.BringToFront();
            navTopBar.BringToFront();
            this.Resize -= frm_MainMenu_ResizeChrome;
            this.Resize += frm_MainMenu_ResizeChrome;
            this.Load -= ApplyRole;
            this.Load += ApplyRole;
            this.Activated -= frm_MainMenu_ActivatedInsights;
            this.Activated += frm_MainMenu_ActivatedInsights;
            AppWorkspace.Attach(this);
            LayoutChrome();
        }

        internal void RefreshWorkspace()
        {
            LayoutChrome();
        }

        private void navAccounts_Click(object sender, EventArgs e)
        {
            frm_Accounts accounts = new frm_Accounts();
            AppWorkspace.Open(accounts, "Accounts");
        }

        private void ApplyRole(object sender, EventArgs e)
        {
            bool admin = lblUserLevel.Text.Trim() == "0";
            SetNavVisible("navReports", admin);
            SetNavVisible("navExpenses", admin);
            SetNavVisible("navAccounts", admin);
            SetNavVisible("navUser", admin);
            SetNavVisible("navBackup", admin);
            SetNavVisible("navPayroll", admin);
            reportsToolStripMenuItem.Enabled = admin;
            processToolStripMenuItem.Enabled = admin;
            dailyExpencesToolStripMenuItem.Enabled = admin;
            createNewUserToolStripMenuItem.Enabled = admin;
            createUserRolesToolStripMenuItem.Enabled = admin;
            backupDatabaseToolStripMenuItem.Enabled = admin;
        }

        private void SetNavVisible(string name, bool visible)
        {
            Control found = FindNamed(navSidebar, name);
            if (found != null)
            {
                found.Visible = visible;
            }
        }

        private static Control FindNamed(Control parent, string name)
        {
            if (parent == null)
            {
                return null;
            }
            if (parent.Name == name)
            {
                return parent;
            }
            foreach (Control child in parent.Controls)
            {
                Control hit = FindNamed(child, name);
                if (hit != null)
                {
                    return hit;
                }
            }
            return null;
        }

        private void frm_MainMenu_ActivatedInsights(object sender, EventArgs e)
        {
            RefreshLowStock();
        }

        private void PlaceTopBar()
        {
            label15.Image = null;
            label15.AutoSize = true;
            label15.Font = UiTheme.FontBold;
            label15.ForeColor = UiTheme.Ink;
            label15.BackColor = Color.White;
            label15.Location = new Point(16, 18);
            navTopBar.Controls.Add(label15);

            label8.Image = null;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8F);
            label8.ForeColor = UiTheme.Muted;
            label8.BackColor = Color.White;
            label8.Location = new Point(280, 8);
            navTopBar.Controls.Add(label8);

            lblUser.Image = null;
            lblUser.AutoSize = true;
            lblUser.Font = UiTheme.FontBold;
            lblUser.ForeColor = UiTheme.Ink;
            lblUser.BackColor = Color.White;
            lblUser.Location = new Point(280, 26);
            navTopBar.Controls.Add(lblUser);

            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F);
            label3.ForeColor = UiTheme.Muted;
            label3.BackColor = Color.White;
            label3.Location = new Point(520, 8);
            navTopBar.Controls.Add(label3);

            lblSD.AutoSize = true;
            lblSD.Font = UiTheme.Font;
            lblSD.ForeColor = UiTheme.Ink;
            lblSD.BackColor = Color.White;
            lblSD.Location = new Point(520, 26);
            navTopBar.Controls.Add(lblSD);

            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F);
            label4.ForeColor = UiTheme.Muted;
            label4.BackColor = Color.White;
            label4.Location = new Point(760, 18);
            navTopBar.Controls.Add(label4);

            lblDate.AutoSize = true;
            lblDate.Font = UiTheme.FontBold;
            lblDate.ForeColor = UiTheme.Ink;
            lblDate.BackColor = Color.White;
            lblDate.Location = new Point(810, 16);
            navTopBar.Controls.Add(lblDate);

            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F);
            label5.ForeColor = UiTheme.Muted;
            label5.BackColor = Color.White;
            label5.Location = new Point(940, 18);
            navTopBar.Controls.Add(label5);

            lblTime.AutoSize = true;
            lblTime.Font = UiTheme.FontBold;
            lblTime.ForeColor = UiTheme.Ink;
            lblTime.BackColor = Color.White;
            lblTime.Location = new Point(990, 16);
            navTopBar.Controls.Add(lblTime);

            panel1.Visible = false;
        }

        private void HideLegacyChrome()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button17.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button29.Visible = false;
            button33.Visible = false;
            label10.Visible = false;
            label16.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label24.Visible = false;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;
            pictureBox11.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox24.Visible = false;
            pictureBox26.Visible = false;
            pictureBox28.Visible = false;
            btnShow.Visible = false;
        }

        private static void AddNav(Panel panel, Button button)
        {
            panel.Controls.Add(button);
            button.BringToFront();
        }

        private Button NavButton(string name, string text, string icon, Color accent, EventHandler handler)
        {
            Button button = new Button();
            button.Name = name;
            button.Tag = text;
            button.AccessibleName = text;
            button.AccessibleDescription = icon;
            button.Text = "";
            button.Font = UiTheme.Font;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = NavHover;
            button.FlatAppearance.MouseDownBackColor = NavHover;
            button.BackColor = Color.White;
            button.ForeColor = UiTheme.Ink;
            button.UseVisualStyleBackColor = false;
            button.Height = 36;
            button.Dock = DockStyle.Top;
            button.Cursor = Cursors.Hand;
            button.Click += handler;
            button.MouseEnter += navButton_MouseEnter;
            button.MouseLeave += navButton_MouseLeave;
            button.Paint += navButton_Paint;
            navAccents[button] = accent;
            if (navTips != null)
            {
                navTips.SetToolTip(button, text);
            }
            return button;
        }

        private void navButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            navHover.Add(button);
            button.BackColor = NavHover;
            button.Invalidate();
        }

        private void navButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            navHover.Remove(button);
            button.BackColor = Color.White;
            button.Invalidate();
        }

        private void navButton_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            Color accent = navAccents.ContainsKey(button) ? navAccents[button] : AccentNavy;
            bool hover = navHover.Contains(button);
            SolidBrush bar = new SolidBrush(accent);
            e.Graphics.FillRectangle(bar, 0, 0, 4, button.Height);
            bar.Dispose();
            string icon = button.AccessibleDescription == null ? "" : button.AccessibleDescription;
            Font iconFont = new Font("Segoe MDL2 Assets", navExpanded ? 14F : 16F);
            SolidBrush iconBrush = new SolidBrush(accent);
            if (!navExpanded)
            {
                SizeF size = e.Graphics.MeasureString(icon, iconFont);
                e.Graphics.DrawString(icon, iconFont, iconBrush, (button.Width - size.Width) / 2F, (button.Height - size.Height) / 2F);
            }
            else
            {
                e.Graphics.DrawString(icon, iconFont, iconBrush, 12F, 8F);
                string label = button.Tag as string;
                if (label == null)
                {
                    label = "";
                }
                SolidBrush textBrush = new SolidBrush(hover ? accent : UiTheme.Ink);
                e.Graphics.DrawString(label, UiTheme.Font, textBrush, 40F, 8F);
                textBrush.Dispose();
            }
            iconBrush.Dispose();
            iconFont.Dispose();
        }

        private void navToggle_Click(object sender, EventArgs e)
        {
            navExpanded = !navExpanded;
            navSidebar.Width = navExpanded ? 220 : 56;
            navToggle.Text = navExpanded ? "Hide" : "";
            ApplyNavWidth(navSidebar);
            LayoutChrome();
        }

        private void navPayroll_Click(object sender, EventArgs e)
        {
            frm_PayrollDashboard payroll = new frm_PayrollDashboard();
            payroll.Show();
        }

        private void ApplyNavWidth(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                Button button = control as Button;
                if (button != null && button.Name.StartsWith("nav") && button.Name != "navToggle")
                {
                    button.Text = "";
                    button.Invalidate();
                }
                if (control.HasChildren)
                {
                    ApplyNavWidth(control);
                }
            }
        }

        private void HideOffscreenLegacy()
        {
            foreach (Control control in this.Controls)
            {
                if (control == navSidebar || control == navTopBar || control == pictureBox1 || control.Name == "kpiRow" || control.Name == "workspaceTabs")
                {
                    continue;
                }
                if (control.Name != null && control.Name.StartsWith("nav"))
                {
                    continue;
                }
                if (!control.Visible)
                {
                    continue;
                }
                if (control.Left < 0 || control.Top >= this.ClientSize.Height || control.Left >= this.ClientSize.Width)
                {
                    control.Visible = false;
                }
            }
        }

        private void frm_MainMenu_ResizeChrome(object sender, EventArgs e)
        {
            if (navSidebar != null && navTopBar != null)
            {
                LayoutChrome();
            }
        }

        private void LayoutChrome()
        {
            if (navCanvas.IsEmpty && pictureBox1.Image != null)
            {
                Bitmap sample = new Bitmap(pictureBox1.Image);
                navCanvas = sample.GetPixel(8, 8);
                sample.Dispose();
            }
            Color navy = navCanvas.IsEmpty ? Color.FromArgb(10, 31, 68) : navCanvas;
            this.BackColor = navy;
            int left = navSidebar.Width;
            int top = navTopBar.Height + 128;
            pictureBox1.BackColor = navy;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Location = new Point(left, top);
            pictureBox1.Size = new Size(Math.Max(200, ClientSize.Width - left), Math.Max(200, ClientSize.Height - top));
            pictureBox1.SendToBack();
            HideOffscreenLegacy();
            Panel cards = this.Controls["kpiRow"] as Panel;
            if (cards != null)
            {
                int content = Math.Max(0, ClientSize.Width - left);
                int x = left + Math.Max(16, (content - cards.Width) / 2);
                cards.Location = new Point(x, navTopBar.Height + 16);
                cards.BringToFront();
            }
            Control workspace = this.Controls["workspaceTabs"];
            if (workspace != null)
            {
                if (workspace is TabControl && ((TabControl)workspace).TabCount > 0)
                {
                    workspace.Visible = true;
                    workspace.Bounds = new Rectangle(left, navTopBar.Height, Math.Max(200, ClientSize.Width - left), Math.Max(200, ClientSize.Height - navTopBar.Height));
                    workspace.BringToFront();
                }
                else
                {
                    workspace.Visible = false;
                }
            }
            navSidebar.BringToFront();
            navTopBar.BringToFront();
        }
    }
}
