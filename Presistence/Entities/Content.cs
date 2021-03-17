using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace learn_Russian_API.Presistence.Entities
{
    public class Content
    {
       
        public long Id { get; set; }
        public string title { get; set; }
        public  string subtitle { get; set; }
        public  string coverImage { get; set; }
        
        public long? DemonstrationContentID { get; set; }
        public string article { get; set; } = null;
        public long categoryID { get; set; }
        public bool isDemo { get; set; } = false;
        public bool isArticle { get; set; } = false;
        public string author { get; set; }
        public DateTime created {get; set; }

    }
}