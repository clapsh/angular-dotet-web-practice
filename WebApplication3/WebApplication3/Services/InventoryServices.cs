using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Services
{
	public class InventoryService: IInventoryServices
    {
        private readonly Dictionary<int, Items> _items;

        public InventoryService()
        {
            _items = new Dictionary<int, Items>();
        }

        public Items AddItems(Items items)
        {
            _items.Add(items.id, items);

            return items;
        }

    }
}