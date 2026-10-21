using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Billing_Inventory_Management_System
{
    public static class AuditLog
    {
        public static void Write(string action, string form, string detail)
        {
            SqlConnection conn = null;
            try
            {
                Connection.DatabaseConnection link = new Connection.DatabaseConnection();
                conn = link.Connect();

                string userId = "";
                SqlCommand who = new SqlCommand("SELECT TOP 1 C_USER FROM [CURRENT_USER]", conn);
                object id = who.ExecuteScalar();
                if (id != null && id != DBNull.Value)
                {
                    userId = id.ToString();
                }

                string userName = "";
                foreach (Form open in Application.OpenForms)
                {
                    frm_MainMenu menu = open as frm_MainMenu;
                    if (menu != null)
                    {
                        userName = menu.lblUser.Text;
                        break;
                    }
                }
                if (userName.Length == 0 && userId.Length > 0)
                {
                    SqlCommand nameCmd = new SqlCommand("SELECT USER_NAME FROM USER_LOGIN WHERE USER_ID = @id", conn);
                    nameCmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = userId;
                    object name = nameCmd.ExecuteScalar();
                    if (name != null && name != DBNull.Value)
                    {
                        userName = name.ToString();
                    }
                }

                if (detail == null)
                {
                    detail = "";
                }
                if (detail.Length > 400)
                {
                    detail = detail.Substring(0, 400);
                }

                SqlCommand insert = new SqlCommand(
                    "INSERT INTO AUDIT_LOG (USER_ID, USER_NAME, ACTION, FORM_NAME, DETAIL) VALUES (@id, @name, @action, @form, @detail)",
                    conn);
                insert.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = userId;
                insert.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = userName;
                insert.Parameters.Add("@action", SqlDbType.VarChar, 20).Value = action;
                insert.Parameters.Add("@form", SqlDbType.VarChar, 80).Value = form;
                insert.Parameters.Add("@detail", SqlDbType.NVarChar, 400).Value = detail;
                insert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                AppLog.Write("AuditLog", ex);
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
