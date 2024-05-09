using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Domain.Entities;

public class Order
{
    public Guid OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public float TotalPrice { get; set; }

    public string OrderStatus { get; set; } = default!;

    public Address Address { get; set; } = default!;

    public Guid UserId { get; set; }

    public Guid? DiscountCouponId { get; set; }

    public DiscountCoupon? DiscountCoupon { get; set; }

    public User User { get; set; } = default!;

    public List<Product> Products { get; set; } = new();

    public List<ProductOrder> ProductOrders { get; set; } = new();

}
