﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models
{
    public class MOrder
    {
        private int lIdOrder;
        private DateTime lCreationDate;
        private MStatus lStatus;
        private MObject lObject;
        private MInventory lInventory;
        private MCustomer lCustomer;
        private string lMessageException;
        private List<MOrderItem> lListOrderItem;

        public int LIdOrder
        {
            get
            {
                return lIdOrder;
            }

            set
            {
                lIdOrder = value;
            }
        }

        public DateTime LCreationDate
        {
            get
            {
                return lCreationDate;
            }

            set
            {
                lCreationDate = value;
            }
        }

        public MStatus LStatus
        {
            get
            {
                return lStatus;
            }

            set
            {
                lStatus = value;
            }
        }

        public MObject LObject
        {
            get
            {
                return lObject;
            }

            set
            {
                lObject = value;
            }
        }

        public MInventory LInventory
        {
            get
            {
                return lInventory;
            }

            set
            {
                lInventory = value;
            }
        }

        public MCustomer LCustomer
        {
            get
            {
                return lCustomer;
            }

            set
            {
                lCustomer = value;
            }
        }

        public string LMessageException
        {
            get
            {
                return lMessageException;
            }

            set
            {
                lMessageException = value;
            }
        }

        public List<MOrderItem> LListOrderItem
        {
            get
            {
                return lListOrderItem;
            }

            set
            {
                lListOrderItem = value;
            }
        }
    }
}