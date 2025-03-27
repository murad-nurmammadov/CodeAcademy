namespace CodeAcademy.Facebook
{
    class User
    {

        // User classı olsun. (Name, Surname, Email, DateOfBirth, isSingle ect.)

        // Fields
        public string Name;
        public string Surname;
        public string Email;
        public string DateOfBirth;  // Date...
        public bool IsSingle;
        public User[] Friends;
        public User[] Requests;
        public Post[] Posts;
        public Comment[] Comments;

        // Constructors
        public User(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Friends = [];
            Requests = [];
            Posts = [];
            Comments = [];
        }

        public User(string name, string surname, string email, string dateOfBirth) : this(name, surname, email)
        {
            DateOfBirth = dateOfBirth;
        }

        public User(string name, string surname, string email, string dateOfBirth, bool isSignle) : this(name, surname, email, dateOfBirth)
        {
            Email = email;
        }

        // Methods
        public void PrintInfo()
        {
            Console.WriteLine($"{Name} {Surname} - {Email}");
        }

        public void Post(string text)
        {
            Post post = new Post(text);

            Post[] modifiedPosts = new Post[Posts.Length + 1];
            for (int i = 0; i < Posts.Length; i++)
            {
                modifiedPosts[i] = Posts[i];
            }

            modifiedPosts[^1] = post;

            Posts = modifiedPosts;
        }


        public void FriendRequest(User user)
        {
            user.Requests.Append(this);
        }

        // Accept
        // Reject

        public Comment Comment()
        {
            return Comments[0];
        }

        public void Like()
        {

        }

    }
}
