using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.SchemasFilter;

public class ShotSchemaFilter : ISchemaFilter
{
  public void Apply(OpenApiSchema schema, SchemaFilterContext context)
  {
    if (context.Type == typeof(Shot))
    {
      // Add oneOf to the Set property
      schema.Properties["Set"] = new OpenApiSchema
      {
        OneOf = new List<OpenApiSchema>
                {
                    context.SchemaGenerator.GenerateSchema(typeof(PreviousSet), context.SchemaRepository),
                    context.SchemaGenerator.GenerateSchema(typeof(CurrentSet), context.SchemaRepository)
                }
      };

      schema.Properties.Remove("set");
    }
  }
}
