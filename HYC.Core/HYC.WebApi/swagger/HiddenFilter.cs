using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HYC.WebApi.swagger
{
    public class HiddenFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            if (JsonConfig.Configuration.Default.RunEnvironment.ToLower().Equals("product"))
                swaggerDoc.Paths.Clear();
        }
    }
}
