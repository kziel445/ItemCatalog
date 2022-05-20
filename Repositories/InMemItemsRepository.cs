using System;
using System.Linq;
using System.Collections.Generic;
using Catalog.Entities;


namespace Catalog.Repositories
{
    public class InMemItemRepository : IItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 10, CreateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Sword", Price = 100, CreateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bow", Price = 100, CreateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Sax", Price = 9000, CreateDate = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existing => existing.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existing => existing.Id == id);
            items.RemoveAt(index);
        }
    }
}