﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class EditOrderListItemResponse
{
    public OrderListItem OrderlistItem { get; set; } = new OrderListItem();
}
