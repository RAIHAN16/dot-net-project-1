using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementProjectApp.DAL.Modals.ViewModel;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class ViewBetweenTwoDateGateway : BaseGateway
    {
        public List<StockOutViewModel> GetSellBetweenTwoDate(string fromDate, string toDate,string actionType)
        {
            string query = "SELECT * FROM StockOutView WHERE Date BETWEEN @fromDate AND @todate AND ActionType = @actionType";
            Command = new SqlCommand(query,Connetion);
            Command.Parameters.AddWithValue("@fromDate", fromDate);
            Command.Parameters.AddWithValue("@todate", toDate);
            Command.Parameters.AddWithValue("@actionType", actionType);

            List<StockOutViewModel> StockOutList = new List<StockOutViewModel>();
            Connetion.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                StockOutViewModel stockOut = new StockOutViewModel();
                stockOut.ItemId = Convert.ToInt32(Reader["ItemId"]);
                stockOut.ItemName = Reader["ItemName"].ToString();
                stockOut.AvailableQuantity = Convert.ToDouble(Reader["AvailableQuantity"]);
                stockOut.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                stockOut.CompanyName = Reader["CompanyName"].ToString();
                stockOut.StockOutId = Convert.ToInt32(Reader["StockOutId"]);
                stockOut.ActionType = Reader["ActionType"].ToString();
                stockOut.Quantity = Convert.ToDouble(Reader["Quantity"]);
                stockOut.Date = Reader["Date"].ToString();

                StockOutList.Add(stockOut);
            }
            Connetion.Close();

            return StockOutList;
        }
    }
}