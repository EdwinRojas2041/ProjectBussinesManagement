﻿using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllUser : IBusinessUser
    {
        public IDaoUser LiDaoUser { get; set; }

        public BllUser()
        {
            this.LiDaoUser = new DaoUser();
        }

        public BoUser bll_GetUserByUser(string pUser)
        {
            return this.LiDaoUser.Dao_getUserByUser(pUser);
        }

        public BoUser bll_GetUserById(int pIdUser)
        {
            return this.LiDaoUser.Dao_getUserById(pIdUser);
        }

        public string bll_InsertUser(BoUser pUser)
        {
            return this.LiDaoUser.Dao_InsertUser(pUser);
        }
    }
}
