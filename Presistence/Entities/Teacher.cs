namespace learn_Russian_API.Presistence.Entities
{
    public class Teacher
    {
        //public long Id { get; set; }
        public string Subject { get; set; }
        public Role Role { get; set; } = Role.Teacher;
    }
}