using HtmlParse.Core.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace HtmlParse.Core.Systems.Data.MongoDB
{
    class Mongo : IData
    {
        MongoClient client;
        IMongoDatabase database;
        IDataSettings Settings;
        public Mongo(IDataSettings settings)
        {
            Settings = settings;

            client = new MongoClient(Settings.Connection);
            database = client.GetDatabase(Settings.DBName);
        }
        public async Task Insert(S_SimpleData[] Data)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(BsonDocument doc)
        {
            Console.WriteLine(doc);
            var collection = database.GetCollection<BsonDocument>(Settings.Table);
            await collection.InsertOneAsync(doc);
        }
    }
}
