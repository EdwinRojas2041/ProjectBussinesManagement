﻿using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;

namespace Bll_Business
{
    public class Bll_Taxe
    {
        public static List<Bo_Taxe>  bll_GetListallTaxesXProduct(int pIdProduct)
        {
            Dao_Taxe oDaoTaxe = new Dao_Taxe();
            return oDaoTaxe.Dao_getLisAllTaxesXProduct(pIdProduct);
        }

        public static List<Bo_Taxe> bll_GetListTaxes()
        {
            Dao_Taxe oDaoTaxe = new Dao_Taxe();
            return oDaoTaxe.Dao_getLisTaxes();
        }

        public static List<Bo_Taxe> bll_GetListTaxesWithOutProduct(int pIdProduct)
        {
            Dao_Taxe oDaoTaxe = new Dao_Taxe();
            return oDaoTaxe.Dao_getLisAllTaxesWithOutProduct(pIdProduct);
        }

        public static string bll_AssociateTaxeXProduct(int pIdProduct, int pIdTaxe)
        {
            Dao_Taxe lDaoTaxe = new Dao_Taxe();
            return lDaoTaxe.Dao_InsertTaxeXProduct(pIdProduct, pIdTaxe);
        }

        public static Bo_Taxe bll_GetTaxe(int pIdTaxe)
        {
            Dao_Taxe lDaoTaxe = new Dao_Taxe();
            return lDaoTaxe.Dao_getTaxeById(pIdTaxe);
        }

        public static string bll_DeleteTaxeXProduct(int pIdProduct, int pIdTaxe)
        {
            Dao_Taxe lDaoTaxe = new Dao_Taxe();
            return lDaoTaxe.Dao_DeleteTaxeXProduct(pIdProduct, pIdTaxe);
        }
    }
}
