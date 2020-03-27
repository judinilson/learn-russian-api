namespace learn_Russian_API.Models.Country.Create
{
    public class CountryCreateRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// continent
        /// </summary>
        public int Region { get; set; }
    }
}