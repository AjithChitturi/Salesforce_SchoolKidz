namespace SchoolKidzSFCRMAPI.AuthenticationLayer.Services
{
    public interface IAuthService
    {
        public string getToken();
        public string getInstanceUrl();
        public string getId();
        public string getTokenType();
        public string getIssue();
        public string getSignature();
        public void RefreshToken();

    }
}
