using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProjectApp.DAL.Gateway;
using StockManagementProjectApp.DAL.Modals.ViewModel;

namespace StockManagementProjectApp.BLL
{
    public class ViewBetweenTwoDatesManager
    {
        ViewBetweenTwoDateGateway viewBetweenTwoDateGateway = new ViewBetweenTwoDateGateway();
        public List<StockOutViewModel> GetSellBetweenTwoDate(string fromDate, string toDate, string actionType)
        {
            return viewBetweenTwoDateGateway.GetSellBetweenTwoDate(fromDate, toDate, actionType);
        }
    }
}