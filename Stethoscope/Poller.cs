using Stethoscope.Sensors;
using System.Data.SqlClient;

namespace Stethoscope
{
    public class Poller<T>
    {
        private SqlConnection _connection;
        private ISensor<T> _sensor;

        public Poller(SqlConnection connection, ISensor<T> sensor)
        {
            _connection = connection;
            _sensor = sensor;   
        }
    }
}
