using Serilog;
using Trackify;

Log.Information("Starting web application");
var builder = WebApplication.CreateBuilder(args);
builder.AddServices();
var app = builder.Build();
await app.Configure();
app.Run();