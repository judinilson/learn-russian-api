﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace learn_Russian_API.Models.Content.Create
{
    public class ContentArticleCreate
    {
        [Required]public string title { get; set; }
        public  string subtitle { get; set; }
        public  string coverImage { get; set; }
        
        public long? DemonstrationContentID { get; set; }
        [Required] public string article { get; set; } 
        [Required]public long categoryID { get; set; }
        public bool isArticle { get; set; } = true;
        [Required]public string author { get; set; }
        public DateTime created { get; set; } = DateTime.Now;

    }
}