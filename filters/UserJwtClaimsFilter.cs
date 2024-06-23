using MyProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyProject.Filters;

public class UserJwtClaimsFilter : IActionFilter {

    public void OnActionExecuting(ActionExecutingContext context) {
        if (context.Controller is not IController controller) return;

        var userClaims = context.HttpContext.User;
        if (userClaims == null || userClaims.Identity == null || !userClaims.Identity.IsAuthenticated) {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userIdClaim = userClaims.Claims.FirstOrDefault(c => c.Type == "UserId");
        var tenantIdClaim = userClaims.Claims.FirstOrDefault(c => c.Type == "TenantId");
        if (userIdClaim == null || tenantIdClaim == null) {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (int.TryParse(userIdClaim.Value, out int userId)) controller.UserId = userId;
        if (int.TryParse(tenantIdClaim.Value, out int tenantId)) controller.TenantId = tenantId;
        else context.Result = new UnauthorizedResult();
    }

    public void OnActionExecuted(ActionExecutedContext context) {
        // Not implemented
    }

}
