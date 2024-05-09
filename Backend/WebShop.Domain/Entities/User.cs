using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Domain.Entities;

public class User
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string Salt { get; set; } = default!;
    public Address Address { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public List<Order> Orders { get; set; } = new();

}
