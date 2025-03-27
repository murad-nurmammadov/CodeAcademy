using Models;

namespace Facebook
{
    class Porgram()
    {
        static void Main()
        {
            /* 
             Facebook?
              • User classı olsun. (Name, Surname, Email, DateOfBirth, isSingle ect.)
              • Bu classın parametrlərini sizin müəyyən edəcəyiniz 3 constructoru olsun.
              • Post classı olsun. (Text, SharedDate, LikeCount, CommentCount ect.)
              • Comment classı olsun. (Text, CommentedDate ect.)
              • Userin Postları olsun. (Post Arrayı tipindən)
              • Postun Commentləri olsun. (Comment Arrayı tipindən)
              • Commentin Useri olsun. (User tipindən) (Kommenti yazan Useri ifadə edəcək)
             */

            User murad = new User("Murad", "Nurmammadov", "murad@gmail.com");
            User davud = new User("Davud", "Nurmammadov", "davud@gmail.com");
            User said = new User("Said", "Nurmammadov", "said@gmail.com");

            User[] users = { murad, davud, said };

            foreach (User user in users)
            {
                user.PrintInfo();
            }

            Console.WriteLine("==========");

            murad.Post("post text 1");
            murad.Post("post text 2");
            murad.Post("post text 3");

            foreach (Post post in murad.Posts)
            {
                Console.WriteLine(post.Text);
            }
        }
    }
}