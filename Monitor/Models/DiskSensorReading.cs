using System;

namespace Monitor.Controllers
{
    public class DiskSensorReading
    {
        public DateTime Timestamp { get; }
        public string Label { get; }
        public string Volume { get; }
        public float AvailableSpace { get; }
        public float TotalSpace { get; }
        public float UsedSpace { get; }
        

        public DiskSensorReading(DateTime timestamp, string label, string volume, float totalSpace, float availableSpace)
        {
            this.Timestamp = timestamp;
            this.Label = label;
            this.Volume = volume;
            this.AvailableSpace = availableSpace;
            this.TotalSpace = totalSpace;
            UsedSpace = totalSpace - availableSpace;
        }
    }
}