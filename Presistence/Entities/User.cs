#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using learn_Russian_API.Models.TeacherGroup.Create;
using learn_Russian_API.Models.Users.Teacher.Create;

namespace learn_Russian_API.Presistence.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public string Username { get; set; }
        
        public long? CountryId { get; set; }
        public long? TeacherGroupId { get; set; }
        public string? Subject { get; set; }
       public string Password { get; set; }
       public byte[] PasswordHash { get; set; }
       public byte[] PasswordSalt { get; set; }
       
       
        public Role Role { get; set; } = Role.Developer;
        public bool isActive = true;
        public DateTime created {get; set; }
    }
}