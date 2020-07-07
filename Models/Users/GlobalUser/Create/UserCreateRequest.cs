using System;
using System.ComponentModel.DataAnnotations;

namespace learn_Russian_API.Models.Users.GlobalUser.Create
{
    public class UserCreateRequest
    {
        [Required]public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required]public string Username { get; set; }
        [Required]public string Password { get; set; }
        public DateTime created {get; set; }

    }
}