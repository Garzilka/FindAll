using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParse.Core.Systems.Parse.Riac34
{
    class Riac34Settings : IParserSettings
    {
        public Riac34Settings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseURL { get; set; } = "https://riac34.ru/news/";
        public string Prefix { get; set; } = "109990/js/share.js?PAGEN_1={CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
