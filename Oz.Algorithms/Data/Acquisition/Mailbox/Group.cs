using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oz.Algorithms.Data.Acquisition.Mailbox
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        private List<Post> Posts { get; set; } 


        public Group(string inputName = "")
        {
            Name = inputName;
            Posts = new List<Post>();
        }

        private Post ProcessPost(IEnumerable<string> postStringList)
        {
            var post = new Post();
            var lineCount = 0;
            var headerFinish = false;
            foreach (var s in postStringList)
            {
                if (s == "")
                {
                    headerFinish = true;
                }
                if (!headerFinish)
                {
                   post.HeaderList.Add(s);
                }
                else
                {
                    post.Body.Add(s);
                }
                /*int index = line.IndexOf(": ");
                    if ((index >= 2) && (index < 30))
                    {
                        distinctValues.Add(line.Substring(0, index));
                    }
                    else
                    {
                        index = 0;
                    }
                }*/
            }
            return post;
        }

        public void LoadGroupFromFile(string groupname = "")
        {
            var distinctValues = new HashSet<string>();
            if (groupname == "")
            {
                groupname = @"d:\\data\comp.ai.neural-nets.mbox"; 
            }
            //var _filename = 
            int postCount = 0;
            var spaceCount = 0;
            var newPost = false;
            var postStringList = new List<string>();
            foreach (var line in File.ReadLines(groupname))
            {
                if ((line.StartsWith("From ", StringComparison.CurrentCulture)) && (line.Count(Char.IsWhiteSpace) == 1))
                {
                    //newPost = true;
                    Posts.Add(ProcessPost(postStringList));
                    postCount++;
                    postStringList.Clear();
                }
                postStringList.Add(line);
/*                else
                {
                    newPost = false;
                }*/
            }
            groupname = "";            
        }

    }
}
