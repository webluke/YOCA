﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace YOCA.DataAccess.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName = "Default")
    {
        string connectionString = _config.GetConnectionString(connectionStringName) ?? throw new InvalidOperationException("Connection string 'Default' not found.");

        using IDbConnection connection = new SqlConnection(connectionString);

        var rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        return rows;
    }

    public async Task<(IEnumerable<T>, int Count)> LoadCountData<T, U>(string storedProcedure, U parameters, string connectionStringName = "Default")
    {
        string connectionString = _config.GetConnectionString(connectionStringName) ?? throw new InvalidOperationException("Connection string 'Default' not found.");

        using IDbConnection connection = new SqlConnection(connectionString);

        var multiResult = await connection.QueryMultipleAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        var rows = await multiResult.ReadAsync<T>();
        var totalPosts = await multiResult.ReadSingleAsync<int>();
        return (rows, totalPosts);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName = "Default")
    {
        string connectionString = _config.GetConnectionString(connectionStringName) ?? throw new InvalidOperationException("Connection string 'Default' not found.");

        using IDbConnection connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
