using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProjectApp.BLL;
using StockManagementProjectApp.DAL.Modals.ViewModel;

namespace StockManagementProjectApp.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        private CompanyManager companyManager = new CompanyManager();
        private ItemManager itemManager = new ItemManager();
        private StockOutManager stockOutManager = new StockOutManager();
        private StockInManager stockInManager = new StockInManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TaskOnFirstLoad();
                companyDropDownList.Items.Insert(0, "Select Company");
                itemDropDownList.Items.Insert(0, "Select Item");
            }

        }

        public void TaskOnFirstLoad()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompanies();
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataBind();
            reorderLavelTextBox.Text = String.Empty;
            availableQuantityTextBox.Text = String.Empty;
            itemDropDownList.Enabled = false;
            stockOutTextBox.Enabled = false;
            addButton.Enabled = false;
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                itemDropDownList.Enabled = true;

                itemDropDownList.DataSource = itemManager.GetItemsByCompanyId(companyId);
                itemDropDownList.DataValueField = "ItemId";
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataBind();
                itemDropDownList.Items.Insert(0, "Select Item");
            }
            else
            {
                itemDropDownList.SelectedIndex = 0;
                itemDropDownList.Enabled = false;
                stockOutTextBox.Enabled = false;
                addButton.Enabled = false;
                availableQuantityTextBox.Text = String.Empty;
                reorderLavelTextBox.Text = String.Empty;
            }
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                ItemViewModel itemViewModel = itemManager.GetItemByItemId(itemId);

                addButton.Enabled = true;
                stockOutTextBox.Enabled = true;
                reorderLavelTextBox.Text = itemViewModel.ReorderLavel.ToString();
                availableQuantityTextBox.Text = itemViewModel.AvailableQuantity.ToString();
                stockOutTextBox.Focus();

            }
            else
            {
                addButton.Enabled = false;
                stockOutTextBox.Enabled = false;
                reorderLavelTextBox.Text = String.Empty;
                availableQuantityTextBox.Text = String.Empty;
            }

        }

        protected void ValidateTextBoxForPositiveNumber()
        {
            string stockOutQuantity = stockOutTextBox.Text;
            
            if (!System.Text.RegularExpressions.Regex.IsMatch(stockOutQuantity, "^[0-9]*$"))    //Restricting Inserting only Alphabatic character
            {
                outputLabel.Text = "Enter Valid Quantity";
                stockOutTextBox.Focus();
                stockOutTextBox.Text = String.Empty;
            }
        }
        protected void addButton_Click(object sender, EventArgs e)
        {
            ValidateTextBoxForPositiveNumber();

            if (stockOutTextBox.Text.Trim()=="")
            {
                return;
            }
            int stockOutQuantity = Convert.ToInt32(stockOutTextBox.Text);
            if (stockOutQuantity < 1)                   //Restricting Entering value less than 0
            {
                outputLabel.Text = "Enter Valid Quantity";
                return;
            }

            List<ItemViewModel> itemList = new List<ItemViewModel>();
            int itemId = Convert.ToInt32(Convert.ToInt32(itemDropDownList.SelectedValue));

            ItemViewModel itemViewModel = itemManager.GetItemByItemId(itemId);

            itemViewModel.AvailableQuantity -= stockOutQuantity;

            if (ViewState["itemList"] == null)                  //When nothing is in Viewstate
            {
                if (itemViewModel.AvailableQuantity > 0)        //Insert to itemList if present available quanttity is greater then 0
                {
                    itemList.Add(itemViewModel);
                    stockOutGridView.DataSource = itemList;
                    stockOutGridView.DataBind();
                    stockOutTextBox.Text = String.Empty;
                    ViewState["itemList"] = itemList;
                    outputLabel.Text = String.Empty;
                }
                else
                {
                    outputLabel.Text = "Not enough stock";
                }

            }
            else
            {
                itemList = (List<ItemViewModel>)ViewState["itemList"];     //Retriving Viewstate when there is Data in ViewState

                int pointer = 0;                                           //Pointer that is used to decide if the given itemId already exist or not

                foreach (ItemViewModel item in itemList)                  //This loop iterates to detect duplicate Item and update it
                {
                    if (item.ItemId == itemId)
                    {
                        item.AvailableQuantity -= stockOutQuantity;        //This line update the itemList
                        if (item.AvailableQuantity > 0)
                        {
                            outputLabel.Text = String.Empty;
                            pointer++;
                            break;
                        }

                        outputLabel.Text = "Not enough stock";

                    }
                }

                if (pointer == 0)                                       //This condition will be true if ViewState is not null and Duplicate item not present
                {
                    if (itemViewModel.AvailableQuantity > 0)
                    {
                        outputLabel.Text = String.Empty;
                        itemList.Add(itemViewModel);
                    }
                    else
                    {
                        outputLabel.Text = "Not enough stock";
                    }
                }
                stockOutGridView.DataSource = itemList;
                stockOutGridView.DataBind();
                ViewState["itemList"] = itemList;
                stockOutTextBox.Text = String.Empty;
            }                                                        //after updating available quantity everytime it shoulb be checked if it is not zero


        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            List<ItemViewModel> itemList = (List<ItemViewModel>)ViewState["itemList"];

            if (itemList == null)
            {
                outputLabel.Text = "Please Take Something in Cart";
                return;
            }
            foreach (ItemViewModel item in itemList)
            {
                ItemViewModel itemViewModel = itemManager.GetItemByItemId(item.ItemId);
                double totalStockOut = itemViewModel.AvailableQuantity - item.AvailableQuantity;
                stockInManager.StockUpdate(item.AvailableQuantity, item.ItemId);        //Updating available quantity
                stockOutManager.StockOutEntry("sell", totalStockOut, item.ItemId);      //Storing Stock Out
            }
            outputLabel.Text = "Item Sold";
            ViewState["itemList"] = null;

            TaskOnFirstLoad();
            companyDropDownList.Items.Insert(0, "Select Company");
            itemDropDownList.SelectedIndex = 0;
            stockOutGridView.DataBind();
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            List<ItemViewModel> itemList = (List<ItemViewModel>)ViewState["itemList"];

            if (itemList == null)
            {
                outputLabel.Text = "Please Take Something in Cart";
                return;
            }
            foreach (ItemViewModel item in itemList)
            {
                ItemViewModel itemViewModel = itemManager.GetItemByItemId(item.ItemId);
                double totalStockOut = itemViewModel.AvailableQuantity - item.AvailableQuantity;
                stockInManager.StockUpdate(item.AvailableQuantity, item.ItemId);
                stockOutManager.StockOutEntry("damage", totalStockOut, item.ItemId);
            }
            outputLabel.Text = "Item Damaged";
            ViewState["itemList"] = null;
            TaskOnFirstLoad();
            companyDropDownList.Items.Insert(0, "Select Company");
            itemDropDownList.SelectedIndex = 0;
            stockOutGridView.DataBind();
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            List<ItemViewModel> itemList = (List<ItemViewModel>)ViewState["itemList"];

            if (itemList == null)
            {
                outputLabel.Text = "Please Take Something in Cart";
                return;
            }
            foreach (ItemViewModel item in itemList)
            {
                ItemViewModel itemViewModel = itemManager.GetItemByItemId(item.ItemId);
                double totalStockOut = itemViewModel.AvailableQuantity - item.AvailableQuantity;
                stockInManager.StockUpdate(item.AvailableQuantity, item.ItemId);
                stockOutManager.StockOutEntry("lost", totalStockOut, item.ItemId);
            }
            outputLabel.Text = "Lost Item Entry Added";
            ViewState["itemList"] = null;
            TaskOnFirstLoad();
            companyDropDownList.Items.Insert(0, "Select Company");
            itemDropDownList.SelectedIndex = 0;
            stockOutGridView.DataBind();
        }

    }
}