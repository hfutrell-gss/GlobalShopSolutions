using GlobalShopSolutions.Server.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

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