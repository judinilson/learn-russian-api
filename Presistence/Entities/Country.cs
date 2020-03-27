﻿using System;

namespace learn_Russian_API.Presistence.Entities
{
    public class Country
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
        public Region Region { get; set; }
    }
}