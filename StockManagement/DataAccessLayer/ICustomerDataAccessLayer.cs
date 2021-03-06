﻿using StockManagement.DataAccessLayer;
using System.Collections.Generic;

namespace StockManagement.DataAccessLayer
{
    interface ICustomerDataAccessLayer
    {
        //Login
        int IsValid(LoginData LoginData);
        //Return all the customers
        List<CustomerDataObjects> GetCustomers();

        //Add or Update given customer
        void UpdateCustomer(CustomerDataObjects customer);

        //Delete customer
        void DeleteCustomer(CustomerDataObjects customer);
    }
}
