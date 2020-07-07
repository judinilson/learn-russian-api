using System.Collections.Generic;
using learn_Russian_API.Models.Content.DemoContents;

namespace DefaultNamespace
{
    public class DemonstrationContentResponse
    {
        public string title { get; set; }
        public  string subtitle { get; set; }
        public  string coverImage { get; set; }
        public ICollection<DemonstrationContentsRequest> DemostrationContentses { get; set; }
       public long categoryID { get; set; }
        public bool isDemo { get; set; }
        public string author { get; set; }
    }
}