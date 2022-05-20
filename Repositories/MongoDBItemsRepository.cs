using System;
using System.Collections.Generic;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDBItemsRepository : IItemRepository
    {
        private const string dataBaseName = "Catalog";
        private const string colletionName = "Items";
        private readonly IMongoCollection<Item> itemsColection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

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
            var filter = filterBuilder.Eq(item => item.Id, id);
            itemsColection.DeleteOne(filter);
        }

        public Item GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            
            return itemsColection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemsColection.Find(new BsonDocument()).ToList();
        }

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);

            itemsColection.ReplaceOne(filter, item);
            
        }
    }
}