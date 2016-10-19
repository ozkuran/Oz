using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oz.Algorithms.Data.Download.Twitter;
using System.Configuration;
using System.IO;

namespace Oz.Algorithms.Tests
{
    [TestClass]
    public class TwitterTests
    {
        private Twitter _twitter;

        public TwitterTests()
        {
            string twitterConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
            string twitterConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
            string twitterAccessToken = ConfigurationManager.AppSettings["twitterAccessToken"];
            string twitterAccessTokenSecret = ConfigurationManager.AppSettings["twitterAccessTokenSecret"];
            _twitter = new Twitter(twitterConsumerKey, twitterConsumerSecret, twitterAccessToken, twitterAccessTokenSecret);
        }

        //[TestMethod]
        //public void CheckIfConnected()
        //{
        //    StringAssert.Equals(_twitter.ConnectedUser(), "maozkuran");
        //}

        //[TestMethod]
        //public void CheckFollowerIds()
        //{
        //    var results = _twitter.GetFollowerIds("nytimes");
        //    StreamWriter file = new System.IO.StreamWriter("d:\\nytimes.txt");
        //    results.ForEach(file.WriteLine);
        //    file.Close();
        //}

    }
}
