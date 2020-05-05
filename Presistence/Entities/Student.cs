using System.ComponentModel.DataAnnotations;

namespace learn_Russian_API.Presistence.Entities
{
    public class Student
    {
        public long Id { get; set; }
        [Required] public long userId { get; set; }
        [Required] public long CountryId { get; set; }
        [Required] public long TeacherGroupId { get; set; }
        
        public Role Role { get; set; } = Role.Student;
    }
}