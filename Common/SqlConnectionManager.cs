using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Common
{
    public class SqlConnectionManager
    {
        private readonly string _connectionString;
        private readonly SqlConnection _connection;

        public SqlConnectionManager(string connectionString)
        {
            _connectionString = connectionString;
            _connection = PrepareConnection();
            Connect();
        }

        private SqlConnection PrepareConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private void Connect()
        {
            if (_connection?.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            _connection.Open();
        }

        public SqlProcedureResult ExecuteStoredProcWithReader(string targetStoredProcedure, params SqlParameter[] parameters)
        {
            var cmd = new SqlCommand(targetStoredProcedure, _connection) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddRange(parameters);

            var reader = cmd.ExecuteReader();
            var outParameters = parameters.Where(p =>
                p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.InputOutput).ToList();

            return new SqlProcedureResult(outParameters, reader);
        }
    }
}
