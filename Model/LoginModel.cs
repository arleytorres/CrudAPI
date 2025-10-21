namespace CrudJWT.Model
{
    public class LoginModel
    {
        public Guid Id { get; init; }
        protected string Username;
        protected string Password;
        protected string Role;
        protected string CreationTime;

        public LoginModel()
        {
            
        }

        public LoginModel(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
            CreationTime = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
        }

        public string username
        {
            get { return Username; }
            set { Username = value; }
        }

        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        public string role
        {
            get { return Role; }
            set { Role = value; }
        }
    }
}
