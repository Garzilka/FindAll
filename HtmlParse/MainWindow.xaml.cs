using HtmlParse.Core;
using HtmlParse.Core.Habra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        CCore core;
        public MainWindow()
        {
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {

            foreach (string str in arg2)
                OUT.AppendText(str);
        }

        private void Parser_OnCompleted(object obj)
        {/*MessageBox.Show("Completed");*/}



        private void IStart(object sender, RoutedEventArgs e)
        {
            OUT.Clear();
            int start;
            Int32.TryParse(StartPoint.Text, out start);
            int stop;
            Int32.TryParse(EndPoint.Text, out stop);
            core = new CCore(0);
            core.OnCompleted += Parser_OnNewData;
            core.StartParse(start, stop);
        }

        private void IStop(object sender, RoutedEventArgs e)
        {
        }

        private void EP_Correct(object sender, KeyEventArgs e)
        {
            string a = e.Key.ToString();
            Regex regex = new Regex("\\d+");
            Match match = regex.Match(a);
            if (match.Value == "")
                e.Handled = true;
        }

        private void ES_Correct(object sender, KeyEventArgs e)
        {
            string a = e.Key.ToString();
            Regex regex = new Regex("\\d+");
            Match match = regex.Match(a);
            if (match.Value == "")
                e.Handled = true;
        }
    }
}
