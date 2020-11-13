using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParse.Core
{
    class Core<T> where T : class
    {

        public event Action<object> OnCompleted;
        public event Action<object, string> OnError;

        public Core()
        {


        }



        public void StartParse()
        {
        }


    }
}
