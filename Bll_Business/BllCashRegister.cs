﻿using Dao_BussinessManagement;
using IDaoBusiness.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using IBusiness.Management;

namespace Bll_Business
{
    public class BllCashRegister : ICashRegister
    {
        public IDaoCashRegister LiCashRegister { get; set; }

        public BllCashRegister()
        {
            this.LiCashRegister = new DaoCashRegister();
        }

        public List<BoCashRegister> bll_GetListLastCashRegister()
        {
            return this.LiCashRegister.Dao_getListLastCashRegister();
        }

        public List<BoCashRegister> bll_GetListCashInput()
        {
            return this.LiCashRegister.Dao_getListCashInput();
        }

        public List<BoCashRegister> bll_GetListCashOutputs()
        {
            return this.LiCashRegister.Dao_getListCashOutputs();
        }

        public BoCashRegister bll_GetCash(int pIdCash, bool pIsInput)
        {
            return pIsInput ? this.LiCashRegister.Dao_getCashInput(pIdCash) : this.LiCashRegister.Dao_getCashOutPut(pIdCash);
        }

        public string bll_CreateCashOutput(int pIdCashRegister, decimal pValue, string pDescription)
        {
            var lCashOutPut = new BoCashRegister
            {
                LIdCashRegister = pIdCashRegister,
                LValue = pValue,
                LDescription = pDescription
            };
            return this.LiCashRegister.Dao_InsertCashRegisterOutPut(lCashOutPut);
        }

        public string bll_CreateCashInput(int pIdCashRegister, decimal pValue, string pDescription)
        {
            var lCashOutPut = new BoCashRegister
            {
                LIdCashRegister = pIdCashRegister,
                LValue = pValue,
                LDescription = pDescription
            };
            return this.LiCashRegister.Dao_InsertCashRegisterInput(lCashOutPut);
        }

        public int bll_GetFirstIdCashRegister()
        {
            return this.LiCashRegister.Dao_getFirstIdCashRegister();
        }

        public string bll_DeleteCash(int pIdCash, bool pIsInput)
        {
            var lCash = new BoCashRegister
            {
               LIdCash = pIdCash
            };
            return pIsInput ? this.LiCashRegister.Dao_DeleteCashRegisterInput(lCash) : this.LiCashRegister.Dao_DeleteCashRegisterOutPut(lCash);

        }
    }
}
