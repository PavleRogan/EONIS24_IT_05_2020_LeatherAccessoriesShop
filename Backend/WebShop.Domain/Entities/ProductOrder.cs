using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Domain.Entities;

public class ProductOrder
{
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }

    public Product Product { get; set; } = default!;
    public Order Order { get; set; } = default!;
}
