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
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        protected CatagoryManager catagoryManager = new CatagoryManager();
        protected CompanyManager companyManager = new CompanyManager();
        protected ItemManager itemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                catagoryDropDownList.DataSource = catagoryManager.GetAllCatagories();

                catagoryDropDownList.DataValueField = "Id";
                catagoryDropDownList.DataTextField = "CatagoryName";
                catagoryDropDownList.DataBind();
                catagoryDropDownList.Items.Insert(0, "Select Catagory");

                companyDropDownList.DataSource = companyManager.GetAllCompanies();
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, "Select Company");

                reorderLavelTextBox.Text = "0";

            }
        }

        protected void ValidateTextboxForString()
        {
            string itemName = itemNameTextBox.Text;
            if (itemName.Trim() == "") //Validating Null Value
            {
                outputLabel.Text = "Enter Valid Catagory Name";
                itemNameTextBox.Text = String.Empty;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(itemName, "^[a-zA-Z ]"))
                //Restricting Inserting only Alphabatic character
            {
                outputLabel.Text = "Enter Valid Catagory Name";
                itemNameTextBox.Text = String.Empty;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            int catagorySelect = catagoryDropDownList.SelectedIndex;
            int companySelect = companyDropDownList.SelectedIndex;

            ValidateTextboxForString();

            string reorderLavel = reorderLavelTextBox.Text;
          
            if (!System.Text.RegularExpressions.Regex.IsMatch(reorderLavel, "^[0-9]*$"))    //Restricting Inserting only Alphabatic character
            {
                outputLabel.Text = "Reorder Lavel Must be Positive Integer";
                reorderLavelTextBox.Focus();
                reorderLavelTextBox.Text = String.Empty;
                return;
            }

            if (catagorySelect != 0 && companySelect!=0 && itemNameTextBox.Text!="")
            {
                Item item = new Item();
                item.ItemName = itemNameTextBox.Text;
                item.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                item.CatagoryId = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                item.ReorderLavel = Convert.ToInt32(reorderLavelTextBox.Text);
                outputLabel.Text = itemManager.SaveItem(item);
                itemNameTextBox.Text = String.Empty;
                reorderLavelTextBox.Text = String.Empty;
                catagoryDropDownList.SelectedIndex = 0;
                companyDropDownList.SelectedIndex = 0;
                reorderLavelTextBox.Text = "0";
            }
            else
            {
                outputLabel.Text = "Fill all field. Reorder lavel can be skipped";
            }
            
        }

        
    }
}