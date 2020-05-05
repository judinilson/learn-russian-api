namespace learn_Russian_API.Models.Users.GlobalUser.Get
{
    public class UserGetResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public string Username { get; set; }
        public Presistence.Entities.Teacher tacher { get; } = null;
        public Presistence.Entities.Student student { get; } = null;
        
        
    }
}