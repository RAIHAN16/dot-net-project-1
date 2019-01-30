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
    public partial class CatagorySetupUI : System.Web.UI.Page
    {
        private CatagoryManager catagoryManager = new CatagoryManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                catagoryListGridView.DataSource = catagoryManager.GetAllCatagories(); //Loading the GridView
                catagoryListGridView.DataBind();
                catagoryTextBox.Text = String.Empty;
            }
            catagoryTextBox.Focus();
            outputLabel.Text = String.Empty;
        }

        protected void ValidateTextboxForString()
        {
            string companyName = catagoryTextBox.Text;
            if (companyName.Trim() == "")                        //Validating Null Value
            {
                outputLabel.Text = "Enter Valid Catagory Name";
                catagoryTextBox.Text = String.Empty;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(companyName, "^[a-zA-Z ]"))    //Restricting Inserting only Alphabatic character
            {
                outputLabel.Text = "Enter Valid Catagory Name";
                catagoryTextBox.Text = String.Empty;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            ValidateTextboxForString();

            if (catagoryTextBox.Text.Trim() != "") //Restricting Inserting NULL value & Only White space
            {
                Catagory catagory = new Catagory();
                catagory.CatagoryName = catagoryTextBox.Text;
                outputLabel.Text = catagoryManager.SaveCatagory(catagory);
                catagoryTextBox.Text = String.Empty;
                catagoryListGridView.DataSource = catagoryManager.GetAllCatagories(); //Loading the GridView
                catagoryListGridView.DataBind(); //Redirecting to CatagorySetupUI
            }
        }

        protected void catagoryUpdateLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;                     //(Next 4 Line) To retrive a row from linkButton
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField catagoryIdHiddenField = (HiddenField)row.FindControl("catagoryIdHiddenField");

            int id = Convert.ToInt32(catagoryIdHiddenField.Value);

            Response.Redirect("UpdateCatagoryUI.aspx?Id=" + id);             //Redirecting & Sending Query string
        }


    }
}