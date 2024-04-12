using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.CustomerStatus;

public class ChangeCustomerStatus : IRequest<IEnumerable<OrderViewModel>>
{
    public string UserName { get; set; }

    public ChangeCustomerStatus(string userName)
    {
        UserName = userName;
    }
}
