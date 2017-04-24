﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_InvoiceItem: Bo_Exception
    {
        private int lIdInvoiceItem;
        private int lIdInvoice;
        private Bo_Product lProduct;
        private DateTime lCreationDate;
        private decimal lQuantity;
        private Bo_Status lStatus;
        private Bo_Object lObject;

        public int LIdInvoiceItem
        {
            get
            {
                return lIdInvoiceItem;
            }

            set
            {
                lIdInvoiceItem = value;
            }
        }

        public int LIdInvoice
        {
            get
            {
                return lIdInvoice;
            }

            set
            {
                lIdInvoice = value;
            }
        }

        public Bo_Product LProduct
        {
            get
            {
                return lProduct;
            }

            set
            {
                lProduct = value;
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

        public decimal LQuantity
        {
            get
            {
                return lQuantity;
            }

            set
            {
                lQuantity = value;
            }
        }

        public Bo_Status LStatus
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

        public Bo_Object LObject
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
    }
}