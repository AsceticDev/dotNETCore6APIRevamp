namespace dotNETCoreAPIRevamp.Options
{
    public class JwtSettings
    {
        public string Key { get; set; } = String.Empty; 
        public string Issuer {get; set;} = String.Empty;
        public string Audience {get; set;} = String.Empty;
        public string Subject { get; set; }  = String.Empty;
        public double DurationInMinutes { get; set; } = 0;
    }
}
