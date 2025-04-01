namespace Models
{
    public class User
    {
        // Fields
        private string _username;
        private string _password;

        // Properties
        public string Username
        {
            get { return _username; }
            set
            {
                if (value.Length >= 6 && value.Length <= 25)
                {
                    _username = value;
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                bool hasValidLength = value.Length >= 8 && value.Length <= 25;
                bool hasRequiredChars = HasDigit(value) && HasLower(value) && HasUpper(value);

                if (hasValidLength && hasRequiredChars)
                {
                    _password = value;
                }
            }
        }

        // Constructor
        public User(string usernname, string password)
        {
            Username = usernname;
            Password = password;
        }

        // Methods
        private bool HasDigit(string text)
        {
            foreach (char c in text)
            {
                if (char.IsDigit(c)) { return true; }
            }

            return false;
        }

        private bool HasUpper(string text)
        {
            foreach (char c in text)
            {
                if (char.IsUpper(c)) { return true; }
            }

            return false;
        }

        private bool HasLower(string text)
        {
            foreach (char c in text)
            {
                if (char.IsLower(c)) { return true; }
            }

            return false;
        }
    }
}
