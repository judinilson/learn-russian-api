using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.Users.Teacher.Create
{
    public class Teacher
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Discipline { get; set; }
        public Role Role { get; set; } = Role.Teacher;
    }
}