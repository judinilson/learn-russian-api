using System.ComponentModel.DataAnnotations;

namespace learn_Russian_API.Presistence.Entities
{
    public class User
    {
       [Required] public string Name { get; set; }
       [Required]  public string Password { get; set; }
        public Role Role { get; set; } = Role.Developer;
        public long Id { get; set; }
    }
}