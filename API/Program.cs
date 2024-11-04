using API;
using API.Configuration;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
APIConfiguration apiConfiguration = new();
configuration.Bind(apiConfiguration);
builder.Services.Configure<APIConfiguration>(configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger(apiConfiguration);
builder.Services.AddContext(apiConfiguration);
builder.Services.AddRepositories();
builder.Services.ConfigureServices();
builder.Services.AddML();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/predict",
    async (MLModel.ModelInput input) =>
        await Task.FromResult(MLModel.Predict(input)));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();