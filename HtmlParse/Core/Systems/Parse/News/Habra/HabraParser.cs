﻿using System;
using System.Collections.Generic;
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
            List<string> Result = new List<string> { };
            OnNewLinks?.Invoke(this, Result.ToArray());
            throw new NotImplementedException();
        }

        public void ParseNews(IHtmlDocument document, string Href)
        {
            throw new NotImplementedException();
        }
    }
}