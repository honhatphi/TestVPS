using Microsoft.EntityFrameworkCore;
using Trackify.Common.Api.Results;
using Trackify.Data;
using Trackify.Data.Type.Abs;

namespace Trackify.Common.Api.Filters;
public class EnsureEntityExistsFilter<TRequest, TEntity>(AppDbContext database, Func<TRequest, int?> idSelector) : IEndpointFilter
    where TEntity : class, IEntity
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var request = context.Arguments.OfType<TRequest>().Single();
        var cancellationToken = context.HttpContext.RequestAborted;
        var id = idSelector(request);

        if (!id.HasValue)
        {
            return await next(context);
        }

        var exists = await database
            .Set<TEntity>()
            .AnyAsync(x => x.Id == id, cancellationToken);

        return exists
            ? await next(context)
            : new NotFoundProblem($"{typeof(TEntity).Name} with id {id} was not found.");
    }
}