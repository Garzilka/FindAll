
namespace HtmlParse.Core
{
    interface IParser<T> where T : class
    {
        T Parse(AngleSharp.Html.Dom.IHtmlDocument document);
    }
}
