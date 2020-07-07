namespace learn_Russian_API.Models.Users.GlobalUser.Update
{
    public class UserUpdateStudentRequest
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public string Username { get; set; }
        public long TeacherGroupId { get; set; }
        public string Password { get; set; }
    }
}