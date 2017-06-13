namespace Monitor.Controllers
{
    public class DiskSummary
    {
        public string label { get; }
        public string volume { get; }
        public float availableSpace { get; }
        public float totalSpace { get; }
        public float usedSpace { get; }
        

        public DiskSummary(string label, string volume, float totalSpace, float availableSpace)
        {
            this.label = label;
            this.volume = volume;
            this.availableSpace = availableSpace;
            this.totalSpace = totalSpace;
            usedSpace = totalSpace - availableSpace;
        }
    }
}