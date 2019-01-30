using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProjectApp.BLL;
using StockManagementProjectApp.DAL.Modals.ViewModel;

namespace StockManagementProjectApp.UI
{
    public partial class StockIn : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        StockInManager stockInManager = new StockInManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TaskOnFirstLoad();
            }           
        }

        private void TaskOnFirstLoad()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompanies();
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataBind();
            companyDropDownList.Items.Insert(0, "Select Company");
            itemDropDownList.Items.Insert(0, "Select Item");


            itemDropDownList.Enabled = false;
            stockInTextbox.Enabled = false;
        }
        
        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex == 0)
            {
                itemDropDownList.Enabled = false;
                stockInTextbox.Enabled = false;
                availableQuantityTextBox.Text = String.Empty;
                reorderLavelTextBox.Text=String.Empty;
                itemDropDownList.SelectedIndex = 0;
            }
            else
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                itemDropDownList.Enabled = true;
                itemDropDownList.DataSource = itemManager.GetItemsByCompanyId(companyId);
                itemDropDownList.DataValueField = "ItemId";
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataBind();
                itemDropDownList.Items.Insert(0, "Select Item");
                
            }
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemDropDownList.SelectedIndex!=0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                stockInTextbox.Enabled = true;
                ItemViewModel item = itemManager.GetItemByItemId(itemId);
                availableQuantityHiddenField.Value = item.AvailableQuantity.ToString();
                reorderLavelTextBox.Text = item.ReorderLavel.ToString();
                availableQuantityTextBox.Text = item.AvailableQuantity.ToString();
                stockInTextbox.Focus();
            }
            else
            {
                stockInTextbox.Enabled = false;
                availableQuantityTextBox.Text = String.Empty;
                reorderLavelTextBox.Text = String.Empty;
            }
        }

        protected void ValidateTextBoxForPositiveNumber()
        {
            string stockInQuantity = stockInTextbox.Text;
  
             if (!System.Text.RegularExpressions.Regex.IsMatch(stockInQuantity, "^[0-9]*$"))    //Restricting Inserting only Alphabatic character
            {
                outputLabel.Text = "Enter Valid Quantity to Stock";
                stockInTextbox.Focus();
                stockInTextbox.Text = String.Empty;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            double availableQuantity = Convert.ToDouble(availableQuantityHiddenField.Value);
            int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);
            
       
            ValidateTextBoxForPositiveNumber();

            if (stockInTextbox.Text.Trim() != "")               //Validating Null Value
            {
                int stockQuantity = Convert.ToInt32(stockInTextbox.Text);
                if (stockQuantity !=0)
                {
                    double totalQuantity = availableQuantity + stockQuantity;
                    string message = stockInManager.StockUpdate(totalQuantity, itemId);
                    outputLabel.Text = message;
                    reorderLavelTextBox.Text = String.Empty;
                    availableQuantityTextBox.Text = String.Empty;
                    itemDropDownList.SelectedIndex = 0;
                    stockInTextbox.Text = String.Empty;
                    TaskOnFirstLoad();
                }                
            }
            
        }

    }
}