using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.Users.Student.GetAll
{
    public class StudentGetAllResponse
    {
        public long Id { get; set; }
        public long CountryId { get; set; }
        public long UserId { get; set; }
        public long TeacherGroupId { get; set; }
        public Role Role { get; set; } = Role.Student;
    }
}