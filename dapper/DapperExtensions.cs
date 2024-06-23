using System.Data;
using Dapper;

namespace MyProject.Dapper;

public static class DapperExtensions {

    public static IEnumerable<T> QueryStoredProcedure<T>(this IDbConnection db, string storedProcedure, object? parameters = null) {
        return db.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public static async Task<IEnumerable<T>> QueryStoredProcedureAsync<T>(this IDbConnection db, string storedProcedure, object? parameters = null) {
        return await db.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public static async Task<DataRow> ExecuteDataRowAsync(this IDbConnection db, string storedProcedure, object? parameters = null) {
        using var reader = await db.ExecuteReaderAsync(storedProcedure, parameters);
        var dataTable = new DataTable();
        dataTable.Load(reader);
        return dataTable.Rows[0];
    }

    public static async Task<DataTable> ExecuteDataTableAsync(this IDbConnection db, string storedProcedure, object? parameters = null) {
        using var reader = await db.ExecuteReaderAsync(storedProcedure, parameters);
        var dataTable = new DataTable();
        dataTable.Load(reader);
        return dataTable;
    }

    public static async Task<List<DataTable>> ExecuteDataTablesAsync(this IDbConnection db, string storedProcedure, object? parameters = null) {
        using var reader = await db.ExecuteReaderAsync(storedProcedure, parameters);

        var result = new List<DataTable>();
        do {
            var dataTable = new DataTable();
            dataTable.Load(reader);
            result.Add(dataTable);
        } while (!reader.IsClosed);

        return result;
    }

    public static int ExecuteStoredProcedure(this IDbConnection db, string storedProcedure, object? parameters = null) {
        return db.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public static async Task<int> ExecuteStoredProcedureAsync(this IDbConnection db, string storedProcedure, DynamicParameters? parameters = null) {
        return await db.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public static async Task<string> ExecuteScalarStringAsync(this IDbConnection db, string storedProcedure, object? parameters = null) {
        string? result = await db.ExecuteScalarAsync<string>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        return result ?? string.Empty;
    }

    public static async Task<int?> ExecuteScalarIntAsync(this IDbConnection db, string storedProcedure, object? parameters = null) {
        return await db.ExecuteScalarAsync<int?>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

}
