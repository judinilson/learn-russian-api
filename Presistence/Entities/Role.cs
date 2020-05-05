using System.ComponentModel;

namespace learn_Russian_API.Presistence.Entities
{
    public enum Role
    {
        [Description("Teacher")]
        Teacher = 1,
        [Description("Student")]
        Student = 2,
        [Description("Administrator")]
        Admin = 3,
        [Description("Developer")]
        Developer = 4
    }
}