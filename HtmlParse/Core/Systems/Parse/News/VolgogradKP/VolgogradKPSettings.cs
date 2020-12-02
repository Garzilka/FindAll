using HtmlParse.Core.Data;

namespace HtmlParse.Core.Systems.Parse.News.VolgogradKP
{
    class VolgogradKPSettings : IParserSettings
    {
        public VolgogradKPSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
            ParsInfo = new S_SimpleData[7];
            ParsInfo[0].ParameterName = "NameNews";
            ParsInfo[0].Value = "time.mdIfz";
            ParsInfo[1].ParameterName = "Date";
            ParsInfo[1].Value = "div.news-attr span.date";
            ParsInfo[2].ParameterName = "RefNews";
            ParsInfo[2].Value = "";
            ParsInfo[3].ParameterName = "TextNews";
            ParsInfo[3].Value = "div.full-text";
            ParsInfo[4].ParameterName = "VideoRef";
            ParsInfo[4].Value = "";
            ParsInfo[5].ParameterName = "countViews";
            ParsInfo[5].Value = "span.views";
            ParsInfo[6].ParameterName = "countComments";
            ParsInfo[6].Value = "span.comments";
        }
        public string BaseURL { get; set; } = "https://www.volgograd.kp.ru/online/news/";
        public string Prefix { get; set; } = "124149/js/share.js?PAGEN_1={CurrentId}"; //section/{CurrentId}
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public S_SimpleData[] ParsInfo { get; set; }
        public string Table { get; set; }
    }
}
