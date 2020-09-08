using MongoDB.Driver;
using System;

namespace MongoDAL
{
    public class DBConfig
    {
        //方式一
        //private static readonly string connStr = "mongodb://myAdmin:123456@localhost";
        //private static readonly string dbName = "myTest";

        //方式二（myTestAdmin用户只可访问数据库myTest）
        private static readonly string connStr = "mongodb://localhost/BlockDB";

        private static IMongoDatabase db = null;

        private static readonly object lockHelper = new object();

        private DBConfig() { }

        public static IMongoDatabase GetMongoDb()
        {
            if (db == null)
            {
                lock (lockHelper)
                {
                    if (db == null)
                    {
                        //方式一
                        //var client = new MongoClient(connStr);
                        //db = client.GetDatabase(dbName);

                        //方式二（myTestAdmin用户只可访问数据库myTest）
                        var url = new MongoUrl(connStr);
                        MongoClientSettings mcs = MongoClientSettings.FromUrl(url);
                        mcs.MaxConnectionLifeTime = TimeSpan.FromMilliseconds(1000);
                        var client = new MongoClient(mcs);
                        db = client.GetDatabase(url.DatabaseName);
                    }
                }
            }
            return db;
        }
    }
}
