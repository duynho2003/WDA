using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace Lab01.Models
{
    public class DatabaseContext
    {
        public SqlConnection connection;
        public SqlConnection SetConnect()
        {
            string str = "server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=WDADB;uid=sa;pwd=123";
            connection = new SqlConnection(str);
            return connection;
        }
    }
}