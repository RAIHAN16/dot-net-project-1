using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProjectApp.DAL.Gateway;

namespace StockManagementProjectApp.BLL
{
    public class StockInManager
    {
        StockInGateway stockInGateway = new StockInGateway();
        public string StockUpdate(double totalQuantity, int itemId)
        {
            if (stockInGateway.StockUpdate(totalQuantity, itemId) > 0)
            {
                return "Item Stocked";
            }

            return "Item Stock Failed";
        }
    }
}