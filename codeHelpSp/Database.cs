using CustomerManageSystemAFC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerManageSystemAFC.DataAccessLayer
{
    public class Database
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);

        //ADD
        public void addCustomer(Customer model)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_Customer_add", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@FName", model.FName);
                com.Parameters.AddWithValue("@LName", model.LName);
                com.Parameters.AddWithValue("@NIC", model.NIC);
                com.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                com.Parameters.AddWithValue("@Birthday", model.Birthday);
                com.Parameters.AddWithValue("@Email", model.Email);
                com.Parameters.AddWithValue("@Address", model.Address);
                com.Parameters.AddWithValue("@lastID", ParameterDirection.Output);
                con.Open();
                com.ExecuteNonQuery();

                var orderID = com.Parameters["@lastID"].Value;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        //View All
        public DataSet getAll()
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_Customer_getAll", con);
                com.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        //Update
        public void updateCustomer(Customer model)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_Customer_update", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@CustomerID", model.customerID);
                com.Parameters.AddWithValue("@FName", model.FName);
                com.Parameters.AddWithValue("@LName", model.LName);
                com.Parameters.AddWithValue("@NIC", model.NIC);
                com.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                com.Parameters.AddWithValue("@Birthday", model.Birthday);
                com.Parameters.AddWithValue("@Email", model.Email);
                com.Parameters.AddWithValue("@Address", model.Address);
                com.Parameters.AddWithValue("@lastID", ParameterDirection.Output);
                con.Open();
                com.ExecuteNonQuery();

                var orderID = com.Parameters["@lastID"].Value;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }


        //Use to Get By ID
        public DataSet getById(int CustomerID)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_Customer_getById", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@CustomerID", CustomerID);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }


        //Use to Get By NIC
        public DataSet getByNIC(string NIC)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_Customer_getByNIC", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@NIC", NIC);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}