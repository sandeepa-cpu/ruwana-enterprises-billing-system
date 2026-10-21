using System;
using System.Data.SqlClient;
using System.Xml;

namespace Billing_Inventory_Management_System
{
    class Connection
    {
        public class DatabaseConnection
        {
            private SqlConnection sqlDBConnection;

            public SqlConnection Connect()
            {
                XmlDocument xmldocMessage = new XmlDocument();
                Billing_Inventory_Management_System.FilePath objFilePath = new Billing_Inventory_Management_System.FilePath();
                xmldocMessage.Load(objFilePath.ConfigurationFilePath());

                XmlElement root = xmldocMessage.DocumentElement;
                XmlNode xmlNode = root.SelectSingleNode("descendant::Database[@Title='DBSetting']");
                if (xmlNode == null || xmlNode["IPAddress"] == null || xmlNode["DBName"] == null)
                {
                    throw new ApplicationException("Configuration file specified not in proper format. Recheck the entries");
                }

                string userId = xmlNode["UserId"] != null ? xmlNode["UserId"].InnerText : "";
                string password = xmlNode["Password"] != null ? xmlNode["Password"].InnerText : "";
                if (userId.Length == 0 || password.Length == 0)
                {
                    throw new ApplicationException("Database user or password is missing from Configuration.xml");
                }

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = xmlNode["IPAddress"].InnerText;
                builder.InitialCatalog = xmlNode["DBName"].InnerText;
                builder.UserID = userId;
                builder.Password = password;
                builder.PersistSecurityInfo = true;
                builder.Pooling = true;

                sqlDBConnection = new SqlConnection(builder.ConnectionString);
                sqlDBConnection.Open();
                return sqlDBConnection;
            }
        }
    }
}
