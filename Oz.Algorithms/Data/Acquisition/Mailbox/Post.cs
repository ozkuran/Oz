using System.Collections.Generic;
using System.ComponentModel;

namespace Oz.Algorithms.Data.Acquisition.Mailbox
{
    public class Post
    {
        public string PostId { get; set; }
        public List<string> HeaderList { get; set; }
        public List<string> Body { get; set; }
        /// <summary>
        /// Group of the Post
        /// </summary>
        public Group Group { get; set; }
        /// <summary>
        /// Headers of the post
        /// </summary>
        public Header Header { get; set; }
        
        /// <summary>
        /// Body text without stopwords
        /// </summary>
        /// 
        public List<string> NoStopWordBody { get; set; }

        /// <summary>
        /// Post Object
        /// </summary>
        public Post()
        {
            HeaderList = new List<string>();
            Body = new List<string>();
            Header = new Header();
            NoStopWordBody = new List<string>();
        }
    }
}
