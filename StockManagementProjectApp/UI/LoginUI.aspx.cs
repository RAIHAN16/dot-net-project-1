using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using StockManagementProjectApp.BLL;
using StockManagementProjectApp.DAL.Modals;
using System.Data;
namespace StockManagementProjectApp.UI
{
    public partial class LoginUI : System.Web.UI.Page
    {

        LoginManager manager = new LoginManager();
        DataTable dt =new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            Login aLogin = new Login();
            
            aLogin.UserName = userNameTextBox.Text;
            aLogin.Password = passwordTextBox.Text;
            dt = manager.UserLogin(aLogin);
            if (dt.Rows.Count>0)
            {
                Response.Redirect("IndexUI.aspx");
            }
            else
            {
                LoginOutputLabel.Text = "Incorrect User Or Password , Please Try Again ...";
            }
        }
    }
}