using ecommerce_skinet_shop.MembershipModule.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.MembershipModule.SeedData
{
    public class ApplicationContextSeedData
    {
        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    DisplayName = "aamir",
                    Email = "aamir@test.com",
                    UserName = "aamir@test.com",
                    City = "CTG",
                    State = "NY",
                    Street = "10 street main",
                    Zipcode = "9089"
                };
                await userManager.CreateAsync(user, "dev@aamir");
            }
        }
    }
}
