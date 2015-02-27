using System;

namespace Oz.Algorithms.Data.Acquisition.Stackoverflow
{
    internal class Post
    {
        public int? postId { get; set; }
        public int? TypeId { get; set; }
        public int? ParentId { get; set; }
        public int? AcceptedAnswerId { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Score { get; set; }
        public int? ViewCount { get; set; }
        public string Body { get; set; }
        public int? OwnerUserId { get; set; }
        public int? LastEditorUserId { get; set; }
        public string LastEditorDisplayName { get; set; }
        public DateTime? LastEditDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public DateTime? CommunityOwnedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public int? AnswerCount { get; set; }
        public int? CommentCount { get; set; }
        public int? FavoriteCount { get; set; }

        public Post()
        {
            postId = null;
            TypeId = null;
            ParentId = null;
            AcceptedAnswerId = null;
            CreationDate = null;
            Score = null;
            ViewCount = null;
            Body = null;
            OwnerUserId = null;
            LastEditorUserId = null;
            LastEditorDisplayName = null;
            LastEditDate = null;
            LastActivityDate = null;
            CommunityOwnedDate = null;
            ClosedDate = null;
            Title = null;
            Tags = null;
            AnswerCount = null;
            CommentCount = null;
            FavoriteCount = null;
        }
    }
}
