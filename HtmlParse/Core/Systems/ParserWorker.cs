using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using HtmlParse.Core.Data;
using HtmlParse.Core.Systems.Parse;
using System;
using System.Collections.Generic;

namespace HtmlParse.Core.Systems
{
    class ParserWorker<T> where T : class
    {
        IParserSettings parserSettings;
        IParser<T> Parser;

        htmlLoader loader;
        bool isActive;
        #region Properties


        public bool IsActive
        {
            get
            {
                return isActive;
            }

        }

        #endregion
        public event Action<object, string> OnNewLinks;
        public event Action<object, string[]> OnCompleted;

        public ParserWorker(IParser<T> parser)
        {
            this.Parser = parser;
            Parser.OnNewLinks += Parser_OnNewLinks;
            Parser.OnNewNews += Parser_OnNewNews;

        }
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
            loader = new htmlLoader(parserSettings);
        }

        public void Abort()
        {
            isActive = false;
        }
        protected async void Parser_OnNewLinks(object arg1, string[] Links)
        {
            //Prototype
            List<string> Result = new List<string> { };
            foreach (string Href in Links)
            {
                var Source = await loader.GetSourceByHref(Href);
                var DomParser = new HtmlParser();
                var Document = await DomParser.ParseDocumentAsync(Source);
                Parser.ParseNews(Document, Href);
                Result.Add(Href + "\n");
            }
            OnCompleted?.Invoke(this, Result.ToArray());
            
        }
        protected void Parser_OnNewNews(object arg1, S_SimpleData[] News)
        {
            //Prototype
            List<string> Result = new List<string> { };
            foreach (S_SimpleData Data in News)
            {
                Result.Add(Data.ParameterName + ":\n");
                Result.Add(Data.Value + "\n");
            }
            Result.Add("__________________________\n");
            OnCompleted?.Invoke(this, Result.ToArray());
        }



        public void Start()
        {
            isActive = true;
            Worker();
        }
        private async void Worker()
        {
            //Prototype
            if (parserSettings.StartPoint > 0)
            {
                for (int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
                {
                    /* 
                     if (!isActive)
                     {
                         OnCompleted?.Invoke(this);
                         return;
                     }
                     */

                    var source = await loader.GetHTML(i);
                    var domParser = new HtmlParser();

                    var document = await domParser.ParseDocumentAsync(source);

                    Parser.ParseMain(document);
                }
            }
            else
            {
                var source = await loader.GetHTML(0);
                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);

                Parser.ParseMain(document);
            }
        }

    }
}
