using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Billing_Inventory_Management_System
{
    public static class FormActions
    {
        public static void Standardize(Form form)
        {
            Size actionSize = new Size(110, 36);
            Button add = Find(form, "btn_Add");
            if (add != null && add.Text.IndexOf("Add", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                add.Text = "Save";
            }
            if (add != null)
            {
                add.Size = actionSize;
                UiTheme.StylePrimary(add);
            }

            Button quit = Find(form, "btn_Quit");
            if (quit != null)
            {
                quit.Text = "Close";
                quit.Size = actionSize;
                UiTheme.StyleSecondary(quit);
            }

            Button clear = Find(form, "btn_Clear");
            if (quit != null && clear == null)
            {
                clear = new Button();
                clear.Name = "btn_Clear";
                clear.Text = "Clear";
                clear.Size = actionSize;
                clear.Location = new Point(Math.Max(8, quit.Left - actionSize.Width - 8), quit.Top);
                clear.Anchor = quit.Anchor;
                clear.Click += delegate
                {
                    foreach (TextBox box in AllTextBoxes(form))
                    {
                        if (box.Name.StartsWith("txt", StringComparison.OrdinalIgnoreCase))
                        {
                            box.Clear();
                        }
                    }
                };
                quit.Parent.Controls.Add(clear);
            }
            if (clear != null)
            {
                clear.Size = actionSize;
                UiTheme.StyleSecondary(clear);
            }
        }

        private static Button Find(Control parent, string name)
        {
            foreach (Control control in parent.Controls)
            {
                Button button = control as Button;
                if (button != null && button.Name == name)
                {
                    return button;
                }
                Button nested = Find(control, name);
                if (nested != null)
                {
                    return nested;
                }
            }
            return null;
        }

        private static List<TextBox> AllTextBoxes(Control parent)
        {
            List<TextBox> boxes = new List<TextBox>();
            Collect(parent, boxes);
            return boxes;
        }

        private static void Collect(Control parent, List<TextBox> boxes)
        {
            foreach (Control control in parent.Controls)
            {
                TextBox box = control as TextBox;
                if (box != null)
                {
                    boxes.Add(box);
                }
                Collect(control, boxes);
            }
        }
    }
}
