using System;
using System.IO;
using System.Windows.Forms;

namespace Billing_Inventory_Management_System
{
    public static class AppLog
    {
        public static void Write(string form, Exception ex)
        {
            try
            {
                string dir = Path.Combine(Application.StartupPath, "Logs");
                Directory.CreateDirectory(dir);
                string line = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    + " [" + form + "] "
                    + ex
                    + Environment.NewLine;
                File.AppendAllText(Path.Combine(dir, "app.log"), line);
            }
            catch
            {
            }
        }
    }
}
