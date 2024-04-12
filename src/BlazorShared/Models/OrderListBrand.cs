using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Attributes;

namespace BlazorShared.Models;

[Endpoint(Name = "orderlist-brands")]
public class OrderListBrand : LookupData
{
}
