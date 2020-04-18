﻿using CustomAuthenticationMVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
//other namespaces
namespace CustomAuthenticationMVC.DataAccess
{
    public class AuthenticationDB : DbContext
    {
        public AuthenticationDB()
            :base("AuthenticationDB")
        {

        }
        //other ctors
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m =>
                {
                    m.ToTable("UserRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });
        }
        //override other methods
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}