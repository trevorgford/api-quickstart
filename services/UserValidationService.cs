using Dapper;
using MyProject.Dapper;
using MyProject.Models;

namespace MyProject.Services;

public class UserValidationService(DapperContext context) {
    
    protected readonly DapperContext _context = context;

    public UserModel? ValidateLogin(LoginModel model) {
        // Validate the login

        return null;  
    }

    public void CreateTempSession(string sessionId, int userId) {
        var parameters = new DynamicParameters();
        parameters.Add("@SessionId", sessionId);
        parameters.Add("@UserId", userId);

        using var db = _context.CreateConnection();
        db.Execute("tempSession_create", parameters);
    }

    public async Task<UserModel> LoadTempSession(string sessionId, int tenantId) {
        var parameters = new DynamicParameters();
        parameters.Add("@SessionId", sessionId);
        parameters.Add("@TenantId", tenantId);

        using var db = _context.CreateConnection();
        int? userId = await db.ExecuteScalarIntAsync("tempSession_load", parameters);

        return new UserModel { Id = userId };
    }
    
}
