using ecommerce_v2.Db;
using ecommerce_v2.Models;
using ecommerce_v2.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Ocelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy => { policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseMySQL(connectionString ?? throw new InvalidOperationException("Connection string is null"));
});


builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<SalesOrderItemService>();
builder.Services.AddScoped<SalesOrderService>();

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Product>("Products");
modelBuilder.EntitySet<SalesOrder>("SalesOrders");
modelBuilder.EntitySet<SalesOrderItem>("SalesOrderItems");

builder.Services.AddControllers()
    .AddOData(opt =>
    {
        opt.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).EnableQueryFeatures(null).AddRouteComponents(
            routePrefix: "odata",
            model: modelBuilder.GetEdmModel()
        );
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.UseRouting();
app.MapControllers();

app.Run();