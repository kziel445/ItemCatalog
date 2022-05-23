using System;
using System.Collections.Generic;
using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDBItemsRepository : IItemRepository
    {
        private const string dataBaseName = "Catalog";
        private const string colletionName = "Items";
        private readonly IMongoCollection<Item> itemsColection;

        public MongoDBItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(dataBaseName);
            itemsColection = database.GetCollection<Item>(colletionName);
        }
        
        public void CreateItem(Item item)
        {
            itemsColection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}