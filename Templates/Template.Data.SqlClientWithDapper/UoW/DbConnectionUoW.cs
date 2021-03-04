using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Template.Data.SqlClientWithDapper.Configurations;

namespace Template.Data.SqlClientWithDapper.UoW
{
    public class DbConnectionUoW : IDbConnectionUoW, IDisposable
    {
        private readonly DatabaseConfiguration _databaseConfiguration;
        private IDbConnection _connection;

        public DbConnectionUoW(DatabaseConfiguration databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
        }

        public TResult Execute<TResult>(Func<IDbConnection, TResult> func)
        {
            return func(GetConnection());
        }

        public async Task<TResult> ExecuteAsync<TResult>(Func<IDbConnection, Task<TResult>> func)
        {
            return await func(GetConnection());
        }

        private IDbConnection GetConnection()
        {
            return OpenConnection();
        }

        private void CreateConnection()
        {
            _connection ??= new SqlConnection(_databaseConfiguration.ConnectionString);
        }

        private IDbConnection OpenConnection()
        {
            CreateConnection();

            if (!_connection.State.Equals(ConnectionState.Open))
            {
                _connection.Open();
            }

            return _connection;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }

}
