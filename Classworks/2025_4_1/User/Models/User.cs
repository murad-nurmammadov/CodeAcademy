using System.Threading.Channels;

namespace Models
{
    public class User
    {
        // Fields
        private string _username;
        private string _email;
        private string _password;

        // Properties
        public string Username
        {
            get { return _username; }
            set
            {
                if (value.Length >= 3) { _username = value; }
            }
        }

        public string Email
        {
            get { return _password; }
            set
            {
                if (value.Contains('@')) { _email = value; }
            }
        }

        public string Password
        {
            get { return _username; }
            set
            {
                bool hasValidLength = value.Length > 8;

                bool hasLower = false;
                bool hasUpper = false;
                bool hasDigit = false;

                foreach (char c in value)
                {
                    if (Char.IsLower(c)) { hasLower = true; continue; }
                    if (Char.IsUpper(c)) { hasUpper = true; continue; }
                    if (Char.IsDigit(c)) { hasDigit = true; continue; }
                }

                if (hasValidLength && hasLower && hasUpper && hasDigit)
                {
                    _password = value;
                }
            }
        }

        // Constructor
        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        // Methods
        public void GetInfo()
        {
            Console.WriteLine($"{Username}, {Email} --- {Password}");
        }
    }
}
