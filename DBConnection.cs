﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public static class DBConnection
    {
        public static SqlConnection getConnection()
        {
            String path = "Data Source=localhost\\SqlExpress;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection con = new SqlConnection(path);
            return con;
        }
    }
}
