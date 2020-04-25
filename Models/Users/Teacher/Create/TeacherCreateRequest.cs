namespace learn_Russian_API.Models.Users.Teacher.Create
{
    public class TeacherCreateRequest
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Discipline { get; set; }
    }
}