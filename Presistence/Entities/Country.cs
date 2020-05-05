using System;
using System.ComponentModel.DataAnnotations;

namespace learn_Russian_API.Presistence.Entities
{
    public partial class Country
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        [Required]
        public string Language { get; set; }
        /// <summary>
        /// continent
        /// </summary>
        public Region Region { get; set; }
    }
}