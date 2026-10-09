using System;
using System.Collections.Generic;
using System.Text;

namespace Billing_Inventory_Management_System
{
    public class FilePath
    {
        public FilePath()
        {
        }

        public string ConfigurationFilePath()//Database and File path
        {
            try
            {
                //return @"C:\Program Files\APSS\Configuration.xml";
                return @"Configuration.xml";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }

    public class NameValue
    {
    }
}