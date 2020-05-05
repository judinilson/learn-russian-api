using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.Users.Teacher.GetAll
{
    public class TeacherGetAllResponse
    {
        public long Id { get; set; }
        public  long UserId { get; set; }
        public string Subject { get; set; }
        public Role Role { get; set; } = Role.Teacher;
    }
}