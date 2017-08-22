using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Monitor.Models
{
    public class DiskSensorReading : ISensorReading
    {
        public int TenantKey { get; }
        public DateTime Timestamp { get; }
        public string Label { get; }
        public string Volume { get; }
        public float AvailableSpace { get; }
        public float TotalSpace { get; }
        public float UsedSpace { get; }

        public string SensorTarget;
        public string GetSensorTarget()
        {
            return SensorTarget;
        }

        public DiskSensorReading(DateTime timestamp, string label, string volume, float totalSpace, float availableSpace)
        {
            TenantKey = 1;
            Timestamp = timestamp;
            Label = label;
            Volume = volume;
            AvailableSpace = availableSpace;
            TotalSpace = totalSpace;
            UsedSpace = totalSpace - availableSpace;
        }
    }
}