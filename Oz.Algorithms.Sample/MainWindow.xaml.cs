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
using System.Configuration;
using Oz.Algorithms;
using System.IO;

namespace Oz.Algorithms.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TwitterDownloadFollowerIds_Click(object sender, RoutedEventArgs e)
        {
            string twitterConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
            string twitterConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
            string twitterAccessToken = ConfigurationManager.AppSettings["twitterAccessToken"];
            string twitterAccessTokenSecret = ConfigurationManager.AppSettings["twitterAccessTokenSecret"];
            Oz.Algorithms.Data.Download.Twitter.Twitter twitter = new Data.Download.Twitter.Twitter(twitterConsumerKey, twitterConsumerSecret, twitterAccessToken, twitterAccessTokenSecret);
            var list = twitter.GetFollowerIds("maozkuran");
            StreamWriter file = new System.IO.StreamWriter("c:\\rrr\\maozkuran.txt");
            list.ForEach(file.WriteLine);
            file.Close();
        }
    }
}
