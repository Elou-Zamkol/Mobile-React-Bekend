using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
