using System;
using HtmlParse.Core.Data;

namespace HtmlParse.Core.Systems.Parse
{
    interface IParser<T> where T : class
    {
        void ParseMain(AngleSharp.Html.Dom.IHtmlDocument document); // Парсинг ленты новостей
        void ParseNews(AngleSharp.Html.Dom.IHtmlDocument document); // Парсинг Новости
        event Action<object, string[]> OnNewLinks;
        event Action<object, E_SimpleData[]> OnNewNews;
    }
}
