using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParse.Core.Data
{
    enum E_DataType
    {
        SQL,
        NoSQL
    }
    struct S_SimpleData
    {
        public string ParameterName { get; set; }
        public string Value { get; set; }
    }
}
