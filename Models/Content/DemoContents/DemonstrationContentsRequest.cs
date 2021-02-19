using System.Collections.Generic;

namespace learn_Russian_API.Models.Content.DemoContents
{
    public class DemonstrationContentsRequest
    {
        public long Id { get; set; }
        public ICollection<DemoContentsModel> DemostrationContentses { get; set; }
    }
}