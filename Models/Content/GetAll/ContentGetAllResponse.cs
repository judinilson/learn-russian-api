using System;
using System.Collections.Generic;
using System.Text.Json;
using learn_Russian_API.Models.Content.DemoContents;
using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Models.Content.GetAll
{
    public class ContentGetAllResponse
    {
        public long Id { get; set; }
        public string title { get; set; }
        public  string subtitle { get; set; }
        public  string coverImage { get; set; }
        //public ICollection<DemonstrationContentsRequest> DemostrationContentses { get; set; }
        public long DemonstrationContentID { get; set; }
        public string article { get; set; } 
        public long categoryID { get; set; }
        public bool isDemo { get; set; }
        public bool isArticle { get; set; }
        public string author { get; set; }
        public DateTime created {get; set; }

    }
}