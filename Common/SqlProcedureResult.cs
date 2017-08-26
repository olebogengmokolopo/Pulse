using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Common
{
    public class SqlProcedureResult : ProcedureResult<SqlParameter, SqlDataReader>
    {

        public SqlProcedureResult(IEnumerable<SqlParameter> parameters)
            : base(parameters)
        {}

        public SqlProcedureResult(IEnumerable<SqlParameter> parameters, SqlDataReader dataReader)
            : base(parameters, dataReader)
        {}
    }

    public abstract class ProcedureResult<TDbParameter, TDbDataReader> where TDbParameter : DbParameter where TDbDataReader : DbDataReader
    {
        private readonly List<TDbParameter> parameters;

        public IEnumerable<TDbParameter> Parameters => parameters;
        public TDbDataReader DataReader { get; }

        protected ProcedureResult(IEnumerable<TDbParameter> parameters)
        {
            this.parameters = new List<TDbParameter>(parameters);
        }

        protected ProcedureResult(IEnumerable<TDbParameter> parameters, TDbDataReader dataReader)
            :this(parameters)
        {
            DataReader = dataReader;
        }

        public bool HasDataReader => this.DataReader != null;
        public bool HasParameters => this.parameters.Count > 0;
    }
}
