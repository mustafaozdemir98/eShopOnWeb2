using System;
using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities;

public class OrderlistItem : BaseEntity, IAggregateRoot
{
    //public DateTimeOffset OrderDate { get; set; }
    //public string BuyerId { get; set; }
    public CatalogItemOrdered ItemOrdered { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Units { get; private set; }

#pragma warning disable CS8618 // Required by Entity Framework
    private OrderlistItem() { }

    public OrderlistItem(CatalogItemOrdered itemOrdered, decimal unitPrice, int units)
    {
        ItemOrdered = itemOrdered;
        UnitPrice = unitPrice;
        Units = units;
    }
    
    /*
    public OrderlistItem(
        string buyerId)
    {
        BuyerId = buyerId;
    }
    */

    
    
}
