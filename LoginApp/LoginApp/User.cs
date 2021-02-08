namespace LoginApp
{
    public class User
    {
        private string mName;
        private string mEmail;

        //default constructor
        public User() : this("", "")
        {
            // empty 
        }

        // first constructor
        public User(string name) : this(name, "")
        {

        }

        //overloaded constructor
        public User(string name, string email)
        {
            mName = name;
            mEmail = email;
        }
        
        public string Name
        {
            get { return mName;  }
            set { mName = value;  }
        }

        public string Email
        {
            get { return mEmail; }
        }
    }
}
