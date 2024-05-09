using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Domain.Entities;

public class Product
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string Image { get; set; } = default!; 
    public string Gender { get; set; } = default!;
    public float Price { get; set; }
    public int StockQuantity { get; set; }

    public List<Order> Orders { get; set; } = new();
    public List<ProductOrder> ProductOrders { get; set; } = new();

}
