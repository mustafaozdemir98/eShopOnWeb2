using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorShared.Interfaces;
using BlazorShared.Models;

namespace BlazorAdmin.Pages.OrdersPage;

public partial class OrderList : BlazorComponent
{
    private List<OrderListItem> orderlistItems = new List<OrderListItem>();
    private List<OrderListType> orderlistTypes = new List<OrderListType>();
    private List<OrderListBrand> orderlistBrands = new List<OrderListBrand>();


    private Details DetailsComponent { get; set; }

    private async void DetailsClick(int id)
    {
        await DetailsComponent.Open(id);
    }



}
