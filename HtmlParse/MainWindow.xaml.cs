using HtmlParse.Core;
using HtmlParse.Core.Habra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HtmlParse
{
    
    public partial class MainWindow : Window
    {
        ParserWorker<string[]> parser;

        public MainWindow()
        {
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Completed");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void IStart(object sender, RoutedEventArgs e)
        {

        }

        private void IStop(object sender, RoutedEventArgs e)
        {
        }
    }
}
