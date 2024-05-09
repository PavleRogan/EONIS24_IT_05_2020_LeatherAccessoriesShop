﻿namespace WebShop.Domain.Entities;

public class Address
{
    public string? Country { get; set; }

    public string? City { get; set; }

    public string? StreetAndNumber { get; set; }

    public string? PostalCode { get; set; }
}