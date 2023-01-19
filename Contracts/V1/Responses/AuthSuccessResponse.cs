namespace dotNETCoreAPIRevamp.Contracts.V1.Responses
{
    public class AuthSuccessResponse
    {
        public string? Token { get; set; }
        //verify email after registration request
        public string? RefreshToken { get; set; }
    }
}
