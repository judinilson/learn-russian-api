using System.ComponentModel.DataAnnotations;
using learn_Russian_API.Models.TeacherGroup.Create;

namespace learn_Russian_API.Presistence.Entities
{
    public class Student
    {
        //public long Id { get; set; }
        public  Country Country { get; set; }
        public TeacherGroup TeacherGroup { get; set; }
        //[Required] public long CountryId { get; set; }
        //[Required] public long TeacherGroupId { get; set; }
        
        public Role Role { get; set; } = Role.Student;
    }
}