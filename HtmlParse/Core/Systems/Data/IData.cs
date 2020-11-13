using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
namespace HtmlParse.Core.Data
{
    interface IData
    {
        Task Insert(BsonDocument doc);
        Task Insert(S_SimpleData[] Data);
    }
}
