using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace Oz.Algorithms.Data.Download.Twitter
{
    /// <summary>
    /// Twitter Class for Data Downloading
    /// </summary>
    public class Twitter
    {
        private string _consumerKey;
        private string _consumerSecret;
        private string _accessToken;
        private string _accessTokenSecret;
        private string _screenName;
        TwitterService service;

        /// <summary>
        /// Twitter Class Constructor
        /// </summary>
        /// <param name="consumerKey">Twitter Consumer Key</param>
        /// <param name="consumerSecret">Twitter Consumer Secret</param>
        /// <param name="accessToken">Twitter Access Token</param>
        /// <param name="accessTokenSecret">Twitter Access Token Secret</param>
        public Twitter(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret) 
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _accessToken = accessToken;
            _accessTokenSecret = accessTokenSecret;
            _screenName = "";
            Connect();
        }

        private void Connect()
        {
           // var appCredentials = new TwitterCredentials(_consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            service = new TwitterService(_consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            //var followers = service.ListFollowerIdsOf(new ListFollowerIdsOfOptions() { ScreenName = "fcnblog" });
        }

        /// <summary>
        /// Gives Screen Name of the connected user
        /// </summary>
        /// <returns>string</returns>
        public string ConnectedUser()
        {
            if (_screenName == "")
            {
                return "Not Connected!"; 
            }
            else
            {
                return _screenName;
            }

        }

        public TwitterCursorList<long> GetFollowerIds(string userScreenName, int maxFollowersToRetrieve = 5000)
        {
            var service = new TwitterService(_consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            return service.ListFollowerIdsOf(new ListFollowerIdsOfOptions() { ScreenName = "maozkuran" });
        }
    }
}
