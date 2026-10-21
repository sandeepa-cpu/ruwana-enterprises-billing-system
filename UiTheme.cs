using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Billing_Inventory_Management_System
{
    public static class UiTheme
    {
        public static readonly Color Canvas = Color.FromArgb(244, 246, 248);
        public static readonly Color Card = Color.White;
        public static readonly Color Ink = Color.FromArgb(31, 41, 51);
        public static readonly Color Muted = Color.FromArgb(107, 114, 128);
        public static readonly Color Primary = Color.FromArgb(31, 78, 121);
        public static readonly Color PrimaryHover = Color.FromArgb(24, 62, 96);
        public static readonly Color Line = Color.FromArgb(209, 213, 219);
        public static readonly Color GridLine = Color.FromArgb(229, 231, 235);
        public static readonly Color GridAlt = Color.FromArgb(248, 250, 252);
        public static readonly Color GridSelect = Color.FromArgb(219, 234, 254);
        public static readonly Color InputReadOnly = Color.FromArgb(243, 244, 246);

        public static readonly Font Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        public static readonly Font FontBold = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        public static readonly Font TitleFont = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
        public static readonly Font ValueFont = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);

        public static void StyleForm(Form form)
        {
            form.BackColor = Canvas;
            form.Font = Font;
            form.ForeColor = Ink;
            StyleChildren(form);
            ApplyShell(form);
        }

        private static void ApplyShell(Form form)
        {
            form.ControlBox = true;
            if (form.Name == "frm_MainMenu" || form.Name == "frm_UserLogIn" || form.Name == "frm_Splash" || form.Name == "frm_Reports")
            {
                return;
            }
            bool large = form.ClientSize.Width >= 900 || form.ClientSize.Height >= 680;
            form.MaximizeBox = large;
            form.MinimizeBox = large;
            WidenInputs(form);
            form.Shown -= OnShellShown;
            form.Shown += OnShellShown;
        }

        private static void OnShellShown(object sender, EventArgs e)
        {
            Form form = sender as Form;
            if (form == null || form.IsDisposed)
            {
                return;
            }
            try
            {
                if (!form.TopLevel)
                {
                    form.Dock = DockStyle.Fill;
                    form.AutoScroll = false;
                    DockActionBar(form);
                    return;
                }
                form.AutoScroll = false;
                form.AutoScrollPosition = new Point(0, 0);
                if (form.TopLevel)
                {
                    Rectangle work = Screen.FromControl(form).WorkingArea;
                    if (form.Width > work.Width || form.Height > work.Height)
                    {
                        int width = Math.Min(form.Width, work.Width);
                        int height = Math.Min(form.Height, work.Height);
                        form.Bounds = new Rectangle(work.Left + Math.Max(0, (work.Width - width) / 2), work.Top + Math.Max(0, (work.Height - height) / 2), width, height);
                    }
                }
                DockActionBar(form);
            }
            catch (Exception ex)
            {
                AppLog.Write("UiTheme.Shell", ex);
            }
        }

        private static void DockActionBar(Form form)
        {
            if (form.Controls.ContainsKey("actionBar"))
            {
                return;
            }
            List<Button> row = new List<Button>();
            foreach (Control control in form.Controls)
            {
                Button button = control as Button;
                if (button == null || !button.Visible || !IsBottomAction(button, form))
                {
                    continue;
                }
                row.Add(button);
            }
            if (row.Count == 0)
            {
                return;
            }
            row.Sort(delegate(Button left, Button right) { return left.Left.CompareTo(right.Left); });
            Panel bar = new Panel();
            bar.Name = "actionBar";
            bar.Height = 52;
            bar.Dock = DockStyle.Bottom;
            bar.BackColor = Canvas;
            bar.Padding = new Padding(12, 8, 12, 8);
            form.Controls.Add(bar);
            bar.BringToFront();
            form.PerformLayout();
            int x = bar.ClientSize.Width - 12;
            for (int i = row.Count - 1; i >= 0; i--)
            {
                Button button = row[i];
                x -= button.Width;
                button.Parent = bar;
                button.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                button.Location = new Point(Math.Max(12, x), 8);
                button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                x -= 8;
            }
            WrapScroll(form, bar);
        }

        private static void WrapScroll(Form form, Panel bar)
        {
            if (form.Controls.ContainsKey("contentScroll"))
            {
                return;
            }
            Panel scroll = new Panel();
            scroll.Name = "contentScroll";
            scroll.Dock = DockStyle.Fill;
            scroll.AutoScroll = true;
            scroll.BackColor = form.BackColor;
            List<Control> move = new List<Control>();
            foreach (Control control in form.Controls)
            {
                if (control != bar && control.Dock == DockStyle.None)
                {
                    move.Add(control);
                }
            }
            foreach (Control control in move)
            {
                Point location = control.Location;
                control.Parent = scroll;
                control.Location = location;
            }
            form.Controls.Add(scroll);
            bar.BringToFront();
        }

        private static bool IsBottomAction(Button button, Control parent)
        {
            if (button.Name != null && button.Name.StartsWith("nav"))
            {
                return false;
            }
            string text = button.Text == null ? "" : button.Text.Replace("&", "");
            bool labeled = text.IndexOf("Save", StringComparison.OrdinalIgnoreCase) >= 0
                || text.IndexOf("Clear", StringComparison.OrdinalIgnoreCase) >= 0
                || text.IndexOf("Close", StringComparison.OrdinalIgnoreCase) >= 0
                || text.IndexOf("Quit", StringComparison.OrdinalIgnoreCase) >= 0;
            bool named = button.Name == "btn_Add" || button.Name == "btn_Clear" || button.Name == "btn_Quit" || button.Name == "btn_Back" || button.Name == "btn_Delete";
            if (!labeled && !named)
            {
                return false;
            }
            bool outside = button.Right > parent.ClientSize.Width - 2 || button.Bottom > parent.ClientSize.Height - 2 || button.Left < -2 || button.Top < -2;
            bool band = button.Top >= parent.ClientSize.Height - 170;
            return outside || band;
        }

        private static bool Overflows(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (!child.Visible || child.Name == "actionBar")
                {
                    continue;
                }
                if (child.Right > parent.ClientSize.Width + 8 || child.Bottom > parent.ClientSize.Height + 8)
                {
                    return true;
                }
                if (child.HasChildren && !(child is DataGridView) && Overflows(child))
                {
                    return true;
                }
            }
            return false;
        }

        private static void WidenInputs(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child.HasChildren && !(child is DataGridView))
                {
                    WidenInputs(child);
                }
            }
            List<Control> items = new List<Control>();
            foreach (Control child in parent.Controls)
            {
                if (child.Visible)
                {
                    items.Add(child);
                }
            }
            items.Sort(delegate(Control left, Control right)
            {
                int band = left.Top.CompareTo(right.Top);
                return band != 0 ? band : left.Left.CompareTo(right.Left);
            });
            foreach (Control item in items)
            {
                TextBox phone = item as TextBox;
                if (phone != null && IsPhoneName(phone.Name))
                {
                    phone.TextAlign = HorizontalAlignment.Left;
                }
                if (!(item is TextBoxBase) && !(item is ComboBox))
                {
                    continue;
                }
                int target = TargetWidth(item);
                int push = 0;
                foreach (Control other in items)
                {
                    if (other == item || other.Right <= item.Left)
                    {
                        continue;
                    }
                    if (other.Left < item.Left && other.Top < item.Bottom - 4 && other.Bottom > item.Top + 4)
                    {
                        int into = other.Right + 6 - item.Left;
                        if (into > push)
                        {
                            push = into;
                        }
                    }
                }
                int need = target - item.Width;
                if (need < 0)
                {
                    need = 0;
                }
                if (push < 4 && need < 4)
                {
                    continue;
                }
                int rowRight = item.Right;
                foreach (Control other in items)
                {
                    if (other.Top < item.Bottom - 4 && other.Bottom > item.Top + 4 && other.Right > rowRight)
                    {
                        rowRight = other.Right;
                    }
                }
                int slack = parent.ClientSize.Width - 8 - rowRight;
                if (slack < 0)
                {
                    slack = 0;
                }
                int shift = push + need;
                if (shift > slack)
                {
                    shift = slack;
                }
                if (shift < 4)
                {
                    continue;
                }
                if (push > shift)
                {
                    push = shift;
                }
                int grow = shift - push;
                int originalRight = item.Right;
                if (push > 0)
                {
                    item.Left += push;
                }
                item.Width += grow;
                foreach (Control other in items)
                {
                    if (other != item && other.Left >= originalRight - 2 && other.Top < item.Bottom - 4 && other.Bottom > item.Top + 4)
                    {
                        other.Left += shift;
                    }
                }
            }
        }

        private static bool IsPhoneName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            string lower = name.ToLowerInvariant();
            return lower.Contains("mobile") || lower.Contains("phone") || lower.Contains("tel") || lower.Contains("resident") || lower.Contains("contact") || lower.Contains("fax") || lower.Contains("nic");
        }

        private static int TargetWidth(Control control)
        {
            TextBoxBase box = control as TextBoxBase;
            if (box != null && box.Multiline)
            {
                return control.Width;
            }
            int chars = 0;
            string name = control.Name == null ? "" : control.Name.ToLowerInvariant();
            if (IsPhoneName(name))
            {
                chars = 12;
                if (box != null && box.MaxLength >= 8 && box.MaxLength <= 16)
                {
                    chars = box.MaxLength;
                }
            }
            else if (box != null && box.MaxLength >= 8 && box.MaxLength <= 16)
            {
                chars = box.MaxLength;
            }
            else if (control is ComboBox && (name.Contains("desc") || name.Contains("customer") || name.Contains("supplier") || name.Contains("part") || name.Contains("vehicle")))
            {
                chars = 18;
            }
            if (chars <= 0)
            {
                return control.Width;
            }
            string sample = chars <= 3 ? new string('0', chars) : "076" + new string('5', chars - 3);
            Size measured = TextRenderer.MeasureText(sample, control.Font);
            return measured.Width + 18;
        }

        public static void StylePrimary(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = PrimaryHover;
            button.FlatAppearance.MouseDownBackColor = PrimaryHover;
            button.BackColor = Primary;
            button.ForeColor = Color.White;
            button.Font = FontBold;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
            button.BackgroundImage = null;
        }

        public static void StyleSecondary(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Line;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(243, 244, 246);
            button.BackColor = Color.White;
            button.ForeColor = Muted;
            button.Font = FontBold;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
            button.BackgroundImage = null;
        }

        public static void StyleInput(TextBox box)
        {
            box.Font = Font;
            box.BorderStyle = BorderStyle.FixedSingle;
            box.ForeColor = Ink;
            box.BackColor = box.ReadOnly ? InputReadOnly : Color.White;
            Form owner = box.FindForm();
            if (owner != null && owner.Name == "frm_UserLogIn")
            {
                box.TextAlign = HorizontalAlignment.Left;
            }
        }

        public static void RoundPanel(Panel panel, int radius)
        {
            ApplyRound(panel, radius);
            panel.Resize += delegate { ApplyRound(panel, radius); };
        }

        public static void StyleGrid(DataGridView grid)
        {
            if (grid == null || grid.IsDisposed)
            {
                return;
            }
            grid.EnableHeadersVisualStyles = false;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = GridLine;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersHeight = 36;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = FontBold;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            grid.DefaultCellStyle.Font = Font;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Ink;
            grid.DefaultCellStyle.SelectionBackColor = GridSelect;
            grid.DefaultCellStyle.SelectionForeColor = Ink;
            grid.AlternatingRowsDefaultCellStyle.BackColor = GridAlt;
            grid.AlternatingRowsDefaultCellStyle.ForeColor = Ink;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = GridSelect;
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Ink;
            grid.RowTemplate.Height = 32;
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.DefaultCellStyle.BackColor = Color.White;
                column.DefaultCellStyle.ForeColor = Ink;
                column.DefaultCellStyle.Font = Font;
                column.DefaultCellStyle.SelectionBackColor = GridSelect;
                column.DefaultCellStyle.SelectionForeColor = Ink;
            }
        }

        private static void StyleChildren(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                Button button = control as Button;
                TextBox box = control as TextBox;
                ComboBox combo = control as ComboBox;
                Label label = control as Label;
                DataGridView grid = control as DataGridView;
                if (button != null)
                {
                    StyleButton(button);
                }
                else if (box != null)
                {
                    StyleInput(box);
                }
                else if (combo != null)
                {
                    combo.FlatStyle = FlatStyle.Flat;
                    combo.Font = Font;
                    combo.BackColor = Color.White;
                    combo.ForeColor = Ink;
                }
                else if (label != null && label.Font != null && label.Font.Name != "Segoe MDL2 Assets")
                {
                    label.Font = new Font("Segoe UI", label.Font.Size, label.Font.Style, GraphicsUnit.Point);
                }
                else if (grid != null)
                {
                    grid.DataBindingComplete -= OnGridBound;
                    grid.DataBindingComplete += OnGridBound;
                    StyleGrid(grid);
                }
                if (control.HasChildren)
                {
                    StyleChildren(control);
                }
            }
        }

        private static void OnGridBound(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid == null || grid.IsDisposed || !grid.IsHandleCreated)
            {
                return;
            }
            grid.BeginInvoke(new MethodInvoker(delegate
            {
                StyleGrid(grid);
            }));
        }

        private static void StyleButton(Button button)
        {
            if (button.Name.StartsWith("nav"))
            {
                return;
            }
            string text = button.Text.Replace("&", "");
            if (button.Name == "btn_Quit" || button.Name == "btn_Clear" || text.IndexOf("Close", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Quit", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                StyleSecondary(button);
            }
            else if (button.Name == "btn_LogIn" || button.Name == "btn_Add" || text.IndexOf("Save", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Print", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Log In", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                StylePrimary(button);
            }
            else
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.BorderColor = Line;
                button.BackColor = Color.White;
                button.ForeColor = Ink;
                button.Font = FontBold;
                button.Cursor = Cursors.Hand;
                button.UseVisualStyleBackColor = false;
            }
        }

        private static void ApplyRound(Panel panel, int radius)
        {
            Rectangle bounds = panel.ClientRectangle;
            if (bounds.Width < radius * 2 || bounds.Height < radius * 2)
            {
                return;
            }
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(bounds.Width - diameter, 0, diameter, diameter, 270, 90);
            path.AddArc(bounds.Width - diameter, bounds.Height - diameter, diameter, diameter, 0, 90);
            path.AddArc(0, bounds.Height - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            Region previous = panel.Region;
            panel.Region = new Region(path);
            path.Dispose();
            if (previous != null)
            {
                previous.Dispose();
            }
        }
    }
}
