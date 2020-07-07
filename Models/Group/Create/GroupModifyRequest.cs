using System;

namespace learn_Russian_API.Models.Group.Create
{
    public class GroupModifyRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}