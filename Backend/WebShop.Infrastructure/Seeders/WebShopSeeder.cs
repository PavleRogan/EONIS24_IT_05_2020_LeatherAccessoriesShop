using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShop.Infrastructure.Persistence;

namespace WebShop.Infrastructure.Seeders;

internal class WebShopSeeder(WebShopDbContext dbContext) : IWebShopSeeder
{
    private readonly static int iterations = 1000;
    Tuple<string, string> hashedPasswordAndSalt = HashPassword("password");
    Tuple<string, string> hashedPasswordAndSalt2 = HashPassword("password2");
    Tuple<string, string> hashedAdminPasswordAndSalt = HashPassword("admin");
    Guid productId1 = new Guid("B02D6E2E-7C2C-4EB1-963C-1A62042B93FA");
    Guid productId2 = new Guid("AC8F513A-331E-40FE-B047-23C45031F939");
    Guid productId3 = new Guid("AC8F513A-331E-40FE-B047-23C45099F999");
    Guid orderId1 = new Guid("eae7b2a9-a90b-4796-ac8b-14a00c6b92c5");
    Guid orderId2 = new Guid("3728bf70-3f1f-4e5f-becc-483e0e8a2049");
    Guid userId1 = new Guid("2728bf70-3f1f-4e5f-becc-483e0e8a2042");
    Guid userId2 = new Guid("1728bf70-3f1f-4e5f-becc-483e0e8a2041");
    Guid orderItemId1 = new Guid("1228bf70-3f1f-4e5f-becc-483e0e8a2041");
    Guid orderItemId2 = new Guid("1238bf70-3f1f-4e5f-becc-483e0e8a2041");
    Guid couponId = new Guid("12345670-3f1f-4e5f-becc-483e0e8a2041");

    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Products.Any())
            {
                var products = GetProducts();
                dbContext.Products.AddRange(products);
                await dbContext.SaveChangesAsync();
            }
            if (!dbContext.DiscountCoupons.Any())
            {
                var coupons = GetCoupons();
                dbContext.DiscountCoupons.AddRange(coupons);
                await dbContext.SaveChangesAsync();
            }
            if (!dbContext.Users.Any())
            {
                var users = GetUsers();
                dbContext.Users.AddRange(users);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Admins.Any())
            {
                var admins = GetAdmins();
                dbContext.Admins.AddRange(admins);
                await dbContext.SaveChangesAsync();
            }

        }
    }

    private IEnumerable<Product> GetProducts()
    {
        List<Product> products = [
            new(){
                ProductId = productId1,
                Name = "Men's Leather Wallet",
                Description = "Classic men's leather wallet with multiple card slots and a bill compartment.",
                Category = "Wallets",
                Gender = "Male",
                Price = 4200,
                Image = "none",
                StockQuantity = 100
            }, new(){
                  ProductId = productId2,
                Name = "Women's Leather Wallet",
                Description = "Elegant women's leather wallet with compartments for cards, cash, and coins.",
                Category = "Wallets",
                Gender = "Female",
                Image = "none",
                Price = 4200,
                StockQuantity = 80
            }, new(){
                   ProductId = productId3,
                Name = "Leather Pencil Case",
                Description = "Elegant and pretty case for pencils of any kind.",
                Category = "Cases",
                Image = "none",
                Gender = "Unisex",
                Price = 2400,
                StockQuantity = 30
            }
            ];
        return products;
    }
    private IEnumerable<DiscountCoupon> GetCoupons()
    {
        return new List<DiscountCoupon>
            {
                new DiscountCoupon
                {
                   DiscountCouponId = couponId,
                   Code = "SALE123",
                   Percentage = 10,
                   IsActive = true,

                }
            };
    }
    private IEnumerable<Admin> GetAdmins()
    {
        return new List<Admin>
            {
                new Admin
                {
                    AdminId = Guid.NewGuid(),
                    Name = "Admin",
                    Surname = "Adminic",
                    PasswordHash = hashedAdminPasswordAndSalt.Item1,
                    Salt = hashedAdminPasswordAndSalt.Item2,
                    PhoneNumber = "0631234567"
                }
            };
    }

    private IEnumerable<User> GetUsers()
    {
        List<User> users = [new()

            {
                UserId = userId1,
                Name = "John",
                Surname = "Doe",
                Email = "john@example.com",
                PasswordHash = hashedPasswordAndSalt2.Item1,
                Salt = hashedPasswordAndSalt2.Item2,
                Address = new()
                {
                    Country = "USA",
                    City = "New York",
                    StreetAndNumber = "123 Main St",
                    PostalCode = "10001"
                },
                PhoneNumber = "0641212121",
                Orders = new List<Order>
                    {
                       new Order
                        {
                            OrderId = orderId1,
                            OrderDate = DateTime.Now.AddDays(-7),
                            TotalPrice = 4200,
                           // UserId = userId1,
                           DiscountCouponId = couponId,
                            OrderStatus = "Proccessed",
                            Address = new()
                                {
                                    Country = "USA",
                                    City = "New York",
                                    StreetAndNumber = "123 Main St",
                                    PostalCode = "10001"
                                },
                            ProductOrders = new List<ProductOrder>
                            {
                            new ProductOrder
                                    {
                                        ProductId = productId1,
                                        Quantity = 2
                                    }
                            }
                        }
                    }
            },new (){
                UserId = userId2,
                Name = "Jane",
                Surname = "Smith",
                Email = "jane@example.com",
                PasswordHash = hashedPasswordAndSalt.Item1,
                Salt = hashedPasswordAndSalt.Item2,
                Address = new Address
                {
                    Country="USA",
                    City = "Los Angeles",
                    StreetAndNumber = "456 Oak Ave",
                    PostalCode = "90001"
                },
                PhoneNumber = "987-654-3210",
                Orders = new List<Order>
                    {
                       new Order
                        {
                            OrderId = orderId2,
                            OrderDate = DateTime.Now.AddDays(-7),
                            //UserId = userId2,
                            TotalPrice= 3800,
                            OrderStatus = "Processed",
                            Address = new Address
                                {
                                    Country="USA",
                                    City = "Los Angeles",
                                    StreetAndNumber = "456 Oak Ave",
                                    PostalCode = "90001"
                                },
                            ProductOrders = new List<ProductOrder>
                            {
                            new ProductOrder
                                    {
                                        ProductId = productId2,
                                        Quantity = 1
                                    }
                            }
                        }
                    }
            }

            ];

        return users;
    }

    private static Tuple<string, string> HashPassword(string password)
    {
        var sBytes = new byte[password.Length];
        new RNGCryptoServiceProvider().GetNonZeroBytes(sBytes);
        var salt = Convert.ToBase64String(sBytes);

        var derivedBytes = new Rfc2898DeriveBytes(password, sBytes, iterations);

        return new Tuple<string, string>
        (
            Convert.ToBase64String(derivedBytes.GetBytes(256)),
            salt
        );
    }
}
