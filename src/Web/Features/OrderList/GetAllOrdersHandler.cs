using MediatR;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.Infrastructure.Data;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.OrderList;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrders, IEnumerable<OrderViewModel>>
{
    private readonly IReadRepository<Order> _orderRepository;

    public GetAllOrdersHandler(IReadRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderViewModel>> Handle(GetAllOrders request,
        CancellationToken cancellationToken)
    {
        var specification = new AdminAllOrderSpec(request.UserName);
        var orders = await _orderRepository.ListAsync(specification,cancellationToken);
        
        return orders.Select(o => new OrderViewModel
        {
            OrderStatus = o.OrderStatus,
            BuyerId = o.BuyerId,
            OrderDate = o.OrderDate,
            OrderNumber = o.Id,
            ShippingAddress = o.ShipToAddress,
            Total = o.Total()
        });
    }

}
