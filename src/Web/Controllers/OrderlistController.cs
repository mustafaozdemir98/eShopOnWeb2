using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Net;
using System.Net.NetworkInformation;
using Ardalis.GuardClauses;
using Ardalis.Specification.EntityFrameworkCore;
using BlazorAdmin.Pages.OrdersPage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.Infrastructure.Data;
using Microsoft.eShopWeb.Web.Features.MyOrders;
using Microsoft.eShopWeb.Web.Features.OrderDetails;
using Microsoft.eShopWeb.Web.Features.OrderList;
using Microsoft.eShopWeb.Web.ViewModels;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Microsoft.eShopWeb.Web.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Authorize(Roles = "Administrators")] // Controllers that mainly require Authorization still use Controller/View; other pages use Pages
[Route("[controller]/[action]")]
public class OrderlistController : Controller
{
    private readonly IMediator _mediator;
    protected readonly CatalogContext _catalogContext;
    public OrderlistController(IMediator mediator, CatalogContext catalogContext)
    {
        _mediator = mediator;
        _catalogContext = catalogContext;
    }

    [HttpGet]
    public async Task<IActionResult> OrderList()
    {
        Guard.Against.Null(User?.Identity?.Name, nameof(User.Identity.Name));
        var viewModel = await _mediator.Send(new GetAllOrders(User.Identity.Name));

        return View(viewModel);
    }


    [HttpGet("{orderId}")]
    public async Task<IActionResult> Detail(int orderId)
    {
        Guard.Against.Null(User?.Identity?.Name, nameof(User.Identity.Name));
        var viewModel = await _mediator.Send(new GetOrderDetails(User.Identity.Name,orderId));

        if (viewModel == null)
        {
            return BadRequest("No such order found for this user.");
        }

        return View(viewModel);
    }
    public async Task<IActionResult> UpdateStatus(int orderId)
    {
        Guard.Against.Null(User?.Identity?.Name, nameof(User.Identity.Name));
        var viewModel = await _mediator.Send(new GetOrderDetails(User.Identity.Name, orderId));

        if (viewModel == null)
        {
            return BadRequest("No such order found for this user.");
        }

        var exStatus = _catalogContext.Orders.Where(c => c.Id == orderId).SingleOrDefault();
        exStatus.OrderStatus = "Approved";
        _catalogContext.SaveChanges();

        return RedirectToAction(nameof(Detail),new { orderId });
    }
}

