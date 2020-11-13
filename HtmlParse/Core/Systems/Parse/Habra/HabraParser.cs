using System;
using AngleSharp.Html.Dom;
using HtmlParse.Core.Data;
using HtmlParse.Core.Systems.Parse;

namespace HtmlParse.Core.Habra
{
    class HabraParser : IParser<string[]>
    {
        public IParserSettings Settings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action<object, string[]> OnNewLinks;
        public event Action<object, S_SimpleData[]> OnNewNews;

        public void ParseMain(IHtmlDocument document)
        {
            throw new NotImplementedException();
        }

        public void ParseNews(IHtmlDocument document, string Href)
        {
            throw new NotImplementedException();
        }
    }
}
