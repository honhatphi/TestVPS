using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Trackify.Common.Api.Extensions;
using Trackify.Common.Api.Results;
using Trackify.Common.Api;
using Trackify.Common.Authentication;
using Trackify.Data.Type;
using Trackify.Data;
using Microsoft.EntityFrameworkCore;

namespace Trackify.Features.Authentication;
public class Signup : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("/signup", Handle)
        .WithSummary("Creates a new user account")
        .WithRequestValidation<Request>()
        .WithEnsureEntityExists<Organization, Request>(x => x.OrganizationId);

    public record Request(string Username, string Password, string Name, int OrganizationId, bool IsAdmin);
    public record Response(string Token);
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    private static async Task<Results<Ok<Response>, ValidationError>> Handle(
        Request request,
        AppDbContext database,
        Jwt jwt,
        IPasswordHasher hasher,
        CancellationToken cancellationToken)
    {
        var isUsernameTaken = await database.Users
            .AnyAsync(x => x.Username == request.Username, cancellationToken);

        if (isUsernameTaken)
        {
            return new ValidationError("Username is already taken");
        }

        var user = new User
        {
            Username = request.Username,
            PasswordHash = hasher.Hash(request.Password),
            DisplayName = request.Name,
            OrganizationId = request.OrganizationId,
            IsAdmin = request.IsAdmin,
            IsLocked = false
        };
        await database.Users.AddAsync(user, cancellationToken);
        await database.SaveChangesAsync(cancellationToken);

        var token = jwt.GenerateToken(user);
        var response = new Response(token);
        return TypedResults.Ok(response);
    }
}
