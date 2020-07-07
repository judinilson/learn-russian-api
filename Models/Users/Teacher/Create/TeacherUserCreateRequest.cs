using System;
using System.ComponentModel.DataAnnotations;
using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.Users.Teacher.Create
{
    public class TeacherUserCreateRequest
    {
        [Required]public string FirstName { get; set; }
        [Required]public  string LastName { get; set; }
        [Required]public string Username { get; set; }
        [Required]public string Subject { get; set; }
        [Required]public string Password { get; set; }
        public Role Role { get; set; } = Role.Teacher;
        public bool isActive = true;
        public DateTime created {get; set; }

    }
}