using System.ComponentModel.DataAnnotations;

namespace learn_Russian_API.Models.Users
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string password { get; set; }
    }
}