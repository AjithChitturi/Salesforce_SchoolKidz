namespace SchoolKidzSFCRMAPI.AuthenticationLayer.Models
{
    public class AuthenticationOption
    {
        public const string AuthenticationStrings = "AuthenticationStrings";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
