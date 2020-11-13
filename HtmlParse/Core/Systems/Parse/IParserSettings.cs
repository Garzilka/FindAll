using HtmlParse.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParse.Core
{
    interface IParserSettings
    {
        string BaseURL { get; set; }

        string Prefix { get; set; }

        int StartPoint { get; set; }

        int EndPoint { get; set; }

        S_SimpleData[] ParsInfo { get; set; }

    }
}
