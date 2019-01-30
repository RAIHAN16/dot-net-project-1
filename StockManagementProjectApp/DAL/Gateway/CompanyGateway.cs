using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementProjectApp.DAL.Modals;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class CompanyGateway : BaseGateway
    {
        public int SaveCompany(Company company)                                 //Mathod for saving Company
        {
            string query = "INSERT INTO Companies(CompanyName) VALUES(@companyName)";
            Command = new SqlCommand(query,Connetion);
            Command.Parameters.AddWithValue("@companyName", company.CompanyName);
            Connetion.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connetion.Close();

            return rowAffect;
        }

        public bool IsCompanyExist(string company)                              //Mathod for making Company unique
        {
            string query = "SELECT * FROM Companies WHERE CompanyName = @companyName";
            Command = new SqlCommand(query,Connetion);

            Command.Parameters.AddWithValue("@companyName", company);

            Connetion.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connetion.Close();

            return isExist;
        }

        public List<Company> GetAllCompanies()                   //Mathod for Retriving all Catagories from database
        {
            string query = "SELECT * FROM Companies";
            Command = new SqlCommand(query, Connetion);

            Connetion.Open();
            Reader = Command.ExecuteReader();

            List<Company> companyList = new List<Company>();
            while (Reader.Read())                               //Reading database row by row
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(Reader["Id"]);
                company.CompanyName = Reader["CompanyName"].ToString();
                companyList.Add(company);
            }
            Connetion.Close();

            return companyList;
        }
    }
}