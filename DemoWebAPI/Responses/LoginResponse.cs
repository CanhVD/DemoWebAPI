namespace DemoWebAPI.Responses
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string AccessToken { get; set; } = null!;
        public string ExpireTime { get; set; } = null!;
    }
}
