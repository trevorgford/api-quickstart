namespace MyProject.Models;

public class LoginTenantModel {

    public required string SessionId { get; set; }
    public required int TenantId { get; set; }

}
