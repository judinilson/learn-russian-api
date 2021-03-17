using System;
using System.Text.Json;

namespace DefaultNamespace
{
    public class ArticleContentResponse
    {
        public long Id { get; set; }
        public string title { get; set; }
        public  string subtitle { get; set; }
        //public JsonDocument article {get;set;}
        public  string coverImage { get; set; }
        public string article { get; set; } 
        public long categoryID { get; set; }
        public bool isArticle { get; set; }
        public string author { get; set; }
        public DateTime created {get; set; }

    }
}