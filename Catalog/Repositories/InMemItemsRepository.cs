using System;
using System.Linq;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Rayman Legends", Price = 10, CreateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "The Legend of Zelda: Breath of the Wild", Price = 54, CreateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Super Mario Maker 2", Price = 64, CreateDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(items => items.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}