using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingmanFleet.DataAccess;
using WingmanFleet.Models; 
//using Westwind.BusinessObjects;

namespace WingmanFleet.Lockdown
{
    /// <summary>
    /// Account repository used to validate and manage user accounts
    /// </summary>

    public class AccountRepository : EntityFrameworkRepository<WingmanContext, ApplicationUser>
    {
        
        public AccountRepository(WingmanContext context)
            : base(context)
        { }
        
        public async Task<bool> Authenticate(string username, string password)
        {
            // TODO: Do proper password hashing - for now DEMO CODE 
            // var hashedPassword = AppUtils.HashPassword(password);
            var hashedPassword = password;

            var user = await Context.Users.FirstOrDefaultAsync(usr => 
                            usr.UserName == username && 
                            usr.Password == hashedPassword);
            if (user == null)
                return false;
            
            return true;
        }

        public async Task<ApplicationUser> AuthenticateAndLoadUser(string username, string password)
        {
            // TODO: Do proper password hashing - for now DEMO CODE 
            // var hashedPassword = AppUtils.HashPassword(password);
            var hashedPassword = password;

            var user = await Context.Users
                          .FirstOrDefaultAsync(usr => usr.UserName == username &&
                                                 usr.Password == hashedPassword);
            return user;
        }        
    }
}
