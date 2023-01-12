using System.ComponentModel.DataAnnotations;

namespace dotNETCoreAPIRevamp.Contracts.V1.Requests
{
    public class UserRegistrationRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; } = String.Empty;
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; } = String.Empty;
    }
}
