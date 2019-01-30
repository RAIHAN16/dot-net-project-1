﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProjectApp.DAL.Gateway;

namespace StockManagementProjectApp.BLL
{
    public class StockOutManager : BaseGateway
    {
        StockOutGateway stockOutGateway = new StockOutGateway();
        public string StockOutEntry(string actionType, double quantity, int itemId)     //Reusable mathod for storing Stock Out quantiy depending on StockOut type
        {
            if (stockOutGateway.StockOutEntry(actionType, quantity, itemId) > 0)
            {
                return "StockOut Entry Succesfull";
            }

            return "StockOut Entry Failed";
        }
    }
}