using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using learn_Russian_API.Models.Content.DemoContents;
using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.Content.Create
{
    public class ContentDemoCreate
    {

        [Required]public string title { get; set; }
        public  string subtitle { get; set; }
        public  string coverImage { get; set; }
        [Required] public long DemonstrationContentID { get; set; }
        //public ICollection<DemonstrationContentsCreate> DemostrationContentses { get; set; }
        [Required]public long categoryID { get; set; }
        public bool isDemo { get; set; } = true;
        [Required]public string author { get; set; }
        public DateTime created {get; set; }  = DateTime.Now;

    }
}