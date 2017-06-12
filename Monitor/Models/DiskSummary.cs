namespace Monitor.Controllers
{
    public class Disk
    {
        string label;
        string volume;
        float availableSpace;
        float totalSpace;
        float usedSpace;

        public Disk(string label, string volume, float availableSpace, float totalSpace)
        {
            this.label = label;
            this.volume = volume;
            this.availableSpace = availableSpace;
            this.totalSpace = totalSpace;
            usedSpace = totalSpace - availableSpace;
        }
    }
}