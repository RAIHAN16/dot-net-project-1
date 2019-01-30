using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class StockOutGateway:BaseGateway
    {

        public int StockOutEntry(string actionType, double quantity, int itemId)                //Storing stock out Quantity
        {
            string query = "INSERT INTO StockOuts(ActionType,Quantity,ItemId) VALUES(@actionType, @quantity,@itemId)";
            Command = new SqlCommand(query, Connetion);
            Command.Parameters.AddWithValue("actionType", actionType);
            Command.Parameters.AddWithValue("quantity", quantity);
            Command.Parameters.AddWithValue("itemId", itemId);

            Connetion.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connetion.Close();

            return rowAffected;
        }
    }
}