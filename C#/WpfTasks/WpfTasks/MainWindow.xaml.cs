using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace WpfTasks
{
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html",
            typeof(string),
            typeof(MainWindow),
            new FrameworkPropertyMetadata(OnHtmlChanged)
            );


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Debug.WriteLine($"Thread No. : {Thread.CurrentThread.ManagedThreadId}");
                HttpClient client = new HttpClient();
                string html = client.GetStringAsync("http://speedtest.tele2.net/20MB.zip").Result;
                MessageBox.Show(html);

                MyButton.Dispatcher.Invoke(() => MyButton.Content = "Done");

            });

        }

        private async void Button_Click2(object sender, RoutedEventArgs e)
        {
            string myHtml = "ABC";
            await Task.Run(() =>
            {
                HttpClient client = new HttpClient();
                string html = client.GetStringAsync("https://youtube.com").Result;
                myHtml = html;

            });
            MyButton.Content = "Done Downloading";
            MyWebBrowser.SetValue(HtmlProperty, myHtml);
        }

        static void OnHtmlChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)dependencyObject;
            if (webBrowser != null)
            {
                webBrowser.NavigateToString(e.NewValue as string);
            }
        }

    }
}
