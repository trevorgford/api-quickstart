namespace MyProject.Models;

public class UserModel : BaseModel {

    public string? Username { get; set; }
    public List<TenantModel> Tenants { get; set; } = [];

}
