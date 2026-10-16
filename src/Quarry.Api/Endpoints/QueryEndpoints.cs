using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Quarry.Api.Contracts;
using Quarry.Core.Providers;

namespace Quarry.Api.Endpoints
{
    public static class QueryEndpoints
    {
        public static void MapQueryEndPoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/query");

            group.MapPost("/",ExecuteQuery);
        }

        private static async Task<IResult> ExecuteQuery(QueryRequest request ,IServiceProvider service,CancellationToken token)
        {
            var provider = service.GetRequiredKeyedService<IDatabaseProvider>(request.Kind);

            try
            {
                var result = await provider.ExecuteAsync(request.ConnectionString,request.Sql,token);
                return Results.Ok(result);
            }
            catch (DbException ex)
            {
                
                return Results.BadRequest(new {error = ex.Message});
            }
        }
    }
}