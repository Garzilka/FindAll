

using HtmlParse.Core.Data;

namespace HtmlParse.Core.Habra
{
    class HabraSettings : IParserSettings
    {
        public HabraSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseURL { get; set; } = "https://habrahabr.ru";
        public string Prefix { get; set; } = "page{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public S_SimpleData[] ParsInfo { get; set; }
        public string Table { get; set; }
    }
}
