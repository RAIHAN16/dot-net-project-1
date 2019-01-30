using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class BaseGateway
    {
        public SqlConnection Connetion { get; set; }
        public SqlCommand Command{ get; set; }
        public SqlDataReader Reader { get; set; }

        public BaseGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["StockManagementProjectDBConString"]
                    .ConnectionString;                                      //Loading connectionString from Web.config
            Connetion = new SqlConnection(connectionString);
        }
    }
}