using ecommerce_v2.Db;
using ecommerce_v2.Models;

namespace ecommerce_v2.Services;

public class SalesOrderService(AppDbContext context) : Repository<SalesOrder>(context);