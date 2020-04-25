namespace learn_Russian_API.Presistence.Entities
{
    public class studentCreateRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// student first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// student last name 
        /// </summary>
        public  string LastName { get; set; }
        /// <summary>
        /// student country
        /// </summary>
        public long CountryId { get; set; }
        /// <summary>
        /// student teacher
        /// </summary>
        public long TeacherId { get; set; }
        /// <summary>
        /// student group
        /// </summary>
        public long GroupId { get; set; }
    }
}