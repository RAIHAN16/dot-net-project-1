using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementProjectApp.DAL.Modals;
using StockManagementProjectApp.DAL.Modals.ViewModel;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class ItemGateway : BaseGateway
    {
        public int SaveItem(Item item)
        {
            string query = "INSERT INTO Items(ItemName,CompanyId,CatagoryId) VALUES(@itemName,@companyId,@catagoryId)";
            Command = new SqlCommand(query, Connetion);
            Command.Parameters.AddWithValue("@itemName", item.ItemName);
            Command.Parameters.AddWithValue("@companyId", item.CompanyId);
            Command.Parameters.AddWithValue("@catagoryId", item.CatagoryId);
            Connetion.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connetion.Close();

            return rowAffect;
        }

        public bool IsItemExist(Item item)
        {
            string query =
                "SELECT * FROM GetAllItemsView WHERE "
                    + "ItemName = @itemName AND CompanyId = @companyId AND CatagoryId = @catagoryId";
            Command = new SqlCommand(query,Connetion);
            Command.Parameters.AddWithValue("@itemName", item.ItemName);
            Command.Parameters.AddWithValue("@companyId", item.CompanyId);
            Command.Parameters.AddWithValue("@catagoryId", item.CatagoryId);

            Connetion.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            bool isExist = Reader.HasRows;
            Connetion.Close();

            return isExist;
        }

        public List<ItemViewModel> GetItemsByCompanyId(int companyId)
        {
            string query = "SELECT * FROM GetAllItemsView WHERE CompanyId = @companyId";
            Command = new SqlCommand(query, Connetion);

            Command.Parameters.AddWithValue("@companyId", companyId);
            Connetion.Open();
            Reader = Command.ExecuteReader();

            List<ItemViewModel> itemList = new List<ItemViewModel>();
            while (Reader.Read())                                           //Reading database row by row
            {
                ItemViewModel item = new ItemViewModel();
                item.ItemId = Convert.ToInt32(Reader["Id"]);
                item.ItemName = Reader["ItemName"].ToString();
                item.ReorderLavel = Convert.ToInt32(Reader["ReorderLavel"]);
                item.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                item.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                item.CompanyName = (Reader["CompanyId"]).ToString();
                item.CatagoryId = Convert.ToInt32(Reader["CatagoryId"]);
                item.CatagoryName = (Reader["CatagoryName"]).ToString();

                itemList.Add(item);
            }
            Connetion.Close();

            return itemList;
        }

        public ItemViewModel GetItemByItemId(int itemId)
        {
            string query = "SELECT * FROM GetAllItemsView WHERE  Id = @itemId";
            Command = new SqlCommand(query, Connetion);
            Command.Parameters.AddWithValue("@itemId", itemId);
            Connetion.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();

            ItemViewModel item = new ItemViewModel();
            item.ItemId = Convert.ToInt32(Reader["Id"]);
            item.ItemName = Reader["ItemName"].ToString();
            item.ReorderLavel = Convert.ToInt32(Reader["ReorderLavel"]);
            item.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
            item.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
            item.CompanyName = (Reader["CompanyName"]).ToString();
            item.CatagoryId = Convert.ToInt32(Reader["CatagoryId"]);
            item.CatagoryName = (Reader["CatagoryName"]).ToString();

            Connetion.Close();

            return item;
        }     

    }
}