using MyProject.Models;
using MyProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController(AuthenticationService authenticationService, UserValidationService validationService) : ControllerBase {

    private readonly AuthenticationService _authenticationService = authenticationService;
    private readonly UserValidationService _validationService = validationService;

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model) {
        var user = _validationService.ValidateLogin(model);
        if (user == null || user.Id == null) return Unauthorized();

        if (user.Tenants.Count == 1 && user.Tenants[0].Id != null) {
            var token = _authenticationService.GenerateJwtToken(user.Id.Value, user.Tenants[0].Id!.Value);
            return Ok(new { Token = token });
        }

        var sessionId = Guid.NewGuid().ToString();
        _validationService.CreateTempSession(sessionId, user.Id.Value);

        return Ok(new {sessionId});
    }

    [HttpPost("selectTenant")]
    public async Task<IActionResult> SelectTenant([FromBody] LoginTenantModel model) {
        var user = await _validationService.LoadTempSession(model.SessionId, model.TenantId);
        if (user == null || user.Id == null) return Unauthorized();

        var token = _authenticationService.GenerateJwtToken(user.Id.Value, model.TenantId);
        return Ok(new { Token = token });
    }
    
}
