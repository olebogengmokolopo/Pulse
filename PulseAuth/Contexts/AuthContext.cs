using System;
using System.Configuration;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PulseAuth.Entities;
using PulseAuth.Mappings;

namespace PulseAuth.Contexts
{
    public class AuthContext : IdentityDbContext
        <ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public AuthContext()
            : base(ConfigurationManager.ConnectionStrings["PulseAuthContext"].ConnectionString)
        {

        }

        public AuthContext Context
        {
            get { return this; }
        }

        public static AuthContext Create()
        {
            return new AuthContext();
        }

        public virtual DbSet<Tenancy> Tenancies { get; set; }
        public virtual DbSet<TenancyUserRole> TenancyUserRoles { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            TenancyMapping.Map(modelBuilder);
            TenancyUserRoleMapping.Map(modelBuilder);
            ApplicationUserMapping.Map(modelBuilder);
        }
    }
}


