using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DA_BookStore.Models
{
    public class DBConnection
    {
        String strCon;
        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
        }

        public SqlConnection getConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}