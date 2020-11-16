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
        Task Insert(BsonDocument doc, S_SimpleData forFind);
        Task Insert(S_SimpleData[] Data, S_SimpleData forFind);
    }
}
