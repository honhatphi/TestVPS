    using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Trackify.Common.Api;
using Trackify.Common.Api.Extensions;
using Trackify.Common.Api.Results;
using Trackify.Common.Utils;
using Trackify.Data;
using Trackify.Data.Type;

namespace Trackify.Features.Products;
public class CreateProduct : IEndpoint
{
    // Constants
    private static readonly string SequencePrefix = $"{DateTime.Now:yyyy}-{nameof(Product)}";
    private const int CODE_MAX_LENGTH = 50;
    private const int NAME_MAX_LENGTH = 255;

    // Endpoint Configuration
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("/", Handle)
        .WithSummary("Creates a new product")
        .WithRequestValidation<Request>();

    // Data Models
    public record Request(string Code, string Name, string? Description);
    public record Response(int Id);

    // Validation
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .MaximumLength(CODE_MAX_LENGTH);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(NAME_MAX_LENGTH);
        }
    }

    // Handler
    public static async Task<Results<Ok<Response>, ValidationError>> Handle(
        Request request,
        AppDbContext database,
        IGenerate generate,
        CancellationToken cancellationToken)
    {
        // Check for duplicate code
        if (await IsCodeTaken(request.Code, database, cancellationToken))
        {
            return new ValidationError("Code is already taken");
        }

        // Create and save product
        var product = await CreateProductEntity(request, generate);
        await database.Products.AddAsync(product, cancellationToken);
        await database.SaveChangesAsync(cancellationToken);

        return TypedResults.Ok(new Response(product.Id));
    }

    // Helper Methods
    private static async Task<bool> IsCodeTaken(
        string code,
        AppDbContext database,
        CancellationToken cancellationToken) =>
            await database.Products.AnyAsync(x => x.Code == code, cancellationToken);

    private static async Task<Product> CreateProductEntity(
        Request request,
        IGenerate generate) => new Product
        {
            Code = request.Code,
            Name = request.Name,
            Barcode = await generate.BarcodeEAN13Async(SequencePrefix),
            Description = request.Description
        };
}
