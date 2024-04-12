using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.OrderList;

public class GetAllOrders : IRequest<IEnumerable<OrderViewModel>>
{
    public string UserName { get; set; }

    public GetAllOrders(string userName)
    {
        UserName = userName;

    }
}
