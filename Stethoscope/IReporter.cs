using Monitor.Models;

namespace Stethoscope
{
    public interface IReporter
    {
        void Report<T>(T reading) where T : ISensorReading;
    }
}