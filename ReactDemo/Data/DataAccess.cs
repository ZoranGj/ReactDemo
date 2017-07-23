using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("EmployeeDB");
        }

        public IEnumerable<Item> GetItems()
        {
            return _db.GetCollection<Item>("Items").FindAll();
        }


        public Item GetItem(ObjectId id)
        {
            var res = Query<Item>.EQ(p => p.Id, id);
            return _db.GetCollection<Item>("Items").FindOne(res);
        }

        public Item Create(Item p)
        {
            _db.GetCollection<Item>("Items").Save(p);
            return p;
        }

        public void Update(ObjectId id, Item p)
        {
            p.Id = id;
            var res = Query<Item>.EQ(pd => pd.Id, id);
            var operation = Update<Item>.Replace(p);
            _db.GetCollection<Item>("Items").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<Item>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Item>("Items").Remove(res);
        }
    }
}
