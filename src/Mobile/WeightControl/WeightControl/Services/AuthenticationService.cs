namespace WeightControl.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool Login(string name, string password)
        {
            return true;
        }

        public bool Register(string name, string password, string mail)
        {
            return true;
        }
    }
}   