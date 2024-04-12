using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;


namespace BlazorAdmin.Services;

public class OrderlistItemService : IOrderListItemService
{
    private readonly ICatalogLookupDataService<CatalogBrand> _brandService;
    private readonly ICatalogLookupDataService<CatalogType> _typeService;
    private readonly HttpService _httpService;
    private readonly ILogger<CatalogItemService> _logger;

    public OrderlistItemService(ICatalogLookupDataService<CatalogBrand> brandService,
        ICatalogLookupDataService<CatalogType> typeService,
        HttpService httpService,
        ILogger<CatalogItemService> logger)
    {
        _brandService = brandService;
        _typeService = typeService;
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<OrderListItem> GetById(int id)
    {
        var brandListTask = _brandService.List();
        var typeListTask = _typeService.List();
        var itemGetTask = _httpService.HttpGet<EditOrderListItemResponse>($"catalog-items/{id}");
        await Task.WhenAll(brandListTask, typeListTask, itemGetTask);
        var brands = brandListTask.Result;
        var types = typeListTask.Result;
        var orderlistItem = itemGetTask.Result.OrderlistItem;
        //orderlistItem.OrderlistBrand = brands.FirstOrDefault(b => b.Id == orderlistItem.OrderlistBrandId)?.Name;
        //orderlistItem.OrderlistType = types.FirstOrDefault(t => t.Id == orderlistItem.OrderlistTypeId)?.Name;
        return orderlistItem;
    }

    public async Task<List<CatalogItem>> ListPaged(int pageSize)
    {
        _logger.LogInformation("Fetching catalog items from API.");

        var brandListTask = _brandService.List();
        var typeListTask = _typeService.List();
        var itemListTask = _httpService.HttpGet<PagedCatalogItemResponse>($"catalog-items?PageSize=10");
        await Task.WhenAll(brandListTask, typeListTask, itemListTask);
        var brands = brandListTask.Result;
        var types = typeListTask.Result;
        var items = itemListTask.Result.CatalogItems;
        foreach (var item in items)
        {
            item.CatalogBrand = brands.FirstOrDefault(b => b.Id == item.CatalogBrandId)?.Name;
            item.CatalogType = types.FirstOrDefault(t => t.Id == item.CatalogTypeId)?.Name;
        }
        return items;
    }

    public async Task<List<CatalogItem>> List()
    {
        _logger.LogInformation("Fetching catalog items from API.");

        var brandListTask = _brandService.List();
        var typeListTask = _typeService.List();
        var itemListTask = _httpService.HttpGet<PagedCatalogItemResponse>($"catalog-items");
        await Task.WhenAll(brandListTask, typeListTask, itemListTask);
        var brands = brandListTask.Result;
        var types = typeListTask.Result;
        var items = itemListTask.Result.CatalogItems;
        foreach (var item in items)
        {
            item.CatalogBrand = brands.FirstOrDefault(b => b.Id == item.CatalogBrandId)?.Name;
            item.CatalogType = types.FirstOrDefault(t => t.Id == item.CatalogTypeId)?.Name;
        }
        return items;
    }

    Task<OrderListItem> IOrderListItemService.GetById(int id)
    {
        throw new System.NotImplementedException();
    }

    Task<List<OrderListItem>> IOrderListItemService.ListPaged(int pageSize)
    {
        throw new System.NotImplementedException();
    }

    Task<List<OrderListItem>> IOrderListItemService.List()
    {
        throw new System.NotImplementedException();
    }
}
