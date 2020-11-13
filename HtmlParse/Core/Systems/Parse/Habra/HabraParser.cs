using System;
using AngleSharp.Html.Dom;
using HtmlParse.Core.Data;
using HtmlParse.Core.Systems.Parse;

namespace HtmlParse.Core.Habra
{
    class HabraParser : IParser<string[]>
    {
        public event Action<object, string[]> OnNewLinks;
        public event Action<object, E_SimpleData[]> OnNewNews;

        public void ParseMain(IHtmlDocument document)
        {
            return;
        }

        public void ParseNews(IHtmlDocument document)
        {
            return;
        }
    }
}
