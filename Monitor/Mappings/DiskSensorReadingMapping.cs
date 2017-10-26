using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Common.Sensors;
using PulseAuth.Entities;

namespace Monitor.Mappings
{
    internal class DiskSensorReadingMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiskSensorReading>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<DiskSensorReading>()
                .Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DiskSensorReading>()
                .Property(u => u.TenantId)
                .IsRequired();

            modelBuilder.Entity<DiskSensorReading>()
                .Property(u => u.Timestamp)
                .IsRequired();

            modelBuilder.Entity<DiskSensorReading>()
                .Property(u => u.Label)
                .IsOptional();

            modelBuilder.Entity<DiskSensorReading>()
                .Property(u => u.Volume)
                .IsRequired();

            modelBuilder.Entity<DiskSensorReading>()
                .Property(u => u.AvailableSpace)
                .IsRequired();

            modelBuilder.Entity<DiskSensorReading>()
                .Property(u => u.TotalSpace)
                .IsRequired();
        }
    }
}