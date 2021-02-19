using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using learn_Russian_API.Models.Content.DemoContents;

namespace learn_Russian_API.Models.Content.Create
{
    public class DemonstrationContentsCreate
    {
        [Required] public ICollection<DemoContentsModel> DemostrationContentses { get; set; }
      
    }
}