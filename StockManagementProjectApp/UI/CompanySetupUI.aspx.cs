using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProjectApp.BLL;
using StockManagementProjectApp.DAL.Modals;

namespace StockManagementProjectApp.UI
{
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        private CompanyManager companyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            companyListGridView.DataSource = companyManager.GetAllCompanies();      //Loading the GridView
            companyListGridView.DataBind();
        }

        protected void ValidateTextboxForString()
        {
            string companyName = companyTextBox.Text;
            if (companyName.Trim() == "")                        //Validating Null Value
            {
                outputLabel.Text = "Enter Valid Company Name";
                companyTextBox.Text = String.Empty;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(companyName, "^[a-zA-Z ]"))    //Restricting Inserting only Alphabatic character
            {
                outputLabel.Text = "Enter Valid Company Name";
                companyTextBox.Text = String.Empty;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            ValidateTextboxForString();

            if (companyTextBox.Text.Trim()!= "")                                   //Restricting Inserting NULL value
            {
                Company company = new Company();
                company.CompanyName = companyTextBox.Text;
                outputLabel.Text = companyManager.SaveCompany(company);
                companyTextBox.Text = String.Empty;
                companyListGridView.DataSource = companyManager.GetAllCompanies();      //Loading the GridView
                companyListGridView.DataBind();
            }
        }

    }
}