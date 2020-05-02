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
            InitializeComponent();
            parser = new ParserWorker<string[]>(
                new HabraParser()
                );
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            ListB.Items.Add(arg2);
            //StarB.AppendText(arg2[0]);
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
            float start;
            float.TryParse(StarB.Text, out start);
            float stop;
            float.TryParse(StopB.Text, out stop); 
            parser.Settings = new HabraSettings((int)start, (int)stop);
            parser.Start();
        }

        private void IStop(object sender, RoutedEventArgs e)
        {
            parser.Abort();
        }
    }
}
