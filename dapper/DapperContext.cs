using System.Data;
using Microsoft.Data.SqlClient;

namespace MyProject.Dapper;

public class DapperContext {

    private readonly IConfiguration _configuration;
    private readonly string? _connectionString;

    public DapperContext(IConfiguration configuration) {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("MyConnectionString");
    }

    public IDbConnection CreateConnection() {
        return new SqlConnection(_connectionString);
    }

}
