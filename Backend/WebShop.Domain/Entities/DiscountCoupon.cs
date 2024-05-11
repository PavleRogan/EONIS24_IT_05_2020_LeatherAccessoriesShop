using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Domain.Entities;

public class DiscountCoupon
{
    public Guid DiscountCouponId { get; set; }

    public string Code { get; set; } = default!;

    public int Percentage { get; set; }

    public bool IsActive { get; set; }

    public List<Order> Orders { get; set; } = new();

}
