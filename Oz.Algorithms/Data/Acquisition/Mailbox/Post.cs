using System.Collections.Generic;

namespace Oz.Algorithms.Data.Acquisition.Mailbox
{
    class Post
    {
        public string PostId { get; set; }
        public List<string> HeaderList { get; set; }
        public List<string> Body { get; set; }
        public Group Group { get; set; }

        public Post()
        {
            HeaderList = new List<string>();
            Body = new List<string>();
        }
    }
}
