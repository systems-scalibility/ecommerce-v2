using System.Linq.Expressions;
using ecommerce_v2.Db;
using ecommerce_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_v2.Services;

public class SalesOrderItemService(AppDbContext context) : Repository<SalesOrderItem>(context);