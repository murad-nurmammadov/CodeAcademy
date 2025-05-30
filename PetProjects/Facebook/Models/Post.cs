﻿namespace Models
{
    public class Post
    {
        // Fields
        public string Text;
        public DateTime Date;
        public uint LikeCount;
        public uint CommentCount;

        // Constructor
        public Post(string text)
        {
            Text = text;
            Date = DateTime.Now;
            LikeCount = 0;
            CommentCount = 0;
        }
    }
}