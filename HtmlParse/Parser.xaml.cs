using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HtmlParse.Core;

namespace HtmlParse
{
    public partial class Parser : UserControl
    {
        CCore core;
        public Parser()
        {
            InitializeComponent();
        }
        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            foreach (string str in arg2)
                OUT.AppendText(str);
        }
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
