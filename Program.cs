using ecommerce_v1.Db;
using ecommerce_v1.Services;
using Microsoft.EntityFrameworkCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseMySQL(connectionString ?? throw new InvalidOperationException("Connection string is null"));
});

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<SalesOrderItemService>();
builder.Services.AddScoped<SalesOrderService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOcelot();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot(); 
app.Run();