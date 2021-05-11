using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebAPI.Filters
{
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {        
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            // operation.Parameters.Add(new OpenApiParameter()
            // {
            //     Name = "X-User-Token",
            //     Description = "Access Token",
            //     In = ParameterLocation.Header,
            //     Schema = new OpenApiSchema() { Type = "String" },
            //     Required = true,
            //     Example = new OpenApiString("Tenant ID example")
            // });
        }
    }
}