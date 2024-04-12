using System.Data;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.ViewModels;

public class OrderlistViewModel
{   /*
    private readonly IBasketService _basketService;
    private readonly IBasketViewModelService _basketViewModelService;
    private readonly IRepository<CatalogItem> _itemRepository;

    public OrderlistModel(IBasketService basketService,
        IBasketViewModelService basketViewModelService,
        IRepository<CatalogItem> itemRepository)
    {
        _basketService = basketService;
        _basketViewModelService = basketViewModelService;
        _itemRepository = itemRepository;
    }*/

    public OrderDetailViewModel OrderDetailModel { get; set; } = new OrderDetailViewModel();


    public async Task OnPostUpdate(string orderStatus)
    {
        SqlConnection baglan = new SqlConnection(@"Data Source=(localdb)\\mssqllocaldb;Integrated Security=true;Initial Catalog=Microsoft.eShopOnWeb.CatalogDb;");
        baglan.Open();
        //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("UPDATE Orders SET OrderStatus = @OrderStatus WHERE OrderId = @Id;",baglan);
        string query = "UPDATE Orders SET Name = @Name,Country = @Country WHERE CustomerId = @Id";
        SqlCommand cmd = new SqlCommand(query, baglan);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@OrderStatus", orderStatus);
        baglan.Open();
        cmd.ExecuteNonQuery();
        baglan.Close();
    }
}
