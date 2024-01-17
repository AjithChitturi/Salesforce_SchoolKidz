namespace SchoolKidzSFCRMAPI.AuthenticationLayer.Models
{
    public class AuthResponse
    {
        public string access_token { get; set; }
        public string instance_url { get; set; }
        public string id { get; set; }
        public string token_type { get; set; }
        public string issued_at { get; set; }
        public string signature { get; set; }

        public void refresh(AuthResponse authResponse)
        {
            access_token = authResponse.access_token;
            instance_url = authResponse.instance_url;
            id = authResponse.id;
            token_type = authResponse.token_type;
            issued_at = authResponse.issued_at;
            signature = authResponse.signature;
        }
    }
}
