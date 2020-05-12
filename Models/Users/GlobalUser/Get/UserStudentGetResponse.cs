using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.Users.GlobalUser.Get
{
    public class UserStudentGetResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public string Username { get; set; }
        
        public long CountryId { get; set; }
        public long TeacherGroupId { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public bool isActive { get; set; }
    }
}