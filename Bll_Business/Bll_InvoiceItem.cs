﻿using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllInvoiceItem: IInvoiceItem
    {
        public IProduct LiProduct { get; set; }

        public IDaoInvoiceItem LiDaoInvoiceItem { get; set; }

        public BllInvoiceItem()
        {
            this.LiProduct = new BllProduct();
            this.LiDaoInvoiceItem = new DaoInvoiceItem();
        }
        public List<BoInvoiceItem> bll_GetInvoiceItemsByIdInvoice(int pIdInvoice)
        {
            return this.LiDaoInvoiceItem.Dao_getInvoiceItemByIdInvoice(pIdInvoice);
        }

        public List<BoInvoiceItem> bll_ChangeOrderItemToInvoiceItem(List<BoOrderItem> lListOrderItem, BoObject lObjectInvoice)
        {
            var lListInvoiceItem = new List<BoInvoiceItem>();
            lListOrderItem?.ForEach(x =>
            {
                var lInvoiceItem = new BoInvoiceItem
                {
                    LProduct = new BoProduct(),
                    LQuantity = x.LQty,
                    LValueProd = x.LValueProduct,
                    LValueDesc = x.LValueDesc,
                    LValueSupplier = x.LValueSupplier,
                    LValueTaxes = x.LValueTaxes,
                    LObject = lObjectInvoice
                };
                lInvoiceItem.LProduct = this.LiProduct.bll_GetProductByCode(x.LProduct.LCdProduct);
                lListInvoiceItem.Add(lInvoiceItem);
            });
            return lListInvoiceItem;
        }


        public string bll_InsertInvoiceItem(int pIdInvoice, decimal pQuantity, decimal pValueProduct, decimal pValueSupplier, decimal pValueTaxes, decimal pValueDesc, int pIdProduct, int pIdObject, string pIdStatus)
        {
            var lInvoiceItem = new BoInvoiceItem
            {
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus},
                LProduct = new BoProduct {LIdProduct = pIdProduct},
                LIdInvoice = pIdInvoice,
                LQuantity = pQuantity,
                LValueDesc = pValueDesc,
                LValueProd = pValueProduct,
                LValueSupplier = pValueSupplier,
                LValueTaxes = pValueTaxes
            };
            return this.LiDaoInvoiceItem.Dao_InsertInvoiceItem(lInvoiceItem);
        }

        public string bll_UpdateInvoiceTem(int pIdInvoice, int pQuantity, int pIdProduct, int pIdObject, string pIdStatus)
        {
            var lInvoiceItem = new BoInvoiceItem
            {
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus},
                LProduct = new BoProduct {LIdProduct = pIdProduct},
                LIdInvoice = pIdInvoice,
                LQuantity = pQuantity
            };
            return this.LiDaoInvoiceItem.Dao_UpdateInvoiceIem(lInvoiceItem);
        }

        public string bll_DeleteInvoiceItem(int pIdInvoiceItem)
        {
            var lInvoiceItem = new BoInvoiceItem {LIdInvoiceItem = pIdInvoiceItem};
            return this.LiDaoInvoiceItem.Dao_DeleteInvoiceItem(lInvoiceItem);
        }
    }
}
