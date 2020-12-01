using HtmlParse.Core.Data;
using HtmlParse.Core.Systems;
using HtmlParse.Core.Systems.Data;
using HtmlParse.Core.Systems.Parse.Riac34;
using System;
using System.Collections.Generic;

namespace HtmlParse.Core
{
    class CCore
    {
        CDMS DMS;
        public ParserWorker<string[]> Parser;
        public event Action<object, string> OnError;
        public event Action<object, string[]> OnCompleted;
        ConventorData Conventor = new ConventorData();

        public CCore(int typeParser)
        {
            switch (typeParser)
            {
                case 0:
                    {
                        
                        break;
                    }
                default:
                    {
                        OnError(this, "Error: Выбран не существующий парсер");
                        return;
                    }
            }

        }

        async void News(object arg1, S_SimpleData[] News)
        {
            E_DataType Type = E_DataType.NoSQL;
            await Conventor.ConvertorAsync(Type, News);
            List<string> Result = new List<string> { };
            foreach (S_SimpleData Data in News)
            {
                Result.Add(Data.ParameterName + ":\n");
                Result.Add(Data.Value + "\n");
            }
            Result.Add("__________________________\n");
            OnCompleted?.Invoke(this, Result.ToArray());
        }

        public void StartParse(int start, int stop)
        {
            IParserSettings Settings = new Riac34Settings(start, stop);
            Parser = new ParserWorker<string[]>(new Riac34(Settings), Settings);
            DMS = new CDMS(Conventor);
            Parser.OnNewNews += News;
            Parser.Start();

        }


    }
}
