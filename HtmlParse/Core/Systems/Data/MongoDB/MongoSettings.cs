using HtmlParse.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParse.Core.Systems.Data.MongoDB
{
    class MongoSettings : IDataSettings
    {
        public string Connection { get; set; } = "mongodb://localhost";
        public string DBName { get; set; } = "News";
        public string Table { get; set; } = "Riac34";
        public E_DataType DataType { get; set; }
    }
}
