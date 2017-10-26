using System.Configuration;
using System.Data.Entity;
using Common.Sensors;
using Monitor.Mappings;

namespace Monitor.Contexts
{
    public class PulseWebContext : DbContext
    {
        public PulseWebContext()
            : base(ConfigurationManager.ConnectionStrings["PulseWebContext"].ConnectionString)
        {

        }

        public PulseWebContext Context
        {
            get { return this; }
        }

        public static PulseWebContext Create()
        {
            return new PulseWebContext();
        }

        public virtual DbSet<DiskSensorReading> DiskSensorReadings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DiskSensorReadingMapping.Map(modelBuilder);
        }
    }
}