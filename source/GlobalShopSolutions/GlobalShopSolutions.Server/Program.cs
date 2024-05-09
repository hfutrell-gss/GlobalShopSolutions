using GlobalShopSolutions.Server.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging.AddSerilog();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGlobalShopSolutionsServer(
    builder.Configuration
);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseGlobalShopSolutions();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Welcome to the Globe!")
    .WithName("Welcome")
    .WithOpenApi();

app.Run();