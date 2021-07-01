using ecommerce_skinet_shop.MembershipModule.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.MembershipModule.Contexts
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
            string ROLE_ID = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6";

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SuperAdmin",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            // var ApplicationUser = new ApplicationUser
            // {
            //     Id = ADMIN_ID,
            //     Email = "aamir@gmail.com",
            //     EmailConfirmed = true,
            //     UserName = "aamir@gmail.com" 
            //};
            var applicationUser = new ApplicationUser
            {
                Id = ADMIN_ID,
                DisplayName = "aamir",
                Email = "aamir@gmail.com",
                EmailConfirmed = true,
                UserName = "aamir@gmail.com",
                NormalizedEmail="AAMIR@GMAIL.COM",
                NormalizedUserName= "AAMIR@GMAIL.COM",
                City = "CTG",
                State = "NY",
                Street = "10 street main",
                Zipcode = "9089"
            };
            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            applicationUser.PasswordHash = ph.HashPassword(applicationUser, "dev@aamir");

            //seed user
            builder.Entity<ApplicationUser>().HasData(applicationUser);
            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            base.OnModelCreating(builder);
        }
    }
}
