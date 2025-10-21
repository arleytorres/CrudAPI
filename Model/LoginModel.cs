namespace CrudJWT.Model
{
    public class LoginModel
    {
        public Guid Id { get; init; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public string CreationTime { get; init; }

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
    }
}
