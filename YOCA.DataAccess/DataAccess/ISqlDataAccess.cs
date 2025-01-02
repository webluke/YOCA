
namespace YOCA.DataAccess.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName = "Default");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName = "Default");
    }
}