using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using HtmlParse.Core.Systems.Parse;

namespace HtmlParse.Core.Habra
{
    class HabraParser : IParser<string[]>
    {
        public event Action<object, string[]> OnNewLinks;

        public void ParseMain(IHtmlDocument document)
        {
            throw new NotImplementedException();
        }

        public void ParseNews(IHtmlDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
