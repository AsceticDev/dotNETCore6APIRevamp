namespace dotNETCoreAPIRevamp.Models
{
    public class AuthenticationResult
    {
        public string Token { get; set; } = String.Empty;
        public string RefreshToken { get; set; } = String.Empty;
        public bool Success { get; set; } = false;
        public IEnumerable<string>? Errors { get; set; }
    }
}
