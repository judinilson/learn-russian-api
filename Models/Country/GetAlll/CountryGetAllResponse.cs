using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.Country.GetAlll
{
    public class CountryGetAllResponse
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
        public string Region { get; set; }
    }
}