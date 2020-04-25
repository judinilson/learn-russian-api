using learn_Russian_API.Presistence.Entities;

namespace DefaultNamespace
{
    public class StudentGetAllResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public long CountryId { get; set; }
        public long TeacherId { get; set; }
        public long GroupId { get; set; }
        public Role Role { get; set; } = Role.Student;
    }
}