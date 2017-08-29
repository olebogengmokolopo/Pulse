using PulseAuth.Entities;
using PulseAuth.SeedData;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PulseAuth.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Contexts.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contexts.AuthContext context)
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
