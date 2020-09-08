using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MongoDAL
{
    public class MongoDBHelper
    {
        private IMongoDatabase _database = DBConfig.GetMongoDb();
        public List<T> GetList<T>(Expression<Func<T, bool>> conditions = null)
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            if (conditions != null)
            {
                return collection.Find(conditions).ToList();
            }
            return collection.Find(_ => true).ToList();
        }

        public void InsertMany<T>(List<T> list)
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            collection.InsertMany(list);
        }

        public void InsertOne<T>(T t)
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            collection.InsertOne(t);
        }


        public T FindOne<T>(Expression<Func<T, bool>> conditions = null)
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            if (conditions != null)
            {
                return collection.Find(conditions).FirstOrDefault();
            }
            return collection.Find(_ => true).FirstOrDefault();
        }

        public void DeleteMany<T>(Expression<Func<T, bool>> conditions = null)
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);

            collection.DeleteMany<T>(conditions);
        }

        public void UpdateOne<T>(string Did, List<UpdateParam> UpdateParams)
        {
            var collection = _database.GetCollection<BsonDocument>(typeof(T).Name);
            foreach (var param in UpdateParams)
            {
                //更新
                var filter = Builders<BsonDocument>.Filter.Eq("_id", Did);
                var update = Builders<BsonDocument>.Update.Set(param.UpdateKey, param.UpateValue);
                collection.UpdateOne(filter, update);
            }

        }

        
    }
}
