﻿using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.Infrastructure.Data.Queries;
namespace Microsoft.eShopWeb.Web.ViewModels;

public class OrderViewModel
{
    //private const string DEFAULT_STATUS = "Pending";


    public string? BuyerId { get; set; }
    public int OrderNumber { get; set; }
    
    public DateTimeOffset OrderDate { get; set; }
    
    public decimal Total { get; set; }
    public string? OrderStatus {get;set;}
    public Address? ShippingAddress { get; set; }
    //public string? OrderStatus { get; set; }
}
