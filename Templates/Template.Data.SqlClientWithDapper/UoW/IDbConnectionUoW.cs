using System;
using System.Data;
using System.Threading.Tasks;

namespace Template.Data.SqlClientWithDapper.UoW
{
    public interface IDbConnectionUoW
    {
        TResult Execute<TResult>(Func<IDbConnection, TResult> func);

        Task<TResult> ExecuteAsync<TResult>(Func<IDbConnection, Task<TResult>> func);
    }
}
