namespace DemoWebAPI.Configs
{
    public class JwtConfig
    {
        public string Secret { get; set; } = string.Empty;
        public int ExpireMinutes { get; set; } = 240;
    }
}
