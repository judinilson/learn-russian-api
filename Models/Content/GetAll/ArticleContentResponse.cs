using System;

namespace DefaultNamespace
{
    public class ArticleContentResponse
    {
        public string title { get; set; }
        public  string subtitle { get; set; }
        public  string coverImage { get; set; }
        public string article { get; set; } 
        public long categoryID { get; set; }
        public bool isArticle { get; set; }
        public string author { get; set; }
        public DateTime created {get; set; }

    }
}