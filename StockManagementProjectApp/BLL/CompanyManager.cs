using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProjectApp.DAL.Gateway;
using StockManagementProjectApp.DAL.Modals;

namespace StockManagementProjectApp.BLL
{
    public class CompanyManager
    {
        private CompanyGateway companyGateway = new CompanyGateway();

        public string SaveCompany(Company company)                      //Checking Saving succesful or not
        {
            if (companyGateway.IsCompanyExist(company.CompanyName))
            {
                return "Company Already Exist...";
            }
            int rowAffect = companyGateway.SaveCompany(company);
            if (rowAffect > 0)
            {
                return "Save Succesful";
            }
            return "Save Failed";
        }

        public List<Company> GetAllCompanies()                          //Retrive All Company
        {
            return companyGateway.GetAllCompanies();
        }
    }
}