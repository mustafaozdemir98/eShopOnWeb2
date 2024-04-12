using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;
public class GetCustomerSpec : Specification<Order>
{
    public GetCustomerSpec(string buyerId)
    {
        Query
            .Include(o => o.BuyerId)
            ;
    }
}
