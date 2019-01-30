using System;

namespace StockManagementProjectApp.DAL.Modals.ViewModel
{

    [Serializable]
    public class ItemViewModel : Item  
    {
        public string CompanyName { get; set; }
        public string CatagoryName { get; set; }
    }
}