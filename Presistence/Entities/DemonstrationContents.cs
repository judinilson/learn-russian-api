using System.Collections.Generic;
using learn_Russian_API.Models.Content.DemoContents;

namespace learn_Russian_API.Presistence.Entities
{
    public partial class DemonstrationContents
    {
        public long Id { get; set; }
        public ICollection<DemoContentsModel> DemostrationContentses { get; set; }
       
       
        
    }
}