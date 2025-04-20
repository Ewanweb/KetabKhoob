 using Common.Application;
 using Common.AspNetCore.Middlewares;
 using Shop.Api.Infrastructure;
 using Shop.Api.Infrastructure.JWTUtil;
 using Shop.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.RegisterShopDependencies(builder.Configuration);
EndPointDiContainer.Init(builder.Services);
CommonBootstrapper.Init(builder.Services);
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseApiCustomExceptionHandler();
app.MapControllers();

app.Run();
