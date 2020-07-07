using System;
using System.ComponentModel.DataAnnotations;
using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.Users.Student.Create
{
    public class StudentUserCreateRequest
    {
        [Required]public string FirstName { get; set; }
        [Required]public  string LastName { get; set; }
        [Required]public string Username { get; set; }
        [Required]public long CountryId { get; set; }
        [Required]public long TeacherGroupId { get; set; }
        [Required]public string Password { get; set; }
        public bool isActive = true;
        public Role Role { get; set; } = Role.Student;
        public DateTime created {get; set; }

    }
}