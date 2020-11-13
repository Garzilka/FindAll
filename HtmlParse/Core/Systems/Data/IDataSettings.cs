using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParse.Core.Data
{
    interface IDataSettings
    {
        string Connection { get; set; }
        string DBName { get; set; }
        string Table { get; set; } // or document
        E_DataType DataType { get; set; }
    }
}
