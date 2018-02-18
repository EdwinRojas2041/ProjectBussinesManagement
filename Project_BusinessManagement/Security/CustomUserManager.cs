﻿using Microsoft.AspNet.Identity;
using Project_BusinessManagement.Models;
using System.Threading.Tasks;

namespace Project_BusinessManagement.Security
{
    public class CustomUserManager : UserManager<MUser>
    {
        public CustomUserManager() : base(new CustoMUserStore())
        {
            //We can retrieve Old System Hash Password and can encypt or decrypt old password using custom approach. 
            //When we want to reuse old system password as it would be difficult for all users to initiate pwd change as per Idnetity Core hashing. 
            this.PasswordHasher = new OldSystemPasswordHasher();
        }

        public async Task<MUser> FindUserAsync(string pUserName, string pPassword)
        {
            MUser lUser = new MUser();
            lUser = await FindByNameAsync(pUserName);
            if (lUser != null)
            {
                PasswordVerificationResult result = PasswordHasher.VerifyHashedPassword(lUser.LPasswordHash, pPassword);
                if (result == PasswordVerificationResult.Success)
                {
                    return lUser;
                }
                return null;
            }
            return lUser;
        }
    }

    /// <summary> 
    /// Use Custom approach to verify password 
    /// </summary> 
    public class OldSystemPasswordHasher : PasswordHasher
    {
        public override string HashPassword(string password)
        {
            return base.HashPassword(password);
        }

    }
}
