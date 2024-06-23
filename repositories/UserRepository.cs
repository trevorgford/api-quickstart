using Dapper;
using MyProject.Attributes;
using MyProject.Dapper;
using MyProject.Models;

namespace MyProject.Repositories;

[ModelName("user")]
public class UserRepository(DapperContext context) : BaseRepository<UserModel>(context) {

    public override async Task<int> CreateAsync(UserModel entity, int userId, int tenantId) {
        var parameters = new DynamicParameters();
        parameters.Add("@username", entity.Username);
        // Add other parameters here
        parameters.Add("@userId", userId);
        parameters.Add("@tenantId", tenantId);
        return await CreateAsync(parameters);
    }

}
