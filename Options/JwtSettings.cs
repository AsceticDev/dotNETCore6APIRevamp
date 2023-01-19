namespace dotNETCoreAPIRevamp.Options
{
    public class JwtSettings
    {
        public string Key { get; set; } = String.Empty; 
        public string Issuer {get; set;} = String.Empty;
        public string Audience {get; set;} = String.Empty;
        public string Subject { get; set; }  = String.Empty;
        public int TokenDurationSeconds { get; set; }
        public int TokenDurationMinutes { get; set; }
        public int TokenDurationHours { get; set; }
        public int TokenDurationDays{ get; set; }
        public TimeSpan TokenDuration { get; set; } = TimeSpan.Zero;
    }
}
