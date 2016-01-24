using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Oz.Algorithms.Data.Cleaning;
using Oz.Algorithms.Data.Factory;

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
            var line = "";
            foreach (var s in postStringList)
            {
                if (s == "")
                {
                    headerFinish = true;
                }
                if (!headerFinish)
                {
                    if (s.StartsWith("From "))
                    {
                        post.Header.Id = s.Substring(s.IndexOf("From ", System.StringComparison.Ordinal) + s.Length);
                    }
                    else if (s.StartsWith("From: "))
                    {
                        post.Header.From = s.Substring(s.IndexOf("From: ", System.StringComparison.Ordinal) + s.Length);
                    }
                    else if (s.StartsWith("Subject: "))
                    {
                        post.Header.Subject = s.Substring(s.IndexOf("Subject: ", System.StringComparison.Ordinal) + s.Length);
                    }
                    else if (s.StartsWith("Message-ID: "))
                    {
                        post.Header.MessageId = s.Substring(s.IndexOf("Message-ID: ", System.StringComparison.Ordinal) + s.Length);
                    }
                    else if (s.StartsWith("Date: "))
                    {
                        post.Header.Date = s.Substring(s.IndexOf("Date: ", System.StringComparison.Ordinal) + s.Length);
                    }
                    post.HeaderList.Add(s);
                }
                else
                {
                    line += s;
                }
            }
            //post.Body.Add(line);
            var swr = new StopWordRemover(line);
           /* var stm = new Stemmer();
            var outList = new List<string>();
            foreach (var word in swr.Remove())
            {
                outList.Add(stm.stem(word));                
            }*/
            post.NoStopWordBody = swr.Remove();
            return post;
        }

        /// <summary>
        /// Loads Group Posts From File
        /// </summary>
        /// <param name="groupname"></param>
        public void LoadGroupFromFile(string groupname = "")
        {
            var distinctValues = new HashSet<string>();
            if (groupname == "")
            {
                groupname = @"d:\\data\alt.comp.lang.learn.c-c++.mbox"; 
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
            }
            groupname = "";            
        }

        /// <summary>
        /// Stores given group on MongoDB 
        /// </summary>
        /// <param name="mongo"></param>
        public void StoreGroupOnDb(MongoDBFactory mongo)
        {
            mongo.Connect();
            MongoCollection<BsonDocument> collection = mongo.GetCollection("comp.ai.neural-nets");
            foreach (var post in Posts)
            {
                collection.Insert(post);
            }
        }

    }
}
