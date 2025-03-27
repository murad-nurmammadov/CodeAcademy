namespace CodeAcademy.Facebook
{
    class Comment
    {
        // Fields
        public string Text;
        public DateTime Date;
        public User[] LikingUsers;

        // Constructor
        public Comment(string text)
        {
            Text = text;
            Date = DateTime.Now;
        }
    }
}
