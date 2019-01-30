using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProjectApp.DAL.Gateway;
using StockManagementProjectApp.DAL.Modals;
using StockManagementProjectApp.UI;

namespace StockManagementProjectApp.BLL
{
    
    public class CatagoryManager
    {
        CatagoryGateway catagoryGateway = new CatagoryGateway();

        public string SaveCatagory(Catagory catagory)               //Checking Saving succesful or not
        {
            if (catagoryGateway.IsCatagoryExist(catagory.CatagoryName))
            {
                return "Catagory Already Exist...";
            }
            int rowAffect = catagoryGateway.SaveCatagory(catagory);
            if (rowAffect > 0)
            {
                  return "Save Succesful";
            }
            return "Save Failed";           
        }

        public List<Catagory> GetAllCatagories()
        {
            return catagoryGateway.GetAllCatagories();
        }

        public Catagory GetCatagoryById(int id)
        {
            return catagoryGateway.GetCatagoryById(id);
        }

        public string UpdateCatagoryById(Catagory catagory)
        {
            if (catagoryGateway.IsCatagoryExist(catagory.CatagoryName))
            {
                return "Exist";
            }
            if (catagory != null)
            {
                int rowAffected = catagoryGateway.UpdateCatagoryById(catagory);
                if (rowAffected>0)
                {
                    return "Succesful";
                }

                return "Failed";
            }
            else
            {
                return "nothing";
            }
        }
    }
}