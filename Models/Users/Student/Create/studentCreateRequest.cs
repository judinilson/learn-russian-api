namespace learn_Russian_API.Presistence.Entities
{
    public class studentCreateRequest
    {

        public long UserId { get; set; }
   
        /// <summary>
        /// student country
        /// </summary>
        public long CountryId { get; set; }
        /// <summary>
        /// student teacher
        /// </summary>
        public long TeacherGroupId { get; set; }
 
    }
}