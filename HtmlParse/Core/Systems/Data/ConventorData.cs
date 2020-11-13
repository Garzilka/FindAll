using HtmlParse.Core.Data;
using System;
using System.Collections.Generic;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace HtmlParse.Core.Systems.Data
{
    class ConventorData
    {
        public event Action<BsonDocument> ToBson;
        public event Action<string[]> JsonToSQL;
        public async Task ConvertorAsync(E_DataType type, S_SimpleData[] data)
        {
            switch (type)
            {
                case E_DataType.SQL:
                    {
                        return;
                    }
                case E_DataType.NoSQL:
                    {
                        ConvertToBson(data);
                        return;
                    }
            }
        }
        private void ConvertToBson(S_SimpleData[] Value)
        {
            BsonDocument Doc = new BsonDocument { };
            foreach (S_SimpleData Data in Value)
            {
                BsonDocument doc = new BsonDocument
                {
                    {Data.ParameterName, Data.Value}
                };
                Doc.AddRange(doc);
            }
            
            ToBson?.Invoke(Doc);
        }
    }
}
