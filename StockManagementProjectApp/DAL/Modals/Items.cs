using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementProjectApp.DAL.Modals
{
    [Serializable]
    public class Item
    {
        public int  ItemId { get; set; }
        public string ItemName { get; set; }
        public int ReorderLavel { get; set; }
        public double AvailableQuantity { get; set; }
        public int CompanyId { get; set; }
        public int CatagoryId { get; set; }
    }
}