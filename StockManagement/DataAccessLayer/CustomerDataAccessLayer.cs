
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace StockManagement.DataAccessLayer
{
    class CustomerDataAccessLayer:ICustomerDataAccessLayer
    {
        string Conn_string = ConfigurationManager.ConnectionStrings["Stock_string"].ConnectionString;
        public static SqlConnection conn=null;
       
        public CustomerDataAccessLayer()
        {
            conn = new SqlConnection(Conn_string);
        }
        
        //Return all customers
        public List<CustomerDataObjects> GetCustomers()
        {
            List<CustomerDataObjects> CustomerList = new List<CustomerDataObjects>();
            string st = "Select Customer_ID,FirstName,LastName,Address,Customer_Type from Customer";
            try
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(st, conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            var Customer = new CustomerDataObjects();
                            Customer.Customer_ID =(int) reader["Customer_ID"];
                            Customer.FirstName   =  reader["FirstName"].ToString();
                            Customer.LastName = reader["LastName"].ToString();
                            Customer.Address = reader["Address"].ToString();
                            Customer.Customer_Type = reader["Customer_Type"].ToString();
                            CustomerList.Add(Customer);
                        }
                         
                    }

                }
                
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                conn.Close();
            }
            return CustomerList;
        }

        public void UpdateCustomer(CustomerDataObjects customer)
        {
            List<CustomerDataObjects> CustomerList = new List<CustomerDataObjects>();
            string st1 = "Insert into Customer values (@Customer_ID,@FirstName,@LastName,@Address,@Customer_Type)";

            try
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(st1, conn))
                {
                    comm.Parameters.AddWithValue("@Customer_ID", customer.Customer_ID);
                    comm.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    comm.Parameters.AddWithValue("@LastName", customer.LastName);
                    comm.Parameters.AddWithValue("@Address", customer.Address);
                    comm.Parameters.AddWithValue("@Customer_Type", customer.Customer_Type);
                    comm.ExecuteNonQuery();
                } 

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        public void DeleteCustomer(CustomerDataObjects customer)
        {
            throw new NotImplementedException();
        }
    }
}
