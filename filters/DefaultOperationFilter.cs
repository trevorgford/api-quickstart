using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace MyProject.Filters;

public class DefaultOperationFilter : IOperationFilter {

    public void Apply(OpenApiOperation operation, OperationFilterContext context) {
        if (context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor) {
            switch (controllerActionDescriptor.ActionName) {
                case "GetAll":
                    operation.Summary = $"Gets all {controllerActionDescriptor.ControllerName} records";
                    break;
                case "Get":
                    operation.Summary = $"Gets a {controllerActionDescriptor.ControllerName}";
                    break;
                case "Create":
                    operation.Summary = $"Creates a {controllerActionDescriptor.ControllerName}";
                    break;
                case "Delete":
                    operation.Summary = $"Deletes a {controllerActionDescriptor.ControllerName}";
                    break;
                case "Update":
                    operation.Summary = $"Updates a {controllerActionDescriptor.ControllerName}";
                    break;
            }
        }
    }

}
