using dotnetApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace dotnetApi.Services
{
    public class ItemsService
    {
        private readonly IMongoCollection<Item> _items;

        public ItemsService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("ItemsDatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("ItemsDatabaseSettings:DatabaseName"));

            _items = database.GetCollection<Item>(configuration.GetValue<string>("ItemsDatabaseSettings:ItemsCollectionName"));
        }

        public List<Item> Get() =>
            _items.Find(item => true).ToList();

        public Item Get(string id) =>
            _items.Find<Item>(item => item._id == id).FirstOrDefault();

        public Item Create(Item item)
        {
            _items.InsertOne(item);
            return item;
        }

        public void Update(string id, Item itemIn) =>
            _items.ReplaceOne(item => item._id == id, itemIn);

        public void Remove(Item itemIn) =>
            _items.DeleteOne(item => item._id == itemIn._id);

        public void Remove(string id) => 
            _items.DeleteOne(item => item._id == id);
    }
}