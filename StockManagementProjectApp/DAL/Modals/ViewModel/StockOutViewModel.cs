using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementProjectApp.DAL.Modals.ViewModel
{
    public class StockOutViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double AvailableQuantity { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int StockOutId { get; set; }
        public string ActionType { get; set; }
        public double Quantity { get; set; }
        public string Date { get; set; }
    }
}