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
        public async Task Insert(S_SimpleData[] Data, S_SimpleData forFind)
        {
            throw new NotImplementedException();
        }
        public async Task Insert(BsonDocument doc, S_SimpleData forFind)
        {
            var collection = database.GetCollection<BsonDocument>(Settings.Table);
            var filter = new BsonDocument(forFind.ParameterName, forFind.Value);
            using (var cursor = await collection.FindAsync(filter))
            {
                bool success = false;
                while (await cursor.MoveNextAsync())
                {
                    var people = cursor.Current;

                    foreach (var document in people)
                    {
                        success = true;
                        var collect = database.GetCollection<BsonDocument>(Settings.Table);
                        await collect.ReplaceOneAsync(filter, doc);
                    }
                }
                if (!success)
                {
                    Console.WriteLine("Save");
                    var collect = database.GetCollection<BsonDocument>(Settings.Table);
                    await collect.InsertOneAsync(doc);
                }
            }
        }
        
    }
}
