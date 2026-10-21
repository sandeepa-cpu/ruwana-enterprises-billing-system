using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Billing_Inventory_Management_System
{
    public static class AppWorkspace
    {
        private static TabControl tabs;
        private static frm_MainMenu menu;

        public static void Attach(frm_MainMenu host)
        {
            if (host == null || tabs != null)
            {
                return;
            }
            menu = host;
            tabs = new TabControl();
            tabs.Name = "workspaceTabs";
            tabs.Visible = false;
            tabs.Font = UiTheme.Font;
            tabs.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabs.SizeMode = TabSizeMode.Fixed;
            tabs.ItemSize = new Size(180, 32);
            tabs.Padding = new Point(12, 6);
            tabs.DrawItem += DrawTab;
            tabs.MouseDown += TabsMouseDown;
            typeof(TabControl).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tabs, true, null);
            host.Controls.Add(tabs);
        }

        public static void Open(Form form, string caption)
        {
            if (form == null)
            {
                return;
            }
            if (tabs == null || IsSeparateWindow(form))
            {
                form.Show();
                return;
            }
            for (int i = 0; i < tabs.TabPages.Count; i++)
            {
                if (tabs.TabPages[i].Tag == form)
                {
                    tabs.SelectedIndex = i;
                    tabs.Visible = true;
                    if (menu != null)
                    {
                        menu.RefreshWorkspace();
                    }
                    return;
                }
            }
            if (caption == null || caption.Trim() == "")
            {
                caption = form.Text.Trim();
            }
            if (caption == "")
            {
                caption = "Window";
            }
            TabPage page = new TabPage(caption);
            page.Tag = form;
            page.BackColor = UiTheme.Canvas;
            page.AutoScroll = false;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            page.Controls.Add(form);
            tabs.TabPages.Add(page);
            tabs.SelectedTab = page;
            tabs.Visible = true;
            form.FormClosed += HostedFormClosed;
            form.Show();
            form.Dock = DockStyle.Fill;
            if (menu != null)
            {
                menu.RefreshWorkspace();
            }
        }

        private static bool IsSeparateWindow(Form form)
        {
            string name = form.Name;
            if (name == "frm_Reports" || name == "frm_UserLogIn" || name == "frm_Splash" || name == "frm_HNBFormat" || name == "frm_COMMFormat")
            {
                return true;
            }
            return name != null && name.StartsWith("frm_PaySlip");
        }

        private static void HostedFormClosed(object sender, FormClosedEventArgs e)
        {
            if (tabs == null)
            {
                return;
            }
            Form form = sender as Form;
            for (int i = tabs.TabPages.Count - 1; i >= 0; i--)
            {
                if (tabs.TabPages[i].Tag == form)
                {
                    tabs.TabPages.RemoveAt(i);
                }
            }
            if (tabs.TabCount == 0)
            {
                tabs.Visible = false;
            }
            if (menu != null)
            {
                menu.RefreshWorkspace();
            }
        }

        private static void TabsMouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabs.TabCount; i++)
            {
                Rectangle rect = tabs.GetTabRect(i);
                Rectangle close = new Rectangle(rect.Right - 22, rect.Top + 8, 16, 16);
                if (!close.Contains(e.Location))
                {
                    continue;
                }
                Form form = tabs.TabPages[i].Tag as Form;
                if (form != null && !form.IsDisposed)
                {
                    form.Close();
                }
                return;
            }
        }

        private static void DrawTab(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= tabs.TabCount)
            {
                return;
            }
            bool selected = e.Index == tabs.SelectedIndex;
            Color back = selected ? UiTheme.Primary : Color.White;
            Color ink = selected ? Color.White : UiTheme.Ink;
            using (SolidBrush brush = new SolidBrush(back))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            string caption = tabs.TabPages[e.Index].Text;
            Rectangle text = new Rectangle(e.Bounds.X + 8, e.Bounds.Y, e.Bounds.Width - 30, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, caption, UiTheme.Font, text, ink, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            TextRenderer.DrawText(e.Graphics, "x", UiTheme.FontBold, new Rectangle(e.Bounds.Right - 22, e.Bounds.Y, 18, e.Bounds.Height), ink, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
