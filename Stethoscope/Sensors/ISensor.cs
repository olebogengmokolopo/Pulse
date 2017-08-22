using System.Collections.Generic;
using Monitor.Models;

namespace Stethoscope.Sensors
{
    public interface ISensor<out T> where T : ISensorReading
    {
        IEnumerable<T> MakeReading();
    }
}
