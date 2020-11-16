using System;
using System.Collections.Generic;
using AngleSharp.Html.Dom;
using HtmlParse.Core.Data;
using System.Text.RegularExpressions;
using System.Linq;

namespace HtmlParse.Core.Systems.Parse.Riac34
{
    class Riac34 : IParser<string[]>
    {
        public event Action<object, string[]> OnNewLinks;
        public event Action<object, S_SimpleData[]> OnNewNews;

        public IParserSettings Settings { get; set; }
        public Riac34(IParserSettings settings) { Settings = settings; }
        public void ParseMain(IHtmlDocument document)
        {
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
                        if(match.Value != "")
                            Result.Add("https://riac34.ru/news/" + match.Value + "/");

                    }
                }

            }

            Console.WriteLine("ParseComplete");
            OnNewLinks?.Invoke(this, Result.ToArray());
        }
        public string ListToString(List<string> list)
        {
            string Return = "";
            foreach (string str in list)
                Return += str;
            return Return;

        }
        public void ParseNews(IHtmlDocument document, string Href)
        {

            S_SimpleData[] Result = new S_SimpleData[Settings.ParsInfo.Length];
            for (int i = 0; i < Result.Length; i++)
            {
                Result[i].Value = "";
                Result[i].ParameterName = "";
            }
                for (int i = 0; i < Settings.ParsInfo.Length; i++)
            {
                if (Settings.ParsInfo[i].Value != "")
                {
                    var items = document.QuerySelectorAll(Settings.ParsInfo[i].Value).Where(item => item.ClassName != null);
                    foreach (var item in items)
                    {
                        Result[i].Value += item.TextContent + "\n";
                    }
                    if(Result[i].Value == null)
                        Result[i].Value = "";
                }
                
                Result[i].ParameterName = Settings.ParsInfo[i].ParameterName;
            }
            Result[2].Value = Href;

            OnNewNews?.Invoke(this, Result);
        }
    }
}
