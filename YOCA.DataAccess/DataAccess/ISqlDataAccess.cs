
using Dapper;

namespace YOCA.DataAccess.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<(IEnumerable<T>, int Count)> LoadCountData<T, U>(string storedProcedure, U parameters, string connectionStringName = "Default");
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName = "Default");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName = "Default");
        Task<TResult> LoadMultipleData<TParam, TResult>(string storedProcedure, TParam parameters, Func<SqlMapper.GridReader, Task<TResult>> mapper, string connectionStringName = "Default");
    }
}