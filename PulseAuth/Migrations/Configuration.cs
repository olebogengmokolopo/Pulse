using PulseAuth.Entities;
using PulseAuth.SeedData;

namespace PulseAuth.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PulseAuth.Contexts.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PulseAuth.Contexts.AuthContext context)
        {
            var systemUser = context.Set<ApplicationUser>().SingleOrDefault(x => x.UserName == "SystemUser");
            if (systemUser == null)
            {
                systemUser = UserSeedData.Create(context);
                context.SaveChanges();
            }
        }
    }
}
