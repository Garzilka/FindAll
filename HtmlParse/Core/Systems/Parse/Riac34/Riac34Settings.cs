using HtmlParse.Core.Data;
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
            ParsInfo = new S_SimpleData[7];
            ParsInfo[0].ParameterName = "NameNews";
            ParsInfo[0].Value = "div.inner-new-content h1";
            ParsInfo[1].ParameterName = "Date";
            ParsInfo[1].Value = "div.news-attr span.date";
            ParsInfo[2].ParameterName = "RefNews";
            ParsInfo[2].Value = "";
            ParsInfo[3].ParameterName = "TextNews";
            ParsInfo[3].Value = "div.full-text";
            ParsInfo[4].ParameterName = "VideoRef";
            ParsInfo[4].Value = "";
            ParsInfo[5].ParameterName = "countViews";
            ParsInfo[5].Value = "";
            ParsInfo[6].ParameterName = "countComments";
            ParsInfo[6].Value = "";
        }
        public string BaseURL { get; set; } = "https://riac34.ru/news/";
        public string Prefix { get; set; } = "109990/js/share.js?PAGEN_1={CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public S_SimpleData[] ParsInfo { get; set; }
    }
}
