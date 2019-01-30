using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementProjectApp.DAL.Modals.ViewModel;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class SearchAndViewGateway : BaseGateway
    {
        public List<ItemViewModel> GetItemsByCatagoryId(int catagoryId)
        {
            string query = "SELECT * FROM GetAllItemsView WHERE CatagoryId = @catagoryId";
            Command = new SqlCommand(query, Connetion);

            Command.Parameters.AddWithValue("@catagoryId", catagoryId);
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

        public List<ItemViewModel> GetItemsByCompanyIdAndCatagoryId(int companyId, int catagoryId)
        {
            string query = "SELECT * FROM GetAllItemsView WHERE CompanyId = @companyId AND CatagoryId = @catagoryId";
            Command = new SqlCommand(query, Connetion);

            Command.Parameters.AddWithValue("@companyId", companyId);
            Command.Parameters.AddWithValue("@catagoryId", catagoryId);
            Connetion.Open();
            Reader = Command.ExecuteReader();

            if (!Reader.HasRows)
            {
                Connetion.Close();
                return null;
            }
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

        public List<ItemViewModel> GetAllItems()
        {
            string query = "SELECT * FROM Items";
            Command = new SqlCommand(query, Connetion);

            Connetion.Open();
            Reader = Command.ExecuteReader();

            if (!Reader.HasRows)
            {
                Connetion.Close();
                return null;
            }
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

                itemList.Add(item);
            }
            Connetion.Close();

            return itemList;
        }
    }
}