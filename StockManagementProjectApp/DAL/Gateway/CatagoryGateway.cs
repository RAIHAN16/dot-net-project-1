using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementProjectApp.DAL.Modals;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class CatagoryGateway : BaseGateway
    {
        public int SaveCatagory(Catagory catagory)                                      //Mathod for saving Catagory
        {
            string query = "INSERT INTO Catagories(CatagoryName) VALUES(@catagoryName)";
            Command = new SqlCommand(query,Connetion);
            Command.Parameters.AddWithValue("@catagoryName", catagory.CatagoryName);    //Inserting value in a Hackprotected way
            Connetion.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connetion.Close();

            return rowAffect;
        }

        public bool IsCatagoryExist(string catagory)                        //Mathod for making Company unique
        {
            string query = "SELECT * FROM Catagories WHERE CatagoryName = @catagoryName";
            Command = new SqlCommand(query,Connetion);

            Command.Parameters.AddWithValue("@catagoryName", catagory);

            Connetion.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connetion.Close();

            return isExist;
        }

        public List<Catagory> GetAllCatagories()                            //Mathod for Retriving all Catagories from database
        {
            string query = "SELECT * FROM Catagories";
            Command = new SqlCommand(query, Connetion);

            Connetion.Open();
            Reader = Command.ExecuteReader();

            List<Catagory> catagoryList = new List<Catagory>();
            while (Reader.Read())                                           //Reading database row by row
            {
                Catagory catagory = new Catagory();
                catagory.Id = Convert.ToInt32(Reader["Id"]);
                catagory.CatagoryName = Reader["CatagoryName"].ToString();
                catagoryList.Add(catagory);
            }
            Connetion.Close();

            return catagoryList;
        }

        public Catagory GetCatagoryById(int id)                     //Mathod for retriving a catagory using CatagoryId
        {
            string query = "SELECT * FROM Catagories WHERE Id = @id";
            Command = new SqlCommand(query,Connetion);

            Command.Parameters.AddWithValue("@id", id);
            Connetion.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Catagory catagory = null;
            if (Reader.HasRows)
            {
                catagory = new Catagory();
                catagory.Id = Convert.ToInt32(Reader["Id"]);
                catagory.CatagoryName = Reader["CatagoryName"].ToString();
                Connetion.Close();
            }

            return catagory;
        }

        public int  UpdateCatagoryById(Catagory catagory)               //Mathod for Updating a Catagory
        {
            string query = "UPDATE Catagories SET CatagoryName = @catagoryName WHERE Id = @catagoryId";
            Command = new SqlCommand(query,Connetion);
            Command.Parameters.AddWithValue("@catagoryName", catagory.CatagoryName);
            Command.Parameters.AddWithValue("@catagoryId", catagory.Id);

            Connetion.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connetion.Close();

            return rowAffected;
        }
    }
}