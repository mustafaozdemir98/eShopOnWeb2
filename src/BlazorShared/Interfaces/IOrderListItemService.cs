using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces;
public interface IOrderListItemService
{
    Task<OrderListItem> GetById(int id);
    Task<List<OrderListItem>> ListPaged(int pageSize);
    Task<List<OrderListItem>> List();
}
