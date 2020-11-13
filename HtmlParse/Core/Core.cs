using HtmlParse.Core.Systems;
using HtmlParse.Core.Systems.Parse.Riac34;
using System;

namespace HtmlParse.Core
{
    class Core<T> where T : class
    {
        CDMS DMS;
        public ParserWorker<string[]> Parser;
        public event Action<object> OnCompleted;
        public event Action<object, string> OnError;

        public Core(int typeParser)
        {
            switch (typeParser)
            {
                case 0:
                    {
                        Parser = new ParserWorker<string[]>(new Riac34(), new Riac34Settings(0, 0));
                        break;
                    }
                default:
                    {
                        OnError(this, "Error: Выбран не существующий парсер");
                        return;
                    }
            }

        }



        public void StartParse()
        {
            Parser.Start();
        }


    }
}
