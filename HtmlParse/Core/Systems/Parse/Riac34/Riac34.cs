using System;
using System.Collections.Generic;
using AngleSharp.Html.Dom;
using HtmlParse.Core.Data;
using System.Text.RegularExpressions;


namespace HtmlParse.Core.Systems.Parse.Riac34
{
    class Riac34 : IParser<string[]>
    {
        public event Action<object, string[]> OnNewLinks;
        public event Action<object, E_SimpleData[]> OnNewNews;

        public void ParseMain(IHtmlDocument document)
        {
            Console.WriteLine("Main");
            var items = document.QuerySelectorAll("div.col-lg-8");//span.styled__DigestItemTitleText-sc-5215n1-15 cFlSRO
            List<string> Result = new List<string> { };
            foreach (IHtmlAnchorElement menuLink in document.Links)
            {
                if (menuLink.Href.ToString().Contains("news"))
                {
                    if (!(menuLink.Href.ToString().Contains("section") || menuLink.Href.ToString().Contains("js")))
                    {
                        string a = menuLink.Href.ToString();
                        Regex regex = new Regex("\\d+");
                        Match match = regex.Match(a);
                        Console.WriteLine("https://riac34.ru/news/" + match.Value + "/");
                        Result.Add("https://riac34.ru/news/" + match.Value + "/");

                    }
                }

            }

            Console.WriteLine("ParseComplete");
            OnNewLinks?.Invoke(this, Result.ToArray());
        }

        public void ParseNews(IHtmlDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
