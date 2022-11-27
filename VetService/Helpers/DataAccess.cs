using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Dapper;
using static Dapper.SqlMapper;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Linq;

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

        public T ExecuteScalar<T>(string StoredProcedure)
        {

            try
            {
                OpenConnection();
                T result;
                result = Connection.ExecuteScalar<T>(StoredProcedure, parameters, commandType: CommandType.StoredProcedure);
                Dispose();
                return result;
            }
#pragma warning disable S2737 // "catch" clauses should do more than rethrow
            catch (Exception)
            {
                throw;
            }
#pragma warning restore S2737 // "catch" clauses should do more than rethrow
        }

        public IDataReader Execute(string StoredProcedure)
        {

            try
            {
                OpenConnection();
                IDataReader reader = Connection.ExecuteReader(StoredProcedure, parameters, commandType: CommandType.StoredProcedure);
                return reader;
            }
#pragma warning disable S2737 // "catch" clauses should do more than rethrow
            catch (Exception)
            {
                throw;
            }
#pragma warning restore S2737 // "catch" clauses should do more than rethrow
        }

        public Collection<T> GetList<T>(string pStoredProcedure)
        {
            try
            {
                OpenConnection();
                if (parameters == null)
                {
                    parameters = new DynamicParameters();
                }

                var response = new ObservableCollection<T>(Connection.Query<T>(pStoredProcedure, parameters, commandType: CommandType.StoredProcedure, commandTimeout: 0).ToList());
                Dispose();
                return response;
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
