﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;

namespace Bll_Business
{
    public class Bll_Customer
    {
        public static Bo_Customer bll_GetCustomerById(int pIdCustomer)
        {
            Dao_Customer oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_getCustomerById(pIdCustomer);
        }

        public static List<Bo_Customer> bll_GetAllCustomer()
        {
            Dao_Customer oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_getListAllCustomer();
        }

        public static string bll_InsertCustomer(string pNameCustomer, string pLastNameCustomer, string pNoIdentification, int pIdTypeIdentification, int pIdObject, string pIdStatus)
        {
            Bo_Customer oCustomer = new Bo_Customer();
            oCustomer.LObject = new Bo_Object();
            oCustomer.LStatus = new Bo_Status();
            oCustomer.LTypeIdentification = new Bo_TypeIdentification();
            oCustomer.LNameCustomer = pNameCustomer;
            oCustomer.LLastNameCustomer = pLastNameCustomer;
            oCustomer.LNoIdentification = pNoIdentification;
            oCustomer.LTypeIdentification.LIdTypeIdentification = pIdTypeIdentification;
            oCustomer.LObject.LIdObject = pIdObject;
            oCustomer.LStatus.LIdStatus = pIdStatus;
            Dao_Customer oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_InsertCustomer(oCustomer);
        }

        public static string bll_UpdateCustomer(int pIdCustomer, string pNameCustomer, string pLastNameCustomer, string pNoIdentification, int pIdTypeIdentification, int pIdObject, string pIdStatus)
        {
            Bo_Customer oCustomer = new Bo_Customer();
            oCustomer.LObject = new Bo_Object();
            oCustomer.LStatus = new Bo_Status();
            oCustomer.LTypeIdentification = new Bo_TypeIdentification();
            oCustomer.LIdCustomer = pIdCustomer;
            oCustomer.LNameCustomer = pNameCustomer;
            oCustomer.LLastNameCustomer = pLastNameCustomer;
            oCustomer.LNoIdentification = pNoIdentification;
            oCustomer.LTypeIdentification.LIdTypeIdentification = pIdTypeIdentification;
            oCustomer.LObject.LIdObject = pIdObject;
            oCustomer.LStatus.LIdStatus = pIdStatus;
            Dao_Customer oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_UpdateInventory(oCustomer);
        }

        public static string bll_DeleteCustomer(int pIdCustomer)
        {
            Bo_Customer oCustomer = new Bo_Customer();
            oCustomer.LIdCustomer = pIdCustomer;
            Dao_Customer oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_DeleteInventory(oCustomer);
        }
    }
}