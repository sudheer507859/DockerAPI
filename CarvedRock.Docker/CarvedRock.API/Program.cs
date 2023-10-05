using CarvedRock.API.Domain;
using CarvedRock.API.Interfaces;
using CarvedRock.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetConnectionString("db");

builder.Configuration.GetValue<string>("SimpleProperty");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inject all our services
builder.Services.AddScoped<IProduct, ProductLogic>();
builder.Services.AddScoped<IQuickOrder, QuickOrderLogic>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
