using ecommerce_v2.Db;
using ecommerce_v2.Models;

namespace ecommerce_v2.Services;

public class ProductService(AppDbContext context) : Repository<Product>(context);