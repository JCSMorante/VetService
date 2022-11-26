using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Dapper;
using static Dapper.SqlMapper;
using Microsoft.Extensions.Configuration;

namespace VetService.Helpers
{
    public class DataAccess: IDisposable
    {
        private DbConnection Connection;
        private IDynamicParameters parameters;

        public DataAccess(string ConnectionString)
        {
            Connection = new SqlConnection(ConnectionString);
        }

        public void AddParameter(string pName, object pValue, bool isOutputParameter = false)
        {
            try
            {
                parameters = parameters ?? new DynamicParameters();
                ((DynamicParameters)parameters).Add(string.Format("@{0}", pName), pValue, direction: isOutputParameter ? ParameterDirection.Output : ParameterDirection.Input);
            }
#pragma warning disable S2737 // "catch" clauses should do more than rethrow
            catch (Exception)
            {
                throw;
            }
#pragma warning restore S2737 // "catch" clauses should do more than rethrow
        }

        public int Execute(string StoredProcedure)
        {

            try
            {
                OpenConnection();
                int RowsAffected = 0;
                RowsAffected = Connection.ExecuteScalar<int>(StoredProcedure, parameters, commandType: CommandType.StoredProcedure);
                Dispose();
                return RowsAffected;
            }
#pragma warning disable S2737 // "catch" clauses should do more than rethrow
            catch (Exception)
            {
                throw;
            }
#pragma warning restore S2737 // "catch" clauses should do more than rethrow
        }

        private bool OpenConnection()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
                parameters = parameters ?? new DynamicParameters();
            }

            return true;
        }
        public void Dispose()
        {
            if (Connection != null && Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
            parameters = null;
        }
    }
}
