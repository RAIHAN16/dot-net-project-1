using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProjectApp.BLL;
using StockManagementProjectApp.DAL.Modals;
using Convert = System.Convert;

namespace StockManagementProjectApp.UI
{
    public partial class UpdateCatagoryUI : System.Web.UI.Page
    {
        CatagoryManager catagoryManager = new CatagoryManager();
        private string catagoryLoadedFirst;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)                                        //Condition for executing the code only only First load
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);        //Retriving Id from Query string
                Catagory catagory = catagoryManager.GetCatagoryById(id);
                idHiddenField.Value = catagory.Id.ToString();
                catagoryTextBox.Text = catagory.CatagoryName;
                catagoryLoadedFirst = catagoryTextBox.Text;
                outputLabel.Text = String.Empty;
            }
            catagoryTextBox.Focus();
            
        }

        protected void ValidateTextboxForString()
        {
            string companyName = catagoryTextBox.Text;
            if (companyName.Trim() == "")                        //Validating Null Value
            {
                outputLabel.Text = "Enter Valid Caragory Name";
                catagoryTextBox.Text = String.Empty;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(companyName, "^[a-zA-Z ]"))    //Restricting Inserting only Alphabatic character
            {
                outputLabel.Text = "Enter Valid Caragory Name";
                catagoryTextBox.Text = String.Empty;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            ValidateTextboxForString();
            if (catagoryTextBox.Text.Trim()!="")                                //Restricting Inserting NULL value
            {
                Catagory catagory = new Catagory();
                catagory.Id = Convert.ToInt32(idHiddenField.Value);
                catagory.CatagoryName = catagoryTextBox.Text;
                string result = catagoryManager.UpdateCatagoryById(catagory);
                if (result == "Succesful")
                {
                    catagoryTextBox.Text = String.Empty;
                    Response.Redirect("CatagorySetupUI.aspx");
                }
                else if(result=="Exist")
                {
                    outputLabel.Text = "Catagory already exist.";
                }
                else
                {
                    outputLabel.Text = "Update Failed";
                }
            }

        }
    }
}