using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using StockManagementProjectApp.DAL.Modals;

namespace StockManagementProjectApp.BLL
{
    public class LoginManager
    {
        private SqlConnection connection;
        private SqlCommand command;
     

        public LoginManager()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["StockManagementProjectDBConString"]
                .ConnectionString;                                      //Loading connectionString from Web.config
            connection = new SqlConnection(connectionString);
        }

        public DataTable UserLogin(Login aLogin)
        {
            DataTable dt = new DataTable();
            connection.Open();
            command = new SqlCommand("SELECT * FROM Login WHERE  UserName ='"+aLogin.UserName+"' and Password = '"+aLogin.Password+"'",connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            return dt;
       
        }




    }
}