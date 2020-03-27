using System;

namespace learn_Russian_API.Models.Group.GetAll
{
    public class GroupGetAllResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}