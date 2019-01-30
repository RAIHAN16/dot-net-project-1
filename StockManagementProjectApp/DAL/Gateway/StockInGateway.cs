using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class StockInGateway : BaseGateway
    {
        public int StockUpdate(double totalQuantity, int itemId)
        {
            string query = "UPDATE Items SET AvailableQuantity = @totalQuantity WHERE Id = @id";
            Command = new SqlCommand(query, Connetion);
            Command.Parameters.AddWithValue("@totalQuantity", totalQuantity);
            Command.Parameters.AddWithValue("@id", itemId);
            Connetion.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connetion.Close();

            return rowAffected;
        }
    }
}