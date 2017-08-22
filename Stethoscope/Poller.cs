using Stethoscope.Sensors;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
