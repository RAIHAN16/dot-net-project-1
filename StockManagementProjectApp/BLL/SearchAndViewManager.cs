using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProjectApp.DAL.Gateway;
using StockManagementProjectApp.DAL.Modals.ViewModel;

namespace StockManagementProjectApp.BLL
{
    public class SearchAndViewManager
    {
        SearchAndViewGateway searchAndViewGateway = new SearchAndViewGateway();

        public List<ItemViewModel> GetItemsByCatagoryId(int catagoryId)
        {
            return searchAndViewGateway.GetItemsByCatagoryId(catagoryId);
        }

        public List<ItemViewModel> GetItemsByCompanyIdAndCatagoryId(int companyId, int catagoryId)
        {
            return searchAndViewGateway.GetItemsByCompanyIdAndCatagoryId(companyId, catagoryId);
        }

        public List<ItemViewModel> GetAllItems()
        {
            return searchAndViewGateway.GetAllItems();
        }
    }
}