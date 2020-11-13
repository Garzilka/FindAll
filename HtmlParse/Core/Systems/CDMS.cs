using HtmlParse.Core.Data;
using HtmlParse.Core.Systems.Data;
using HtmlParse.Core.Systems.Data.MongoDB;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParse.Core.Systems
{
    class CDMS // Class Database Management System
    {
        IData DataBase;
        IDataSettings DataSettings;
        public CDMS(ConventorData Conventor)
        {
            DataSettings = new MongoSettings();
            DataBase = new Mongo(DataSettings);

            Conventor.ToBson += Ins;
        }
        async void Ins(BsonDocument doc)
        {
            await DataBase.Insert(doc);
        }
    }
}
