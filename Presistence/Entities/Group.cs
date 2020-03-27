using System;

namespace learn_Russian_API.Presistence.Entities
{
    public class Group
    {
        /// <summary>
        /// identification
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// date of Group creation
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
}