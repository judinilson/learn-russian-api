﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.Content.Create
{
    public class ContentDemoCreate
    {
        [Required]public string title { get; set; }
        public  string subtitle { get; set; }
        public  string coverImage { get; set; }
        [Required]public ICollection<DemostrationContents> DemostrationContentses { get; set; }
        [Required]public long categoryID { get; set; }
        public bool isDemo { get; set; } = true;
    }
}